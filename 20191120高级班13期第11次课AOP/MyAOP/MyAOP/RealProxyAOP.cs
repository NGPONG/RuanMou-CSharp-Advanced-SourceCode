using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.Text;
using System.Threading.Tasks;

namespace MyAOP
{
    /// <summary>
    /// 使用.Net Remoting/RealProxy 实现动态代理
    /// 局限在业务类必须是继承自MarshalByRefObject类型
    /// </summary>
    public class RealProxyAOP
    {
        public static void Show()
        {
            User user = new User()
            {
                Name = "Richard",
                Password = "123456"
            };

            UserProcessor processor = new UserProcessor();
            processor.RegUser(user);

            Console.WriteLine("*********************");
            UserProcessor userProcessor = TransparentProxy.Create<UserProcessor>();
            userProcessor.RegUser(user);
        }

        /// <summary>
        /// 真实代理
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class MyRealProxy<T> : RealProxy
        {
            private T tTarget;
            public MyRealProxy(T target)
                : base(typeof(T))
            {
                this.tTarget = target;
            }

            public override IMessage Invoke(IMessage msg)
            {
                BeforeProceede(msg);//Log  try-catch

                IMethodCallMessage callMessage = (IMethodCallMessage)msg;
                object returnValue = callMessage.MethodBase.Invoke(this.tTarget, callMessage.Args);

                AfterProceede(msg);

                return new ReturnMessage(returnValue, new object[0], 0, null, callMessage);
            }
            public void BeforeProceede(IMessage msg)
            {
                Console.WriteLine("方法执行前可以加入的逻辑");
            }
            public void AfterProceede(IMessage msg)
            {
                Console.WriteLine("方法执行后可以加入的逻辑");
            }
        }

        /// <summary>
        /// 透明代理
        /// </summary>
        public static class TransparentProxy
        {
            public static T Create<T>()
            {
                T instance = Activator.CreateInstance<T>();
                MyRealProxy<T> realProxy = new MyRealProxy<T>(instance);
                T transparentProxy = (T)realProxy.GetTransparentProxy();
                return transparentProxy;
            }
        }


        public interface IUserProcessor
        {
            void RegUser(User user);
        }

        /// <summary>
        /// 必须继承自MarshalByRefObject父类，否则无法生成
        /// </summary>
        public class UserProcessor : MarshalByRefObject, IUserProcessor
        {
            public void RegUser(User user)
            {
                Console.WriteLine("用户已注册。用户名称{0} Password{1}", user.Name, user.Password);
            }
        }

    }
}
