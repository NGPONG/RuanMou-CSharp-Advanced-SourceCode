using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute
{
    /// <summary> 
    /// 请不要使用这个了，请使用什么来代替  
    /// </summary>
   // [Obsolete("请不要使用这个了，请使用什么来代替")]//系统
    //[Serializable]//可以序列化和反序列化  
    [Cutom(234, "飞哥")]
    [Cutom(123)]
    [Cutom(567, Remark = ".Net高级班", Description = ".Net高级班正在学习")]
    [CutomAttributeChild]
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
         
        public void Study()
        {
            Console.WriteLine($"这里是{this.Name}跟着Eleven老师学习");
        }
         
        //[return:Cutom]
        public string Answer(string name)
        {
            return $"This is {name}";
        }
    }
}
