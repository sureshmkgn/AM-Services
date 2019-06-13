using System;
using FA.Common.Messages;
using Newtonsoft.Json;

namespace FA.Api.Messages.Commands.Orders
{
    [MessageNamespace("orders")]
    public class CompleteOrder : ICommand
    {
        public Guid Id { get; }
        public Guid CustomerId { get; }

        [JsonConstructor]
        public CompleteOrder(Guid id, Guid customerId)
        {
            Id = id;
            CustomerId = customerId;
        }
    }
}
