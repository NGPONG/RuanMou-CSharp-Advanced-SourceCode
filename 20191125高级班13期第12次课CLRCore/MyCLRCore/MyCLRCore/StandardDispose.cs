using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCLRCore
{

    //现在是22：02  大家开始提问，22：05开始答疑，期间老师就就不说话了！
    /// <summary>
    /// 标准Dispose模式
    /// 
    /// 析构函数:被动清理
    /// Dispose：主动清理
    /// </summary>
    public class StandardDispose : IDisposable
    {
        //演示创建一个非托管资源
        private string _UnmanageResource = "未被托管的资源";
        //演示创建一个托管资源
        private string _ManageResource = "托管的资源";


        private bool _disposed = false;

        /// <summary>
        /// 实现IDisposable中的Dispose方法
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true); //必须为true
            GC.SuppressFinalize(this);//通知垃圾回收机制不再调用终结器（析构器）
        }

        /// <summary>
        /// 不是必要的，提供一个Close方法仅仅是为了更符合其他语言（如C++）的规范
        /// </summary>
        public void Close()
        {
            this.Dispose();
        }

        /// <summary>
        /// 必须，以备程序员忘记了显式调用Dispose方法
        /// </summary>
        ~StandardDispose()
        {
            //必须为false
            this.Dispose(false);
        }

        /// <summary>
        /// 非密封类修饰用protected virtual
        /// 密封类修饰用private
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (this._disposed)//已经被释放的还可以不异常
            {
                return;
            }
            if (disposing)
            {
                // 清理托管资源
                if (this._ManageResource != null)
                {
                    //Dispose
                    this._ManageResource = null;
                }
            }
            // 清理非托管资源
            if (this._UnmanageResource != null)
            {
                //Dispose  conn.Dispose()
                this._UnmanageResource = null;
            }
            //让类型知道自己已经被释放
            this._disposed = true;
        }

        public void PublicMethod()
        {
            if (this._disposed)
            {
                throw new ObjectDisposedException("StandardDispose", "StandardDispose is disposed");
            }
            //
        }
    }
}
