using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.DesignerPattern.ObserverPattern.Observer
{
    public class Father : IObserver
    {
        public void Action()
        {
            this.Roar();
        }
        public void Roar()
        {
            Console.WriteLine("{0} Roar", this.GetType().Name);
        }
    }
}
