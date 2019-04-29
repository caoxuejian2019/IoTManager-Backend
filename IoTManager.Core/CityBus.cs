using IoTManager.Core.Infrastructures;
using IoTManager.IDao;
using System;
using System.Collections.Generic;
using System.Text;

namespace IoTManager.Core
{
    public sealed class CityBus:ICityBus
    {
        private readonly ICityDao _cityDao;
        public CityBus(ICityDao cityDao)
        {
            this._cityDao = cityDao;
        }
    }
}
