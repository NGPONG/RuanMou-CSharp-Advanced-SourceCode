using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGeneric.Extend
{
    /// <summary>
    /// 只能放在接口或者委托的泛型参数前面
    /// out 协变covariant    修饰返回值 
    /// in  逆变contravariant  修饰传入参数
    /// </summary>
    public class CCTest
    {
        public static void Show()
        {
            {
                Bird bird1 = new Bird();
                Bird bird2 = new Sparrow();
                Sparrow sparrow1 = new Sparrow();
                /* Sparrow sparrow2 = new Bird()*/
                ;
            }

            {
                List<Bird> birdList1 = new List<Bird>();
                //List<Bird> birdList2 = new List<Sparrow>(); 
                //难道一组麻雀不是一组鸟吗？
                //List<Bird> 是一个类， List<Sparrow> 是另外一个类，二者没有继承

                List<Bird> birdList3 = new List<Sparrow>().Select(c => (Bird)c).ToList();

            }
            //泛型在使用的时候，会存在不和谐的地方
            // 协变和逆变  都是在泛型中才有，在泛型接口 或者泛型委托才有
            {//out修改类型参数，协变:可以让右边使用子类

                // 使用协变时候，可以把子类放在右边，这才是泛型该有的样子

                IEnumerable<Bird> birdList1 = new List<Bird>();
                IEnumerable<Bird> birdList2 = new List<Sparrow>(); //为什么可以写？
                 
                ICustomerListOut<Bird> customerList1 = new CustomerListOut<Bird>();
                ICustomerListOut<Bird> customerList2 = new CustomerListOut<Sparrow>();
            }

            {//逆变
                //int修改类型参数，逆变:可以让右边使用父类
                // 类型参数只能作为参数 ，不能作为返回值

                ICustomerListIn<Sparrow> customerList2 = new CustomerListIn<Sparrow>();
                ICustomerListIn<Sparrow> customerList1 = new CustomerListIn<Bird>();

                customerList1.Show(new Sparrow());

                ICustomerListIn<Bird> birdList1 = new CustomerListIn<Bird>();
                birdList1.Show(new Sparrow());
                birdList1.Show(new Bird());

            }

            {
                IMyList<Sparrow, Bird> myList1 = new MyList<Sparrow, Bird>();
                IMyList<Sparrow, Bird> myList2 = new MyList<Sparrow, Sparrow>();//协变
                IMyList<Sparrow, Bird> myList3 = new MyList<Bird, Bird>();//逆变
                IMyList<Sparrow, Bird> myList4 = new MyList<Bird, Sparrow>();//协变+逆变
            }

            //完全能理清楚 刷个1  
            //能清楚80%  2   60%  3
        }
    }

    public class Bird
    {
        public int Id { get; set; }
    }
    public class Sparrow : Bird
    {
        public string Name { get; set; }
    }

    public interface ICustomerListIn<in T>
    {
       //T Get();

        void Show(T t);
    }

    public class CustomerListIn<T> : ICustomerListIn<T>
    {
        //public T Get()
        //{
        //    return default(T);
        //}

        public void Show(T t)
        {
        }
    }

    /// <summary>
    /// 用out修改  协变  T 就只能做返回值 ，不能做参数
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICustomerListOut<out T>
    {
        T Get();
        //void Show(T t);
    }

    public class CustomerListOut<T> : ICustomerListOut<T>
    {
        public T Get()
        {
            return default(T);
        }

        //public void Show(T t)
        //{

        //}
    }


    public interface IMyList<in inT, out outT>
    {
        void Show(inT t);
        outT Get();
        outT Do(inT t);

        ////out 只能是返回值   in只能是参数
        //void Show1(outT t);
        //inT Get1();

    }

    public class MyList<T1, T2> : IMyList<T1, T2>
    {

        public void Show(T1 t)
        {
            Console.WriteLine(t.GetType().Name);
        }

        public T2 Get()
        {
            Console.WriteLine(typeof(T2).Name);
            return default(T2);
        }

        public T2 Do(T1 t)
        {
            Console.WriteLine(t.GetType().Name);
            Console.WriteLine(typeof(T2).Name);
            return default(T2);
        }
    }

}
