using IoTManager.Tcp.MonitorDataSync.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace IoTManager.Tcp.MonitorDataSync.Services
{
    public sealed class HumidResolveService
    {
        public List<MonitorDataContract> ResolveMonitorData(string content)
        {
            return new List<MonitorDataContract>();
            //A5 00 EA 00 0F 13 59 01 79 09 00 00 00 00 5A 0D 0A
        }

        public void ResolveGateway(string content)
        {

        }
    }
}
