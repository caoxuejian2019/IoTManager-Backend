using System;

namespace IoTManager.DAL.Models
{
    public class User
    {
        public int id { get; set; }
        public String userName { get; set; }
        public String displayName { get; set; }
        public String password { get; set; }
        public String email { get; set; }
        public int company { get; set; }
        public String phoneNumber { get; set; }
        public DateTime createTime { get; set; }
        public DateTime updateTime { get; set; }
        public String remark { get; set; }
        public int department { get; set; }
    }
}