using System;
using System.Threading.Tasks;
using AM.Common.Handlers;
using AM.Common.RabbitMq;
using AM.Services.Products.Messages.Commands;
using AM.Services.Products.Messages.Events;
using AM.Services.Products.Repositories;
using Microsoft.Extensions.Logging;

namespace AAM.Services.Projects.Handlers
{
    public class ReserveProductsHandler : ICommandHandler<ReserveProducts>
    {
        private readonly IBusPublisher _busPublisher;
        private readonly IProjectsRepository _productsRepository;
        private readonly ILogger<ReserveProductsHandler> _logger;

        public ReserveProductsHandler(IBusPublisher busPublisher,
            IProjectsRepository productsRepository,
            ILogger<ReserveProductsHandler> logger)
        {
            _busPublisher = busPublisher;
            _productsRepository = productsRepository;
            _logger = logger;
        }

        public async Task HandleAsync(ReserveProducts command, ICorrelationContext context)
        {
            foreach ((Guid productId, int quantity) in command.Products)
            {
                _logger.LogInformation($"Reserving a product: '{productId}' ({quantity})");
                var product = await _productsRepository.GetAsync(productId);
                if (product == null)
                {
                    _logger.LogInformation($"Product was not found: '{productId}' (can't reserve).");

                    continue;
                }

                product.SetQuantity(product.Quantity - quantity);
                await _productsRepository.UpdateAsync(product);
                _logger.LogInformation($"Reserved a product: '{productId}' ({quantity})");
            }

            await _busPublisher.PublishAsync(new ProductsReserved(command.OrderId,
                command.Products), context);
        }
    }
}