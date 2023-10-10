
using Assette.Editors.Forms.Mapper.Entities.Rationale;
using System.Xml.Linq;
using System.Xml;

namespace Assette.Editors.Forms.Mapper.Converters;

public class RationaleConverter
{
    public Dictionary<string, object> RationaleToDictionary(Rationale rationale)
    {
        Dictionary<string, object> result = new()
        {
            { "UniqueId", rationale.UniqueId },
            { "Version", rationale.Version },
            { "TitleId", rationale.TitleId },
            { "Title", ReplaceEscapeCharacters( rationale.Title) },
            { "CategoryTitle", ReplaceEscapeCharacters(rationale.CategoryTitle) },
            { "CategoryTitleId", rationale.CategoryTitleId },
            { "Overview", SectorAttributionToDictionary( rationale.Overview )},
            { "SubCategories", SubCategoriesToDictionary( rationale.SubCategories )}
        };

        return result;
    }

    private List<Dictionary<string, object>> SubCategoriesToDictionary(IList<AttributionType> subCategories)
    {
        List<Dictionary<string, object>> result = new();

        foreach (AttributionType subCategory in subCategories)
        {
            Dictionary<string, object> subCategoryDictionary = new()
            {
                { "TitleId", subCategory.TitleId },
                { "Title", ReplaceEscapeCharacters(subCategory.Title) },
                { "Section", SectorAttributionToDictionary( subCategory.Section )},
                { "TopAttributions", TopAttributionToDictionary( subCategory.TopAttributions )}
            };

            result.Add(subCategoryDictionary);
        }

        return result;
    }

    private Dictionary<string, object> SectorAttributionToDictionary(SectorAttribution sectorAttribution)
    {
        Dictionary<string, object> result = new()
        {
            { "Title", ReplaceEscapeCharacters( sectorAttribution.Title) },
            { "TitleId", sectorAttribution.TitleId },
            { "InputId", sectorAttribution.InputId }
        };

        return result;
    }

    private List<Dictionary<string, object>> TopAttributionToDictionary(IList<TopAttribution> topAttributions)
    {
        List<Dictionary<string, object>> result = new();

        foreach (var topAttribution in topAttributions)
        {
            result.Add(new Dictionary<string, object>
            {
                { "TitleId", topAttribution.TitleId },
                { "Title", ReplaceEscapeCharacters( topAttribution.Title) },
                { "SectorAttributionWithRanks", SectorAttributionWithRankToDictionary(topAttribution.SectorAttributionWithRanks )}
            });
        }

        return result;
    }

    private List<Dictionary<string, object>> SectorAttributionWithRankToDictionary(IList<SectorAttributionWithRank> sectorAttributionWithRanks)
    {
        List<Dictionary<string, object>> result = new();

        foreach (var sectorAttributionWithRank in sectorAttributionWithRanks)
        {
            result.Add(new Dictionary<string, object>
            {
                { "TitleId", sectorAttributionWithRank.TitleId },
                { "Title", ReplaceEscapeCharacters(sectorAttributionWithRank.Title) },
                { "InputId", sectorAttributionWithRank.InputId },
                { "RankId", sectorAttributionWithRank.RankId },
                { "Ranks", sectorAttributionWithRank.Ranks },
                { "TopSecurity", TopSecurityToDictionary( sectorAttributionWithRank.TopSecurity ) }
            });
        }

        return result;
    }

    private Dictionary<string, object> TopSecurityToDictionary(TopSecurity topSecurity)
    {
        Dictionary<string, object> result = new()
        {
            { "TitleId", topSecurity.TitleId },
            { "Title", ReplaceEscapeCharacters(topSecurity.Title) },
            { "SecurityAttributionWithRanks", SecurityAttributionWithRankToDictionary(topSecurity.SecurityAttributionWithRanks )}
        };

        return result;
    }

    private List<Dictionary<string, object>> SecurityAttributionWithRankToDictionary(IList<SecurityAttributionWithRank> securityAttributionWithRanks)
    {
        List<Dictionary<string, object>> result = new();

        foreach (var securityAttributionWithRank in securityAttributionWithRanks)
        {
            result.Add(new Dictionary<string, object>
            {
                { "TitleId", securityAttributionWithRank.TitleId },
                { "Title", ReplaceEscapeCharacters(securityAttributionWithRank.Title) },
                { "InputId", securityAttributionWithRank.InputId },
                { "RankId", securityAttributionWithRank.RankId },
                { "Ranks", securityAttributionWithRank.Ranks }
            });
        }

        return result;
    }

    private static string ReplaceEscapeCharacters(string value)
    {
        value = value.Replace("&", "&amp;")
            .Replace("<", "&lt;")
            .Replace(">", "&gt;")
            .Replace("\"", "&quot;")
            .Replace("'", "&apos;");

        return value;
    }


}
