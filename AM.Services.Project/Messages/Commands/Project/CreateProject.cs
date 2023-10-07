using System;
using AM.Common.Messages;
using Newtonsoft.Json;

namespace AM.Services.Projects.Messages.Commands.Products
{
	[MessageNamespace("projects")]
	public class CreateProject : ICommand
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
		public CreateProject(Guid id, string name,
			string description, string vendor,
			string template ,string  client , DateTime startDate , DateTime endDate, Boolean invitationStatus)
		{
			Id = id;
			Name = name;
			Description = description;
			Template = template;
			Client = client;
			StartDate = startDate;
			EndDate = endDate;
			InvitationStatus = invitationStatus;

		}
	}
}