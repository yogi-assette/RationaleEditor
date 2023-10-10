namespace Assette.Editors.Forms.Api;

public static class WebApplicationExtensions
{
    public static void MapEndpoint(this WebApplication app)
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        var classes = assemblies.Distinct().SelectMany(a => a.GetTypes()).Where(x => typeof(IEndpoint).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).ToList();

        foreach (var @class in classes)
        {
            var instance = Activator.CreateInstance(@class) as IEndpoint;
            instance?.MapEndpoint(app);
        }
    }
}
