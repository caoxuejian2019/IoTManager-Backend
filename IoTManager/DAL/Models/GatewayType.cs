using System;

namespace IoTManager.DAL.Models
{
    public class GatewayType
    {
        public int? id { get; set; }
        public String gatewayTypeName { get; set; }
        public String remark { get; set; }
        public DateTime? createTime { get; set; }
        public DateTime? updateTime { get; set; }
    }
}