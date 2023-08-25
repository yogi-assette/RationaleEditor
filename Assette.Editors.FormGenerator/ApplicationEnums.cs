using System.ComponentModel;
using System.Reflection;

namespace Assette.Editors.FormGenerator;

public static class AppEnums
{
    public enum ElementType
    {
        Heading1,
        Heading2,
        Paragraph,
        Span,
        Table,
        Input
    }

    public enum PropertiesType
    {
        DefaultProperties,
        ParagraphProperties,
        ParagraphMarkRunProperties,
        RunProperties,
        SdtRunProperties,
        SpacingBetweenLines,
        TableProperties,
        TableRowProperties,
        TableCellProperties,
    }

    public enum StyleName
    {
        [Description("none")]
        None,
        [Description("color")]
        Color,
        [Description("shading")]
        Shading,
        [Description("font-family")]
        FontFamily,
        [Description("font-weight")]
        FontWeight,
        [Description("font-size")]
        FontSize,
        [Description("letter-spacing")]
        LetterSpacing,
        [Description("width")]
        Width,
        [Description("text-decoration")]
        TextDecoration,
        [Description("spacing")]
        Spacing,
        [Description("table-style")]
        TableStyle,
        [Description("table-grid")]
        TableGrid,
        [Description("table-width")]
        TableWidth,
        [Description("table-indentation")]
        TableIndentation,
        [Description("table-border")]
        TableBorder,
        [Description("table-look")]
        TableLook,
        [Description("table-row-height")]
        TableRowHeight,
        [Description("table-cell-width")]
        TableCellWidth,
        [Description("table-cell-vertical-alignment")]
        TableCellVerticalAlignment,
        [Description("ind")]
        Indentation
    }

    public enum StyleKey
    {
        [Description ("none")]
        None,
        [Description("val")]
        Val,
        [Description("east-asia-theme")]
        EastAsiaTheme,
        [Description("complex-script-theme")]
        ComplexScriptTheme,
        [Description("color")]
        Color,
        [Description("theme-color")]
        ThemeColor,
        [Description("theme-shade")]
        ThemeShade,
        [Description("fill")]
        Fill,
        [Description("size")]
        Size,
        [Description("width")]
        Width,
        [Description("height")]
        Height,
        [Description("type")]
        Type,
        [Description("space")]
        Space,
        [Description("first-row")]
        FirstRow,
        [Description("last-row")]
        LastRow,
        [Description("first-column")]
        FirstColumn,
        [Description("last-column")]
        LastColumn,
        [Description("no-horizontal-band")]
        NoHorizontalBand,
        [Description("no-vertical-band")]
        NoVerticalBand,
        [Description("after")]
        After,
        [Description("line")]
        Line,
        [Description("line-rule")]
        LineRule,
        [Description("first-line")]
        FirstLine
    }

    public static T GetEnumValueFromDescription<T>(string description, T defaultValue) where T : Enum
    {
        foreach (var field in typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static))
        {
            DescriptionAttribute? attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
            if (attribute != null && attribute.Description.Equals(description, StringComparison.OrdinalIgnoreCase))
            {
                return (T)Enum.Parse(typeof(T), field.Name);
            }
        }

        return defaultValue;
    }
}
