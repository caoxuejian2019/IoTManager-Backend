using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace IoTManager.Utility.Helpers
{
    public sealed class SqlHelper : IDisposable
    {
        private readonly IDbConnection _dbConnection;

        public SqlHelper(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString)) throw new ArgumentNullException();
            this._dbConnection = new SqlConnection(connectionString);
        }

        public void ExecuteNonQuery(string sql, CommandType cmdType, params DbParameter[] paras)
        {
            using(IDbCommand command=new SqlCommand(sql, (SqlConnection)this._dbConnection))
            {
                if (paras != null && paras.Length > 0)
                {
                    foreach (var para in paras)
                    {
                        command.Parameters.Add(para);
                    }
                }
                if(this._dbConnection.State== ConnectionState.Closed)
                {
                    this._dbConnection.Open();
                }
                command.ExecuteNonQuery();
            }
        }

        public void Dispose()
        {
            if (this._dbConnection != null)
            {
                this._dbConnection.Dispose();
            }
        }
    }
}
