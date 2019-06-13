using FA.Common.Types;
using FA.Api.Models.Products;
using FA.Api.Queries;
using RestEase;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FA.Api.Services
{
    [SerializationMethods(Query = QuerySerializationMethod.Serialized)]
    public interface IProductsService
    {
        [AllowAnyStatusCode]
        [Get("products/{id}")]
        Task<Product> GetAsync([Path] Guid id);

        [AllowAnyStatusCode]
        [Get("products")]
        Task<PagedResult<Product>> BrowseAsync([Query] BrowseProducts query);
    }
}
