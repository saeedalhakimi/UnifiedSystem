using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnifiedSystem.APi.Routes;
using UnifiedSystem.Application.Interfaces;

namespace UnifiedSystem.APi.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route(ApiRoutes.BaseRoute)]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IApiLogService _logService;

        public TestController(IApiLogService logService)
        {
            _logService = logService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var correlationId = HttpContext.Items["CorrelationId"]?.ToString() ?? HttpContext.TraceIdentifier;
            _logService.LogInformation("Test API V1 endpoint hit at {Time} with CorrelationId: {CorrelationId}", DateTime.UtcNow, correlationId);

            try
            {
                _logService.LogDebug("Processing GET request for TestController");
                // Simulate some work
                return Ok("Test API V1 is working!");
            }
            catch (Exception ex)
            {
                _logService.LogError(ex, "Error in Test API V1 endpoint with CorrelationId: {CorrelationId}", correlationId);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
