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

        public static String getMongoDBConnectionString()
        {
            //return
                //"mongodb://iotmangermongodb:1BiabpxKh7xotBoShVPkp8IvKaNvb2DoIqfZ9SfZ8tg8Cpwj2y5DKgdK8gVDZZelCfPonWfVJge66y3UjWS6KA==@iotmangermongodb.documents.azure.cn:10255/?ssl=true&replicaSet=globaldb";
                return
                    "mongodb://shudev2:Etp13A3NROECpQeJ1GjTbkj7OqHfoukak17BwiMgcjw6g2ap5PPZsfraINEVJ1G34UtR2MHUJCTufvhAz2uwLQ==@shudev2.documents.azure.cn:10255/?ssl=true&replicaSet=globaldb";
        }

        public static String getDateFormatString()
        {
            return "yyyy年MM月dd日 hh:mm:ss";
        }
    }
}