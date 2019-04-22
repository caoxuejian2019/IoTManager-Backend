using System;
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
            this.lastConnectionTime = DateTime.Now;
            this.imageUrl = null;
            this.createTime = DateTime.Now;
            this.updateTime = DateTime.Now;
            this.remark = null;
            this.department = null;
        }


        public GatewayFormalizer(Gateway gateway)
        {
            this.id = gateway.Id;
            this.hardwareGatewayID = gateway.HardwareGatewayId;
            this.gatewayName = gateway.GatewayName;
            this.gatewayType = gateway.GatewayType.gatewayTypeName;
            this.city = gateway.City.cityName;
            this.factory = gateway.Factory.factoryName;
            this.workshop = gateway.Workshop.workshopName;
            this.gatewayState = gateway.GatewayState.stateName;
            this.lastConnectionTime = gateway.LastConnectionTime;
            this.imageUrl = gateway.ImageUrl;
            this.createTime = gateway.CreateTime;
            this.updateTime = gateway.UpdateTime;
            this.remark = gateway.Remark;
            this.department = gateway.Department.departmentName;
        }
        
        
        public int id { get; set; }
        public String hardwareGatewayID { get; set; }
        public String gatewayName { get; set; }
        public String gatewayType { get; set; }
        public String city { get; set; }
        public String factory { get; set; }
        public String workshop { get; set; }
        public String gatewayState { get; set; }
        public DateTime lastConnectionTime { get; set; }
        public String imageUrl { get; set; }
        public DateTime createTime { get; set; }
        public DateTime updateTime { get; set; }
        public String remark { get; set; }
        public String department { get; set; }
    }
}