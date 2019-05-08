using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IoTManager.API.Formalizers;
using IoTManager.Core.Infrastructures;
using IoTManager.DAL.DbContext;
using IoTManager.DAL.Models;
using IoTManager.IDao;
using IoTManager.Utility.Serializers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MySqlX.XDevAPI.Common;
using Swashbuckle.AspNetCore.Swagger;
using Result = IoTManager.DAL.ReturnType.Result;

namespace IoTManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FactoryController : ControllerBase
    {
        private readonly IFactoryBus _factoryBus;
        private readonly ILogger _logger;

        public FactoryController(IFactoryBus factoryBus, ILogger<FactoryController> logger)
        {
            this._factoryBus = factoryBus;
            this._logger = logger;
        }
        // GET api/values
        [HttpGet]
        public ResponseSerializer Get()
        {
            return new ResponseSerializer(
                200,
                "success",
                this._factoryBus.GetAllFactories());
        }

        // GET api/values/{id}
        [HttpGet("{id}")]
        public ResponseSerializer Get(int id)
        {
            return new ResponseSerializer(
                200,
                "success",
                this._factoryBus.GetFactoryById(id));
        }

        // POST api/values
        [HttpPost]
        public ResponseSerializer Post([FromBody] FactorySerializer factorySerializer)
        {
            return new ResponseSerializer(
                200,
                "success",
                this._factoryBus.CreateNewFactory(factorySerializer));
        }

        // PUT api/values/{id}
        [HttpPut("{id}")]
        public ResponseSerializer Put(int id, [FromBody] FactorySerializer factorySerializer)
        {
            return new ResponseSerializer(
                200,
                "success",
                this._factoryBus.UpdateFactory(id, factorySerializer));
        }

        // DELETE api/values/{id}
        [HttpDelete("{id}")]
        public ResponseSerializer Delete(int id)
        {
            return new ResponseSerializer(
                200,
                "success",
                this._factoryBus.DeleteFactory(id));
        }
    }
}