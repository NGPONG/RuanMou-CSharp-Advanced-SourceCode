using Ruanmou.DB.Interface;
using Ruanmou.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace Ruanmou.DB.SqlServer
{
    /// <summary>
    /// SqlServer实现
    /// </summary>
    public class SqlServerHelper : IDBHelper
    { 
        public SqlServerHelper()
        {
            Console.WriteLine("{0}被构造", this.GetType().Name);
        }

        public void Query()
        {
            Console.WriteLine("{0}.Query", this.GetType().Name);
        } 
    }
}
