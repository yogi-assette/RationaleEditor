using DotLiquid;

namespace Assette.Editors.InvestmentWriter.Entities;

public record ItemWithRank : Item, ILiquidizable
{
    public required IList<int> Ranks { get; init; }
    public static string RankId { get { return Guid.NewGuid().ToString(); } }

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
