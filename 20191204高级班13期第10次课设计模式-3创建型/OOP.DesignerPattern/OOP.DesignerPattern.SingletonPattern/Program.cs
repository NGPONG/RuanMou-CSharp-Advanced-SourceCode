using System;
using System.Threading;
using System.Threading.Tasks;

namespace OOP.DesignerPattern.SingletonPattern
{
    /// <summary>
    /// 同学们，听一首歌，然后再开始，
    /// 容Eleven准备一下，刚吃完饭。。今天搞太晚了~
    /// </summary>
    public class Program
    {
        public static void Show()
        {

            //{
            //    Console.WriteLine("*******************");
            //    Singleton.Test();

            //    for (int i = 0; i < 5; i++)
            //    {
            //        Task.Run(() =>//5个线程并发执行
            //        {
            //            Singleton singleton = Singleton.CreateInstance();
            //            singleton.Show();
            //        });
            //    }
            //    //怎么样保证一个类只被实例化一次？--享元模式  IOC
            //}
            //{
            //    Console.WriteLine("*******************");
            //    SingletonSecond.Test();

            //    for (int i = 0; i < 5; i++)
            //    {
            //        Task.Run(() =>//5个线程并发执行
            //        {
            //            SingletonSecond singleton = SingletonSecond.CreateInstance();
            //            singleton.Show();
            //        });
            //    }
            //}
            //{
            //    Console.WriteLine("*******************");
            //    SingletonThird.Test();

            //    for (int i = 0; i < 5; i++)
            //    {
            //        Task.Run(() =>//5个线程并发执行
            //        {
            //            SingletonThird singleton = SingletonThird.CreateInstance();
            //            singleton.Show();
            //        });
            //    }
            //}
            {
                Console.WriteLine("*******************");
                for (int i = 0; i < 1000; i++)
                {
                    Task.Run(() =>//5个线程并发执行
                    {
                        Singleton singleton = Singleton.CreateInstance();
                        singleton.Show();
                    });
                }
                Thread.Sleep(5000);
                Singleton singleton = Singleton.CreateInstance();
                Console.WriteLine(singleton.iTotal); 
                //0    1     1000  还是  其他
                //A    B      C           D
            }
        }
    }
}
