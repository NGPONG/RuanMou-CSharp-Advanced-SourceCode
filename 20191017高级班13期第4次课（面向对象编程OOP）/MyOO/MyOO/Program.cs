using MyOO.Polymorphism;
using MyOO.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOO
{
    /// <summary> 
    /// 1 封装继承多态
    /// 2 重写overwrite(new)  覆写override 重载overload(方法)
    /// 3 抽象类接口
    /// 
    /// 面向对象：OO
    ///    
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("欢迎来到.net高级班vip课程，今天是Richard老师为大家带来的面向对象编程");
                Console.WriteLine("手机开机");
                Console.WriteLine("开始游侠"); //......
                Console.WriteLine("正在游戏中");
                Console.WriteLine("游戏结束");

                //面向过程其实更加符合人的常规思维，不太方便扩展,尤其是项目项目复杂，代码修改会很频繁，很不稳定
                //面向对象：
                //1、确定对象（定义对象的各种属性或者动作）
                //2、把对象关联起来

                Player player = new Player();
                Phone phone = new Phone();
                player.Play(phone);
                // 每一个对象可以自由扩展自己内部的属性和动作，不用关心其他对象的内部实现
                // 只要对外暴露的（开放的）接口不变，对象之前的访问就不影响
                //完全隔离开了,相对安全
                // 降低耦合 ，提供代码重用性；

                //继承、封装、多态、抽象
                //继承：强继承 
                //封装：就是把一部分动作，属性集中的放在一起,可以隔离，外部不用关心怎么实现，内部可以随意的扩展，安全，只能通过公开的方法访问
                //多态：运行时的多态，编译时多态

                Poly.Test();

                //抽象： 抽象类、接口
                //抽象类： 代码重用 + 约束   是什么 + 约束
                //接口：约束  (更加灵活)     约束

                //单基类继承，多接口实现 

                // 现在是22:10，大家开始提问，22:13 开始答疑

                List<int> list = new List<int>();
                var i = list[0];
                var j = list[2];


            }



            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }
}
