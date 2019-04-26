using System;
using IoTManager.API.Services;
using IoTManager.DAL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace IoTManager.API.Formalizers
{
    public class DeviceFormalizer
    {
        public DeviceFormalizer()
        {
            this.id = 0;
            this.hardwareDeviceID = null;
            this.deviceName = null;
            this.city = null;
            this.factory = null;
            this.workshop = null;
            this.deviceState = null;
            this.LastConnectionTime = null;
            this.imageUrl = null;
            this.gatewayID = 0;
            this.mac = null;
            this.deviceType = null;
            this.createTime = null;
            this.updateTime = null;
            this.remark = null;
            this.department = null;
        }

        
        public DeviceFormalizer(Device device)
        {
            this.id = device.Id;
            this.hardwareDeviceID = device.HardwareDeviceId;
            this.deviceName = device.DeviceName;
            this.city = device.City.CityName;
            this.factory = device.Factory.FactoryName;
            this.workshop = device.Workshop.WorkshopName;
            this.deviceState = device.DeviceState.StateName;
            this.LastConnectionTime = device.LastConnectionTime
                .ToString(ConstantService.DateTimeFormat);
            this.imageUrl = device.ImageUrl;
            this.gatewayID = device.GatewayId;
            this.mac = device.Mac;
            this.deviceType = device.DeviceType.deviceTypeName;
            this.createTime = device.CreateTime
                .ToString(ConstantService.DateTimeFormat);
            this.updateTime = device.UpdateTime
                .ToString(ConstantService.DateTimeFormat);
            this.remark = device.Remark;
            this.department = device.Department.DepartmentName;
        }
        
        
        public int id { get; set; }
        public String hardwareDeviceID { get; set; }
        public String deviceName { get; set; }
        public String city { get; set; }
        public String factory { get; set; }
        public String workshop { get; set; }
        public String deviceState { get; set; }
        public String LastConnectionTime { get; set; }
        public String imageUrl { get; set; }
        public int gatewayID { get; set; }
        public String mac { get; set; }
        public String deviceType { get; set; }
        public String createTime { get; set; }
        public String updateTime { get; set; }
        public String remark { get; set; }
        public String department { get; set; }
    }
}