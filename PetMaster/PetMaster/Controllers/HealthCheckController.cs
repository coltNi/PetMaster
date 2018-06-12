using Microsoft.AspNetCore.Mvc;

namespace PetMaster.Controllers
{
    public class HealthCheckController : Controller
    {
        [HttpGet]
        public IActionResult HealthCheck()
        {
            return Ok("ok");
        }
    }
}