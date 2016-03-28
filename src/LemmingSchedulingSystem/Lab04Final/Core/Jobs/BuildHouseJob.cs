using Core.Data;

namespace Core.Jobs
{
    public class BuildHouseJob : BaseLemmingJob
    {
        protected override void DoWork()
        {
            Logger.Info($"Building a house...");
            UpdateDashboard<BuildHouse>();
        }
    }
}