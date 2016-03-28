using Core.Data;

namespace Core.Jobs
{
    public class BuildHouseJob : BaseLemmingJob
    {
        protected override void DoWork()
        {
            System.Diagnostics.Debug.WriteLine($"Building a house...");
            UpdateDashboard<BuildHouse>();
        }
    }
}
