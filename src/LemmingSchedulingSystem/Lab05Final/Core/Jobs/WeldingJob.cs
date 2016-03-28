using Core.Data;

namespace Core.Jobs
{
    public class WeldingJob : BaseLemmingJob
    {
        protected override void DoWork()
        {
            Logger.Debug($"Welding some metal...");
            UpdateDashboard<Welding>();
        }
    }
}
