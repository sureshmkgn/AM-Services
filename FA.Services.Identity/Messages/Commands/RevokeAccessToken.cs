using System;
using FA.Common.Messages;
using Newtonsoft.Json;

namespace FA.Services.Identity.Messages.Commands
{
    public class RevokeAccessToken : ICommand
    {
        public Guid UserId { get; }
        public string Token { get; }

        [JsonConstructor]
        public RevokeAccessToken(Guid userId, string token)
        {
            UserId = userId;
            Token = token;
        }
    }
}