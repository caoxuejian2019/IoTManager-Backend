using System.Collections.Generic;
using IoTManager.Model;

namespace IoTManager.Core.Infrastructures
{
    public interface IDeviceDataBus
    {
        List<DeviceDataModel> GetAllDeviceData();
    }
}