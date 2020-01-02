using LocaAi.Domain.Interfaces.Services.Logging;
using log4net;
using System;
using System.IO;
using System.Reflection;
using System.Xml;

namespace LocaAi.Services.Log.Components
{
    public class LogForNetLogging : ILogComponent
    {
        public void Configure(object[] context)
        {
            XmlDocument log4netConfig = new XmlDocument();
            log4netConfig.Load(File.OpenRead("log4net.config"));
            var repo = log4net.LogManager.CreateRepository(Assembly.GetEntryAssembly(),
                       typeof(log4net.Repository.Hierarchy.Hierarchy));
            log4net.Config.XmlConfigurator.Configure(repo, log4netConfig["log4net"]);
        }

        public void LogCritical<T>(Exception error)
        {
            ILog _logger = log4net.LogManager.GetLogger(typeof(T));
            _logger.Fatal("Fatal Erorr", error);
        }

        public void LogCritical<T>(Exception error, string message = "", params object[] args)
        {
            ILog _logger = log4net.LogManager.GetLogger(typeof(T));
            _logger.Fatal(string.Format(message, args), error);
        }

        public void LogDebug<T>(string message = "", params object[] args)
        {
            ILog _logger = log4net.LogManager.GetLogger(typeof(T));
            _logger.Debug(string.Format(message, args));
        }

        public void LogError<T>(Exception error)
        {
            ILog _logger = log4net.LogManager.GetLogger(typeof(T));
            _logger.Error("Error", error);
        }

        public void LogError<T>(string message = "", params object[] args)
        {
            ILog _logger = log4net.LogManager.GetLogger(typeof(T));
            _logger.Error(string.Format(message, args));
        }

        public void LogError<T>(Exception error, string message = "", params object[] args)
        {
            ILog _logger = log4net.LogManager.GetLogger(typeof(T));
            _logger.Error(string.Format(message, args), error);
        }

        public void LogInfo<T>(string message = "", params object[] args)
        {
            ILog _logger = log4net.LogManager.GetLogger(typeof(T));
            _logger.Info(string.Format(message, args));
        }

        public void LogTrace<T>(string message = "", params object[] args)
        {
            ILog _logger = log4net.LogManager.GetLogger(typeof(T));
            _logger.Debug(string.Format(message, args));
        }

        public void LogWarning<T>(string message = "", params object[] args)
        {
            ILog _logger = log4net.LogManager.GetLogger(typeof(T));
            _logger.Warn(string.Format(message, args));
        }
    }
}