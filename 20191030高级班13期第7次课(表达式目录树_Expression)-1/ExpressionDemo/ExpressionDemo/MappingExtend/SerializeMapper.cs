using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionDemo.MappingExtend
{
    /// <summary>
    /// 使用第三方序列化反序列化工具
    /// 
    /// 还有automapper
    /// </summary>
    public class SerializeMapper
    {
        /// <summary>
        /// 序列化反序列化方式
        /// </summary>
        /// <typeparam name="TIn"></typeparam>
        /// <typeparam name="TOut"></typeparam>
        public static TOut Trans<TIn, TOut>(TIn tIn)
        {
            return JsonConvert.DeserializeObject<TOut>(JsonConvert.SerializeObject(tIn));
        }
    }
}
