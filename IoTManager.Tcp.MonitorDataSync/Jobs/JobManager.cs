using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Threading.Tasks;

namespace IoTManager.Tcp.MonitorDataSync.Jobs
{
    public sealed class JobManager
    {
        public async Task AcquireMonitorData()
        {
            // Grab the Scheduler instance from the Factory  
            StdSchedulerFactory factory = new StdSchedulerFactory();
            IScheduler scheduler = await factory.GetScheduler();
            // 启动任务调度器  
            await scheduler.Start();
            // 定义一个 Job  
            IJobDetail job = JobBuilder.Create<AcquireMonitorDataJob>()
                .WithIdentity("AcquireMonitorDataJob", "AcquireMonitorDataGroup")
                .Build();
            ISimpleTrigger trigger = (ISimpleTrigger)TriggerBuilder.Create()
                .WithIdentity("AcquireMonitorDataTrigger") // 给任务一个名字  
                .StartAt(DateTime.Now) // 设置任务开始时间  
                .ForJob("AcquireMonitorDataJob", "AcquireMonitorDataGroup") //给任务指定一个分组  
                .WithSimpleSchedule(x => x
                .WithIntervalInSeconds(10)  //循环的时间 1秒1次 
                .RepeatForever())
                .Build();
            // 等待执行任务  
            await scheduler.ScheduleJob(job, trigger);
        }
    }
}
