using Serilog.Context;
using UnifiedSystem.Application.Interfaces;

namespace UnifiedSystem.APi.Middlewares
{
    public class CorrelationIdMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CorrelationIdMiddleware> _logger;

        public CorrelationIdMiddleware(RequestDelegate next, ILogger<CorrelationIdMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, IApiLogService logService)
        {
            // Prefer client-provided correlation ID, fallback to new GUID
            var correlationId = context.Request.Headers["X-Correlation-Id"].FirstOrDefault() ?? Guid.NewGuid().ToString();
            context.Items["CorrelationId"] = correlationId; // Store in HttpContext.Items for controller access
            context.Response.Headers["X-Correlation-Id"] = correlationId;

            using (LogContext.PushProperty("CorrelationId", correlationId))
            {
                logService.LogRequest(context.Request.Method, context.Request.Path, correlationId);
                await _next(context);
            }
        }
    }
}
