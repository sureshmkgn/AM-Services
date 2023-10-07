using System;
using System.Threading.Tasks;
using AM.Common.Mongo;
using AM.Services.Projects.Queries;
using AM.Services.Projects.Domain.Projects;
using AM.Common.Types;
using AM.Services.Projects.Repositories;
using AM.Services.Projects.Dto;

namespace AM.Services.Projects.Repositories
{
    public class ProjectsRepository : IProjectsRepository
    {
        private readonly IMongoRepository<Project> _repository;

        public ProjectsRepository(IMongoRepository<Project> repository)
        {
            _repository = repository;
        }

        public async Task<Project> GetAsync(Guid id)
            => await _repository.GetAsync(id);

        public async Task<bool> ExistsAsync(Guid id)
            => await _repository.ExistsAsync(p => p.Id == id);

        public async Task<bool> ExistsAsync(string name)
            => await _repository.ExistsAsync(p => p.Name == name.ToLowerInvariant());

        public async Task<PagedResult<Project>> BrowseAsync(BrowseProjects query)
        {
            return await _repository.BrowseAsync(p =>
                        p.StartDate >= query.ProjectStartDate && p.EndDate <= query.ProjectEndDate, query);
        }

        public async Task AddAsync(Project product)
            => await _repository.AddAsync(product);

        public async Task UpdateAsync(Project product)
            => await _repository.UpdateAsync(product);

        public async Task DeleteAsync(Guid id)
            => await _repository.DeleteAsync(id);

       
    }
}