using DotLiquid;

namespace Assette.Editors.Forms.Mapper.Entities.Rationale;

public record ItemWithRank : Item, ILiquidizable
{
    public required IList<int> Ranks { get; init; }
    public string RankId { get { return Guid.NewGuid().ToString(); } }

    public new object ToLiquid()
    {
        return new
        {
            TitleId,
            Title,
            InputId,
            Ranks,
            RankId
        };
    }
}
