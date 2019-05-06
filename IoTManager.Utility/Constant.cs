using System;

namespace IoTManager.Utility
{
    public class Constant
    {
        public static String getDatabaseConnectionString()
        {
            return "Database=iotmanager;" +
                   "Data Source=localhost;" +
                   "User Id=jackjack59;" +
                   "Password=jackjack123;" +
                   "port=3306";
        }

        public static String getDateFormatString()
        {
            return "yyyy年MM月dd日 hh:mm:ss";
        }
    }
}