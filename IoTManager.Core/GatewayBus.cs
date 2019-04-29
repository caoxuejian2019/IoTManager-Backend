using IoTManager.Core.Infrastructures;
using IoTManager.IDao;
using System;
using System.Collections.Generic;
using System.Text;

namespace IoTManager.Core
{
    public sealed class GatewayBus:IGatewayBus
    {
        private readonly IGatewayDao _gatewayDao;
        public GatewayBus(IGatewayDao gatewayDao)
        {
            this._gatewayDao = gatewayDao;
        }
    }
}
