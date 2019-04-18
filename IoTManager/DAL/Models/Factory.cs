using System;

namespace IoTManager.DAL.Models
{
    public class Factory
    {
        public int? id { get; set; }
        public String factoryName { get; set; }
        public String factoryPhoneNumber { get; set; }
        public String factoryAddress { get; set; }
        public String remark { get; set; }
        public DateTime? createTime { get; set; }
        public DateTime? updateTime { get; set; }
    }
}