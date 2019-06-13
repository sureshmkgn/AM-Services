using System;
using FA.Common.Messages;
using Newtonsoft.Json;

namespace FA.Services.Identity.Messages.Events
{
    public class AccessTokenRefreshed : IEvent
    {
        public Guid UserId { get; }

        [JsonConstructor]
        public AccessTokenRefreshed(Guid userId)
        {
            UserId = userId;
        }
    }
}