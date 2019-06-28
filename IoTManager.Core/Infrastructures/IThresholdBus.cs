using System;
using System.Collections.Generic;

namespace IoTManager.Core.Infrastructures
{
    public interface IThresholdBus
    {
        Dictionary<String, Tuple<String, int>> GetByDeviceId(String deviceId);
    }
}