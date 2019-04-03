using System;

namespace IoTManager.DAL.Models
{
    public class User
    {
        public int id { get; set; }
        public String username { get; set; }
        public String nickname { get; set; }
        public String password { get; set; }
        public String email { get; set; }
        public int? company { get; set; }
        public String phonenumber { get; set; }
        public DateTime create_time { get; set; }
        public DateTime update_time { get; set; }
        public String remark { get; set; }
        public int? department { get; set; }
    }
}