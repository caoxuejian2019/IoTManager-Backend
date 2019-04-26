using System;
using IoTManager.DAL.Models;

namespace IoTManager.API.Formalizers
{
    public class UserFormalizer
    {
        public UserFormalizer()
        {
            this.id = 0;
            this.userName = null;
            this.displayName = null;
            this.password = null;
            this.email = null;
            this.phoneNumber = null;
            this.remark = null;
            this.department = null;
            this.createTime = DateTime.Now;
            this.updateTime = DateTime.Now;
        }

        public UserFormalizer(User user)
        {
            this.id = user.Id;
            this.userName = user.UserName;
            this.displayName = user.DisplayName;
            this.password = "";
            this.email = user.Email;
            this.phoneNumber = user.PhoneNumber;
            this.remark = user.Remark;
            this.department = user.Department.DepartmentName;
            this.createTime = user.CreateTime;
            this.updateTime = user.UpdateTime;
        }
        
        public int id { get; set; }
        public String userName { get; set; }
        public String displayName { get; set; }
        public String password { get; set; }
        public String email { get; set; }
        public String phoneNumber { get; set; }
        public String remark { get; set; }
        public String department { get; set; }
        public DateTime createTime { get; set; }
        public DateTime updateTime { get; set; }
    }
}