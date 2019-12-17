using MyDispatcherProject.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDispatcherProject
{
    public class CustomSchedulingTask
    {

        static Log4NetLogger log4NetLogger = new Log4NetLogger(typeof(CustomSchedulingTask));

        public static void TaskStart()
        { 
            log4NetLogger.Info("this is test");

            DateTime startTime = new DateTime(2019, 12, 5, 22, 25, 1);
            Console.WriteLine("任务开始了。。。。");
            //Task.Run(() =>
            //{
            //    while (true)
            //    {
            //        var now = DateTime.Now;
            //        if (now.Year == startTime.Year && now.Month == startTime.Month && now.Day == startTime.Day && now.Hour == startTime.Hour && now.Minute == now.Minute)
            //        {
            //            Console.WriteLine("OK...这里就去提示了！");
            //            break;
            //        }
            //    }
            //});

        }

    }
}
