using System;
using AM.Common.Messages;
using Newtonsoft.Json;

namespace AM.Api.Messages.Commands.Products
{
    [MessageNamespace("projects")]
	public class DeleteProject : ICommand
	{
        public Guid Id { get; }

        [JsonConstructor]
        public DeleteProject(Guid id)
        {
            Id = id;
        }
	}
}