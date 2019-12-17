using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOO
{
    public class Game
    {
        public int Id { get; set; }
         
        public void Start()
        {
            Console.WriteLine("开始游戏");
        }

        public void Fighting()
        {
            Console.WriteLine("正在游戏中");
        }

        public void Over()
        {
            Console.WriteLine(" 游戏结束");
        }
    }
}
