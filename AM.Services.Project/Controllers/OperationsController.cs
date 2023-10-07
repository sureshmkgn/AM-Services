using AM.Services.Projects.Services;
using AM.Common.RabbitMq;
using AM.Services.Projects.Messages.Commands;
using AM.Services.Projects.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AM.Services.Projects.Controllers
{
    [AllowAnonymous]
    public class OperationsController : BaseController
    {
        private readonly IOperationsService _operationsService;

        public OperationsController(IBusPublisher busPublisher,
            IOperationsService operationsService) : base(busPublisher)
        {
            _operationsService = operationsService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
            => Single(await _operationsService.GetAsync(id));
    }
}
