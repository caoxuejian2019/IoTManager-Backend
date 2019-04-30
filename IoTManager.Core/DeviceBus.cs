using IoTManager.Core.Infrastructures;
using IoTManager.IDao;
using IoTManager.IHub;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace IoTManager.Core
{
    public sealed class DeviceBus:IDeviceBus
    {
        private readonly IDeviceDao _deviceDao;
        private readonly IoTHub _iotHub;
        private readonly ILogger _logger;
        public DeviceBus(IDeviceDao deviceDao,IoTHub iotHub,ILogger<DeviceBus> logger)
        {
            this._deviceDao = deviceDao;
            this._iotHub = iotHub;
            this._logger = logger;
        }
    }
}
