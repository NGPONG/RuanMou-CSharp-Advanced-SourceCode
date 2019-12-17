using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDelegateEvent.DelegateExtend
{
    public class DBExcuteHelper
    {
        public void Show()
        {
            string insertSql = "insertSql";
            string deleteSql = "deleteSql";
            string updateSql = "updateSql";
            string searchSql = "searchSql";

            this.Excute(insertSql);
            this.Excute(deleteSql);
            this.Excute(updateSql);
            this.Excute(searchSql);
        }


        /// <summary>
        /// 完成sql的执行，一个db sql helper
        /// </summary>
        public void Excute(string sql)
        {
            using (SqlConnection conn = new SqlConnection(""))
            {
                //conn.Open();
                //还可以扩展事务
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                Console.WriteLine($"执行下数据库{nameof(sql)}={sql}");
            }
        }

        #region ElevenWhere
        /// <summary>
        /// 筛选数据
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> ElevenWhere<TSource>(IEnumerable<TSource> source, Func<TSource, bool> func)
        {
            List<TSource> studentList = new List<TSource>();
            foreach (TSource item in source)
            {
                bool bResult = func.Invoke(item);
                if (bResult)
                {
                    studentList.Add(item);
                }
            }
            return studentList;
        }
        #endregion

        #region ExcuteSql
        public T ExcuteSql<T>(string sql, Func<IDbCommand, T> func)
        {
            using (SqlConnection conn = new SqlConnection(""))
            {
                conn.Open();
                //还可以扩展事务
                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                return func(cmd);
            }
        }
        #endregion

        #region SafeInvoke
        /// <summary>
        /// 通用的异常处理
        /// </summary>
        /// <param name="act">对应任何的逻辑</param>
        public static void SafeInvoke(Action act)
        {
            try
            {
                act.Invoke();
            }
            catch (Exception ex)//按异常类型区分处理
            {
                Console.WriteLine(ex.Message);
            }
        }
        #endregion
    }
}
