using System;

namespace OOP.DesignerPattern
{
    /// <summary>
    /// 环境：VS2019+.NetCore3.0
    /// 如果还没有这套环境，打不开代码，
    /// 课后我分享到群里
    /// 也可以找助教QQ3614917466
    /// 
    /// 
    /// 23种设计模式专题--串讲+揭秘
    /// 设计模式六大原则，其实都很虚
    /// 本周设计模式就是具体招数
    /// 23种
    /// 
    /// 
    /// 1 类与类之间的关系解读
    /// 2 适配器模式
    /// 3 代理模式
    /// 4 装饰器模式
    /// 5 结构型设计模式核心套路解读
    /// 
    /// 
    /// 1 观察者模式
    /// 2 行为型设计模式核心套路解读
    /// 3 模板方法模式
    /// 4 责任链模式
    /// 
    /// 1 单例模式/原型模式
    /// 2 简单工厂
    /// 3 工厂方法
    /// 4 抽象工厂
    /// 5 创建型设计模式核心套路解读
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("欢迎来到.Net高级进阶VIP课程，今晚Eleven带来的是设计模式专题!");
                Console.WriteLine("***************结构型设计模式**************");
                {
                    //Console.WriteLine("********适配器模式********");
                    //OOP.DesignerPattern.AdapterPattern.Program.Show();
                }
                {
                    //Console.WriteLine("********代理模式********");
                    //OOP.DesignerPattern.ProxyPattern.Program.Show();
                }
                {
                    //Console.WriteLine("********装饰器模式********");
                    //OOP.DesignerPattern.DecoratorPattern.Program.Show();
                }
                {
                    //Console.WriteLine("********观察者********");
                    //OOP.DesignerPattern.ObserverPattern.Program.Show();
                }
                //{
                //    Console.WriteLine("********模板方法********");
                //    OOP.DesignerPattern.TemplateMethodPattern.Program.Show();

                //}
                //{
                //    Console.WriteLine("********模板方法********");
                //    OOP.DesignerPattern.ResponsibilityChainPattern.Program.Show();

                //}
                {
                    Console.WriteLine("********单例模式********");
                    OOP.DesignerPattern.SingletonPattern.Program.Show();

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
