namespace Assette.Editors.InvestmentWriter.Test;

public class InvestmentWriterTest
{
    private readonly string _templatePath = @".\template\RationaleTemplate_v6.xml";
    private string _docPath = @".\documents\doc_{{guid}}.docx";

    [Fact]
    public void CreateRationaleXml()
    {
        string rationaleXml = XmlGenerator.Create(_templatePath);
        Assert.True(!string.IsNullOrWhiteSpace(rationaleXml));
    }

    [Fact]
    public void CreateDocument()
    {
        
        string identifier = Guid.NewGuid().ToString();
        _docPath = _docPath.Replace("{{guid}}", identifier);

        string rationaleXml = XmlGenerator.Create(_templatePath);
        DocumentGenerator.Create(_docPath, rationaleXml);
        Assert.True(true);
    }
}