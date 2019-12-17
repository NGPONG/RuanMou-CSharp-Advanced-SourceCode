using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.DesignerPattern.ObserverPattern.Observer
{
    public class Brother : IObserver
    {
        public void Action()
        {
            this.Turn();
        }
        public void Turn()
        {
            Console.WriteLine("{0} Turn", this.GetType().Name);
        }
    }
}
