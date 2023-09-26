using AM.Common.RabbitMq;
using AM.Common.Messages;
using System.Threading.Tasks;

namespace AM.Common.Handlers
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task HandleAsync(TCommand command, ICorrelationContext context);
    }
}