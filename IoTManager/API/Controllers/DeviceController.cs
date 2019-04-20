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
                    .Single(d => d.Id == id);
                DeviceFormalizer result = new DeviceFormalizer(device);
                return new Result(
                    200,
                    "success",
                    result
                    );
            }
        }

        // POST api/values
        [HttpPost]
        public object Post([FromBody] DeviceFormalizer device)
        {
            using (DatabaseContext dbcon = new DatabaseContext())
            {
                Device newDevice = new Device();
                
                
                //Basic Information
                newDevice.Id = device.id;
                newDevice.HardwareDeviceId = device.hardwareDeviceID;
                newDevice.DeviceName = device.deviceName;
                newDevice.ImageUrl = device.imageUrl;
                newDevice.GatewayId = device.gatewayID;
                newDevice.Mac = device.mac;
                newDevice.Remark = device.remark;

                
                //Basic Time Information
                newDevice.LastConnectionTime = DateTime.Now;
                newDevice.CreateTime = DateTime.Now;
                newDevice.UpdateTime = DateTime.Now;
                
                
                //Information Based on Relation
                
                //City
                City deviceCity = dbcon.Set<City>()
                    .Single(c => c.cityName == device.city);
                newDevice.City = deviceCity;
                newDevice.CityId = deviceCity.id;

                //Factory
                Factory deviceFactory = dbcon.Set<Factory>()
                    .Single(f => f.factoryName == device.factory);
                newDevice.Factory = deviceFactory;
                newDevice.FactoryId = deviceFactory.id;

                //Workshop
                Workshop deviceWorkshop = dbcon.Set<Workshop>()
                    .Single(w => w.workshopName == device.workshop);
                newDevice.Workshop = deviceWorkshop;
                newDevice.WorkshopId = deviceWorkshop.id;

                //DeviceState
                DeviceState deviceDeviceState = dbcon.Set<DeviceState>()
                    .Single(ds => ds.stateName == device.deviceState);
                newDevice.DeviceState = deviceDeviceState;
                newDevice.DeviceStateId = deviceDeviceState.id;

                //DeviceType
                DeviceType deviceDeviceType = dbcon.Set<DeviceType>()
                    .Single(dt => dt.deviceTypeName == device.deviceType);
                newDevice.DeviceType = deviceDeviceType;
                newDevice.DeviceTypeId = deviceDeviceType.id;

                //Department
                Department deviceDepartment = dbcon.Set<Department>()
                    .Single(d => d.departmentName == device.department);
                newDevice.Department = deviceDepartment;
                newDevice.DepartmentId = deviceDepartment.id;


                dbcon.Device.Add(newDevice);
                dbcon.SaveChanges();

                return new Result(
                    200,
                    "success",
                    newDevice
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
                dbcon.Device.Remove(dbcon.Find<Device>(id));
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