using System;
using System.Collections.Generic;
using System.Text;

namespace OOP.DesignerPattern.DecoratorPattern.Decorator
{
    /// <summary>
    /// 装饰器 is a  学生
    /// 组合+继承
    /// </summary>
    public class StudentDecoratorAnswer : AbstractDecorator
    {
        public StudentDecoratorAnswer(AbstractStudent student) : base(student)
        {
        }
        public override void Study()
        {
            base.Study();
            Console.WriteLine("获取在线答疑。。。");
        }
    }
}
