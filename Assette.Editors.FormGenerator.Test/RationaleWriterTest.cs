using Assette.Editors.FormGenerator.Test.TestData;
using Assette.Editors.ModelMapper.Converters;
using Assette.Editors.ModelMapper.Entities.Rationale;
using Newtonsoft.Json.Linq;

namespace Assette.Editors.FormGenerator.Test;

public class FormGeneratorTest
{

    private string _docPath = @".\documents\doc_{{guid}}.docx";

    private byte[] GetDocumentByteArray()
    {
        string[] identifiers = new[] {
            "6a9a4be4-5b65-4c85-955f-08da7b984031",
            "5ee1d2ea-7f9f-45a5-be52-69065aeeb72b", 
            "5239bd2c-0ce4-4273-8e0e-09bb4302d800"
        };
        _docPath = _docPath.Replace("{{guid}}", identifiers[0]);

        byte[] byteArray = File.ReadAllBytes(_docPath);

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

        JObject data = JObject.FromObject(rationale);
        string rationaleXml = XmlGenerator.Create(data, _templatePath);

        IDocumentGenerator documentGenerator = new DocumentGenerator();
        documentGenerator.Generate(_docPath, rationaleXml);

        Assert.True(true);
    }

    [Fact]
    public void CreateDocumentUsingDictionary()
    {
        string _templatePath = @".\template\RationaleTemplate_v7.xml";

        string identifier = Guid.NewGuid().ToString();
        _docPath = _docPath.Replace("{{guid}}", identifier);

        RationaleStructure1 rationaleTest = new();
        Rationale rationale = rationaleTest.Get;

        RationaleConverter rationaleConverter = new();
        var data = rationaleConverter.RationaleToDictionary(rationale);
        string rationaleXml = XmlGenerator.Create(data, _templatePath);

        IDocumentGenerator documentGenerator = new DocumentGenerator();
        documentGenerator.Generate(_docPath, rationaleXml);

        Assert.True(true);
    }


    [Fact]
    public void CreateDocumentInByteArray()
    {
        string _templatePath = @".\template\RationaleTemplate_v7.xml";

        string identifier = Guid.NewGuid().ToString();
        _docPath = _docPath.Replace("{{guid}}", identifier);

        RationaleStructure2 rationaleTest = new();
        Rationale rationale = rationaleTest.Get;

        RationaleConverter rationaleConverter = new();
        var rationaleDictionary = rationaleConverter.RationaleToDictionary(rationale);
        string rationaleXml = XmlGenerator.Create(rationaleDictionary, _templatePath);

        IDocumentGenerator documentGenerator = new DocumentGenerator();
        byte[] byteArray = documentGenerator.Generate(rationaleXml);

        File.WriteAllBytes(_docPath, byteArray);


        Assert.True(true);
    }

    [Fact]
    public void ProcessDocumentUsingByteArray()
    {
        byte[] bytes = GetDocumentByteArray();

        IDocumentGenerator documentGenerator = new DocumentGenerator();
        var sectorData = documentGenerator.Process(bytes);

        Assert.True(sectorData.Count > 0);
    }
}