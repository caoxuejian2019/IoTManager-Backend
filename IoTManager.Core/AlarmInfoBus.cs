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
    }
}