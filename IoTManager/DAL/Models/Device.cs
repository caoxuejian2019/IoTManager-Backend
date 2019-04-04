using System;

namespace IoTManager.DAL.Models
{
    public class Device
    {
        public int? id { get; set; }
        public String hardwaredeviceid { get; set; }
        public String devicename { get; set; }
        public int? city { get; set; }
        public int? factory { get; set; }
        public int? workshop { get; set; }
        public int? devicestate { get; set; }
        public DateTime lastconnectiontime { get; set; }
        public String imageurl { get; set; }
        public int? gatewayid { get; set; }
        public String mac { get; set; }
        public int? devicetype { get; set; }
        public DateTime create_time { get; set; }
        public DateTime update_time { get; set; }
        public String remark { get; set; }
        public int? department { get; set; }
    }
}