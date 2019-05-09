using System;
using IoTManager.Model;

namespace IoTManager.Utility.Serializers
{
    public class FactorySerializer
    {
        public FactorySerializer()
        {
            this.id = 0;
            this.factoryName = null;
            this.factoryPhoneNumber = null;
            this.factoryAddress = null;
            this.remark = null;
            this.createTime = null;
            this.updateTime = null;
            this.city = null;
        }

        public FactorySerializer(FactoryModel factoryModel)
        {
            this.id = factoryModel.Id;
            this.factoryName = factoryModel.FactoryName;
            this.factoryPhoneNumber = factoryModel.FactoryPhoneNumber;
            this.factoryAddress = factoryModel.FactoryAddress;
            this.remark = factoryModel.Remark;
            this.createTime = factoryModel.CreateTime
                .ToString(Constant.getDateFormatString());
            this.updateTime = factoryModel.UpdateTime
                .ToString(Constant.getDateFormatString());
            this.city = factoryModel.City;
        }
        
        public int id { get; set; }
        public String factoryName { get; set; }
        public String factoryPhoneNumber { get; set; }
        public String factoryAddress { get; set; }
        public String remark { get; set; }
        public String createTime { get; set; }
        public String updateTime { get; set; }
        public String city { get; set; }
    }
}