using System;
using System.Collections.Generic;
using System.Text;
using IoTManager.Model;
using IoTManager.Utility.Serializers;

namespace IoTManager.Core.Infrastructures
{
    public interface ICityBus
    {
        List<CitySerializer> GetAllCities();
        CitySerializer GetCityById(int id);
        String CreateNewCity(CitySerializer citySerializer);
        String UpdateCity(int id, CitySerializer citySerializer);
        String DeleteCity(int id);
    }
}
