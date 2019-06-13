using System;
using FA.Common.Messages;
using Newtonsoft.Json;

namespace FA.Api.Messages.Commands.Customers
{
    [MessageNamespace("customers")]
    public class ClearCart : ICommand
    {
        public Guid CustomerId { get; }

        [JsonConstructor]
        public ClearCart(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}