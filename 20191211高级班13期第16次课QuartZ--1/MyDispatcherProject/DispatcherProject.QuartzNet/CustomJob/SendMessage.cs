using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DispatcherProject.QuartzNet.CustomJob
{

    [PersistJobDataAfterExecution] //执行后可以保留执行结果
    [DisallowConcurrentExecution] // 保证不去重复执行   可以把任务串行起来  让一个任务执行完毕以后  才去执行下一个任务
    public class SendMessage : IJob
    {

        //private static object obj = new object(); //定义一个静态变量也可以实现 执行后可以保留执行结果

        public SendMessage()
        {
            Console.WriteLine("SendMessage 被构造");
        }

        public async Task Execute(IJobExecutionContext context) //context 很强大  他会包含我们想要的切
        {
            await Task.Run(() =>
            {

                Thread.Sleep(5000);

                //发消息：给谁发，需要传递参数；
                Console.WriteLine();
                Console.WriteLine("**********************************************");
                JobDataMap jobDetailMap = context.JobDetail.JobDataMap;

                Console.WriteLine($"{jobDetailMap.Get("Student1")}同学：准备开始上课了！{DateTime.Now}");
                Console.WriteLine($"{jobDetailMap.Get("Student2")}同学：准备开始上课了！{DateTime.Now}");
                Console.WriteLine($"{jobDetailMap.Get("Student3")}同学：准备开始上课了！{DateTime.Now}");
                Console.WriteLine($"{jobDetailMap.Get("Student4")}同学：准备开始上课了！{DateTime.Now}");
                Console.WriteLine($"{jobDetailMap.Get("Year")}");
                jobDetailMap.Put("Year", jobDetailMap.GetInt("Year") + 1);

                Console.WriteLine($"{jobDetailMap.Get("Student4")}同学：准备开始上课了！{DateTime.Now}");
                JobDataMap triggerMap = context.Trigger.JobDataMap;
                Console.WriteLine();

                Console.WriteLine($"{triggerMap.Get("Student5")}同学：第二次提示：准备开始上课了！{DateTime.Now}");
                Console.WriteLine($"{triggerMap.Get("Student6")}同学：第二次提示：准备开始上课了！{DateTime.Now}");
                Console.WriteLine($"{triggerMap.Get("Student7")}同学：第二次提示：准备开始上课了！{DateTime.Now}");
                Console.WriteLine($"{triggerMap.Get("Student8")}同学：第二次提示：准备开始上课了！{DateTime.Now}");

                Console.WriteLine($"{triggerMap.Get("Year")}");

                Console.WriteLine("&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&");
                Console.WriteLine(context.MergedJobDataMap.Get("Year"));
                Console.WriteLine("**********************************************");
                Console.WriteLine();
            });
        }
    }
}
