using FactoryPattern.War3.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.DesignerPattern.ThreeFactory.AbstractFactroy
{
    public abstract class AbstractFactoryBase
    {
        public abstract IRace CreatRace();
        public abstract IArmy CreateArmy();

        public abstract IResource CreateResource();
    }
}
