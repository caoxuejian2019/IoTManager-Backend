using System;
using System.Collections.Generic;

namespace IoTManager.Core.Infrastructures
{
    public interface IStateTypeBus
    {
        List<String> GetAllDeviceTypes();
        List<String> GetAllDeviceStates();
        List<String> GetAllGatewayTypes();
        List<String> GetAllGatewayStates();
    }
}