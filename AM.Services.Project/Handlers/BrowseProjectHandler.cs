using AM.Services.Projects.Queries;
using AM.Common.Handlers;
using AM.Common.Types;
using AM.Services.Projects.Domain.Projects;

using System.Linq;
using System.Threading.Tasks;
using AM.Services.Projects.Dto;
using AM.Services.Projects.Repositories;

namespace AM.Services.Projects.Handlers
{
    public sealed class BrowseProjectsHandler : IQueryHandler<BrowseProjects, PagedResult<ProjectDto>>
    {
        private readonly IProjectsRepository _productsRepository;

        public BrowseProjectsHandler(IProjectsRepository prodjectRepository)
            => _productsRepository = prodjectRepository;

        public async Task<PagedResult<ProjectDto>> HandleAsync(BrowseProjects query)
        {
            var pagedResult = await _productsRepository.BrowseAsync(query);
            var products = pagedResult.Items.Select(p => new ProjectDto
            {
                Name = p.Name,
                Description = p.Description,
                Template = p.Template,
                Client = p.Client
            })
            .ToList();

            return PagedResult<ProjectDto>.From(pagedResult, products);
        }

      
    }
}
