using AM.Common.Handlers;
using AM.Common.RabbitMq;
using AM.Common.Types;
using AM.Services.Products.Messages.Commands;
using AM.Services.Products.Messages.Events;
using AM.Services.Products.Repositories;
using System.Threading.Tasks;

namespace AM.Services.Projects.Handlers
{ 
    public sealed class DeleteProductHandler : ICommandHandler<DeleteProduct>
    {
        private readonly IProjectsRepository _productsRepository;
        private readonly IBusPublisher _busPublisher;

        public DeleteProductHandler(
            IProjectsRepository productsRepository,
            IBusPublisher busPublisher)
        {
            _productsRepository = productsRepository;
            _busPublisher = busPublisher;
        }

        public async Task HandleAsync(DeleteProduct command, ICorrelationContext context)
        {
            if (!await _productsRepository.ExistsAsync(command.Id))
            {
                throw new DShopException("product_not_found",
                    $"Product with id: '{command.Id}' was not found.");
            }

            await _productsRepository.DeleteAsync(command.Id);
            await _busPublisher.PublishAsync(new ProductDeleted(command.Id), context);
        }
    }
}
