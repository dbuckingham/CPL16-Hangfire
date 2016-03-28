using Core.Data;

namespace Core.Jobs
{
    public class SayHelloJob : BaseLemmingJob
    {
        protected override void DoWork()
        {
            Logger.Debug($"Hello!");
            UpdateDashboard<SayHello>();
        }
    }
}
