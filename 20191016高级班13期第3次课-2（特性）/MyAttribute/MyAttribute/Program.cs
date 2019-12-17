using MyAttribute.Extend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyAttribute.ValidateExtend;
using AttributeExtend = MyAttribute.ValidateExtend.AttributeExtend;

namespace MyAttribute
{
    /// <summary>
    /// 1 特性attribute，和注释有什么区别
    /// 2 声明和使用attribute，AttributeUsage
    /// 3 运行中获取attribute：额外信息 额外操作
    /// 4 Remark封装、attribute验证
    ///    
    ///大家久等！流畅度怎么样？
    ///声音听着怎么样？
    ///如果有黑屏的同学  退出重新进入一下
    /// 
    /// 特性： 
    ///     MVC-EF-WCF-IOC 无处不在在
    /// 特性很厉害，加了特性，可以影响编译器编译,还可以增加额外功能
    /// [Obsolete("请不要使用这个了，请使用什么来代替")]//系统
    /// [Serializable]//可以序列化和反序列化 
    /// 
    /// 特性其实就是一个类，需要直接/间接继承Attribute父类
    /// 声明特性的时候，约定俗称是以Attribute 结果
    /// 
    /// 在标记的时候以中括号包裹，可以标记在元素
    ///  [AttributeUsage(AttributeTargets.All,AllowMultiple =true)]
    ///  AttributeTargets.Class设置标记的元素 建议大家明确的指定标记的元素
    ///   
    /// Obsolete，Serializable是系统提供的，我们实现不了
    /// 特性在代码运行的时候，究竟起什么作用？
    /// 
    /// 通过反编译工具可以看到：标记了特性的元素，都会在元素内部生成.custom,但是c#不能元素内部调用
    /// 特性感觉没啥用？ 
    /// 
    /// 那么各种框架集里面是如何使用特性？ 反射
    /// 反射确实可以调用特性，但是需要一个第三方
    /// 现在是21:04 大家开始提问题，准时21:07开始答疑 期间老师不说话
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("欢迎来到.软谋教育的.Net高级班的Vip，我是Richard老师，今天的内容是特性Attribute");
                //Student student = new Student();

                //Student studentVip = new StudentVip()
                //{
                //    Id = 1,
                //    Name = "求学的疯子",
                //    VipGroup = ".Net 高级班学员"
                //};
                //InvokeCenter.ManagerSudent<Student>(studentVip);

                //UserState userState = UserState.Normal;//通过枚举在页面展示出 文字描述
                //if (userState == UserState.Normal)
                //{
                //    Console.WriteLine("正常状态");
                //}
                //else if (userState == UserState.Frozen)
                //{
                //    Console.WriteLine("已冻结");
                //}
                //.......
                //如果发生文字修改，那么改动量特别大  
                //如何通过特性来做呢？

                //特性获取额外的信息
                //string remark1 = AttributeExtend.GetRemark(UserState.Normal);
                //string remark2 = AttributeExtend.GetRemark(UserState.Frozen);
                //string remark3 = UserState.Deleted.GetRemark(); //扩展方法

                //特性如何增加额外功能 
                //long _salary = 800000;
                StudentVip student = new StudentVip()
                {
                    Id = 1,
                    Name = "2的n次方",
                    Salary = 700000,
                    QQ = 823626085
                };
                //if (student.Salary < _salary)
                //{
                //    Console.WriteLine("Pass");
                //}
                //else
                //{
                //    Console.WriteLine("OK");
                //} 
                //bool flg = AttributeExtend.Validate(student);
                bool flg1 = student.Validate(); //扩展方法
                // 实体验证 
                //1、支持多个属性的校验
                //2、支持多重校验
                //3、

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }
}
