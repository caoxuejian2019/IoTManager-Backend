using System.Collections.Generic;
using IoTManager.Core.Infrastructures;
using IoTManager.IDao;
using IoTManager.Model;
using Microsoft.Extensions.Logging;

namespace IoTManager.Core
{
    public sealed class DeviceDataBus: IDeviceDataBus
    {
        private readonly IDeviceDataDao _deviceDataDao;
        private readonly ILogger _logger;

        public DeviceDataBus(IDeviceDataDao deviceDataDao, ILogger<DeviceDataBus> logger)
        {
            this._deviceDataDao = deviceDataDao;
            this._logger = logger;
        }

        public List<DeviceDataModel> GetAllDeviceData()
        {
            return _deviceDataDao.Get();
        }
    }
}