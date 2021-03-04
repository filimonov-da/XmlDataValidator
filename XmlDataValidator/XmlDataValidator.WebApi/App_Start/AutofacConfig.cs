using Autofac;
using Autofac.Core;
using Autofac.Integration.WebApi;
using XmlDataValidator.BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Http;

namespace XmlDataValidator.WebApi
{
    public class AutofacConfig
    {
        public static IContainer Container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }

        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterModule<SchemaValidatorModule>();

            Container = builder.Build();

            return Container;
        }
    }
}