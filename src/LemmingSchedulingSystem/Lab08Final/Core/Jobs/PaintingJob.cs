using Core.Data;

namespace Core.Jobs
{
    public class PaintingJob : BaseLemmingJob
    {
        protected override void DoWork()
        {
            Logger.Info($"Painting some walls...");
            UpdateDashboard<Painting>();
        }
    }
}
