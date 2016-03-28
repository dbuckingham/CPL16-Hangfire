using System;
using System.Linq;
using System.Threading;
using Core.Context;
using Core.Data;
using NLog;

namespace Core.Jobs
{
    public abstract class BaseLemmingJob
    {
        private readonly ApplicationDbContext _dbContext = new ApplicationDbContext();
        protected readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public void Run()
        {
            Logger.Info($"Running job of type {GetType().Name}.");
            SleepyTime();
            DoWork();
        }

        protected abstract void DoWork();

        protected void UpdateDashboard<T>() where T : BaseEntity, IDashboard, new()
        {
            _dbContext.Set<T>().Add(new T() {Created = DateTime.Now, Dashboard = _dbContext.Set<Dashboard>().FirstOrDefault() ?? new Dashboard() {Created = DateTime.Now}});
            _dbContext.SaveChanges();
        }
        
        // This helps us simulate a task taking a while to run
        private void SleepyTime()
        {
            var random = new Random();

            Thread.Sleep(random.Next(1000, 10000));
        }
    }
}
