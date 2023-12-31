﻿using DocumentFormat.OpenXml.Wordprocessing;

namespace Assette.Editors.Forms;
public class FormData
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? Value { get; set; }
    public IEnumerable<Paragraph>? Paragraphs { get; set; }

}
