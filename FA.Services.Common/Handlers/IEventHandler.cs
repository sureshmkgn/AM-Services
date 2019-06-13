using FA.Common.RabbitMq;
using FA.Common.Messages;
using System.Threading.Tasks;

namespace FA.Common.Handlers
{
    public interface IEventHandler<in TEvent> where TEvent : IEvent
    {
        Task HandleAsync(TEvent @event, ICorrelationContext context);
    }
}