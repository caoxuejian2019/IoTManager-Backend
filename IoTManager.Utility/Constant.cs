using System;

namespace IoTManager.Utility
{
    public class Constant
    {
        public static String getDatabaseConnectionString()
        {
            return "Data Source=iotmanagerdbserver.database.chinacloudapi.cn;" +
                   "User ID=azureuser;" +
                   "Initial Catalog=iotmanagerdb;" +
                   "Pwd=123qwe!@#QWE;";
        }

        public static String getDateFormatString()
        {
            return "yyyy年MM月dd日 hh:mm:ss";
        }
    }
}