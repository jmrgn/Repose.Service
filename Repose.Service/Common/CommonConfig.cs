using System;
using System.Configuration;

namespace Repose.Service.Common
{
    public class CommonConfig : ICommonConfig
    {
        public string JavaExecutablePath
        {
            get
            {
                string value = ConfigurationManager.AppSettings["javaExecutablePath"];
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
                string value = ConfigurationManager.AppSettings["reposePath"];
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
                string value = ConfigurationManager.AppSettings["startAction"];
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
                string value = ConfigurationManager.AppSettings["stopAction"];
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
                string value = ConfigurationManager.AppSettings["port"];
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
                string value = ConfigurationManager.AppSettings["reposeConfigs"];
                if (string.IsNullOrWhiteSpace(value))
                {
                    return string.Empty;
                }

                return value;
            }
        }
    }
}
