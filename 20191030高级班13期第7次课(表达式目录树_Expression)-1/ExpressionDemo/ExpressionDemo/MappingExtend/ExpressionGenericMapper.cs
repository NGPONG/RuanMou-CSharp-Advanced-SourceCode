using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionDemo.MappingExtend
{
    /// <summary>
    /// 生成表达式目录树  泛型缓存
    /// </summary>
    /// <typeparam name="TIn"></typeparam>
    /// <typeparam name="TOut"></typeparam>
    public class ExpressionGenericMapper<TIn, TOut>//Mapper`2 //正对于每两个不同类型的组合都会生成副本
    {
        private static Func<TIn, TOut> _FUNC = null;// 在每个副本中都有一个委托
        static ExpressionGenericMapper() //静态构造函数 生成表达式目录树 
        {
            ParameterExpression parameterExpression = Expression.Parameter(typeof(TIn), "p");
            List<MemberBinding> memberBindingList = new List<MemberBinding>();
            foreach (var item in typeof(TOut).GetProperties())
            {
                MemberExpression property = Expression.Property(parameterExpression, typeof(TIn).GetProperty(item.Name));
                MemberBinding memberBinding = Expression.Bind(item, property);
                memberBindingList.Add(memberBinding);
            }
            foreach (var item in typeof(TOut).GetFields())
            {
                MemberExpression property = Expression.Field(parameterExpression, typeof(TIn).GetField(item.Name));
                MemberBinding memberBinding = Expression.Bind(item, property);
                memberBindingList.Add(memberBinding);
            }
            MemberInitExpression memberInitExpression = Expression.MemberInit(Expression.New(typeof(TOut)), memberBindingList.ToArray());
            Expression<Func<TIn, TOut>> lambda = Expression.Lambda<Func<TIn, TOut>>(memberInitExpression, new ParameterExpression[]
            {
                    parameterExpression
            });
            _FUNC = lambda.Compile();//拼装是一次性的   转换成委托以后放入副本的静态变量中去
        }
        public static TOut Trans(TIn t) // 直接获取副本的静态变量（委托）
        {
            return _FUNC(t);
        }
    }
}
