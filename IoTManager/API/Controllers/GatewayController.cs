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
                gateway.lastConnectionTime = DateTime.Now;
                gateway.createTime = DateTime.Now;
                gateway.updateTime = DateTime.Now;
                dbcon.gateway.Add(gateway);
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
                oldGateway.hardwareGatewayID = newGateway.hardwareGatewayID;
                oldGateway.gatewayName = newGateway.gatewayName;
                oldGateway.gatewayType = newGateway.gatewayType;
                oldGateway.city = newGateway.city;
                oldGateway.factory = newGateway.factory;
                oldGateway.workshop = newGateway.workshop;
                oldGateway.gatewayState = newGateway.gatewayState;
                oldGateway.imageUrl = newGateway.imageUrl;
                oldGateway.updateTime = DateTime.Now;
                oldGateway.remark = newGateway.remark;
                oldGateway.department = newGateway.department;
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
                dbcon.gateway.Remove(dbcon.Find<Gateway>(id));
                return new Result(
                    200,
                    "success",
                    "success"
                    );
            }
        }
    }
}