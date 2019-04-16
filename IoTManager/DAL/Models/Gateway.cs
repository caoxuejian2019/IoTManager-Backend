using System;

namespace IoTManager.DAL.Models
{
    public class Gateway
    {
        public int? id { get; set; }
        public String hardwaregatewayid { get; set; }
        public String gatewayname { get; set; }
        public int? gatewaytype { get; set; }
        public int? city { get; set; }
        public int? factory { get; set; }
        public int? workshop { get; set; }
        public int? gatewaystate { get; set; }
        public DateTime lastconnectiontime { get; set; }
        public String imageurl { get; set; }
        public DateTime create_time { get; set; }
        public DateTime update_time { get; set; }
        public String remark { get; set; }
        public int? department { get; set; }
    }
}