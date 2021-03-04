using System;
using System.Linq;
using System.ServiceProcess;
using System.Threading;

namespace XmlDataValidator.Service
{
    static class Program
    {
        private static MainThread mainThread = new MainThread();

        static void Main(string[] args)
        {
            if (args.Count() > 0 && args[0] == "Console")
            {
                Thread thread = new Thread(new ThreadStart(mainThread.Start));
                thread.Start();

                while (true)
                    Thread.Sleep(50);
            }
            else
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                    new XmlDataValidatorService()
                };
                ServiceBase.Run(ServicesToRun);
            }
        }
    }
}
