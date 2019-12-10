using System;
using System.Collections.Generic;
using LocaAi.Domain.Interfaces.Services.Logging;
using LocaAi.Services.Log.Components;

namespace LocaAi.Services.Log
{
    public class LogServiceBase : ILogServiceBase
    {
        public List<ILogComponent> LogComponents { get; set; } = new List<ILogComponent>();

        public LogServiceBase()
        {
            ILogComponent kissLog = new KissLogging();
            LogComponents.Add(kissLog);

            ILogComponent log4net = new LogForNetLogging();
            LogComponents.Add(log4net);
        }
        public void Configure(object[] context)
        {
            LogComponents.ForEach(c => c.Configure(context));
        }

        public void LogCritical<T>(Exception error)
        {
            LogComponents.ForEach(c => c.LogError<T>(error));
        }

        public void LogDebug<T>(string message = "", params object[] args)
        {
            LogComponents.ForEach(c => c.LogDebug<T>(message, args));
        }

        public void LogError<T>(Exception error)
        {
            LogComponents.ForEach(c => c.LogError<T>(error));
        }

        public void LogError<T>(string message = "", params object[] args)
        {
            LogComponents.ForEach(c => c.LogError<T>(message, args));
        }

        public void LogInfo<T>(string message = "", params object[] args)
        {
            LogComponents.ForEach(c => c.LogInfo<T>(message, args));
        }

        public void LogTrace<T>(string message = "", params object[] args)
        {
            LogComponents.ForEach(c => c.LogTrace<T>(message, args));
        }

        public void LogWarning<T>(string message = "", params object[] args)
        {
            LogComponents.ForEach(c => c.LogWarning<T>(message, args));
        }

        public void LogCritical<T>(Exception error, string message = "", params object[] args)
        {
            LogComponents.ForEach(c => c.LogCritical<T>(error, string.Format(message, args)));
        }

        public void LogError<T>(Exception error, string message = "", params object[] args)
        {
            LogComponents.ForEach(c => c.LogError<T>(error, string.Format(message, args)));
        }
    }
}
