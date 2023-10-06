using Assette.Editors.FormGenerator.Test.TestData;
using Assette.Editors.ModelMapper.Converters;
using Assette.Editors.ModelMapper.Entities.Rationale;
using Newtonsoft.Json.Linq;

namespace Assette.Editors.FormGenerator.Test;

public class FormGeneratorTest
{

    private string _docPath = @".\documents\doc_{{guid}}.docx";
    private string _docPathUpdated = @".\documents\doc_{{guid}}.docx";


    private byte[] GetDocumentByteArray()
    {
        string[] identifiers = new[] {
            "1188690f-1feb-4857-a476-f2c019cddaa0",
            "8de28d60-68ca-498c-88a5-a0964831e0d1",
            "c2e1dda0-e3ec-4738-b2a6-87bcf51c1a70",
            "0e172ce7-7b20-46b9-be3a-604274f532b3",
            "2323b454-96a6-4bfc-973a-c47029b18b9d",
            "01679e2a-9747-44fb-a29f-94b30796abb2",
            "0e172ce7-7b20-46b9-be3a-604274f532b3",
            "6a9a4be4-5b65-4c85-955f-08da7b984031",
            "5ee1d2ea-7f9f-45a5-be52-69065aeeb72b",
            "5239bd2c-0ce4-4273-8e0e-09bb4302d800"
        };
        _docPath = _docPath.Replace("{{guid}}", identifiers[0]);

        byte[] byteArray = File.ReadAllBytes(_docPath);

        File.WriteAllBytes(@".\documents\doc_test.docx", byteArray);

        return byteArray;
    }

    /* TODO: Should be removed

    [Fact]
    public void CreateRationaleXml()
    {
        string _templatePath = @".\template\RationaleTemplate_v7.xml";
        string rationaleXml = XmlGenerator.Create(_templatePath);
        Assert.True(!string.IsNullOrWhiteSpace(rationaleXml));
    }

    [Fact]
    public void CreateDocumentUsingRationale()
    {
        string _templatePath = @".\template\RationaleTemplate_v6.xml";

        string identifier = Guid.NewGuid().ToString();
        _docPath = _docPath.Replace("{{guid}}", identifier);

        RationaleTest rationaleTest = new();
        Rationale rationale = rationaleTest.Get;

        string rationaleXml = XmlGenerator.Create(rationale, _templatePath);

        IDocumentGenerator documentGenerator = new DocumentGenerator();
        documentGenerator.Generate(_docPath, rationaleXml);
        Assert.True(true);
    }
    */

    [Fact]
    public void CreateDocumentUsingJObject()
    {
        // TODO: Not working...
        string _templatePath = @".\template\RationaleTemplate_v7.xml";

        string identifier = Guid.NewGuid().ToString();
        _docPath = _docPath.Replace("{{guid}}", identifier);

        RationaleStructure1 rationaleTest = new();
        Rationale rationale = rationaleTest.Get;

        JObject structureData = JObject.FromObject(rationale);
        string rationaleXml = XmlGenerator.Create(structureData, _templatePath);

        IDocumentGenerator documentGenerator = new DocumentGenerator();
        documentGenerator.Generate(_docPath, rationaleXml);

        Assert.True(true);
    }
    // Create a new document using a data model structure - ver1
    [Fact]
    public void CreateDocumentUsingDictionary()
    {
        string _templatePath = @".\template\RationaleTemplate_v7.xml";

        string identifier = Guid.NewGuid().ToString();
        _docPath = _docPath.Replace("{{guid}}", identifier);

        RationaleStructure1 rationaleTest = new();
        Rationale rationaleStructure = rationaleTest.Get;

        RationaleConverter rationaleConverter = new();
        var structureData = rationaleConverter.RationaleToDictionary(rationaleStructure);
        string rationaleXml = XmlGenerator.Create(structureData, _templatePath);

        IDocumentGenerator documentGenerator = new DocumentGenerator();
        documentGenerator.Generate(_docPath, rationaleXml);

        Assert.True(true);
    }

    // Create a new document using a data model structure - ver2
    [Fact]
    public void CreateDocumentInByteArray()
    {
        string _templatePath = @".\template\RationaleTemplate_v7.xml";


        RationaleStructure2 rationaleTest = new();
        Rationale rationale = rationaleTest.Get;

        RationaleConverter rationaleConverter = new();
        var rationaleDictionary = rationaleConverter.RationaleToDictionary(rationale);
        string rationaleXml = XmlGenerator.Create(rationaleDictionary, _templatePath);

        IDocumentGenerator documentGenerator = new DocumentGenerator();
        byte[] byteArray = documentGenerator.Generate(rationaleXml);

        // Saved locally for testing purpose
        string identifier = Guid.NewGuid().ToString();
        _docPath = _docPath.Replace("{{guid}}", identifier);
        File.WriteAllBytes(_docPath, byteArray);


        Assert.True(true);
    }

    // Modify the word document Using same data model structure
    [Fact]
    public void ProcessDocumentUsingByteArray()
    {
        //This code will be called from content service
        byte[] bytes = GetDocumentByteArray();

        string _templatePath = @".\template\RationaleTemplate_v7.xml";

        RationaleStructure2 rationaleTest = new();
        Rationale rationale = rationaleTest.Get;

        RationaleConverter rationaleConverter = new();
        var rationaleDictionary = rationaleConverter.RationaleToDictionary(rationale);
        string rationaleXml = XmlGenerator.Create(rationaleDictionary, _templatePath);


        IDocumentGenerator documentGenerator = new DocumentGenerator();
        byte[] byteArray = documentGenerator.ProcessContent(bytes, rationaleXml, out IList<FormData> formData);

        string identifier = Guid.NewGuid().ToString();
        _docPathUpdated = _docPathUpdated.Replace("{{guid}}", identifier);
        File.WriteAllBytes(_docPathUpdated, byteArray);

        Assert.True(true);
    }

    // Modify the word document using different data model structure from the one it was used to create the previous document
    [Fact]
    public void ProcessDocumentUsingByteArrayWithDifferentStructure()
    {
        //This code will be called from content service
        byte[] bytes = GetDocumentByteArray();

        string _templatePath = @".\template\RationaleTemplate_v7.xml";

        RationaleStructure3 rationaleTest = new();
        Rationale rationale = rationaleTest.Get;

        RationaleConverter rationaleConverter = new();
        var rationaleDictionary = rationaleConverter.RationaleToDictionary(rationale);
        string rationaleXml = XmlGenerator.Create(rationaleDictionary, _templatePath);


        IDocumentGenerator documentGenerator = new DocumentGenerator();
        byte[] byteArray = documentGenerator.ProcessContent(bytes, rationaleXml, out IList<FormData> formData);

        string identifier = Guid.NewGuid().ToString();
        _docPathUpdated = _docPathUpdated.Replace("{{guid}}", identifier);
        File.WriteAllBytes(_docPathUpdated, byteArray);

        Assert.True(true);
    }
}