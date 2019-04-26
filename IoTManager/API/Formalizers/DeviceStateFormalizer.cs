using System;
using IoTManager.API.Services;
using IoTManager.DAL.Models;

namespace IoTManager.API.Formalizers
{
    public class DeviceStateFormalizer
    {
        public DeviceStateFormalizer()
        {
            this.id = 0;
            this.stateName = null;
            this.remark = null;
            this.createTime = null;
            this.updateTime = null;
        }

        public DeviceStateFormalizer(DeviceState deviceState)
        {
            this.id = deviceState.Id;
            this.stateName = deviceState.StateName;
            this.remark = deviceState.Remark;
            this.createTime = deviceState.CreateTime
                .ToString(ConstantService.DateTimeFormat);
            this.updateTime = deviceState.UpdateTime
                .ToString(ConstantService.DateTimeFormat);
        }
        
        public int id { get; set; }
        public String stateName { get; set; }
        public String remark { get; set; }
        public String createTime { get; set; }
        public String updateTime { get; set; }
    }
}