using System;
using IoTManager.Model;

namespace IoTManager.Utility.Serializers
{
    public class GatewaySerializer
    {
        public GatewaySerializer()
        {
            this.id = 0;
            this.hardwareGatewayID = null;
            this.gatewayName = null;
            this.city = null;
            this.factory = null;
            this.workshop = null;
            this.gatewayType = null;
            this.gatewayState = null;
            this.imageUrl = null;
            this.remark = null;
            this.lastConnectionTime = null;
            this.createTime = null;
            this.updateTime = null;
        }

        public GatewaySerializer(GatewayModel gatewayModel)
        {
            this.id = gatewayModel.Id;
            this.hardwareGatewayID = gatewayModel.HardwareGatewayId;
            this.gatewayName = gatewayModel.GatewayName;
            this.city = gatewayModel.City;
            this.factory = gatewayModel.Factory;
            this.workshop = gatewayModel.Workshop;
            this.gatewayType = gatewayModel.GatewayType;
            this.gatewayState = gatewayModel.GatewayState;
            this.imageUrl = gatewayModel.ImageUrl;
            this.remark = gatewayModel.Remark;
            this.lastConnectionTime = gatewayModel.LastConnectionTime
                .ToString(Constant.getDateFormatString());
            this.createTime = gatewayModel.CreateTime
                .ToString(Constant.getDateFormatString());
            this.updateTime = gatewayModel.UpdateTime
                .ToString(Constant.getDateFormatString());
        }
        
        public int id { get; set; }
        public String hardwareGatewayID { get; set; }
        public String gatewayName { get; set; }
        public String city { get; set; }
        public String factory { get; set; }
        public String workshop { get; set; }
        public String gatewayType { get; set; }
        public String gatewayState { get; set; }
        public String imageUrl { get; set; }
        public String remark { get; set; }
        public String lastConnectionTime { get; set; }
        public String createTime { get; set; }
        public String updateTime { get; set; }
    }
}