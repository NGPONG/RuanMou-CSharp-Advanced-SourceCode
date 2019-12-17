using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.DesignerPattern.ProxyPattern
{
    /// <summary>
    /// 没有什么技术问题是包一层不能解决的
    /// 我的地盘听我的，可以随意搞事情
    /// 日志/异常处理/权限/单例/缓存/事务。。
    /// 只要不是业务逻辑，都可以在这里扩展，而不影响Real
    /// </summary>
    public class ProxySubject : ISubject
    {
        //private static ISubject _iSubject = new RealSubject();
        private ISubject _iSubject = new RealSubject();
        public void DoSomething()
        {
            try
            {
                Console.WriteLine("This is DoSomething Before");
                this._iSubject.DoSomething();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // 缓存一下  加个用户检测  事务
        public bool GetSomething()
        {
            return this._iSubject.GetSomething();
        }

        //public void TrySomething()
        //{
            
        //}
    }
}
