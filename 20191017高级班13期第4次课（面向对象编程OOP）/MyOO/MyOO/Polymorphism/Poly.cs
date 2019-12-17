using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOO.Polymorphism
{
    /// <summary>
    /// 
    /// </summary>
    public class Poly
    {
        public static void Test()
        {
            Console.WriteLine("*******************************************");
            Console.WriteLine("*******************************************");
            Console.WriteLine("*******************************************");

            ParentClass instance = new ChildClass(); 

            //ParentClass instance1 = new ChildClass(); 
            //ChildClass instanceChild = new ChildClass();
            //instance.VirtualMethod("");
            //instance.VirtualMethod();

            Console.WriteLine("下面是instance.CommonMethod()");
            instance.CommonMethod(); //执行父类方法 ，普通方法执行是由编译时决定

            Console.WriteLine("下面是instance.VirtualMethod()");
            instance.VirtualMethod(); //子类覆写的虚方法  虚方法是由运行时决定
            Console.WriteLine("下面是instance.AbstractMethod()");
            instance.AbstractMethod(); // 子类实现的抽象方法， 子类方法，由运行时决定--多态

            Console.WriteLine("*******************************************");
            Console.WriteLine("*******************************************");
            Console.WriteLine("*******************************************");
        }
        //{
        // ChildClass instance = new ChildClass();
        //}
    }

    #region abstract
    public abstract class ParentClass
    {

        public ParentClass(int id)
        { }

        /// <summary>
        /// CommonMethod
        /// </summary>
        public void CommonMethod()
        {
            Console.WriteLine("ParentClass CommonMethod");
        }

        /// <summary>
        /// virtual  虚方法  必须包含实现 但是可以被重载
        /// </summary>
        public virtual void VirtualMethod()
        {
            Console.WriteLine("ParentClass VirtualMethod");
        }

        public virtual void VirtualMethod(string name)
        {
            Console.WriteLine("ParentClass VirtualMethod");
        }

        /// <summary>
        /// 抽象方法在子列是必须实现
        /// </summary>
        public abstract void AbstractMethod();
    }

    public class ChildClass : ParentClass
    {
        /// <summary>
        /// 实例化子类的时候，是先完成父类的实例化的
        /// </summary>
        public ChildClass()
            : base(3)//调用父类的构造函数
        {
        }

        /// <summary>
        /// new 隐藏(重写方法)
        /// </summary>
        public new void CommonMethod()
        {
            Console.WriteLine("ChildClass CommonMethod");
            // base this
        }


        /// <summary>
        /// virtual 可以被覆写
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override void VirtualMethod()
        {
            Console.WriteLine("ChildClass VirtualMethod");
            base.VirtualMethod();
        }

        /// <summary>
        /// 抽象方法必须覆写
        /// </summary>
        public override void AbstractMethod()
        {
            Console.WriteLine("ChildClass AbstractMethod");
        }
    }

    public class GrandClass : ChildClass
    {
        public override void VirtualMethod()
        {
            base.VirtualMethod();
        }
    }
    #endregion abstract

}
