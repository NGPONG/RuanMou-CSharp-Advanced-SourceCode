using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDelegateEvent.Event
{
    public class Brother : IObject
    {
        public void DoAction()
        {
            this.Turn();
        }
        public void Turn()
        {
            Console.WriteLine("{0} Turn", this.GetType().Name);
        }
    }
}
