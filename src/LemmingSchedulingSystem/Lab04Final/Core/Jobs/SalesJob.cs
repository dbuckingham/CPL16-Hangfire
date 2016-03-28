using Core.Data;

namespace Core.Jobs
{
    public class SalesJob : BaseLemmingJob
    {
        protected override void DoWork()
        {
            Logger.Debug($"ABC...Always be closing...");
            UpdateDashboard<Sales>();           
        }
    }
}
