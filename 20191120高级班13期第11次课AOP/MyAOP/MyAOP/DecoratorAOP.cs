using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAOP
{
    /// <summary>
    /// 装饰器模式实现静态代理
    /// AOP 在方法前后增加自定义的方法
    /// </summary>
    public class DecoratorAOP
    {
        public static void Show()
        {
            User user = new User()
            {
                Name = "Richard",
                Password = "123123123123"
            };
            IUserProcessor processor = new UserProcessor();
            processor.RegUser(user);
            Console.WriteLine("***************");

            processor = new UserProcessorDecorator(processor);
            processor.RegUser(user);
        }

        public interface IUserProcessor
        {
            void RegUser(User user);
        }
        public class UserProcessor : IUserProcessor
        {
            public void RegUser(User user)
            {
                Console.WriteLine("用户已注册。Name:{0},PassWord:{1}", user.Name, user.Password);
            }
        }
        /// <summary>
        /// 装饰器的模式去提供一个AOP功能
        /// </summary>
        public class UserProcessorDecorator : IUserProcessor
        {
            private IUserProcessor _UserProcessor { get; set; }
            public UserProcessorDecorator(IUserProcessor userprocessor)
            {
                this._UserProcessor = userprocessor;
            }

            public void RegUser(User user)
            {
                BeforeProceed(user);

                this._UserProcessor.RegUser(user);

                AfterProceed(user);
            }

            /// <summary>
            /// 业务逻辑之前
            /// </summary>
            /// <param name="user"></param>
            private void BeforeProceed(User user)
            {
                Console.WriteLine("方法执行前");
            }
            /// <summary>
            /// 业务逻辑之后
            /// </summary>
            /// <param name="user"></param>
            private void AfterProceed(User user)
            {
                Console.WriteLine("方法执行后");
            }
        }

    }
}
