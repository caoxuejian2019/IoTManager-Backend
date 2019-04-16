using System;

namespace IoTManager.DAL.Models
{
    public class Device
    {
        public int? id { get; set; }
        public String hardwareDeviceID { get; set; }
        public String deviceName { get; set; }
        public int? city { get; set; }
        public int? factory { get; set; }
        public int? workshop { get; set; }
        public int? deviceState { get; set; }
        public DateTime LastConnectionTime { get; set; }
        public String imageUrl { get; set; }
        public int? gatewayID { get; set; }
        public String mac { get; set; }
        public int? deviceType { get; set; }
        public DateTime createTime { get; set; }
        public DateTime updateTime { get; set; }
        public String remark { get; set; }
        public int? department { get; set; }
    }
}