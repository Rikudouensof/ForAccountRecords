using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAccountRecords.Application.Helpers
{
  public interface ILogHelper
  {
    void LogError(string requestId, string message, string ip, string methodName, Exception ex);
    void LogInformation(string requestId, string message, string ip, string methodName);
    void logInformation(string requestId, string message, string ip, string methodName, object arguemnet);
    void LogTrace(string requestId, string message, string ip, string methodName, Exception ex);
    void logWarning(string requestId, string message, string ip, string methodName);
  }
}
