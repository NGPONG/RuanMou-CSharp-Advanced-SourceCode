using DispatcherProject.QuartzNet.CustomJob;
using DispatcherProject.QuartzNet.CustomListener;
using DispatcherProject.QuartzNet.QuartzNet.CustomLog;
using Quartz;
using Quartz.Impl;
using Quartz.Logging;
using Quartz.Simpl;
using Quartz.Xml;
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
    /// 
    /// 
    /// ///为什么要分三个角色： 为了更加灵活
    /// 
    /// 
    /// 现在是21：53 大家提问& 休息   21：58开始答疑！ 期间老师就不说话了
    /// 
    /// 
    /// 在定时任务执行的时候；需要我们来管理一下，有时候也需要我们人工介入；
    /// 可视化管理工具：可选的有哪些？
    /// MVC:
    /// Winform  
    /// QuartZ已经提供了！
    /// 
    /// 1.新建一个项目
    /// 2.引入QuartZ/CrystalQuartz 
    /// 3.访问：http://localhost:50611/CrystalQuartzPanel.axd
    /// 4.指定StdSchedulerFactory监控参数  端口和可视化项目的 webconfig 下的provider value 端口保持一直
    /// 
    /// 我们高级班同学在工作中
    ///         高级开发开发者：需要写job  +  配置文件 + Trigger； 
    ///         普通开发者：通过配置文件来配置；
    ///             
    /// 我们现在是把定时任务托管在控制台；
    ///        老师不推荐大家托管在网站；如果没有任何请求的时候，IIS会间隔20分钟会回收程序池；
    ///        可以直接托管在控制台/Winform；
    /// 最好托管在WindowsService：如果系统正常，就可以支持运行，不会被回收；还可以伴随系统启动而启动；
    /// 
    /// WindowsService:
    ///     1.添加一个WindowsService
    ///     2.添加安装程序
    ///     3.就可以安装服务（可以通过工具）
    ///  
    /// 
    /// 
    /// 现在是21：48  大家开始提问&休息&上厕所  21：53开始答疑  期间老师就不说话了
    /// </summary>
    public class DispatcherManager
    {
        public static async Task Init()
        {

            #region 获取框架日志
            LogProvider.SetCurrentLogProvider(new CustomConsoleLogProvider());//
            #endregion

            #region Scheduler

            //StdSchedulerFactory factory = new StdSchedulerFactory();
            //IScheduler scheduler = await factory.GetScheduler();

            IScheduler scheduler=await ScheduleManager.BuildScheduler();
            
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

            {
                {
                    //使用配置文件
                    XMLSchedulingDataProcessor processor = new XMLSchedulingDataProcessor(new SimpleTypeLoadHelper());
                    await processor.ProcessFileAndScheduleJobs("~/CfgFiles/quartz_jobs.xml", scheduler);
                }
            }
            {
                //IJobDetail sayHijobDetail = JobBuilder.Create<SayHIJob>()
                //    .WithDescription("this is sayHijobDetail")
                //.WithIdentity("SayhiJob", "Vip高级班")
                //.WithDescription("This is SayhiJob")
                //.Build();
                 
                //ITrigger SayhiTrigger = TriggerBuilder.Create()
                //               .WithIdentity("SayhiTrigger", "Vip高级班")
                //               //.StartAt(new DateTimeOffset(DateTime.Now.AddSeconds(10)))
                //               .StartNow()
                //              .WithCronSchedule("1/4 * * * * ?")  
                //              .WithDescription("This is SayhiJob's SayhiTrigger")
                //              .Build();


                //await scheduler.ScheduleJob(sayHijobDetail, SayhiTrigger);

            }
        }
    }
}
