using System;
using Owin;
using XmlDataValidator.WebApi;
using XmlDataValidator.WebApi.Controllers;

namespace XmlDataValidator.Service
{
    class WebServiceStartup : Startup
    {
        //  Hack from http://stackoverflow.com/a/17227764/19020 to load controllers in 
        //  another assembly.  Another way to do this is to create a custom assembly resolver
        private readonly Type valuesControllerType = typeof(ValidateController);

        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public override void Configuration(IAppBuilder appBuilder)
        {
            base.Configuration(appBuilder);
        }
    }
}