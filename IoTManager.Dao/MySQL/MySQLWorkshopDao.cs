using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using IoTManager.IDao;
using IoTManager.Model;
using IoTManager.Utility;

namespace IoTManager.Dao
{
    public sealed class MySQLWorkshopDao: IWorkshopDao
    {
        public List<WorkshopModel> Get()
        {
            using (var connection = new SqlConnection(Constant.getDatabaseConnectionString()))
            {
                List<WorkshopModel> workshopModels = connection
                    .Query<WorkshopModel>("SELECT workshop.id, " +
                                          "workshopName, " +
                                          "workshopPhoneNumber, " +
                                          "workshopAddress, " +
                                          "workshop.remark, " +
                                          "workshop.createTime, " +
                                          "workshop.updateTime, " +
                                          "factory.factoryName AS factory " +
                                          "FROM workshop JOIN factory " +
                                          "ON workshop.factory=factory.id")
                    .ToList();
                return workshopModels;
            }
        }

        public WorkshopModel GetById(int id)
        {
            using (var connection = new SqlConnection(Constant.getDatabaseConnectionString()))
            {
                WorkshopModel workshopModel = connection
                    .Query<WorkshopModel>("SELECT workshop.id, " +
                                          "workshopName, " +
                                          "workshopPhoneNumber, " +
                                          "workshopAddress, " +
                                          "workshop.remark, " +
                                          "workshop.createTime, " +
                                          "workshop.updateTime, " +
                                          "factory.factoryName AS factory " +
                                          "FROM workshop JOIN factory " +
                                          "ON workshop.factory=factory.id " +
                                          "WHERE workshop.id=@workshopId", new
                    {
                        workshopId = id
                    }).FirstOrDefault();
                return workshopModel;
            }
        }

        public String Create(WorkshopModel workshopModel)
        {
            using (var connection = new SqlConnection(Constant.getDatabaseConnectionString()))
            {
                FactoryModel factory = connection
                    .Query<FactoryModel>("SELECT * FROM factory WHERE factoryName=@fn", new
                    {
                        fn = workshopModel.Factory
                    }).FirstOrDefault();
                int rows = connection
                    .Execute(
                        "INSERT INTO workshop(workshopName, workshopPhoneNumber, workshopAddress, remark, factory) VALUES (@wn, @wpn, @wa, @r, @f)", new
                        {
                            wn = workshopModel.WorkshopName,
                            wpn = workshopModel.WorkshopPhoneNumber,
                            wa = workshopModel.WorkshopAddress,
                            r = workshopModel.Remark,
                            f = factory.Id
                        });
                return rows == 1 ? "success" : "error";
            }
        }

        public String Update(int id, WorkshopModel workshopModel)
        {
            using (var connection = new SqlConnection(Constant.getDatabaseConnectionString()))
            {
                FactoryModel factory = connection
                    .Query<FactoryModel>("SELECT * FROM factory WHERE factoryName=@fn", new
                    {
                        fn = workshopModel.Factory
                    }).FirstOrDefault();
                int rows = connection
                    .Execute(
                        "UPDATE workshop SET workshopName=@wn, workshopPhoneNumber=@wpn, workshopAddress=@wa, remark=@r, factory=@f, updateTime=CURRENT_TIMESTAMP WHERE id=@workshopId",
                        new
                        {
                            wn = workshopModel.WorkshopName,
                            wpn = workshopModel.WorkshopPhoneNumber,
                            wa = workshopModel.WorkshopAddress,
                            r = workshopModel.Remark,
                            f = factory.Id,
                            workshopId = id
                        });
                return rows == 1 ? "success" : "error";
            }
        }

        public String Delete(int id)
        {
            using (var connection = new SqlConnection(Constant.getDatabaseConnectionString()))
            {
                int rows = connection.Execute("DELETE FROM workshop WHERE id=@workshopId", new
                {
                    workshopId = id
                });
                return rows == 1 ? "success" : "error";
            }
        }
    }
}