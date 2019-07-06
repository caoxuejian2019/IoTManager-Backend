using System;
using System.Collections.Generic;
using System.Text;

namespace IoTManager.Tcp.MonitorDataSync.Configure
{
    public sealed class DeviceSetting
    {
        public List<Device> Devices { get; set; }
    }

    public class Device
    {
        public string NodeAddress { get; set; }
    }
}
