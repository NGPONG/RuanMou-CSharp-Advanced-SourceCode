using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDelegateEvent.Event
{
    /// <summary>
    ///
    /// </summary>
    public class Cat
    {
        public void Miao()
        {
            Console.WriteLine("{0} Miao", this.GetType().Name);
            new Dog().Wang(); //狗叫了
            new Mouse().Run();//老鼠跑了
            new Baby().Cry(); // 小孩哭了
            new Mother().Wispher(); 
            new Father().Roar();
            new Neighbor().Awake();
            new Stealer().Hide();
        }
    }
}
