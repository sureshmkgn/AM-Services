using AM.Common.Messages;
using Newtonsoft.Json;
using System;

namespace AM.Services.Projects.Messages.Events
{
    public class CreateProductRejected : IRejectedEvent
    {
        public Guid Id { get; }
        public string Reason { get; }
        public string Code { get; }

        [JsonConstructor]
        public CreateProductRejected(Guid id, string reason, string code)
        {
            Id = id;
            Reason = reason;
            Code = code;
        }
    }
}
