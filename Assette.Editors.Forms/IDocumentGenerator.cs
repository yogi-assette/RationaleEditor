namespace Assette.Editors.Forms;

public interface IDocumentGenerator
{
    void GenerateByDocPath(string docPath, string xmlString);
    byte[] Generate(string xmlString);

    byte[] Generate(string id, string xmlString);

    byte[] ProcessContent(byte[] byteArray, string xmlString, out IList<FormData> formData);
}
