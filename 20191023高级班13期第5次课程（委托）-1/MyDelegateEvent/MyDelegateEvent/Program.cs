using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDelegateEvent
{
    /// <summary>
    /// 1 委托的声明、实例化和调用
    /// 2 委托的意义：解耦
    /// 3 泛型委托--Func Action  
    /// 4 委托的意义：多播委托
    /// 5 事件 观察者模式
    /// </summary>
    ///  
    /// Func Action 异步多线程 事件  
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // 课程准时20:00开始
                // 同时也希望同学们在每学习一个知识点后，能考虑把知识点应用到自己的作业中去！
                // 音效听着有问题，打个2
                // 准备好学习 刷个1

                Console.WriteLine("欢迎来到.net高级班VIP课程_委托_delegate，我是Richard老师");
                {
                    //Console.WriteLine("****************************MyDelegate*************************");
                    MyDelegate myDelegate = new MyDelegate();
                    myDelegate.Show();
                }
                {
                    //Student student = new Student()
                    //{
                    //    Id = 123,
                    //    Name = "Richard",
                    //    Age = 23,
                    //    ClassId = 1
                    //};

                    //student.SayHi("飞哥", PeopleType.Chinese); //使用枚举可以让调用方避免出错

                    //SayHiDelegate sayHiDelegateChinese = new SayHiDelegate(student.SayHiChinese);

                    //Action<string> act = new Action<string>(student.SayHiChinese);

                    //student.SayHiShow("飞哥", new SayHiDelegate(act));

                    //SayHiDelegate sayHiDelegateAmerican = new SayHiDelegate(student.SayHiAmerican);
                    //student.SayHiShow("飞哥", new SayHiDelegate(sayHiDelegateAmerican));

                    //SayHiDelegate sayHiDelegateJapanese = new SayHiDelegate(student.SayHiJapanese);
                    //student.SayHiShow("飞哥", new SayHiDelegate(sayHiDelegateJapanese));

                    //现在是21:03 大家开始提问+上厕所，21:05 开始答疑，期间老师不说话

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
