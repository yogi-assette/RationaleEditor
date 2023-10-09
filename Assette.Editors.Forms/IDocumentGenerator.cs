namespace Assette.Editors.Forms;

public interface IDocumentGenerator
{
    void Generate(string docPath, string xmlString);
    byte[] Generate(string xmlString);
    byte[] ProcessContent(byte[] byteArray, string xmlString, out IList<FormData> formData);
}
