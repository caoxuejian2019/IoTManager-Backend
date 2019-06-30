using IoTManager.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IoTManager.IDao
{
    public interface IMonitorDataDao
    {
        void Add(MonitorDataModel model);
        List<MonitorDataModel> GetAll();
        MonitorDataModel GetById(int Id);
    }
}
