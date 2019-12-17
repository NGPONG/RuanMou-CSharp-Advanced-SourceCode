using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.DesignerPattern.ResponsibilityChainPattern
{
    public class Manager : AbstractAuditor
    {
        public override void Audit(ApplyContext context)
        {
            Console.WriteLine($"This is {this.GetType().Name} {this.Name} Audit");
            if (context.Hour <= 32)
            {
                context.AuditResult = true;
                context.AuditRemark = "允许请假！";
            }
            else
            {
                //AbstractAuditor chief = new Chief()
                //{
                //    Name = "ivy"
                //};
                //chief.Audit(context);
                base.AuditNext(context);
            }
        }
    }
}
