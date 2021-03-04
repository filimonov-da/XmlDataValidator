using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace XmlDataValidator.Service
{
    [RunInstaller(true)]
    public partial class XmlDataValidatorInstaller : System.Configuration.Install.Installer
    {
        ServiceInstaller serviceInstaller;
        ServiceProcessInstaller processInstaller;

        public XmlDataValidatorInstaller()
        {
            InitializeComponent();
            serviceInstaller = new ServiceInstaller();
            processInstaller = new ServiceProcessInstaller();

            processInstaller.Account = ServiceAccount.User;
            serviceInstaller.StartType = ServiceStartMode.Automatic;
            serviceInstaller.DelayedAutoStart = true;
            serviceInstaller.ServiceName = "XmlDataValidatorSevice";
            serviceInstaller.Description = "Эта служба выполняет валидацию XML данных согласно выбранной XSD схеме по протоколу HTTP";
            Installers.Add(processInstaller);
            Installers.Add(serviceInstaller);
        }
    }
}
