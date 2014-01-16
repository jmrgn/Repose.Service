using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repose.Service.Common;
using Topshelf;
using log4net;

namespace Repose.Service
{
    public class ReposeService
    {
        private static ILog log = LogManager.GetLogger(typeof(ReposeService));
        static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();
            
            log.Debug("Preparing to host the repose service");
            var config = new CommonConfig();

            HostFactory.Run(x =>
            {
                x.UseLog4Net();
                x.Service<ReposeHost>(s =>                        
                {
                    s.ConstructUsing(name => new ReposeHost(config));    
                    s.WhenStarted(r => r.Start());              
                    s.WhenStopped(r => r.Stop());              
                });
                x.RunAsLocalSystem();                            
               
                x.SetDescription("Repose Windows Host");        
                x.SetDisplayName("Repose.Service");                       
                x.SetServiceName("Repose.Service");                       
            });              
        }
    }
}
