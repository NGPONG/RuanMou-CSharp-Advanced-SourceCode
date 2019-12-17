using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCLRCore
{
    /// <summary>
    /// 1 .Net平台&CLR
    /// 2 堆栈内存分配：值类型和引用类型
    /// 3 垃圾回收和Dispose模式  
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                

                //能听到老师讲话的，能看到老师的屏幕的 刷个1
                Console.WriteLine("欢迎来到.Net高级班vip课程，我是Richard老师！今天我们来学习探讨一下我们的CLR");
                {
                    Console.WriteLine("******************CLR****************");
                }
                {
                    Console.WriteLine("******************StackHeap****************");
                    StackHeap.Show();
                }
                {
                    Console.WriteLine("*****************GCDemo*****************");
                    GCDemo.Show();
                }
                {
                    Console.WriteLine("*****************StandardDispose*****************");
                    StandardDispose standardDispose = new StandardDispose();
                    standardDispose.Dispose();
                    standardDispose.Dispose();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }
}
