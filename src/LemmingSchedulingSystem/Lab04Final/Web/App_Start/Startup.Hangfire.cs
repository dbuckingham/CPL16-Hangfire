using System;
using System.Linq.Expressions;
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
            app.UseHangfireServer();  // This will configure the current application to run the Hangfire Server with the configured connection.

            ConfigureRecurringJobs();
        }

        private static void ConfigureRecurringJobs()
        {
            SetupRecurringJob<BuildHouseJob>(j => j.Run());
        }

        private static void SetupRecurringJob<T>(Expression<Action<T>> job) where T : BaseLemmingJob
        {
            RecurringJob.AddOrUpdate(job, Cron.Minutely);
        }
    }
}