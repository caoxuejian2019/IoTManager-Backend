using System;

namespace IoTManager.DAL.Models
{
    public class Role
    {
        public int id { get; set; }
        public String roleName { get; set; }
        public String remark { get; set; }
        public DateTime createTime { get; set; }
        public DateTime updateTime { get; set; }
    }
}