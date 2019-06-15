using System;
using System.Collections.Generic;
using IoTManager.Model;

namespace IoTManager.IDao
{
    public interface IAlarmInfoDao
    {
        List<AlarmInfoModel> Get();
        AlarmInfoModel GetById(String Id);
        List<AlarmInfoModel> GetByDeviceId(String DeviceId);
        List<AlarmInfoModel> GetByIndexId(String IndexId);
    }
}