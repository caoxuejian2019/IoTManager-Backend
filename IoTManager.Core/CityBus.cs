using IoTManager.Core.Infrastructures;
using IoTManager.IDao;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using IoTManager.Model;
using IoTManager.Utility.Serializers;

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

        public List<CitySerializer> GetAllCities()
        {
            List<CityModel> cities =  this._cityDao.Get();
            List<CitySerializer> result = new List<CitySerializer>();
            foreach (CityModel city in cities)
            {
                result.Add(new CitySerializer(city));
            }
            return result;
        }

        public CitySerializer GetCityById(int id)
        {
            CityModel city = this._cityDao.GetById(id);
            CitySerializer result = new CitySerializer(city);
            return result;
        }

        public String CreateNewCity(CitySerializer citySerializer)
        {
            CityModel cityModel = new CityModel();
            cityModel.CityName = citySerializer.cityName;
            cityModel.Remark = citySerializer.remark;
            return this._cityDao.Create(cityModel); 
        }

        public String UpdateCity(int id, CitySerializer citySerializer)
        {
            CityModel cityModel = new CityModel();
            cityModel.Id = id;
            cityModel.CityName = citySerializer.cityName;
            cityModel.Remark = citySerializer.remark;
            return this._cityDao.Update(id, cityModel);
        }

        public String DeleteCity(int id)
        {
            return this._cityDao.Delete(id);
        }
    }
}
