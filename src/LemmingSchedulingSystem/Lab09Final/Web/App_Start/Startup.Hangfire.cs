using Hangfire;
using Owin;
using Web.Security;

namespace Web
{
    public partial class Startup
    {
        public void ConfigureHangfire(IAppBuilder app)
        {
		    GlobalConfiguration.Configuration.UseSqlServerStorage("DefaultConnection").UseNLogLogProvider();

            app.UseHangfireDashboard("/hangfire", new DashboardOptions()
            {
                AuthorizationFilters = new[] { new HangfireDashboardAuthorizationFilter() }
            }); // This will configure the current application to run the Hangfire Dashboard with the configured connection.
        }
    }
}