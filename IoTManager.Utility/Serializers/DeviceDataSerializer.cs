using System;
using IoTManager.Model;

namespace IoTManager.Utility.Serializers
{
    public class DeviceDataSerializer
    {
        public DeviceDataSerializer()
        {
            this.id = null;
            this.deviceId = null;
            this.indexName = null;
            this.indexId = null;
            this.indexUnit = null;
            this.indexType = null;
            this.indexValue = null;
            this.timestamp = null;
        }

        public DeviceDataSerializer(DeviceDataModel deviceDataModel)
        {
            this.id = deviceDataModel.Id;
            this.deviceId = deviceDataModel.DeviceId;
            this.indexName = deviceDataModel.IndexName;
            this.indexId = deviceDataModel.IndexId;
            this.indexUnit = deviceDataModel.IndexUnit;
            this.indexType = deviceDataModel.IndexType;
            this.indexValue = deviceDataModel.IndexValue;
            this.timestamp = deviceDataModel.Timestamp
                .ToString(Constant.getDateFormatString());
        }
        
        public String id { get; set; }
        public String deviceId { get; set; }
        public String indexName { get; set; }
        public String indexId { get; set; }
        public String indexUnit { get; set; }
        public String indexType { get; set; }
        public String indexValue { get; set; }
        public String timestamp { get; set; }
    }
}