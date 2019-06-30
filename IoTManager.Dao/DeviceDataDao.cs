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

        public List<DeviceDataModel> Get()
        {
            return _deviceData.Find<DeviceDataModel>(d => true).ToList();
        }

        public DeviceDataModel GetById(String Id)
        {
            return _deviceData.Find<DeviceDataModel>(dd => dd.Id == Id).FirstOrDefault();
        }

        public List<DeviceDataModel> GetByDeviceId(String DeviceId)
        {
            return _deviceData.Find<DeviceDataModel>(dd => dd.DeviceId == DeviceId).ToList();
        }

        public List<DeviceDataModel> GetNotInspected()
        {
            List<DeviceDataModel> deviceDataModels = _deviceData.Find<DeviceDataModel>(dd => dd.Inspected == "No").ToList();
            var filter = Builders<DeviceDataModel>.Filter.Eq("Inspected", "No");
            var update = Builders<DeviceDataModel>.Update.Set("Inspected", "Yes");
            var result = _deviceData.UpdateMany(filter, update);
            return deviceDataModels;
        }
    }
}