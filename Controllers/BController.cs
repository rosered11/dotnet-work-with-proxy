using Microsoft.AspNetCore.Mvc;

namespace Client.With.Proxy.Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetPublicIP()
        {
            return Ok("The controller B, this publish ip is N/A");
        }
    }
}
