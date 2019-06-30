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

        public List<AlarmInfoModel> Get()
        {
            return _alarmInfo.Find<AlarmInfoModel>(a => true).ToList();
        }

        public AlarmInfoModel GetById(String Id)
        {
            return _alarmInfo.Find<AlarmInfoModel>(a => a.Id == Id).FirstOrDefault();
        }

        public List<AlarmInfoModel> GetByDeviceId(String DeviceId)
        {
            return _alarmInfo.Find<AlarmInfoModel>(a => a.DeviceId == DeviceId).ToList();
        }

        public List<AlarmInfoModel> GetByIndexId(String IndexId)
        {
            return _alarmInfo.Find<AlarmInfoModel>(a => a.IndexId == IndexId).ToList();
        }

        public String Create(AlarmInfoModel alarmInfoModel)
        {
            _alarmInfo.InsertOne(alarmInfoModel);
            return "success";
        }
    }
}