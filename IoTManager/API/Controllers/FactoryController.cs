using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IoTManager.API.Formalizers;
using IoTManager.DAL.DbContext;
using IoTManager.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI.Common;
using Result = IoTManager.DAL.ReturnType.Result;

namespace IoTManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FactoryController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public Result Get()
        {
            using (DatabaseContext dbcon = new DatabaseContext())
            {
                /************************************
                 * Find All Factories from the Database
                 ************************************/

                var factories = dbcon.Factory
                    .Include(f => f.City)
                    .ToList();
                
                
                /************************************
                 * Serialize the Result
                 ************************************/
                
                List<FactoryFormalizer> results = new List<FactoryFormalizer>();

                foreach (Factory f in factories)
                {
                    results.Add(new FactoryFormalizer(f));
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
                 * Find the Factory with Certain Id
                 ************************************/

                var factory = dbcon.Factory
                    .Include(f => f.City)
                    .Single(f => f.Id == id);
                
                
                /************************************
                 * Serialize the Result
                 ************************************/
                
                FactoryFormalizer result = new FactoryFormalizer(factory);
                
                
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
        public Result Post([FromBody] FactoryFormalizer factory)
        {
            using (DatabaseContext dbcon = new DatabaseContext())
            {
                /************************************
                 * Create A New Factory Model
                 ************************************/
                
                Factory newFactory = new Factory();
                
                
                /************************************
                 * Process New Factory Information
                 ************************************/
                
                //Basic Information
                newFactory.FactoryName = factory.factoryName;
                newFactory.FactoryPhoneNumber = factory.factoryPhoneNumber;
                newFactory.FactoryAddress = factory.factoryAddress;
                newFactory.Remark = factory.remark;
                
                //Basic Time Information
                newFactory.CreateTime = DateTime.Now;
                newFactory.UpdateTime = DateTime.Now;
                
                //Information Based on Relation
                //City
                City factoryCity = dbcon.City
                    .Single(c => c.CityName == factory.city);
                newFactory.City = factoryCity;
                newFactory.CityId = factoryCity.Id;
                
                
                /************************************
                 * Save and Return
                 ************************************/

                dbcon.Factory.Add(newFactory);
                dbcon.SaveChanges();
                
                return new Result(
                    200,
                    "success",
                    factory
                );
            }
        }

        // PUT api/values/{id}
        [HttpPut("{id}")]
        public Result Put(int id, [FromBody] FactoryFormalizer newFactory)
        {
            using (DatabaseContext dbcon = new DatabaseContext())
            {
                /************************************
                 * Find the Old Factory Information
                 ************************************/

                Factory oldFactory = dbcon.Find<Factory>(id);
                
                
                /************************************
                 * Process the New Factory Information
                 ************************************/
                
                //Basic Information
                oldFactory.FactoryName = newFactory.factoryName;
                oldFactory.FactoryPhoneNumber = newFactory.factoryPhoneNumber;
                oldFactory.FactoryAddress = newFactory.factoryAddress;
                oldFactory.Remark = newFactory.remark;
                
                //Basic Time Information
                oldFactory.UpdateTime = DateTime.Now;
                
                //Information Based on Relation
                //City
                City factoryCity = dbcon.City
                    .Single(c => c.CityName == newFactory.city);
                oldFactory.City = factoryCity;
                oldFactory.CityId = factoryCity.Id;
                
                
                /************************************
                 * Serialize the Old Factory Information
                 ************************************/
                
                FactoryFormalizer result = new FactoryFormalizer(oldFactory);
                
                
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

        // DELETE api/values/{id}
        [HttpDelete("{id}")]
        public Result Delete(int id)
        {
            using (DatabaseContext dbcon = new DatabaseContext())
            {
                /************************************
                 * Find the Factory To Delete
                 ************************************/

                var factory = dbcon.Factory
                    .Include(f => f.City)
                    .Single(f => f.Id == id);
                
                
                /************************************
                 * Serialize the Deleted Factory
                 ************************************/
                
                FactoryFormalizer result = new FactoryFormalizer(factory);
                
                
                /************************************
                 * Delete and Return the Deleted Factory
                 ************************************/

                dbcon.Factory.Remove(factory);
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