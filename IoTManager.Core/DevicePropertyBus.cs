using System;
using System.Collections.Generic;
using IoTManager.Core.Infrastructures;
using IoTManager.IDao;
using IoTManager.Model;
using IoTManager.Utility.Serializers;
using Microsoft.Extensions.Logging;
using MySqlX.XDevAPI.Common;


namespace IoTManager.Core
{
    public sealed class DevicePropertyBus: IDevicePropertyBus
    {
        private readonly IDevicePropertyDao _devicePropertyDao;
        private readonly ILogger _logger;

        public DevicePropertyBus(IDevicePropertyDao devicePropertyDao, ILogger<DevicePropertyBus> logger)
        {
            this._devicePropertyDao = devicePropertyDao;
            this._logger = logger;

        }

        public DevicePropertySerializer GetDevicePropertyByDeviceIdProperty(string Id, string Property)
        {
          //  throw new NotImplementedException();
        }

        public DevicePropertySerializer GetDevicePropertyById(string Id)
        {
            //throw new NotImplementedException();
        }
    }
