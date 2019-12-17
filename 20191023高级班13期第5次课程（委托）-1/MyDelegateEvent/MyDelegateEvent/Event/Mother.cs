using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDelegateEvent.Event
{
    /// <summary>
    /// 订户
    /// </summary>
    public class Mother : IObject
    {
        public void DoAction()
        {
            this.Wispher();
        }
        public void Wispher()
        {
            Console.WriteLine("{0} Wispher", this.GetType().Name);
        }
    }
}
