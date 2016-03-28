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

            var serverOptions = new BackgroundJobServerOptions()
            {
                WorkerCount = Environment.ProcessorCount*5, // This is the amount of threads.  Default is 10;
                Queues = new[] {QueuePriority.HighPriority, QueuePriority.Default}
            };

            var recurringOptions = new BackgroundJobServerOptions()
            {
                WorkerCount = 1,
                Queues = new[] {QueuePriority.Recurring}
            };

            app.UseHangfireDashboard(); // This will configure the current application to run the Hangfire Dashboard with the configured connection.
            app.UseHangfireServer(serverOptions);  // This will configure the current application to run the Hangfire Server with the configured connection.
            app.UseHangfireServer(recurringOptions);

            ConfigureRecurringJobs();
        }

        private static void ConfigureRecurringJobs()
        {
            SetupRecurringJob<BuildHouseJob>(j => j.BuildHouseRecurring());
        }

        private static void SetupRecurringJob<T>(Expression<Action<T>> job) where T : BaseLemmingJob
        {
            RecurringJob.AddOrUpdate(job, Cron.Minutely);
        }
    }
}