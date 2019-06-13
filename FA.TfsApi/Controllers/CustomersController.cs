using FA.Api.Services;
using FA.Common.RabbitMq;
using FA.Api.Messages.Commands;
using FA.Api.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using FA.Common.Mvc;
using FA.Api.Framework;
using FA.Api.Messages.Commands.Customers;

namespace FA.Api.Controllers
{
    public class CustomersController : BaseController
    {
        private readonly ICustomersService _customersService;

        public CustomersController(IBusPublisher busPublisher,
            ICustomersService customersService) : base(busPublisher)
        {
            _customersService = customersService;
        }

        [HttpGet]
        [AdminAuth]
        public async Task<IActionResult> Get([FromQuery] BrowseCustomers query)
            => Collection(await _customersService.BrowseAsync(query));

        [HttpGet("{id}")]
        [AdminAuth]
        public async Task<IActionResult> Get(Guid id)
            => Single(await _customersService.GetAsync(id), x => x.Id == UserId || IsAdmin);

        [HttpPost]
        public async Task<IActionResult> Post(CreateCustomer command)
            => await SendAsync(command.Bind(c => c.Id, UserId), 
                resourceId: command.Id, resource: "customers");
    }
}
