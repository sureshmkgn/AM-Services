using System;

namespace AM.Api.Models.Projects
{
    public class Project
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Template { get; set; }
        public string Client { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Boolean InvitationStatus { get; set; }


    }
}