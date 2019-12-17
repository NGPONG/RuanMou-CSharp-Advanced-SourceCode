using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionDemo.Visitor
{
    public class OperationsVisitor : ExpressionVisitor
    {
        public Expression Modify(Expression expression)
        {
            return this.Visit(expression);
        }

        protected override Expression VisitBinary(BinaryExpression b)
        {
            if (b.NodeType == ExpressionType.Add)
            {
                Expression left = this.Visit(b.Left);
                Expression right = this.Visit(b.Right);
                return Expression.Subtract(left, right);
            }

            return base.VisitBinary(b);
        }

        protected override Expression VisitConstant(ConstantExpression node)
        {
            return base.VisitConstant(node);
        }
    }
}
