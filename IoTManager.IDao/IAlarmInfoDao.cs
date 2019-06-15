using System.Collections.Generic;
using IoTManager.Model;

namespace IoTManager.IDao
{
    public interface IAlarmInfoDao
    {
        List<AlarmInfoModel> Get();
    }
}