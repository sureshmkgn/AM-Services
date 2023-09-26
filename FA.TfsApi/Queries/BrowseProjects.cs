using System;

namespace FA.Api.Queries
{
    public class BrowseProjects : PagedQuery
    {
        public DateTime ProjectStartDate{ get; set; }
        public DateTime ProjectEndDate { get; set; }

        public BrowseProjects()
        {
            ProjectEndDate = DateTime.Now ;
        }
    }
}