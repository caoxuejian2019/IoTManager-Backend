using System;
using System.Collections.Generic;
using IoTManager.Model;
using IoTManager.Utility.Serializers;

namespace IoTManager.Core.Infrastructures
{
    public interface IAlarmInfoBus
    {
        List<AlarmInfoSerializer> GetAllAlarmInfo();
        AlarmInfoSerializer GetAlarmInfoById(String Id);
        List<AlarmInfoSerializer> GetAlarmInfoByDeviceId(String DeviceId);
        List<AlarmInfoSerializer> GetAlarmInfoByIndexId(String IndexId);
        String InspectAlarmInfo();
    }
}