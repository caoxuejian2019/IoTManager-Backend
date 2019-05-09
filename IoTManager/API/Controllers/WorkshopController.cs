using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IoTManager.API.Formalizers;
using IoTManager.Core.Infrastructures;
using IoTManager.DAL.DbContext;
using IoTManager.DAL.Models;
using IoTManager.DAL.ReturnType;
using IoTManager.Utility.Serializers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace IoTManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkshopController : ControllerBase
    {
        private readonly IWorkshopBus _workshopBus;
        private readonly ILogger _logger;

        public WorkshopController(IWorkshopBus workshopBus, ILogger<WorkshopController> logger)
        {
            this._workshopBus = workshopBus;
            this._logger = logger;
        }
        // GET api/values
        [HttpGet]
        public ResponseSerializer Get()
        {
            return new ResponseSerializer(
                200,
                "success",
                this._workshopBus.GetAllWorkshops());
        }

        // GET api/values/{id}
        [HttpGet("{id}")]
        public ResponseSerializer Get(int id)
        {
            return new ResponseSerializer(
                200,
                "success",
                this._workshopBus.GetWorkshopById(id));
        }

        // POST api/values
        [HttpPost]
        public ResponseSerializer Post([FromBody] WorkshopSerializer workshopSerializer)
        {
            return new ResponseSerializer(
                200,
                "success",
                this._workshopBus.CreateNewWorkshop(workshopSerializer));
        }

        // PUT api/values/{id}
        [HttpPut("{id}")]
        public ResponseSerializer Put(int id, [FromBody] WorkshopSerializer workshopSerializer)
        {
            return new ResponseSerializer(
                200,
                "success",
                this._workshopBus.UpdateWorkshop(id, workshopSerializer));
        }

        // DELETE api/values/{id}
        [HttpDelete("{id}")]
        public ResponseSerializer Delete(int id)
        {
            return new ResponseSerializer(
                200,
                "success",
                this._workshopBus.DeleteWorkshop(id));
        }
    }
}