using AM.Common.RabbitMq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AM.Api.Controllers
{
    [Route("")]
    public class HomeController : BaseController
    {
        public HomeController(IBusPublisher busPublisher) : base(busPublisher)
        {
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get() => Ok("FA TFS API");
    }
}