using Assette.Editors.Forms.Mapper.Entities.Rationale;

namespace Assette.Editors.Forms.Test.TestData;

public class RationaleStructure5
{
    public Rationale Get
    {
        get
        {
            return rationale;
        }
    }

    private readonly Rationale rationale = new()
    {
        UniqueId = "rationale-uid",
        Version = "1.0.0",
        Title = "Rationale for Large Cap Value | Equities",
        CategoryTitle = "Sector Attribution",
        Overview = new SectorAttribution
        {
            Title = "Sector Attribution Overview",
            InputId = "sector-attribution-overview",
        },
        SubCategories = new List<AttributionType>
        {
            new AttributionType
            {
                Title = "Absolute",
                Section = new SectorAttribution
                {
                    Title = "Absolute Summary",
                    InputId = "absolute-summary",
                },
                TopAttributions = new List<TopAttribution>
                {
                    new TopAttribution
                    {
                        Title = "Top 5 Absolute Contributors (5)",
                        SectorAttributionWithRanks = new List<SectorAttributionWithRank>
                        {
                            new SectorAttributionWithRank
                            {
                                Title = "Information Technology",
                                Ranks = new List<int> { 1, 2 },
                                InputId = "information-technology1",
                                TopSecurity = new TopSecurity
                                {
                                    Title = "Top 3 Securities (3)",
                                    SecurityAttributionWithRanks = new List<SecurityAttributionWithRank>
                                    {
                                        new SecurityAttributionWithRank
                                        {
                                            Title = "Apple Inc.",
                                            Ranks = new List<int> { 1, 2 },
                                            InputId = "apple-inc1",
                                        },
                                        new SecurityAttributionWithRank
                                        {
                                            Title = "Microsoft Corp.",
                                            Ranks = new List<int> { 2 },
                                            InputId = "microsoft-corp1",
                                        },
                                        new SecurityAttributionWithRank
                                        {
                                            Title = "IBM - New",
                                            Ranks = new List<int> { 3 },
                                            InputId = "ibm",
                                        }
                                    }
                                }
                            }
                            
                        }

                    },
                    new TopAttribution
                    {
                        Title = "Top 5 Absolute Detractors (3)",
                        SectorAttributionWithRanks = new List<SectorAttributionWithRank>
                        {
                            new SectorAttributionWithRank
                            {
                                Title = "Communication Services",
                                Ranks = new List<int> { 3 },
                                InputId = "communication-services2",
                                TopSecurity = new TopSecurity
                                {
                                    Title = "Top 1 Securities (1)",
                                    SecurityAttributionWithRanks = new List<SecurityAttributionWithRank>
                                    {
                                        new SecurityAttributionWithRank
                                        {
                                            Title = "Alphabet Inc.",
                                            Ranks = new List<int> { 1 },
                                            InputId = "alphabet-inc2"
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            },
            new AttributionType
            {
                Title = "Relative",
                Section = new SectorAttribution
                {
                    Title = "Relative Summary",
                    InputId = "relative-summary",
                },
                TopAttributions = new List<TopAttribution>
                {
                    new TopAttribution
                    {
                        Title = "Top 5 Relative Contributors (5)",
                        SectorAttributionWithRanks = new List<SectorAttributionWithRank>
                        {
                            new SectorAttributionWithRank
                            {
                                Title = "Information Technology",
                                Ranks = new List<int> { 1, 2 },
                                InputId = "information-technology2",
                                TopSecurity = new TopSecurity
                                {
                                    Title = "Top 3 Securities (3)",
                                    SecurityAttributionWithRanks = new List<SecurityAttributionWithRank>
                                    {
                                        new SecurityAttributionWithRank
                                        {
                                            Title = "Apple Inc.",
                                            Ranks = new List<int> { 1 },
                                            InputId = "apple-inc2"
                                        },
                                        new SecurityAttributionWithRank
                                        {
                                            Title = "Microsoft Corp.",
                                            Ranks = new List<int> { 2 },
                                            InputId = "microsoft-corp2"
                                        },
                                        new SecurityAttributionWithRank
                                        {
                                            Title = "Visa Inc.",
                                            Ranks = new List<int> { 3 },
                                            InputId = "visa-inc2"
                                        }
                                    }
                                }
                            },
                            new SectorAttributionWithRank
                            {
                                Title = "Health Care",
                                Ranks = new List<int> { 3 },
                                InputId = "health-care2",
                                TopSecurity = new TopSecurity
                                {
                                    Title = "Top 3 Securities (3)",
                                    SecurityAttributionWithRanks = new List<SecurityAttributionWithRank>
                                    {
                                        new SecurityAttributionWithRank
                                        {
                                            Title = "UnitedHealth Group Inc.",
                                            Ranks = new List<int> { 1 },
                                            InputId = "unitedhealth-group-inc2"
                                        },
                                        new SecurityAttributionWithRank
                                        {
                                            Title = "Johnson &amp; Johnson",
                                            Ranks = new List<int> { 2 },
                                            InputId = "johnson-johnson2"
                                        },
                                        new SecurityAttributionWithRank
                                        {
                                            Title = "Pfizer Inc.",
                                            Ranks = new List<int> { 3 },
                                            InputId = "pfizer-inc2"
                                        }
                                    }
                                }
                            },
                            new SectorAttributionWithRank
                            {
                                Title = "Consumer Discretionary",
                                Ranks = new List<int> { 4 },
                                InputId = "consumer-discretionary2",
                                TopSecurity = new TopSecurity
                                {
                                    Title = "Top 3 Securities (3)",
                                    SecurityAttributionWithRanks = new List<SecurityAttributionWithRank>
                                    {
                                        new SecurityAttributionWithRank
                                        {
                                            Title = "Amazon.com Inc.",
                                            Ranks = new List<int> { 1 },
                                            InputId = "amazon-com-inc2"
                                        },
                                        new SecurityAttributionWithRank
                                        {
                                            Title = "Home Depot Inc.",
                                            Ranks = new List<int> { 2 },
                                            InputId = "home-depot-inc2"
                                        },
                                        new SecurityAttributionWithRank
                                        {
                                            Title = "Comcast Corp.",
                                            Ranks = new List<int> { 3 },
                                            InputId = "comcast-corp2"
                                        }
                                    }
                                }
                            },
                        }
                    },
                }
            }
        }
    };

}
