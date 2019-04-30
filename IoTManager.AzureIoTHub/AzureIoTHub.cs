using IoTManager.IHub;
using IoTManager.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IoTManager.AzureIoTHub
{
    public sealed class AzureIoTHub : IoTHub
    {
        public DeviceModel GetDevice(string deviceId)
        {
            throw new NotImplementedException();
        }

        public List<DeviceModel> ListDevice()
        {
            throw new NotImplementedException();
        }

        public DeviceModel NewDevice(string deviceId)
        {
            throw new NotImplementedException();
        }

        public void RemoveDevice(string deviceId)
        {
            throw new NotImplementedException();
        }
    }
}
