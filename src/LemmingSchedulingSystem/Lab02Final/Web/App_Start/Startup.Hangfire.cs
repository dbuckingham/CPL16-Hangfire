using Hangfire;
using Owin;

namespace Web
{
    public partial class Startup
    {
        public void ConfigureHangfire(IAppBuilder app)
        {
		    GlobalConfiguration.Configuration.UseSqlServerStorage("DefaultConnection");

			app.UseHangfireDashboard(); // This will configure the current application to run the Hangfire Dashboard with the configured connection.
			app.UseHangfireServer();  // This will configure the current application to run the Hangfire Server with the configured connection.
        }
    }
}