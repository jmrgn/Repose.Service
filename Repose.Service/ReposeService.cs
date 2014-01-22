using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
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
            log.Debug("Preparing to host the repose service");
            var settings = ConfigurationManager.GetSection("repose") as NameValueCollection;
            var config = new ReposeConfig(settings);
            log4net.Config.XmlConfigurator.Configure();

            HostFactory.Run(x =>
            {
                x.UseLog4Net();
                x.Service<ReposeHost>(s =>                        
                {
                    s.ConstructUsing(name => new ReposeHost(config));    
                    s.WhenStarted(r => r.Start());              
                    s.WhenStopped(r => r.Stop());              
                });
               
                x.SetDescription("Repose Windows Host");        
                x.SetDisplayName("Repose.Service");                       
                x.SetServiceName("Repose.Service");                       
            });              
        }
    }
}
