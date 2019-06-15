using System;
using System.Collections.Generic;
using IoTManager.IDao;
using IoTManager.Model;
using IoTManager.Utility;
using MongoDB.Driver;

namespace IoTManager.Dao
{
    public sealed class AlarmInfoDao: IAlarmInfoDao
    {
        private readonly IMongoCollection<AlarmInfoModel> _alarmInfo;

        public AlarmInfoDao()
        {
            var client = new MongoClient(Constant.getMongoDBConnectionString());
            var database = client.GetDatabase("iotmanager");

            _alarmInfo = database.GetCollection<AlarmInfoModel>("alarminfo");
        }

        public List<AlarmInfoModel> Get() =>
            _alarmInfo.Find<AlarmInfoModel>(a => true).ToList();

        public AlarmInfoModel GetById(String Id) =>
            _alarmInfo.Find<AlarmInfoModel>(a => a.Id == Id).FirstOrDefault();

        public List<AlarmInfoModel> GetByDeviceId(String DeviceId) =>
            _alarmInfo.Find<AlarmInfoModel>(a => a.DeviceId == DeviceId).ToList();

        public List<AlarmInfoModel> GetByIndexId(String IndexId) =>
            _alarmInfo.Find<AlarmInfoModel>(a => a.IndexId == IndexId).ToList();
    }
}