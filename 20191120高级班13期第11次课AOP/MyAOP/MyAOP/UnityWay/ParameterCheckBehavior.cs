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
    public class ParameterCheckBehavior : IInterceptionBehavior
    {
        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            Console.WriteLine("ParameterCheckBehavior");
            //通过特性校验
            User user = input.Inputs[0] as User;
            if (user.Password.Length < 10)
            {
                //throw new Exception(); 
                return input.CreateExceptionMethodReturn(new Exception("密码长度不能小于10位"));
            }
            else
            {
                Console.WriteLine("参数检测无误");
                return getNext().Invoke(input, getNext);
            }
        }

        public bool WillExecute
        {
            get { return true; }
        }
    }
}
