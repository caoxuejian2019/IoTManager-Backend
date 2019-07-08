using System;
using System.Collections.Generic;
using System;
using IoTManager.Model;

namespace IoTManager.Utility.Serializers
{
    public class DevicePropertySerializer
    {
        public DevicePropertySerializer()
        {

        }

        public DevicePropertySerializer(DevicePropertyModel devicePropertyModel)
        {

        }

        public int id { get; set; }
        public int deviceId { get; set; }
        public int Property { get; set; }

    }
}
