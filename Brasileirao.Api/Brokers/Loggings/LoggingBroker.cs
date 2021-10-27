using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NLog;

namespace Brasileirao.Api.Brokers.Loggings
{
  public class LoggingBroker : ILoggingBroker
  {
    private static ILogger logger = LogManager.GetCurrentClassLogger();

    public LoggingBroker()
    {

    }

    public void LogCritical(Exception exception, string message)
    {
      logger.Fatal(exception, message);
    }

    public void LogDebug(string message)
    {
      logger.Debug(message);
    }

    public void LogError(Exception exception, string message)
    {
      logger.Error(exception, message);
    }

    public void LogInformation(string message)
    {
      logger.Info(message);
    }

    public void LogTrace(string message)
    {
      logger.Trace(message);
    }

    public void LogWarning(string message)
    {
      logger.Warn(message);
    }
  }
}