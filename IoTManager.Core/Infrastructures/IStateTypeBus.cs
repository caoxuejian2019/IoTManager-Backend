using System;
using System.Collections.Generic;

namespace IoTManager.Core.Infrastructures
{
    public interface IStateTypeBus
    {
        List<object> GetAllDeviceTypes();
        List<object> GetAllDeviceStates();
        List<object> GetAllGatewayTypes();
        List<object> GetAllGatewayStates();
    }
}