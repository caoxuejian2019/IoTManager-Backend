using System;
using IoTManager.Utility.Serializers;
using Microsoft.AspNetCore.Mvc;

namespace IoTManager.API.Controllers
{
    [Route("/api")]
    public class LoginController: ControllerBase
    {
        [HttpPost("login")]
        public ResponseSerializer Login()
        {
            return new ResponseSerializer(
                200,
                "success",
                123);
        }
    }
}