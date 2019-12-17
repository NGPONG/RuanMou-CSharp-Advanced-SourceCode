using Ruanmou.DB.Interface;
using Ruanmou.DB.MySql;
using Ruanmou.DB.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using MyReflectiondFactory;

namespace MyReflection
{
    /// <summary>
    /// 1 dll-IL-metadata-反射
    /// 2 反射加载dll，读取module、类、方法
    /// 3 反射创建对象，反射+简单工厂+配置文件  选修：破坏单例 创建泛型
    /// 
    /// 
    /// 反射反射程序员的快乐
    /// 反射是无处不在，MVC  AOP  IOC  ORM  Attribute 
    /// 
    /// 
    /// 听不到声音 刷个2 
    /// IL:中间语言，标准的面向对象语言，但是不太好阅读
    /// metadata:元数据, 数据清单，只是描述了类中有什么
    /// 反射：Reflection, System.Reflection命名空间，是微软提供的一个帮助类库
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("欢迎来到.net高级班vip课程--反射，我是Richard 老师");
                #region Common
                {
                    //1、添加引用
                    //2、创建对象
                    //3、调用方法
                    //IDBHelper dBHelper = new SqlServerHelper();
                    //IDBHelper dBHelper = new MySqlHelper();// 如果发生变更，就需要修改代码
                    //dBHelper.Query();

                    //ReflectionTest reflectionTest = new ReflectionTest("往后余生");
                }
                #endregion

                #region Reflection
                {
                    //// 1、动态加载
                    //Assembly assembly = Assembly.Load("Ruanmou.DB.SqlServer");// dll名称  默认到当前目录下查找
                    //Assembly assembly1 = Assembly.LoadFile(@"D:\软谋教育\Ruanmou\Advanced13Encrypt\20191010Advanced13Course3Reflection\20191010Advanced13Course3Reflection\MyReflection\MyReflection\bin\Debug\Ruanmou.DB.SqlServer.dll");// 全名称= 全路径+dll名称 + 后缀

                    //Assembly assembly2 = Assembly.LoadFrom("Ruanmou.DB.SqlServer.dll");// 全名称

                    //Assembly assembly3 = Assembly.LoadFrom(@"D:\软谋教育\Ruanmou\Advanced13Encrypt\20191010Advanced13Course3Reflection\20191010Advanced13Course3Reflection\MyReflection\MyReflection\bin\Debug\Ruanmou.DB.SqlServer.dll");// 全名称

                    //foreach (Type type in assembly.GetTypes())
                    //{
                    //    Console.WriteLine(type.Name);
                    //    foreach (MethodInfo method in type.GetMethods())
                    //    {
                    //        Console.WriteLine(method.Name);
                    //    }
                    //} 
                }

                {
                    //// 1、动态加载
                    //Assembly assembly = Assembly.Load("Ruanmou.DB.SqlServer");// dll名称  默认到当前目录下查找
                    ////2、获取类型
                    //Type type = assembly.GetType("Ruanmou.DB.SqlServer.SqlServerHelper");
                    ////3、创建对象
                    //object oDbHelper = Activator.CreateInstance(type);
                    //// oDbHelper.Query();//  编译器就不认可  c# 是强类型语言，不能Query 
                    ////dynamic dDbHelper = Activator.CreateInstance(type);
                    //// dDbHelper.Query(); //dynamic 是一个动态类型，可以避开编译器的检查，运行时检查  存在安全问题 
                    ////4、类型转换
                    //IDBHelper iDBHelper = oDbHelper as IDBHelper;
                    ////5、调用方法
                    //iDBHelper.Query();
                }

                // 程序的可配置   修改配置文件
                {//这叫封装   Factory +  config  代码可以不用编译发布
                    //IDBHelper iDBHelper = SimlpFactory.CreateInstentce();
                    //iDBHelper.Query(); 
                    // 程序的可扩展
                    // 1、添加一个OrcaleDb类库
                    // 2、把生成的Dll Copy 当前执行程序所在目录下
                    // 3、修改配置文件 
                } 
                {
                    // 反射选择不同的构造函数创建对象
                    Assembly assembly = Assembly.Load("Ruanmou.DB.SqlServer");
                    Type type = assembly.GetType("Ruanmou.DB.SqlServer.ReflectionTest");





                    //Activator.CreateInstance

                    object oDbHelper = Activator.CreateInstance(type);

                    object oDbHelper1 = Activator.CreateInstance(type, new object[] { "杰克" });
                    object oDbHelper2 = Activator.CreateInstance(type, new object[] { "我是谁" });

                    object oDbHelper3 = Activator.CreateInstance(type, new object[] { 123 });
                }

                //现在是22:02 大家开始提问，22:05开始答疑，中间老师不说话





                #endregion


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }
}
