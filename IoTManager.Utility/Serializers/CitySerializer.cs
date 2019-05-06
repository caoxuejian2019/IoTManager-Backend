using System;
using IoTManager.Model;

namespace IoTManager.Utility.Serializers
{
    public class CitySerializer
    {
        public CitySerializer()
        {
            this.id = 0;
            this.cityName = null;
            this.remark = null;
            this.createTime = null;
            this.updateTime = null;
        }

        public CitySerializer(CityModel cityModel)
        {
            this.id = cityModel.Id;
            this.cityName = cityModel.CityName;
            this.remark = cityModel.Remark;
            this.createTime = cityModel.CreateTime
                .ToString(Constant.getDateFormatString());
            this.updateTime = cityModel.UpdateTime
                .ToString(Constant.getDateFormatString());
        }
        
        public int id { get; set; }
        public String cityName { get; set; }
        public String remark { get; set; }
        public String createTime { get; set; }
        public String updateTime { get; set; }
    }
}