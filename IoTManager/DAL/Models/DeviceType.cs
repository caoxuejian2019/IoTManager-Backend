using System;

namespace IoTManager.DAL.Models
{
    public class DeviceType
    {
        public int id { get; set; }
        public String deviceTypeName { get; set; }
        public String remark { get; set; }
        public DateTime createTime { get; set; }
        public DateTime updateTime { get; set; }
    }
}