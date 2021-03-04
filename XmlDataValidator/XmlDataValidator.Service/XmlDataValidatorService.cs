using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace XmlDataValidator.Service
{
    partial class XmlDataValidatorService : ServiceBase
    {
        private MainThread mainThread = new MainThread();

        public XmlDataValidatorService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            var currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += new UnhandledExceptionEventHandler(GlobalErrorHandler);

            base.OnStart(args);

            Thread thread = new Thread(new ThreadStart(mainThread.Start));
            thread.Start();
        }

        protected override void OnStop()
        {
            mainThread.Stop();

            base.OnStop();
        }

        void GlobalErrorHandler(object sender, UnhandledExceptionEventArgs args)
        {
            var ex = (args.ExceptionObject as Exception);
        }
    }
}
