using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute.ValidateExtend
{
    public class AttributeExtend
    {




        //
        public static bool Validate(StudentVip student)
        {
            Type type = student.GetType();

            //type.GetCustomAttributes

            foreach (var prop in type.GetProperties())
            {
                if (prop.IsDefined(typeof(SalaryAttribute), true)) // 这里先判断  是为了提高性能
                {
                    object ovale = prop.GetValue(student);
                    foreach (SalaryAttribute attribute in prop.GetCustomAttributes(typeof(SalaryAttribute), true)) // 获取特性的实例  上面先判断之后，再获取实例
                    {
                        return attribute.Validate(ovale);
                    }
                }

                //List<Student>
            }
            return false;
        }
    }
}
