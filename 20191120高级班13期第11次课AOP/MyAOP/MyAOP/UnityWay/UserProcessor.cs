using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAOP.UnityWay
{

    // 通过IOC 依赖注入支持扩展AOP
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
}
