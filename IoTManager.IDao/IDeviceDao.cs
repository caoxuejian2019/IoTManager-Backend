using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using IoTManager.Model;

namespace IoTManager.IDao
{
    public interface IDeviceDao
    {
        List<DeviceModel> Get();
        DeviceModel GetById(int id);
        List<DeviceModel> GetByDeviceName(String deviceName);
        String Create(DeviceModel deviceModel);
        String Update(int id, DeviceModel deviceModel);
        String Delete(int id);
        int BatchDelete(int[] id);
    }
}
