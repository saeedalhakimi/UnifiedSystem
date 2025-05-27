using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnifiedSystem.APi.Routes;

namespace UnifiedSystem.APi.Controllers.V2
{
    [ApiVersion("2.0")]
    [Route(ApiRoutes.BaseRoute)]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Test API V2 is working!");
        }
    }
}
