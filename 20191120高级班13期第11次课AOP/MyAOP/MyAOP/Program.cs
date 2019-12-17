using MyAOP.UnityWay;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAOP
{
    /// <summary>
    /// 1 AOP面向切面编程
    /// 2 静态代理实现AOP
    /// 3 动态代理实现AOP
    /// 4 Unity、MVC中的AOP  
    ///  
    /// 欢迎大家来到.Net 高级班的Vip课程   我是Richard 老师！
    /// 课程在8分钟之后准时开始。。。。。
    /// 欢迎大家在线点歌。。。
    /// 
    /// 
    /// POP:面向过程编程，代码是线性式 严格按照顺序  
    /// 
    /// OOP:面向对象编程 万物皆对象，可以搭建大型的复杂系统
    ///       砖块---墙---房间---高楼大厦（稳定）   砖块确实是稳定
    ///        类--各种功能点---功能模块---系统（平台） 类是稳定的吗?
    ///        类是无法一直稳定，确实有场景需要改动。。。
    ///        GOF 23种设计模式   都是依赖抽象   可以更换具体的类型 (最小的粒度只能到类) 
    ///        不能让类动态话，只能替换类；
    ///        
    /// AOP: 可以让类动态化！动态粒度更小，可以把类里面的成员给修改掉！
    ///        
    /// 
    /// AOP 面向切面编程 (Aspect Oriented Programming)   其实是OOP扩展
    /// 
    /// 使用Aop特点以后：
    ///      只聚焦于自身模块的业务功能，用户验证/日志处理/都可以通过Aop给动态加进来！
    ///      功能扩展性更强，把功能集中管理，代码复用，更加规范
    ///       
    /// 能听到老师讲话（声音很清晰），能看到老师的屏幕  刷个1
    /// 
    /// 
    /// 是按AOP的方式：
    /// a 装饰器模式/代理模式   静态实现
    /// b 动态实现 （Remoting）(Emit)
    /// c 通过Unity 支持AOP
    /// 
    ///  在MVC中过滤器  就是典型的AOP 思想；----基于Invoker调用中心
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("欢迎大家来到.Net高级班的Vip 课程，本次课我们来学一下AOP编程思想，我是Richard老师");

                #region AOP show
                //Console.WriteLine("************DecoratorAOP***********");
                //DecoratorAOP.Show();

                //Console.WriteLine("************ProxyAOP***********");
                //ProxyAOP.Show();

                //Console.WriteLine("************RealProxyAOP***********");
                //RealProxyAOP.Show();

                //Console.WriteLine("************CastleProxyAOP***********");
                //CastleProxyAOP.Show();


                //如果需要 通过Unity实现支持Aop 需要先引入DLL
                //Console.WriteLine("*******************UnityConfigAOP*****************");
                UnityConfigAOP.Show();

                //可以使用特性

                //老师，是不是这个类中的每个方法在调用时候都要把每个注册的AOP都走一遍，如果不想让某个函数走AOP或则不想走某一个AOP怎么做？

                #endregion
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }
}
