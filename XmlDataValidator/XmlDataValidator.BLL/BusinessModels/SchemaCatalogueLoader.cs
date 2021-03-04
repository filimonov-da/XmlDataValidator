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
    internal sealed class SchemaCatalogueLoader : ISchemaCatalogueLoader
    {
        #region [Private Declaration]

        private static object LockLoader = new object();
        private static string SchemaCataloguePath;
        private static SchemaCatalogue SchemaCatalogue = new SchemaCatalogue();

        #endregion

        public SchemaCatalogueLoader(string schemaCataloguePath)
        {
            SchemaCataloguePath = schemaCataloguePath;
        }

        #region [LoadCatalogue]

        public void LoadCatalogue()
        {
            lock (LockLoader)
            {
                if (Directory.Exists(SchemaCataloguePath))
                {
                    var di = new DirectoryInfo(SchemaCataloguePath);
                    var fi = di.GetFiles("*.xsd", SearchOption.AllDirectories);

                    fi.ToList().ForEach(f => SchemaCatalogue.AddSchema(new Schema(f)));
                }
                else
                    throw new CatalogueNotFoundException($"Каталог XSD-схем \"{SchemaCataloguePath}\" не найден");
            }
        }

        #endregion
    }
}
