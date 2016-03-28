using Core.Data;

namespace Core.Jobs
{
    public class SayHelloJob : BaseLemmingJob
    {
        protected override void DoWork()
        {
            System.Diagnostics.Debug.WriteLine($"Hello!");
            UpdateDashboard<SayHello>();
        }
    }
}
