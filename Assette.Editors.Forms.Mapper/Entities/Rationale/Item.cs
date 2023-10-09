using DotLiquid;

namespace Assette.Editors.Forms.Mapper.Entities.Rationale;

public record Item : ILiquidizable
{
    public required string Title { get; init; }
    public string TitleId { get { return Guid.NewGuid().ToString(); } }
    public required string InputId { get; init; }

    public object ToLiquid()
    {
        return new
        {
            TitleId,
            Title,
            InputId
        };
    }
}
