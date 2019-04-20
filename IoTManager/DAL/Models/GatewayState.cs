using System;

namespace IoTManager.DAL.Models
{
    public class GatewayState
    {
        public int id { get; set; }
        public String stateName { get; set; }
        public String remark { get; set; }
        public DateTime createTime { get; set; }
        public DateTime updateTime { get; set; }
    }
}