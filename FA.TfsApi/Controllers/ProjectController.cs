using FA.Api.Services;
using FA.Common.RabbitMq;
using FA.Api.Messages.Commands;
using FA.Api.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestEase;
using System;
using System.Threading.Tasks;
using FA.Common.Mvc;
using FA.Api.Framework;
using FA.Api.Messages.Commands.Products;

namespace FA.Api.Controllers
{
    [AdminAuth]
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
