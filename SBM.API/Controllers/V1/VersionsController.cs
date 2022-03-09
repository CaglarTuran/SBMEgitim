using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SBM.API.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    [Route("api/versions/[action]")]
    [ApiController]
    public class VersionsController : ControllerBase
    {
        [MapToApiVersion("1.0")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("version 1.0");
        }

        [MapToApiVersion("1.1")]
        [HttpGet]
        public IActionResult Get2()
        {
            return Ok("version 1.1");
        }
    }
}