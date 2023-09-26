using AM.Common.RabbitMq;
using AM.Common.Messages;
using System.Threading.Tasks;

namespace AM.Common.Handlers
{
    public interface IEventHandler<in TEvent> where TEvent : IEvent
    {
        Task HandleAsync(TEvent @event, ICorrelationContext context);
    }
}