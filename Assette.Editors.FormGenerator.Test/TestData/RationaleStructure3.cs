using Assette.Editors.ModelMapper.Entities.Rationale;

namespace Assette.Editors.FormGenerator.Test.TestData;

public class RationaleStructure3
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
                                            Title = "IBM",
                                            Ranks = new List<int> { 3 },
                                            InputId = "ibm",
                                        }
                                    }
                                }
                            },
                            new SectorAttributionWithRank
                            {
                                Title = "Consumer Discretionary Updated",
                                Ranks = new List<int> { 4 },
                                InputId = "consumer-discretionary-updated1",
                               TopSecurity = new TopSecurity
                               {
                                    Title = "Top 3 Securities (3)",
                                    SecurityAttributionWithRanks = new List<SecurityAttributionWithRank>
                                    {
                                        new SecurityAttributionWithRank
                                        {
                                            Title = "Amazon.com Inc.",
                                            Ranks = new List<int> { 1 },
                                            InputId = "amazon-com-inc1",
                                        },
                                        new SecurityAttributionWithRank
                                        {
                                            Title = "Home Depot Inc.- updated",
                                            Ranks = new List<int> { 2 },
                                            InputId = "home-depot-inc-updated1",
                                        },
                                        new SecurityAttributionWithRank
                                        {
                                            Title = "Comcast Corp.",
                                            Ranks = new List<int> { 3 },
                                            InputId = "comcast-corp1",
                                        }
                                    }
                                }
                            },
                            new SectorAttributionWithRank
                            {
                                Title = "Financials",
                                Ranks = new List<int> { 5 },
                                InputId = "financials",
                               TopSecurity = new TopSecurity
                               {
                                    Title = "Top 3 Securities (3)",
                                    SecurityAttributionWithRanks = new List<SecurityAttributionWithRank>
                                    {
                                        new SecurityAttributionWithRank
                                        {
                                            Title = "Berkshire Hathaway Inc.",
                                            Ranks = new List<int> { 1 },
                                            InputId = "berkshire-hathaway-inc1",
                                        },
                                        new SecurityAttributionWithRank
                                        {
                                            Title = "JPMorgan Chase &amp; Co.",
                                            Ranks = new List<int> { 2 },
                                            InputId = "jpmorgan-chase-co",
                                        },
                                        new SecurityAttributionWithRank
                                        {
                                            Title = "Bank of America Corp.",
                                            Ranks = new List<int> { 3 },
                                            InputId = "bank-of-america-corp",
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
                                    Title = "Top 3 Securities (3)",
                                    SecurityAttributionWithRanks = new List<SecurityAttributionWithRank>
                                    {
                                        new SecurityAttributionWithRank
                                        {
                                            Title = "Alphabet Inc.",
                                            Ranks = new List<int> { 1 },
                                            InputId = "alphabet-inc2"
                                        },
                                        new SecurityAttributionWithRank
                                        {
                                            Title = "Facebook Inc.",
                                            Ranks = new List<int> { 2 },
                                            InputId = "facebook-inc2"
                                        },
                                        new SecurityAttributionWithRank
                                        {
                                            Title = "AT&amp;T Inc.",
                                            Ranks = new List<int> { 3 },
                                            InputId = "at-t-inc2"
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
                    new TopAttribution
                    {
                        Title = "Top 5 Relative Detractors (3)",
                        SectorAttributionWithRanks = new List<SectorAttributionWithRank>
                        {
                            new SectorAttributionWithRank
                            {
                                Title = "Financials",
                                Ranks = new List<int> { 1 },
                                InputId = "financials4",
                                TopSecurity = new TopSecurity
                                {
                                    Title = "Top 3 Securities (3)",
                                    SecurityAttributionWithRanks = new List<SecurityAttributionWithRank>
                                    {
                                        new SecurityAttributionWithRank
                                        {
                                            Title = "Berkshire Hathaway Inc.",
                                            Ranks = new List<int> { 1 },
                                            InputId = "berkshire-hathaway-inc4"
                                        },
                                        new SecurityAttributionWithRank
                                        {
                                            Title = "JPMorgan Chase &amp; Co.",
                                            Ranks = new List<int> { 2 },
                                            InputId = "jpmorgan-chase-co4"
                                        },
                                    }
                                }
                            },
                            new SectorAttributionWithRank
                            {
                                Title = "Energy",
                                Ranks = new List<int> { 2 },
                                InputId = "energy3",
                                TopSecurity = new TopSecurity
                                {
                                    Title = "Top 3 Securities (3)",
                                    SecurityAttributionWithRanks = new List<SecurityAttributionWithRank>
                                    {
                                        new SecurityAttributionWithRank
                                        {
                                            Title = "Exxon Mobil Corp.",
                                            Ranks = new List<int> { 1 },
                                            InputId = "exxon-mobil-corp3"
                                        },
                                        new SecurityAttributionWithRank
                                        {
                                            Title = "Chevron Corp.",
                                            Ranks = new List<int> { 2 },
                                            InputId = "chevron-corp3"
                                        },
                                    }
                                }
                            },
                            new SectorAttributionWithRank
                            {
                                Title = "Communication Services",
                                Ranks = new List<int> { 3 },
                                InputId = "communication-services3",
                               TopSecurity = new TopSecurity
                               {
                                    Title = "Top 3 Securities (3)",
                                    SecurityAttributionWithRanks = new List<SecurityAttributionWithRank>
                                    {
                                        new SecurityAttributionWithRank
                                        {
                                            Title = "Alphabet Inc.",
                                            Ranks = new List<int> { 1 },
                                            InputId = "alphabet-inc3"
                                        },
                                        new SecurityAttributionWithRank
                                        {
                                            Title = "Facebook Inc.",
                                            Ranks = new List<int> { 2 },
                                            InputId = "facebook-inc3",
                                        },
                                    }
                                }
                            }
                        }
                    },
                    new TopAttribution
                    {
                        Title = "Top 5 Relative Detractors (3) - updated",
                        SectorAttributionWithRanks = new List<SectorAttributionWithRank>
                        {
                            new SectorAttributionWithRank
                            {
                                Title = "Financials-updated",
                                Ranks = new List<int> { 1 },
                                InputId = "financials - updated4",
                                TopSecurity = new TopSecurity
                                {
                                    Title = "Top 3 Securities (3)",
                                    SecurityAttributionWithRanks = new List<SecurityAttributionWithRank>
                                    {
                                        new SecurityAttributionWithRank
                                        {
                                            Title = "Berkshire Hathaway Inc.",
                                            Ranks = new List<int> { 1 },
                                            InputId = "berkshire-hathaway-inc-updated4"
                                        },
                                        new SecurityAttributionWithRank
                                        {
                                            Title = "JPMorgan Chase &amp; Co.",
                                            Ranks = new List<int> { 2 },
                                            InputId = "jpmorgan-chase-co-updated4"
                                        },
                                    }
                                }
                            },
                            new SectorAttributionWithRank
                            {
                                Title = "Energy-updated",
                                Ranks = new List<int> { 2 },
                                InputId = "energy-updated3",
                                TopSecurity = new TopSecurity
                                {
                                    Title = "Top 3 Securities (3)-updated",
                                    SecurityAttributionWithRanks = new List<SecurityAttributionWithRank>
                                    {
                                        new SecurityAttributionWithRank
                                        {
                                            Title = "Exxon Mobil Corp.-updated4",
                                            Ranks = new List<int> { 1 },
                                            InputId = "exxon-mobil-corp-updated3"
                                        },
                                        new SecurityAttributionWithRank
                                        {
                                            Title = "Chevron Corp.-updated4",
                                            Ranks = new List<int> { 2 },
                                            InputId = "chevron-corp-updated3"
                                        },
                                    }
                                }
                            },
                            new SectorAttributionWithRank
                            {
                                Title = "Communication Services-updated",
                                Ranks = new List<int> { 3 },
                                InputId = "communication-services-updated3",
                               TopSecurity = new TopSecurity
                               {
                                    Title = "Top 3 Securities (3)-updated",
                                    SecurityAttributionWithRanks = new List<SecurityAttributionWithRank>
                                    {
                                        new SecurityAttributionWithRank
                                        {
                                            Title = "Alphabet Inc.-updated",
                                            Ranks = new List<int> { 1 },
                                            InputId = "alphabet-inc-updated3"
                                        },
                                        new SecurityAttributionWithRank
                                        {
                                            Title = "Facebook Inc.-updated",
                                            Ranks = new List<int> { 2 },
                                            InputId = "facebook-inc-updated3",
                                        },
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    };

}
