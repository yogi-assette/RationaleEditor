using DotLiquid;

namespace Assette.Editors.InvestmentWriter.Entities;
public readonly record struct AttributionType : ILiquidizable
{
    public string Title { get; init; }
    public readonly string TitleId { get { return Guid.NewGuid().ToString(); } }
    public SectorAttribution Section { get; init; }
    public IList<TopAttribution> TopAttributions { get; init; }

    public object ToLiquid()
    {
        return new
        {
            Title,
            TitleId,
            Section,
            TopAttributions
        };
    }
}
