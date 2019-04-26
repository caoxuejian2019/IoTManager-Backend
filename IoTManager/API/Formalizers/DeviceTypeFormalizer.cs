using System;
using IoTManager.API.Services;
using IoTManager.DAL.Models;

namespace IoTManager.API.Formalizers
{
    public class DeviceTypeFormalizer
    {
        public DeviceTypeFormalizer()
        {
            this.id = 0;
            this.deviceTypeName = null;
            this.remark = null;
            this.createTime = null;
            this.updateTime = null;
        }

        public DeviceTypeFormalizer(DeviceType deviceType)
        {
            this.id = deviceType.Id;
            this.deviceTypeName = deviceType.DeviceTypeName;
            this.remark = deviceType.Remark;
            this.createTime = deviceType.CreateTime
                .ToString(ConstantService.DateTimeFormat);
            this.updateTime = deviceType.UpdateTime
                .ToString(ConstantService.DateTimeFormat);
        }
        
        public int id { get; set; }
        public String deviceTypeName { get; set; }
        public String remark { get; set; }
        public String createTime { get; set; }
        public String updateTime { get; set; }
    }
}