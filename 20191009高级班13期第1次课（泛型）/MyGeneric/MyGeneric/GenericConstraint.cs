using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGeneric
{
    /// <summary>
    /// 泛型约束 
    /// </summary>
    public class GenericConstraint
    {
        public static void ShowObject(object oParameter)
        {
            //  Console.WriteLine(oParameter.Id);// 编译器就报错，因为C# 是强类型的语言，在编译的时候就要确定类型
            People people = (People)oParameter;
            Console.WriteLine(people.Id);
            Console.WriteLine("This is {0},parameter={1},type={2}",
                typeof(CommonMethod), oParameter.GetType().Name, oParameter);
        }


        //加了约束就有更多的自由，也可以获取更多的权利

        //获取权利，也就需要尽自己义务 

        public static void Show<T>(T tParameter)
           // where T : People //基类约束,你只能是一个People ，所以这里参数只能传入People或者People子类
           where T : ISports // 接口约束
        {
            //Console.WriteLine(tParameter.Id);  //又报错了 

            //  Console.WriteLine(tParameter.Id);
            // 加了 T : ISports约束以后，发现不能访问Id

            tParameter.Pingpang();

            Console.WriteLine("This is {0},parameter={1},type={2}",
                typeof(CommonMethod), tParameter.GetType().Name, tParameter);
        }


        public static void GenericShow<T>(T tParameter)
        // where T : class // 引用类型约束  就只能传入引用类型的参数
        // where T : struct
        // where T : new()// 无参数构造偶函数约束
        {
            Console.WriteLine("This is {0},parameter={1},type={2}",
                typeof(CommonMethod), tParameter.GetType().Name, tParameter);
        }


        public static void GenericShow1<T>(T tParameter)
        where T : class, new() // 泛型约束可以结合使用 ,用逗号分隔就OK
        {
            Console.WriteLine("This is {0},parameter={1},type={2}",
                typeof(CommonMethod), tParameter.GetType().Name, tParameter);
        }

        public static T GenericShow2<T>()
        {
            return default(T); // default关键字  
        }

        // 泛型约束的好处：
        // 加了约束以后可以获取更多的功能；
        // 程序在调用的时候可以避免错误调用                 
       
    }
}
