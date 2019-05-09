using System;
using System.Collections.Generic;
using IoTManager.Utility.Serializers;

namespace IoTManager.Core.Infrastructures
{
    public interface IFactoryBus
    {
        List<FactorySerializer> GetAllFactories();
        FactorySerializer GetFactoryById(int id);
        String CreateNewFactory(FactorySerializer factorySerializer);
        String UpdateFactory(int id, FactorySerializer factorySerializer);
        String DeleteFactory(int id);
    }
}