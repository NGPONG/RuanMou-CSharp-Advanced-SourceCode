using FactoryPattern.War3.Interface;
using FactoryPattern.War3.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.DesignerPattern.ThreeFactory.AbstractFactroy
{
    public class UndeadFactoryAbstract : AbstractFactoryBase
    {
        public override IRace CreatRace()
        {
            return new Undead();
        }
        public override IArmy CreateArmy()
        {
            return new UndeadArmy();
        }
        public override IResource CreateResource()
        {
            return new UndeadResource();
        }
    }
}
