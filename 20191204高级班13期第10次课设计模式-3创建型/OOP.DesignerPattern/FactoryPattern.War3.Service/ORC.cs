using FactoryPattern.War3.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.War3.Service
{
    /// <summary>
    /// War3种族之一
    /// </summary>
    public class ORC : IRace
    {
        public void ShowKing()
        {
            Console.WriteLine("The King of {0} is {1}", this.GetType().Name, "Grubby");
        }
    }

    public class ORCArmy : IArmy
    {

        public void ShowArmy()
        {
            Console.WriteLine("The Army of {0} is {1}", this.GetType().Name, "大G、风骑士、蝙蝠、战车、牛头人");
        }
    }

    public class ORCHero : IHero
    {
        public void ShowHero()
        {
            Console.WriteLine("The Army of {0} is {1}", this.GetType().Name, "剑圣、小萨满、先知、牛头人酋长");
        }
    }
    public class ORCResource : IResource
    {

        public void ShowResource()
        {
            Console.WriteLine("The Army of {0} is {1}", this.GetType().Name, "1000G1000W");
        }
    }
}
