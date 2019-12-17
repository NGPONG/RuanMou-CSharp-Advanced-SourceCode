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
    public class Undead : IRace
    {
        public void ShowKing()
        {
            Console.WriteLine("The King of {0} is {1}", this.GetType().Name, "GoStop");
        }
    }

    public class UndeadArmy : IArmy
    {

        public void ShowArmy()
        {
            Console.WriteLine("The Army of {0} is {1}", this.GetType().Name, "食尸鬼,蜘蛛，雕像，战车，憎恶，冰霜巨龙");
        }
    }

    public class UndeadHero : IHero
    {
        public void ShowHero()
        {
            Console.WriteLine("The Army of {0} is {1}", this.GetType().Name, "DK、Lich、小强、恐惧魔王");
        }
    }
    public class UndeadResource : IResource
    {

        public void ShowResource()
        {
            Console.WriteLine("The Army of {0} is {1}", this.GetType().Name, "1000G1000W");
        }
    }


}
