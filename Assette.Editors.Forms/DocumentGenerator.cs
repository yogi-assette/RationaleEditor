using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Text;
using System.Xml.Linq;
using System.Security.Cryptography;

namespace Assette.Editors.Forms;

public class DocumentGenerator : IDocumentGenerator
{
    private const string InvalidXmlStructureRootError = "The provided XML string does not have a 'root' element.";
    private const string InvalidXmlStructureBodyError = "The provided XML string is not properly structured with body.";

    private static void Validate(XDocument xDocument, out XElement? bodyElement)
    {
        if (xDocument.Root == null)
        {
            throw new ArgumentException(InvalidXmlStructureRootError);
        }

        bodyElement = xDocument.Root.Element("body");

        if (bodyElement == null || bodyElement?.Elements().Count() == 0)
        {
            throw new ArgumentException(InvalidXmlStructureBodyError);
        }
    }

    private static void BuildControl(IList<FormData> formData, Body body, XElement element)
    {
        switch (element.Name.LocalName)
        {
            case "br":
                body.AppendBlankLine();
                break;
            case "h1":
                body.AppendParagraph(element, AppEnums.ElementType.Heading1);
                break;
            case "h2":
                body.AppendParagraph(element, AppEnums.ElementType.Heading2);
                break;
            case "p":
                IEnumerable<XElement> childElements = element.Elements("span");
                if (childElements.Any())
                {
                    body.AppendSpans(element, childElements);
                    break;
                }

                body.AppendParagraph(element, AppEnums.ElementType.Paragraph);
                break;
            case "span1":
                body.AppendParagraph(element, AppEnums.ElementType.Span);
                break;
            case "input":
                body.AppendSdtBlockWithTable(element, formData);
                body.AppendBlankLine();
                break;
            case "table":
                body.AppendTable(element);
                break;
            default:
                break;
        }
    }

    private static void Build(IList<FormData> formData, Body body, IEnumerable<XElement>? elements, HashSet<string> processedIds)
    {
        if (elements == null || !elements.Any())
        {
            return;
        }

        IEnumerator<XElement> enumerator = elements.GetEnumerator();
        while (enumerator.MoveNext())
        {
            XElement element = enumerator.Current;
            string? elementId = element.Attribute("id")?.Value;

            if (!string.IsNullOrEmpty(elementId) && processedIds.Contains(elementId))
            {
                continue;
            }

            IEnumerable<XElement> descendants = element.Descendants();

            BuildControl(formData, body, element);
            if (elementId != null)
            {
                processedIds.Add(elementId);
            }
            Build(formData, body, descendants, processedIds);
        }
    }

    private static string RemoveIdAttributeValues(string xmlString)
    {
        XDocument xdoc = XDocument.Parse(xmlString);

        foreach (XElement element in xdoc.Descendants())
        {
            if (element.Attribute("id") != null)
            {
                element.Attribute("id").Value = string.Empty;
            }
        }

        return xdoc.ToString();
    }

    private static string GenerateHashedString(string xmlString)
    {
        byte[] xmlStringBytes = Encoding.ASCII.GetBytes(RemoveIdAttributeValues(xmlString));
        using var md5 = MD5.Create();
        byte[] xmlByteArrayHashed = md5.ComputeHash(xmlStringBytes);
        string xmlStringHashed = BitConverter.ToString(xmlByteArrayHashed).Replace("-", string.Empty);

        return xmlStringHashed;
    }

    private IList<FormData> GenerateFormData(IList<FormData> savedFormData, string xmlString)
    {
        XDocument xdoc = XDocument.Parse(xmlString);
        IList<FormData> inputFormData = new List<FormData>();
        Paragraph paragraph = StyleHelper.CreateSdtBlockParagraph();

        foreach (XElement element in xdoc.Descendants("input"))
        {
            var idValue = element.Attribute("id")?.Value;

            if (idValue != null)
            {
                var savedFormDataValue = savedFormData.FirstOrDefault(x => x.Id == idValue);
                var formDataParagraphs = savedFormDataValue?.Paragraphs ?? new List<Paragraph> { paragraph };

                inputFormData.Add(new FormData
                {
                    Id = idValue,
                    Name = idValue,
                    Paragraphs = formDataParagraphs
                });
            }
        }

        return inputFormData;
    }


    private static IList<FormData> ExtractSdtData(Body? body)
    {
        IList<FormData> sectorData = new List<FormData>();
        var sdts = body?.Descendants<SdtElement>() ?? new List<SdtElement>();
        XNamespace w = "http://schemas.openxmlformats.org/wordprocessingml/2006/main";

        // Yogi: Assumption is each SdtElement has only one SdtContentBlock
        foreach (var sdt in sdts)
        {
            FormData data = new();
            var sdtPr = sdt.GetFirstChild<SdtProperties>();
            var tag = sdtPr?.GetFirstChild<Tag>();
            data.Id = tag?.GetAttribute("val", w.NamespaceName).Value;
            var alias = sdtPr?.GetFirstChild<SdtAlias>();
            data.Name = alias?.GetAttribute("val", w.NamespaceName).Value;
            List<string?> lines = new();
            var sdtContentBlocks = sdt.Descendants<SdtContentBlock>();

            // Yogi: This FormData logic works for single SdtContentBlock 
            foreach (var sdtContentBlock in sdtContentBlocks)
            {
                var paragraphs = sdtContentBlock.Descendants<Paragraph>();
                data.Paragraphs = paragraphs;

                foreach (var paragraph in paragraphs)
                {
                    StringBuilder line = new();
                    var runs = paragraph.Descendants<Run>();

                    foreach (var run in runs)
                    {
                        string? tempText = run.GetFirstChild<Text>()?.Text;
                        if (tempText == AppConstants.SdtText) break;
                        tempText = ApplyRunProperties(run, tempText, w);
                        line.Append(tempText);
                    }
                    if (line.Length > 0) lines.Add(line.ToString());
                }
            }

            if (lines.Count > 0 && !(lines.Count == 1 && lines[0] == AppConstants.SdtText))
            {
                data.Value = $"<p>{string.Join("<br/>", lines)}</p>";
                sectorData.Add(data);
            }
        }

        return sectorData;
    }

    private static string? ApplyRunProperties(Run run, string? tempText, XNamespace w)
    {
        var runProperties = run.Descendants<RunProperties>();

        foreach (var runProperty in runProperties)
        {
            if (runProperty.Highlight != null)
            {
                tempText = $"<mark>{tempText}</mark>";
            }
            if (runProperty.Color != null && runProperty.Color.GetAttribute("val", w.NamespaceName).Value != AppConstants.SdtColor[1..])
            {
                tempText = $"<span style=\"color:#{runProperty.Color.GetAttribute("val", w.NamespaceName).Value}\">{tempText}</span>";
            }
            if (runProperty.Underline != null)
            {
                tempText = $"<u>{tempText}</u>";
            }
            if (runProperty.Bold != null)
            {
                tempText = $"<strong>{tempText}</strong>";
            }
            if (runProperty.FontSize != null)
            {
                var fontSize = runProperty.FontSize.GetAttribute("val", w.NamespaceName).Value;
                tempText = $"<span style=\"font-size:{fontSize}pt\">{tempText}</span>";
            }
        }

        return tempText;
    }


    public void Generate(string docPath, string xmlString)
    {
        XDocument xDocument = XDocument.Parse(xmlString, LoadOptions.PreserveWhitespace);
        Validate(xDocument, out XElement? bodyElement);

        using WordprocessingDocument wordDocument = WordprocessingDocument.Create(docPath, WordprocessingDocumentType.Document);
        MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
        mainPart.AddStylesPartToPackage();

        Body body = new();
        HashSet<string> processedIds = new();

        Build(new List<FormData>(), body, bodyElement?.Elements(), processedIds);

        Document document = new();
        document.AddNamespaces();
        document?.AppendChild(body);
        mainPart.Document = document ?? new Document();
        mainPart.Document?.Save();
    }

    public byte[] Generate(string xmlString)
    {
        var formData = GenerateFormData(new List<FormData>(), xmlString);
        return Generate(formData, xmlString);

        /* TODO: This code has to be removed after testing

        XDocument xDocument = XDocument.Parse(xmlString, LoadOptions.PreserveWhitespace);
        Validate(xDocument, out XElement? bodyElement);

        using MemoryStream stream = new();
        using WordprocessingDocument wordDocument = WordprocessingDocument.Create(stream, WordprocessingDocumentType.Document);

        string xmlStringHashed = GenerateHashedString(xmlString);
        wordDocument.SetCustomFileProperties(xmlStringHashed);

        MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
        mainPart.AddStylesPartToPackage();
        mainPart.EnableTrackChanges();

        Body body = new();
        HashSet<string> processedIds = new();

        Build(body, bodyElement?.Elements(), processedIds);

        Document document = new();
        document.AddNamespaces();
        document?.AppendChild(body);
        mainPart.Document = document ?? new Document();
        mainPart.Document?.Save();

        wordDocument.Dispose();

        stream.Flush();
        return stream.ToArray();
        */
    }

    private byte[] Generate(IList<FormData> formData, string xmlString , IEnumerable<Comment>? comments = null)
    {
        XDocument xDocument = XDocument.Parse(xmlString, LoadOptions.PreserveWhitespace);
        Validate(xDocument, out XElement? bodyElement);

        using MemoryStream stream = new();
        using WordprocessingDocument wordDocument = WordprocessingDocument.Create(stream, WordprocessingDocumentType.Document);

        string xmlStringHashed = GenerateHashedString(xmlString);
        wordDocument.SetCustomFileProperties(xmlStringHashed);

        MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
        mainPart.AddStylesPartToPackage();
        mainPart.EnableTrackChanges();

        Body body = new();
        HashSet<string> processedIds = new();

        Build(formData, body, bodyElement?.Elements(), processedIds);

        Document document = new();
        document.AddNamespaces();
        document?.AppendChild(body);
        mainPart.Document = document ?? new Document();
        mainPart.AddCommentsPart(comments);
        mainPart.Document?.Save();

        wordDocument.Dispose();

        stream.Flush();
        return stream.ToArray();
    }

    public byte[] ProcessContent(byte[] byteArray, string xmlString, out IList<FormData> formData)
    {
        byte[] clonedByteArray = (byte[])byteArray.Clone();

        formData = new List<FormData>();

        using MemoryStream stream = new(clonedByteArray);
        using WordprocessingDocument wordDocument = WordprocessingDocument.Open(stream, true);
        wordDocument.GetCustomFileProperties(out string dataModelValue);

        if (dataModelValue != GenerateHashedString(xmlString))
        {
            // Extract the comments from the word document
            WordprocessingCommentsPart? commentsPart = wordDocument.MainDocumentPart?.WordprocessingCommentsPart;
            var comments = commentsPart?.Comments.Elements<Comment>();


            Body? body = wordDocument.MainDocumentPart?.Document.Body;
            IList<FormData> savedFormData = ExtractSdtData(body);

            // Get the input ids from the xmlString
            formData = GenerateFormData(savedFormData, xmlString);

            return Generate(formData, xmlString, comments);
        }

        return byteArray;
    }

}
