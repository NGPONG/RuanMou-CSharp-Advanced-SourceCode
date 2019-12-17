using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using ExpressionDemo.DBExtend;

namespace ExpressionDemo.Visitor
{
    public class ConditionBuilderVisitor : ExpressionVisitor
    {
        private Stack<string> _StringStack = new Stack<string>();

        public string Condition()
        {
            string condition = string.Concat(this._StringStack.ToArray());
            this._StringStack.Clear();
            return condition;
        }
        //((((( [Age]  > 5) AND ( [Id]  > 5)) AND ( [Name]  LIKE '1%')) AND ( [Name]  LIKE '%1')) AND ( [Name]  LIKE '%1%'))

        /// <summary>
        /// 如果是二元表达式
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        protected override Expression VisitBinary(BinaryExpression node)
        {
            if (node == null) throw new ArgumentNullException("BinaryExpression");

            this._StringStack.Push(")");
            base.Visit(node.Right);//解析右边
            this._StringStack.Push(" " + node.NodeType.ToSqlOperator() + " ");
            base.Visit(node.Left);//解析左边
            this._StringStack.Push("(");

            return node;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        protected override Expression VisitMember(MemberExpression node)
        {
            if (node == null) throw new ArgumentNullException("MemberExpression");
            this._StringStack.Push(" [" + node.Member.Name + "] ");
            return node;
        }
        /// <summary>
        /// 常量表达式
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        protected override Expression VisitConstant(ConstantExpression node)
        {
            if (node == null) throw new ArgumentNullException("ConstantExpression");
            this._StringStack.Push( node.Value.ToString());
            return node;
        }
        /// <summary>
        /// 方法表达式
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        protected override Expression VisitMethodCall(MethodCallExpression m)
        {
            if (m == null) throw new ArgumentNullException("MethodCallExpression");

            string format;
            switch (m.Method.Name)
            {
                case "StartsWith":
                    format = "({0} LIKE '{1}%')";
                    break;

                case "Contains":
                    format = "({0} LIKE '%{1}%')";
                    break;

                case "EndsWith":
                    format = "({0} LIKE '%{1}')";
                    break;

                default:
                    throw new NotSupportedException(m.NodeType + " is not supported!");
            }
            this.Visit(m.Object);
            this.Visit(m.Arguments[0]);
            string right = this._StringStack.Pop();
            string left = this._StringStack.Pop();
            this._StringStack.Push(String.Format(format, left, right));

            return m;
        }
    }
}
