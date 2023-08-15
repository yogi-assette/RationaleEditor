using DotLiquid;

namespace Assette.Editors.InvestmentWriter.Entities;

public record TopAttribution : ILiquidizable
{
    public required string Title { get; init; }
    public static string TitleId { get { return Guid.NewGuid().ToString(); } }
    public required IList<SectorAttributionWithRank> SectorAttributionWithRanks { get; init; }

    public object ToLiquid()
    {
        return new
        {
            Title,
            TitleId,
            SectorAttributionWithRanks
        };
    }
}
