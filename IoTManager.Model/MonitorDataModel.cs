using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace IoTManager.Model
{
    public class MonitorDataModel
    {
        [JsonProperty("Id")]
        public string Id { get; set; }
        public string GatewayId { get; set; }
        public string DeviceId { get; set; }
        public string TypeName { get; set; }
        public string Type { get; set; }
        public string Unit { get; set; }
        public string Value { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
