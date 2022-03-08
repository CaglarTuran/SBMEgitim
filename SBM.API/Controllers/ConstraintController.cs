using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SBM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConstraintController : ControllerBase
    {
        [HttpGet("{name:minlength(5)}")]
        public IActionResult Get(string name)
        {
            return Ok(name);
        }
    }
}