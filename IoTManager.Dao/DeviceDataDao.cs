using System;
using System.Collections.Generic;
using IoTManager.IDao;
using IoTManager.Model;
using IoTManager.Utility;
using MongoDB.Bson;
using MongoDB.Driver;

namespace IoTManager.Dao
{
    public sealed class DeviceDataDao: IDeviceDataDao
    {
        private readonly IMongoCollection<DeviceDataModel> _deviceData;

        public DeviceDataDao()
        {
            var client = new MongoClient(Constant.getMongoDBConnectionString());
            var database = client.GetDatabase("iotmanager");

            _deviceData = database.GetCollection<DeviceDataModel>("devicedata");
        }

        public List<DeviceDataModel> Get() =>
            _deviceData.Find<DeviceDataModel>(d => true).ToList();
    }
}