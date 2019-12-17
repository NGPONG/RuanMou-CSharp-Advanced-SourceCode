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
    public class ExceptionLoggingBehavior : IInterceptionBehavior
    {
        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            Console.WriteLine("ExceptionLoggingBehavior");
            IMethodReturn methodReturn = getNext()(input, getNext);
            if (methodReturn.Exception == null)
            {
                Console.WriteLine("无异常");
            }
            else
            {
                Console.WriteLine($"异常:{methodReturn.Exception.Message}");
            }
            return methodReturn;
        }

        public bool WillExecute
        {
            get { return true; }
        }
    }
}
