using System;
using System.Collections.Generic;

namespace IoTManager.IDao
{
    public interface IStateTypeDao
    {
        List<String> GetDeviceType();
        List<String> GetDeviceState();
        List<String> GetGatewayType();
        List<String> GetGatewayState();
    }
}