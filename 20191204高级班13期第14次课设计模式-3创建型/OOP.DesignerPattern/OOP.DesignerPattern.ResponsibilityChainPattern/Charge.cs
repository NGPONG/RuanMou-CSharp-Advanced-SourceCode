using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.DesignerPattern.ResponsibilityChainPattern
{
    public class Charge : AbstractAuditor
    {
        public override void Audit(ApplyContext context)
        {
            Console.WriteLine($"This is {this.GetType().Name} {this.Name} Audit");
            if (context.Hour <= 16)
            {
                context.AuditResult = true;
                context.AuditRemark = "允许请假！";
            }
            else
            {
                //AbstractAuditor manager = new Manager()
                //{
                //    Name = "小巨蛋"
                //};
                //manager.Audit(context);
                base.AuditNext(context);
            }
        }
    }
}
