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
    public sealed class GatewayDao:IGatewayDao
    {
        public List<GatewayModel> Get()
        {
            using (var connection = new SqlConnection(Constant.getDatabaseConnectionString()))
            {
                return connection.Query<GatewayModel>("select gateway.id, " +
                                                      "hardwareGatewayID," +
                                                      " gatewayName," +
                                                      " gatewayType, " +
                                                      "city.cityName as city, " +
                                                      "factory.factoryName as factory, " +
                                                      "workshop.workshopName as workshop, " +
                                                      "gatewayState, " +
                                                      "imageUrl, " +
                                                      "gateway.remark, " +
                                                      "gateway.lastConnectionTime, " +
                                                      "gateway.createTime, " +
                                                      "gateway.updateTime from gateway " +
                                                      "join city on city.id=gateway.city " +
                                                      "join factory on factory.id=gateway.factory " +
                                                      "join workshop on workshop.id=gateway.workshop")
                    .ToList();
            }
        }

        public GatewayModel GetById(int id)
        {
            using (var connection = new SqlConnection(Constant.getDatabaseConnectionString()))
            {
                return connection.Query<GatewayModel>("select gateway.id, " +
                                                      "hardwareGatewayID," +
                                                      " gatewayName," +
                                                      " gatewayType, " +
                                                      "city.cityName as city, " +
                                                      "factory.factoryName as factory, " +
                                                      "workshop.workshopName as workshop, " +
                                                      "gatewayState, " +
                                                      "imageUrl, " +
                                                      "gateway.remark, " +
                                                      "gateway.lastConnectionTime, " +
                                                      "gateway.createTime, " +
                                                      "gateway.updateTime from gateway " +
                                                      "join city on city.id=gateway.city " +
                                                      "join factory on factory.id=gateway.factory " +
                                                      "join workshop on workshop.id=gateway.workshop " +
                                                      "where gateway.id=@gatewayId", new
                {
                    gatewayId = id
                }).FirstOrDefault();
            }
        }

        public String Create(GatewayModel gatewayModel)
        {
            using (var connection = new SqlConnection(Constant.getDatabaseConnectionString()))
            {
                CityModel city = connection.Query<CityModel>(
                    "SELECT * FROM city WHERE city.cityName=@cn", new
                    {
                        cn = gatewayModel.City
                    }).FirstOrDefault();
                FactoryModel factory = connection.Query<FactoryModel>(
                    "SELECT * FROM factory WHERE factory.factoryName=@fn", new
                    {
                        fn = gatewayModel.Factory
                    }).FirstOrDefault();
                WorkshopModel workshop = connection.Query<WorkshopModel>(
                    "SELECT * FROM workshop WHERE workshop.workshopName=@wn", new
                    {
                        wn = gatewayModel.Workshop
                    }).FirstOrDefault();
                int rows = connection.Execute(
                    "INSERT INTO gateway(hardwareGatewayID, gatewayName, city, factory, workshop, gatewayType, gatewayState, imageUrl, remark)" +
                    " VALUES(@hgid, @gn, @c, @f, @w, @gt, @gs, @iu, @r)", new
                    {
                        hgid = gatewayModel.HardwareGatewayId,
                        gn = gatewayModel.GatewayName,
                        c = city.Id,
                        f = factory.Id,
                        w = workshop.Id,
                        gt = gatewayModel.GatewayType,
                        gs = gatewayModel.GatewayState,
                        iu = gatewayModel.ImageUrl,
                        r = gatewayModel.Remark
                    });
                return rows == 1 ? "success" : "error";
            }
        }

        public String Update(int id, GatewayModel gatewayModel)
        {
            using (var connection = new SqlConnection(Constant.getDatabaseConnectionString()))
            {
                CityModel city = connection.Query<CityModel>(
                    "SELECT * FROM city WHERE city.cityName=@cn", new
                    {
                        cn = gatewayModel.City
                    }).FirstOrDefault();
                FactoryModel factory = connection.Query<FactoryModel>(
                    "SELECT * FROM factory WHERE factory.factoryName=@fn", new
                    {
                        fn = gatewayModel.Factory
                    }).FirstOrDefault();
                WorkshopModel workshop = connection.Query<WorkshopModel>(
                    "SELECT * FROM workshop WHERE workshop.workshopName=@wn", new
                    {
                        wn = gatewayModel.Workshop
                    }).FirstOrDefault();
                int rows = connection.Execute(
                    "UPDATE gateway SET hardwareGatewayID=@hgid, gatewayName=@gn, city=@c, factory=@f, workshop=@w, gatewayType=@gt, gatewayState=@gs, imageUrl=@iu, remark=@r, updateTime=CURRENT_TIMESTAMP WHERE id=@gatewayId",
                    new
                    {
                        gatewayId = id,
                        hgid = gatewayModel.HardwareGatewayId,
                        gn = gatewayModel.GatewayName,
                        c = city.Id,
                        f = factory.Id,
                        w = workshop.Id,
                        gt = gatewayModel.GatewayType,
                        gs = gatewayModel.GatewayState,
                        iu = gatewayModel.ImageUrl,
                        r = gatewayModel.Remark
                    });
                return rows == 1 ? "success" : "error";
            }
        }

        public String Delete(int id)
        {
            using (var connection = new SqlConnection(Constant.getDatabaseConnectionString()))
            {
                int rows = connection.Execute("DELETE FROM gateway WHERE id=@gatewayId", new
                {
                    gatewayId = id
                });
                return rows == 1 ? "success" : "error";
            }
        }

        public List<GatewayModel> GetByWorkshop(String workshop)
        {
            using (var connection = new SqlConnection(Constant.getDatabaseConnectionString()))
            {
                return connection.Query<GatewayModel>("select gateway.id, " +
                                                      "hardwareGatewayID," +
                                                      " gatewayName," +
                                                      " gatewayType, " +
                                                      "city.cityName as city, " +
                                                      "factory.factoryName as factory, " +
                                                      "workshop.workshopName as workshop, " +
                                                      "gatewayState, " +
                                                      "imageUrl, " +
                                                      "gateway.remark, " +
                                                      "gateway.lastConnectionTime, " +
                                                      "gateway.createTime, " +
                                                      "gateway.updateTime from gateway " +
                                                      "join city on city.id=gateway.city " +
                                                      "join factory on factory.id=gateway.factory " +
                                                      "join workshop on workshop.id=gateway.workshop " +
                                                      "where gateway.workshop in (select id from workshop where workshopName=@wn)", new
                    {
                        wn = workshop
                    })
                    .ToList();
            }
        }
    }
}
