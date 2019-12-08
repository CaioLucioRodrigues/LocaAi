﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LocaAi.Domain.Interfaces.Services.Logging
{
    public interface ILogServiceBase
    {
        List<ILogComponent> LogComponents { get; set; }

        void LogCritical<T>(Exception error, string message = "", params object[] args);
        
        void LogError<T>(Exception error, string message = "", params object[] args);

        void LogError<T>(string message = "", params object[] args);

        void LogDebug<T>(string message = "", params object[] args);

        void LogTrace<T>(string message = "", params object[] args);

        void LogWarning<T>(string message = "", params object[] args);

        void LogInfo<T>(string message = "", params object[] args);
    }
}
