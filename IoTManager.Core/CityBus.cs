using IoTManager.Core.Infrastructures;
using IoTManager.IDao;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace IoTManager.Core
{
    public sealed class CityBus:ICityBus
    {
        private readonly ICityDao _cityDao;
        private readonly ILogger _logger;
        public CityBus(ICityDao cityDao,ILogger<CityBus> logger)
        {
            this._cityDao = cityDao;
            this._logger = logger;
        }
    }
}
