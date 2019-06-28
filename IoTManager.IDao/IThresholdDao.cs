using System;
using System.Collections.Generic;
using IoTManager.Model;

namespace IoTManager.IDao
{
    public interface IThresholdDao
    {
        Dictionary<String, Tuple<String, int>> GetByDeviceId(String deviceId);
    }
}