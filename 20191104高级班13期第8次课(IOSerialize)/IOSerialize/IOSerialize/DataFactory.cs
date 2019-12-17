using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOSerialize
{

    [Serializable]  //必须添加序列化特性
    public class Person
    {
        [NonSerialized]
        public int Id = 1;

        public string Name { get; set; }

        public string Sex { get; set; }
    }

    [Serializable]  //必须添加序列化特性
    public class Programmer : Person
    {
        private string Language { get; set; }//编程语言
        public string Description { get; set; }
    }

    public class DataFactory
    {
        /// <summary>
        /// 初始化数据的
        /// </summary>
        /// <returns></returns>
        public static List<Programmer> BuildProgrammerList()
        {
            #region data prepare
            List<Programmer> list = new List<Programmer>();
            list.Add(new Programmer()
            {
                Id = 1,
                Description="高级班学员",
                Name = "SoWhat",
                Sex = "男"
            });
            list.Add(new Programmer()
            {
                Id = 1,
                Description = "高级班学员",
                Name = "day",
                Sex = "男"
            });
            list.Add(new Programmer()
            {
                Id = 1,
                Description = "高级班学员",
                Name = "领悟",
                Sex = "男"
            });
            list.Add(new Programmer()
            {
                Id = 1,
                Description = "高级班学员",
                Name = "Sam",
                Sex = "男"
            });
            list.Add(new Programmer()
            {
                Id = 1,
                Description = "高级班学员",
                Name = "AlphaGo",
                Sex = "男"
            });
            list.Add(new Programmer()
            {
                Id = 1,
                Description = "高级班学员",
                Name = "折腾",
                Sex = "男"
            });
            list.Add(new Programmer()
            {
                Id = 1,
                Description = "高级班学员",
                Name = "Me860",
                Sex = "男"
            });
            list.Add(new Programmer()
            {
                Id = 1,
                Description = "高级班学员",
                Name = "打兔子的猎人",
                Sex = "男"
            });
            list.Add(new Programmer()
            {
                Id = 1,
                Description = "高级班学员",
                Name = "Nine",
                Sex = "女"
            });
            list.Add(new Programmer()
            {
                Id = 1,
                Description = "高级班学员",
                Name = "望",
                Sex = "女"
            });
            list.Add(new Programmer()
            {
                Id = 1,
                Description = "高级班学员",
                Name = "微笑刺客",
                Sex = "男"
            });
            list.Add(new Programmer()
            {
                Id = 1,
                Description = "高级班学员",
                Name = "waltz",
                Sex = "男"
            });
            list.Add(new Programmer()
            {
                Id = 1,
                Description = "高级班学员",
                Name = "爱在昨天",
                Sex = "男"
            });
            list.Add(new Programmer()
            {
                Id = 1,
                Description = "高级班学员",
                Name = "waltz",
                Sex = "男"
            });
            #endregion

            return list;
        }
    }
}
