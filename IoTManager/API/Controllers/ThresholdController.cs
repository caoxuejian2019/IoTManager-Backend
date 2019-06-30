using System;
using IoTManager.Core.Infrastructures;
using IoTManager.Utility.Serializers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IoTManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThresholdController
    {
        private readonly IThresholdBus _thresholdBus;
        private readonly ILogger _logger;

        public ThresholdController(IThresholdBus thresholdBus, ILogger<ThresholdController> logger)
        {
            this._thresholdBus = thresholdBus;
            this._logger = logger;
        }

        [HttpGet("{id}")]
        public ResponseSerializer GetByDeviceId(String id)
        {
            return new ResponseSerializer(
                200,
                "success",
                _thresholdBus.GetByDeviceId(id));
        }
    }
}