using MyDelegateEvent.Event;
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
                //我发现昨天的关于判断哪国人大招呼素衣永委托代替枚举判断有问题啊，试两数据场景。比如枚举方式参数是传哪国人，自行判断，而委托我告诉他去判断哪国人久试哪国人

                //答案：使用委托可以需要执行的逻辑提到上端调用方来定义了，直接把逻辑传递过去了

                // 课程准时20:00开始
                // 同时也希望同学们在每学习一个知识点后，能考虑把知识点应用到自己的作业中去！
                // 音效听着有问题，打个2
                // 准备好学习 刷个1 
                //这里是直播课 
                //能听到老师讲话，能看到老师屏幕的 刷个1


                // 事件在哪些场景中会使用？
                // Winform--WPF--请求级事件--Webform 
                // 事件可以把固定动作写好，把可变动作分离出去，在满足条件的情况下执行可变动作，相当于对外开放了一个接口，由外部任意扩展
                // 正是因为有这个特点，这就是正是封装框架所需要的，框架可以支持扩展

                //控件事件：
                //启动Form---初始化控件Button---Click +=动作

                // 点击按钮--鼠标操作--系统收集信号--判断发给程序---程序接受信号--判断控件--登录-(事件只能在所在类的内部触发)Button触发Click

                // 点击按钮--鼠标操作--系统收集信号--判断发给程序---程序接受信号--判断控件--支付-(事件只能在所在类的内部触发)Button触发Click

                //把公共部分的逻辑封装起来，把可变的逻辑通过事件发布出来；
                //这里两个按钮大部分的逻辑是一样的，可变的逻辑仅仅只是在注册到事件的方法里面 
                //Event:权限控制，防止外部乱来；

                Console.WriteLine("欢迎来到.net高级班VIP课程_委托_delegate + Event，我是Richard老师");
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

                {
                    //Console.WriteLine("****************多播委托********************");
                    //Cat cat = new Cat();
                    //cat.Miao();

                    //Console.WriteLine("****************观察者模式********************");
                    //cat.AddObserver(new Dog()); //狗叫了
                    //cat.AddObserver(new Mouse());//老鼠跑了
                    //cat.AddObserver(new Baby()); // 小孩哭了
                    //cat.AddObserver(new Mother());
                    //cat.AddObserver(new Father());
                    //cat.AddObserver(new Neighbor());
                    //cat.AddObserver(new Stealer());
                    //cat.MiaoAbserver();

                    //Console.WriteLine("****************多播委托********************");
                    //cat.CatMaioAction += new Dog().Wang; //狗叫了
                    //cat.CatMaioAction += new Mouse().Run;//老鼠跑了
                    //cat.CatMaioAction += new Baby().Cry; // 小孩哭了
                    //cat.CatMaioAction += new Mother().Wispher;

                    ////cat.CatMaioAction = null;
                    ////cat.CatMaioAction.Invoke();

                    //cat.CatMaioAction += new Father().Roar;
                    //cat.CatMaioAction += new Neighbor().Awake;
                    //cat.CatMaioAction += new Stealer().Hide;
                    //cat.MiaoDelegate();


                    //Console.WriteLine("****************事件Event********************");
                    //cat.CatMaioActionHandler += new Dog().Wang; //狗叫了
                    //cat.CatMaioActionHandler += new Mouse().Run;//老鼠跑了
                    //cat.CatMaioActionHandler += new Baby().Cry; // 小孩哭了

                    ////cat.CatMaioActionHandler = null; 
                    ////cat.CatMaioActionHandler.Invoke();

                    //cat.CatMaioActionHandler += new Mother().Wispher;
                    //cat.CatMaioActionHandler += new Father().Roar;
                    //cat.CatMaioActionHandler += new Neighbor().Awake;
                    //cat.CatMaioActionHandler += new Stealer().Hide;
                    //cat.MiaoEvent();
                }

                {
                    EventStandard.Show();

                    // 大家开始提问，22:10分开始答疑
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
