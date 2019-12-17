using System;

namespace Ruanmou.Model
{
    /// <summary>
    /// 实体
    /// </summary>
    public class People
    {
        public People()
        {
            Console.WriteLine("{0}被创建", this.GetType().FullName);
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description; 
    }
}
