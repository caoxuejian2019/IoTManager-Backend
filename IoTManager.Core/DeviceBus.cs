using IoTManager.Core.Infrastructures;
using IoTManager.IDao;
using System;
using System.Collections.Generic;
using System.Text;

namespace IoTManager.Core
{
    public sealed class DeviceBus:IDeviceBus
    {
        private readonly IDeviceDao _deviceDao;
        public DeviceBus(IDeviceDao deviceDao)
        {
            this._deviceDao = deviceDao;
        }
    }
}
