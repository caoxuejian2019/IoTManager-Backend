using System;
using System.Collections.Generic;
using IoTManager.IDao;
using IoTManager.Model;
using Microsoft.Extensions.Logging;
using Pomelo.AspNetCore.TimedJob;

namespace IoTManager.Core.Jobs
{
    public class AlarmInfoJob: Job
    {
        private readonly IDeviceDataDao _deviceDataDao;
        private readonly IAlarmInfoDao _alarmInfoDao;
        private readonly ILogger _logger;

        public AlarmInfoJob(IDeviceDataDao deviceDataDao, IAlarmInfoDao alarmInfoDao, ILogger<AlarmInfoJob> logger)
        {
            this._deviceDataDao = deviceDataDao;
            this._alarmInfoDao = alarmInfoDao;
            this._logger = logger;
        }

        [Invoke(Begin = "2019-6-16 16:20", Interval = 1000*3, SkipWhileExecuting = true)]
        public void Run()
        {
            List<DeviceDataModel> result = _deviceDataDao.GetNotInspected();
            System.Console.WriteLine(result[1].IndexValue);
        }
    }
}