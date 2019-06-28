using System;
using System.Collections.Generic;
using IoTManager.Core.Infrastructures;
using IoTManager.IDao;
using Microsoft.Extensions.Logging;

namespace IoTManager.Core
{
    public sealed class ThresholdBus: IThresholdBus
    {
        private readonly IThresholdDao _thresholdDao;
        private readonly ILogger _logger;

        public ThresholdBus(IThresholdDao thresholdDao, ILogger<ThresholdBus> logger)
        {
            this._thresholdDao = thresholdDao;
            this._logger = logger;
        }
        
        public Dictionary<String, Tuple<String, int>> GetByDeviceId(String deviceId)
        {
            return _thresholdDao.GetByDeviceId(deviceId);
        }
    }
}