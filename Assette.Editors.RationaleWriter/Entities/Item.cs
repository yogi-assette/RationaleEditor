﻿using DotLiquid;

namespace Assette.Editors.InvestmentWriter.Entities;

public record Item : ILiquidizable
{
    public required string Title { get; init; }
    public string TitleId { get { return Guid.NewGuid().ToString(); } }
    public string InputId { get { return Guid.NewGuid().ToString(); } }

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
