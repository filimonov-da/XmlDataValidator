using System;
using System.Configuration;
using System.Globalization;
using XmlDataValidator.BLL.Args;
using XmlDataValidator.BLL.Interfaces;

namespace XmlDataValidator.BLL.BusinessModels
{
    public class ConfigurationSettings : Configuration, IConfigurationSettings
    {
        public string ServiceAddress => (string)GetAppSetting(typeof(string), "ServiceAddress");
        public string SchemaCataloguePath => (string)GetAppSetting(typeof(string), "SchemaCataloguePath");
        public TimeSpan SchemaCatalogueLoadTimeInterval => (TimeSpan)GetAppSetting(typeof(TimeSpan), "SchemaCatalogueLoadTimeInterval");

        public static event EventHandler<ValidationEventArgs> OnValidation;

        public static void Validation(object sender, ValidationEventArgs validationEventArgs) => OnValidation?.Invoke(sender, validationEventArgs);
    }
}
