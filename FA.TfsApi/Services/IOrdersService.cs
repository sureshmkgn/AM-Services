using FA.Common.Types;
using FA.Api.Models.Orders;
using FA.Api.Queries;
using RestEase;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FA.Api.Services
{
    [SerializationMethods(Query = QuerySerializationMethod.Serialized)]
    public interface IOrdersService
    {
        [AllowAnyStatusCode]
        [Get("orders/{id}")]
        Task<OrderDetails> GetAsync([Path] Guid id);

        [AllowAnyStatusCode]
        [Get("customers/{customerId}/orders/{orderId}")]
        Task<OrderDetails> GetAsync([Path] Guid customerId, [Path] Guid orderId);

        [AllowAnyStatusCode]
        [Get("orders")]
        Task<PagedResult<Order>> BrowseAsync([Query] BrowseOrders query);
    }
}
