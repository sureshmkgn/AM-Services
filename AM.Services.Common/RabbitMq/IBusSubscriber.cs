using System;
using AM.Common.Messages;
using AM.Common.Types;

namespace AM.Common.RabbitMq
{
    public interface IBusSubscriber
    {
        IBusSubscriber SubscribeCommand<TCommand>(string @namespace = null, string queueName = null,
            Func<TCommand, AMException, IRejectedEvent> onError = null)
            where TCommand : ICommand;

        IBusSubscriber SubscribeEvent<TEvent>(string @namespace = null, string queueName = null,
            Func<TEvent, AMException, IRejectedEvent> onError = null) 
            where TEvent : IEvent;
    }
}
