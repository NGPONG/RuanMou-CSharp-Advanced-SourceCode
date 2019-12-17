using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute.Extend
{
    public enum UserState
    {
        /// <summary>
        /// 正常状态
        /// </summary>
        [RemarkAttribute("正常状态")]
        Normal = 0,

        /// <summary>
        /// 已冻结
        /// </summary>
        [RemarkAttribute("已冻结")] 
        Frozen = 1,

        /// <summary>
        /// 已删除
        /// </summary>
        [RemarkAttribute("已删除")]
        Deleted = 2
    }
}
