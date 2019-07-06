using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly IThresholdDao _thresholdDao;
        private readonly ILogger _logger;

        public AlarmInfoJob(IDeviceDataDao deviceDataDao, IAlarmInfoDao alarmInfoDao, IThresholdDao thresholdDao, ILogger<AlarmInfoJob> logger)
        {
            this._deviceDataDao = deviceDataDao;
            this._alarmInfoDao = alarmInfoDao;
            this._thresholdDao = thresholdDao;
            this._logger = logger;
        }

        [Invoke(Begin = "2019-6-16 16:20", Interval = 1000 * 10, SkipWhileExecuting = true)]
        public void Run()
        {
            List<DeviceDataModel> dataNotInspected = _deviceDataDao.GetNotInspected();
            Dictionary<String, List<DeviceDataModel>> sortedData = new Dictionary<string, List<DeviceDataModel>>();
            List<String> deviceIds = new List<string>();
            foreach (DeviceDataModel d in dataNotInspected)
            {
                if (!sortedData.ContainsKey(d.DeviceId))
                {
                    sortedData.Add(d.DeviceId, new List<DeviceDataModel>());
                    sortedData[d.DeviceId].Add(d);
                }
                else
                {
                    sortedData[d.DeviceId].Add(d);
                }
                deviceIds.Add(d.DeviceId);
            }
            //TODO: Uniquify
            deviceIds = deviceIds.Distinct().ToList();
            foreach (String did in deviceIds)
            {
                Dictionary<String, Tuple<String, int>> thresholdDic = _thresholdDao.GetByDeviceId(did);
                foreach (DeviceDataModel data in sortedData[did])
                {
                    String op = thresholdDic[data.IndexId].Item1;
                    int threshold = thresholdDic[data.IndexId].Item2;

                    Boolean abnormal = false;

                    if (op == "equal")
                    {
                        if (Int32.Parse(data.IndexValue) != threshold)
                        {
                            abnormal = true;
                        }
                    }
                    else if (op == "less")
                    {
                        if (Int32.Parse(data.IndexValue) <= threshold)
                        {
                            abnormal = true;
                        }
                    }
                    else if (op == "greater")
                    {
                        if (Int32.Parse(data.IndexValue) >= threshold)
                        {
                            abnormal = true;
                        }
                    }

                    if (abnormal == true)
                    {
                        AlarmInfoModel alarmInfo = new AlarmInfoModel();
                        alarmInfo.AlarmInfo = data.Id;
                        alarmInfo.DeviceId = data.DeviceId;
                        alarmInfo.IndexId = data.IndexId;
                        alarmInfo.IndexName = data.IndexName;
                        alarmInfo.IndexValue = data.IndexValue;
                        alarmInfo.ThresholdValue = threshold.ToString();
                        alarmInfo.Timestamp = DateTime.Now;

                        _alarmInfoDao.Create(alarmInfo);
                    }
                }
            }
        }
    }
}