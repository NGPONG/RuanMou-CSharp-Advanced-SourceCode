using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGeneric
{
    /// <summary>
    /// 泛型方法
    /// </summary>
    public class GenericTest
    {
        public static void Show<T>(T tParameter)
        {
            Console.WriteLine("This is {0},parameter={1},type={2}",
                typeof(CommonMethod), tParameter.GetType().Name, tParameter);
        }
    }

    /// <summary>
    /// 泛型类型  就是一个类型 满足多个类型的需求
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericClass<T>
    { 

    }

    public class ChildClass<S, T> : GenericClass<S>, GenericInterface<T>
    {
    }

    public class ChildClass1 : GenericInterface<int>
    {
    }

    /// <summary>
    /// 泛型接口  就是一个接口 满足多个多个类型的需求
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface GenericInterface<T>
    {
    }

    /// <summary>
    /// 泛型委托 就是一个委托 满足多个多个类型的需求
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public delegate void Do<T>();


}
