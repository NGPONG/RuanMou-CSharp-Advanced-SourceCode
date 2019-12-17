using System;
using System.Collections.Generic;
using System.Text;

namespace OOP.DesignerPattern.DecoratorPattern.Decorator
{
    /// <summary>
    /// 装饰器 is a  学生
    /// 组合+继承
    /// abstract是为了避免外部直接实例化
    /// </summary>
    public  class AbstractDecorator : AbstractStudent
    {
        private AbstractStudent _Student = null;
        public AbstractDecorator(AbstractStudent student) : base()
        {
            this._Student = student;
        }
        public override void Study()
        {
            this._Student.Study();
        }
    }
}
