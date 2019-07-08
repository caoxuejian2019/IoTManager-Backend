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
    public sealed class MySQLUserDao:IUserDao
    {
        public String Create(UserModel userModel)
        {
            using (var connection = new SqlConnection(Constant.getDatabaseConnectionString()))
            {
                int rows = connection.Execute(
                    "INSERT INTO account(userName, displayName, password, email, phoneNumber, remark) VALUES (@un, @dn, @p, @e, @pn, @r)",
                    new
                    {
                        un = userModel.UserName,
                        dn = userModel.DisplayName,
                        p = userModel.Password,
                        e = userModel.Email,
                        pn = userModel.PhoneNumber,
                        r = userModel.Remark
                    });
                return rows == 1 ? "success" : "error";
            }
        }

        public List<UserModel> Get()
        {
            using (var connection = new SqlConnection(Constant.getDatabaseConnectionString()))
            {
                return connection
                    .Query<UserModel>("SELECT * FROM account")
                    .ToList();
            }
        }

        public UserModel GetById(int id)
        {
            using (var connection = new SqlConnection(Constant.getDatabaseConnectionString()))
            {
                return connection
                    .Query<UserModel>("SELECT * FROM account WHERE id=@userId", new
                    {
                        userId = id
                    }).FirstOrDefault();
            }
        }

        public UserModel GetByUserName(String userName)
        {
            using (var connection = new SqlConnection(Constant.getDatabaseConnectionString()))
            {
                return connection
                    .Query<UserModel>("SELECT * FROM account WHERE userName=@uName", new
                    {
                        uName = userName
                    }).FirstOrDefault();
            }
        }

        public String Update(int id, UserModel userModel)
        {
            using (var connection = new SqlConnection(Constant.getDatabaseConnectionString()))
            {
                int rows = connection
                    .Execute(
                        "UPDATE account SET userName=@un, displayName=@dn, password=@p, email=@e, phoneNumber=@pn, remark=@r, updateTime=CURRENT_TIMESTAMP WHERE id=@userId",
                        new
                        {
                            userId = userModel.Id,
                            un = userModel.UserName,
                            dn = userModel.DisplayName,
                            p = userModel.Password,
                            e = userModel.Email,
                            pn = userModel.PhoneNumber,
                            r = userModel.Remark
                        });
                return rows == 1 ? "success" : "error";
            }
        }

        public String Delete(int id)
        {
            using (var connection = new SqlConnection(Constant.getDatabaseConnectionString()))
            {
                int rows = connection.Execute("DELETE FROM account WHERE id=@userId", new
                {
                    userId = id
                });
                return rows == 1 ? "success" : "error";
            }
        }
    }
}
