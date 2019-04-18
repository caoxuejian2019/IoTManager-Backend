using System;

namespace IoTManager.DAL.Models
{
    public class Department
    {
        public int? id { get; set; }
        public String path { get; set; }
        public String departmentName { get; set; }
        public String phoneNumber { get; set; }
        public String remark { get; set; }
        public DateTime? createTime { get; set; }
        public DateTime? updateTime { get; set; }
    }
}