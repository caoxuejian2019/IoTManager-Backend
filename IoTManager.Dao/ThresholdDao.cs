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
    public sealed class ThresholdDao: IThresholdDao
    {
        public Dictionary<String, Tuple<String, int>> GetByDeviceId(String deviceId)
        {
            using (var connection = new SqlConnection(Constant.getDatabaseConnectionString()))
            {
                List<ThresholdModel> thresholdModels = connection.Query<ThresholdModel>(
                    "select * from threshold where deviceId=@did", new
                    {
                        did = deviceId
                    }).ToList();
                
                Dictionary<String, Tuple<String, int>> result = new Dictionary<string, Tuple<string, int>>();
                foreach (ThresholdModel t in thresholdModels)
                {
                    result.Add(t.IndexId, new Tuple<string, int>(t.Operator, t.ThresholdValue));
                }

                return result;
            }
        }
    }
}