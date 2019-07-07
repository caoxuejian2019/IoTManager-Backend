using IoTManager.Tcp.MonitorDataSync.Configure;
using IoTManager.Tcp.MonitorDataSync.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading;

namespace IoTManager.Tcp.MonitorDataSync
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();
            Startup startup = new Startup();
            startup.ConfigureServices(services);
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            //configure file logging
            serviceProvider.GetService<ILoggerFactory>().AddFile("logs/iotmanager-{Date}.txt");
            
            var logger = serviceProvider.GetService<ILoggerFactory>()
                .CreateLogger<Program>();
            logger.LogError("bug");
            // Get Service and call method
            var surveyService = serviceProvider.GetService<SurveyService>();
            surveyService.AcquireMonitorData();

            var sockerManager = serviceProvider.GetService<SockerManager>();
            

            //读取配置
            //var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).Build();
            //var appsetting = new AppSetting();
            //builder.GetSection("AppSettings").Bind(appsetting);
            //添加日志
            //var serviceCollection = new ServiceCollection();
            //serviceCollection.AddLogging();

            ///定时任务
            //JobManager jobManager = new JobManager();
            //jobManager.AcquireMonitorData().GetAwaiter().GetResult();

            #region 服务端

            //SockerManager sockerManager = new SockerManager();
            //sockerManager.StartListenLocalMachinePort(appsetting.Gateway.Port);

            #endregion

            #region 客户端
            //SockerManager sockerManager = new SockerManager();
            //Random random = new Random();
            //while (true)
            //{
            //    Console.WriteLine("send message start...");
            //    sockerManager.SendCommand(appsetting.Gateway.IPAddress, appsetting.Gateway.Port, "send message test" + random.Next(1000));
            //    Console.WriteLine("send message end...");
            //    Thread.Sleep(10000);
            //}
            #endregion
            //sockerManager.StartMonitorLocalMachinePort(port);
            //sockerManager.StartMonitorLocalMachinePort(port);
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
