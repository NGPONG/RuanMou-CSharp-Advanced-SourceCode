using Ruanmou.DB.Interface;
using Ruanmou.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Reflection;

namespace Ruanmou.DB.SqlServer
{
    /// <summary>
    /// SqlServer实现
    /// </summary>
    public class SqlServerHelper : IDBHelper
    {
        private static string Customers = ConfigurationManager.ConnectionStrings["Customers"].ToString();

        public SqlServerHelper()
        {
            //Console.WriteLine("{0}被构造", this.GetType().Name);
        }

        public void Query()
        {
            //Console.WriteLine("{0}.Query", this.GetType().Name);
        }


        /// <summary>
        /// 泛型方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public static T Find<T>(int id) where T : BaseModel
        {
            //string sql = @"SELECT   [Id]
            //      ,[Name]
            //      ,[CreateTime]
            //      ,[CreatorId]
            //      ,[LastModifierId]
            //      ,[LastModifyTime]
            //  FROM [SystemDB].[dbo].[Company] where Id=" + id;


            Type type = typeof(T);
            object oCompany = Activator.CreateInstance(type);
            //List<string> 
            var propNames = type.GetProperties().Select(a => $"[{a.Name}]");
            string props = string.Join(",", propNames);
            string sql = $"SELECT {props } FROM [{type.Name}] where Id={id}"; 
            using (SqlConnection connection = new SqlConnection(Customers))
            {
                SqlCommand sqlCommand = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.Read()) //开始读取
                {
                    foreach (var prop in type.GetProperties())
                    {
                        prop.SetValue(oCompany, reader[prop.Name]);
                    }
                }
            }

            return (T)oCompany;
        }





        ///// <summary>
        ///// 数据库查询 
        ///// //这里只是查询了company  如果需要查询User  Student
        /////  
        ///// 一个方法满足多个类型的需求
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public static Company Find(int id)
        //{
        //    string sql = @"SELECT   [Id]
        //          ,[Name]
        //          ,[CreateTime]
        //          ,[CreatorId]
        //          ,[LastModifierId]
        //          ,[LastModifyTime]
        //      FROM [SystemDB].[dbo].[Company] where Id=" + id;


        //    Type type = typeof(Company);
        //    object oCompany = Activator.CreateInstance(type);
        //    using (SqlConnection connection = new SqlConnection(Customers))
        //    {
        //        SqlCommand sqlCommand = new SqlCommand(sql, connection);
        //        connection.Open();
        //        SqlDataReader reader = sqlCommand.ExecuteReader();
        //        if (reader.Read()) //开始读取
        //        {
        //            foreach (var prop in type.GetProperties())
        //            {
        //                prop.SetValue(oCompany, reader[prop.Name]);

        //                //if (prop.Name.Equals("Id"))
        //                //{
        //                //    prop.SetValue(oCompany, reader[prop.Name]);
        //                //}
        //                //else if (prop.Name.Equals("Name"))
        //                //{
        //                //    prop.SetValue(oCompany, reader[prop.Name]);
        //                //} 
        //            }

        //            //Console.WriteLine(reader["Id"]);
        //            //Console.WriteLine(reader["Name"]); 
        //            //return new Company() { Id =(int)reader["Id"] };
        //        }

        //    }

        //    return (Company)oCompany;
        //}

    }
}
