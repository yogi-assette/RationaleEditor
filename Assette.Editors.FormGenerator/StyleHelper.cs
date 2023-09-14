using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Xml.Linq;
using W15 = DocumentFormat.OpenXml.Office2013.Word;
using static Assette.Editors.FormGenerator.AppEnums;
using Assette.Editors.FormGenerator;

namespace Assette.Editors.FormGenerator;
public static class StyleHelper
{
    private static RunProperties SdtRunProperties
    {
        get
        {
            RunProperties runProperties = new();
            RunFonts runFonts = new() { EastAsiaTheme = ThemeFontValues.MinorEastAsia, ComplexScriptTheme = ThemeFontValues.MinorHighAnsi };
            Color color = new() { Val = "3B3838", ThemeColor = ThemeColorValues.Background2, ThemeShade = "40" };
            Spacing spacing = new() { Val = 15 };

            runProperties.AppendChild(runFonts);
            runProperties.AppendChild(color);
            runProperties.AppendChild(spacing);
            return runProperties;
        }
    }

    private static TableBorders CreateTableBorders()
    {
        TableBorders tableBorders = new();
        TopBorder topBorder = new() { Val = BorderValues.Single, Color = "CBCBCB", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
        LeftBorder leftBorder = new() { Val = BorderValues.Single, Color = "CBCBCB", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
        BottomBorder bottomBorder = new() { Val = BorderValues.Single, Color = "CBCBCB", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
        RightBorder rightBorder = new() { Val = BorderValues.Single, Color = "CBCBCB", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
        InsideHorizontalBorder insideHorizontalBorder = new() { Val = BorderValues.Single, Color = "CBCBCB", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
        InsideVerticalBorder insideVerticalBorder = new() { Val = BorderValues.Single, Color = "CBCBCB", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

        tableBorders.AppendChild(topBorder);
        tableBorders.AppendChild(leftBorder);
        tableBorders.AppendChild(bottomBorder);
        tableBorders.AppendChild(rightBorder);
        tableBorders.AppendChild(insideHorizontalBorder);
        tableBorders.AppendChild(insideVerticalBorder);
        return tableBorders;
    }

    private static TableProperties CreateTableProperties(TableBorders tableBorders, IDictionary<AppEnums.StyleName, IList<KeyValuePair<StyleKey, string>>> styleNameValuePairs)
    {
        TableProperties tableProperties = new();
        ApplyStyles(tableProperties, styleNameValuePairs);
        tableProperties.AppendChild(new TableStyle() { Val = "TableGrid" });
        tableProperties.AppendChild(new TableWidth() { Width = "0", Type = TableWidthUnitValues.Auto });
        tableProperties.AppendChild(tableBorders);
        tableProperties.AppendChild(new TableLook() { Val = "04A0", FirstRow = true, LastRow = false, FirstColumn = true, LastColumn = false, NoHorizontalBand = false, NoVerticalBand = true });
        return tableProperties;
    }

    private static TableRow CreateTableRow(TableCell tableCell)
    {
        TableRow tableRow = new() { RsidTableRowMarkRevision = "00435DB6", RsidTableRowAddition = "00435DB6", RsidTableRowProperties = "00594E86", ParagraphId = "406E2796", TextId = "77777777" };

        TableRowProperties tableRowProperties = new();
        tableRowProperties.AppendChild(new TableRowHeight() { Val = (UInt32Value)296U });

        tableRow.AppendChild(tableCell);
        return tableRow;
    }

    private static TableCell CreateTableCell(IDictionary<AppEnums.StyleName, IList<KeyValuePair<StyleKey, string>>> styleNameValuePairs)
    {
        TableCellProperties tableCellProperties = new();
        ApplyStyles(tableCellProperties, styleNameValuePairs);

        TableCell tableCell = new();
        tableCell.AppendChild(tableCellProperties);

        return tableCell;
    }

    private static Paragraph CreateParagraph(string? styles = null)
    {
        Paragraph paragraph = new()
        {
            RsidParagraphMarkRevision = "001D7A68",
            RsidParagraphAddition = "001D7A68",
            RsidParagraphProperties = "00237F85",
            RsidRunAdditionDefault = "001D7A68",
            ParagraphId = "4E78F5D5",
            TextId = "1894DB47"
        };

        ParagraphProperties paragraphProperties = new();
        ParagraphMarkRunProperties paragraphMarkRunProperties = new();
        var styleNameValues = ExtractStyles(styles, ElementType.Paragraph, PropertiesType.ParagraphMarkRunProperties);
        ApplyStyles(paragraphMarkRunProperties, styleNameValues);
        paragraphProperties.AppendChild(paragraphMarkRunProperties);

        paragraph.AppendChild(paragraphProperties);

        return paragraph;
    }

    public static void AppendBlankLine(this Body body)
    {
        Paragraph paragraph = new() { RsidParagraphMarkRevision = "00435DB6", RsidParagraphAddition = "00D81A26", RsidParagraphProperties = "005D5A45", RsidRunAdditionDefault = "00D81A26", ParagraphId = "5B187171", TextId = "77777777" };

        ParagraphProperties paragraphProperties = new();

        ParagraphMarkRunProperties paragraphMarkRunProperties = new();

        paragraphMarkRunProperties.AppendChild(new Color() { Val = "707070" });

        paragraphProperties.AppendChild(new SpacingBetweenLines() { Before = "240" });
        paragraphProperties.AppendChild(paragraphMarkRunProperties);

        paragraph.AppendChild(paragraphProperties);

        body.AppendChild(paragraph);
    }

    private static Table CreateTable(TableProperties tableProperties, TableRow tableRow)
    {
        Table table = new();

        TableGrid tableGrid = new();
        tableGrid.AppendChild(new GridColumn() { Width = "9124" });

        table.AppendChild(tableProperties);
        table.AppendChild(tableGrid);
        table.AppendChild(tableRow);
        return table;
    }

    private static SdtBlock CreateSdtBlock(string? id)
    {
        RunProperties sdtRunProperties = SdtRunProperties;

        SdtPlaceholder sdtPlaceholder = new();
        _ = sdtPlaceholder.AppendChild(new DocPartReference() { Val = "F8390F70C0CF4898A2F84F0C9C097B51" });

        SdtProperties sdtProperties = new();
        _ = sdtProperties.AppendChild(sdtRunProperties);
        _ = sdtProperties.AppendChild(new SdtId() { Val = 1676146547 });
        _ = sdtProperties.AppendChild(new Tag() { Val = id });
        _ = sdtProperties.AppendChild(new Lock() { Val = LockingValues.SdtLocked });
        _ = sdtProperties.AppendChild(sdtPlaceholder);
        _ = sdtProperties.AppendChild(new ShowingPlaceholder());
        _ = sdtProperties.AppendChild(new W15.Color { Val = "FFCC99" });

        ParagraphMarkRunProperties paragraphMarkRunProperties = new();
        _ = paragraphMarkRunProperties.AppendChild(new RunFonts() { EastAsiaTheme = ThemeFontValues.MinorEastAsia, ComplexScriptTheme = ThemeFontValues.MinorHighAnsi });
        _ = paragraphMarkRunProperties.AppendChild(new Color() { Val = AppConstants.SdtColor, ThemeColor = ThemeColorValues.Background2, ThemeShade = "40" });
        _ = paragraphMarkRunProperties.AppendChild(new Spacing() { Val = 15 });

        ParagraphProperties paragraphProperties = new();
        _ = paragraphProperties.AppendChild(new SpacingBetweenLines() { Line = "312", LineRule = LineSpacingRuleValues.Auto });
        _ = paragraphProperties.AppendChild(paragraphMarkRunProperties);

        RunStyle runStyle = new() { Val = "PlaceholderText" };
        RunProperties runProperties = new();
        _ = runProperties.AppendChild(runStyle);

        Run run = new() { RsidRunProperties = "00D7472F" };
        _ = run.AppendChild(runProperties);
        _ = run.AppendChild(new Text(AppConstants.SdtText));

        Paragraph paragraph = new()
        {
            RsidParagraphMarkRevision = "00D7472F",
            RsidParagraphAddition = "009734FA",
            RsidParagraphProperties = "00237F85",
            RsidRunAdditionDefault = "00D7472F",
            ParagraphId = "2F9F5118",
            TextId = "61DBF2A9"
        };

        _ = paragraph.AppendChild(paragraphProperties);
        _ = paragraph.AppendChild(run);

        SdtContentBlock sdtContentBlock = new();
        _ = sdtContentBlock.AppendChild(paragraph);

        SdtBlock sdtBlock = new();
        _ = sdtBlock.AppendChild(sdtProperties);
        _ = sdtBlock.AppendChild(sdtContentBlock);
        return sdtBlock;
    }

    private static string GetDefaultStyle(ElementType elementType)
    {
        return elementType switch
        {
            ElementType.Heading1 => "font-family:Calibri;font-size:28pt;color:#707070;font-weight:bold;",
            ElementType.Heading2 => "font-size:20pt;color:#A5B82A;letter-spacing:.75pt;font-family:Calibri;font-weight:bold;",
            ElementType.Paragraph => "font-size:20pt;color:#A5B82A;letter-spacing:.75pt;font-family:Calibri;font-weight:bold;",
            //ElementType.SdtRunProperties => "font-size:20pt;color:#A5B82A;letter-spacing:.75pt;font-family:Calibri;font-weight:bold;",
            //ElementType.SpacingBetweenLines => "spacing:line=276,line-rule=auto;",
            ElementType.Span => "font-family:Calibri;font-size:7pt;color:#707070;font-weight:bold;",
            _ => "font-family:Calibri;font-size:7pt;color:#707070;font-weight: bold;",
        };
    }

    private static void ApplyFontFamilyStyle<X>(X properties, IList<KeyValuePair<StyleKey, string>> styleKeyValuePairs)
        where X : TypedOpenXmlCompositeElement
    {
        RunFonts runFonts = new();
        foreach (var (key, value) in styleKeyValuePairs)
        {
            if (key == StyleKey.None)
            {
                runFonts.Ascii = value;
                runFonts.HighAnsi = value;
                runFonts.ComplexScript = value;
            }
            else if (key == StyleKey.EastAsiaTheme && Enum.TryParse(value, true, out ThemeFontValues eastAsiaTheme))
            {
                runFonts.EastAsiaTheme = eastAsiaTheme;
            }
            else if (key == StyleKey.ComplexScriptTheme && Enum.TryParse(value, true, out ThemeFontValues complexScriptTheme))
            {
                runFonts.ComplexScriptTheme = complexScriptTheme;
            }
        }

        properties.AppendChild(runFonts);
    }

    private static void ApplyColorStyle<X>(X properties, IList<KeyValuePair<StyleKey, string>> styleKeyValuePairs)
        where X : TypedOpenXmlCompositeElement
    {
        Color clor = new();
        foreach (var (key, value) in styleKeyValuePairs)
        {
            if (key == StyleKey.None || key == StyleKey.Val)
            {
                clor.Val = value;
            }
            else if (key == StyleKey.ThemeColor && Enum.TryParse(value, true, out ThemeColorValues themeColor))
            {
                clor.ThemeColor = themeColor;
            }
            else if (key == StyleKey.ThemeShade)
            {
                clor.ThemeShade = value;
            }
        }

        properties.AppendChild(clor);
    }

    private static void ApplyShadingStyle<X>(X properties, IList<KeyValuePair<StyleKey, string>> styleKeyValuePairs)
        where X : TypedOpenXmlCompositeElement
    {
        Shading shading = new();
        foreach (var (key, value) in styleKeyValuePairs)
        {
            if ((key == StyleKey.None || key == StyleKey.Val) && Enum.TryParse(value, true, out ShadingPatternValues shadingValue))
            {
                shading.Val = shadingValue;
            }
            else if (key == StyleKey.Color)
            {
                shading.Color = value;
            }
            else if (key == StyleKey.Fill)
            {
                shading.Fill = value;
            }
        }

        properties.AppendChild(shading);
    }

    private static void ApplySpacingStyle<X>(X properties, IList<KeyValuePair<StyleKey, string>> styleKeyValuePairs)
        where X : TypedOpenXmlCompositeElement
    {
        SpacingBetweenLines spacingBetweenLines = new();
        foreach (var (key, value) in styleKeyValuePairs)
        {
            if (key == StyleKey.None || key == StyleKey.Line)
            {
                spacingBetweenLines.Line = value;
            }
            else if (key == StyleKey.LineRule && Enum.TryParse(value, true, out LineSpacingRuleValues lineRule))
            {
                spacingBetweenLines.LineRule = lineRule;
            }
            else if (key == StyleKey.After && int.TryParse(value, out int intAfter))
            {
                spacingBetweenLines.After = value;
            }
        }

        properties.AppendChild(spacingBetweenLines);
    }

    private static void ApplyTableStyleStyle<X>(X properties, IList<KeyValuePair<StyleKey, string>> styleKeyValuePairs)
        where X : TypedOpenXmlCompositeElement
    {
        TableStyle tableStyle = new();
        foreach (var (key, value) in styleKeyValuePairs)
        {
            if (key == StyleKey.None || key == StyleKey.Val)
            {
                tableStyle.Val = value;
            }
        }

        properties.AppendChild(tableStyle);
    }

    private static void ApplyTableWidthStyle<X>(X properties, IList<KeyValuePair<StyleKey, string>> styleKeyValuePairs)
        where X : TypedOpenXmlCompositeElement
    {
        TableWidth tableWidth = new();
        foreach (var (key, value) in styleKeyValuePairs)
        {
            if (key == StyleKey.None || key == StyleKey.Width)
            {
                tableWidth.Width = value;
            }
            else if (key == StyleKey.Type && Enum.TryParse(value, true, out TableWidthUnitValues type))
            {
                tableWidth.Type = type;
            }
        }

        properties.AppendChild(tableWidth);
    }

    private static void ApplyTableIndentationStyle<X>(X properties, IList<KeyValuePair<StyleKey, string>> styleKeyValuePairs)
        where X : TypedOpenXmlCompositeElement
    {
        TableIndentation tableIndentation = new();
        foreach (var (key, value) in styleKeyValuePairs)
        {
            if ((key == StyleKey.None || key == StyleKey.Width) && int.TryParse(value, out int intValue))
            {
                tableIndentation.Width = new Int32Value(intValue);
            }
            else if (key == StyleKey.Type && Enum.TryParse(value, true, out TableWidthUnitValues type))
            {
                tableIndentation.Type = type;
            }
        }

        properties.AppendChild(tableIndentation);
    }

    private static void ApplyTableBorderStyle<X>(X properties, IList<KeyValuePair<StyleKey, string>> styleKeyValuePairs)
        where X : TypedOpenXmlCompositeElement
    {
        TableBorders tableBorders = new();

        var borderTypes = new List<BorderType>
        {
            new TopBorder(),
            new LeftBorder(),
            new RightBorder(),
            new BottomBorder(),
            new InsideHorizontalBorder(),
            new InsideVerticalBorder()
        };

        foreach (var borderType in borderTypes)
        {
            foreach (var (key, value) in styleKeyValuePairs)
            {
                if (key == StyleKey.Val && Enum.TryParse(value, true, out BorderValues borderValue))
                {
                    borderType.Val = borderValue;
                }
                else if (key == StyleKey.Color)
                {
                    borderType.Color = value;
                }
                else if (key == StyleKey.Size && uint.TryParse(value, out uint uintSizeValue))
                {
                    borderType.Size = new UInt32Value(uintSizeValue);
                }
                else if (key == StyleKey.Space && uint.TryParse(value, out uint uintSpaceValue))
                {
                    borderType.Space = new UInt32Value(uintSpaceValue);
                }
            }
            tableBorders.AppendChild(borderType);
        }

        properties.AppendChild(tableBorders);
    }

    private static void ApplyTableLookStyle<X>(X properties, IList<KeyValuePair<StyleKey, string>> styleKeyValuePairs)
        where X : TypedOpenXmlCompositeElement
    {
        TableLook tableLook = new();

        foreach (var (key, value) in styleKeyValuePairs)
        {
            if (key == StyleKey.Val)
            {
                tableLook.Val = value;
            }
            else if (key == StyleKey.FirstRow && bool.TryParse(value, out bool boolFirstRow))
            {
                tableLook.FirstRow = new OnOffValue(boolFirstRow);
            }
            else if (key == StyleKey.LastRow && bool.TryParse(value, out bool boolLastRow))
            {
                tableLook.LastRow = new OnOffValue(boolLastRow);
            }
            else if (key == StyleKey.FirstColumn && bool.TryParse(value, out bool boolFirstColumn))
            {
                tableLook.FirstColumn = new OnOffValue(boolFirstColumn);
            }
            else if (key == StyleKey.LastColumn && bool.TryParse(value, out bool boolLastColumn))
            {
                tableLook.LastColumn = new OnOffValue(boolLastColumn);
            }
            else if (key == StyleKey.NoHorizontalBand && bool.TryParse(value, out bool boolNoHorizontalBand))
            {
                tableLook.NoHorizontalBand = new OnOffValue(boolNoHorizontalBand);
            }
            else if (key == StyleKey.NoVerticalBand && bool.TryParse(value, out bool boolNoVerticalBand))
            {
                tableLook.NoVerticalBand = new OnOffValue(boolNoVerticalBand);
            }
        }

        properties.AppendChild(tableLook);
    }

    private static void ApplyTableRowHeightStyle<X>(X properties, IList<KeyValuePair<StyleKey, string>> styleKeyValuePairs)
       where X : TypedOpenXmlCompositeElement
    {

        if (styleKeyValuePairs != null && styleKeyValuePairs.Count == 1)
        {
            var (key, value) = styleKeyValuePairs[0];
            if ((key == StyleKey.None || key == StyleKey.Val) && uint.TryParse(value, out uint uintValue))
            {
                properties.AppendChild(new TableRowHeight() { Val = new UInt32Value(uintValue) });
            }
        }
    }

    private static void ApplyTableCellWidthStyle<X>(X properties, IList<KeyValuePair<StyleKey, string>> styleKeyValuePairs)
       where X : TypedOpenXmlCompositeElement
    {

        TableCellWidth tableCellWidth = new();
        foreach (var (key, value) in styleKeyValuePairs)
        {
            if (key == StyleKey.None || key == StyleKey.Width)
            {
                tableCellWidth.Width = value;
            }
            else if (key == StyleKey.Type && Enum.TryParse(value, true, out TableWidthUnitValues type))
            {
                tableCellWidth.Type = type;
            }
        }

        properties.AppendChild(tableCellWidth);
    }

    private static void ApplyTableCellVerticalAlignmentStyle<X>(X properties, IList<KeyValuePair<StyleKey, string>> styleKeyValuePairs)
       where X : TypedOpenXmlCompositeElement
    {

        if (styleKeyValuePairs != null && styleKeyValuePairs.Count == 1)
        {
            var (key, value) = styleKeyValuePairs[0];
            if ((key == StyleKey.None || key == StyleKey.Val) && Enum.TryParse(value, true, out TableVerticalAlignmentValues alignment))
            {
                properties.AppendChild(new TableCellVerticalAlignment() { Val = alignment });
            }
        }
    }

    private static void ApplyFontWeightStyle<X>(X properties, IList<KeyValuePair<StyleKey, string>> styleKeyValuePairs)
        where X : TypedOpenXmlCompositeElement
    {
        if (styleKeyValuePairs != null && styleKeyValuePairs.Count == 1 && styleKeyValuePairs[0].Key == StyleKey.None)
        {
            properties.Append(new Bold(), new BoldComplexScript());
        }
    }

    private static void ApplyFontSizeStyle<X>(X properties, IList<KeyValuePair<StyleKey, string>> styleKeyValuePairs)
        where X : TypedOpenXmlCompositeElement
    {
        if (styleKeyValuePairs != null && styleKeyValuePairs.Count == 1 && styleKeyValuePairs[0].Key == StyleKey.None)
        {
            string fontSizeTrimmed = styleKeyValuePairs[0].Value.TrimEnd('p', 't');
            _ = double.TryParse(fontSizeTrimmed, out double fontSize);
            fontSize = 2 * (int)fontSize;
            properties.AppendChild(new FontSize() { Val = fontSize.ToString() });
            properties.AppendChild(new FontSizeComplexScript() { Val = fontSize.ToString() });

            properties.Append(new Bold(), new BoldComplexScript());
        }
    }

    private static void ApplyLetterSpacingStyle<X>(X properties, IList<KeyValuePair<StyleKey, string>> styleKeyValuePairs)
        where X : TypedOpenXmlCompositeElement
    {
        if (styleKeyValuePairs != null && styleKeyValuePairs.Count == 1 && styleKeyValuePairs[0].Key == StyleKey.None)
        {
            string letterSpacingTrimmed = styleKeyValuePairs[0].Value.Trim().TrimEnd('p', 't');
            _ = double.TryParse(letterSpacingTrimmed, out double letterSpacing);
            properties.AppendChild(new Spacing() { Val = (int)(100 * letterSpacing / 5) });
        }
    }

    private static void ApplyTextDecorationStyle<X>(X properties, IList<KeyValuePair<StyleKey, string>> styleKeyValuePairs)
        where X : TypedOpenXmlCompositeElement
    {
        if (styleKeyValuePairs != null && styleKeyValuePairs.Count == 1 && styleKeyValuePairs[0].Key == StyleKey.None)
        {
            properties.AppendChild(new Underline() { Val = UnderlineValues.Single });
        }
    }

    private static void ApplyIndentationStyle<X>(X properties, IList<KeyValuePair<StyleKey, string>> styleKeyValuePairs)
        where X : TypedOpenXmlCompositeElement
    {
        var value = styleKeyValuePairs?.FirstOrDefault().Value;
        if (styleKeyValuePairs != null && styleKeyValuePairs.Count == 1 &&
            (styleKeyValuePairs[0].Key == StyleKey.None || styleKeyValuePairs[0].Key == StyleKey.FirstLine) &&
            int.TryParse(value, out _))
        {
            properties.AppendChild(new Indentation() { FirstLine = value });
        }
    }

    private static void ApplyStyles<T>(T properties, IDictionary<AppEnums.StyleName, IList<KeyValuePair<StyleKey, string>>> styleNameKeyValues)
        where T : TypedOpenXmlCompositeElement
    {
        foreach (var (key, value) in styleNameKeyValues)
        {
            switch (key)
            {
                case AppEnums.StyleName.FontFamily:
                    ApplyFontFamilyStyle(properties, value);
                    break;
                case AppEnums.StyleName.Color:
                    ApplyColorStyle(properties, value);
                    break;
                case AppEnums.StyleName.Shading:
                    ApplyShadingStyle(properties, value);
                    break;
                case AppEnums.StyleName.FontWeight:
                    ApplyFontWeightStyle(properties, value);
                    break;
                case AppEnums.StyleName.FontSize:
                    ApplyFontSizeStyle(properties, value);
                    break;
                case AppEnums.StyleName.LetterSpacing:
                    ApplyLetterSpacingStyle(properties, value);
                    break;
                case AppEnums.StyleName.TextDecoration:
                    ApplyTextDecorationStyle(properties, value);
                    break;
                case AppEnums.StyleName.Spacing:
                    ApplySpacingStyle(properties, value);
                    break;
                case AppEnums.StyleName.TableStyle:
                    ApplyTableStyleStyle(properties, value);
                    break;
                case AppEnums.StyleName.TableWidth:
                    ApplyTableWidthStyle(properties, value);
                    break;
                case AppEnums.StyleName.TableIndentation:
                    ApplyTableIndentationStyle(properties, value);
                    break;
                case AppEnums.StyleName.TableBorder:
                    ApplyTableBorderStyle(properties, value);
                    break;
                case AppEnums.StyleName.TableLook:
                    ApplyTableLookStyle(properties, value);
                    break;
                case AppEnums.StyleName.TableRowHeight:
                    ApplyTableRowHeightStyle(properties, value);
                    break;
                case AppEnums.StyleName.TableCellWidth:
                    ApplyTableCellWidthStyle(properties, value);
                    break;
                case AppEnums.StyleName.TableCellVerticalAlignment:
                    ApplyTableCellVerticalAlignmentStyle(properties, value);
                    break;
                case AppEnums.StyleName.Indentation:
                    ApplyIndentationStyle(properties, value);
                    break;
            }
        }
    }

    public static IDictionary<AppEnums.StyleName, IList<KeyValuePair<StyleKey, string>>> ExtractStyles(string? styles, ElementType elementType, PropertiesType propertiesType)
    {
        styles = string.IsNullOrWhiteSpace(styles) ? GetDefaultStyle(elementType) : styles;

        var styleNameValues = new Dictionary<AppEnums.StyleName, IList<KeyValuePair<StyleKey, string>>>();

        if (!StyleDefinition.EligibleStyles.TryGetValue(propertiesType, out IList<AppEnums.StyleName>? eligibleStyles))
        {
            return styleNameValues;
        }

        string[] styleList = styles.Split(';');
        foreach (var style in styleList)
        {
            var styleTrimmed = style.Trim();
            if (string.IsNullOrEmpty(styleTrimmed) || styleTrimmed == ";")
            {
                continue;
            }

            var styleComponent = styleTrimmed.Split(':');
            if (styleComponent.Length != 2)
            {
                continue;
            }

            var styleName = GetEnumValueFromDescription(styleComponent[0].Trim(), AppEnums.StyleName.None);
            if (!eligibleStyles.Contains(styleName))
            {
                continue;
            }


            string[] styleNameValueArray = styleComponent[1].Trim().Split(',');
            var keyValuePairs = new List<KeyValuePair<StyleKey, string>>();

            if (styleNameValueArray.Length == 1)
            {
                var keyValue = styleComponent[1].Trim().Split('=');
                if (keyValue.Length == 1)
                {
                    StyleKey styleKey = StyleKey.None;
                    var value = styleComponent[1].Trim();
                    keyValuePairs.Add(new KeyValuePair<StyleKey, string>(styleKey, value));
                }
                else
                {
                    StyleKey styleKey = GetEnumValueFromDescription(keyValue[0].Trim(), StyleKey.None);
                    var value = keyValue[1].Trim();
                    keyValuePairs.Add(new KeyValuePair<StyleKey, string>(styleKey, value));
                }
            }
            else
            {
                foreach (string styleNameValue in styleNameValueArray)
                {
                    string[] keyValueArray = styleNameValue.Split('=');
                    if (keyValueArray.Length == 2)
                    {
                        StyleKey styleKey = GetEnumValueFromDescription(keyValueArray[0].Trim(), StyleKey.None);
                        if (styleKey != StyleKey.None)
                        {
                            var value = keyValueArray[1].Trim();
                            keyValuePairs.Add(new KeyValuePair<StyleKey, string>(styleKey, value));
                        }
                    }
                }
            }

            styleNameValues.Add(styleName, keyValuePairs);
        }

        return styleNameValues;
    }

    public static void AddNamespaces(this Document document)
    {
        document.MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "w14 w15 w16se w16cid w16 w16cex w16sdtdh wp14" };
        document.AddNamespaceDeclaration("wpc", "http://schemas.microsoft.com/office/word/2010/wordprocessingCanvas");
        document.AddNamespaceDeclaration("cx", "http://schemas.microsoft.com/office/drawing/2014/chartex");
        document.AddNamespaceDeclaration("cx1", "http://schemas.microsoft.com/office/drawing/2015/9/8/chartex");
        document.AddNamespaceDeclaration("cx2", "http://schemas.microsoft.com/office/drawing/2015/10/21/chartex");
        document.AddNamespaceDeclaration("cx3", "http://schemas.microsoft.com/office/drawing/2016/5/9/chartex");
        document.AddNamespaceDeclaration("cx4", "http://schemas.microsoft.com/office/drawing/2016/5/10/chartex");
        document.AddNamespaceDeclaration("cx5", "http://schemas.microsoft.com/office/drawing/2016/5/11/chartex");
        document.AddNamespaceDeclaration("cx6", "http://schemas.microsoft.com/office/drawing/2016/5/12/chartex");
        document.AddNamespaceDeclaration("cx7", "http://schemas.microsoft.com/office/drawing/2016/5/13/chartex");
        document.AddNamespaceDeclaration("cx8", "http://schemas.microsoft.com/office/drawing/2016/5/14/chartex");
        document.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
        document.AddNamespaceDeclaration("aink", "http://schemas.microsoft.com/office/drawing/2016/ink");
        document.AddNamespaceDeclaration("am3d", "http://schemas.microsoft.com/office/drawing/2017/model3d");
        document.AddNamespaceDeclaration("o", "urn:schemas-microsoft-com:office:office");
        document.AddNamespaceDeclaration("oel", "http://schemas.microsoft.com/office/2019/extlst");
        document.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
        document.AddNamespaceDeclaration("m", "http://schemas.openxmlformats.org/officeDocument/2006/math");
        document.AddNamespaceDeclaration("v", "urn:schemas-microsoft-com:vml");
        document.AddNamespaceDeclaration("wp14", "http://schemas.microsoft.com/office/word/2010/wordprocessingDrawing");
        document.AddNamespaceDeclaration("wp", "http://schemas.openxmlformats.org/drawingml/2006/wordprocessingDrawing");
        document.AddNamespaceDeclaration("w10", "urn:schemas-microsoft-com:office:word");
        document.AddNamespaceDeclaration("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
        document.AddNamespaceDeclaration("w14", "http://schemas.microsoft.com/office/word/2010/wordml");
        document.AddNamespaceDeclaration("w15", "http://schemas.microsoft.com/office/word/2012/wordml");
        document.AddNamespaceDeclaration("w16cex", "http://schemas.microsoft.com/office/word/2018/wordml/cex");
        document.AddNamespaceDeclaration("w16cid", "http://schemas.microsoft.com/office/word/2016/wordml/cid");
        document.AddNamespaceDeclaration("w16", "http://schemas.microsoft.com/office/word/2018/wordml");
        document.AddNamespaceDeclaration("w16sdtdh", "http://schemas.microsoft.com/office/word/2020/wordml/sdtdatahash");
        document.AddNamespaceDeclaration("w16se", "http://schemas.microsoft.com/office/word/2015/wordml/symex");
        document.AddNamespaceDeclaration("wpg", "http://schemas.microsoft.com/office/word/2010/wordprocessingGroup");
        document.AddNamespaceDeclaration("wpi", "http://schemas.microsoft.com/office/word/2010/wordprocessingInk");
        document.AddNamespaceDeclaration("wne", "http://schemas.microsoft.com/office/word/2006/wordml");
        document.AddNamespaceDeclaration("wps", "http://schemas.microsoft.com/office/word/2010/wordprocessingShape");
    }

    public static void AddStylesPartToPackage(this MainDocumentPart mainPart)
    {
        StyleDefinitionsPart? styleDefinitionsPart = mainPart.StyleDefinitionsPart;

        if (styleDefinitionsPart == null)
        {
            styleDefinitionsPart = mainPart.AddNewPart<StyleDefinitionsPart>();
            Styles root = new();
            root.Save(styleDefinitionsPart);
        }
    }

    public static void EnableTrackChanges(this MainDocumentPart mainDocPart)
    {
        DocumentSettingsPart settingsPart = mainDocPart.AddNewPart<DocumentSettingsPart>();
        Settings settings = new();
        TrackRevisions trackRevisions = new() { Val = OnOffValue.FromBoolean(true) };
        settings.AppendChild(trackRevisions);
        settingsPart.Settings = settings;
        settingsPart.Settings.Save();
    }

    public static void AppendSpans<T>(this T compositeElement, XElement paragraphElement, IEnumerable<XElement> spanElements)
        where T : TypedOpenXmlCompositeElement
    {
        string? styles = paragraphElement.Attribute("style")?.Value;

        ParagraphMarkRunProperties paragraphMarkRunProperties = new();
        var styleNameValuePairs = ExtractStyles(styles, ElementType.Paragraph, PropertiesType.ParagraphMarkRunProperties);
        ApplyStyles(paragraphMarkRunProperties, styleNameValuePairs);

        ParagraphProperties paragraphProperties = new();
        styleNameValuePairs = ExtractStyles(styles, ElementType.Paragraph, PropertiesType.ParagraphProperties);
        ApplyStyles(paragraphProperties, styleNameValuePairs);
        paragraphProperties.AppendChild(paragraphMarkRunProperties);

        List<Run> runList = new();
        foreach (XElement spanElement in spanElements)
        {
            if (spanElement.Name.LocalName == "span")
            {
                Run spanRun = new();
                RunProperties spanRunProperties = new();
                styles = spanElement.Attribute("style")?.Value;
                styleNameValuePairs = ExtractStyles(styles, ElementType.Span, PropertiesType.RunProperties);
                ApplyStyles(spanRunProperties, styleNameValuePairs);
                spanRun.AppendChild(spanRunProperties);
                spanRun.AppendChild(new Text() { Text = spanElement.Value.Replace(' ', '\u00A0') });
                runList.Add(spanRun);
            }
        }

        Paragraph paragraph = new()
        {
            RsidParagraphAddition = "00D81A26",
            RsidParagraphProperties = "00496BCB",
            RsidRunAdditionDefault = "00F6492B",
            ParagraphId = "534FE3BF",
            TextId = "77777777"
        };

        paragraph.AppendChild(paragraphProperties);
        runList.ForEach(run =>
        {
            paragraph.AppendChild(run);
        });

        compositeElement.AppendChild(paragraph);
    }

    public static void AppendParagraph<T>(this T compositeElement, XElement element, ElementType styleType = ElementType.Paragraph)
        where T : TypedOpenXmlCompositeElement
    {
        string? styles = element.Attribute("style")?.Value;

        ParagraphMarkRunProperties paragraphMarkRunProperties = new();
        var styleNameValuePairs = ExtractStyles(styles, ElementType.Paragraph, PropertiesType.ParagraphMarkRunProperties);
        ApplyStyles(paragraphMarkRunProperties, styleNameValuePairs);

        ParagraphProperties paragraphProperties = new();
        styleNameValuePairs = ExtractStyles(styles, ElementType.Paragraph, PropertiesType.ParagraphProperties);
        ApplyStyles(paragraphProperties, styleNameValuePairs);
        paragraphProperties.AppendChild(paragraphMarkRunProperties);

        Run run = new();
        RunProperties runProperties = new();
        styleNameValuePairs = ExtractStyles(styles, ElementType.Paragraph, PropertiesType.RunProperties);
        ApplyStyles(runProperties, styleNameValuePairs);
        run.AppendChild(runProperties);
        run.AppendChild(new Text() { Text = element.Value });

        Paragraph paragraph = new()
        {
            RsidParagraphAddition = "00D81A26",
            RsidParagraphProperties = "00496BCB",
            RsidRunAdditionDefault = "00F6492B",
            ParagraphId = "534FE3BF",
            TextId = "77777777"
        };

        paragraph.AppendChild(paragraphProperties);
        paragraph.AppendChild(run);

        compositeElement.AppendChild(paragraph);
    }

    public static void AppendSdtBlock(this Body body, string? id)
    {
        SdtBlock sdtBlock = CreateSdtBlock(id);
        body?.AppendChild(sdtBlock);
    }

    public static void AppendSdtBlockWithTable(this Body body, XElement element)
    {
        string? id = element.Attribute("id")?.Value;

        string? styles = element.Attribute("style")?.Value;
        

        SdtBlock sdtBlock = CreateSdtBlock(id);

        var styleNameValuePairs = ExtractStyles(styles, ElementType.Input, PropertiesType.TableCellProperties);
        TableCell tableCell = CreateTableCell(styleNameValuePairs);
        tableCell.AppendChild(sdtBlock);
        tableCell.AppendChild(CreateParagraph());

        TableRow tableRow = CreateTableRow(tableCell);
        TableBorders tableBorders = CreateTableBorders();


        styleNameValuePairs = ExtractStyles(styles, ElementType.Input, PropertiesType.TableProperties);
        TableProperties tableProperties = CreateTableProperties(tableBorders, styleNameValuePairs);
        Table table = CreateTable(tableProperties, tableRow);

        body?.AppendChild(table);
    }

    public static void AppendTable<T>(this T compositeElement, XElement element)
        where T : TypedOpenXmlCompositeElement
    {
        string? styles = element.Attribute("style")?.Value;

        TableProperties tableProperties = new();
        var styleNameValuePairs = ExtractStyles(styles, ElementType.Table, PropertiesType.TableProperties);
        ApplyStyles(tableProperties, styleNameValuePairs);

        IEnumerable<XElement> trElements = element.Elements("tr");
        List<TableRow> tableRows = new();

        foreach (XElement trElement in trElements)
        {
            TableRowProperties tableRowProperties = new();
            styles = trElement.Attribute("style")?.Value;
            styleNameValuePairs = ExtractStyles(styles, ElementType.Table, PropertiesType.TableRowProperties);
            ApplyStyles(tableRowProperties, styleNameValuePairs);

            IEnumerable<XElement> tdElements = trElement.Elements("td");
            foreach (XElement tdElement in tdElements)
            {
                TableCellProperties tableCellProperties = new();
                styles = tdElement.Attribute("style")?.Value;
                styleNameValuePairs = ExtractStyles(styles, ElementType.Table, PropertiesType.TableCellProperties);
                ApplyStyles(tableCellProperties, styleNameValuePairs);

                TableCell tableCell = new();
                tableCell.AppendChild(tableCellProperties);

                if (tdElement.HasElements)
                {
                    IEnumerable<XElement> paragraphElements = tdElement.Elements("p");
                    foreach (XElement paragraphElement in paragraphElements)
                    {
                        IEnumerable<XElement> spanElements = paragraphElement.Elements("span");
                        if (spanElements.Any())
                        {
                            tableCell.AppendSpans(paragraphElement, spanElements);
                        }
                        else
                        {
                            tableCell.AppendParagraph(paragraphElement, AppEnums.ElementType.Paragraph);
                        }
                    }
                }

                TableRow tableRow = new();
                tableRow.AppendChild(tableRowProperties);
                tableRow.AppendChild(tableCell);
                tableRows.Add(tableRow);
            }
        }

        Table table = new();
        table.AppendChild(tableProperties);
        TableGrid tableGrid = new();
        tableGrid.AppendChild(new GridColumn() { Width = "9090" });
        table.AppendChild(tableGrid);
        tableRows.ForEach(row => table.AppendChild(row));

        compositeElement.AppendChild(table);
    }
}
