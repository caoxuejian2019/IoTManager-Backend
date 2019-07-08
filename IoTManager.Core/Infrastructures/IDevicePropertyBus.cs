using System;
using System.Collections.Generic;
using IoTManager.Model;
using IoTManager.Utility.Serializers;

namespace IoTManager.Core.Infrastructures
{
    public interface IDevicePropertyBus
    {
        DevicePropertySerializer GetDevicePropertyById(string Id);

        DevicePropertySerializer GetDevicePropertyByDeviceIdProperty(string Id, string Property);
    }
}
