using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.DesignerPattern.DecoratorPattern
{
    /// <summary>
    /// 一个普通的vip学员,学习vip课程
    /// </summary>
    public class StudentVip : AbstractStudent
    {
        /// <summary>
        /// 付费  上课前要预习   
        /// 上课学习
        /// </summary>
        public override void Study()
        {
            Console.WriteLine("{0} is a vip student studying .net Vip", base.Name);
        }
    }
    //还需要看视频
    //作业巩固练习 老师在线答疑  免费升级---预习
    //个数能随意定制？  顺序能随意定制？
    public class StudentVipVideo : StudentVip
    {
        public override void Study()
        {
            base.Study();
            Console.WriteLine("获取视频课件代码回看");
        }
    }

    public class StudentCombination
    {
        private AbstractStudent _Student = null;
        /// <summary>
        /// 必须传入
        /// 面向抽象
        /// </summary>
        /// <param name="student"></param>
        public StudentCombination(AbstractStudent student)
        {
            this._Student.Study();
        }
        public void Study()
        {
            this._Student.Study();
            Console.WriteLine("获取视频课件代码回看");
        }
    }
}
