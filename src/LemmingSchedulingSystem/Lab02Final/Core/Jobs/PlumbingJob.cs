using Core.Data;

namespace Core.Jobs
{
    public class PlumbingJob : BaseLemmingJob
    {
        protected override void DoWork()
        {
            System.Diagnostics.Debug.WriteLine($"Unclogging some toilets...");
            UpdateDashboard<Plumbing>();
        }
    }
}
