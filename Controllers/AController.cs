using Microsoft.AspNetCore.Mvc;

namespace Client.With.Proxy.Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetPublicIP()
        {
            return Ok("The controller A, this publish ip is N/A");
        }
    }
}
