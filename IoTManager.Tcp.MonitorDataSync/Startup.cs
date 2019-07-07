using IoTManager.Tcp.MonitorDataSync.Configure;
using IoTManager.Tcp.MonitorDataSync.Services;
using IoTManager.Tcp.MonitorDataSync.Utility;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IoTManager.Tcp.MonitorDataSync
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public Startup()
        {
            //var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).Build();
            //var appsetting = new AppSetting();
            //builder.GetSection("AppSettings").Bind(appsetting);
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging();
            services.AddSingleton<IConfigurationRoot>(Configuration);
            services.AddScoped<SurveyService>();
            services.AddSingleton<JobQueue<string>>();
            services.Configure<AppSetting>(this.Configuration.GetSection("AppSettings"));
        }
    }
}
