using System;
using System.Collections.Generic;
using IoTManager.Model;
using IoTManager.Utility.Serializers;

namespace IoTManager.IDao
{
    public interface IFactoryDao
    {
        List<FactoryModel> Get();
        FactoryModel GetById(int id);
        String Create(FactoryModel factoryModel);
        String Update(int id, FactoryModel factoryModel);
        String Delete(int id);
    }
}