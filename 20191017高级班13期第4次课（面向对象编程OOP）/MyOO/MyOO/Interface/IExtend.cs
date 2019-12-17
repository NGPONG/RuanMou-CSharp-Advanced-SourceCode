using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOO.Interface
{
    /// <summary>
    /// 接口里面究竟可以放哪些成员
    /// </summary>
    public interface IExtend
    {
        void PlayGame();

        int Id { get; set; }

        //string Remark;字段不行

        //delegate void Show();  委托不行

        event Action DoNothing;

        /// <summary>
        /// 索引器可以
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        int this[int i]
        {
            get;
        }
    }
}
