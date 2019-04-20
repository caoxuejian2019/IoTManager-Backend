using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IoTManager.API.Formalizers;
using Microsoft.AspNetCore.Mvc;
using IoTManager.DAL.ReturnType;
using IoTManager.DAL.Models;
using IoTManager.DAL.DbContext;
using Microsoft.AspNetCore.WebSockets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace IoTManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public Result Get()
        {
            using (DatabaseContext dbcon = new DatabaseContext())
            {
                var devices = dbcon.Set<Device>()
                    .Include(d => d.City)
                    .Include(d => d.Factory)
                    .Include(d => d.Workshop)
                    .Include(d => d.DeviceState)
                    .Include(d => d.DeviceType)
                    .Include(d => d.Department)
                    .ToList();
                List<DeviceFormalizer> results = new List<DeviceFormalizer>();
                foreach (Device d in devices)
                {
                    results.Add(new DeviceFormalizer(d));
                }
                return new Result(
                    200,
                    "success",
                    results
                    );
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Result Get(int id)
        {
            using (DatabaseContext dbcon = new DatabaseContext())
            {
                var device = dbcon.Set<Device>()
                    .Include(d => d.City)
                    .Include(d => d.Factory)
                    .Include(d => d.Workshop)
                    .Include(d => d.DeviceState)
                    .Include(d => d.DeviceType)
                    .Include(d => d.Department)
                    .Where(d => d.Id == id)
                    .ToList();
                DeviceFormalizer result = new DeviceFormalizer(device[0]);
                return new Result(
                    200,
                    "success",
                    result
                    );
            }
        }

        // POST api/values
        [HttpPost]
        public Result Post([FromBody] Device device)
        {
            using (DatabaseContext dbcon = new DatabaseContext())
            {
                device.LastConnectionTime = DateTime.Now;
                device.CreateTime = DateTime.Now;
                device.UpdateTime = DateTime.Now;
                dbcon.device.Add(device);
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
        public Result Put(int id, [FromBody] Device newDevice)
        {
            using (DatabaseContext dbcon = new DatabaseContext())
            {
                DateTime ctime;
                Device oldDevice = dbcon.Find<Device>(id);
                oldDevice.HardwareDeviceId = newDevice.HardwareDeviceId;
                oldDevice.DeviceName = newDevice.DeviceName;
                oldDevice.City = newDevice.City;
                oldDevice.Factory = newDevice.Factory;
                oldDevice.Workshop = newDevice.Workshop;
                oldDevice.DeviceState = newDevice.DeviceState;
                oldDevice.ImageUrl = newDevice.ImageUrl;
                oldDevice.GatewayId = newDevice.GatewayId;
                oldDevice.Mac = newDevice.Mac;
                oldDevice.DeviceType = newDevice.DeviceType;
                oldDevice.UpdateTime = DateTime.Now;
                oldDevice.Remark = newDevice.Remark;
                oldDevice.Department = newDevice.Department;
                dbcon.Update<Device>(oldDevice);
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
                dbcon.device.Remove(dbcon.Find<Device>(id));
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