using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCLRCore
{
    /// <summary> 
    ///  1  托管堆垃圾回收 -- GC
    ///     只有引用类型才需要垃圾回收？ 托管资源 
    ///     
    ///     托管资源：托管再CLR上，创建的对象，string   
    ///     非托管资源：数据连接，文件流，句柄
    ///     using 其实是c# 封装了非托管资源的连接
    ///     
    ///     非托管资源是需要手手动释放；
    ///     
    ///  2 哪些对象的内存，会被GC回收？
    ///     对象访问不到了，就可以被GC回收
    ///     程序入口--找对象--建立一个标记--对象图---如果访问不到的就是垃圾
    ///     
    ///  3 对象是如何分配再堆上的呢?
    ///     因为引用类型是分配再堆上面，每次分配的时候会先检查一个空间是否足够
    ///     
    ///  4 什么时候需要执行GC 
    ///     a 创建对象的时候--会有一个临界点
    ///     b 可以手动触发 GC.Conllect 直接就去GC回收下,老师不建议大家频繁的去GC 回收
    ///     c  程序在退出的时候会执行GC 
    ///         string a="明日梦"
    ///         a=null;
    ///         GC.Conllect
    ///         
    ///   5  GC 在回收的是的时候，是怎么样的呢？
    ///         多个对象--全部对象标记为垃圾--开始一个一个检查，如果可以访问到，就标记一下
    ///         会再次遍历去清除内存--产生不连续内存---地址移动--压缩--还需要修改变量指向
    ///         
    ///   6  垃圾回收的策略是什么样的？
    ///         对象分代：3代
    ///         0代： 第一次分配到堆   就是0代
    ///         1代： 被回收一次之后就由0代变成1代，依然存在
    ///         2代： 被回收两次之后就由1代变成2代，依然存在
    ///         
    ///         优先回收0代，提高效率，最容易也是多需要回收的
    ///         如果0代回收之后，内存仍然不够----就去找1代  -----2代
    ///         
    ///   大对象：就是比较大的大象
    ///   所存储的大小大于等于80000个字节的时候，同时大对象会被列举为2代
    /// 
    /// </summary>
    public class GCDemo
    {
        private static Student _Student = new Student()
        {
            Id = 123,
            Name = "Richard"
        };
        //private static Student _Student1 = new Student()
        //{
        //    Id = 123,
        //    Name = "Richard"
        //};


        public static void Show()
        {
            { 
                Student student = _Student;
                Class @class = new Class()
                {
                    ClassId = 1,
                    ClassName = "高级班"
                };
                student.Class = @class;
                int i = 3;
            }
            {
                GC.Collect();
            }
            {
                Student student = new Student()
                {
                    Id = 234,
                    Name = "Richard",
                    Class = new Class()
                    {
                        ClassId = 1,
                        ClassName = "高级班"
                    }
                };
                student = null;
                GC.Collect();
            }
            {
                using (Student student = new Student()
                {
                    Id = 234,
                    Name = "Richard",
                    Class = new Class()
                    {
                        ClassId = 1,
                        ClassName = "高级班"
                    }
                })
                {
                    Console.WriteLine("这里啥也不干");
                }
            }
            {
                for (int i = 0; i < 1000; i++)
                {
                    Class @class = new Class()
                    {
                        ClassId = i,
                        ClassName = "高级班"
                    };
                }
                GC.Collect();
            }
        }
    }

    public class People : IDisposable
    {
        public string Remark { get; set; }
        public virtual void Dispose()
        {
            MyLog.Log($"执行{this.GetType().Name}Dispose");
        }
    }

    public class Student : People, IDisposable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Class Class { get; set; }

        public override void Dispose()
        {
            base.Dispose();
            if (this.Class != null)
            {
                this.Class.Dispose();
            }
            //通知垃圾回收机制不再调用终结器（析构器）
            GC.SuppressFinalize(this);
            MyLog.Log($"执行{this.GetType().Name}Dispose");
        }

        public void Study()
        {
            Console.WriteLine("跟着Richard老师学习.Net高级开发");
        }

        ~Student()
        {
            MyLog.Log($"执行{this.GetType().Name}Dispose");
        }
    }

    public class Class : IDisposable
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        ~Class()
        {
            MyLog.Log($"执行{this.GetType().Name}Dispose");
        }
        public void Dispose()
        {
            MyLog.Log($"执行{this.GetType().Name}Dispose");
        }
    }


}
