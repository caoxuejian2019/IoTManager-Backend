using System.Collections.Generic;
using IoTManager.Model;

namespace IoTManager.IDao
{
    public interface IDeviceDataDao
    {
        List<DeviceDataModel> Get();
    }
}