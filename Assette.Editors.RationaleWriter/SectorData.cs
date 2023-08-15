using DocumentFormat.OpenXml.Wordprocessing;

namespace Assette.Editors.InvestmentWriter;
public class SectorData
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? Value { get; set; }
    public IEnumerable<Paragraph>? RunParagraphs { get; set; }
}
