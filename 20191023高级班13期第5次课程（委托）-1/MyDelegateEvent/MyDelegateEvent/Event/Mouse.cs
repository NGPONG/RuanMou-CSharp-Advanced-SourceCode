using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDelegateEvent.Event
{
    public class Mouse : IObject
    {
        public void DoAction()
        {
            this.Run();
        }
        public void Run()
        {
            Console.WriteLine("{0} Run", this.GetType().Name);
        }
    }
}
