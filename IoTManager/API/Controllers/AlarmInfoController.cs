using System;
using IoTManager.Core.Infrastructures;
using IoTManager.Utility.Serializers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IoTManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlarmInfoController
    {
        private readonly IAlarmInfoBus _alarmInfoBus;
        private readonly ILogger _logger;

        public AlarmInfoController(IAlarmInfoBus alarmInfoBus, ILogger<AlarmInfoController> logger)
        {
            this._alarmInfoBus = alarmInfoBus;
            this._logger = logger;
        }
        
        //GET api/alarmInfo
        [HttpGet]
        public ResponseSerializer Get()
        {
            return new ResponseSerializer(
                200,
                "success",
                _alarmInfoBus.GetAllAlarmInfo());
        }

        [HttpGet("id/{Id}")]
        public ResponseSerializer GetById(String Id)
        {
            return new ResponseSerializer(
                200,
                "success",
                _alarmInfoBus.GetAlarmInfoById(Id));
        }

        [HttpGet("deviceId/{DeviceId}")]
        public ResponseSerializer GetByDeviceId(String DeviceId)
        {
            return new ResponseSerializer(
                200,
                "success",
                _alarmInfoBus.GetAlarmInfoByDeviceId(DeviceId));
        }

        [HttpGet("indexId/{IndexId}")]
        public ResponseSerializer GetByIndexId(String IndexId)
        {
            return new ResponseSerializer(
                200,
                "success",
                _alarmInfoBus.GetAlarmInfoByIndexId(IndexId));
        }
    }
}