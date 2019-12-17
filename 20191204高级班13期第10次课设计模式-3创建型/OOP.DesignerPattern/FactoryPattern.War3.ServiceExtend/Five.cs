using FactoryPattern.War3.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.War3.ServiceExtend
{
    /// <summary>
    /// War3种族之一
    /// </summary>
    public class Five : IRace
    {
        public Five()
            : this(1, "old", 1)//当前类的构造函数
        {

        }
        public Five(int id, string name, int version)
        { }

        public void ShowKing()
        {
            Console.WriteLine("The King of {0} is {1}", this.GetType().Name, "Moon");
        }
    }
}
