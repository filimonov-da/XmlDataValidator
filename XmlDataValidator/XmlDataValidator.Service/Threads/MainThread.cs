using System;
using Microsoft.Owin.Hosting;
using System.Configuration;
using Autofac;
using XmlDataValidator.BLL.Interfaces;
using XmlDataValidator.BLL.Infrastructure;
using System.Threading;
using System.IO;
using XmlDataValidator.BLL.Args;
using XmlDataValidator.BLL.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace XmlDataValidator.Service
{
    public class MainThread
    {
        #region [Private Declaration]

        private BLL.BusinessModels.ConfigurationSettings ConfigurationSettings = new BLL.BusinessModels.ConfigurationSettings();
        private SchemaCatalogueLoaderThread SchemaCatalogueLoaderThread;
        private IDisposable Service;

        #endregion

        public MainThread()
        {
            #region [Create container]

            var builder = new ContainerBuilder();
            builder.RegisterConfiguredModulesFromAssemblyContaining<SchemaValidatorModule>(ConfigurationSettings);
            var container = builder.Build();

            #endregion

            SchemaCatalogueLoaderThread = new SchemaCatalogueLoaderThread(container);
        }

        #region [Start]

        public void Start()
        {
            BLL.BusinessModels.ConfigurationSettings.OnValidation += JavaValidator.Validation;

            Thread thread = new Thread(new ThreadStart(SchemaCatalogueLoaderThread.Start));
            thread.Start();

            Service = WebApp.Start<WebServiceStartup>(url: ConfigurationSettings.ServiceAddress);
        }

        #endregion

        #region [Stop]

        public void Stop()
        {
            SchemaCatalogueLoaderThread.Stop();

            Service.Dispose();
        }

        #endregion
    }
}
