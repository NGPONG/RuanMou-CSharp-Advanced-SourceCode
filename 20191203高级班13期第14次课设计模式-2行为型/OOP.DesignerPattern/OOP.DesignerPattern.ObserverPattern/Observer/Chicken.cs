using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.DesignerPattern.ObserverPattern.Observer
{
    public class Chicken : IObserver
    {
        public void Action()
        {
            this.Woo();
        }
        public void Woo()
        {
            Console.WriteLine("{0} Woo", this.GetType().Name);
        }
    }
}
