using Assette.Editors.Forms.Mapper.Converters;
using Assette.Editors.Forms.Mapper.Entities.Rationale;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Template;
using System.Xml.Linq;

namespace Assette.Editors.Forms.Api;

public class FormsHandler : IEndpoint
{
    public void MapEndpoint(WebApplication app)
    {
        app.MapGet("api/formsservice/generate", () => "API works successfully!!!");


        app.MapPost("api/formsservice/generate", ([FromBody] Rationale rationale) =>
        {
            RationaleConverter rationaleConverter = new();
            var rationaleDictionary = rationaleConverter.RationaleToDictionary(rationale);

            string _templatePath = @".\templates\RationaleTemplate.xml";
            string rationaleXml = XmlGenerator.Create(rationaleDictionary, _templatePath);

            IDocumentGenerator documentGenerator = new DocumentGenerator();
            byte[] byteArray = documentGenerator.Generate(rationaleXml);

            // TODO:[Remove this cod] Saved document locally for testing purpose
            string identifier = $"./doc/{Guid.NewGuid()}.docx";
            File.WriteAllBytes(identifier, byteArray);

            return byteArray;
        });

        app.MapPost("api/formsservice/generate/{id}", (string id, [FromBody] Rationale rationale) => 
        {
            RationaleConverter rationaleConverter = new();
            var rationaleDictionary = rationaleConverter.RationaleToDictionary(rationale);

            string _templatePath = @".\templates\RationaleTemplate.xml";
            string rationaleXml = XmlGenerator.Create(rationaleDictionary, _templatePath);

            IDocumentGenerator documentGenerator = new DocumentGenerator();
            byte[] byteArray = documentGenerator.Generate(id, rationaleXml);

            // TODO:[Remove this cod] Saved document locally for testing purpose
            string identifier = $"./doc/{Guid.NewGuid()}.docx";
            File.WriteAllBytes(identifier, byteArray);
        });
    }
}
