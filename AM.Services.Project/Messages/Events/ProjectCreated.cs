using System;
using AM.Common.Messages;
using Newtonsoft.Json;

namespace AM.Services.Products.Messages.Events
{
    public class ProjectCreated : IEvent
    {
        public Guid Id { get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Template { get; set; }
        public string Client { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Boolean InvitationStatus { get; set; }

        [JsonConstructor]
        public ProjectCreated(Guid id, string name,
            string description, 
            string template, string client, DateTime startDate, DateTime endDate, Boolean invitationStatus)
        {
            Id = id;
            Name = name;
            Description = description;
            Template = Template ;
            Client = client;
            StartDate = startDate;
            EndDate = endDate;
            InvitationStatus = invitationStatus;
                
            
        }
    }
}
