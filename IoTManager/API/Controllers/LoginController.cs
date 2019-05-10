using System;
using Microsoft.AspNetCore.Mvc;

namespace IoTManager.API.Controllers
{
    [Route("/api")]
    public class LoginController: ControllerBase
    {
        [HttpPost("login")]
        public object Login()
        {
            return new {user = "123", asdf = 1234};
        }
    }
}