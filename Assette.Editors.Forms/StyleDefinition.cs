using DocumentFormat.OpenXml.Wordprocessing;

namespace Assette.Editors.Forms;

public class StyleDefinition
{
    /*
    private static IList<AppEnums.StyleKey> ShadingKeys =>
        new List<AppEnums.StyleKey>
        {
            AppEnums.StyleKey.Val,
            AppEnums.StyleKey.Color,
            AppEnums.StyleKey.Fill
        };

    private static IList<AppEnums.StyleKey> FontFamilyKeys =>
        new List<AppEnums.StyleKey>
        {
            AppEnums.StyleKey.EastAsiaTheme,
            AppEnums.StyleKey.ComplexScriptTheme
        };

    private static IList<AppEnums.StyleKey> ColorKeys =>
        new List<AppEnums.StyleKey>
        {
            AppEnums.StyleKey.Val,
            AppEnums.StyleKey.ThemeColor,
            AppEnums.StyleKey.ThemeShade
        };
    */

    private static IList<AppEnums.StyleName> DefaultPropertiesStyles =>
        new List<AppEnums.StyleName>
        {
            AppEnums.StyleName.Color,
            AppEnums.StyleName.FontFamily,
            AppEnums.StyleName.FontSize,
            AppEnums.StyleName.FontWeight,
            AppEnums.StyleName.LetterSpacing
        };

    private static IList<AppEnums.StyleName> ParagraphPropertiesStyles =>
        new List<AppEnums.StyleName>
        {
            AppEnums.StyleName.Indentation
        };

    private static IList<AppEnums.StyleName> ParagraphMarkRunPropertiesStyles =>
        new List<AppEnums.StyleName>
        {
            AppEnums.StyleName.Color,
            AppEnums.StyleName.FontFamily,
            AppEnums.StyleName.FontSize,
            AppEnums.StyleName.FontWeight,
            AppEnums.StyleName.LetterSpacing,
            AppEnums.StyleName.Spacing
        };

    private static IList<AppEnums.StyleName> TablePropertiesStyles =>
        new List<AppEnums.StyleName>
        {
            AppEnums.StyleName.TableStyle,
            AppEnums.StyleName.TableWidth,
            AppEnums.StyleName.TableIndentation,
            AppEnums.StyleName.TableBorder,
            AppEnums.StyleName.Shading,
            AppEnums.StyleName.TableLook
        };

    private static IList<AppEnums.StyleName> TableRowPropertiesStyles =>
        new List<AppEnums.StyleName>
        {
            AppEnums.StyleName.TableRowHeight
        };

    private static IList<AppEnums.StyleName> TableCellPropertiesStyles =>
        new List<AppEnums.StyleName>
        {
            AppEnums.StyleName.TableCellWidth,
            AppEnums.StyleName.Shading,
            AppEnums.StyleName.Color,
            AppEnums.StyleName.TableCellVerticalAlignment
        };

    private static IList<AppEnums.StyleName> SpacingBetweenLinesPropertiesStyles =>
        new List<AppEnums.StyleName>
        {
            AppEnums.StyleName.Spacing
        };

    protected StyleDefinition()
    {
    }

    public static IDictionary<AppEnums.PropertiesType, IList<AppEnums.StyleName>> EligibleStyles =>
        new Dictionary<AppEnums.PropertiesType, IList<AppEnums.StyleName>>()
        {
            {AppEnums.PropertiesType.DefaultProperties, DefaultPropertiesStyles },
            {AppEnums.PropertiesType.ParagraphProperties, ParagraphPropertiesStyles },
            {AppEnums.PropertiesType.ParagraphMarkRunProperties, ParagraphMarkRunPropertiesStyles },
            {AppEnums.PropertiesType.RunProperties , DefaultPropertiesStyles },
            {AppEnums.PropertiesType.SdtRunProperties, DefaultPropertiesStyles },
            {AppEnums.PropertiesType.TableProperties, TablePropertiesStyles },
            {AppEnums.PropertiesType.TableRowProperties, TableRowPropertiesStyles },
            {AppEnums.PropertiesType.TableCellProperties, TableCellPropertiesStyles },
            // TODO: Revisit the below ones
            {AppEnums.PropertiesType.SpacingBetweenLines, SpacingBetweenLinesPropertiesStyles }
        };

    // TODO: Should we not use the below???
    /*
    public static IDictionary<AppEnums.StyleName, IList<AppEnums.StyleKey>> StyleDefinitions =>
        new Dictionary<AppEnums.StyleName, IList<AppEnums.StyleKey>>
        {
            { AppEnums.StyleName.FontFamily, FontFamilyKeys },
            { AppEnums.StyleName.Shading, ShadingKeys },
            { AppEnums.StyleName.Color, ColorKeys }
        };
    */
}
