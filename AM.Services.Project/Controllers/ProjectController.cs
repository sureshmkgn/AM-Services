using AM.Services.Projects.Services;
using AM.Common.RabbitMq;
using AM.Services.Projects.Messages.Commands;
using AM.Services.Projects.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestEase;
using System;
using System.Threading.Tasks;
using AM.Common.Mvc;
using AM.Services.Projects.Framework;
using AM.Services.Projects.Messages.Commands.Products;

namespace AM.Services.Projects.Controllers
{
    //[AdminAuth]
    public class ProjectController : BaseController
    {
        private readonly IProjectsService _productsService;

        public ProjectController(IBusPublisher busPublisher, 
            IProjectsService productsService) : base(busPublisher)
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
                resourceId: command.Id, resource: "products");

        [HttpPut("{id}")]
        public async Task<IActionResult>  Put(Guid id, UpdateProject command)
            => await SendAsync(command.Bind(c => c.Id, id), 
                resourceId: command.Id, resource: "products");

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
            => await SendAsync(new DeleteProject(id));
    }
}
