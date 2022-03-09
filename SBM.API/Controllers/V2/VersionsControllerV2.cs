using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SBM.API.Controllers.V2
{
    [ApiVersion("2.0")]
    [Route("api/versions")]
    [ApiController]
    public class VersionsControllerV2 : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("version 2.0");
        }
    }
}