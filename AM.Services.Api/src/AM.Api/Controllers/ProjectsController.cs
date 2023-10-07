using AM.Api.Services;
using AM.Common.RabbitMq;
using AM.Api.Messages.Commands;
using AM.Api.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestEase;
using System;
using System.Threading.Tasks;
using AM.Common.Mvc;
using AM.Api.Framework;
using AM.Api.Messages.Commands.Projects;
using OpenTracing;

namespace AM.Api.Controllers
{
   // [AdminAuth]
    public class ProjectsController : BaseController
    {
        private readonly IProjectsService _productsService;

        public ProjectsController(IBusPublisher busPublisher, ITracer tracer, 
            IProjectsService productsService) : base(busPublisher, tracer)
        {
            _productsService = productsService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get([FromQuery] BrowseProjects query)
            => Collection(await _productsService.BrowseAsync(query));

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(Guid id)
            => Single(await _productsService.GetAsync(id));

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post(CreateProject command)
            => await SendAsync(command.BindId(c => c.Id), 
                resourceId: command.Id, resource: "projects");

        [HttpPut("{id}")]
        public async Task<IActionResult>  Put(Guid id, UpdateProject command)
            => await SendAsync(command.Bind(c => c.Id, id), 
                resourceId: command.Id, resource: "projects");

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
            => await SendAsync(new DeleteProject(id));
    }
}
