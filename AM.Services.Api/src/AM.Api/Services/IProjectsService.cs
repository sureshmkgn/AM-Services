using AM.Common.Types;
using AM.Api.Models.Projects;
using AM.Api.Queries;
using RestEase;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AM.Api.Models.Projects;

namespace AM.Api.Services
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
