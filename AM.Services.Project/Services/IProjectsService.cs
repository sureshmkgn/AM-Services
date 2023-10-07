using AM.Common.Types;
using AM.Services.Projects.Dto;
using AM.Services.Projects.Queries;
using RestEase;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AM.Services.Projects.Services
{
    [SerializationMethods(Query = QuerySerializationMethod.Serialized)]
    public interface IProjectsService
    {
        [AllowAnyStatusCode]
        [Get("projects/{id}")]
        Task<ProjectDto> GetAsync([Path] Guid id);

        [AllowAnyStatusCode]
        [Get("projects")]
        Task<PagedResult<ProjectDto>> BrowseAsync([Query] BrowseProjects query);
    }
}
