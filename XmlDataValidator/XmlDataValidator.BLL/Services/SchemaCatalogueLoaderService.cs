using XmlDataValidator.BLL.BusinessModels;
using XmlDataValidator.BLL.Interfaces;
using XmlDataValidator.BLL.Models;
using System;
using System.Threading;

namespace XmlDataValidator.BLL.Services
{
    public class SchemaCatalogueLoaderService : BaseService, ISchemaCatalogueLoaderService
    {
        #region [Private Declaration]

        private ISchemaCatalogueLoader SchemaCatalogueLoader;

        #endregion

        public SchemaCatalogueLoaderService(ConfigurationSettings configurationSettings) : base(configurationSettings)
        {
            SchemaCatalogueLoader = new SchemaCatalogueLoader(configurationSettings.SchemaCataloguePath);
        }

        #region [LoadSchemaCatalogue]

        public void LoadSchemaCatalogue()
        {
            SchemaCatalogueLoader.LoadCatalogue();
        }

        #endregion
    }
}
