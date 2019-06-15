using System;
using System.Collections.Generic;
using IoTManager.Core.Infrastructures;
using IoTManager.IDao;
using IoTManager.Model;
using IoTManager.Utility.Serializers;
using Microsoft.Extensions.Logging;

namespace IoTManager.Core
{
    public sealed class AlarmInfoBus: IAlarmInfoBus
    {
        private readonly IAlarmInfoDao _alarmInfoDao;
        private readonly ILogger _logger;

        public AlarmInfoBus(IAlarmInfoDao alarmInfoDao, ILogger<AlarmInfoBus> logger)
        {
            this._alarmInfoDao = alarmInfoDao;
            this._logger = logger;
        }

        public List<AlarmInfoSerializer> GetAllAlarmInfo()
        {
            List<AlarmInfoModel> alarmInfos = this._alarmInfoDao.Get();
            List<AlarmInfoSerializer> result = new List<AlarmInfoSerializer>();
            foreach (AlarmInfoModel alarmInfo in alarmInfos)
            {
                result.Add(new AlarmInfoSerializer(alarmInfo));
            }
            return result;
        }

        public AlarmInfoSerializer GetAlarmInfoById(String Id)
        {
            AlarmInfoModel alarmInfo = this._alarmInfoDao.GetById(Id);
            AlarmInfoSerializer result = new AlarmInfoSerializer(alarmInfo);
            return result;
        }

        public List<AlarmInfoSerializer> GetAlarmInfoByDeviceId(String DeviceId)
        {
            List<AlarmInfoModel> alarmInfos = this._alarmInfoDao.GetByDeviceId(DeviceId);
            List<AlarmInfoSerializer> result = new List<AlarmInfoSerializer>();
            foreach (AlarmInfoModel alarmInfo in alarmInfos)
            {
                result.Add(new AlarmInfoSerializer(alarmInfo));
            }
            return result;
        }

        public List<AlarmInfoSerializer> GetAlarmInfoByIndexId(String IndexId)
        {
            List<AlarmInfoModel> alarmInfos = this._alarmInfoDao.GetByIndexId(IndexId);
            List<AlarmInfoSerializer> result = new List<AlarmInfoSerializer>();
            foreach (AlarmInfoModel alarmInfo in alarmInfos)
            {
                result.Add(new AlarmInfoSerializer(alarmInfo));
            }
            return result;
        }
    }
}