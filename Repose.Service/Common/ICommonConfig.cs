﻿using System;

namespace Repose.Service.Common
{
    public interface ICommonConfig
    {
        string JavaExecutablePath { get; }
        string ReposePath { get; }
        string StartAction { get; }
        string StopAction { get; }
        string Port { get; }
        string ReposeConfigs { get; }
    }
}
