using Serilog.Context;
using UnifiedSystem.Application.Interfaces;

namespace UnifiedSystem.APi.Services
{
    public class ApiLogService : IApiLogService
    {
        private readonly ILogger<ApiLogService> _logger;

        public ApiLogService(ILogger<ApiLogService> logger)
        {
            _logger = logger;
        }

        public void LogInformation(string message, params object[] args)
        {
            _logger.LogInformation(message, args);
        }

        public void LogWarning(string message, params object[] args)
        {
            _logger.LogWarning(message, args);
        }

        public void LogError(Exception exception, string message, params object[] args)
        {
            _logger.LogError(exception, message, args);
        }

        public void LogDebug(string message, params object[] args)
        {
            _logger.LogDebug(message, args);
        }

        public void LogRequest(string method, string path, string correlationId)
        {
            using (LogContext.PushProperty("CorrelationId", correlationId))
            {
                _logger.LogInformation("HTTP {Method} request to {Path}", method, path);
            }
        }
    }
}
