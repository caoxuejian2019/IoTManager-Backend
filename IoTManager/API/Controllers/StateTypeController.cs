using System;
using IoTManager.Core.Infrastructures;
using IoTManager.Utility.Serializers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace IoTManager.API.Controllers
{
    [Route("/api")]
    [ApiController]
    public class StateTypeController: ControllerBase
    {
        private readonly IStateTypeBus _stateTypeBus;
        private readonly ILogger _logger;

        public StateTypeController(IStateTypeBus stateTypeBus, ILogger<StateTypeController> logger)
        {
            this._stateTypeBus = stateTypeBus;
            this._logger = logger;
        }
        
        [HttpGet("deviceType")]
        public ResponseSerializer GetAllDeviceTypes()
        {
            return new ResponseSerializer(
                200,
                "success",
                this._stateTypeBus.GetAllDeviceTypes());
        }

        [HttpGet("deviceState")]
        public ResponseSerializer GetAllDeviceStates()
        {
            return new ResponseSerializer(
                200,
                "success",
                this._stateTypeBus.GetAllDeviceStates());
        }

        [HttpGet("gatewayType")]
        public ResponseSerializer GetAllGatewayTypes()
        {
            return new ResponseSerializer(
                200,
                "success",
                this._stateTypeBus.GetAllGatewayTypes());
        }

        [HttpGet("gatewayState")]
        public ResponseSerializer GetAllGatewayStates()
        {
            return new ResponseSerializer(
                200,
                "success",
                this._stateTypeBus.GetAllGatewayStates());
        }
    }
}