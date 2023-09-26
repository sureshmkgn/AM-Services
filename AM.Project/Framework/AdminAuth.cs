using AM.Common.Authentication;

namespace AM.Api.Framework
{
    public class AdminAuth : JwtAuthAttribute
    {
        public AdminAuth() : base("admin")
        {
        }
    }
}