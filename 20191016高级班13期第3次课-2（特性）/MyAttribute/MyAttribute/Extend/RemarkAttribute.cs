using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute.Extend
{
    [AttributeUsage(AttributeTargets.Field)]
    public class RemarkAttribute : Attribute
    {
        public string Remark { get; private set; }


        public RemarkAttribute(string remark)
        {
            this.Remark = remark;
        }

    }
}
