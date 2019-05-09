using System;
using System.Collections.Generic;
using System.Text;

namespace IoTManager.Model
{
    public sealed class DeviceModel
    {
        public int Id { get; set; }
        public string DeviceName { get; set; }
        public string HardwareDeviceID { get; set; }
        public int City { get; set; }
        public int Factory { get; set; }
        public int Workshop { get; set; }
        public int DeviceState { get; set; }
        public DateTime LastConnectionTime { get; set; }
        public string ImageUrl { get; set; }
        public int GatewayID { get; set; }
        public string Mac { get; set; }
        public string DeviceType { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public string Remark { get; set; }
        public string Department { get; set; }
    }
}
