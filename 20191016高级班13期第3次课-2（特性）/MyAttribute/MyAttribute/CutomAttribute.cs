using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class CutomAttribute : Attribute
    {
        public CutomAttribute()
        {
            Console.WriteLine("无参数构造函数");
        }
        public CutomAttribute(int i)
        {
            Console.WriteLine("Int类型构造函数");
        }

        public CutomAttribute(int i, string j)
        {
            Console.WriteLine("两个参数构造函数");
        }
        public string Remark { get; set; }

        public string Description;

        public void Show()
        {
            Console.WriteLine("通过反射调用特性中的方法");
        }
    }

    public class CutomAttributeChild : CutomAttribute
    {
        public CutomAttributeChild() : base(345)
        {
        }
    }
}
