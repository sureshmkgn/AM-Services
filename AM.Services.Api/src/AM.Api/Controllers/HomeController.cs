using AM.Common.RabbitMq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenTracing;
using RawRabbit.Operations.Publish.Middleware;

namespace AM.Api.Controllers
{
    [Route("")]
    public class HomeController : BaseController
    {
        public HomeController(IBusPublisher busPublisher, ITracer tracer) : base(busPublisher, tracer)
        {
        }

        [HttpGet]
        [AllowAnonymous]
        // public IActionResult Get() => Ok("AM API");
        public IActionResult Get() =>  Redirect("~/docs");
    }
}