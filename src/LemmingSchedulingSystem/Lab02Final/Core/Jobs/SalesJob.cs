using Core.Data;

namespace Core.Jobs
{
    public class SalesJob : BaseLemmingJob
    {
        protected override void DoWork()
        {
            System.Diagnostics.Debug.WriteLine($"ABC...Always be closing...");
            UpdateDashboard<Sales>();           
        }
    }
}
