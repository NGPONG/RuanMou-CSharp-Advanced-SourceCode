using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.DesignerPattern.ResponsibilityChainPattern
{
    /// <summary>
    /// PM-
    /// 权限范围内审核
    /// 权限范围外转交主管
    /// 
    /// PM下一环节就一定是Charge? 依赖   耦合
    /// 甩锅大法：哪里不稳定 就甩哪里
    /// </summary>
    public class PM : AbstractAuditor
    {
        //private AbstractAuditor _NextAuditor = null;
        //public void SetNext(AbstractAuditor auditor)
        //{
        //    this._NextAuditor = auditor;
        //}
        public override void Audit(ApplyContext context)
        {
            Console.WriteLine($"This is {this.GetType().Name} {this.Name} Audit");
            if (context.Hour <= 8)
            {
                context.AuditResult = true;
                context.AuditRemark = "允许请假！";
            }
            else
            {
                //this._NextAuditor?.Audit(context);
                base.AuditNext(context);
                //AbstractAuditor charge = new Charge()
                //{
                //    Name = "腾坤"
                //};//锅
                //charge.Audit(context);
            }
        }
    }
}
