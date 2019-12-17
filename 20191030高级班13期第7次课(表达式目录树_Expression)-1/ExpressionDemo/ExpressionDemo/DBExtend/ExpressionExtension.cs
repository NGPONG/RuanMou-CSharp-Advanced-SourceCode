using ExpressionDemo.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionDemo.DBExtend
{
    public static class ExpressionExtension
    {
        public static void BatchDelete<T>(this IQueryable<T> entities, Expression<Func<T, bool>> expr)
        {
            ConditionBuilderVisitor visitor = new ConditionBuilderVisitor();
            visitor.Visit(expr);
            string condition = visitor.Condition();

            string sql = string.Format("DELETE FROM [{0}] WHERE {1};"
                , typeof(T).Name//有可能还得根据泛型去获取
                , condition);
            //然后执行sql
        }

    }
}
