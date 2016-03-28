using Core.Data;

namespace Core.Jobs
{
    public class PaintingJob : BaseLemmingJob
    {
        protected override void DoWork()
        {
            System.Diagnostics.Debug.WriteLine($"Painting some walls...");
            UpdateDashboard<Painting>();
        }
    }
}
