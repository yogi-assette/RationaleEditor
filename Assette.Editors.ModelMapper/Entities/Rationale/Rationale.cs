using DotLiquid;

namespace Assette.Editors.ModelMapper.Entities.Rationale;

public readonly record struct Rationale : ILiquidizable
{
    private readonly HashSet<Guid> _generatedGuids;

    public Rationale()
    {
        _generatedGuids = new HashSet<Guid>();
    }

    public string GenerateGuid()
    {
        Guid guid = Guid.NewGuid();
        while (_generatedGuids.Contains(guid))
        {
            guid = Guid.NewGuid();
        }
        _generatedGuids.Add(guid);

        return guid.ToString();
    }

    public string UniqueId { get; init; }
    public string Version { get; init; }
    public string Title { get; init; }
    public readonly string TitleId { get { return Guid.NewGuid().ToString(); } }
    public string CategoryTitle { get; init; }
    public readonly string CategoryTitleId { get { return Guid.NewGuid().ToString(); } }
    public SectorAttribution Overview { get; init; }
    public IList<AttributionType> SubCategories { get; init; }

    public object ToLiquid()
    {
        return new
        {
            UniqueId,
            Version,
            Title,
            TitleId,
            CategoryTitle,
            CategoryTitleId,
            Overview,
            SubCategories
        };
    }
}
