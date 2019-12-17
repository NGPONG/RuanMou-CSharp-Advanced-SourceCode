using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute.ValidateExtend
{
    [AttributeUsage(AttributeTargets.Property)]
    public class LongAttribute : AbstractValidateAttribute
    {
        public long _Max { get; set; }

        public long _Min { get; set; }

        public override bool Validate(object oValue)
        {
            return oValue != null && long.TryParse(oValue.ToString(), out long lValue) && lValue >= _Min && lValue <= _Max;

            //if (oValue != null && long.TryParse(oValue.ToString(), out long lValue) && lValue >= _Min && lValue <= _Max)
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
