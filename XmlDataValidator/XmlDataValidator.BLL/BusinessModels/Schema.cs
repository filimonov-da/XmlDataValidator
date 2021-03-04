using XmlDataValidator.BLL.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using XmlDataValidator.BLL.Interfaces;

namespace XmlDataValidator.BLL.BusinessModels
{
    internal sealed class Schema : ISchema
    {
        #region [Private Declaration]

        private const string constValidationError = "Ошибка валилации XSD-схемы \"{0}\": \"{}\"";
        
        #endregion

        public XmlSchema XsdSchema { get; private set; }

        public string XsdSchemaName => Path.GetFileNameWithoutExtension(XsdSchemaFileInfo.Name);
        
        public FileInfo XsdSchemaFileInfo { get; private set; }

        public Schema(FileInfo file)
        {
            XsdSchemaFileInfo = file;
        }

        public void Load()
        {
            using (var fs = XsdSchemaFileInfo.OpenRead())
            {
                try
                {
                    XsdSchema = XmlSchema.Read(fs, SchemaValidationHandler);
                }
                catch (Exception ex)
                {
                    throw new SchemaValidationException(String.Format(constValidationError, XsdSchemaName, ex.Message));
                }
            }
        }

        #region [SchemaValidationHandler]

        private void SchemaValidationHandler(object sender, ValidationEventArgs args) => throw new SchemaValidationException(String.Format(constValidationError, XsdSchemaName, args.Message));

        #endregion
    }
}
