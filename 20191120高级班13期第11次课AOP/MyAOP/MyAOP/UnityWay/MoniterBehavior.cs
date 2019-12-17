//using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.PolicyInjection.Pipeline;

namespace MyAOP.UnityWay
{
    /// <summary>
    /// 不需要特性
    /// </summary>
    public class MoniterBehavior : IInterceptionBehavior
    {
        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start(); 
            // 可以在这儿添加方法之前的逻辑
             
            var query = getNext().Invoke(input, getNext);


            stopwatch.Stop();
            Console.WriteLine($"执行耗时：{stopwatch.ElapsedMilliseconds} ms"); 
            return query; 
        }

        public bool WillExecute
        {
            get { return true; }
        }
    }
}
