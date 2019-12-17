using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.DesignerPattern.AdapterPattern
{
    /// <summary>
    /// 第三方提供的  openstack  servicestack
    /// 不能修改
    /// </summary>
    public class RedisHelperInherit : RedisHelper, IHelper
    {
        public RedisHelperInherit()
        {
            Console.WriteLine($"构造RedisHelperInherit");
        }
        public void Add<T>()
        {
            base.AddRedis<T>();
        }

        public void Delete<T>()
        {
            base.DeleteRedis<T>();
        }

        public void Update<T>()
        {
            base.UpdateRedis<T>();
        }

        public void Query<T>()
        {
            base.QueryRedis<T>();
        }
    }
}
