using System;
using System.Linq.Expressions;
using Core.Constants;
using Core.Jobs;
using Hangfire;
using Owin;

namespace Web
{
    public partial class Startup
    {
        public void ConfigureHangfire(IAppBuilder app)
        {
		    GlobalConfiguration.Configuration.UseSqlServerStorage("DefaultConnection").UseNLogLogProvider();

            app.UseHangfireDashboard(); // This will configure the current application to run the Hangfire Dashboard with the configured connection.
        }
    }
}