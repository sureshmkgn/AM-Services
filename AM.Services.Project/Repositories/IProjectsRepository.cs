using AM.Common.Types;
using AM.Services.Projects.Domain.Projects;
using AM.Services.Projects.Dto;
using AM.Services.Projects.Queries;
using System;
using System.Threading.Tasks;

namespace AM.Services.Projects.Repositories
{
    public interface IProjectsRepository
    {
        Task<Project> GetAsync(Guid id);
        Task<bool> ExistsAsync(Guid id);
        Task<bool> ExistsAsync(string name);
        Task<PagedResult<Project>> BrowseAsync(BrowseProjects query);
        Task AddAsync(Project project);
        Task UpdateAsync(Project project);
        Task DeleteAsync(Guid id);
    }
}