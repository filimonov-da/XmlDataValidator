using System.IO;
using System.Xml.Schema;

namespace XmlDataValidator.BLL.Interfaces
{
    internal interface ISchema
    {
        XmlSchema XsdSchema { get; }
        FileInfo XsdSchemaFileInfo { get; }
        string XsdSchemaName { get; }

        void Load();
    }
}