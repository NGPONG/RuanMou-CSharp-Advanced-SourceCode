using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OOP.DesignerPattern.SingletonPattern
{
    public class SingletonPrototype
    {
        /// <summary>
        /// 构造函数耗时耗资源
        /// 1 私有化构造函数
        /// </summary>
        private SingletonPrototype()
        {
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
        private static SingletonPrototype _SingletonPrototype = new SingletonPrototype();

        /// <summary>
        /// 2 公开的静态方法提供实例
        /// </summary>
        /// <returns></returns>
        public static SingletonPrototype CreateInstance()
        {
            SingletonPrototype prototype = (SingletonPrototype)_SingletonPrototype.MemberwiseClone();//内存copy
            //跟单例的区别就是 新的实例 不是同一个，就不会互相影响
            //快速复制对象，不走构造函数---浅克隆
            return prototype;
        }

        //既然是单例，大家用的是同一个对象，用的是同一个方法，那还会并发吗  还有线程安全问题吗？
        public int iTotal = 0;
        public void Show()
        {
            //Console.WriteLine($"This is {this.GetType().Name} {Thread.CurrentThread.ManagedThreadId}");
            //lock (Singleton_Lock)
            //{
                this.iTotal++;
            //}
        }

        public static void Test()
        {
            Console.WriteLine("Test1");
        }

    }
}
