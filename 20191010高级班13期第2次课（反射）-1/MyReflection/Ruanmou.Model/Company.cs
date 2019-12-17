using System;

namespace Ruanmou.Model
{
    public class Company : BaseModel
    {
        public string Name { get; set; }
        public System.DateTime CreateTime { get; set; }
        public int CreatorId { get; set; }
        public int? LastModifierId { get; set; }
        public DateTime? LastModifyTime { get; set; }
    }
}