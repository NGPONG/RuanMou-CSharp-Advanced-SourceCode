using Ruanmou.DB.Interface;
using Ruanmou.DB.SqlServer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyReflection
{
    public class Monitor
    {
        public static void Show()
        {
            Console.WriteLine("*******************Monitor*******************");
            long commonTime = 0;
            long reflectionTime = 0;
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                for (int i = 0; i < 1_000_000; i++)
                {
                    IDBHelper iDBHelper = new SqlServerHelper();
                    iDBHelper.Query();
                }
                watch.Stop();
                commonTime = watch.ElapsedMilliseconds;
            }
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                Assembly assembly = Assembly.Load("Ruanmou.DB.SqlServer");//1 动态加载
                Type dbHelperType = assembly.GetType("Ruanmou.DB.SqlServer.SqlServerHelper");//2 获取类型
                for (int i = 0; i < 1_000_000; i++)
                {
                    //Assembly assembly = Assembly.Load("Ruanmou.DB.SqlServer");//1 动态加载
                    //Type dbHelperType = assembly.GetType("Ruanmou.DB.SqlServer.SqlServerHelper");//2 获取类型
                    object oDBHelper = Activator.CreateInstance(dbHelperType);//3 创建对象
                    IDBHelper dbHelper = (IDBHelper)oDBHelper;//4 接口强制转换
                    dbHelper.Query();//5 方法调用
                }
                watch.Stop();
                reflectionTime = watch.ElapsedMilliseconds;
            }

            Console.WriteLine("commonTime={0} reflectionTime={1}", commonTime, reflectionTime);
        }
    }
}
