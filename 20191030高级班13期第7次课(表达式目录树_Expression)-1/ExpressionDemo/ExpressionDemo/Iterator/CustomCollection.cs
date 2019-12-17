using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExpressionDemo.Iterator
{
    /// <summary>
    /// 
    /// </summary>
    public class IEnumerableDemo
    {
        //private IEnumerable<int> _IntList = null;

        private List<int> _IntList = null;
        public IEnumerableDemo()
        {
            List<int>  intList = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                intList.Add(this.Get());
            }
            this._IntList = intList;
        }
        private int Get()
        {
            Thread.Sleep(1000);
            return DateTime.Now.Second;
        }
        /// <summary>
        /// 遍历
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < this._IntList.Count(); i++)
            {
                yield return this._IntList[i];
            }
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public class IQueryableDemo
    {
        private IQueryable<int> _IntList = null;
        public IQueryableDemo()
        {
           
        }
        private int Get()
        {
            Thread.Sleep(1000);
            return DateTime.Now.Second;
        }
        /// <summary>
        /// 遍历
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < 10; i++)
            {
                yield return this.Get();
            }
        }
    }
}
