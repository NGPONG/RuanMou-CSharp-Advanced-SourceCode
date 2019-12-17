using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOSerialize
{
    /// <summary>
    /// 集中管理系统的配置字段
    /// </summary>
    public class Constant
    {
        /// <summary>
        /// 配置绝对路径
        /// </summary>
        public static string LogPath = ConfigurationManager.AppSettings["LogPath"];
        public static string LogMovePath = ConfigurationManager.AppSettings["LogMovePath"];

        /// <summary>
        /// 序列化数据地址
        /// </summary>
        public static string SerializeDataPath = ConfigurationManager.AppSettings["SerializeDataPath"];
    }
}
