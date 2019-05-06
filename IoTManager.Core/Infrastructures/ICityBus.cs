using System;
using System.Collections.Generic;
using System.Text;
using IoTManager.Model;
using IoTManager.Utility.Serializers;

namespace IoTManager.Core.Infrastructures
{
    public interface ICityBus
    {
        List<CityModel> GetAllCities();
        CityModel GetCityById(int id);
        String CreateNewCity(CityModel cityModel);
        String UpdateCity(int id, CityModel cityModel);
        String DeleteCity(int id);
    }
}
