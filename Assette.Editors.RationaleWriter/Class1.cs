using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml;

namespace Assette.Editors.InvestmentWriter;
public class Class1
{
    private void WordText()
    {
        Paragraph paragraph18 = new Paragraph() { RsidParagraphAddition = "001A10EE", RsidParagraphProperties = "008E2128", RsidRunAdditionDefault = "005D5A45", ParagraphId = "2E75228F", TextId = "0D8FF4A1" };

        ParagraphProperties paragraphProperties17 = new ParagraphProperties();
        SpacingBetweenLines spacingBetweenLines14 = new SpacingBetweenLines() { Line = "336", LineRule = LineSpacingRuleValues.Auto };

        ParagraphMarkRunProperties paragraphMarkRunProperties17 = new ParagraphMarkRunProperties();
        RunFonts runFonts23 = new RunFonts() { EastAsiaTheme = ThemeFontValues.MinorEastAsia, ComplexScriptTheme = ThemeFontValues.MinorBidi };
        Bold bold17 = new Bold();
        BoldComplexScript boldComplexScript17 = new BoldComplexScript();
        Color color25 = new Color() { Val = "B1C42B" };
        Spacing spacing18 = new Spacing() { Val = 15 };
        FontSize fontSize20 = new FontSize() { Val = "32" };
        FontSizeComplexScript fontSizeComplexScript20 = new FontSizeComplexScript() { Val = "32" };

        paragraphMarkRunProperties17.Append(runFonts23);
        paragraphMarkRunProperties17.Append(bold17);
        paragraphMarkRunProperties17.Append(boldComplexScript17);
        paragraphMarkRunProperties17.Append(color25);
        paragraphMarkRunProperties17.Append(spacing18);
        paragraphMarkRunProperties17.Append(fontSize20);
        paragraphMarkRunProperties17.Append(fontSizeComplexScript20);

        paragraphProperties17.Append(spacingBetweenLines14);
        paragraphProperties17.Append(paragraphMarkRunProperties17);

        Run run10 = new Run();

        RunProperties runProperties10 = new RunProperties();
        RunFonts runFonts24 = new RunFonts() { EastAsiaTheme = ThemeFontValues.MinorEastAsia, ComplexScriptTheme = ThemeFontValues.MinorBidi };
        Bold bold18 = new Bold();
        BoldComplexScript boldComplexScript18 = new BoldComplexScript();
        Color color26 = new Color() { Val = "B1C42B" };
        Spacing spacing19 = new Spacing() { Val = 15 };
        FontSize fontSize21 = new FontSize() { Val = "32" };
        FontSizeComplexScript fontSizeComplexScript21 = new FontSizeComplexScript() { Val = "32" };

        runProperties10.Append(runFonts24);
        runProperties10.Append(bold18);
        runProperties10.Append(boldComplexScript18);
        runProperties10.Append(color26);
        runProperties10.Append(spacing19);
        runProperties10.Append(fontSize21);
        runProperties10.Append(fontSizeComplexScript21);
        Text text10 = new Text() { Space = SpaceProcessingModeValues.Preserve };
        text10.Text = " ";

        run10.Append(runProperties10);
        run10.Append(text10);

        Run run11 = new Run() { RsidRunProperties = "00435DB6", RsidRunAddition = "001A10EE" };

        RunProperties runProperties11 = new RunProperties();
        RunFonts runFonts25 = new RunFonts() { EastAsiaTheme = ThemeFontValues.MinorEastAsia, ComplexScriptTheme = ThemeFontValues.MinorBidi };
        Bold bold19 = new Bold();
        BoldComplexScript boldComplexScript19 = new BoldComplexScript();
        Color color27 = new Color() { Val = "B1C42B" };
        Spacing spacing20 = new Spacing() { Val = 15 };
        FontSize fontSize22 = new FontSize() { Val = "32" };
        FontSizeComplexScript fontSizeComplexScript22 = new FontSizeComplexScript() { Val = "32" };

        runProperties11.Append(runFonts25);
        runProperties11.Append(bold19);
        runProperties11.Append(boldComplexScript19);
        runProperties11.Append(color27);
        runProperties11.Append(spacing20);
        runProperties11.Append(fontSize22);
        runProperties11.Append(fontSizeComplexScript22);
        Text text11 = new Text();
        text11.Text = "Top 5 Absolute Contributors";

        run11.Append(runProperties11);
        run11.Append(text11);

        Run run12 = new Run() { RsidRunAddition = "001D7A68" };

        RunProperties runProperties12 = new RunProperties();
        RunFonts runFonts26 = new RunFonts() { EastAsiaTheme = ThemeFontValues.MinorEastAsia, ComplexScriptTheme = ThemeFontValues.MinorBidi };
        Bold bold20 = new Bold();
        BoldComplexScript boldComplexScript20 = new BoldComplexScript();
        Color color28 = new Color() { Val = "B1C42B" };
        Spacing spacing21 = new Spacing() { Val = 15 };
        FontSize fontSize23 = new FontSize() { Val = "32" };
        FontSizeComplexScript fontSizeComplexScript23 = new FontSizeComplexScript() { Val = "32" };

        runProperties12.Append(runFonts26);
        runProperties12.Append(bold20);
        runProperties12.Append(boldComplexScript20);
        runProperties12.Append(color28);
        runProperties12.Append(spacing21);
        runProperties12.Append(fontSize23);
        runProperties12.Append(fontSizeComplexScript23);
        Text text12 = new Text() { Space = SpaceProcessingModeValues.Preserve };
        text12.Text = " (";

        run12.Append(runProperties12);
        run12.Append(text12);

        Run run13 = new Run() { RsidRunAddition = "008252C2" };

        RunProperties runProperties13 = new RunProperties();
        RunFonts runFonts27 = new RunFonts() { EastAsiaTheme = ThemeFontValues.MinorEastAsia, ComplexScriptTheme = ThemeFontValues.MinorBidi };
        Bold bold21 = new Bold();
        BoldComplexScript boldComplexScript21 = new BoldComplexScript();
        Color color29 = new Color() { Val = "B1C42B" };
        Spacing spacing22 = new Spacing() { Val = 15 };
        FontSize fontSize24 = new FontSize() { Val = "32" };
        FontSizeComplexScript fontSizeComplexScript24 = new FontSizeComplexScript() { Val = "32" };

        runProperties13.Append(runFonts27);
        runProperties13.Append(bold21);
        runProperties13.Append(boldComplexScript21);
        runProperties13.Append(color29);
        runProperties13.Append(spacing22);
        runProperties13.Append(fontSize24);
        runProperties13.Append(fontSizeComplexScript24);
        Text text13 = new Text();
        text13.Text = "5)";

        run13.Append(runProperties13);
        run13.Append(text13);

        paragraph18.Append(paragraphProperties17);
        paragraph18.Append(run10);
        paragraph18.Append(run11);
        paragraph18.Append(run12);
        paragraph18.Append(run13);
    }

    private void WordTextH1()
    {
        Paragraph paragraph = new() { RsidParagraphAddition = "001A10EE", RsidParagraphProperties = "008E2128", RsidRunAdditionDefault = "005D5A45", ParagraphId = "2E75228F", TextId = "0D8FF4A1" };

        ParagraphProperties paragraphProperties = new();
        SpacingBetweenLines spacingBetweenLines = new() { Line = "336", LineRule = LineSpacingRuleValues.Auto };

        ParagraphMarkRunProperties paragraphMarkRunProperties = new();
        RunFonts runFonts = new() { EastAsiaTheme = ThemeFontValues.MinorEastAsia, ComplexScriptTheme = ThemeFontValues.MinorBidi };
        Bold bold17 = new();
        BoldComplexScript boldComplexScript = new();
        Color color25 = new() { Val = "B1C42B" };
        Spacing spacing18 = new() { Val = 15 };
        FontSize fontSize20 = new() { Val = "32" };
        FontSizeComplexScript fontSizeComplexScript20 = new() { Val = "32" };

        paragraphMarkRunProperties.Append(runFonts);
        paragraphMarkRunProperties.Append(bold17);
        paragraphMarkRunProperties.Append(boldComplexScript);
        paragraphMarkRunProperties.Append(color25);
        paragraphMarkRunProperties.Append(spacing18);
        paragraphMarkRunProperties.Append(fontSize20);
        paragraphMarkRunProperties.Append(fontSizeComplexScript20);

        paragraphProperties.Append(spacingBetweenLines);
        paragraphProperties.Append(paragraphMarkRunProperties);

        Run run = new();

        RunProperties runProperties = new();
        //RunFonts runFonts1 = new RunFonts() { Ascii = "Calibri", HighAnsi = "Calibri", ComplexScript = "Calibri" };
        RunFonts runFonts24 = new() { EastAsiaTheme = ThemeFontValues.MinorEastAsia, ComplexScriptTheme = ThemeFontValues.MinorBidi };
        Bold bold18 = new();
        BoldComplexScript boldComplexScript18 = new();
        Color color26 = new() { Val = "B1C42B" };
        Spacing spacing19 = new() { Val = 15 };
        FontSize fontSize21 = new() { Val = "32" };
        FontSizeComplexScript fontSizeComplexScript21 = new() { Val = "32" };

        runProperties.Append(runFonts24);
        runProperties.Append(bold18);
        runProperties.Append(boldComplexScript18);
        runProperties.Append(color26);
        runProperties.Append(spacing19);
        runProperties.Append(fontSize21);
        runProperties.Append(fontSizeComplexScript21);
        Text text = new()
        {
            Text = "Top 5 Absolute Contributors (5)"
        };

        run.Append(runProperties);
        run.Append(text);

        paragraph.Append(paragraphProperties);
        paragraph.Append(run);
    }

    private void WordAbsolute()
    {
        /*
            < table class=MsoTableGrid border = 0 cellspacing=0 cellpadding=0 style='margin-left:4.5pt;background:#C2D72B;border-collapse:collapse;
            border:none;mso-yfti-tbllook:1184;mso-padding-alt:0in 5.4pt 0in 5.4pt;
            mso-border-insideh:none;mso-border-insidev:none'>
            <tr style = 'mso-yfti-irow:0;mso-yfti-firstrow:yes;mso-yfti-lastrow:yes;
            height:.45in'>
                <td width = 606 style='width:454.5pt;padding:0in 5.4pt 0in 5.4pt;height:.45in'>
                    <p class=MsoNormal style = 'line-height:115%' >
                        < b >< span style='font-size:24.0pt;
            line-height:115%;mso-ascii-font-family:Calibri;mso-hansi-font-family:Calibri;
            mso-bidi-font-family:Calibri;color:#707070'>
                            <span style = 'mso-spacerun:yes' ></ span >
                        </ span >
                    </ b >
                    < b >
                        < span style = 'font-size:20.0pt;
            line-height:115%;mso-fareast-font-family:"Times New Roman";mso-fareast-theme-font:
            minor-fareast;mso-bidi-font-family:"Iskoola Pota";mso-bidi-theme-font:minor-bidi;
            color:white;mso-themecolor:background1;letter-spacing:.75pt'>Absolute</span>
                    </b>
                    <b>
                        <span style = 'font-size:20.0pt;line-height:115%;mso-ascii-font-family:Calibri;
            mso-hansi-font-family:Calibri;mso-bidi-font-family:Calibri;color:#707070'>
                            <o:p></o:p>
                        </span>
                    </b>
                </p>
            </td>
        </tr>
        </table>
        */

        Table table = new Table();

        TableProperties tableProperties = new TableProperties();
        TableStyle tableStyle = new TableStyle() { Val = "TableGrid" };
        TableWidth tableWidth = new TableWidth() { Width = "0", Type = TableWidthUnitValues.Auto };
        TableIndentation tableIndentation = new TableIndentation() { Width = 90, Type = TableWidthUnitValues.Dxa };

        TableBorders tableBorders = new TableBorders();
        TopBorder topBorder = new TopBorder() { Val = BorderValues.None, Color = "auto", Size = (UInt32Value)0U, Space = (UInt32Value)0U };
        LeftBorder leftBorder = new LeftBorder() { Val = BorderValues.None, Color = "auto", Size = (UInt32Value)0U, Space = (UInt32Value)0U };
        BottomBorder bottomBorder = new BottomBorder() { Val = BorderValues.None, Color = "auto", Size = (UInt32Value)0U, Space = (UInt32Value)0U };
        RightBorder rightBorder4 = new RightBorder() { Val = BorderValues.None, Color = "auto", Size = (UInt32Value)0U, Space = (UInt32Value)0U };
        InsideHorizontalBorder insideHorizontalBorder4 = new InsideHorizontalBorder() { Val = BorderValues.None, Color = "auto", Size = (UInt32Value)0U, Space = (UInt32Value)0U };
        InsideVerticalBorder insideVerticalBorder4 = new InsideVerticalBorder() { Val = BorderValues.None, Color = "auto", Size = (UInt32Value)0U, Space = (UInt32Value)0U };

        tableBorders.Append(topBorder);
        tableBorders.Append(leftBorder);
        tableBorders.Append(bottomBorder);
        tableBorders.Append(rightBorder4);
        tableBorders.Append(insideHorizontalBorder4);
        tableBorders.Append(insideVerticalBorder4);
        Shading shading = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "C2D72B" };
        TableLook tableLook = new TableLook() { Val = "04A0", FirstRow = true, LastRow = false, FirstColumn = true, LastColumn = false, NoHorizontalBand = false, NoVerticalBand = true };

        tableProperties.Append(tableStyle);
        tableProperties.Append(tableWidth);
        tableProperties.Append(tableIndentation);
        tableProperties.Append(tableBorders);
        tableProperties.Append(shading);
        tableProperties.Append(tableLook);

        TableGrid tableGrid4 = new TableGrid();
        GridColumn gridColumn4 = new GridColumn() { Width = "9090" };

        tableGrid4.Append(gridColumn4);

        TableRow tableRow4 = new TableRow() { RsidTableRowMarkRevision = "00435DB6", RsidTableRowAddition = "00435DB6", RsidTableRowProperties = "00EE6F3B", ParagraphId = "406E2796", TextId = "77777777" };

        TableRowProperties tableRowProperties3 = new TableRowProperties();
        TableRowHeight tableRowHeight3 = new TableRowHeight() { Val = (UInt32Value)648U };


        tableRowProperties3.Append(tableRowHeight3);

        TableCell tableCell4 = new TableCell();

        TableCellProperties tableCellProperties4 = new TableCellProperties();
        TableCellWidth tableCellWidth4 = new TableCellWidth() { Width = "9090", Type = TableWidthUnitValues.Dxa };
        Shading shading2 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "C2D72B" };
        TableCellVerticalAlignment tableCellVerticalAlignment1 = new TableCellVerticalAlignment() { Val = TableVerticalAlignmentValues.Center };

        tableCellProperties4.Append(tableCellWidth4);
        tableCellProperties4.Append(shading2);
        tableCellProperties4.Append(tableCellVerticalAlignment1);

        Paragraph paragraph10 = new Paragraph() { RsidParagraphMarkRevision = "00BE0741", RsidParagraphAddition = "00AF6469", RsidParagraphProperties = "00BE0741", RsidRunAdditionDefault = "00AF6469", ParagraphId = "53C4D00B", TextId = "77777777" };

        ParagraphProperties paragraphProperties9 = new ParagraphProperties();
        SpacingBetweenLines spacingBetweenLines8 = new SpacingBetweenLines() { Line = "276", LineRule = LineSpacingRuleValues.Auto };

        ParagraphMarkRunProperties paragraphMarkRunProperties9 = new ParagraphMarkRunProperties();
        RunFonts runFonts13 = new RunFonts() { Ascii = "Calibri", HighAnsi = "Calibri", ComplexScript = "Calibri" };
        Bold bold10 = new Bold();
        BoldComplexScript boldComplexScript10 = new BoldComplexScript();
        Color color13 = new Color() { Val = "707070" };
        FontSize fontSize10 = new FontSize() { Val = "40" };
        FontSizeComplexScript fontSizeComplexScript10 = new FontSizeComplexScript() { Val = "40" };

        paragraphMarkRunProperties9.Append(runFonts13);
        paragraphMarkRunProperties9.Append(bold10);
        paragraphMarkRunProperties9.Append(boldComplexScript10);
        paragraphMarkRunProperties9.Append(color13);
        paragraphMarkRunProperties9.Append(fontSize10);
        paragraphMarkRunProperties9.Append(fontSizeComplexScript10);

        paragraphProperties9.Append(spacingBetweenLines8);
        paragraphProperties9.Append(paragraphMarkRunProperties9);

        Run run6 = new Run() { RsidRunProperties = "00435DB6" };

        RunProperties runProperties6 = new RunProperties();
        RunFonts runFonts14 = new RunFonts() { Ascii = "Calibri", HighAnsi = "Calibri", ComplexScript = "Calibri" };
        Bold bold11 = new Bold();
        BoldComplexScript boldComplexScript11 = new BoldComplexScript();
        Color color14 = new Color() { Val = "707070" };
        FontSize fontSize11 = new FontSize() { Val = "48" };
        FontSizeComplexScript fontSizeComplexScript11 = new FontSizeComplexScript() { Val = "48" };

        runProperties6.Append(runFonts14);
        runProperties6.Append(bold11);
        runProperties6.Append(boldComplexScript11);
        runProperties6.Append(color14);
        runProperties6.Append(fontSize11);
        runProperties6.Append(fontSizeComplexScript11);
        Text text6 = new Text() { Space = SpaceProcessingModeValues.Preserve };
        text6.Text = " ";

        run6.Append(runProperties6);
        run6.Append(text6);

        Run run7 = new Run() { RsidRunProperties = "00BE0741" };

        RunProperties runProperties7 = new RunProperties();
        RunFonts runFonts15 = new RunFonts() { EastAsiaTheme = ThemeFontValues.MinorEastAsia, ComplexScriptTheme = ThemeFontValues.MinorBidi };
        Bold bold12 = new Bold();
        BoldComplexScript boldComplexScript12 = new BoldComplexScript();
        Color color15 = new Color() { Val = "FFFFFF", ThemeColor = ThemeColorValues.Background1 };
        Spacing spacing10 = new Spacing() { Val = 15 };
        FontSize fontSize12 = new FontSize() { Val = "40" };
        FontSizeComplexScript fontSizeComplexScript12 = new FontSizeComplexScript() { Val = "40" };

        runProperties7.Append(runFonts15);
        runProperties7.Append(bold12);
        runProperties7.Append(boldComplexScript12);
        runProperties7.Append(color15);
        runProperties7.Append(spacing10);
        runProperties7.Append(fontSize12);
        runProperties7.Append(fontSizeComplexScript12);
        Text text7 = new Text();
        text7.Text = "Absolute";

        run7.Append(runProperties7);
        run7.Append(text7);

        paragraph10.Append(paragraphProperties9);
        paragraph10.Append(run6);
        paragraph10.Append(run7);

        tableCell4.Append(tableCellProperties4);
        tableCell4.Append(paragraph10);

        tableRow4.Append(tableRowProperties3);
        tableRow4.Append(tableCell4);

        table.Append(tableProperties);
        table.Append(tableGrid4);
        table.Append(tableRow4);
    }
}
