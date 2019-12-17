using FactoryPattern.War3.Interface;
using FactoryPattern.War3.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.DesignerPattern.ThreeFactory.FactoryMethod
{
    public class UndeadFactory : IFactory
    {
        public IRace CreateInstance()
        {
            IRace iRace = new Undead();
            return iRace;
        }
    }
}
