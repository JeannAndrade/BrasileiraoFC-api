using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brasileirao.Api.Brokers.Loggings
{
  public interface ILoggingBroker
  {
    void LogInformation(string message);
    void LogTrace(string message);
    void LogDebug(string message);
    void LogWarning(string message);
    void LogError(Exception exception, string message);
    void LogCritical(Exception exception, string message);
  }
}