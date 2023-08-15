using DotLiquid;

namespace Assette.Editors.InvestmentWriter.Entities;

public record SectorAttributionWithRank : ItemWithRank, ILiquidizable
{
    public required TopSecurity TopSecurity { get; init; }

    public new object ToLiquid()
    {
        return new
        {
            TitleId,
            Title,
            InputId,
            RankId,
            Ranks,
            TopSecurity
        };
    }
}
