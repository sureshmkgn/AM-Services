using FA.Common.RabbitMq;
using FA.Common.Messages;
using System.Threading.Tasks;

namespace FA.Common.Handlers
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task HandleAsync(TCommand command, ICorrelationContext context);
    }
}