using IoTManager.IDao;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using IoTManager.Model;
using IoTManager.Utility;

namespace IoTManager.Dao
{
    public sealed class DeviceDao:IDeviceDao
    {
        public List<DeviceModel> Get()
        {
            using (var connection = new SqlConnection(Constant.getDatabaseConnectionString()))
            {
                return connection.Query<DeviceModel>("select device.id, " +
                                                     "hardwareDeviceID, " +
                                                     "deviceName, " +
                                                     "city.cityName as city, " +
                                                     "factory.factoryName as factory, " +
                                                     "workshop.workshopName as workshop, " +
                                                     "deviceState, " +
                                                     "imageUrl, " +
                                                     "gatewayID, " +
                                                     "mac, " +
                                                     "deviceType, " +
                                                     "device.remark, " +
                                                     "lastConnectionTime, " +
                                                     "device.createTime, " +
                                                     "device.updateTime " +
                                                     "from device " +
                                                     "join city on city.id=device.city " +
                                                     "join factory on factory.id=device.factory " +
                                                     "join workshop on workshop.id=device.workshop")
                    .ToList();
            }
        }

        public DeviceModel GetById(int id)
        {
            using (var connection = new SqlConnection(Constant.getDatabaseConnectionString()))
            {
                return connection.Query<DeviceModel>("select device.id, " +
                                                     "hardwareDeviceID, " +
                                                     "deviceName, " +
                                                     "city.cityName as city, " +
                                                     "factory.factoryName as factory, " +
                                                     "workshop.workshopName as workshop, " +
                                                     "deviceState, " +
                                                     "imageUrl, " +
                                                     "gatewayID, " +
                                                     "mac, " +
                                                     "deviceType, " +
                                                     "device.remark, " +
                                                     "lastConnectionTime, " +
                                                     "device.createTime, " +
                                                     "device.updateTime " +
                                                     "from device " +
                                                     "join city on city.id=device.city " +
                                                     "join factory on factory.id=device.factory " +
                                                     "join workshop on workshop.id=device.workshop " +
                                                     "where device.id=@deviceId", new
                {
                    deviceId = id
                }).FirstOrDefault();
            }
        }

        public List<DeviceModel> GetByDeviceName(String deviceName)
        {
            using (var connection = new SqlConnection(Constant.getDatabaseConnectionString()))
            {
                return connection.Query<DeviceModel>("select device.id, " +
                                                     "hardwareDeviceID, " +
                                                     "deviceName, " +
                                                     "city.cityName as city, " +
                                                     "factory.factoryName as factory, " +
                                                     "workshop.workshopName as workshop, " +
                                                     "deviceState, " +
                                                     "imageUrl, " +
                                                     "gatewayID, " +
                                                     "mac, " +
                                                     "deviceType, " +
                                                     "device.remark, " +
                                                     "lastConnectionTime, " +
                                                     "device.createTime, " +
                                                     "device.updateTime " +
                                                     "from device " +
                                                     "join city on city.id=device.city " +
                                                     "join factory on factory.id=device.factory " +
                                                     "join workshop on workshop.id=device.workshop " +
                                                     "where device.deviceName like '%"+deviceName+"%'")
                    .ToList();
            }
        }

        public List<DeviceModel> GetByDeviceId(String deviceId)
        {
            using (var connection = new SqlConnection(Constant.getDatabaseConnectionString()))
            {
                return connection.Query<DeviceModel>("select device.id, " +
                                                     "hardwareDeviceID, " +
                                                     "deviceName, " +
                                                     "city.cityName as city, " +
                                                     "factory.factoryName as factory, " +
                                                     "workshop.workshopName as workshop, " +
                                                     "deviceState, " +
                                                     "imageUrl, " +
                                                     "gatewayID, " +
                                                     "mac, " +
                                                     "deviceType, " +
                                                     "device.remark, " +
                                                     "lastConnectionTime, " +
                                                     "device.createTime, " +
                                                     "device.updateTime " +
                                                     "from device " +
                                                     "join city on city.id=device.city " +
                                                     "join factory on factory.id=device.factory " +
                                                     "join workshop on workshop.id=device.workshop " +
                                                     "where device.hardwareDeviceID like '%"+deviceId+"%'")
                    .ToList();
            }
        }

        public String Create(DeviceModel deviceModel)
        {
            using (var connection = new SqlConnection(Constant.getDatabaseConnectionString()))
            {
                CityModel city = connection.Query<CityModel>(
                    "SELECT * FROM city WHERE city.cityName=@cn", new
                    {
                        cn = deviceModel.City
                    }).FirstOrDefault();
                FactoryModel factory = connection.Query<FactoryModel>(
                    "SELECT * FROM factory WHERE factory.factoryName=@fn", new
                    {
                        fn = deviceModel.Factory
                    }).FirstOrDefault();
                WorkshopModel workshop = connection.Query<WorkshopModel>(
                    "SELECT * FROM workshop WHERE workshop.workshopName=@wn", new
                    {
                        wn = deviceModel.Workshop
                    }).FirstOrDefault();
                int rows = connection.Execute(
                    "INSERT INTO "+ 
                    "device(hardwareDeviceID, deviceName, city, factory, workshop, deviceState, imageUrl, gatewayId, mac, deviceType, remark)" +
                    " VALUES (@hdid, @dn, @c, @f, @w, @ds, @iu, @gid, @m, @dt, @r)", new
                    {
                        hdid = deviceModel.HardwareDeviceId,
                        dn = deviceModel.DeviceName,
                        c = city.Id,
                        f = factory.Id,
                        w = workshop.Id,
                        ds = deviceModel.DeviceState,
                        iu = deviceModel.ImageUrl,
                        gid = deviceModel.GatewayId,
                        m = deviceModel.Mac,
                        dt = deviceModel.DeviceType,
                        r = deviceModel.Remark
                    });
                return rows == 1 ? "success" : "error";
            }
        }

        public String Update(int id, DeviceModel deviceModel)
        {
            using (var connection = new SqlConnection(Constant.getDatabaseConnectionString()))
            {
                CityModel city = connection.Query<CityModel>(
                    "SELECT * FROM city WHERE city.cityName=@cn", new
                    {
                        cn = deviceModel.City
                    }).FirstOrDefault();
                FactoryModel factory = connection.Query<FactoryModel>(
                    "SELECT * FROM factory WHERE factory.factoryName=@fn", new
                    {
                        fn = deviceModel.Factory
                    }).FirstOrDefault();
                WorkshopModel workshop = connection.Query<WorkshopModel>(
                    "SELECT * FROM workshop WHERE workshop.workshopName=@wn", new
                    {
                        wn = deviceModel.Workshop
                    }).FirstOrDefault();
                int rows = connection
                    .Execute(
                        "UPDATE device "+
                        "SET hardwareDeviceID=@hdid, " +
                        "deviceName=@dn, " +
                        "city=@c, " +
                        "factory=@f, " +
                        "workshop=@w, " +
                        "deviceState=@ds, " +
                        "imageUrl=@iu, " +
                        "gatewayId=@gid, " +
                        "mac=@m, " +
                        "deviceType=@dt, " +
                        "remark=@r, " +
                        "updateTime=CURRENT_TIMESTAMP " +
                        "WHERE device.id=@deviceId",
                        new
                        {
                            deviceId = deviceModel.Id,
                            hdid = deviceModel.HardwareDeviceId,
                            dn = deviceModel.DeviceName,
                            c = city.Id,
                            f = factory.Id,
                            w = workshop.Id,
                            ds = deviceModel.DeviceState,
                            iu = deviceModel.ImageUrl,
                            gid = deviceModel.GatewayId,
                            m = deviceModel.Mac,
                            dt = deviceModel.DeviceType,
                            r = deviceModel.Remark
                        });
                return rows == 1 ? "success" : "error";
            }
        }

        public String Delete(int id)
        {
            using (var connection = new SqlConnection(Constant.getDatabaseConnectionString()))
            {
                int rows = connection.Execute("DELETE FROM device WHERE device.id=@deviceId", new
                {
                    deviceId = id
                });
                return rows == 1 ? "success" : "error";
            }
        }

        public int BatchDelete(int[] ids)
        {
            using (var connection = new SqlConnection(Constant.getDatabaseConnectionString()))
            {
                int rows = 0;
                foreach (int i in ids)
                {
                    connection.Execute("DELETE FROM device WHERE device.id=@deviceId", new
                    {
                        deviceId = i
                    });
                    rows = rows + 1;
                }
                return rows;
            }
        }

        public List<DeviceModel> GetByWorkshop(String workshop)
        {
            using (var connection = new SqlConnection(Constant.getDatabaseConnectionString()))
            {
                return connection.Query<DeviceModel>("select device.id, " +
                                                     "hardwareDeviceID, " +
                                                     "deviceName, " +
                                                     "city.cityName as city, " +
                                                     "factory.factoryName as factory, " +
                                                     "workshop.workshopName as workshop, " +
                                                     "deviceState, " +
                                                     "imageUrl, " +
                                                     "gatewayID, " +
                                                     "mac, " +
                                                     "deviceType, " +
                                                     "device.remark, " +
                                                     "lastConnectionTime, " +
                                                     "device.createTime, " +
                                                     "device.updateTime " +
                                                     "from device " +
                                                     "join city on city.id=device.city " +
                                                     "join factory on factory.id=device.factory " +
                                                     "join workshop on workshop.id=device.workshop " +
                                                     "where workshop in (select id from workshop where workshopName=@wn)", new
                    {
                        wn = workshop
                    })
                    .ToList();
            }
        }
    }
}
