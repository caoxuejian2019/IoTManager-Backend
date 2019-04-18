using System;
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
            this.LastConnectionTime = DateTime.Now;
            this.imageUrl = null;
            this.gatewayID = 0;
            this.mac = null;
            this.deviceType = null;
            this.createTime = DateTime.Now;
            this.updateTime = DateTime.Now;
            this.remark = null;
            this.department = null;
        }

        public DeviceFormalizer(Device device)
        {
            this.id = device.id;
            this.hardwareDeviceID = device.hardwareDeviceID;
            this.deviceName = device.deviceName;
            this.city = device.city.cityName;
            this.factory = device.factory.factoryName;
            this.workshop = device.workshop.workshopName;
            this.deviceState = device.deviceState.stateName;
            this.LastConnectionTime = device.LastConnectionTime;
            this.imageUrl = device.imageUrl;
            this.gatewayID = device.gatewayID;
            this.mac = device.mac;
            this.deviceType = device.deviceType.deviceTypeName;
            this.createTime = device.createTime;
            this.updateTime = device.updateTime;
            this.remark = device.remark;
            this.department = device.department.departmentName;
        }
        
        public int id { get; set; }
        public String hardwareDeviceID { get; set; }
        public String deviceName { get; set; }
        public String city { get; set; }
        public String factory { get; set; }
        public String workshop { get; set; }
        public String deviceState { get; set; }
        public DateTime LastConnectionTime { get; set; }
        public String imageUrl { get; set; }
        public int gatewayID { get; set; }
        public String mac { get; set; }
        public String deviceType { get; set; }
        public DateTime createTime { get; set; }
        public DateTime updateTime { get; set; }
        public String remark { get; set; }
        public String department { get; set; }
    }
}