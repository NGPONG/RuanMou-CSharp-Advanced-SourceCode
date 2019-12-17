using MyOO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOO.Service
{
    public class iPhone:BasePhone, IExtend,IExtendExp
    {
        public int this[int i] => throw new NotImplementedException();

        public event Action DoNothing;

        public void Photo()
        {
            throw new NotImplementedException();
        }

        public void PlayGame()
        {
            throw new NotImplementedException();
        }

        public void Show()
        {
            throw new NotImplementedException();
        }

        //public int Id { get; set; }
        //public string Name { get; set; }
        //public string Branch { get; set; }

        public override void System()
        {
            Console.WriteLine($"{this.GetType().Name} System is IOS");
        }
        //public void Call()
        //{
        //    Console.WriteLine($"Use {this.GetType().Name} Call");
        //}
        //public void Text()
        //{
        //    Console.WriteLine($"Use {this.GetType().Name} Call");
        //} 
    }
}
