using System;

namespace AM.Services.Projects.Dto
{
    public class ProjectDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Template { get; set; }
        public string Client { get; set; }
        
    }
}
