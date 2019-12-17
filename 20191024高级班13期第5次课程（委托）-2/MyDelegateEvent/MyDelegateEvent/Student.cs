using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDelegateEvent
{
    /// <summary>
    /// 学生类
    /// </summary>
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ClassId { get; set; }
        public int Age { get; set; }


        //中国人：晚上好
        //美国人：good evening!
        //通过枚举判断，执行各自的业务逻辑 
        //如果新增一个国家的人，那么就修改这个方法
        //如果业务升级，方法需要频繁的修改，方法很不稳定
        //传参数peopleType 是判断之后执行逻辑，传参数是为了执行逻辑，参数不同逻辑又不一样，既然如此，能不能把这个逻辑直接传过来呢？逻辑是什么？逻辑不就是方法吗？如果把一个方法包裹之后传递呢？ 委托

        public void SayHi(string name, PeopleType peopleType)
        {
            Console.WriteLine("招手");
            switch (peopleType)
            {
                case PeopleType.Chinese:
                    Console.WriteLine($"{name}:晚上好！");
                    break;
                case PeopleType.American:
                    Console.WriteLine($"{name}:good evening！");
                    break;
                case PeopleType.Japanese:
                    Console.WriteLine($"{name}:#@%￥%……%%…！");
                    break;
                default:
                    throw new Exception("枚举不存在！");
            }
        }

        //如果在打招呼的时候，需要提前做点什么事？

        // 面对当前这个情况：能不能有个好方法，既能增加公共逻辑方便，而且代码能够很稳定！
        // 如果需要加入新的逻辑，只需要新增一个方法，然后通过委托包裹，传递过来执行

        //自上而下比较;逻辑解耦，方便维护升级，代码稳定！
        //自下往上：去掉重复代码 代码重用
        public void SayHiShow(string name, Action<string> method)
        {
            Console.WriteLine("招手");
            method.Invoke(name);
        }

        /// <summary>
        /// 编写不同的方法，根据不同的人调用不同的方法 
        /// 和上面的实现方案比较好像好一点
        /// 
        /// 如果在问好之前需要做点什么？这里就需要在每个方法中增加一个动作，代码重复很多



        //public void SayHi(string name)
        //{
        //    Console.WriteLine("招手");
        //    Console.WriteLine($"{name}:4r7987！");
        //}

        public void SayHiChinese(string name)
        {
            Console.WriteLine("招手");
            Console.WriteLine($"{name}:晚上好！");
        }

        public void SayHiAmerican(string name)
        {
            Console.WriteLine("招手");
            Console.WriteLine($"{name}:good evening！");
        }

        public void SayHiJapanese(string name)
        {
            Console.WriteLine("招手");
            Console.WriteLine($"{name}:#@%￥%……%%…！！");
        }

        public void Study()
        {
            Console.WriteLine("学习.net高级班公开课");
        }

        public static void StudyAdvanced()
        {
            Console.WriteLine("学习.net高级班vip课");
        }

        public static void Show()
        {
            Console.WriteLine("123");
        }


    }

    public delegate void SayHiDelegate(string name);


    public enum PeopleType
    {
        /// <summary>
        /// 中国人
        /// </summary>
        Chinese = 1,
        /// <summary>
        /// 美国人
        /// </summary>
        American = 2,

        /// <summary>
        /// 日本人
        /// </summary>
        Japanese = 3

    }
}
