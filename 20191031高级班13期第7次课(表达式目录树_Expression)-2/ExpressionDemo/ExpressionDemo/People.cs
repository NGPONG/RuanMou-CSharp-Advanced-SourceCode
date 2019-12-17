using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionDemo
{
    /// <summary>
    /// 实体类
    /// </summary>
    public class People
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public int Id;
          
    }
    /// <summary>
    /// 实体类Target
    /// PeopleDTO
    /// </summary>
    public class PeopleCopy
    { 
        public int Age { get; set; }
        public string Name { get; set; }
        public int Id;
    }
}
