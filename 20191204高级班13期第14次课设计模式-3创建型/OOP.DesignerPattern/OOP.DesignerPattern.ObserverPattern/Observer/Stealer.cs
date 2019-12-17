using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.DesignerPattern.ObserverPattern.Observer
{
    public class Stealer : IObserver
    {
        public void Action()
        {
            this.Hide();
        }
        public void Hide()
        {
            Console.WriteLine("{0} Hide", this.GetType().Name);
        }
    }
}
