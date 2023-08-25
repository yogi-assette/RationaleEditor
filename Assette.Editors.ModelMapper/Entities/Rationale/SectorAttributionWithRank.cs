using DotLiquid;

namespace Assette.Editors.ModelMapper.Entities.Rationale;

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
