using MyDispatcherProject.Common;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispatcherProject.QuartzNet.CustomJob
{
    public class SayHIJob : IJob
    {

        Log4NetLogger log4NetLogger = new Log4NetLogger(typeof(SayHIJob));
        public async Task Execute(IJobExecutionContext context)
        {
            await Task.Run(() =>
            {
                ///这里可以调用其他项目的Api 模拟http请求  
                ///可以访问数据库

                log4NetLogger.Info("******************************************");
                log4NetLogger.Info($"大家好！ 欢迎大家来到.Net高级班的Vip课程！{ DateTime.Now} ");
                log4NetLogger.Info("******************************************");
                 
                //Console.WriteLine("");
                //Console.WriteLine("******************************************");
                //Console.WriteLine($"大家好！ 欢迎大家来到.Net高级班的Vip课程！{DateTime.Now}"); 
                //Console.WriteLine("******************************************");
                //Console.WriteLine("");
            });
        }
    }
}
