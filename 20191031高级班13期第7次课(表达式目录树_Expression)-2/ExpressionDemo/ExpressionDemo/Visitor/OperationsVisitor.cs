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
            Console.WriteLine(b.ToString());
            if (b.NodeType == ExpressionType.Add)
            {
                Expression left = this.Visit(b.Left); // 会产生一个新的表达式目录树
                Expression right = this.Visit(b.Right);

                Console.WriteLine(left.ToString());

                Console.WriteLine(right.ToString());

                return Expression.Subtract(left, right);
            }
            else if (b.NodeType==ExpressionType.Multiply)
            {
                Expression left = this.Visit(b.Left); // 会产生一个新的表达式目录树
                Expression right = this.Visit(b.Right);
                return Expression.Divide(left, right);
            }

              
            var express = base.VisitBinary(b);

            return express;
        }

        protected override Expression VisitConstant(ConstantExpression node)
        {
            Console.WriteLine(node.ToString());
            return base.VisitConstant(node);
        }
    }
}
