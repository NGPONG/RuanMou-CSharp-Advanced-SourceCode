using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDelegateEvent.Event
{
    public class Neighbor : IObject
    {
        public void DoAction()
        {
            this.Awake();
        }
        public void Awake()
        {
            Console.WriteLine("{0} Awake", this.GetType().Name);
        }
    }
}
