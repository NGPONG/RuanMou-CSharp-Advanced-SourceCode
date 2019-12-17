using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute.ValidateExtend
{
    public static class AttributeExtend
    {
        //这里是值对StudentVip 中的属性写了校验，如果其他别的类型需要校验不是又要写一个方法吗？
        //需要满足不同类型的需求  泛型方法
        public static bool Validate<T>(this T t) where T : class
        {
            Type type = t.GetType();
            foreach (var prop in type.GetProperties())
            {
                if (prop.IsDefined(typeof(AbstractValidateAttribute), true)) // 这里先判断  是为了提高性能
                {
                    object ovale = prop.GetValue(t);
                    foreach (AbstractValidateAttribute attribute in prop.GetCustomAttributes(typeof(AbstractValidateAttribute), true)) // 获取特性的实例  上面先判断之后，再获取实例
                    {
                        if(!attribute.Validate(ovale))
                        {
                            return false;
                        }
                    }
                }

                //if (prop.IsDefined(typeof(LongAttribute), true))
                //{
                //    object ovale = prop.GetValue(t);
                //    foreach (LongAttribute attribute in prop.GetCustomAttributes(typeof(LongAttribute), true)) // 获取特性的实例  上面先判断之后，再获取实例
                //    {
                //        if (!attribute.Validate(ovale))
                //        {
                //            return false;
                //        }
                //    }
                //}

                //if (prop.IsDefined(typeof(LongAttribute), true))
                //{
                //    object ovale = prop.GetValue(t);
                //    foreach (LongAttribute attribute in prop.GetCustomAttributes(typeof(LongAttribute), true)) // 获取特性的实例  上面先判断之后，再获取实例
                //    {
                //        if (!attribute.Validate(ovale))
                //        {
                //            return false;
                //        }
                //    }
                //}
            }
            return true;
        }
    }
}
