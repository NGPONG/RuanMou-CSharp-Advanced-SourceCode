using FactoryPattern.War3.Interface;
using FactoryPattern.War3.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.DesignerPattern.ThreeFactory.FactoryMethod
{
    public class HumanFactory : IFactory
    {
        public virtual IRace CreateInstance()
        {
            //IRace iRace = new Human();
            IRace iRace = new Human(123, DateTime.Now, "123");
            return iRace;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class HumanFactoryChild : HumanFactory
    {
        public override IRace CreateInstance()
        {
            Console.WriteLine("12345667..");
            //IRace iRace = new Human();
            IRace iRace = new Human(123, DateTime.Now, "123");
            return iRace;
        }
    }
}
