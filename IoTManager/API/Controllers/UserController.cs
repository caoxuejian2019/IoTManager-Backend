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
    public class UserController : ControllerBase
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
                    dbcon.Set<User>().ToList()
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
                    dbcon.Find<User>(id)
                    );
            }
        }

        // POST api/values
        [HttpPost]
        public Result Post([FromBody] User user)
        {
            using (DatabaseContext dbcon = new DatabaseContext())
            {
                user.createTime = DateTime.Now;
                user.updateTime = DateTime.Now;
                dbcon.user.Add(user);
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
        public Result Put(int id, [FromBody] User newUser)
        {
            using (DatabaseContext dbcon = new DatabaseContext())
            {
                User oldUser = dbcon.Find<User>(id);
                oldUser.userName = newUser.userName;
                oldUser.displayName = newUser.displayName;
                oldUser.password = newUser.password;
                oldUser.email = newUser.email;
                oldUser.company = newUser.company;
                oldUser.phoneNumber = newUser.phoneNumber;
                oldUser.updateTime  = DateTime.Now;
                oldUser.remark = newUser.remark;
                oldUser.department = newUser.department;
                dbcon.Update<User>(oldUser);
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
                dbcon.user.Remove(dbcon.Find<User>(id));
                dbcon.SaveChanges();
                return new Result(
                    200,
                    "success",
                    "success"
                );
            }
        }
    }
}