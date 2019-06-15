using IoTManager.Core.Infrastructures;
using IoTManager.Utility.Serializers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IoTManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceDataController
    {
        private readonly IDeviceDataBus _deviceDataBus;
        private readonly ILogger _logger;

        public DeviceDataController(IDeviceDataBus deviceDataBus, ILogger<DeviceDataController> logger)
        {
            this._deviceDataBus = deviceDataBus;
            this._logger = logger;
        }

        //GET api/deviceData
        [HttpGet]
        public ResponseSerializer Get()
        {
            return new ResponseSerializer(
                200,
                "success",
                this._deviceDataBus.GetAllDeviceData());
        }
    }
}