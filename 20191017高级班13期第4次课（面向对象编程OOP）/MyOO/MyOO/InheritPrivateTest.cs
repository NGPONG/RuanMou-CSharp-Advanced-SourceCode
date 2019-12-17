using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyOO
{
    public class InheritPrivateTest
    {
        /// <summary>
        /// private的东西，子类到底能不能继承到呢
        /// </summary>
        public static void Show()
        {
            {
                Console.WriteLine("***************Parent****************");
                Type type = typeof(ParentClassWithPrivate);
                foreach (var item in type.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic))
                {
                    Console.WriteLine(item.Name);
                }
                foreach (var item in type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic))
                {
                    Console.WriteLine(item.Name);
                }
            }
            //私有元素没有继承  object可以看看

            {
                Console.WriteLine("***************Child****************");
                Type type = typeof(ChildClassInheritParent);
                foreach (var item in type.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic))
                {
                    Console.WriteLine(item.Name);
                }
                foreach (var item in type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic))
                {
                    Console.WriteLine(item.Name);
                }
            }
        }
       
    }

    public class ParentClassWithPrivate
    {
        private int Id { get; set; }

        private void Test()
        {
            Console.WriteLine("123456");
        }
    }

    public class ChildClassInheritParent : ParentClassWithPrivate
    {
        public void Do()
        {
            //base.Test();//肯定不能直接访问
            //base.Id;
        } 
    }
}
