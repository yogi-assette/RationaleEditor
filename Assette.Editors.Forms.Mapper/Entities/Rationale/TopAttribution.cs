﻿using DotLiquid;

namespace Assette.Editors.Forms.Mapper.Entities.Rationale;

public record TopAttribution : ILiquidizable
{
    public string TitleId { get { return Guid.NewGuid().ToString(); } }
    public required string Title { get; init; }
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
