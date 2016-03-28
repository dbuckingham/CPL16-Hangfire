using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Constants;
using Core.Jobs;
using Hangfire;

namespace Svc
{
    public class EventProcessor
    {
        private readonly Stack<BackgroundJobServer> _backgroundJobServers;

        public EventProcessor()
        {
            _backgroundJobServers = new Stack<BackgroundJobServer>();
        }

        public void Start()
        {
            Core.Configuration.Bootstrap.Start();
            GlobalConfiguration.Configuration.UseSqlServerStorage("DefaultConnection").UseNLogLogProvider();

            var serverOptions = new BackgroundJobServerOptions()
            {
                WorkerCount = Environment.ProcessorCount * 5, // This is the amount of threads.  Default is 10;
                Queues = new[] { QueuePriority.HighPriority, QueuePriority.Default }
            };

            var recurringOptions = new BackgroundJobServerOptions()
            {
                WorkerCount = 1,
                Queues = new[] { QueuePriority.Recurring }
            };

            _backgroundJobServers.Push(new BackgroundJobServer(serverOptions));
            _backgroundJobServers.Push(new BackgroundJobServer(recurringOptions));

            ConfigureRecurringJobs();
        }

        public void Stop()
        {
            while (_backgroundJobServers.Count > 0)
                _backgroundJobServers.Pop().Dispose();
        }

        private static void ConfigureRecurringJobs()
        {
            SetupRecurringJob<BuildHouseJob>(j => j.BuildHouseRecurring(JobCancellationToken.Null));
        }

        private static void SetupRecurringJob<T>(Expression<Action<T>> job) where T : BaseLemmingJob
        {
            RecurringJob.AddOrUpdate(job, Cron.Minutely);
        }
    }
}
