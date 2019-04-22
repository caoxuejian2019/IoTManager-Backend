using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
    public class UserController : ControllerBase
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

                var users = dbcon.User
                    .Include(u => u.Company)
                    .Include(u => u.Department)
                    .ToList();
                
                
                /************************************
                 * Serialize the Result
                 ************************************/
                
                List<UserFormalizer> results = new List<UserFormalizer>();

                foreach (User u in users)
                {
                    results.Add(new UserFormalizer(u));
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
                 * Find the User with Certain Id
                 ************************************/
                
                var user = dbcon.User
                    .Include(u => u.Company)
                    .Include(u => u.Department)
                    .Single(u => u.Id == id);
                
                /************************************
                 * Serialize the Result
                 ************************************/
                
                UserFormalizer result = new UserFormalizer(user);
                
                
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
        public Result Post([FromBody] UserFormalizer user)
        {
            using (DatabaseContext dbcon = new DatabaseContext())
            {
                /************************************
                 * Create A New User Model
                 ************************************/
                
                User newUser = new User();
                
                
                /************************************
                 * Process New User Information
                 ************************************/
                
                //Basic Information
                newUser.UserName = user.userName;
                newUser.DisplayName = user.displayName;
                newUser.Password = user.password;
                newUser.Email = user.email;
                newUser.PhoneNumber = user.phoneNumber;
                newUser.Remark = user.remark;
                
                //Basic Time Information
                newUser.CreateTime = DateTime.Now;
                newUser.UpdateTime = DateTime.Now;
                
                //Information Based on Relation
                //Company
                Company userCompany = dbcon.Company
                    .Single(c => c.companyName == user.company);
                newUser.Company = userCompany;
                newUser.CompanyId = userCompany.id;
                
                //Department
                Department userDepartment = dbcon.Department
                    .Single(d => d.departmentName == user.department);
                newUser.Department = userDepartment;
                newUser.DepartmentId = userDepartment.id;
                
                
                /************************************
                 * Save and Return
                 ************************************/

                dbcon.User.Add(newUser);
                dbcon.SaveChanges();
                
                return new Result(
                    200,
                    "success",
                    user
                );
            }
        }

        // PUT api/values/{id}
        [HttpPut("{id}")]
        public Result Put(int id, [FromBody] UserFormalizer newUser)
        {
            using (DatabaseContext dbcon = new DatabaseContext())
            {
                /************************************
                 * Find the Old User Information
                 ************************************/

                User oldUser = dbcon.Find<User>(id);
                
                
                /************************************
                 * Process the New User Information
                 ************************************/
                
                //Basic Information
                oldUser.UserName = newUser.userName;
                oldUser.DisplayName = newUser.displayName;
                oldUser.Password = newUser.password;
                oldUser.Email = newUser.email;
                oldUser.PhoneNumber = newUser.phoneNumber;
                oldUser.Remark = newUser.remark;
                
                //Basic Time Information
                oldUser.UpdateTime = DateTime.Now;
                
                //Information Based on Relation
                //Company
                Company userCompany = dbcon.Company
                    .Single(c => c.companyName == newUser.company);
                oldUser.Company = userCompany;
                oldUser.CompanyId = userCompany.id;
                
                //Department
                Department userDepartment = dbcon.Department
                    .Single(d => d.departmentName == newUser.department);
                oldUser.Department = userDepartment;
                oldUser.DepartmentId = userDepartment.id;
                
                
                /************************************
                 * Serialize the Old User Information
                 ************************************/
                
                UserFormalizer result = new UserFormalizer(oldUser);
                
                
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
                
                var user = dbcon.User
                    .Include(u => u.Company)
                    .Include(u => u.Department)
                    .Single(u => u.Id == id);
                
                
                /************************************
                 * Serialize the Deleted Device
                 ************************************/
                
                UserFormalizer result = new UserFormalizer(user);
                
                
                /************************************
                 * Delete and Return the Deleted Device
                 ************************************/

                dbcon.User.Remove(user);
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