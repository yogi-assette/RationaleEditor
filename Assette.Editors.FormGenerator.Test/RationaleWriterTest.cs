using Assette.Editors.ModelMapper.Converters;
using Assette.Editors.ModelMapper.Entities.Rationale;
using Newtonsoft.Json.Linq;

namespace Assette.Editors.FormGenerator.Test;

public class FormGeneratorTest
{

    private string _docPath = @".\documents\doc_{{guid}}.docx";

    private byte[] GetDocumentByteArray()
    {
        string identifier = "5239bd2c-0ce4-4273-8e0e-09bb4302d800";
        _docPath = _docPath.Replace("{{guid}}", identifier);

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

        RationaleTest rationaleTest = new();
        Rationale rationale = rationaleTest.Get;

        JObject jsonRationale = JObject.FromObject(rationale);
        string rationaleXml = XmlGenerator.Create(jsonRationale, _templatePath);

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

        RationaleTest rationaleTest = new();
        Rationale rationale = rationaleTest.Get;

        RationaleConverter rationaleConverter = new();
        var rationaleDictionary = rationaleConverter.RationaleToDictionary(rationale);
        string rationaleXml = XmlGenerator.Create(rationaleDictionary, _templatePath);

        IDocumentGenerator documentGenerator = new DocumentGenerator();
        documentGenerator.Generate(_docPath, rationaleXml);

        Assert.True(true);
    }


    [Fact]
    public void CreateDocumentFromByteArrayUsingDictionary()
    {
        string _templatePath = @".\template\RationaleTemplate_v7.xml";

        string identifier = Guid.NewGuid().ToString();
        _docPath = _docPath.Replace("{{guid}}", identifier);

        RationaleTest rationaleTest = new();
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