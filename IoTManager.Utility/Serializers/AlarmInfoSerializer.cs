using System;
using IoTManager.Model;

namespace IoTManager.Utility.Serializers
{
    public class AlarmInfoSerializer
    {
        public AlarmInfoSerializer()
        {
            this.id = null;
            this.alarmInfo = null;
            this.deviceId = null;
            this.indexId = null;
            this.indexName = null;
            this.indexValue = null;
            this.thresholdValue = null;
            this.timestamp = null;
        }

        public AlarmInfoSerializer(AlarmInfoModel alarmInfoModel)
        {
            this.id = alarmInfoModel.Id;
            this.alarmInfo = alarmInfoModel.AlarmInfo;
            this.deviceId = alarmInfoModel.DeviceId;
            this.indexId = alarmInfoModel.IndexId;
            this.indexName = alarmInfoModel.IndexName;
            this.indexValue = alarmInfoModel.IndexValue;
            this.thresholdValue = alarmInfoModel.ThresholdValue;
            this.timestamp = alarmInfoModel.Timestamp
                .ToString(Constant.getDateFormatString());
        }
        
        public String id { get; set; }
        public String alarmInfo { get; set; }
        public String deviceId { get; set; }
        public String indexId { get; set; }
        public String indexName { get; set; }
        public String indexValue { get; set; }
        public String thresholdValue { get; set; }
        public String timestamp { get; set; }
    }
}