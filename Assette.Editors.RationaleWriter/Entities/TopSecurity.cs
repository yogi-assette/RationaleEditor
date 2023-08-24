using DotLiquid;

namespace Assette.Editors.InvestmentWriter.Entities;

public record TopSecurity : ILiquidizable
{
    public string TitleId { get { return Guid.NewGuid().ToString(); } }
    public required string Title { get; init; }
    public required IList<SecurityAttributionWithRank> SecurityAttributionWithRanks { get; init; }

    public object ToLiquid()
    {
        return new
        {
            TitleId,
            Title,
            SecurityAttributionWithRanks
        };
    }
}
