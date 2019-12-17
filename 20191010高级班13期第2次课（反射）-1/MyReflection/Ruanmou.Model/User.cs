using System;

namespace Ruanmou.Model
{
    /// <summary>
    /// LM_User
    /// UserModel
    /// </summary>

    public class User : BaseModel
    {
        public string Name { set; get; }

        public string Account { set; get; }

        public string Password { set; get; }

        public string Email { set; get; }

        public string Mobile { set; get; }

        public int CompanyId { set; get; }

        public string CompanyName { set; get; }

        /// <summary>
        /// 用户状态  0正常 1冻结 2删除
        /// </summary>
        public int State { set; get; }

        /// <summary>
        /// 用户类型  1 普通用户 2管理员 4超级管理员
        /// </summary>
        public int UserType { set; get; }

        public DateTime LastLoginTime { set; get; }

        public DateTime CreateTime { set; get; }

        public int CreatorId { set; get; }

        public int LastModifierId { set; get; }

        public DateTime LastModifyTime { set; get; }

    }
}
