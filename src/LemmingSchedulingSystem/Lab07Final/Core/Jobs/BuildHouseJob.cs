using Core.Constants;
using Core.Data;
using Hangfire;

namespace Core.Jobs
{
    public class BuildHouseJob : BaseLemmingJob
    {
        protected override void DoWork()
        {
            Logger.Info($"Building a house...");
            UpdateDashboard<BuildHouse>();
        }

        public void BuildHouseWithFriend()
        {
            BuildHouseWithFriendWithName("Default");
        }

        [Queue(QueuePriority.Recurring)]
        public void BuildHouseRecurring(IJobCancellationToken cancellationToken)
        {
            for (var i = 0; i < 10; i++)
            {
                cancellationToken.ThrowIfCancellationRequested();

                SleepyTime();
            }

            DoWork();
        }

        [Queue(QueuePriority.HighPriority)]
        public void BuildHouseWithFriendWithName(string friendName)
        {
            Logger.Info($"Building a house with my friend {friendName}!");
            UpdateDashboard<BuildHouse>();
        }
    }
}
