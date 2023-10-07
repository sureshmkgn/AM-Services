using AM.Common.Authentication;

namespace AM.Services.Projects.Framework
{
    public class AdminAuth : JwtAuthAttribute
    {
        public AdminAuth() : base("admin")
        {
        }
    }
}