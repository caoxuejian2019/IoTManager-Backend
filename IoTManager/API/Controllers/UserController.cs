using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using IoTManager.API.Formalizers;
using IoTManager.API.Services;
using IoTManager.Core.Infrastructures;
using Microsoft.AspNetCore.Mvc;
using IoTManager.DAL.Models;
using IoTManager.DAL.DbContext;
using IoTManager.DAL.ReturnType;
using IoTManager.Utility.Serializers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace IoTManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBus _userBus;
        private readonly ILogger _logger;

        public UserController(IUserBus userBus, ILogger<UserController> logger)
        {
            this._userBus = userBus;
            this._logger = logger;
        }
        
        // GET api/values
        [HttpGet]
        public ResponseSerializer Get()
        {
            return new ResponseSerializer(
                200,
                "success",
                this._userBus.GetAllUsers()
                );
        }

        // GET api/values/{id}
        [HttpGet("{id}")]
        public ResponseSerializer Get(int id)
        {
            return new ResponseSerializer(
                200,
                "success",
                this._userBus.GetUserById(id)
                );
        }

        //GET api/user/username/{userName}
        [HttpGet("username/{userName}")]
        public ResponseSerializer GetByUserName(String userName)
        {
            return new ResponseSerializer(
                200,
                "success",
                this._userBus.GetUserByUserName(userName)
                );
        }

        // POST api/values
        [HttpPost]
        public ResponseSerializer Post([FromBody] UserSerializer userSerializer)
        {
            return new ResponseSerializer(
                200,
                "success",
                this._userBus.CreateNewUser(userSerializer)
                );
        }

        // PUT api/values/{id}
        [HttpPut("{id}")]
        public ResponseSerializer Put(int id, [FromBody] UserSerializer userSerializer)
        {
            return new ResponseSerializer(
                200,
                "success",
                this._userBus.UpdateUser(id, userSerializer)
                );
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ResponseSerializer Delete(int id)
        {
            return new ResponseSerializer(
                200,
                "success",
                this._userBus.DeleteUser(id)
                );
        }
    }
}