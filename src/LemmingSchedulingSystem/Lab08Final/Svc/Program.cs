using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace Svc
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.UseNLog();

                x.SetDisplayName("CPL16-Hangfire Event Processing Host");
                x.SetServiceName("CPL16-HangfireEventProcessor");
                x.SetDescription("CPL16-Hangfire Event Processing Host");
                x.RunAsLocalSystem();

                x.StartAutomatically();
                x.EnableServiceRecovery(r =>
                {
                    r.RestartService(1);
                    r.SetResetPeriod(1);
                });

                x.Service<EventProcessor>(s =>
                {
                    s.ConstructUsing(name => new EventProcessor());

                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
            });
        }
    }
}
