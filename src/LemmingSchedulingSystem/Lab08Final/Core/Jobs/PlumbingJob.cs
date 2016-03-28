using Core.Data;

namespace Core.Jobs
{
    public class PlumbingJob : BaseLemmingJob
    {
        protected override void DoWork()
        {
            Logger.Info($"Unclogging some toilets...");
            UpdateDashboard<Plumbing>();
        }
    }
}
