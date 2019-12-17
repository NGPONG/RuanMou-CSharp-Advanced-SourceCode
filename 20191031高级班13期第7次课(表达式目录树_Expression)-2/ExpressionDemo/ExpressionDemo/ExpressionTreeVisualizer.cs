using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionDemo
{
    /// <summary>
    /// 展示表达式树，协助用的
    /// 编译lambda--反编译C#--得到原始声明方式
    /// </summary>
    public class ExpressionTreeVisualizer
    {
        public static void Show()
        {
            //Expression<Func<int>> expression = () => 123 + 234; 
            //Expression<Func<int, int, int>> expression = (m, n) => m * n + m + n + 2;

            //Expression<Func<People, bool>> lambda = x => x.Id.ToString().Equals("5");

            //Expression<Func<People, bool>> exp1 = a => a.Account.Contains("Admin") && a.Name.Contains("Richard");
        }
    }
}
