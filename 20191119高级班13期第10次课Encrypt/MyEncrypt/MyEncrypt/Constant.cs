using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEncrypt
{
    public static class Constant
    {
        public static string DesKey = AppSettings("DesKey", "Richard2019");


        private static T AppSettings<T>(string key, T defaultValue)
        {
            var v = ConfigurationManager.AppSettings[key];
            return String.IsNullOrEmpty(v) ? defaultValue : (T)Convert.ChangeType(v, typeof(T));
        }

    }




}
