using System;
using System.Collections.Generic;
using System.Text;

namespace IoTManager.Model
{
    public sealed class UserModel
    {
        public int Id { get; set; }
        public String UserName { get; set; }
        public String DisplayName { get; set; }
        public String Password { get; set; }
        public String Email { get; set; }
        public String PhoneNumber { get; set; }
        public String Remark { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
