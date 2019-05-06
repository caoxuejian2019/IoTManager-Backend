using IoTManager.Core.Infrastructures;
using IoTManager.IDao;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using IoTManager.Model;

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

        public List<CityModel> GetAllCities()
        {
            return this._cityDao.Get();
        }

        public CityModel GetCityById(int id)
        {
            return this._cityDao.GetById(id);
        }

        public String CreateNewCity(CityModel cityModel)
        {
            return this._cityDao.Create(cityModel); 
        }

        public String UpdateCity(int id, CityModel cityModel)
        {
            return this._cityDao.Update(id, cityModel);
        }

        public String DeleteCity(int id)
        {
            return this._cityDao.Delete(id);
        }
    }
}
