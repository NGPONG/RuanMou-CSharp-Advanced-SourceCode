using MyAttribute.ValidateExtend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute
{
    [Cutom(123, Remark = ".Net高级班", Description = "第三节课正在学习")]
    public class StudentVip : Student
    {
        [Cutom(123, Remark = ".Vip", Description = ".Net高级班的成员")]
        public string VipGroup { get; set; }

        [Cutom(123, Remark = ".Vip", Description = ".Net高级班的成员")]
        public void Homework()
        {
            //.cutom

            Console.WriteLine("Homework");
        }

        [SalaryAttribute(1000000)]
        public long Salary { get; set; }
    }
}
