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
                    .Include(d => d.city)
                    .Include(d => d.factory)
                    .Include(d => d.workshop)
                    .Include(d => d.deviceState)
                    .Include(d => d.deviceType)
                    .Include(d => d.department)
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
                return new Result(
                    200,
                    "success",
                    dbcon.Find<Device>(id)
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
                device.createTime = DateTime.Now;
                device.updateTime = DateTime.Now;
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
                oldDevice.hardwareDeviceID = newDevice.hardwareDeviceID;
                oldDevice.deviceName = newDevice.deviceName;
                oldDevice.city = newDevice.city;
                oldDevice.factory = newDevice.factory;
                oldDevice.workshop = newDevice.workshop;
                oldDevice.deviceState = newDevice.deviceState;
                oldDevice.imageUrl = newDevice.imageUrl;
                oldDevice.gatewayID = newDevice.gatewayID;
                oldDevice.mac = newDevice.mac;
                oldDevice.deviceType = newDevice.deviceType;
                oldDevice.updateTime = DateTime.Now;
                oldDevice.remark = newDevice.remark;
                oldDevice.department = newDevice.department;
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