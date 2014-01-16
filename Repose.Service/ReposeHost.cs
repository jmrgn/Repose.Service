using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using Repose.Service.Common;

namespace Repose.Service
{
    public class ReposeHost
    {
        private readonly ICommonConfig configuration;
        private static ILog log = LogManager.GetLogger(typeof(ReposeService));
        public Process repose;

        public ReposeHost(ICommonConfig config)
        {
            this.configuration = config;
        }

        public void Start() 
        {
            log.Info("Starting service...");
            RunProcess();
        }

        public void Stop()
        {
            log.Debug("Stopping service...");

        }

        public void RunProcess()
        {
           
        }

        void repose_Exited(object sender, System.EventArgs e)
        {
            // Log an error and stop
            this.Stop();
        }
    }
}
