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
using Ruanmou.Model;

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
                // 今天会有作业！  大家期待不？
                // 有部分同学  是黑屏的   现在 老师下课  重新进入课堂试试 
                // 如果还有 黑屏的情况  退出重新进入一下 试试
                // 课程 即将开始 大家在群里面  叫一下其他的同学

                //能听到 老师讲话，能看到老师屏幕的  刷个1


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
                    //Assembly assembly = Assembly.Load("Ruanmou.DB.SqlServer");
                    //Type type = assembly.GetType("Ruanmou.DB.SqlServer.ReflectionTest");

                    ////Activator.CreateInstance 
                    //object oDbHelper = Activator.CreateInstance(type);
                    //object oDbHelper1 = Activator.CreateInstance(type, new object[] { "杰克" });
                    //object oDbHelper2 = Activator.CreateInstance(type, new object[] { "我是谁" });
                    //object oDbHelper3 = Activator.CreateInstance(type, new object[] { 123 });
                }
                {
                    //调用方法为什么一定要类型转换？ 
                    //需要先获取方法，然后方法Invoke
                    //Assembly assembly = Assembly.Load("Ruanmou.DB.SqlServer");
                    //Type type = assembly.GetType("Ruanmou.DB.SqlServer.ReflectionTest");
                    //object oTest = Activator.CreateInstance(type);

                    //MethodInfo show1 = type.GetMethod("Show1");
                    //show1.Invoke(oTest, new object[0]);// 反射调用方法 

                    //MethodInfo show2 = type.GetMethod("Show2");
                    //show2.Invoke(oTest, new object[] { 123 });// 反射调用方法 ,需要参数的时候，参数类型必须和方法参数类型保持一致

                    // 重载方法:
                    //MethodInfo show3 = type.GetMethod("Show3", new Type[] { typeof(string), typeof(int) });
                    //show3.Invoke(oTest, new object[] { "飞哥", 134 });// 反射调用方法 

                    //ReflectionTest test = new ReflectionTest();
                    //test.Show4();

                    //MethodInfo show4 = type.GetMethod("Show4",   BindingFlags.NonPublic | BindingFlags.CreateInstance);
                    //show4.Invoke(oTest, new object[] { "Tenk" });// 反射调用方法 

                    //MethodInfo show5 = type.GetMethod("Show5");
                    //show5.Invoke(oTest, new object[] { "彭于晏" });// 反射调用静态方法： 对象的实例  可以传入，也可以传入null
                    //show5.Invoke(null, new object[] { "Korey" });  


                    // 反射调用带参数带out和ref的方法
                }

                {
                    //泛型编译之后生成展位符  `1   `2    `3
                    //GenericMethod genericMethod = new GenericMethod();
                    //genericMethod.Show<int, string, DateTime>(1234,"",DateTime.Now);

                    //Assembly assembly = Assembly.Load("Ruanmou.DB.SqlServer");
                    //Type type = assembly.GetType("Ruanmou.DB.SqlServer.GenericMethod");
                    //object oTest = Activator.CreateInstance(type);
                    //MethodInfo genericMethod = type.GetMethod("Show");
                    //MethodInfo genericMethod1 = genericMethod.MakeGenericMethod(new Type[] { typeof(int), typeof(string), typeof(DateTime) });// 指定泛型方法的  具体参数 
                    //genericMethod1.Invoke(oTest, new object[] { 123, "jun", DateTime.Now }); // 传入参数必须和声明的一样

                    //在泛型类中  调用泛型方法

                    //Assembly assembly = Assembly.Load("Ruanmou.DB.SqlServer");
                    //Type type = assembly.GetType("Ruanmou.DB.SqlServer.GenericClass`3"); //获取一个泛型类型 
                    //                                                                     // GenericClass<int,string,DateTime> genericClass = new GenericClass<int, string, DateTime>()
                    //Type type1 = type.MakeGenericType(new Type[] { typeof(int), typeof(string), typeof(DateTime) });
                    //object oGenericTest = Activator.CreateInstance(type1);
                    //MethodInfo genericMethod = type1.GetMethod("Show");
                    //genericMethod.Invoke(oGenericTest, new object[] { 123, "子玉", DateTime.Now });
                    //现在是21:03  大家开始提问，21:05开始答疑
                }

                {
                    //反射的黑科技
                    //反射破坏单利  其实就是反射调用私有构造函数
                    // Singleton singleton = new Singleton(); 
                    //Singleton singleton1 = Singleton.GetInstance();
                    //Singleton singleton2 = Singleton.GetInstance();
                    //Singleton singleton3 = Singleton.GetInstance();
                    //Singleton singleton4 = Singleton.GetInstance();
                    //Console.WriteLine(singleton1.Equals(singleton4));

                    //Assembly assembly = Assembly.Load("Ruanmou.DB.SqlServer");
                    //Type type = assembly.GetType("Ruanmou.DB.SqlServer.Singleton");
                    //object oSingleton1 = Activator.CreateInstance(type, true); //完全等价于 New Singleton
                    //object oSingleton2 = Activator.CreateInstance(type, true);
                    //object oSingleton3 = Activator.CreateInstance(type, true);
                    //object oSingleton4 = Activator.CreateInstance(type, true);
                    //Console.WriteLine(oSingleton1.Equals(oSingleton4));
                }

                {
                    //反射特点：
                    //动态 减少对象和对象之间的依赖，只需要知道类名(字符串)、方法名(字符串)，就可以调用，
                    //还可以突破特定权限，可以做到普通方式无法做到的
                    //编写比较困难，代码量大，编写的时候容易出错 
                    //性能问题，性能损耗大,经过测试：发现反射确实性能损耗比较大 普通方式：140, 反射：34860，确实让我们无法接受，经过缓存优化之后发现，普通方式：65   反射：628，对于性能损耗，大家要理性看待，因为执行的数量巨大，中间的这些性能损耗是可以忽略不计。


                    // 反射应用：创建对象----IOC
                    // 通过一些字符串可以访问方法----MVC : localhost://Home/Index?id=1  Home:控制器(类)，Index :方法
                    // ORM
                    //Monitor.Show();

                    // 反射如何使用属性字段
                    {
                        People people = new People();
                        people.Id = 123;
                        people.Name = "风之林";
                        people.Description = ".Net 高级班学员";
                        Console.WriteLine($"people.Id={people.Id}");
                        Console.WriteLine($"people.Name={people.Name}");
                        Console.WriteLine($"people.Description={people.Description}");
                        //反射怎么玩呢？

                        // 1、GetValue其实是有意义的
                        // 2、SetValue 好像没啥用
                        Type type = typeof(People);
                        object oPeople = Activator.CreateInstance(type);
                        foreach (PropertyInfo prop in type.GetProperties())
                        {
                            if (prop.Name.Equals("Id"))
                            {
                                prop.SetValue(oPeople, 123);
                            }
                            else if (prop.Name.Equals("Name"))
                            {
                                prop.SetValue(oPeople, "风之林");
                            }
                            Console.WriteLine($"oPeople.{prop.Name}={prop.GetValue(oPeople)}");
                        }

                        foreach (FieldInfo field in type.GetFields())
                        {
                            if (field.Name.Equals("Description"))
                            {
                                field.SetValue(oPeople, ".Net 高级班学员");
                            }
                        }
                    }
                    {

                        Company company = SqlServerHelper.Find<Company>(1);
                        User user = SqlServerHelper.Find<User>(1); 

                        // 现在大家提问题
                    }
                }



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
