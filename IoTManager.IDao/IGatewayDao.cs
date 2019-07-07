using System;
using System.Collections.Generic;
using System.Text;
using IoTManager.Model;

namespace IoTManager.IDao
{
    public interface IGatewayDao
    {
        List<GatewayModel> Get();
        GatewayModel GetById(int id);
        String Create(GatewayModel gatewayModel);
        String Update(int id, GatewayModel gatewayModel);
        String Delete(int id);
        List<GatewayModel> GetByWorkshop(String workshop);
    }
}
