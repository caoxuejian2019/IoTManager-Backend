using System;
using IoTManager.API.Services;
using IoTManager.DAL.Models;

namespace IoTManager.API.Formalizers
{
    public class GatewayStateFormalizer
    {
        public GatewayStateFormalizer()
        {
            this.id = 0;
            this.stateName = null;
            this.remark = null;
            this.createTime = null;
            this.updateTime = null;
        }

        public GatewayStateFormalizer(GatewayState gatewayState)
        {
            this.id = gatewayState.Id;
            this.stateName = gatewayState.StateName;
            this.remark = gatewayState.Remark;
            this.createTime = gatewayState.CreateTime
                .ToString(ConstantService.DateTimeFormat);
            this.updateTime = gatewayState.UpdateTime
                .ToString(ConstantService.DateTimeFormat);
        }
        
        public int id { get; set; }
        public String stateName { get; set; }
        public String remark { get; set; }
        public String createTime { get; set; }
        public String updateTime { get; set; }
    }
}