using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using System.Web.Http;

[assembly: OwinStartup(typeof(XmlDataValidator.WebApi.Startup))]

namespace XmlDataValidator.WebApi
{
    public partial class Startup
    {
        public virtual void Configuration(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();

            WebApiConfig.Register(config);

            RouteConfig.RegisterRoutes(config);

            AutofacConfig.Initialize(config);

            appBuilder.UseWebApi(config);
        }
    }
}
