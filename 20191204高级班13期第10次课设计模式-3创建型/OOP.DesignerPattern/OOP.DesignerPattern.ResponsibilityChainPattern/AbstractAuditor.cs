using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.DesignerPattern.ResponsibilityChainPattern
{
    public abstract class AbstractAuditor
    {
        public string Name { get; set; }
        public abstract void Audit(ApplyContext context);

        private AbstractAuditor _NextAuditor = null;
        public void SetNext(AbstractAuditor auditor)
        {
            this._NextAuditor = auditor;
        }
        protected void AuditNext(ApplyContext context)
        {
            this._NextAuditor?.Audit(context);
        }
    }
}

