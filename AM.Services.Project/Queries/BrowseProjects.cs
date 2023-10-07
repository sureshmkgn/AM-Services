using AM.Common.Types;
using AM.Services.Projects.Dto;
using System;

namespace AM.Services.Projects.Queries
{
    public class BrowseProjects : PagedQueryBase, IQuery<PagedResult<ProjectDto>>
    {
        public DateTime ProjectStartDate{ get; set; }
        public DateTime ProjectEndDate { get; set; }

        public BrowseProjects()
        {
            ProjectEndDate = DateTime.Now ;
        }
    }
}