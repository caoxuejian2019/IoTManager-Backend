using IoTManager.IHub;
using IoTManager.Model;
using IoTManager.Model.Configuration;
using IoTManager.Utility.Extensions;
using Microsoft.Azure.Devices;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace IoTManager.AzureIoTHub
{
    public sealed class AzureIoTHub : IoTHub
    {
        private readonly RegistryManager _registeryManager;
        private readonly IoTHubAppSetting _appsetting;

        public AzureIoTHub(IOptions<IoTHubAppSetting> appsetting)
        {
            this._appsetting = appsetting.Value;
            this._registeryManager = RegistryManager.CreateFromConnectionString(this._appsetting.ConnectionString);
        }

        public DeviceModel GetDevice(string deviceId)
        {
            var device = this._registeryManager.GetDeviceAsync(deviceId).Result;
            return device.ToJson().ConvertToObj<DeviceModel>();
        }

        public List<DeviceModel> ListDevice()
        {
            List<DeviceModel> devices = new List<DeviceModel>();
            
            var query = this._registeryManager.CreateQuery("select * from devices");
            if (query.HasMoreResults)
            {
                var jsons = query.GetNextAsJsonAsync().Result;
                foreach (var json in jsons)
                {
                    devices.Add(json.ConvertToObj<DeviceModel>());
                }
            }
            return devices;
        }

        public DeviceModel NewDevice(string deviceId)
        {
            var device = this._registeryManager.AddDeviceAsync(new Device(deviceId)).Result;
            return device.ToJson().ConvertToObj<DeviceModel>();
        }

        public void RemoveDevice(string deviceId)
        {
            this._registeryManager.RemoveDeviceAsync(deviceId);
        }
    }
}
