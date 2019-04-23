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
    public class CityController : ControllerBase
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

                var cities = dbcon.City
                    .ToList();
                
                
                /************************************
                 * Serialize the Result
                 ************************************/
                
                List<CityFormalizer> results = new List<CityFormalizer>();

                foreach (City c in cities)
                {
                    results.Add(new CityFormalizer(c));
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
                 * Find the City with Certain Id
                 ************************************/

                var city = dbcon.City
                    .Single(c => c.Id == id);
                
                
                /************************************
                 * Serialize the Result
                 ************************************/
                
                CityFormalizer result = new CityFormalizer(city);
                
                
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
        public Result Post([FromBody] CityFormalizer city)
        {
            using (DatabaseContext dbcon = new DatabaseContext())
            {
                /************************************
                 * Create A New City Model
                 ************************************/
                
                City newCity = new City();
                
                
                /************************************
                 * Process New City Information
                 ************************************/

                //Basic Information
                newCity.CityName = city.cityName;
                newCity.Remark = city.remark;
                
                //Basic Time Information
                newCity.CreateTime = DateTime.Now;
                newCity.UpdateTime = DateTime.Now;
                
                
                /************************************
                 * Save and Return
                 ************************************/

                dbcon.City.Add(newCity);
                dbcon.SaveChanges();
                
                return new Result(
                    200,
                    "success",
                    city
                );
            }
        }

        // PUT api/values/{id}
        [HttpPut("{id}")]
        public Result Put(int id, [FromBody] CityFormalizer newCity)
        {
            using (DatabaseContext dbcon = new DatabaseContext())
            {
                /************************************
                 * Find the Old City Information
                 ************************************/

                City oldCity = dbcon.Find<City>(id);
                
                
                /************************************
                 * Process the New City Information
                 ************************************/
                
                //Basic Information
                oldCity.CityName = newCity.cityName;
                oldCity.Remark = newCity.remark;
                
                //Basic Time Information
                oldCity.UpdateTime = newCity.updateTime;
                
                
                /************************************
                 * Serialize the Old City Information
                 ************************************/
                CityFormalizer result = new CityFormalizer(oldCity);
                
                
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
                 * Find the City To Delete
                 ************************************/

                var city = dbcon.City
                    .Single(c => c.Id == id);
                
                
                /************************************
                 * Serialize the Deleted City
                 ************************************/
                
                CityFormalizer result = new CityFormalizer(city);
                
                
                /************************************
                 * Delete and Return the Deleted City
                 ************************************/

                dbcon.City.Remove(city);
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