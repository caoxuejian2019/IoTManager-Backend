using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IoTManager.API.Formalizers;
using IoTManager.DAL.DbContext;
using IoTManager.DAL.Models;
using IoTManager.DAL.ReturnType;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IoTManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkshopController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public Result Get()
        {
            using (DatabaseContext dbcon = new DatabaseContext())
            {
                /************************************
                 * Find All Workshops from the Database
                 ************************************/

                var workshops = dbcon.Workshop
                    .Include(w => w.Factory)
                    .ToList();
                
                
                /************************************
                 * Serialize the Result
                 ************************************/
                
                List<WorkshopFormalizer> results = new List<WorkshopFormalizer>();

                foreach (Workshop w in workshops)
                {
                    results.Add(new WorkshopFormalizer(w));
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
                 * Find the Workshop with Certain Id
                 ************************************/

                var workshop = dbcon.Workshop
                    .Include(w => w.Factory)
                    .Single(w => w.Id == id);
                
                
                /************************************
                 * Serialize the Result
                 ************************************/
                
                WorkshopFormalizer result = new WorkshopFormalizer(workshop);
                
                
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
        public Result Post([FromBody] WorkshopFormalizer workshop)
        {
            using (DatabaseContext dbcon = new DatabaseContext())
            {
                /************************************
                 * Create A New Workshop Model
                 ************************************/
                
                Workshop newWorkshop = new Workshop();
                
                
                /************************************
                 * Process New Workshop Information
                 ************************************/
                
                //Basic Information
                newWorkshop.WorkshopName = workshop.workshopName;
                newWorkshop.WorkshopPhoneNumber = workshop.workshopPhoneNumber;
                newWorkshop.WorkshopAddress = workshop.workshopAddress;
                newWorkshop.Remark = workshop.remark;
                
                //Basic Time Information
                newWorkshop.CreateTime = DateTime.Now;
                newWorkshop.UpdateTime = DateTime.Now;
                
                //Information Based on Relation
                //Factory
                Factory workshopFactory = dbcon.Factory
                    .Single(f => f.FactoryName == workshop.factory);
                newWorkshop.Factory = workshopFactory;
                newWorkshop.FactoryId = workshopFactory.Id;
                
                
                /************************************
                 * Save and Return
                 ************************************/

                dbcon.Workshop.Add(newWorkshop);
                dbcon.SaveChanges();
                
                return new Result(
                    200,
                    "success",
                    workshop
                );
            }
        }

        // PUT api/values/{id}
        [HttpPut("{id}")]
        public Result Put(int id, [FromBody] WorkshopFormalizer newWorkshop)
        {
            using (DatabaseContext dbcon = new DatabaseContext())
            {
                /************************************
                 * Find the Old Workshop Information
                 ************************************/

                Workshop oldWorkshop = dbcon.Find<Workshop>(id);
                
                
                /************************************
                 * Process the New Workshop Information
                 ************************************/
                
                //Basic Information
                oldWorkshop.WorkshopName = newWorkshop.workshopName;
                oldWorkshop.WorkshopPhoneNumber = newWorkshop.workshopPhoneNumber;
                oldWorkshop.WorkshopAddress = newWorkshop.workshopAddress;
                oldWorkshop.Remark = newWorkshop.remark;
                
                //Basic Time Information
                oldWorkshop.UpdateTime = DateTime.Now;
                
                //Information Based on Relation
                Factory workshopFactory = dbcon.Factory
                    .Single(f => f.FactoryName == newWorkshop.factory);
                oldWorkshop.Factory = workshopFactory;
                oldWorkshop.FactoryId = workshopFactory.Id;
                
                
                /************************************
                 * Serialize the Old Workshop Information
                 ************************************/
                
                WorkshopFormalizer result = new WorkshopFormalizer(oldWorkshop);
                
                
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
                 * Find the Workshop To Delete
                 ************************************/

                var workshop = dbcon.Workshop
                    .Include(w => w.Factory)
                    .Single(w => w.Id == id);
                
                
                /************************************
                 * Serialize the Deleted Workshop
                 ************************************/
                
                WorkshopFormalizer result = new WorkshopFormalizer(workshop);
                
                
                /************************************
                 * Delete and Return the Deleted Workshop
                 ************************************/

                dbcon.Workshop.Remove(workshop);
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