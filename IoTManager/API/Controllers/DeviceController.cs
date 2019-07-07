using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IoTManager.API.Formalizers;
using Microsoft.AspNetCore.Mvc;
using IoTManager.DAL.ReturnType;
using IoTManager.DAL.Models;
using IoTManager.DAL.DbContext;
using Microsoft.AspNetCore.WebSockets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using IoTManager.Core.Infrastructures;
using IoTManager.Utility.Serializers;

namespace IoTManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceBus _deviceBus;

        public DeviceController(IDeviceBus deviceBus)
        {
            this._deviceBus = deviceBus;
        }

        // GET api/values
        [HttpGet]
        public ResponseSerializer Get()
        {
            return new ResponseSerializer(
                200,
                "success",
                this._deviceBus.GetAllDevices());
        }

        // GET api/values/{id}
        [HttpGet("{id}")]
        public ResponseSerializer Get(int id)
        {
            return new ResponseSerializer(
                200,
                "success",
                this._deviceBus.GetDeviceById(id));
        }
        
        // GET api/device/devicename/{deviceName}
        [HttpGet("devicename/{devicename}")]
        public ResponseSerializer GetByDeviceName(String deviceName)
        {
            return new ResponseSerializer(
                200,
                "success",
                this._deviceBus.GetDevicesByDeviceName(deviceName));
        }
        
        //GET api/device/deviceid/{deviceId}
        [HttpGet("deviceid/{deviceId}")]
        public ResponseSerializer GetByDeviceId(String deviceId)
        {
            return new ResponseSerializer(
                200,
                "success",
                this._deviceBus.GetDevicesByDeviceId(deviceId));
        }

        // POST api/values
        [HttpPost]
        public ResponseSerializer Post([FromBody] DeviceSerializer deviceSerializer)
        {
            return new ResponseSerializer(
                200,
                "success",
                this._deviceBus.CreateNewDevice(deviceSerializer));
        }

        // PUT api/values/{id}
        [HttpPut("{id}")]
        public ResponseSerializer Put(int id, [FromBody] DeviceSerializer deviceSerializer)
        {
            return new ResponseSerializer(
                200,
                "success",
                this._deviceBus.UpdateDevice(id, deviceSerializer));
        }

        // DELETE api/values/{id}
        [HttpDelete("{id}")]
        public ResponseSerializer Delete(int id)
        {
            return new ResponseSerializer(
                200,
                "success",
                this._deviceBus.DeleteDevice(id));
        }

        [HttpPost("batch/devices")]
        public ResponseSerializer BatchDelete([FromBody] BatchNumber batchNumber)
        {
            return new ResponseSerializer(
                200,
                "success",
                this._deviceBus.BatchDeleteDevice(batchNumber.number));
        }

        [HttpGet("workshop/{workshopName}")]
        public ResponseSerializer GetByDeviceWorkshop(String workshopName)
        {
            return new ResponseSerializer(
                200,
                "success",
                this._deviceBus.GetDeviceByWorkshop(workshopName));
        }
    }
}