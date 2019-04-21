using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IoTManager.DAL.Models;
using IoTManager.DAL.DbContext;
using IoTManager.DAL.ReturnType;

namespace IoTManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GatewayController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public Result Get()
        {
            using (DatabaseContext dbcon = new DatabaseContext())
            {
                return new Result(
                    200,
                    "success", 
                    dbcon.Set<Gateway>().ToList()
                    );
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Result Get(int id)
        {
            using (DatabaseContext dbcon = new DatabaseContext())
            {
                return new Result(
                    200,
                    "success",
                    dbcon.Find<Gateway>(id)
                    );
            }
        }

        // POST api/values
        [HttpPost]
        public Result Post([FromBody] Gateway gateway)
        {
            using (DatabaseContext dbcon = new DatabaseContext())
            {
                gateway.LastConnectionTime = DateTime.Now;
                gateway.CreateTime = DateTime.Now;
                gateway.UpdateTime = DateTime.Now;
                dbcon.Gateway.Add(gateway);
                dbcon.SaveChanges();
                return new Result(
                    200,
                    "success",
                    "success"
                    );
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public Result Put(int id, [FromBody] Gateway newGateway)
        {
            using (DatabaseContext dbcon = new DatabaseContext())
            {
                Gateway oldGateway = dbcon.Find<Gateway>(id);
                oldGateway.HardwareGatewayId = newGateway.HardwareGatewayId;
                oldGateway.GatewayName = newGateway.GatewayName;
                oldGateway.GatewayType = newGateway.GatewayType;
                oldGateway.City = newGateway.City;
                oldGateway.Factory = newGateway.Factory;
                oldGateway.Workshop = newGateway.Workshop;
                oldGateway.GatewayState = newGateway.GatewayState;
                oldGateway.ImageUrl = newGateway.ImageUrl;
                oldGateway.UpdateTime = DateTime.Now;
                oldGateway.Remark = newGateway.Remark;
                oldGateway.Department = newGateway.Department;
                dbcon.Update<Gateway>(oldGateway);
                dbcon.SaveChanges();
                return new Result(
                    200,
                    "success",
                    "success"
                    );
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public Result Delete(int id)
        {
            using (DatabaseContext dbcon = new DatabaseContext())
            {
                dbcon.Gateway.Remove(dbcon.Find<Gateway>(id));
                return new Result(
                    200,
                    "success",
                    "success"
                    );
            }
        }
    }
}