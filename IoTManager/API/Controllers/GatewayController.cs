using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using IoTManager.API.Formalizers;
using Microsoft.AspNetCore.Mvc;
using IoTManager.DAL.Models;
using IoTManager.DAL.DbContext;
using IoTManager.DAL.ReturnType;
using Microsoft.EntityFrameworkCore;

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
                /************************************
                 * Find All Gateways from the Database
                 ************************************/

                var gateways = dbcon.Gateway
                    .Include(g => g.GatewayType)
                    .Include(g => g.City)
                    .Include(g => g.Factory)
                    .Include(g => g.Workshop)
                    .Include(g => g.GatewayState)
                    .Include(g => g.Department)
                    .ToList();

                
                /************************************
                 * Serialize the Result
                 ************************************/

                List<GatewayFormalizer> results = new List<GatewayFormalizer>();

                foreach (Gateway g in gateways)
                {
                    results.Add(new GatewayFormalizer(g));
                }
                
                
                /************************************
                 * Return
                 ************************************/
                
                return new Result(
                    200,
                    "success",
                    results
                );
            }
        }

        // GET api/values/{id}
        [HttpGet("{id}")]
        public Result Get(int id)
        {
            using (DatabaseContext dbcon = new DatabaseContext())
            {
                /************************************
                 * Find the Gateway with Certain Id
                 ************************************/

                var gateway = dbcon.Gateway
                    .Include(g => g.GatewayType)
                    .Include(g => g.City)
                    .Include(g => g.Factory)
                    .Include(g => g.Workshop)
                    .Include(g => g.GatewayState)
                    .Include(g => g.Department)
                    .Single(g => g.Id == id);
                
                
                /************************************
                 * Serialize the Result
                 ************************************/
                
                GatewayFormalizer result = new GatewayFormalizer(gateway);
                
                
                /************************************
                 * Return
                 ************************************/
                
                return new Result(
                    200, 
                    "success",
                    result
                );
            }
        }

        // POST api/values
        [HttpPost]
        public Result Post([FromBody] GatewayFormalizer gateway)
        {
            using (DatabaseContext dbcon = new DatabaseContext())
            {
                /************************************
                 * Create A New Gateway Model
                 ************************************/
                
                Gateway newGateway = new Gateway();
                
                
                /************************************
                 * Process New Gateway Information
                 ************************************/
                
                //Basic Information
                newGateway.HardwareGatewayId = gateway.hardwareGatewayID;
                newGateway.GatewayName = gateway.gatewayName;
                newGateway.ImageUrl = gateway.imageUrl;
                newGateway.Remark = gateway.remark;
                
                //Basic Time Information
                newGateway.LastConnectionTime = DateTime.Now;
                newGateway.CreateTime = DateTime.Now;
                newGateway.UpdateTime = DateTime.Now;
                
                //Information Based on Relation
                //GatewayState
                GatewayState gatewayGatewayState = dbcon.GatewayState
                    .Single(gs => gs.StateName == gateway.gatewayState);
                newGateway.GatewayState = gatewayGatewayState;
                newGateway.GatewayStateId = gatewayGatewayState.Id;
                
                //GatewayType
                GatewayType gatewayGatewayType = dbcon.GatewayType
                    .Single(gt => gt.GatewayTypeName == gateway.gatewayType);
                newGateway.GatewayType = gatewayGatewayType;
                newGateway.GatewayTypeId = gatewayGatewayType.Id;
                
                //City
                City gatewayCity = dbcon.City
                    .Single(c => c.CityName == gateway.city);
                newGateway.City = gatewayCity;
                newGateway.CityId = gatewayCity.Id;
                
                //Factory
                Factory gatewayFactory = dbcon.Factory
                    .Single(f => f.FactoryName == gateway.factory);
                newGateway.Factory = gatewayFactory;
                newGateway.FactoryId = gatewayFactory.Id;
                
                //Workshop
                Workshop gatewayWorkshop = dbcon.Workshop
                    .Single(w => w.WorkshopName == gateway.workshop);
                newGateway.Workshop = gatewayWorkshop;
                newGateway.WorkshopId = gatewayWorkshop.Id;
                
                //Department
                Department gatewayDepartment = dbcon.Department
                    .Single(d => d.DepartmentName == gateway.department);
                newGateway.Department = gatewayDepartment;
                newGateway.DepartmentId = gatewayDepartment.Id;
                
                
                /************************************
                 * Save and Return
                 ************************************/

                dbcon.Gateway.Add(newGateway);
                dbcon.SaveChanges();
                
                return new Result(
                    200,
                    "success",
                    gateway
                );
            }
        }

        // PUT api/values/{id}
        [HttpPut("{id}")]
        public Result Put(int id, [FromBody] GatewayFormalizer newGateway)
        {
            using (DatabaseContext dbcon = new DatabaseContext())
            {
                /************************************
                 * Find the Old Gateway Information
                 ************************************/

                Gateway oldGateway = dbcon.Find<Gateway>(id);
                
                
                /************************************
                 * Process the New Gateway Information
                 ************************************/
                
                //Basic Information
                oldGateway.HardwareGatewayId = newGateway.hardwareGatewayID;
                oldGateway.GatewayName = newGateway.gatewayName;
                oldGateway.ImageUrl = newGateway.imageUrl;
                oldGateway.Remark = newGateway.remark;
                
                //Basic Time Information
                oldGateway.UpdateTime = DateTime.Now;
                
                //Information Based on Relation
                //GatewayState
                GatewayState gatewayGatewayState = dbcon.GatewayState
                    .Single(gs => gs.StateName == newGateway.gatewayState);
                oldGateway.GatewayState = gatewayGatewayState;
                oldGateway.GatewayStateId = gatewayGatewayState.Id;
                
                //GatewayType
                GatewayType gatewayGatewayType = dbcon.GatewayType
                    .Single(gt => gt.GatewayTypeName == newGateway.gatewayType);
                oldGateway.GatewayType = gatewayGatewayType;
                oldGateway.GatewayTypeId = gatewayGatewayType.Id;
                
                //City
                City gatewayCity = dbcon.City
                    .Single(c => c.CityName == newGateway.city);
                oldGateway.City = gatewayCity;
                oldGateway.CityId = gatewayCity.Id;
                
                //Factory
                Factory gatewayFactory = dbcon.Factory
                    .Single(f => f.FactoryName == newGateway.factory);
                oldGateway.Factory = gatewayFactory;
                oldGateway.FactoryId = gatewayFactory.Id;
                
                //Workshop
                Workshop gatewayWorkshop = dbcon.Workshop
                    .Single(w => w.WorkshopName == newGateway.workshop);
                oldGateway.Workshop = gatewayWorkshop;
                oldGateway.WorkshopId = gatewayWorkshop.Id;
                
                //Department
                Department gatewayDepartment = dbcon.Department
                    .Single(d => d.DepartmentName == newGateway.department);
                oldGateway.Department = gatewayDepartment;
                oldGateway.DepartmentId = gatewayDepartment.Id;
                
                
                /************************************
                 * Serialize the Old Gateway Information
                 ************************************/
                
                GatewayFormalizer result = new GatewayFormalizer(oldGateway);
                
                
                /************************************
                 * Save and Return
                 ************************************/

                dbcon.SaveChanges();
                
                return new Result(
                    200,
                    "success",
                    result
                );
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public Result Delete(int id)
        {
            using (DatabaseContext dbcon = new DatabaseContext())
            {
                /************************************
                 * Find the Gateway To Delete
                 ************************************/
                
                var gateway = dbcon.Gateway
                    .Include(g => g.GatewayType)
                    .Include(g => g.City)
                    .Include(g => g.Factory)
                    .Include(g => g.Workshop)
                    .Include(g => g.GatewayState)
                    .Include(g => g.Department)
                    .Single(g => g.Id == id);
                
                
                /************************************
                 * Serialize the Deleted Gateway
                 ************************************/
                
                GatewayFormalizer result = new GatewayFormalizer(gateway);
                
                
                /************************************
                 * Delete and Return the Deleted Gateway
                 ************************************/

                dbcon.Gateway.Remove(gateway);
                dbcon.SaveChanges();
                
                return new Result(
                    200,
                    "success",
                    result
                );
            }
        }
    }
}