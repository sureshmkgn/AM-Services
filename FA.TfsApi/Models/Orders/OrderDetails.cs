using System.Collections.Generic;

namespace FA.Api.Models.Orders
{
    public class OrderDetails : Order
    {
        public OrderCustomer Customer { get; set; }
        public IEnumerable<OrderItem> Items { get; set; }
    }
}
