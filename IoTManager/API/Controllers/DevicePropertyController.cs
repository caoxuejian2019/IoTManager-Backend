using System;
using IoTManager.Core.Infrastructures;
using IoTManager.Utility.Serializers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IoTManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevicePropertyController : ControllerBase
    {
        private readonly IDevicePropertyBus _devicePropertyBus;
        private readonly ILogger _logger;
        public DevicePropertyController(IDevicePropertyBus devicePropertyBus,ILogger<DevicePropertyController> logger)
        {
            this._devicePropertyBus = devicePropertyBus;
            this._logger = logger;
        }
        [HttpGet("id/{Id}")]
        public ResponseSerializer GetById(String Id)
        {
            return new ResponseSerializer(
                200,
                "success",
                this._devicePropertyBus.GetDevicePropertyById(Id));
        }
        [HttpGet("deviceid/{deviceid}/property/{property}")]

    }
}
