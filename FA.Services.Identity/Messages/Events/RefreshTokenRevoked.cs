using System;
using AM.Common.Messages;
using Newtonsoft.Json;

namespace AM.Services.Identity.Messages.Events
{
    public class RefreshTokenRevoked : IEvent
    {
        public Guid UserId { get; }

        [JsonConstructor]
        public RefreshTokenRevoked(Guid userId)
        {
            UserId = userId;
        }
    }
}