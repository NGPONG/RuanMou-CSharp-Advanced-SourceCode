using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OOP.DesignerPattern.SingletonPattern
{
    public class Singleton
    {
        /// <summary>
        /// 构造函数耗时耗资源
        /// 1 私有化构造函数
        /// </summary>
        private Singleton()//加个参数 防止反射
        {
            //Activator.CreateInstance(null, true);
            long lResult = 0;
            for (int i = 0; i < 10000000; i++)
            {
                lResult += i;
            }
            Thread.Sleep(2000);
            Console.WriteLine($"{this.GetType().Name}被构造一次 {Thread.CurrentThread.ManagedThreadId}");
        }
        /// <summary>
        /// 3 提供一个静态变量重用
        /// </summary>
        private static Singleton _Singleton = null;
        private static readonly object Singleton_Lock = new object();

        /// <summary>
        /// 2 公开的静态方法提供实例
        /// </summary>
        /// <returns></returns>
        public static Singleton CreateInstance()
        {
            if (_Singleton == null)//是在对象初始化之后，可以并发了
            {
                lock (Singleton_Lock)//反多线程--限制并发的
                {
                    if (_Singleton == null)
                    {
                        _Singleton = new Singleton();
                    }
                }
            }
            return _Singleton;
        }




        //既然是单例，大家用的是同一个对象，用的是同一个方法，那还会并发吗  还有线程安全问题吗？
        public int iTotal = 0;
        public void Show()
        {
            //Console.WriteLine($"This is {this.GetType().Name} {Thread.CurrentThread.ManagedThreadId}");
            lock (Singleton_Lock)
            {
                this.iTotal++;
            }
        }

        public static void Test()
        {
            Console.WriteLine("Test1");
        }

    }
}
