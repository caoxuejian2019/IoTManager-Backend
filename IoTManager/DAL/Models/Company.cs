using System;

namespace IoTManager.DAL.Models
{
    public class Company
    {
        public int? id { get; set; }
        public String companyName { get; set; }
        public String phoneNumber { get; set; }
        public String address { get; set; }
        public String remark { get; set; }
        public DateTime? createTime { get; set; }
        public DateTime? updateTime { get; set; }
    }
}