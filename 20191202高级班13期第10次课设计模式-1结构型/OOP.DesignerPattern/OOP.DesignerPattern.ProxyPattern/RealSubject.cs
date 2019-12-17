using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OOP.DesignerPattern.ProxyPattern
{
    /// <summary>
    /// 一个耗时耗资源的对象方法
    /// 一个第三方封装的类和方法
    /// </summary>
    public class RealSubject : ISubject
    {
        public RealSubject()
        {
            Thread.Sleep(2000);
            long lResult = 0;
            for (int i = 0; i < 100000000; i++)
            {
                lResult += i;
            }
            Console.WriteLine("RealSubject被构造。。。");
        }

        /// <summary>
        /// 火车站查询火车票
        /// </summary>
        public bool GetSomething()
        {
            Console.WriteLine("坐车去火车站看看余票信息。。。");
            Thread.Sleep(3000);
            Console.WriteLine("到火车站，看到是有票的");
            return true;
        }

        /// <summary>
        /// 火车站买票
        /// </summary>
        public void DoSomething()
        {
            //Console.WriteLine("This is DoSomething Before");

            Console.WriteLine("开始排队。。。");
            Thread.Sleep(2000);
            Console.WriteLine("终于买到票了。。。");
        }
    }
}
