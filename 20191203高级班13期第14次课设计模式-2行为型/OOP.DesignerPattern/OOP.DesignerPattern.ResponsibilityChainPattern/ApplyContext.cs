using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.DesignerPattern.ResponsibilityChainPattern
{
    /// <summary>
    /// 请假申请，
    /// Context--上下文环境，保存业务处理中参数-中间结果-最终结果
    /// 行为型设计模式常用的标配
    /// 把行为转移，
    /// HttpContext
    /// </summary>
    public class ApplyContext
    {
        public int Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// 请假时长
        /// </summary>
        public int Hour { get; set; }
        public string Description { get; set; }
        public bool AuditResult { get; set; }
        public string AuditRemark { get; set; }
    }
}
