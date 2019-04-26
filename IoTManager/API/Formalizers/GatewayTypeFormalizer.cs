using System;
using IoTManager.API.Services;
using IoTManager.DAL.Models;

namespace IoTManager.API.Formalizers
{
    public class GatewayTypeFormalizer
    {
        public GatewayTypeFormalizer()
        {
            this.id = 0;
            this.gatewayTypeName = null;
            this.remark = null;
            this.createTime = null;
            this.updateTime = null;
        }

        public GatewayTypeFormalizer(GatewayType gatewayType)
        {
            this.id = gatewayType.Id;
            this.gatewayTypeName = gatewayType.GatewayTypeName;
            this.remark = gatewayType.Remark;
            this.createTime = gatewayType.CreateTime
                .ToString(ConstantService.DateTimeFormat);
            this.updateTime = gatewayType.UpdateTime
                .ToString(ConstantService.DateTimeFormat);
        }
        
        public int id { get; set; }
        public String gatewayTypeName { get; set; }
        public String remark { get; set; }
        public String createTime { get; set; }
        public String updateTime { get; set; }
    }
}