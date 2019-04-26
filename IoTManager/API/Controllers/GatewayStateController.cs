using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IoTManager.API.Formalizers;
using IoTManager.DAL.DbContext;
using IoTManager.DAL.Models;
using IoTManager.DAL.ReturnType;
using Microsoft.AspNetCore.Mvc;

namespace IoTManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GatewayStateController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public Result Get()
        {
            using (DatabaseContext dbcon = new DatabaseContext())
            {
                /************************************
                 * Find All GatewayStates from the Database
                 ************************************/

                var gatewayStates = dbcon.GatewayState
                    .ToList();
                
                
                /************************************
                 * Serialize the Result
                 ************************************/
                
                List<GatewayStateFormalizer> results = new List<GatewayStateFormalizer>();

                foreach (GatewayState gs in gatewayStates)
                {
                    results.Add(new GatewayStateFormalizer(gs));
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

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}