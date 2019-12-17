using MyGeneric.Extend;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGeneric
{
    /// <summary>
    /// 1 引入泛型:延迟声明
    /// 2 如何声明和使用泛型
    /// 3 泛型的好处和原理
    /// 4 泛型类、泛型方法、泛型接口、泛型委托
    /// 5 泛型约束
    /// 6 协变 逆变(选修)
    /// 7 泛型缓存(选修)
    ///  
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // 欢迎大家来到.Net 高级班的Vip课程，我是Richard老师！
                // 今天是第十三期的第一次课：泛型
                //什么是泛型？
                //宽泛的，不确定的，就是不确定的类型 
                //List<string> intlist = new List<string>();

                // var i = 1234; // 语法糖


                Console.WriteLine(typeof(List<>));
                Console.WriteLine(typeof(Dictionary<,>));

                Console.WriteLine("欢迎来到.net高级班vip课程，今天是Richard老师给大家带来的泛型Generic");
                int iValue = 123;
                string sValue = "456";
                DateTime dtValue = DateTime.Now;
                object oValue = "789";

                Console.WriteLine("***********************Common***********************");
                CommonMethod.ShowInt(iValue);
                CommonMethod.ShowString(sValue);
                CommonMethod.ShowDateTime(dtValue);

                Console.WriteLine("***********************Object***********************");
                CommonMethod.ShowObject(oValue);
                CommonMethod.ShowObject(iValue);
                CommonMethod.ShowObject(sValue);
                CommonMethod.ShowObject(dtValue);

                Console.WriteLine("***********************Generic***********************");
                // 泛型只有：泛型方法、泛型类、泛型接口、泛型委托 
                //泛型方法调用的时候，需要加上<>,而且需要指定具体的类型、指定的类型和传入的参数类型保持一致。

                CommonMethod.Show(iValue); //如果类型参数，可以通过参数类型推导出来，那么就可以省略
                                           /* CommonMethod.Show<int>(sValue);*/// 因为类型错了 
                CommonMethod.Show(sValue);
                CommonMethod.Show<DateTime>(dtValue);
                CommonMethod.Show<object>(oValue);

                //Monitor.Show();

                Console.WriteLine("***********************GenericCache***********************");
                //GenericCacheTest.Show();

                //泛型方法  一个方法满足多个类型的需求
                //泛型类   就是一个类 满足多个类型的需求
                //泛型接口 就是一个接口 满足多个多个类型的需求
                //泛型委托 就是一个委托 满足多个多个类型的需求

                //GenericConstraint.ShowObject(iValue);
                //GenericConstraint.ShowObject(sValue);
                //GenericConstraint.ShowObject(dtValue);
                //GenericConstraint.ShowObject(oValue);
                 
                Console.WriteLine("***********************GenericConstraint***********************");
                // 泛型约束的好处：
                // 加了约束以后可以获取更多的功能；
                // 程序在调用的时候可以避免错误调用   
                People people = new People()
                {
                    Id = 123,
                    Name = "Richard"
                };

                Chinese chinese = new Chinese()
                {
                    Id = 234,
                    Name = "习大大"
                };
                Hubei hubei = new Hubei()
                {
                    Id = 345,
                    Name = "王市长"
                };
                Japanese japanese = new Japanese()
                {
                    Id = 678,
                    Name = "福原爱"
                };

                // Object 方法因为可以出入任何类型，没有限制，如果传入的类型不匹配，就会发生异常（类型安全问题）
                //GenericConstraint.ShowObject(people);
                //GenericConstraint.ShowObject(chinese);
                //GenericConstraint.ShowObject(hubei);
                //GenericConstraint.ShowObject(japanese);

                //GenericConstraint.Show(people);
                //GenericConstraint.Show(chinese);
                //GenericConstraint.Show(hubei);
                //GenericConstraint.Show(japanese);//


               // GenericConstraint.GenericShow(123);

                GenericConstraint.GenericShow(people);
                GenericConstraint.GenericShow(chinese);
                GenericConstraint.GenericShow(hubei);
                GenericConstraint.GenericShow(japanese);//


               



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }
}
