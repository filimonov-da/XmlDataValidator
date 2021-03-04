using Autofac;
using Autofac.Core;
using XmlDataValidator.BLL.Autofac;
using XmlDataValidator.BLL.BusinessModels;
using XmlDataValidator.BLL.Interfaces;
using XmlDataValidator.BLL.Services;
using System;
using System.Collections.Generic;

namespace XmlDataValidator.BLL.Infrastructure
{
    public class SchemaValidatorModule : ConfiguredModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new ConfigurationSettings()).InstancePerLifetimeScope();
            builder.RegisterType<LoggerService>().As<ILoggerService>().InstancePerLifetimeScope();
            builder.RegisterType<SchemaCatalogueLoaderService>().As<ISchemaCatalogueLoaderService>().InstancePerLifetimeScope();
            builder.RegisterType<SchemaValidationService>().As<ISchemaValidationService>().InstancePerLifetimeScope();

            //builder.Register(c => new AppDbContext()).InstancePerLifetimeScope();
            //builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerDependency();
        }
    }

    public static class ConfiguredModuleRegistrationExtensions
    {
        #region [RegisterConfiguredModulesFromAssemblyContaining]

        public static ContainerBuilder RegisterConfiguredModulesFromAssemblyContaining<TType>(this ContainerBuilder builder, IConfigurationSettings configurationSettings)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            if (configurationSettings == null)
                throw new ArgumentNullException(nameof(configurationSettings));

            var metaBuilder = new ContainerBuilder();

            metaBuilder.RegisterInstance(configurationSettings);
            metaBuilder.RegisterAssemblyTypes(typeof(TType).Assembly)
                .AssignableTo<IModule>()
                .As<IModule>()
                .PropertiesAutowired();

            using (IContainer metaContainer = metaBuilder.Build())
            {
                foreach (IModule module in metaContainer.Resolve<IEnumerable<IModule>>())
                    builder.RegisterModule(module);
            }

            return builder;
        }

        #endregion
    }
}
