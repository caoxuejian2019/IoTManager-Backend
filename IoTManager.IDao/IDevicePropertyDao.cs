using System;
using System.Collections.Generic;
using System.Text;
using IoTManager.Model;

namespace IoTManager.IDao
{
    public interface IDevicePropertyDao
    {
        List<DevicePropertyModel> Get();

        DevicePropertyModel GetById(string Id);

        DevicePropertyModel GetByDeviceIdProperty(string Id, string Property);


    }
}
