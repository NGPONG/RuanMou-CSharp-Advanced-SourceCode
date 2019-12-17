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
    public class Human : IRace
    {
        public Human(int id, DateTime dateTime, string reamrk)
        { }
        public Human()
        { }

        public void ShowKing()
        {
            Console.WriteLine("The King of {0} is {1}", this.GetType().Name, "Sky");
        }
    }


    public class HumanArmy : IArmy
    {

        public void ShowArmy()
        {
            Console.WriteLine("The Army of {0} is {1}", this.GetType().Name, "footman，火枪，骑士，狮鹫");
        }
    }

    public class HumanHero : IHero
    {
        public void ShowHero()
        {
            Console.WriteLine("The Army of {0} is {1}", this.GetType().Name, "大法师、山丘、圣骑士、血法师");
        }
    }
    public class HumanResource : IResource
    {

        public void ShowResource()
        {
            Console.WriteLine("The Army of {0} is {1}", this.GetType().Name, "1000G1000W");
        }
    }
}
