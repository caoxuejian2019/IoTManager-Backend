using System;
using System.Collections.Generic;
using System.Text;
using IoTManager.Model;
using IoTManager.Utility.Serializers;

namespace IoTManager.Core.Infrastructures
{
    public interface IGatewayBus
    {
        List<GatewaySerializer> GetAllGateways();
        GatewaySerializer GetGatewayById(int id);
        String CreateNewGateway(GatewaySerializer gatewaySerializer);
        String UpdateGateway(int id, GatewaySerializer gatewaySerializer);
        String DeleteGateway(int id);
        List<GatewaySerializer> GetGatewayByWorkshop(String workshop);
    }
}
