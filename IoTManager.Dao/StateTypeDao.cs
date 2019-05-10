using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using IoTManager.IDao;
using IoTManager.Utility;

namespace IoTManager.Dao
{
    public sealed class StateTypeDao: IStateTypeDao
    {
        public List<String> GetDeviceType()
        {
            using (var connection = new SqlConnection(Constant.getDatabaseConnectionString()))
            {
                return connection
                    .Query<String>("SELECT configValue FROM config WHERE configTag='deviceType'")
                    .ToList();
            }
        }

        public List<String> GetDeviceState()
        {
            using (var connection = new SqlConnection(Constant.getDatabaseConnectionString()))
            {
                return connection
                    .Query<String>("SELECT configValue FROM config WHERE configTag='deviceState'")
                    .ToList();
            }
        }

        public List<String> GetGatewayType()
        {
            using (var connection = new SqlConnection(Constant.getDatabaseConnectionString()))
            {
                return connection
                    .Query<String>("SELECT configValue FROM config WHERE configTag='gatewayType'")
                    .ToList();
            }
        }

        public List<String> GetGatewayState()
        {
            using (var connection = new SqlConnection(Constant.getDatabaseConnectionString()))
            {
                return connection
                    .Query<String>("SELECT configValue FROM config WHERE configTag='gatewayState'")
                    .ToList();
            }
        }
    }
}