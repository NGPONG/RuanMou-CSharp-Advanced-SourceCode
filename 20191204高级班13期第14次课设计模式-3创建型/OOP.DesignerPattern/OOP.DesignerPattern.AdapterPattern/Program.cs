using System;

namespace OOP.DesignerPattern.AdapterPattern
{
    /// <summary>
    /// 适配器-- 
    /// iphone港版的插头--内地的插排就不吻合--转接器
    /// 笔记本电脑-电源转换器-220V
    /// 
    /// 
    /// 中场休息5分钟，大家可以提问
    /// 21:10分开始答疑
    /// </summary>
    public class Program
    {
        public static void Show()
        {
            {
                Console.WriteLine("*************************");
                IHelper helper = new MysqlHelper();
                helper.Query<Program>();
                helper.Delete<Program>();
                helper.Add<Program>();
                helper.Update<Program>();
            }
            {
                Console.WriteLine("*************************");
                IHelper helper = new SqlserverHelper();
                helper.Query<Program>();
                helper.Delete<Program>();
                helper.Add<Program>();
                helper.Update<Program>();
            }
            {
                Console.WriteLine("*************************");
                IHelper helper = new OracleHelper();
                helper.Query<Program>();
                helper.Delete<Program>();
                helper.Add<Program>();
                helper.Update<Program>();
            }
            //关系型数据库不能满足诉求，启用Redis，ServiceStack-SDK---第三方类库没有实现IHelper接口，所以不能直接沿用之前的写法
            {
                Console.WriteLine("*************************");
                IHelper helper = new RedisHelperInherit();//类适配器
                helper.Query<Program>();
                helper.Delete<Program>();
                helper.Add<Program>();
                helper.Update<Program>();
            }
            {
                Console.WriteLine("*************************");
                IHelper helper = new RedisHelperObject();//对象适配器
                helper.Query<Program>();
                helper.Delete<Program>();
                helper.Add<Program>();
                helper.Update<Program>();
            }
            //都能实现--实现了适配--why 组合优于继承呢？
            {
                //继承最大的问题是侵入性
                RedisHelperInherit redisHelper = new RedisHelperInherit();
                redisHelper.QueryRedis<Program>();
                //只能为单一类型服务 
            }
            {
                RedisHelperObject helper = new RedisHelperObject();//没有侵入性
                //组合的不好其实是产生新的类--复杂一点
                //三种注入方式; --可以换不同实例
                
                //相对灵活一点
            }
        }
    }
}
