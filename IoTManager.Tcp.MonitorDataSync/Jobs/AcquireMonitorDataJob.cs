using Quartz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IoTManager.Tcp.MonitorDataSync.Jobs
{
    public sealed class AcquireMonitorDataJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            return Task.Run(() =>
            {
                Console.Out.WriteLine("AcquireMonitorDataJob running .... out");
                Console.WriteLine("AcquireMonitorDataJob running ....");
            });
            //throw new NotImplementedException();
        }
    }
}
