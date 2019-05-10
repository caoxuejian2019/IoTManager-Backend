using System;
using IoTManager.Model;

namespace IoTManager.Utility.Serializers
{
    public class DeviceSerializer
    {
        public DeviceSerializer()
        {
            this.id = 0;
            this.deviceName = null;
            this.hardwareDeviceID = null;
            this.city = null;
            this.factory = null;
            this.workshop = null;
            this.deviceState = null;
            this.lastConnectiontime = null;
            this.imageUrl = null;
            this.gatewayId = 0;
            this.mac = null;
            this.deviceType = null;
            this.createTime = null;
            this.updateTime = null;
            this.remark = null;
        }

        public DeviceSerializer(DeviceModel deviceModel)
        {
            this.id = deviceModel.Id;
            this.deviceName = deviceModel.DeviceName;
            this.hardwareDeviceID = deviceModel.HardwareDeviceId;
            this.city = deviceModel.City;
            this.factory = deviceModel.Factory;
            this.workshop = deviceModel.Workshop;
            this.deviceState = deviceModel.DeviceState;
            this.lastConnectiontime = deviceModel.LastConnectionTime
                .ToString(Constant.getDateFormatString());
            this.imageUrl = deviceModel.ImageUrl;
            this.gatewayId = deviceModel.GatewayId;
            this.mac = deviceModel.Mac;
            this.deviceType = deviceModel.DeviceType;
            this.createTime = deviceModel.CreateTime
                .ToString(Constant.getDateFormatString());
            this.updateTime = deviceModel.UpdateTime
                .ToString(Constant.getDateFormatString());
            this.remark = deviceModel.Remark;
        }
        
        public int id { get; set; }
        public String deviceName { get; set; }
        public String hardwareDeviceID { get; set; }
        public String city { get; set; }
        public String factory { get; set; }
        public String workshop { get; set; }
        public String deviceState { get; set; }
        public String lastConnectiontime { get; set; }
        public String imageUrl { get; set; }
        public int gatewayId { get; set; }
        public String mac { get; set; }
        public String deviceType { get; set; }
        public String createTime { get; set; }
        public String updateTime { get; set; }
        public String remark { get; set; }
    }

    public class BatchNumber
    {
        public int[] number { get; set; }
    }
}