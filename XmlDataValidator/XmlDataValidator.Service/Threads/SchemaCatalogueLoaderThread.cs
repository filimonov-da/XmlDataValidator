using Autofac;
using System;
using System.Threading;
using XmlDataValidator.BLL.Exceptions;
using XmlDataValidator.BLL.Interfaces;

namespace XmlDataValidator.Service
{
    public class SchemaCatalogueLoaderThread
    {
        #region [Private Declaration]

        private static Timer Timer;
        private static object TimerLock = new object();

        private IConfigurationSettings ConfigurationSettings = new BLL.BusinessModels.ConfigurationSettings();
        private ILoggerService LoggerService;
        private ISchemaCatalogueLoaderService SchemaCatalogueLoaderService;

        #endregion

        public SchemaCatalogueLoaderThread(IContainer container)
        {
            using (var scope = container.BeginLifetimeScope())
            {
                LoggerService = scope.Resolve<ILoggerService>();
                SchemaCatalogueLoaderService = scope.Resolve<ISchemaCatalogueLoaderService>();
            }
        }

        #region [Start]

        public void Start()
        {
            try
            {
                Timer = new Timer(new TimerCallback(LoadSchemaCatalogue), null, 0, (int)ConfigurationSettings.SchemaCatalogueLoadTimeInterval.TotalMilliseconds);
            }
            catch (Exception ex)
            {
                LoggerService.Error(ex);

                throw;
            }
        }

        #endregion

        #region [Stop]

        public void Stop()
        {
            try
            {
                Timer.Change(Timeout.Infinite, Timeout.Infinite);

            }
            catch (Exception ex)
            {
                LoggerService.Error(ex);

                throw;
            }
        }

        #endregion

        #region [LoadSchemaCatalogue]

        private void LoadSchemaCatalogue(object obj)
        {
            lock (TimerLock)
            {
                try
                {
                    SchemaCatalogueLoaderService.LoadSchemaCatalogue();
                }
                catch(CatalogueNotFoundException ex)
                {
                    LoggerService.Error(ex);
                }
                catch (SchemaValidationException ex)
                {
                    LoggerService.Error(ex);
                }
                catch (Exception ex)
                {
                    LoggerService.Error(ex);

                    throw;
                }
            }
        }

        #endregion
    }
}
