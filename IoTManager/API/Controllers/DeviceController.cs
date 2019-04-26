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
                /************************************
                 * Find All Devices from the Database
                 ************************************/
                
                var devices = dbcon.Device
                    .Include(d => d.City)
                    .Include(d => d.Factory)
                    .Include(d => d.Workshop)
                    .Include(d => d.DeviceState)
                    .Include(d => d.DeviceType)
                    .Include(d => d.Department)
                    .ToList();
                
                
                /************************************
                 * Serialize the Result
                 ************************************/
                
                List<DeviceFormalizer> results = new List<DeviceFormalizer>();
                
                foreach (Device d in devices)
                {
                    results.Add(new DeviceFormalizer(d));
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
                 * Find the Device with Certain Id
                 ************************************/
                
                var device = dbcon.Device
                    .Include(d => d.City)
                    .Include(d => d.Factory)
                    .Include(d => d.Workshop)
                    .Include(d => d.DeviceState)
                    .Include(d => d.DeviceType)
                    .Include(d => d.Department)
                    .Single(d => d.Id == id);
                
                
                /************************************
                 * Serialize the Result
                 ************************************/
                
                DeviceFormalizer result = new DeviceFormalizer(device);
                
                
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
        public object Post([FromBody] DeviceFormalizer device)
        {
            using (DatabaseContext dbcon = new DatabaseContext())
            {
                /************************************
                 * Create A New Device Model
                 ************************************/
                
                Device newDevice = new Device();
                
                
                /************************************
                 * Process New Device Information
                 ************************************/
                
                //Basic Information
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
                City deviceCity = dbcon.City
                    .Single(c => c.CityName == device.city);
                newDevice.City = deviceCity;
                newDevice.CityId = deviceCity.Id;

                //Factory
                Factory deviceFactory = dbcon.Factory
                    .Single(f => f.FactoryName == device.factory);
                newDevice.Factory = deviceFactory;
                newDevice.FactoryId = deviceFactory.Id;

                //Workshop
                Workshop deviceWorkshop = dbcon.Workshop
                    .Single(w => w.WorkshopName == device.workshop);
                newDevice.Workshop = deviceWorkshop;
                newDevice.WorkshopId = deviceWorkshop.Id;

                //DeviceState
                DeviceState deviceDeviceState = dbcon.DeviceState
                    .Single(ds => ds.stateName == device.deviceState);
                newDevice.DeviceState = deviceDeviceState;
                newDevice.DeviceStateId = deviceDeviceState.id;

                //DeviceType
                DeviceType deviceDeviceType = dbcon.DeviceType
                    .Single(dt => dt.deviceTypeName == device.deviceType);
                newDevice.DeviceType = deviceDeviceType;
                newDevice.DeviceTypeId = deviceDeviceType.id;

                //Department
                Department deviceDepartment = dbcon.Department
                    .Single(d => d.DepartmentName == device.department);
                newDevice.Department = deviceDepartment;
                newDevice.DepartmentId = deviceDepartment.Id;


                /************************************
                 * Save and Return
                 ************************************/
                
                dbcon.Device.Add(newDevice);
                dbcon.SaveChanges();

                return new Result(
                    200,
                    "success",
                    device
                );
            }
        }

        // PUT api/values/{id}
        [HttpPut("{id}")]
        public Result Put(int id, [FromBody] DeviceFormalizer newDevice)
        {
            using (DatabaseContext dbcon = new DatabaseContext())
            {
                /************************************
                 * Find the Old Device Information
                 ************************************/
                Device oldDevice = dbcon.Find<Device>(id);
                
                
                /************************************
                 * Process the New Device Information
                 ************************************/
                
                //Basic Information
                oldDevice.HardwareDeviceId = newDevice.hardwareDeviceID;
                oldDevice.DeviceName = newDevice.deviceName;
                oldDevice.ImageUrl = newDevice.imageUrl;
                oldDevice.GatewayId = newDevice.gatewayID;
                oldDevice.Mac = newDevice.mac;
                oldDevice.Remark = newDevice.remark;
                
                //Basic Time Information
                oldDevice.UpdateTime = DateTime.Now;
                
                //Information Based on Relation
                //City
                City deviceCity = dbcon.City
                    .Single(c => c.CityName == newDevice.city);
                oldDevice.City = deviceCity;
                oldDevice.CityId = deviceCity.Id;
                
                //Factory
                Factory deviceFactory = dbcon.Factory
                    .Single(f => f.FactoryName == newDevice.factory);
                oldDevice.Factory = deviceFactory;
                oldDevice.FactoryId = deviceFactory.Id;
                
                //Workshop
                Workshop deviceWorkshop = dbcon.Workshop
                    .Single(w => w.WorkshopName == newDevice.workshop);
                oldDevice.Workshop = deviceWorkshop;
                oldDevice.WorkshopId = deviceWorkshop.Id;
                
                //DeviceState
                DeviceState deviceDeviceState = dbcon.DeviceState
                    .Single(ds => ds.stateName == newDevice.deviceState);
                oldDevice.DeviceState = deviceDeviceState;
                oldDevice.DeviceStateId = deviceDeviceState.id;
                
                //DeviceType
                DeviceType deviceDeviceType = dbcon.DeviceType
                    .Single(dt => dt.deviceTypeName == newDevice.deviceType);
                oldDevice.DeviceType = deviceDeviceType;
                oldDevice.DeviceTypeId = deviceDeviceType.id;
                
                //Department
                Department deviceDepartment = dbcon.Department
                    .Single(d => d.DepartmentName == newDevice.department);
                oldDevice.Department = deviceDepartment;
                oldDevice.DepartmentId = deviceDepartment.Id;
                
                
                /************************************
                 * Serialize the Old Device Information
                 ************************************/
                
                DeviceFormalizer result = new DeviceFormalizer(oldDevice);
                
                
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
                 * Find the Device To Delete
                 ************************************/
                
                Device device = dbcon.Device
                    .Include(d => d.City)
                    .Include(d => d.Factory)
                    .Include(d => d.Workshop)
                    .Include(d => d.DeviceState)
                    .Include(d => d.DeviceType)
                    .Include(d => d.Department)
                    .Single(d => d.Id == id);
                
                
                /************************************
                 * Serialize the Deleted Device
                 ************************************/
                
                DeviceFormalizer result = new DeviceFormalizer(device);
                
                
                /************************************
                 * Delete and Return the Deleted Device
                 ************************************/
                
                dbcon.Device.Remove(device);
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