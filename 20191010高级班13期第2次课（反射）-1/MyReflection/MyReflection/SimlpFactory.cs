using Ruanmou.DB.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyReflectiondFactory
{
    public class SimlpFactory
    { 
        private static string IDBHelperConfig = ConfigurationManager.AppSettings["IDBHelperConfig"]; 
        private static string DllName = IDBHelperConfig.Split(',')[1];
        private static string TypeName = IDBHelperConfig.Split(',')[0]; 
        public static IDBHelper CreateInstentce()
        {
            Assembly assembly = Assembly.Load(DllName);
            Type type = assembly.GetType(TypeName);
            object oDbHelper = Activator.CreateInstance(type);
            return oDbHelper as IDBHelper;
        }
    }
}
