using AM.Services.Projects.Dto;
using AM.Common.Types;

using System;


namespace DShop.Services.Products.Queries
{
    public class GetProduct : IQuery<ProjectDto>
    {
        public Guid Id { get; set; }
    }
}
