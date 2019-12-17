using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.DesignerPattern.AdapterPattern
{
    /// <summary>
    /// 
    /// </summary>
    public class CacheHelper
    {
        public void AddCache<T>()
        {
            Console.WriteLine("This is {0} Add", this.GetType().Name);
        }
        public void DeleteCache<T>()
        {
            Console.WriteLine("This is {0} Delete", this.GetType().Name);
        }
        public void UpdateCache<T>()
        {
            Console.WriteLine("This is {0} Update", this.GetType().Name);
        }
        public void QueryCache<T>()
        {
            Console.WriteLine("This is {0} Query", this.GetType().Name);
        }
    }
}
