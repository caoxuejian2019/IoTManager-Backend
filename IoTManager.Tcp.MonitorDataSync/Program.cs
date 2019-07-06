using IoTManager.Tcp.MonitorDataSync.Configure;
using IoTManager.Tcp.MonitorDataSync.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace IoTManager.Tcp.MonitorDataSync
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).Build();
            var setting = new DeviceSetting();
            builder.GetSection("AppSettings").Bind(setting);
            ///定时任务
            //JobManager jobManager = new JobManager();
            //jobManager.AcquireMonitorData().GetAwaiter().GetResult();


            string ipAddress = "127.0.0.1";
            string port = "8080";
            SockerManager sockerManager = new SockerManager();
            sockerManager.SendCommand(ipAddress, port, "send message test");
            sockerManager.StartMonitorLocalMachinePort(port);
            //sockerManager.StartMonitorLocalMachinePort(port);
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
