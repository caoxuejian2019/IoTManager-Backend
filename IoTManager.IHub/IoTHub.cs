using IoTManager.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IoTManager.IHub
{
    public interface IoTHub
    {
        IoTHubDeviceModel NewDevice(string deviceId);
        void RemoveDevice(string deviceId);
        IoTHubDeviceModel GetDevice(string deviceId);
        List<IoTHubDeviceModel> ListDevice();
    }
}
