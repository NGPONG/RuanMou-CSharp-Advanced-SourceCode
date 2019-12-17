using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.DesignerPattern.ResponsibilityChainPattern
{
    public class Chief : AbstractAuditor
    {
        public override void Audit(ApplyContext context)
        {
            Console.WriteLine($"This is {this.GetType().Name} {this.Name} Audit");
            if (context.Hour <= 64)
            {
                context.AuditResult = true;
                context.AuditRemark = "允许请假！";
            }
            else
            {
                //未完待续
                base.AuditNext(context);
            }
        }
    }
}
