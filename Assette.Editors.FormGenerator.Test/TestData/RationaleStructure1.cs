using Assette.Editors.ModelMapper.Entities.Rationale;

namespace Assette.Editors.FormGenerator.Test.TestData;

public class RationaleStructure1
{
    public Rationale Get
    {
        get
        {
            return rationale;
        }
    }

    /*
    private readonly Rationale rationale = new()
    {
        UniqueId = new Rationale().GenerateGuid(),
        Version = "1.0.0",
        Title = "Rationale for Large Cap Value | Equities",
        CategoryTitle = "Sector Attribution",
        Overview = new SectorAttribution
        {
            Title = "Sector Attribution Overview"
        },
        SubCategories = new List<AttributionType>
        {
            new AttributionType
            {
                Title = "Absolute",
                Section = new SectorAttribution
                {
                    Title = "Absolute Summary"
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
                                SecurityAttributionWithRank = new SecurityAttributionWithRank
                                {
                                    Test = "test1",
                                    Title = "title 1"
                                }
                            },
                            new SectorAttributionWithRank
                            {
                                Title = "Industrials",
                                Ranks = new List<int> { 2 },
                                SecurityAttributionWithRank = new SecurityAttributionWithRank
                                {
                                    Test = "test2",
                                    Title = "title 2"
                                }
                            },
                            new SectorAttributionWithRank
                            {
                                Title = "Health Care",
                                Ranks = new List<int> { 3 },
                                SecurityAttributionWithRank = new SecurityAttributionWithRank
                                {
                                    Test = "test3",
                                   Title = "title 3"
                                }
                            },
                            new SectorAttributionWithRank
                            {
                                Title = "Consumer Discretionary",
                                Ranks = new List<int> { 4 },
                                SecurityAttributionWithRank = new SecurityAttributionWithRank
                                {
                                    Test = "test4",
                                    Title = "title 4"
                                }
                            },
                            new SectorAttributionWithRank
                            {
                                Title = "Financials",
                                Ranks = new List<int> { 5 },
                                SecurityAttributionWithRank = new SecurityAttributionWithRank
                                {
                                    Test = "test5",
                                    Title = "title 5"
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
                                Title = "Financials",
                                Ranks = new List<int> { 1 },
                                SecurityAttributionWithRank = new SecurityAttributionWithRank
                                {
                                    Test = "test6",
                                    Title = "title 6"
                                }
                            },
                            new SectorAttributionWithRank
                            {
                                Title = "Energy",
                                Ranks = new List<int> { 2 },
                                SecurityAttributionWithRank = new SecurityAttributionWithRank
                                {
                                    Test = "test7",
                                    Title = "title 7"
                                }
                            },
                            new SectorAttributionWithRank
                            {
                                Title = "Communication Services",
                                Ranks = new List<int> { 3 },
                                SecurityAttributionWithRank = new SecurityAttributionWithRank
                                {
                                    Test = "test8",
                                    Title = "title 8"
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
                    Title = "Relative Summary"
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
                                SecurityAttributionWithRank = new SecurityAttributionWithRank
                                {
                                    Test = "test9",
                                    Title = "title 9"
                                }
                            },
                            new SectorAttributionWithRank
                            {
                                Title = "Industrials",
                                Ranks = new List<int> { 2 },
                                SecurityAttributionWithRank = new SecurityAttributionWithRank
                                {
                                    Test = "test10",
                                    Title = "title 10"
                                }
                            },
                            new SectorAttributionWithRank
                            {
                                Title = "Health Care",
                                Ranks = new List<int> { 3 },
                                SecurityAttributionWithRank = new SecurityAttributionWithRank
                                {
                                    Test = "test11",
                                    Title = "title 11"
                                }
                            },
                            new SectorAttributionWithRank
                            {
                                Title = "Consumer Discretionary",
                                Ranks = new List<int> { 4 },
                                SecurityAttributionWithRank = new SecurityAttributionWithRank
                                {
                                    Test = "test12",
                                    Title = "title 12"
                                }
                            },
                            new SectorAttributionWithRank
                            {
                                Title = "Financials",
                                Ranks = new List<int> { 5 },
                                SecurityAttributionWithRank = new SecurityAttributionWithRank { 
                                    Test = "test12",
                                    Title = "title 12"
                                }
                            }
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
                                SecurityAttributionWithRank = new SecurityAttributionWithRank
                                {
                                    Test = "test13",
                                    Title = "title 13"
                                }
                            },
                            new SectorAttributionWithRank
                            {
                                Title = "Energy",
                                Ranks = new List<int> { 2 },
                                SecurityAttributionWithRank = new SecurityAttributionWithRank
                                {
                                    Test = "test14",
                                    Title = "title 14"
                                }
                            },
                            new SectorAttributionWithRank
                            {
                                Title = "Communication Services",
                                Ranks = new List<int> { 3 },
                                SecurityAttributionWithRank = new SecurityAttributionWithRank
                                {
                                    Test = "test15",
                                    Title = "title 15"
                                }
                            }
                        }
                    }
                }
            }
        }
    };
    */

    private readonly Rationale rationale = new()
    {
        UniqueId = new Rationale().GenerateGuid(),
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
                                            Title = "IBM",
                                            Ranks = new List<int> { 3 },
                                            InputId = "ibm",
                                        }
                                    }
                                }
                            },
                            new SectorAttributionWithRank
                            {
                                Title = "Industrials",
                                Ranks = new List<int> { 2 },
                                InputId = "industrials",
                                TopSecurity = new TopSecurity
                                {
                                    Title = "Top 3 Securities (3)",
                                    SecurityAttributionWithRanks = new List<SecurityAttributionWithRank>
                                    {
                                        new SecurityAttributionWithRank
                                        {
                                            Title = "3M Co.",
                                            Ranks = new List<int> { 1 },
                                            InputId = "3m-co",
                                        },
                                        new SecurityAttributionWithRank
                                        {
                                            Title = "Honeywell International Inc.",
                                            Ranks = new List<int> { 2 },
                                            InputId = "honeywell-international-inc",
                                        },
                                        new SecurityAttributionWithRank
                                        {
                                            Title = "General Electric Co.",
                                            Ranks = new List<int> { 3 },
                                            InputId = "general-electric-co",
                                        }
                                    }
                                }
                            },
                            new SectorAttributionWithRank
                            {
                                Title = "Health Care",
                                Ranks = new List<int> { 3 },
                                InputId = "health-care1",
                                TopSecurity = new TopSecurity
                                {
                                    Title = "Top 3 Securities (3)",
                                    SecurityAttributionWithRanks = new List<SecurityAttributionWithRank>
                                    {
                                        new SecurityAttributionWithRank
                                        {
                                            Title = "Johnson &amp; Johnson",
                                            Ranks = new List<int> { 1, 2 },
                                            InputId = "johnson-johnson1",
                                        },
                                        new SecurityAttributionWithRank
                                        {
                                            Title = "UnitedHealth Group Inc.",
                                            Ranks = new List<int> { 2 },
                                            InputId = "unitedhealth-group-inc",
                                        },
                                        new SecurityAttributionWithRank
                                        {
                                            Title = "Pfizer Inc.",
                                            Ranks = new List<int> { 3 },
                                            InputId = "pfizer-inc",
                                        }
                                    }
                                }
                            },
                            new SectorAttributionWithRank
                            {
                                Title = "Consumer Discretionary",
                                Ranks = new List<int> { 4 },
                                InputId = "consumer-discretionary1",
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
                                            Title = "Home Depot Inc.",
                                            Ranks = new List<int> { 2 },
                                            InputId = "home-depot-inc1",
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
                                Title = "Financials",
                                Ranks = new List<int> { 1 },
                                InputId = "financials2",
                                TopSecurity = new TopSecurity
                                {
                                    Title = "Top 3 Securities (3)",
                                    SecurityAttributionWithRanks = new List<SecurityAttributionWithRank>
                                    {
                                        new SecurityAttributionWithRank
                                        {
                                            Title = "Berkshire Hathaway Inc.",
                                            Ranks = new List<int> { 1 },
                                            InputId = "berkshire-hathaway-inc2"
                                        },
                                        new SecurityAttributionWithRank
                                        {
                                            Title = "JPMorgan Chase &amp; Co.",
                                            Ranks = new List<int> { 2 },
                                            InputId = "jpmorgan-chase-co2"
                                        },
                                        new SecurityAttributionWithRank
                                        {
                                            Title = "Bank of America Corp.",
                                            Ranks = new List<int> { 3 },
                                            InputId = "bank-of-america-corp2"
                                        }
                                    }
                                }
                            },
                            new SectorAttributionWithRank
                            {
                                Title = "Energy",
                                Ranks = new List<int> { 2 },
                                InputId = "energy2",
                                TopSecurity = new TopSecurity
                                {
                                    Title = "Top 3 Securities (3)",
                                    SecurityAttributionWithRanks = new List<SecurityAttributionWithRank>
                                    {
                                        new SecurityAttributionWithRank
                                        {
                                            Title = "Exxon Mobil Corp.",
                                            Ranks = new List<int> { 1 },
                                            InputId = "exxon-mobil-corp2"
                                        },
                                        new SecurityAttributionWithRank
                                        {
                                            Title = "Chevron Corp.",
                                            Ranks = new List<int> { 2 },
                                            InputId = "chevron-corp2"
                                        },
                                        new SecurityAttributionWithRank
                                        {
                                            Title = "Schlumberger Ltd.",
                                            Ranks = new List<int> { 3 },
                                            InputId = "schlumberger-ltd2"
                                        }
                                    }
                                }
                            },
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
                                Title = "Industrials",
                                Ranks = new List<int> { 2 },
                                InputId = "industrials2",
                                TopSecurity = new TopSecurity
                                {
                                    Title = "Top 3 Securities (3)",
                                    SecurityAttributionWithRanks = new List<SecurityAttributionWithRank>
                                    {
                                        new SecurityAttributionWithRank
                                        {
                                            Title = "Boeing Co.",
                                            Ranks = new List<int> { 1 },
                                            InputId = "boeing-co2"
                                        },
                                        new SecurityAttributionWithRank
                                        {
                                            Title = "United Technologies Corp.",
                                            Ranks = new List<int> { 2 },
                                            InputId = "united-technologies-corp2"
                                        },
                                        new SecurityAttributionWithRank
                                        {
                                            Title = "Union Pacific Corp.",
                                            Ranks = new List<int> { 3 },
                                            InputId = "union-pacific-corp2"
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
                            new SectorAttributionWithRank
                            {
                                Title = "Financials",
                                Ranks = new List<int> { 5 },
                                InputId = "financials3",
                                TopSecurity = new TopSecurity
                                {
                                    Title = "Top 3 Securities (3)",
                                    SecurityAttributionWithRanks = new List<SecurityAttributionWithRank>
                                    {
                                        new SecurityAttributionWithRank
                                        {
                                            Title = "Berkshire Hathaway Inc.",
                                            Ranks = new List<int> { 1 },
                                            InputId = "berkshire-hathaway-inc3"
                                        },
                                        new SecurityAttributionWithRank
                                        {
                                            Title = "JPMorgan Chase &amp; Co.",
                                            Ranks = new List<int> { 2 },
                                            InputId = "jpmorgan-chase-co3"
                                        },
                                        new SecurityAttributionWithRank
                                        {
                                            Title = "Bank of America Corp.",
                                            Ranks = new List<int> { 3 },
                                            InputId = "bank-of-america-corp3"
                                        }
                                    }
                                }
                            }
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
                                        new SecurityAttributionWithRank
                                        {
                                            Title = "Bank of America Corp.",
                                            Ranks = new List<int> { 3 },
                                            InputId = "bank-of-america-corp4"
                                        }
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
                                        new SecurityAttributionWithRank
                                        {
                                            Title = "Schlumberger Ltd.",
                                            Ranks = new List<int> { 3 },
                                            InputId = "schlumberger-ltd3"
                                        }
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
                                        new SecurityAttributionWithRank
                                        {
                                            Title = "Netflix Inc.",
                                            Ranks = new List<int> { 3 },
                                            InputId = "netflix-inc3"
                                        }
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
