using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using IoTManager.Utility.Helpers;
using System.Data;

namespace IoTManager.MonitorService
{
    public static class AddMonitorData
    {
        private static string connectionString = "";

        [FunctionName("AddMonitorData")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = "iot hub";

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            if (string.IsNullOrEmpty(requestBody))
            {
                return new StatusCodeResult(404);
            }

            //TODO:insert monitor data to database
            using(SqlHelper helper=new SqlHelper(connectionString))
            {
                string sql = "insert into ....";
                helper.ExecuteNonQuery(sql, CommandType.Text);
            }
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            return name != null
                ? (ActionResult)new OkObjectResult($"Hello, {name}")
                : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
        }
    }
}
