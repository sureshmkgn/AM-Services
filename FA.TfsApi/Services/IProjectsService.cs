using FA.Common.Types;
using FA.Api.Domain.Products;
using FA.Api.Queries;
using RestEase;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FA.Api.Services
{
    [SerializationMethods(Query = QuerySerializationMethod.Serialized)]
    public interface IProjectsService
    {
        [AllowAnyStatusCode]
        [Get("projects/{id}")]
        Task<Project> GetAsync([Path] Guid id);

        [AllowAnyStatusCode]
        [Get("projects")]
        Task<PagedResult<Project>> BrowseAsync([Query] BrowseProjects query);
    }
}
