using AM.Common.Handlers;
using AM.Common.RabbitMq;
using AM.Services.Projects.Messages.Commands.Products;
using AM.Services.Products.Messages.Events;

using System.Threading.Tasks;
using AM.Common.Types;
using AM.Services.Projects.Domain.Projects;
using AM.Services.Projects.Repositories;

namespace AM.Services.Projects.Handlers
{
    public sealed class CreateProjectHandler : ICommandHandler<CreateProject>
    {
        private readonly IProjectsRepository _productsRepository;
        private readonly IBusPublisher _busPublisher;

        public CreateProjectHandler(
            IProjectsRepository productsRepository,
            IBusPublisher busPublisher)
        {
            _productsRepository = productsRepository;
            _busPublisher = busPublisher;
        }

        public async Task HandleAsync(CreateProject command, ICorrelationContext context)
        {
            if (command.Client == null)
            {
                throw new AMException("Invalid_Client",
                    "Client is required for construction process");
            }

            if (await _productsRepository.ExistsAsync(command.Name))
            {
                throw new AMException("product_already_exists",
                    $"Product: '{command.Name}' already exists.");
            }

            var _project = new Project(command.Id, command.Name,
                command.Description, command.Template ,command.Client,command.StartDate,command.EndDate,command.InvitationStatus);

            await _productsRepository.AddAsync(_project);

            await _busPublisher.PublishAsync(new ProjectCreated(command.Id, command.Name,
                command.Description, command.Template, command.Client,command.StartDate,command.EndDate ,command.InvitationStatus), context);
        }
    }
}
