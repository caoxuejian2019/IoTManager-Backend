using System;
using System.Collections.Generic;
using System.Text;
using IoTManager.Model;
using IoTManager.Utility.Serializers;

namespace IoTManager.Core.Infrastructures
{
    public interface IDeviceBus
    {
        List<DeviceSerializer> GetAllDevices();
        DeviceSerializer GetDeviceById(int id);
        List<DeviceSerializer> GetDevicesByDeviceName(String deviceName);
        List<DeviceSerializer> GetDevicesByDeviceId(String deviceId);
        String CreateNewDevice(DeviceSerializer deviceSerializer);
        String UpdateDevice(int id, DeviceSerializer deviceSerializer);
        String DeleteDevice(int id);
        int BatchDeleteDevice(int[] id);
        List<DeviceSerializer> GetDeviceByWorkshop(String workshop);
    }
}
