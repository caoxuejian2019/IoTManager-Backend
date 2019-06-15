using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace IoTManager.Model
{
    public class DeviceDataModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String Id { get; set; }
        
        [BsonElement("DeviceId")]
        public String DeviceId { get; set; }
        
        [BsonElement("IndexName")]
        public String IndexName { get; set; }
        
        [BsonElement("IndexId")]
        public String IndexId { get; set; }
        
        [BsonElement("IndexUnit")]
        public String IndexUnit { get; set; }
        
        [BsonElement("IndexType")]
        public String IndexType { get; set; }
        
        [BsonElement("IndexValue")]
        public String IndexValue { get; set; }
        
        [BsonElement("Timestamp")]
        public DateTime Timestamp { get; set; }
    }
}