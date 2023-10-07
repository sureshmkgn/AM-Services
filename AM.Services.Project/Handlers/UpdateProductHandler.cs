using AM.Common.Handlers;
using AM.Common.RabbitMq;
using AM.Common.Types;
using AM.Services.Products.Messages.Commands;
using AM.Services.Products.Messages.Events;
using AM.Services.Products.Repositories;
using System.Threading.Tasks;

namespace AM.Services.Projects.Handlers
{
    public sealed class UpdateProductHandler : ICommandHandler<UpdateProduct>
    {
        private readonly IProjectsRepository _productsRepository;
        private readonly IBusPublisher _busPublisher;

        public UpdateProductHandler(
            IProjectsRepository productsRepository,
            IBusPublisher busPublisher)
        {
            _productsRepository = productsRepository;
            _busPublisher = busPublisher;
        }

        public async Task HandleAsync(UpdateProduct command, ICorrelationContext context)
        {
            var product = await _productsRepository.GetAsync(command.Id);
            if (product == null)
            {
                throw new DShopException("product_not_found",
                    $"Product with id: '{command.Id}' was not found.");
            }

            product.SetName(command.Name);
            product.SetDescription(command.Description);
            product.SetVendor(command.Vendor);
            product.SetPrice(command.Price);
            product.SetQuantity(command.Quantity);
            await _productsRepository.UpdateAsync(product);
            await _busPublisher.PublishAsync(new ProductUpdated(command.Id, command.Name,
                command.Description, command.Vendor, command.Price, command.Quantity), context);
        }
    }
}
