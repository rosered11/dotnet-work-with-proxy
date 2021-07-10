using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Client.With.Proxy.Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetPublicIP()
        {
            string forwardIp = HttpContext.Request.Headers["X-Forwarded-For"];
            string forwardProto = HttpContext.Request.Headers["X-Forwarded-Proto"];
            string publicIp = forwardIp?.Split(new char[] { ',' }).FirstOrDefault() ?? "N/A";
            return Ok($"[Controller A] proto: {forwardProto}, publicIp: {publicIp}, url: {Request.GetDisplayUrl()}");
        }
    }
}
