using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCLRCore
{
    /// <summary>
    ///堆栈内存分配：
    /// 堆 Heap: 进程堆，一个程序在运行是，进程对方引用类型变量的一块内存，全局唯一 
    /// 栈 Stack: 线程栈，一个线程存放变量的一个内存，随着线程的生命周期存在的
    /// 
    /// 引用类型：类/接口/委托  存放在堆上
    /// 值类型：结构/枚举        存放在栈
    /// 
    /// 
    /// 
    /// 
    /// </summary>
    public class StackHeap
    {
        public static void Show()
        {
            //内存分配：线程栈   堆
            {
                ValuePoint valuePoint;
                valuePoint.x = 123;
                Console.WriteLine(valuePoint.x);//赋值后才能使用

                ValuePoint point = new ValuePoint();//默认一定有无参数构造函数
            }
            {
                ReferencePoint referencePoint = new ReferencePoint(123);

                Console.WriteLine(referencePoint.x);
            }
            //装箱拆箱
            {
                int i = 3;
                object oValue = i;
                int k = (int)oValue;
            }
            {
                ReferenceTypeClass referenceTypeClassInstance = new ReferenceTypeClass();
                referenceTypeClassInstance.Method(); 
                //1  调用New  就会去先开辟内存
                //2  把实例传递给构造函数
                //3  执行构造函数
                //4  引用返回
            }
            {
                ValueTypeStruct valueTypeStructInstance = new ValueTypeStruct();
                valueTypeStructInstance.Method();
            }

            //引用类型在哪里   值类型在哪里？
            {
                ReferencePoint referencePoint = new ReferencePoint(3);//引用类型
                Console.WriteLine(referencePoint.x);//这个x的值3，是存在堆上面，还是在栈上面？

                ReferencePoint referencePoint2 = referencePoint;
                Console.WriteLine(referencePoint2.x);//3

                referencePoint2.x = 123;
                Console.WriteLine(referencePoint.x);
                Console.WriteLine(referencePoint2.x);
            }
            {
                ValuePoint valuePoint = new ValuePoint();
                valuePoint.x = 3;
                Console.WriteLine(valuePoint.x);//3

                ValuePoint valuePoint2 = valuePoint;
                Console.WriteLine(valuePoint2.x);//3

                valuePoint2.x = 234;

                Console.WriteLine(valuePoint.x);
                Console.WriteLine(valuePoint2.x);
            }
            //值类型的值，会随着对象的位置存储
            //引用类型的值，是一定会存储在堆里面 
            //值类型的长度是确定，引用类型的长度不确定的，只有堆才能存放各种值
             
             
            //string字符串内存分配
            {
                //string student = "大山";
                //string student2 = student;

                //Console.WriteLine(student);
                //Console.WriteLine(student2);

                //student2 = "APP";//=new string(APP);
                //Console.WriteLine(student);
                //Console.WriteLine(student2);
            }

            {
                string student = "大山";
                string student2 = "APP";//共享
                student2 = "大山"; 
                Console.WriteLine(object.ReferenceEquals(student, student2)); //判断二者是不是同 
                // true  同一个变量  享元模式
               
                student2 = "大山1"; // new String("大山1")  会开辟一块新的内存 
                Console.WriteLine(student); 
                //还是输出大山 字符串的不可变性  
                  
                string student3 = string.Format("大{0}", "山");
                Console.WriteLine(object.ReferenceEquals(student, student3));
                //false  因为二者没有享元  先分配内存   然后计算  最终的结果才是 “大山”


                string student4 = "大" + "山";
                Console.WriteLine(object.ReferenceEquals(student, student4));
                //true  先计算了，  直接就得到大山  可以指向之前存在的内存块
                 
                string halfStudent = "山";
                string student5 = "大" + halfStudent;
                Console.WriteLine(object.ReferenceEquals(student, student5));
                //false    是先分配内存，然后再计算
            }
            //{
            //    StackTrace trace = new StackTrace();
            //    //获取是哪个类来调用的  
            //    Type type = trace.GetFrame(1).GetMethod().DeclaringType;
            //    //获取是类中的那个方法调用的  
            //    string method = trace.GetFrame(1).GetMethod().ToString();
            //}
        }
    }


    public struct ValuePoint// : System.ValueType  结构不能有父类，因为隐式继承了ValueType
    {
        public int x;
        public ValuePoint(int x)
        {
            this.x = x;
            this.Text = "1234";
        }

        public string Text;//堆还是栈？ 堆里面的
    }

    public class ReferencePoint
    {
        public int x;
        public ReferencePoint(int x)
        {
            this.x = x;
        }
    }

    public class ReferenceTypeClass
    {
        private int _valueTypeField;//1 堆1栈2
        public ReferenceTypeClass()
        {
            //this._valueTypeField = 3;
            _valueTypeField = 0;
        }
        public void Method()
        {
            int valueTypeLocalVariable = 0;//2 堆1栈2
        }
    }

    public struct ValueTypeStruct//值类型
    {
        private object _referenceTypeField;//1 堆1 栈2
        public ValueTypeStruct(int x)
        {
            _referenceTypeField = new object();
            //this.Text = "Richard";
        }

        //private string Text;
        public void Method()
        {
            object referenceTypeLocalVariable = new object();//1 堆1栈2
        }
    }


}
