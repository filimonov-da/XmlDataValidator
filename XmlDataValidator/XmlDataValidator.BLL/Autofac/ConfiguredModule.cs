using Autofac;
using XmlDataValidator.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlDataValidator.BLL.Autofac
{
    public abstract class ConfiguredModule : Module
    {
        public IConfigurationSettings ConfigurationSettings { get; set; }
    }
}
