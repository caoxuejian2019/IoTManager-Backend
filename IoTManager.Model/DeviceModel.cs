using System;
using System.Collections.Generic;
using System.Text;

namespace IoTManager.Model
{
    public sealed class DeviceModel
    {
        public int Id { get; set; }
        public String DeviceName { get; set; }
        public String HardwareDeviceId { get; set; }
        public String City { get; set; }
        public String Factory { get; set; }
        public String Workshop { get; set; }
        public String DeviceState { get; set; }
        public DateTime LastConnectionTime { get; set; }
        public String ImageUrl { get; set; }
        public int GatewayId { get; set; }
        public String Mac { get; set; }
        public String DeviceType { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public String Remark { get; set; }
    }
}
