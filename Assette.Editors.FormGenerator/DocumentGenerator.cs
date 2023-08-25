using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Text;
using System.Xml.Linq;

namespace Assette.Editors.FormGenerator;

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

    private static void BuildControl(Body body, XElement element)
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
                body.AppendSdtBlockWithTable(element);
                body.AppendBlankLine();
                break;
            case "table":
                body.AppendTable(element);
                break;
            default:
                break;
        }
    }

    private static void Build2(Body body, IEnumerable<XElement>? elements)
    {
        if (elements == null || !elements.Any())
        {
            return;
        }

        foreach (XElement element in elements)
        {
            IEnumerable<XElement> descendants = element.DescendantsAndSelf().Distinct();

            BuildControl(body, element);
            Build2(body, descendants);
        }
    }


    private static void Build(Body body, IEnumerable<XElement>? elements, HashSet<string> processedIds)
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

            BuildControl(body, element);
            if (elementId != null)
            {
                processedIds.Add(elementId);
            }
            Build(body, descendants, processedIds);
        }
    }

    private static IList<FormData> ExtractSdtData(Body? body)
    {
        IList<FormData> sectorData = new List<FormData>();
        var sdts = body?.Descendants<SdtElement>() ?? new List<SdtElement>();
        XNamespace w = "http://schemas.openxmlformats.org/wordprocessingml/2006/main";

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

            foreach (var sdtContentBlock in sdtContentBlocks)
            {
                var paragraphs = sdtContentBlock.Descendants<Paragraph>();

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

            if (lines.Count > 0)
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

        Build(body, bodyElement?.Elements(), processedIds);

        Document document = new();
        document.AddNamespaces();
        document?.AppendChild(body);
        mainPart.Document = document ?? new Document();
        mainPart.Document?.Save();
    }

    public byte[] Generate(string xmlString)
    {
        XDocument xDocument = XDocument.Parse(xmlString, LoadOptions.PreserveWhitespace);
        Validate(xDocument, out XElement? bodyElement);

        using MemoryStream stream = new();
        using WordprocessingDocument wordDocument = WordprocessingDocument.Create(stream, WordprocessingDocumentType.Document);
        MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
        mainPart.AddStylesPartToPackage();

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
    }

    public IList<FormData> Process(byte[] byteArray)
    {
        using MemoryStream stream = new(byteArray);
        using WordprocessingDocument wordDocument = WordprocessingDocument.Open(stream, true);
        Body? body = wordDocument.MainDocumentPart?.Document.Body;

        return ExtractSdtData(body);
    }
}
