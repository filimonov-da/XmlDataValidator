using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlDataValidator.BLL.BusinessModels;
using XmlDataValidator.BLL.Interfaces;

namespace XmlDataValidator.BLL.Services
{
    public class BaseService
    {
        protected IConfigurationSettings ConfigurationSettings;

        public BaseService(ConfigurationSettings configurationSettings)
        {
            ConfigurationSettings = configurationSettings;
        }
    }
}
