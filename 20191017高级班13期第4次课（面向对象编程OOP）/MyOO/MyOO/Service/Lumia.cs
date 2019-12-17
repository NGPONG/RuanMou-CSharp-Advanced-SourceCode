using MyOO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOO.Service
{

    public class Lumia:BasePhone, IExtend
    {
        public int this[int i] => throw new NotImplementedException();

        public event Action DoNothing;

        public void PlayGame()
        {
          
        }
        //public int Id { get; set; }
        //public string Name { get; set; }
        //public string Branch { get; set; }

        public override void System()
        {
            Console.WriteLine($"{this.GetType().Name} System is WinPhone");
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
