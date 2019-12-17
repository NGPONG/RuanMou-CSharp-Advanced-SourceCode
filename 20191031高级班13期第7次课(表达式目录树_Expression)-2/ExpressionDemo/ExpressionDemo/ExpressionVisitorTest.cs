using ExpressionDemo.Extend;
using ExpressionDemo.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionDemo
{
    /// <summary>
    /// 表达式访问者
    /// </summary>
    public class ExpressionVisitorTest
    {

        //表达式目录树的拼装和拆解作为本周的家庭作业

        public static void Show()
        {
            //ExpressionVisitor访问者类，Visit是一个入口，先判断，进一步的解析，然后
            //1、lambada会区分参数和方法体，调度到更加专业的方法中解析；
            //2、根据表达式的类型，调度到更加专业的方法中解析；
            //3、默认根据旧的模式产生一个新的表达式目录树；

            // 解析表达式目录树的时候，先从Visit进入，调度更加专业的方法进一步解析；

            {
                //修改表达式目录树
                Expression<Func<int, int, int>> exp = (m, n) => m * n + 2;
                OperationsVisitor visitor = new OperationsVisitor();
                //visitor.Visit(exp);
                Expression expNew = visitor.Modify(exp);
            }
            {
                // 写成这样的表达式目录树怎么变成sql呢？
                Expression<Func<People, bool>> lambda = x => x.Age > 5;
                // select * from People where Age>5 
                new List<People>().AsQueryable().Where(x => x.Age > 5 && x.Id == 10);

                ConditionBuilderVisitor vistor = new ConditionBuilderVisitor();
                vistor.Visit(lambda);
                Console.WriteLine(vistor.Condition());
            }

            Console.WriteLine("更加复杂一点");
            {

                //select * from People where Age>5 and Id>5
                Expression<Func<People, bool>> lambda = x => x.Age > 5
                                                         && x.Id > 5
                                                         && x.Name.StartsWith("1")
                                                         && x.Name.EndsWith("1")
                                                         && x.Name.Contains("1");

                string sql = string.Format("Delete From [{0}] WHERE {1}"
                    , typeof(People).Name
                    , " [Age]>5 AND [ID] >5"
                    );
                ConditionBuilderVisitor vistor = new ConditionBuilderVisitor();
                vistor.Visit(lambda);
                Console.WriteLine(vistor.Condition());
            }
            {

                //且或非
                Expression<Func<People, bool>> lambda = x => x.Age > 5 && x.Name == "A" || x.Id > 5;
                ConditionBuilderVisitor vistor = new ConditionBuilderVisitor();
                vistor.Visit(lambda);
                Console.WriteLine(vistor.Condition());
            }
            {
                Expression<Func<People, bool>> lambda = x => x.Age > 5 || (x.Name == "A" && x.Id > 5);
                ConditionBuilderVisitor vistor = new ConditionBuilderVisitor();
                vistor.Visit(lambda);
                Console.WriteLine(vistor.Condition());
            }
            {
                Expression<Func<People, bool>> lambda = x => (x.Age > 5 || x.Name == "A") && x.Id > 5;
                ConditionBuilderVisitor vistor = new ConditionBuilderVisitor();
                vistor.Visit(lambda);
                Console.WriteLine(vistor.Condition());
            }

            #region 表达式链接
            {

                // 把多个表达式拼接起来
                Expression<Func<People, bool>> lambda1 = x => x.Age > 5;
                Expression<Func<People, bool>> lambda2 = x => x.Id > 5;
                Expression<Func<People, bool>> lambda3 = lambda1.And(lambda2);
                Expression<Func<People, bool>> lambda4 = lambda1.Or(lambda2);
                Expression<Func<People, bool>> lambda5 = lambda1.Not();
                Do1(lambda3);
                Do1(lambda4);
                Do1(lambda5);
            }
            #endregion


        }
        #region PrivateMethod
        private static void Do1(Func<People, bool> func)
        {
            List<People> people = new List<People>();
            people.Where(func);
        }
        private static void Do1(Expression<Func<People, bool>> func)
        {
            List<People> people = new List<People>()
            {
                new People(){Id=4,Name="123",Age=4},
                new People(){Id=5,Name="234",Age=5},
                new People(){Id=6,Name="345",Age=6},
            };

            List<People> peopleList = people.Where(func.Compile()).ToList();
        }

        private static IQueryable<People> GetQueryable(Expression<Func<People, bool>> func)
        {
            List<People> people = new List<People>()
            {
                new People(){Id=4,Name="123",Age=4},
                new People(){Id=5,Name="234",Age=5},
                new People(){Id=6,Name="345",Age=6},
            };

            return people.AsQueryable<People>().Where(func);
        }
        #endregion
    }
}
