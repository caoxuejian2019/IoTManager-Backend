using System;
using IoTManager.Core.Infrastructures;
using IoTManager.Model;
using IoTManager.Utility.Serializers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IoTManager.API.Controllers
{
    [Route("api/[controller]")]
    public class LoginController: ControllerBase
    {
        private readonly ILoginBus _loginBus;
        private readonly ILogger _logger;

        public LoginController(ILoginBus loginBus, ILogger<LoginController> logger)
        {
            this._loginBus = loginBus;
            this._logger = logger;
        }
        
        [HttpPost]
        public ResponseSerializer Login([FromBody] LoginModel loginModel)
        {
            return new ResponseSerializer(
                200,
                this._loginBus.Login(loginModel),
                this._loginBus.Login(loginModel));
        }
    }
}