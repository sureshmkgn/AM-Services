using System;
using FA.Common.Messages;
using FA.Common.Types;

namespace FA.Common.RabbitMq
{
    public interface IBusSubscriber
    {
        IBusSubscriber SubscribeCommand<TCommand>(string @namespace = null, string queueName = null,
            Func<TCommand, DShopException, IRejectedEvent> onError = null)
            where TCommand : ICommand;

        IBusSubscriber SubscribeEvent<TEvent>(string @namespace = null, string queueName = null,
            Func<TEvent, DShopException, IRejectedEvent> onError = null) 
            where TEvent : IEvent;
    }
}
