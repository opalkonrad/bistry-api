using Microsoft.AspNetCore.Mvc;

namespace BistryApi;

[Route("[controller]")]
[ApiController]
public class HeartbeatController : Controller
{
    [HttpGet]
    public ActionResult<string> Get()
    {
        return Ok($"Heartbeat - {DateTime.Now}");
    }
}
