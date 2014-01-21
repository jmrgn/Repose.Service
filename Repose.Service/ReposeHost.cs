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
        private readonly IReposeConfig configuration;
        private static ILog log = LogManager.GetLogger(typeof(ReposeService));
        public Process repose;

        public ReposeHost(IReposeConfig config)
        {
            this.configuration = config;
        }

        public void Start() 
        {
            log.Info("ReposeHost: Starting service...");
            RunProcess();
        }

        public void Stop()
        {
            log.Info("Stopping service...");
            if (repose != null && !repose.HasExited)
            {
                string args = string.Format("-jar {0} {1} -s {2}",
                                                configuration.ReposePath,
                                                configuration.StopAction,
                                                configuration.Port);

                Process.Start(configuration.JavaExecutablePath, args);
            }
        }

        public void RunProcess()
        {
            try
            {
                string args = string.Format("-jar {0} {1} -s {2} -c {3}",
                                                    configuration.ReposePath,
                                                    configuration.StartAction,
                                                    configuration.Port,
                                                    configuration.ReposeConfigs);

                var info = new ProcessStartInfo(configuration.JavaExecutablePath, args);
                info.Verb = "runas";
                log.Debug(string.Format("Starting the repose process with the following arguments: {0}", args));
                repose = Process.Start(info);
                repose.EnableRaisingEvents = true;
                repose.Exited += repose_Exited;
            }
            catch (Exception)
            {
                Stop();
                throw;
            }
        }

        void repose_Exited(object sender, System.EventArgs e)
        {
            var errorMsg = "Repose exited unexpectedly at {0} with an exit code of {1}. Please check the repose logs for details.";
            log.Error(string.Format(errorMsg, repose.ExitTime, repose.ExitTime));
            this.Stop();
        }
    }
}
