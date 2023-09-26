using System;
using AM.Common.Messages;
using Newtonsoft.Json;

namespace AM.Api.Messages.Commands.Products
{
	[MessageNamespace("prodjects")]
	public class CreateProject : ICommand
	{
        public Guid Id { get; }
        public string Name { get; }
        public string Description { get; }
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