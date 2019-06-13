using Microsoft.AspNetCore.Mvc;

namespace FA.Services.Identity.Controllers
{
    [Route("")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok("FA Identity Service");
    }
}