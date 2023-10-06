using DotLiquid;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;

namespace Assette.Editors.FormGenerator;
public class XmlGenerator
{
    protected XmlGenerator()
    {
    }

    /* TODO: Should be removed
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
    */

    public static string Create(JObject data, string templatePath)
    {
        XDocument xmlTemplate = XDocument.Load(templatePath);
        string templateContent = xmlTemplate.ToString();

        Template.RegisterSafeType(typeof(JObject), new string[] { "*" });
        Template.RegisterValueTypeTransformer(typeof(JObject), value => value.ToString());

        Template template = Template.Parse(templateContent);
        
        string result = template.Render(Hash.FromAnonymousObject(new { data = data}));

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
