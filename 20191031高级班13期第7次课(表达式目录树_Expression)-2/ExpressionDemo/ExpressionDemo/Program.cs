using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionDemo
{
    /// <summary>  
    /// 1 ExpressionVisitor解析表达式目录树
    /// 2 解析Expression生成Sql
    /// 3 Expression扩展拼装链接 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            { 
                //能听到老师讲话（声音很清晰），能看到老师屏幕的 刷个1
                Console.WriteLine("欢迎来到.net高级班vip课程，今晚学习表达式树Expression,我是Richard老师！");
                {
                    Console.WriteLine("****************认识表达式目录树*************");
                    //ExpressionTest.Show();
                }
                {
                    //Console.WriteLine("********************MapperTest********************");
                    //ExpressionTest.MapperTest();
                }
                {
                    //Console.WriteLine("********************解析表达式目录树********************");
                   ExpressionVisitorTest.Show();
                 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }
}
