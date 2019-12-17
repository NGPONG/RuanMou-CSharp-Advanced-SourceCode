using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ExpressionDemo.Extend;
using System.Diagnostics;
using ExpressionDemo.MappingExtend;
using System.Reflection;

namespace ExpressionDemo
{
    /// <summary>
    /// 认识/拼装 表达式目录树
    /// 拼装表达式
    /// 应用
    /// </summary>
    public class ExpressionTest
    {
        public static void Show()
        {
            {
                //new List<int>().Where(a => a > 10); //Linq To Object 
                new List<People>().AsQueryable().Where(a => a.Id > 10 && a.Name.ToString().Contains("Hyl")); //Linq To Sql
            }
            {
                Func<int, int, int> func = (m, n) => m * n + 2; //匿名方法
                Expression<Func<int, int, int>> exp = (m, n) => m * n + 2;
                //声明一个表达式目录树
                //快捷方式的声明 数据结构；
                //类似于一个树形结构，描述不同变量和常量之间的关系  数据结构；  
                //表达式目录树：语法树，或者说是一种数据结构
                int iResult1 = func.Invoke(12, 23);
                //exp.Compile()=> 委托； 
                int iResult2 = exp.Compile().Invoke(12, 23); //12 * 23 +2  278

                //int iResult = func.Invoke(12, 13); 
                //Expression<Func<int, int, int>> exp1 = (m, n) =>
                //    {
                //        return m * n + 2;
                //    }; 不能有语句体，不能当做一个方法，不能有大括号，只能有一行代码 
            }

            {
                //手动拼装表达式目录树，不是用的lambda的快捷方式
                {
                    //Expression<Func<int>> expression = () => 123 + 234; 
                    ConstantExpression left = Expression.Constant(123, typeof(int));
                    ConstantExpression right = Expression.Constant(234, typeof(int));
                    var plus = Expression.Add(left, right);
                    Expression<Func<int>> expression = Expression.Lambda<Func<int>>(plus, new ParameterExpression[0]);
                    int iResult = expression.Compile().Invoke();
                    int iResult1 = expression.Compile()();
                }
                {
                    // 更复杂一点的：
                    //Expression<Func<int, int, int>> expression = (m, n) => m * n + m + n + 2; 
                    ParameterExpression m = Expression.Parameter(typeof(int), "m");
                    ParameterExpression n = Expression.Parameter(typeof(int), "n");
                    ConstantExpression constant2 = Expression.Constant(2, typeof(int));
                    var multiply = Expression.Multiply(m, n);
                    var plus1 = Expression.Add(multiply, m);
                    var plus2 = Expression.Add(plus1, n);
                    var plus = Expression.Add(plus2, constant2);
                    Expression<Func<int, int, int>> expression = Expression.Lambda<Func<int, int, int>>(plus, new ParameterExpression[]
                    {
                        m,
                        n
                    });
                    int iResult = expression.Compile().Invoke(12, 10);

                }
                {
                    //   Expression<Func<People, bool>> lambda = (x) => x.Id.ToString().Equals("5"); 
                    ParameterExpression x = Expression.Parameter(typeof(People), "x");
                    FieldInfo field = typeof(People).GetField("Id");
                    ConstantExpression constant5 = Expression.Constant("5");
                    var fieldExp = Expression.Field(x, field);
                    MethodInfo toString = typeof(int).GetMethod("ToString", new Type[] { });
                    MethodInfo equals = typeof(string).GetMethod("Equals", new Type[] { typeof(string) });
                    var tostringExp = Expression.Call(fieldExp, toString, new Expression[0]);
                    var equalsExp = Expression.Call(tostringExp, equals, new Expression[]
                      {
                         constant5
                      });
                    Expression<Func<People, bool>> expression = Expression.Lambda<Func<People, bool>>(equalsExp, new ParameterExpression[]
                    {
                           x
                    });
                    bool bResult = expression.Compile().Invoke(new People()
                    {
                        Id = 5,
                        Name = "德玛西亚"
                    });
                }
            }

            //动态
            {
                //{   //以前根据用户输入拼装条件 
                //    string sql = "SELECT * FROM USER WHERE 1=1";
                //    Console.WriteLine("用户输入个名称，为空就跳过");
                //    string name = Console.ReadLine();
                //    if (!string.IsNullOrWhiteSpace(name))
                //    {
                //        sql += $" and name like '%{name}%'";
                //    }

                //    Console.WriteLine("用户输入个账号，为空就跳过");
                //    string account = Console.ReadLine();
                //    if (!string.IsNullOrWhiteSpace(account))
                //    {
                //        sql += $" and account like '%{account}%'";
                //    }
                //}

                {   //Linq To Sql

                    var DbSet = new List<People>().AsQueryable();
                    //Expression<Func<People, bool>> exp = a => a.Name.Contains("Richard") && a.Id == 10; 
                    Expression<Func<People, bool>> exp = a => true;
                    Console.WriteLine("用户输入个名称，为空就跳过");
                    string name = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(name))
                    {
                        exp = a => a.Name.Contains(name);
                        //DbSet = DbSet.Where(a => a.Name.Contains(name));
                    }
                    Console.WriteLine("用户输入个年级，为空就跳过");
                    string age = Console.ReadLine();
                    int iage;
                    if (!string.IsNullOrWhiteSpace(age) && int.TryParse(age, out iage))
                    {
                        exp = a => a.Age > iage;
                        //DbSet = DbSet.Where(a => a.Account.Contains(account));// 出现整个DBSet 暴露出来了，在使用的时候是非常危险
                    }
                    //exp = a => a.Age > iage && a.Name.Contains(name);
                }

                {
                    //1、可以封装一个表达式目录树的扩展，扩展AndAlso;
                    //2、根据一个字符串+需要查询的条件自动拼接起来 
                    //Expression<Func<People, bool>> exp1 = item => item.Account.Contains("Admin") && item.Name.Contains("Richard");

                    // if(Account 不为空)  
                    //    var Account= typeof(People).GetProperty("Account"); 
                    //   var contains = typeof(string).GetMethod("Contains"); 
                    //    ParameterExpression a = Expression.Parameter(typeof(People), "a");
                    //    Expression<Func<People, bool>> expression = Expression.Lambda<Func<People, bool>>(Expression.AndAlso(Expression.Call(Expression.Property(a, Account, (MethodInfo)MethodBase.GetMethodFromHandle(ldtoken(Contains())), new Expression[]
                    //    {
                    //Expression.Constant("Admin", typeof(string))
                    //    }), Expression.Call(Expression.Property(a, (MethodInfo)MethodBase.GetMethodFromHandle(ldtoken(get_Name()))), (MethodInfo)MethodBase.GetMethodFromHandle(ldtoken(Contains())), new Expression[]
                    //    {
                    //Expression.Constant("Richard", typeof(string))
                    //    })), new ParameterExpression[]
                    //    {
                    //a
                    //    });


                }

            }
        }

        public static void MapperTest()
        {
            {
                //People people = new People()
                //{
                //    Id = 11,
                //    Name = "Richard",
                //    Age = 31
                //};
                //PeopleCopy peopleCopy = new PeopleCopy()//硬编码 //硬编码性能好，但是通用型差
                //{
                //    Id = people.Id,
                //    Name = people.Name,
                //    Age = people.Age
                //};
                ////如果说有其他别的类型需要转换，那么不是为所有的类型都需要写这样代码？ 
                //PeopleCopy peopleCopy1 = ReflectionMapper.Trans<People, PeopleCopy>(people);//反射+泛型方法 
                //PeopleCopy peopleCopy2 = SerializeMapper.Trans<People, PeopleCopy>(people);
                ////Func<People, PeopleCopy> exp1 = p =>
                ////{ 
                ////    return new PeopleCopy()
                ////    { 
                ////        Id = p.Id,
                ////        Name = p.Name,
                ////        Age = p.Age
                ////    };
                ////}; 
                ////泛型方法+表达式目录 = 既可以通用，效率高
                //PeopleCopy peopleCopy3 = ExpressionMapper.Trans<People, PeopleCopy>(people); 
                //PeopleCopy peopleCopy4 = ExpressionGenericMapper<People, PeopleCopy>.Trans(people); 
            }
            {

                Console.WriteLine("****************************性能测试结果***************************");
                People people = new People()
                {
                    Id = 11,
                    Name = "Richard",
                    Age = 31
                };
                long common = 0;
                long generic = 0;
                long cache = 0;
                long reflection = 0;
                long serialize = 0;
                {
                    Stopwatch watch = new Stopwatch();
                    watch.Start();
                    for (int i = 0; i < 100_000; i++)
                    {
                        PeopleCopy peopleCopy = new PeopleCopy()
                        {
                            Id = people.Id,
                            Name = people.Name,
                            Age = people.Age
                        };
                    }
                    watch.Stop();
                    common = watch.ElapsedMilliseconds;
                }
                {
                    Stopwatch watch = new Stopwatch();
                    watch.Start();
                    for (int i = 0; i < 100_000; i++)
                    {
                        PeopleCopy peopleCopy = ReflectionMapper.Trans<People, PeopleCopy>(people);
                    }
                    watch.Stop();
                    reflection = watch.ElapsedMilliseconds;
                }
                {
                    Stopwatch watch = new Stopwatch();
                    watch.Start();
                    for (int i = 0; i < 100_000; i++)
                    {
                        PeopleCopy peopleCopy = SerializeMapper.Trans<People, PeopleCopy>(people);
                    }
                    watch.Stop();
                    serialize = watch.ElapsedMilliseconds;
                }
                {
                    Stopwatch watch = new Stopwatch();
                    watch.Start();
                    for (int i = 0; i < 100_000; i++)
                    {
                        PeopleCopy peopleCopy = ExpressionMapper.Trans<People, PeopleCopy>(people);
                    }
                    watch.Stop();
                    cache = watch.ElapsedMilliseconds;
                }
                {
                    Stopwatch watch = new Stopwatch();
                    watch.Start();
                    for (int i = 0; i < 100_000; i++)
                    {
                        PeopleCopy peopleCopy = ExpressionGenericMapper<People, PeopleCopy>.Trans(people);
                    }
                    watch.Stop();
                    generic = watch.ElapsedMilliseconds;
                }
                Console.WriteLine($"common = { common} ms");
                Console.WriteLine($"reflection = { reflection} ms");
                Console.WriteLine($"serialize = { serialize} ms");
                Console.WriteLine($"cache = { cache} ms");
                Console.WriteLine($"generic = { generic} ms");
            }
            //通过拼接表达式目录树+ 泛型缓存性能最高！
            //硬编码性能最高，为了通用，动态生成硬编码==最完美
        }
    }
}
