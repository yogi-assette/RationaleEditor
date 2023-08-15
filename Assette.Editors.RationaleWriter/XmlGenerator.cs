using Assette.Editors.InvestmentWriter.Entities;
using DotLiquid;
using System.Xml.Linq;

namespace Assette.Editors.InvestmentWriter;
public class XmlGenerator
{
    protected XmlGenerator()
    {
    }

    public static string Create(string templatePath)
    {
        RationaleTest rationaleTest = new();
        Rationale rationale = rationaleTest.Get;

        Template.RegisterSafeType(typeof(Rationale), new[] { "Title", "CategoryTitle", "Overview", "SubCategories", "GenerateGuid" });

        XDocument xmlTemplate = XDocument.Load(templatePath);
        string templateContent = xmlTemplate.ToString();
        
        Template template = Template.Parse(templateContent);
        string result = template.Render(Hash.FromAnonymousObject(new { rationale }));

        return result;
    }
}
