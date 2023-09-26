using System;
using FA.Common.Messages;
using Newtonsoft.Json;

namespace FA.Api.Messages.Commands.Products
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