using IoTManager.Core.Infrastructures;
using IoTManager.IDao;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
