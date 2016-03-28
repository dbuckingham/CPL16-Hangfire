using Core.Data;

namespace Core.Jobs
{
    public class WeldingJob : BaseLemmingJob
    {
        protected override void DoWork()
        {
            System.Diagnostics.Debug.WriteLine($"Welding some metal...");
            UpdateDashboard<Welding>();
        }
    }
}
