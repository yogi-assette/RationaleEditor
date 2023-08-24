using Assette.Editors.InvestmentWriter.Entities;
using Assette.Editors.RationaleWriter.Converters;
using DocumentFormat.OpenXml.Packaging;
using Newtonsoft.Json.Linq;

namespace Assette.Editors.InvestmentWriter.Test;

public class InvestmentWriterTest
{

    private string _docPath = @".\documents\doc_{{guid}}.docx";

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
        DocumentGenerator.Create(_docPath, rationaleXml);
        Assert.True(true);
    }

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
        DocumentGenerator.Create(_docPath, rationaleXml);
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
        DocumentGenerator.Create(_docPath, rationaleXml);
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

        byte[] byteArray = DocumentGenerator.Create(rationaleXml);
        File.WriteAllBytes(_docPath, byteArray);


        Assert.True(true);
    }
}