using OOP.DesignerPattern.DecoratorPattern.Decorator;
using System;

namespace OOP.DesignerPattern.DecoratorPattern
{
    /// <summary>
    /// 被称之为结构型设计模式的巅峰之作
    /// 组合+继承的融合应用
    /// 
    /// 能够任意扩展要求  还能调整顺序
    /// </summary>
    public class Program
    {
        public static void Show()
        {
            {
                AbstractStudent student = new StudentVip()
                {
                    Id = 123,
                    Name = "小瓶子"
                };
                student = new StudentDecoratorHomework(student);
                student = new StudentDecoratorVideo(student);//包一层
                student = new StudentDecoratorAnswer(student);
               
                student.Study();//可以任意扩展功能   顺序也可以随意调整      --假如我需要预习呢？ 发生在直播之前的


                //AbstractDecorator student1 = new AbstractDecorator(student);//基类
                //AbstractStudent student2= new AbstractDecorator(student);//基类

                //StudentDecoratorVideo student3 = new StudentDecoratorVideo(student2);
                //AbstractDecorator student4 = new StudentDecoratorVideo(student2);
                //AbstractStudent student5 = new StudentDecoratorVideo(student);
                //object student6 = new StudentDecoratorVideo(student2);

                //student = new StudentDecoratorVideo(student);//引用指向新的对象
            }
            //{
            //    object a = new object();
            //    //object b = new object();
            //    a = new object();
            //}



            //{
            //    AbstractStudent student = new StudentFree()
            //    {
            //        Id = 123,
            //        Name = "明日梦"
            //    };
            //    StudentCombination student1 = new StudentCombination(student);
            //    student1.Study();
            //}
            //{
            //    AbstractStudent student = new StudentVip()
            //    {
            //        Id = 234,
            //        Name = "到下个路口"
            //    };
            //    StudentCombination student1 = new StudentCombination(student);
            //    student1.Study();
            //}
            //{
            //    //继承复杂度低一些，少个类
            //    AbstractStudent student = new StudentVipVideo()
            //    {
            //        Id = 345,
            //        Name = "jerry"
            //    };
            //    student.Study();
            //}
        }
    }
}
