using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Unity;
using Unity.Interception;
using Unity.Interception.ContainerIntegration;
using Unity.Interception.Interceptors.InstanceInterceptors.InterfaceInterception;
using Unity.Interception.PolicyInjection.Pipeline;
using Unity.Interception.PolicyInjection.Policies;//InterceptionExtension

namespace MyAOP
{
    /// <summary>
    /// 使用EntLib\PIAB Unity 实现动态代理
    /// 
    /// </summary>
    public class UnityAOP
    {
        public static void Show()
        {
            //Microsoft.Practices.Unity.Configuration.
            User user = new User()
            {
                Name = "Richard",
                Password = "1234567890123456789"
            };

            IUnityContainer container = new UnityContainer();//声明一个容器
            container.RegisterType<IUserProcessor, UserProcessor>();//声明UnityContainer并注册IUserProcessor
            //IUserProcessor processor = container.Resolve<IUserProcessor>();
            //processor.RegUser(user);//调用

            container.AddNewExtension<Interception>();
            container.RegisterType<IUserProcessor, UserProcessor>()
            .Configure<Interception>()
                .SetInterceptorFor<IUserProcessor>(new InterfaceInterceptor());


            //IUserProcessor userprocessor = new UserProcessor();
            IUserProcessor userprocessor = container.Resolve<IUserProcessor>();

            Console.WriteLine("********************");
            userprocessor.RegUser(user);//调用
            userprocessor.GetUser(user);//调用
        }

        #region 特性对应的行为
        public class UserHandler : ICallHandler
        {
            public int Order { get; set; }
            public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
            {
                User user = input.Inputs[0] as User;
                if (user.Password.Length < 10)
                {
                    return input.CreateExceptionMethodReturn(new Exception("密码长度不能小于10位"));
                }
                Console.WriteLine("参数检测无误");

                IMethodReturn methodReturn = getNext()(input, getNext); //getNext.Invoke().Invoke(input, getNext);

                //Console.WriteLine("已完成操作");

                return methodReturn;
            }
        }

        public class LogHandler : ICallHandler
        {
            public int Order { get; set; }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="input">方法调用的参数列表</param>
            /// <param name="getNext"></param>
            /// <returns></returns>
            public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
            {
                User user = input.Inputs[0] as User;
                string message = $"RegUser:Username:{user.Name},Password:{user.Password}";
                Console.WriteLine("日志已记录，Message:{0},Ctime:{1}", message, DateTime.Now);
                return getNext()(input, getNext);
            }
        }


        public class ExceptionHandler : ICallHandler
        {
            public int Order { get; set; }
            public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
            {
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
        }

        public class AfterLogHandler : ICallHandler
        {
            public int Order { get; set; }
            public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
            {
                IMethodReturn methodReturn = getNext()(input, getNext);
                User user = input.Inputs[0] as User;
                string message = string.Format("RegUser:Username:{0},Password:{1}", user.Name, user.Password);
                Console.WriteLine("完成日志，Message:{0},Ctime:{1},计算结果{2}", message, DateTime.Now, methodReturn.ReturnValue);
                return methodReturn;
            }
        }
        #endregion 特性对应的行为

        #region 特性
        public class UserHandlerAttribute : HandlerAttribute
        {
            public override ICallHandler CreateHandler(IUnityContainer container)
            {
                ICallHandler handler = new UserHandler() { Order = this.Order };
                return handler;
            }
        }

        public class LogHandlerAttribute : HandlerAttribute
        {
            public override ICallHandler CreateHandler(IUnityContainer container)
            {
                return new LogHandler() { Order = this.Order };
            }
        }

        public class ExceptionHandlerAttribute : HandlerAttribute
        {
            public override ICallHandler CreateHandler(IUnityContainer container)
            {
                return new ExceptionHandler() { Order = this.Order };
            }
        }

        public class AfterLogHandlerAttribute : HandlerAttribute
        {
            public override ICallHandler CreateHandler(IUnityContainer container)
            {
                return new AfterLogHandler() { Order = this.Order };
            }
        }
        #endregion 特性

        #region 业务
        [UserHandlerAttribute(Order = 1)]
        //[ExceptionHandlerAttribute(Order = 3)]
        //[LogHandlerAttribute(Order = 2)]
        //[AfterLogHandlerAttribute(Order = 5)]
        public interface IUserProcessor
        {
            void RegUser(User user);
            User GetUser(User user);
        }

        public class UserProcessor : IUserProcessor
        {
            public void RegUser(User user)
            {
                Console.WriteLine("用户已注册。");
                //throw new Exception("11");
            }

            public User GetUser(User user)
            {
                return user;
            }
        }
        #endregion 业务

        /*
         TransparentProxyInterceptor：直接在类的方法上进行标记，但是这个类必须继承MarshalByRefObject...不建议用
         VirtualMethod：直接在类的方法上进行标记，但这个方法必须是虚方法（就是方法要带virtual关键字）
         InterfaceInterceptor：在接口的方法上进行标记，这样继承这个接口的类里实现这个接口方法的方法就能被拦截
         */
    }
}
