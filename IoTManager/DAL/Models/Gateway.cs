using System;

namespace IoTManager.DAL.Models
{
    public class Gateway
    {
        public int id { get; set; }
        public String hardwareGatewayID { get; set; }
        public String gatewayName { get; set; }
        public int gatewayType { get; set; }
        public int city { get; set; }
        public int factory { get; set; }
        public int workshop { get; set; }
        public int gatewayState { get; set; }
        public DateTime lastConnectionTime { get; set; }
        public String imageUrl { get; set; }
        public DateTime createTime { get; set; }
        public DateTime updateTime { get; set; }
        public String remark { get; set; }
        public int department { get; set; }
    }
}