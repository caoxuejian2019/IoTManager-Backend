using IoTManager.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IoTManager.IHub
{
    public interface IoTHub
    {
        DeviceModel NewDevice(string deviceId);
        void RemoveDevice(string deviceId);
        DeviceModel GetDevice(string deviceId);
        List<DeviceModel> ListDevice();
    }
}
