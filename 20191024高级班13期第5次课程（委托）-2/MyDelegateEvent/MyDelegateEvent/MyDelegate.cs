using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyDelegateEvent
{
    public delegate void NoReturnNoParaOutClass();
    public class MyDelegate // :  MulticastDelegate
    {
        /// <summary>
        ///委托声明 可以声明在类的外面也可以是在类内部
        /// </summary> 
        /// 1、委托在IL 中就是一个类，继承自父类(特殊类)MulticastDelegate

        public delegate void NoReturnNoPara();
        public delegate void NoReturnWithPara(int x, int y);//1 声明委托
        public delegate int WithReturnNoPara();
        public delegate int WithReturnWithPara(out int x, ref int y);

        public void Show()
        {

            //{
            //    WithReturnNoPara method1 = new WithReturnNoPara(ToInt);
            //    int iResult = method1.Invoke();
            //}

            //Student student = new Student()
            //{
            //    Id = 1,
            //    Name = "周瑾",
            //    Age = 25
            //};
            //student.Study();

            //委托的实例化：要求传递一个和委托参数返回值完全一致的方法。
            NoReturnNoPara method = new NoReturnNoPara(this.DoNothing);
            //NoReturnNoPara method1 = new NoReturnNoPara(this.ParaReturn);
            //method.Invoke();// 就是去调用方法
            //method();// 可以省略Invoke
            //this.DoNothing(); //和委托Invoke 是做的同一件事
            //method.BeginInvoke(null, null);//这里是开启一个新的线程去执行方法
            //method.EndInvoke(null);

            //1、声明一个委托
            //2、委托的实例化
            //3、调用 

            // 系统内置的委托
            {
                //Action  Func  从.Netframework 3.0出现，是系统提供的委托
                //Action:没有返回值， 参数可有可无
                //Func: 必须有返回值，参数可有可无
                //我们其实可以自定义委托呀，那系统为什么还要定义这两个委托呢？

                //new Thread(new ThreadStart(DoNothing));
                //new Thread(new NoReturnNoPara(DoNothing)); // 是不是重复声明？
                ////我们的思维来讲：应该是不会报错
                //这里为什么不行呢？ 是因为委托是一个类，两个实例肯定不一样啊！

                //所以系统提供Action Func 两个委托,系统肯定是希望在以后的封装中能够直接使用这两个委托！

                //Action: 没有返回值，最多支持16个泛型参数
                //Action act = new Action(this.DoNothing);
                //Action<int> actInt = new Action<int>(NoReturn);
                //Action<int, string, DateTime, object, int, string, DateTime, object, int, string, DateTime, object, int, string, DateTime, object> action = null;

                ////Func: 有（泛型）返回值，最多支持16个泛型参数，泛型参数列表的最后一个为委托返回值类型
                //Func<int> func1 = new Func<int>(ToInt);
                //Func<int, int, string, DateTime, object, int, string, DateTime, object, int, string, DateTime, object, int, string, DateTime, object> Func2 = null;
                //int iResult = func1.Invoke();

            }

            {//多播委托 我们自定义的任何一个委托都是多播委托 
                //可以通过+=/-=  向委托中增加或者移除方法；
                //+=增加方法以后，让委托组成了一个方法链

                //-=只能移除同一个实例里的方法，如过没有可以移除的方法，就啥事儿也不发生
                NoReturnNoPara method1 = new NoReturnNoPara(this.DoNothing);

                //var student = new Student();
                //method1 += this.DoNothing;
                //method1 += student.Study; //加括号就是调用    
                //method1 -= this.DoNothing;
                //method1 -= student.Study; //仍然会执行 因为是两个不同的实例
                //method1.Invoke();

                //foreach (NoReturnNoPara item in method1.GetInvocationList())
                //{
                //    item.Invoke();
                //}
                // 如果func 委托在+= 形成一个方法链以后，在执行后，只能获取最后一个方法的返回值
            }
            //现在是21:55  大家开始提问，21：58开始答疑，期间老师不说话

            {
                //Console.WriteLine("********************委托的多种实例化**************************");
                //{
                //    //普通方法实例化委托
                //    NoReturnNoPara method1 = new NoReturnNoPara(this.DoNothing);
                //}
                //{
                //    //静态方法实例化委托
                //    NoReturnNoPara method1 = new NoReturnNoPara(DoNothingStatic);
                //}
                //{
                //    //实例方法实例化委托
                //    NoReturnNoPara method1 = new NoReturnNoPara(new Student().Study);
                //}

                //{
                //    //静态方法实例化委托
                //    NoReturnNoPara method1 = new NoReturnNoPara(Student.StudyAdvanced);
                //}
            }
        }


        private MyDelegate ParaReturn(out int x, ref int y)
        {
            throw new Exception();
        }


        private void NoReturn(int i)
        {
            Console.WriteLine("");
        }


        private int ToInt()
        {
            return 1;
        }

        private void DoNothing()
        {
            Console.WriteLine("This is DoNothing");
        }
        private static void DoNothingStatic()
        {
            Console.WriteLine("This is DoNothingStatic");
        }
    }

    public class OtherClass
    {
        public void DoNothing()
        {
            Console.WriteLine("This is DoNothing");
        }
        public static void DoNothingStatic()
        {
            Console.WriteLine("This is DoNothingStatic");
        }
    }
}
