using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assette.Editors.FormGenerator;

public interface IDocumentGenerator
{
    void Generate(string docPath, string xmlString);
    byte[] Generate(string xmlString);
    IList<FormData> Process(byte[] byteArray);
}
