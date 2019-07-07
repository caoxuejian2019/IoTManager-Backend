using IoTManager.Core.Infrastructures;
using IoTManager.IDao;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using IoTManager.Model;
using IoTManager.Utility.Serializers;

namespace IoTManager.Core
{
    public sealed class GatewayBus:IGatewayBus
    {
        private readonly IGatewayDao _gatewayDao;
        private readonly ILogger _logger;
        public GatewayBus(IGatewayDao gatewayDao,ILogger<GatewayBus> logger)
        {
            this._gatewayDao = gatewayDao;
            this._logger = logger;
        }

        public List<GatewaySerializer> GetAllGateways()
        {
            List<GatewayModel> gateways = this._gatewayDao.Get();
            List<GatewaySerializer> result = new List<GatewaySerializer>();
            foreach (GatewayModel gateway in gateways)
            {
                result.Add(new GatewaySerializer(gateway));
            }
            return result;
        }

        public GatewaySerializer GetGatewayById(int id)
        {
            GatewayModel gateway = this._gatewayDao.GetById(id);
            GatewaySerializer result = new GatewaySerializer(gateway);
            return result;
        }

        public String CreateNewGateway(GatewaySerializer gatewaySerializer)
        {
            GatewayModel gatewayModel = new GatewayModel();
            gatewayModel.HardwareGatewayId = gatewaySerializer.hardwareGatewayID;
            gatewayModel.GatewayName = gatewaySerializer.gatewayName;
            gatewayModel.City = gatewaySerializer.city;
            gatewayModel.Factory = gatewaySerializer.factory;
            gatewayModel.Workshop = gatewaySerializer.workshop;
            gatewayModel.GatewayType = gatewaySerializer.gatewayType;
            gatewayModel.GatewayState = gatewaySerializer.gatewayState;
            gatewayModel.ImageUrl = gatewaySerializer.imageUrl;
            gatewayModel.Remark = gatewaySerializer.remark;
            return this._gatewayDao.Create(gatewayModel);
        }

        public String UpdateGateway(int id, GatewaySerializer gatewaySerializer)
        {
            GatewayModel gatewayModel = new GatewayModel();
            gatewayModel.Id = id;
            gatewayModel.HardwareGatewayId = gatewaySerializer.hardwareGatewayID;
            gatewayModel.GatewayName = gatewaySerializer.gatewayName;
            gatewayModel.City = gatewaySerializer.city;
            gatewayModel.Factory = gatewaySerializer.factory;
            gatewayModel.Workshop = gatewaySerializer.workshop;
            gatewayModel.GatewayType = gatewaySerializer.gatewayType;
            gatewayModel.GatewayState = gatewaySerializer.gatewayState;
            gatewayModel.ImageUrl = gatewaySerializer.imageUrl;
            gatewayModel.Remark = gatewaySerializer.remark;
            return this._gatewayDao.Update(id, gatewayModel);
        }

        public String DeleteGateway(int id)
        {
            return this._gatewayDao.Delete(id);
        }

        public List<GatewaySerializer> GetGatewayByWorkshop(String workshop)
        {
            List<GatewayModel> gateways = this._gatewayDao.GetByWorkshop(workshop);
            List<GatewaySerializer> result = new List<GatewaySerializer>();
            foreach (GatewayModel g in gateways)
            {
                result.Add(new GatewaySerializer(g));
            }

            return result;
        }
    }
}
