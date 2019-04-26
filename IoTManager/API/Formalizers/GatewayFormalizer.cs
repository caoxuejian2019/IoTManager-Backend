using System;
using IoTManager.API.Services;
using IoTManager.DAL.Models;

namespace IoTManager.API.Formalizers
{
    public class GatewayFormalizer
    {
        public GatewayFormalizer()
        {
            this.id = 0;
            this.hardwareGatewayID = null;
            this.gatewayName = null;
            this.gatewayType = null;
            this.city = null;
            this.factory = null;
            this.workshop = null;
            this.gatewayState = null;
            this.lastConnectionTime = null;
            this.imageUrl = null;
            this.createTime = null;
            this.updateTime = null;
            this.remark = null;
            this.department = null;
        }


        public GatewayFormalizer(Gateway gateway)
        {
            this.id = gateway.Id;
            this.hardwareGatewayID = gateway.HardwareGatewayId;
            this.gatewayName = gateway.GatewayName;
            this.gatewayType = gateway.GatewayType.GatewayTypeName;
            this.city = gateway.City.CityName;
            this.factory = gateway.Factory.FactoryName;
            this.workshop = gateway.Workshop.WorkshopName;
            this.gatewayState = gateway.GatewayState.StateName;
            this.lastConnectionTime = gateway.LastConnectionTime
                .ToString(ConstantService.DateTimeFormat);
            this.imageUrl = gateway.ImageUrl;
            this.createTime = gateway.CreateTime
                .ToString(ConstantService.DateTimeFormat);
            this.updateTime = gateway.UpdateTime
                .ToString(ConstantService.DateTimeFormat);
            this.remark = gateway.Remark;
            this.department = gateway.Department.DepartmentName;
        }
        
        
        public int id { get; set; }
        public String hardwareGatewayID { get; set; }
        public String gatewayName { get; set; }
        public String gatewayType { get; set; }
        public String city { get; set; }
        public String factory { get; set; }
        public String workshop { get; set; }
        public String gatewayState { get; set; }
        public String lastConnectionTime { get; set; }
        public String imageUrl { get; set; }
        public String createTime { get; set; }
        public String  updateTime { get; set; }
        public String remark { get; set; }
        public String department { get; set; }
    }
}