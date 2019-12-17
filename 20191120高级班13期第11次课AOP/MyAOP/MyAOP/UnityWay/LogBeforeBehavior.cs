//using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.PolicyInjection.Pipeline;

namespace MyAOP.UnityWay
{
    /// <summary>
    /// 不需要特性
    /// 
    /// 必须实现IInterceptionBehavior
    /// </summary>
    public class LogBeforeBehavior : IInterceptionBehavior
    {
        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            Console.WriteLine("LogBeforeBehavior");
            foreach (var item in input.Inputs)
            {
                Console.WriteLine(item.ToString());//反射获取更多信息
            }
            var query = getNext().Invoke(input, getNext);

            //下一个节点的方法已经执行完毕   
            //在这里计入方法执行后的逻辑
            return query;

            //现在是21：53 大家开始提问 && 休息  21：57 开始答疑！期间老师不说话
        }

        public bool WillExecute
        {
            get { return true; }
        }
    }
}
