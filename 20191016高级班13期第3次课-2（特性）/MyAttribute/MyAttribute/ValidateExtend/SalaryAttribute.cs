using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute.ValidateExtend
{

    [AttributeUsage(AttributeTargets.Property)]
    public class SalaryAttribute : AbstractValidateAttribute
    {
        public long _Salary { get; set; }  // 公司的预算 800000

        public SalaryAttribute(long salary)
        {
            _Salary = salary;
        }

        public override bool Validate(object oValue)
        {
            return oValue != null && long.TryParse(oValue.ToString(), out long lValue) && lValue < _Salary;

            //if (oValue != null && long.TryParse(oValue.ToString(), out long lValue) && lValue > _Salary)
            //{
            //    return true;
            //} 
            //else
            //{
            //    return false;
            //} 
        }

    }
}
