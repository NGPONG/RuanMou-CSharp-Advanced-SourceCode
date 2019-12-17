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
    public class RedisHelperObject : IHelper
    {
        ///// <summary>
        ///// 方法注入：需要才注入，可变的，可能为空
        ///// </summary>
        //private RedisHelper _RedisHelper = null;
        //public void SetHelper(RedisHelper rHelper)
        //{
        //    this._RedisHelper = rHelper;
        //}

        ///// <summary>
        ///// 构造函数注入，构造就得传进来不可能为空，可变的
        ///// </summary>
        //private RedisHelper _RedisHelper = null;
        //public RedisHelperObject(RedisHelper rHelper)
        //{
        //    this._RedisHelper = rHelper;
        //    Console.WriteLine($"构造RedisHelperInherit");
        //}

        //属性/字段注入 写死的 不可能空
        private RedisHelper _RedisHelper = new RedisHelper();
        public RedisHelperObject()
        {
            Console.WriteLine($"构造RedisHelperInherit");
        }
        public void Add<T>()
        {
            this._RedisHelper.AddRedis<T>();
        }
        public void Delete<T>()
        {
            this._RedisHelper.DeleteRedis<T>();
        }
        public void Update<T>()
        {
            this._RedisHelper.UpdateRedis<T>();
        }
        public void Query<T>()
        {
            this._RedisHelper.QueryRedis<T>();
        }
    }
}
