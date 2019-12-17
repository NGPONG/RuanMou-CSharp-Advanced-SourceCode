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
    }
}
