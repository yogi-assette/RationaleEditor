using Assette.Editors.InvestmentWriter.Entities;
using DotLiquid;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

    public static string Create(Rationale rationale, string templatePath)
    {
        Template.RegisterSafeType(typeof(Rationale), new[] { "Title", "CategoryTitle", "Overview", "SubCategories", "GenerateGuid" });

        XDocument xmlTemplate = XDocument.Load(templatePath);
        string templateContent = xmlTemplate.ToString();

        Template template = Template.Parse(templateContent);
        string result = template.Render(Hash.FromAnonymousObject(new { rationale }));

        return result;
    }

    public static string Create(JObject jsonData, string templatePath)
    {
        XDocument xmlTemplate = XDocument.Load(templatePath);
        string templateContent = xmlTemplate.ToString();
        Template template = Template.Parse(templateContent);

        var data = jsonData.ToObject<Dictionary<string, object>>();
        string result = template.Render(Hash.FromAnonymousObject(new { data }));

        return result;
    }

    public static string Create(Dictionary<string, object> data, string templatePath)
    {
        XDocument xmlTemplate = XDocument.Load(templatePath);
        string templateContent = xmlTemplate.ToString();
        Template template = Template.Parse(templateContent);

        string result = template.Render(Hash.FromAnonymousObject(new { data }));

        return result;
    }
}
