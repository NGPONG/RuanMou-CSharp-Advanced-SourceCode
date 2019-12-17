using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOO.Interface
{
    public abstract class BasePhone
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Branch { get; set; }

        public abstract void System();// 没有方法体(只是一个声明)
        //{
        //    Console.WriteLine($"{this.GetType().Name} System is IOS");
        //}
        public void Call()
        {
            Console.WriteLine($"Use {this.GetType().Name} Call");
        }
        public void Text()
        {
            Console.WriteLine($"Use {this.GetType().Name} Call");
        }
    }
}
