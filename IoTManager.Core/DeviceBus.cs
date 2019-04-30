using IoTManager.Core.Infrastructures;
using IoTManager.IDao;
using IoTManager.IHub;
using System;
using System.Collections.Generic;
using System.Text;

namespace IoTManager.Core
{
    public sealed class DeviceBus:IDeviceBus
    {
        private readonly IDeviceDao _deviceDao;
        private readonly IoTHub _iotHub;
        public DeviceBus(IDeviceDao deviceDao,IoTHub iotHub)
        {
            this._deviceDao = deviceDao;
            this._iotHub = iotHub;
        }
    }
}
