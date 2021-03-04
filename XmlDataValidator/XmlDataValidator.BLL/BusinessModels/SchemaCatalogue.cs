using XmlDataValidator.BLL.Exceptions;
using XmlDataValidator.BLL.Interfaces;
using XmlDataValidator.BLL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace XmlDataValidator.BLL.BusinessModels
{
    internal sealed class SchemaCatalogue : ISchemaCatalogue
    {
        #region [Private Declaration]

        private static IList<Schema> SchemaList { get; set; } = new List<Schema>();

        #endregion

        #region [GetSchema]

        public Schema GetSchema(string name)
        {
            var schema = SchemaList.Where(t => t.XsdSchemaName == name).SingleOrDefault();
            if (schema != null)
                return schema;
            else
                throw new SchemaNotFoundException($"XSD-схема \"{name}\" не загружена");
        }

        #endregion

        #region [AddSchema]

        public void AddSchema(Schema schema)
        {
            var isLoaded = false;

            var schemaCatalogue = SchemaList.Where(t => t.XsdSchemaName == schema.XsdSchemaName).SingleOrDefault();
            if (schemaCatalogue != null)
            {
                if (schema.XsdSchemaFileInfo.LastWriteTime < schemaCatalogue.XsdSchemaFileInfo.LastWriteTime)
                    SchemaList.Remove(schemaCatalogue);
                else
                    isLoaded = true;
            }

            if (!isLoaded)
            {
                schema.Load();
                SchemaList.Add(schema);
            }
        }

        #endregion
    }
}
