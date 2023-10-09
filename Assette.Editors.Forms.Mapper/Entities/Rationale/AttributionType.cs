using DotLiquid;

namespace Assette.Editors.Forms.Mapper.Entities.Rationale;
public readonly record struct AttributionType : ILiquidizable
{
    public readonly string TitleId { get { return Guid.NewGuid().ToString(); } }
    public string Title { get; init; }
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
