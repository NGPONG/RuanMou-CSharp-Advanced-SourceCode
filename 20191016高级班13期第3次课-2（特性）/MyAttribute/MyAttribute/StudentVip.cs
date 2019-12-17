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
            //.cutom  无法调用
            Console.WriteLine("Homework");
        }

        [SalaryAttribute(800000)] // 公司的预算
        public long Salary { get; set; }


        //【特性：验证不能为空】 
        [Long(_Min = 10000, _Max = 999999999999)]
        public long QQ { get; set; }

    }
}
