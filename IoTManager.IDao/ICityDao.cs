using System;
using System.Collections.Generic;
using System.Text;
using IoTManager.Model;

namespace IoTManager.IDao
{
    public interface ICityDao
    {
        String Create(CityModel cityModel);
        List<CityModel> Get();
        CityModel GetById(int id);
        String Update(int id, CityModel cityModel);
        String Delete(int id);
    }
}
