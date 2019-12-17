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
    public class LogAfterBehavior : IInterceptionBehavior
    {
        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }


        //一切正常的  刷个1
        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            Console.WriteLine("LogAfterBehavior");
            foreach (var item in input.Inputs)
            {
                Console.WriteLine(item.ToString());//反射获取更多信息
            }
            IMethodReturn methodReturn = getNext()(input, getNext);
            Console.WriteLine("LogAfterBehavior" + methodReturn.ReturnValue);
            return methodReturn;
        }

        public bool WillExecute
        {
            get { return true; }
        }
    }
}
