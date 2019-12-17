using DispatcherProject.QuartzNet;
using MyDispatcherProject.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace MyDispatcherProjectRichardWindowsService
{
    public partial class Service1 : ServiceBase
    {

        Log4NetLogger log4NetLogger = new Log4NetLogger(typeof(Service1));
        public Service1()
        {
            InitializeComponent();
            DispatcherManager.Init().GetAwaiter().GetResult();
        }

        protected override void OnStart(string[] args)
        {
            log4NetLogger.Info("Service1  is Start");
        }

        protected override void OnStop()
        {
            log4NetLogger.Info("Service1  is Stop");
        }
    }
}
