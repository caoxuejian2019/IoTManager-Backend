using System;
using System.Collections.Generic;
using System.Text;

namespace IoTManager.Tcp.MonitorDataSync.Configure
{
    public sealed class AppSetting
    {
        public List<Device> Devices { get; set; }
        public Gateway Gateway { get; set; }
    }

    public class Device
    {
        public string NodeAddress { get; set; }
    }

    public class Gateway
    {
        public string IPAddress { get; set; }
        public int Port { get; set; }
    }
}
