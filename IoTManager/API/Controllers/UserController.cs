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
                user.create_time = DateTime.Now;
                user.update_time = DateTime.Now;
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
                DateTime ctime;
                User oldUser = dbcon.Find<User>(id);
                oldUser.username = newUser.username;
                oldUser.nickname = newUser.nickname;
                oldUser.password = newUser.password;
                oldUser.email = newUser.email;
                oldUser.company = newUser.company;
                oldUser.phonenumber = newUser.phonenumber;
                oldUser.update_time  = DateTime.Now;
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