using System;
using XmlDataValidator.BLL.Args;

namespace XmlDataValidator.BLL.Interfaces
{
    public interface IConfigurationSettings
    {
        string SchemaCataloguePath { get; }
        TimeSpan SchemaCatalogueLoadTimeInterval { get; }
        string ServiceAddress { get; }

        //void Validation(object sender, ValidationEventArgs validationEventArgs);
    }
}