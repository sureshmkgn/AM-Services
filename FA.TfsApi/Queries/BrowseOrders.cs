using System;

namespace FA.Api.Queries
{
    public class BrowseOrders : PagedQuery
    {
        public Guid CustomerId { get; set; }
    }
}
