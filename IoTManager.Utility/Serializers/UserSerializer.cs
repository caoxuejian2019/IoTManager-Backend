using System;
using IoTManager.Model;

namespace IoTManager.Utility.Serializers
{
    public class UserSerializer
    {
        public UserSerializer()
        {
            this.id = 0;
            this.userName = null;
            this.displayName = null;
            this.password = null;
            this.email = null;
            this.phoneNumber = null;
            this.remark = null;
            this.createTime = null;
            this.updateTime = null;
        }

        public UserSerializer(UserModel userModel)
        {
            this.id = userModel.Id;
            this.userName = userModel.UserName;
            this.displayName = userModel.DisplayName;
            this.password = "";
            this.email = userModel.Email;
            this.phoneNumber = userModel.PhoneNumber;
            this.remark = userModel.Remark;
            this.createTime = userModel.CreateTime
                .ToString(Constant.getDateFormatString());
            this.updateTime = userModel.UpdateTime
                .ToString(Constant.getDateFormatString());

        }
        
        public int id { get; set; }
        public String userName { get; set; }
        public String displayName { get; set; }
        public String password { get; set; }
        public String email { get; set; }
        public String phoneNumber { get; set; }
        public String remark { get; set; }
        public String createTime { get; set; }
        public String updateTime { get; set; }
    }
}