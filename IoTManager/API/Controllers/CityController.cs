using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IoTManager.API.Formalizers;
using IoTManager.Core.Infrastructures;
using IoTManager.DAL.DbContext;
using IoTManager.DAL.Models;
using IoTManager.Model;
using IoTManager.Utility;
using IoTManager.Utility.Serializers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MySqlX.XDevAPI.Common;
using Result = IoTManager.DAL.ReturnType.Result;

namespace IoTManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityBus _cityBus;
        private readonly ILogger _logger;
        public CityController(ICityBus cityBus,ILogger<CityController> logger)
        {
            this._cityBus = cityBus;
            this._logger = logger;
        }

        // GET api/values
        [HttpGet]
        public List<CitySerializer> Get()
        {
            List<CityModel> cities = this._cityBus.GetAllCities();
            List<CitySerializer> result = new List<CitySerializer>();
            foreach (CityModel city in cities)
            {
                result.Add(new CitySerializer(city));
            }
            return result;
        }

        // GET api/values/{id}
        [HttpGet("{id}")]
        public CitySerializer Get(int id)
        {
            CityModel city = this._cityBus.GetCityById(id);
            CitySerializer result = new CitySerializer(city);
            return result;
        }

        // POST api/values
        [HttpPost]
        public String Post([FromBody] CitySerializer citySerializer)
        {
            CityModel cityModel = new CityModel();
            cityModel.CityName = citySerializer.cityName;
            cityModel.Remark = citySerializer.remark;
            return this._cityBus.CreateNewCity(cityModel);
        }

        // PUT api/values/{id}
        [HttpPut("{id}")]
        public String Put(int id, [FromBody] CitySerializer citySerializer)
        {
            CityModel cityModel = new CityModel();
            cityModel.Id = id;
            cityModel.CityName = citySerializer.cityName;
            cityModel.Remark = citySerializer.remark;
            return this._cityBus.UpdateCity(id, cityModel);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public String Delete(int id)
        {
            return this._cityBus.DeleteCity(id);
        }
    }
}