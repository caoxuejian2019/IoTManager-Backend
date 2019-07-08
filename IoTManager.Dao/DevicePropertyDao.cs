using System;
using System.Collections.Generic;
using IoTManager.IDao;
using IoTManager.Model;
using IoTManager.Utility;
using MongoDB.Bson;
using MongoDB.Driver;

namespace IoTManager.Dao
{
    public sealed class DevicePropertyDao: IDevicePropertyDao
    {
        private readonly IMongoCollection<DevicePropertyModel> _devicePropertyData;

        public DevicePropertyDao()
        {
            var client = new MongoClient(Constant.getMongoDBConnectionString());
            var database = client.GetDatabase("iotmanager");

            _devicePropertyData = database.GetCollection<DevicePropertyModel>("devicedata");
        }
        public List<DevicePropertyModel> Get()
        {
           // throw new NotImplementedException();
        }

        public DevicePropertyModel GetById(string Id)
        {
           // throw new NotImplementedException();
        }

        public DevicePropertyModel GetByDeviceIdProperty(string Id, string Property)
        {
          //  throw new NotImplementedException();
        }
    
    }
}
