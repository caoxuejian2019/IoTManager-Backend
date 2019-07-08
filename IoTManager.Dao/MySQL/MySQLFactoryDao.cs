using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using IoTManager.IDao;
using IoTManager.Model;
using IoTManager.Utility;
using IoTManager.Utility.Serializers;

namespace IoTManager.Dao
{
    public sealed class MySQLFactoryDao: IFactoryDao
    {
        public List<FactoryModel> Get()
        {
            using (var connection = new SqlConnection(Constant.getDatabaseConnectionString()))
            {
                List<FactoryModel> factoryModels = connection
                    .Query<FactoryModel>("SELECT factory.id, " +
                                         "factoryName, " +
                                         "factoryPhoneNumber, " +
                                         "factoryAddress, " +
                                         "factory.remark, " +
                                         "factory.createTime,"+
                                         " factory.updateTime, " +
                                         "city.cityName AS city " +
                                         "FROM factory " +
                                         "JOIN city ON factory.city=city.id")
                    .ToList();
                return factoryModels;
            }
        }

        public FactoryModel GetById(int id)
        {
            using (var connection = new SqlConnection(Constant.getDatabaseConnectionString()))
            {
                return connection
                    .Query<FactoryModel>("SELECT factory.id, " +
                                         "factoryName, " +
                                         "factoryPhoneNumber, " +
                                         "factoryAddress, " +
                                         "factory.remark, " +
                                         "factory.createTime,"+
                                         " factory.updateTime, " +
                                         "city.cityName AS city " +
                                         "FROM factory " +
                                         "JOIN city ON factory.city=city.id " +
                                         "WHERE factory.id=@factoryId", new
                    {
                        factoryId = id
                    }).FirstOrDefault();
            }
        }

        public String Create(FactoryModel factoryModel)
        {
            using (var connection = new SqlConnection(Constant.getDatabaseConnectionString()))
            {
                CityModel city = connection
                    .Query<CityModel>("SELECT * FROM city WHERE cityName=@cn", new
                    {
                        cn = factoryModel.City
                    }).FirstOrDefault();
                int rows = connection.Execute(
                    "INSERT INTO factory(factoryName, factoryPhoneNumber, factoryAddress, remark, city) VALUES (@fn, @fpn, @fa, @r, @c)", new
                    {
                        fn = factoryModel.FactoryName,
                        fpn = factoryModel.FactoryPhoneNumber,
                        fa = factoryModel.FactoryAddress,
                        r = factoryModel.Remark,
                        c = city.Id
                    });
                return rows == 1 ? "success" : "error";
            }
        }

        public String Update(int id, FactoryModel factoryModel)
        {
            using (var connection = new SqlConnection(Constant.getDatabaseConnectionString()))
            {
                CityModel city = connection
                    .Query<CityModel>("SELECT * FROM city WHERE cityName=@cn", new
                    {
                        cn = factoryModel.City
                    }).FirstOrDefault();
                int rows = connection.Execute(
                    "UPDATE factory SET factoryName=@fn, factoryPhoneNumber=@fpn, factoryAddress=@fa, remark=@r, city=@c, updateTime=CURRENT_TIMESTAMP WHERE id=@factoryId",
                    new
                    {
                        fn = factoryModel.FactoryName,
                        fpn = factoryModel.FactoryPhoneNumber,
                        fa = factoryModel.FactoryAddress,
                        r = factoryModel.Remark,
                        c = city.Id,
                        factoryId = id
                    });
                return rows == 1 ? "success" : "error";
            }
        }

        public String Delete(int id)
        {
            using (var connection = new SqlConnection(Constant.getDatabaseConnectionString()))
            {
                int rows = connection.Execute("DELETE FROM factory WHERE id=@factoryId", new
                {
                    factoryId = id
                });
                return rows == 1 ? "success" : "error";
            }
        }
    }
}