using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;
using Microsoft.AspNet.WebApi.Extensions.Compression.Server;
using System.Net.Http.Extensions.Compression.Core.Compressors;
using Newtonsoft.Json;
using System.Net.Http.Formatting;
using XmlDataValidator.BLL.Models;
using System.Xml.Serialization;

namespace XmlDataValidator.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            AutoMapperConfig.Initialize();

            config.MapHttpAttributeRoutes();
            config.Formatters.XmlFormatter.UseXmlSerializer = true;
            config.Formatters.XmlFormatter.SetSerializer<ValidationRequest>(new XmlSerializer(typeof(ValidationRequest)));
            config.Formatters.XmlFormatter.SetSerializer<ValidationResponse>(new XmlSerializer(typeof(ValidationResponse)));
            config.Formatters.JsonFormatter.SupportedMediaTypes.Clear();
            config.MessageHandlers.Insert(0, new ServerCompressionHandler(new GZipCompressor(), new DeflateCompressor()));
        }
    }
}
