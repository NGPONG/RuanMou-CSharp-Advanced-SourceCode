using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDelegateEvent.DelegateExtend
{
    public class ListExtend
    {
        #region 数据准备
        /// <summary>
        /// 准备数据
        /// </summary>
        /// <returns></returns>
        private List<Student> GetStudentList()
        {
            #region 初始化数据
            List<Student> studentList = new List<Student>()
            {
                new Student()
                {
                    Id=1,
                    Name="打兔子的猎人",
                    ClassId=2,
                    Age=35
                },
                new Student()
                {
                    Id=1,
                    Name="Alpha Go",
                    ClassId=2,
                    Age=23
                },
                 new Student()
                {
                    Id=1,
                    Name="白开水",
                    ClassId=2,
                    Age=27
                },
                 new Student()
                {
                    Id=1,
                    Name="狼牙道",
                    ClassId=2,
                    Age=26
                },
                new Student()
                {
                    Id=1,
                    Name="Nine",
                    ClassId=2,
                    Age=25
                },
                new Student()
                {
                    Id=1,
                    Name="Y",
                    ClassId=2,
                    Age=24
                },
                new Student()
                {
                    Id=1,
                    Name="小昶",
                    ClassId=2,
                    Age=21
                },
                 new Student()
                {
                    Id=1,
                    Name="yoyo",
                    ClassId=2,
                    Age=22
                },
                 new Student()
                {
                    Id=1,
                    Name="冰亮",
                    ClassId=2,
                    Age=34
                },
                 new Student()
                {
                    Id=1,
                    Name="瀚",
                    ClassId=2,
                    Age=30
                },
                new Student()
                {
                    Id=1,
                    Name="毕帆",
                    ClassId=2,
                    Age=30
                },
                new Student()
                {
                    Id=1,
                    Name="一点半",
                    ClassId=2,
                    Age=30
                },
                new Student()
                {
                    Id=1,
                    Name="小石头",
                    ClassId=2,
                    Age=28
                },
                new Student()
                {
                    Id=1,
                    Name="大海",
                    ClassId=2,
                    Age=30
                },
                 new Student()
                {
                    Id=3,
                    Name="yoyo",
                    ClassId=3,
                    Age=30
                },
                  new Student()
                {
                    Id=4,
                    Name="unknown",
                    ClassId=4,
                    Age=30
                }
            };
            #endregion
            return studentList;
        }
        #endregion

        public static void Show()
        {

        }
    }
}
