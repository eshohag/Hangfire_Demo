using Hangfire.Annotations;
using Hangfire.Dashboard;

namespace Hangfire_Authorization_Demo
{
    public class HangfireCustomBasicAuthenticationFilter : IDashboardAuthorizationFilter
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }

        public bool Authorize([NotNull] DashboardContext context)
        {
            if (UserName == "admin" && Password == "1234")
                return true;
            return false;
        }
    }
}
