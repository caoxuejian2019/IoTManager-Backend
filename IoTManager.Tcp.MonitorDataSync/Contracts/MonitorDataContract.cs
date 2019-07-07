using System;
using System.Collections.Generic;
using System.Text;

namespace IoTManager.Tcp.MonitorDataSync.Contracts
{
    public sealed class MonitorDataContract
    {
        public string Id { get; set; }
        public string GatewayId { get; set; }
        public string DeviceId { get; set; }
        public string DeviceName { get; set; }
        public string DeviceType { get; set; }
        public string MonitorDataId { get; set; }
        public string MonitorDataName { get; set; }
        public string MonitorDataUnit { get; set; }
        public string MonitorDataType { get; set; }
        public string MonitorDataValue { get; set; }
        public DateTime Timestamp { get; set; }
        public bool IsScan { get; set; }
    }
}
