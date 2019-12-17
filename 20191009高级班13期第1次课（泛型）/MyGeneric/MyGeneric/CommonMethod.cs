using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGeneric
{
    public class CommonMethod
    {
        /// <summary>
        /// 打印个int值 
        /// </summary>
        /// <param name="iParameter"></param>
        public static void ShowInt(int iParameter)
        {
            Console.WriteLine("This is {0},parameter={1},type={2}",
                typeof(CommonMethod).Name, iParameter.GetType().Name, iParameter);
        }
        /// <summary>
        /// 打印个string值
        /// </summary>
        /// <param name="sParameter"></param>
        public static void ShowString(string sParameter)
        {
            Console.WriteLine("This is {0},parameter={1},type={2}",
                typeof(CommonMethod).Name, sParameter.GetType().Name, sParameter);
        }
        /// <summary>
        /// 打印个DateTime值
        /// </summary>
        /// <param name="oParameter"></param>
        public static void ShowDateTime(DateTime dtParameter)
        {
            Console.WriteLine("This is {0},parameter={1},type={2}",
                typeof(CommonMethod).Name, dtParameter.GetType().Name, dtParameter);
        }

        //如果做数据库查询，每一个实体对应的表，那岂不是每一个实体都要写一个方法吗？


        /// <summary> 
        ///为什么用object 作为参数类型，调用的时候，可以把任何类型都传进来
        ///
        ///C#: 任何父类出现的地方  都可以用子类代替；
        ///Object类型是一切类型的父类
        ///
        ///Object 出现的都可以让任何类型传进来
        /// 
        /// 但是：有2个问题
        ///        性能问题：会出现装箱和拆箱；
        ///        类型安全问题。 
        /// </summary>
        /// <param name="oParameter"></param>
        public static void ShowObject(object oParameter)
        {
            Console.WriteLine("This is {0},parameter={1},type={2}",
                typeof(CommonMethod), oParameter.GetType().Name, oParameter);
        }

        /// <summary>
        /// 泛型方法：需要在方法名的后面带一个<>，需要定义T, T是什么呢？ 不知道， 
        /// T：类型参数,只是一个占位符，类型在声明其实不确定，在调用的时候，确定类型。
        ///  
        /// 延迟声明，推迟一切可以推迟的，事情能晚点做就晚点做。 
        /// 在使用的时候，需要指定明确的类型
        /// 泛型方法性能和普通方法差不多，可以用一个方法满足多个类型的需求 
        /// 鱼与熊掌兼得
        /// 又叫马儿跑，又叫马儿不吃草
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tParameter"></param>
        public static void Show<T>(T tParameter)
        {
            Console.WriteLine("This is {0},parameter={1},type={2}",
                typeof(CommonMethod), tParameter.GetType().Name, tParameter);
        }

    }
}
