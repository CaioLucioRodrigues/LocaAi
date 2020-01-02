using KissLog;
using KissLog.Apis.v1.Listeners;
using KissLog.AspNetCore;
using LocaAi.Domain.Interfaces.Services.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using System;

namespace LocaAi.Services.Log.Components
{
    public class KissLogging : ILogComponent
    {
        private readonly ILogger _logger;

        public KissLogging()
        {
            _logger = Logger.Factory.Get();
        }

        public void Configure(object[] context)
        {
            IApplicationBuilder app = (IApplicationBuilder)context[0];
            IConfiguration config = (IConfiguration)context[1];

            app.UseKissLogMiddleware(options => options.Listeners.Add(new KissLogApiListener(new KissLog.Apis.v1.Auth.Application(
                config["KissLog.OrganizationId"],
                config["KissLog.ApplicationId"])
            )));
        }

        public void LogCritical<T>(Exception error)
        {
            _logger.Critical(error);
        }

        public void LogCritical<T>(Exception error, string message = "", params object[] args)
        {
            _logger.Critical(error);
        }

        public void LogDebug<T>(string message = "", params object[] args)
        {
            _logger.Debug(string.Format(message, args));
        }

        public void LogError<T>(Exception error)
        {
            _logger.Error(error);
        }

        public void LogError<T>(string message = "", params object[] args)
        {
            _logger.Error(string.Format(message, args));
        }

        public void LogError<T>(Exception error, string message = "", params object[] args)
        {
            _logger.Error(error);
        }

        public void LogInfo<T>(string message = "", params object[] args)
        {
            _logger.Info(string.Format(message, args));
        }

        public void LogTrace<T>(string message = "", params object[] args)
        {
            _logger.Trace(string.Format(message, args));
        }

        public void LogWarning<T>(string message = "", params object[] args)
        {
            _logger.Warn(string.Format(message, args));
        }
    }
}
