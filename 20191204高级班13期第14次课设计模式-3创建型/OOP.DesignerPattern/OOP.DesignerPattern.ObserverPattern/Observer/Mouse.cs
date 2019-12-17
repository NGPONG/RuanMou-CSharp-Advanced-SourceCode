using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.DesignerPattern.ObserverPattern.Observer
{
    public class Mouse : IObserver
    {
        public void Action()
        {
            this.Run();
        }
        public void Run()
        {
            Console.WriteLine("{0} Run", this.GetType().Name);
        }
    }
}
