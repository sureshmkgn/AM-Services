using AM.Common.Handlers;
using AM.Services.Projects.Dto;
using AM.Services.Projects.Repositories;
using DShop.Services.Products.Queries;
using System.Threading.Tasks;

namespace AM.Services.Projects.Handlers
{
    public sealed class GetProjectHandler : IQueryHandler<GetProduct, ProjectDto>
    {
        private readonly IProjectsRepository _productsRepository;

        public GetProjectHandler(IProjectsRepository productsRepository)
            => _productsRepository = productsRepository;

        public async Task<ProjectDto> HandleAsync(GetProduct query)
        {
            var product = await _productsRepository.GetAsync(query.Id);

            return product == null ? null : new ProjectDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
               
            };
        }
    }
}
