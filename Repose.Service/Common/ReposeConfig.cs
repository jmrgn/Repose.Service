using System;
using System.Collections.Specialized;
using System.Configuration;

namespace Repose.Service.Common
{
    public class ReposeConfig : IReposeConfig
    {
        private readonly NameValueCollection config;
        public ReposeConfig(NameValueCollection collection)
        {
            this.config = collection;
        }

        public ReposeConfig()
        {
            config = ConfigurationManager.GetSection("repose") as NameValueCollection;
        }

        public string JavaExecutablePath
        {
            get
            {
                string value = config["javaExecutablePath"];
                if (string.IsNullOrWhiteSpace(value))
                {
                    return string.Empty;
                }

                return value;
            }
        }

        public string ReposePath
        {
            get
            {
                string value = config["reposePath"];
                if (string.IsNullOrWhiteSpace(value))
                {
                    return string.Empty;
                }

                return value;
            }
        }

        public string StartAction
        {
            get
            {
                string value = config["startAction"];
                if (string.IsNullOrWhiteSpace(value))
                {
                    return string.Empty;
                }

                return value;
            }
        }

        public string StopAction
        {
            get
            {
                string value = config["stopAction"];
                if (string.IsNullOrWhiteSpace(value))
                {
                    return string.Empty;
                }

                return value;
            }
        }

        public string Port
        {
            get
            {
                string value = config["port"];
                if (string.IsNullOrWhiteSpace(value))
                {
                    return string.Empty;
                }

                return value;
            }
        }

        public string ReposeConfigs
        {
            get
            {
                string value = config["reposeConfigs"];
                if (string.IsNullOrWhiteSpace(value))
                {
                    return string.Empty;
                }

                return value;
            }
        }
    }
}
