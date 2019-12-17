using System;
using System.Collections.Generic;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionDemo.DBExtend
{
    /// <summary>
    /// 还没验证
    /// 利用linq to sql生成的sql进行截断替换
    /// </summary>
    public static class ObjectQueryExtension
    {
        /// <summary>
        /// 执行批量删除操作。直接使用 ado.net
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate">条件</param>
        /// <returns></returns>
        public static int Delete<TEntity>(this ObjectQuery<TEntity> source, Expression<Func<TEntity, bool>> predicate)
                                                               where TEntity : System.Data.Objects.DataClasses.EntityObject
        {
            var selectSql = (source.Where(predicate) as ObjectQuery).ToTraceString();

            //
            int startIndex = selectSql.IndexOf(",");
            int endIndex = selectSql.IndexOf(".");
            string tableAlias = selectSql.Substring(startIndex + 1, endIndex - startIndex - 1);//get table alias
            startIndex = selectSql.IndexOf("FROM");
            string deleteSql = "DELETE " + tableAlias + " " + selectSql.Substring(startIndex);
            //Gets the string used to open a SQL Server database
            string connectionString = ((source as ObjectQuery).Context.Connection as EntityConnection).StoreConnection.ConnectionString;

            return ExecuteNonQuery(connectionString, deleteSql);
        }

        /// <summary>
        /// 执行T-sql 语句
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private static int ExecuteNonQuery(string connectionString, string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.Parameters.AddRange(parameters);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = sql;

                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
