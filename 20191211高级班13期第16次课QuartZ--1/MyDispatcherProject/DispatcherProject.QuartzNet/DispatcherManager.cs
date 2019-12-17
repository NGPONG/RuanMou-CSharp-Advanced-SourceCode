using DispatcherProject.QuartzNet.CustomJob;
using DispatcherProject.QuartzNet.CustomListener;
using DispatcherProject.QuartzNet.QuartzNet.CustomLog;
using Quartz;
using Quartz.Impl;
using Quartz.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispatcherProject.QuartzNet
{

    /// <summary>
    /// 1 quartZ引入&初始化&使用  
    /// 2 核心对象Job、Trigger解析
    /// 3 三种Listener扩展订制
    /// 4 可视化界面管理&WindowsService承载
    /// 5 IOC容器结合
    /// 6 自定义的定时调度框架
    /// 
    /// 1. Nuget引入程序包 QuartZ
    /// 2. 三大核心对象
    ///     IScheduler：时间轴  单元  盒子  在这里进行任务配置
    ///     IJobDetail：描述具体做什么事情，定时任务执行的动作
    ///     ITrigger：时间策略，按照什么频率来执行
    /// 3.传参数：jobDetail.JobDataMap.Add  传参数
    ///           trigger.JobDataMap.Add 传参数
    ///           注意： context.MergedJobDataMap 会去掉重复  以后者为准 获取参数严格区分大小写
    ///           链式传参：
    ///          
    /// 4.系统日志
    /// 
    /// 
    /// ///为什么要分三个角色： 为了更加灵活
    /// 
    /// 
    /// 现在是21：53 大家提问& 休息   21：58开始答疑！ 期间老师就不说话了
    /// </summary>
    public class DispatcherManager
    {
        public static async Task Init()
        {

            #region 获取框架日志
            LogProvider.SetCurrentLogProvider(new CustomConsoleLogProvider());//
            #endregion

            #region Scheduler

            StdSchedulerFactory factory = new StdSchedulerFactory();
            IScheduler scheduler = await factory.GetScheduler();
            await scheduler.Start();

         
             
            #region Listener
            scheduler.ListenerManager.AddJobListener(new CustomJobListener());
            scheduler.ListenerManager.AddTriggerListener(new CustomTriggerListener());
            scheduler.ListenerManager.AddSchedulerListener(new CustomSchedulerListener());
            #endregion

            #endregion

            #region JobDetail
            IJobDetail jobDetail = JobBuilder.Create<SendMessage>()
                  .WithIdentity("sendJob", "group1")
                  .WithDescription("This is sendJob")
                  .Build();

            jobDetail.JobDataMap.Add("Student1", "阳光下的微笑");
            jobDetail.JobDataMap.Add("Student2", "明日梦");
            jobDetail.JobDataMap.Add("Student3", "大白");
            jobDetail.JobDataMap.Add("Student4", "池鱼");

            jobDetail.JobDataMap.Add("Year", DateTime.Now.Year);

            #endregion

            #region trigger

            //ITrigger trigger = TriggerBuilder.Create()
            //               .WithIdentity("sendTrigger", "group1")
            //               //.StartAt(new DateTimeOffset(DateTime.Now.AddSeconds(10)))
            //               .StartNow()
            //              .WithCronSchedule("5/3 * * * * ?")//每隔一分钟 
            //              //5，8，11，14
            //              .WithDescription("This is sendJob's sendTrigger")
            //              .Build();

            ITrigger trigger = TriggerBuilder.Create()
                   .WithIdentity("sendTrigger", "group1")
                   .StartNow()
                   .WithSimpleSchedule(x => x
                       .WithIntervalInSeconds(10) //多少秒执行一次 
                       .WithRepeatCount(10) //表示最多执行多少次
                       .RepeatForever())
                       .WithDescription("This is testjob's Trigger")
                   .Build();

            trigger.JobDataMap.Add("Student5", "非常Nice");
            trigger.JobDataMap.Add("Student6", "Jerry");
            trigger.JobDataMap.Add("Student7", "龙");
            trigger.JobDataMap.Add("Student8", "月光寒");
            trigger.JobDataMap.Add("Year", DateTime.Now.Year + 1);

            #endregion 

            await scheduler.ScheduleJob(jobDetail, trigger);
        }
    }
}
