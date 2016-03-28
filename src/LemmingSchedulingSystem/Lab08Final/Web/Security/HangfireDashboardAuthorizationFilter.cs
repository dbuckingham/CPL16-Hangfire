using System.Collections.Generic;
using Hangfire.Dashboard;
using Microsoft.Owin;

namespace Web.Security
{
    public class HangfireDashboardAuthorizationFilter : IAuthorizationFilter
    {
        public bool Authorize(IDictionary<string, object> owinEnvironment)
        {
            //var context = new OwinContext(owinEnvironment);
            //var user = context.Authentication.User;

            //if (user?.Identity == null || !user.Identity.IsAuthenticated)
            //    return false;

            return true; // Consider adding in a custom check here for a specific user role in your application
        }
    }
}