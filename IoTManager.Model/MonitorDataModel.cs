using System;
using System.Collections.Generic;
using System.Text;

namespace IoTManager.Model
{
    public class MonitorDataModel
    {
        public string GatewayId { get; set; }
        public string DeviceId { get; set; }
        public string TypeName { get; set; }
        public string Type { get; set; }
        public string Unit { get; set; }
        public string Value { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
