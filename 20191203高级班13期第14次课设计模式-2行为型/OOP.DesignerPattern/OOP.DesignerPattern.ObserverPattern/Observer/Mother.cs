using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.DesignerPattern.ObserverPattern.Observer
{
    public class Mother : IObserver
    {
        public void Action()
        {
            this.Whisper();
        }
        public void Whisper()
        {
            Console.WriteLine("{0} Whisper", this.GetType().Name);
        }
    }
}
