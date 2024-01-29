using ForAccountRecords.Application.Helpers;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAccountRecords.ApiConsuption.Helpers
{
    public class LogHelper : ILogHelper
    {

        private readonly ILogger<LogHelper> _logger;
        public LogHelper(ILogger<LogHelper> logger)
        {
            _logger = logger;
        }


        public void LogError(string requestId, string message, string ip, string methodName, Exception ex)
        {
            _logger.LogError(ex, $"requestId:{requestId}, Method Name:{methodName}, IP:{ip}, Message:{message}");
        }

        public void LogInformation(string requestId, string message, string ip, string methodName)
        {
            _logger.LogInformation($"requestId:{requestId}, Method Name:{methodName}, IP:{ip}, Message:{message}");
        }

        public void LogInformation(string requestId, string message, string ip, string methodName, object arguemnet)
        {
            _logger.LogInformation($"requestId:{requestId}, Method Name:{methodName}, IP:{ip}, Message:{message}", arguemnet);
        }

        public void LogTrace(string requestId, string message, string ip, string methodName, Exception ex)
        {
            _logger.LogError(ex, $"requestId:{requestId}, Method Name:{methodName}, IP:{ip}, Message:{message}");
        }

        public void logWarning(string requestId, string message, string ip, string methodName)
        {
            _logger.LogWarning($"requestId:{requestId}, Method Name:{methodName}, IP:{ip}, Message:{message}");
        }
    }
}
