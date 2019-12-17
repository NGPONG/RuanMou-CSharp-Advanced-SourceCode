using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyAsyncThread
{
    /// <summary>
    /// 1 进程-线程-多线程，同步和异步
    /// 2 委托启动异步调用
    /// 3 多线程特点：不卡主线程、速度快、无序性
    /// 4 异步的回调和状态参数
    /// 5 异步等待三种方式
    /// 6 异步返回值 
    /// 
    /// 欢迎大家到来.Net高级班的Vip课程，请现在在电脑前的同学帮老师到群里叫一下其他同学！
    /// 
    /// 能听到老师讲话（声音很清晰）,能看到老师屏幕的 刷个 1 
    /// .NetFramework1.0就有多线程！
    /// 进程：计算机概念，程序运行在服务器占据的全部计算机的资源 
    /// 线程：计算机概念，是进程在相应操作时候的一个最小单元，也包括cpu/硬盘/内存  虚拟概念 
    /// 进程和线程：包含关系，线程是属于某一个进程的，如果一个进程销毁，线程也就不会存在。 
    /// 句柄：描述程序中的某一个最小单元，是一个long数字，操作系统通过这个数字识别应用程序。 
    /// 多线程：计算概念，就是某一个进程中，多个线程同时运行；
    ///  
    /// C#中的多线程： 
    /// Thread类是C#语言对线程对象一个封装；
    /// 
    /// 为什么可以多线程呢？
    /// 
    /// 1、Cpu有多个核；可以并行计算；
    ///    双核四线：这里的线程是模拟核；
    /// 
    /// 2、cpu分片：某1s的处理能切分成1000份，操作系统调度去相应不同的任务；
    ///   从宏观角度来说：感觉就有多个任务在并发执行；
    ///   从微观角度来说：一个物理cpu不能在某一刻为某一个任务服务
    ///   
    /// 同步异步：
    ///     同步方法：发起调用，只有在调用的方法完成以后，才能继续执行一下一行代码，按照顺序执行；
    ///     诚心请吃饭，我请你吃饭，你说你现在需要忙一会儿，我等你，等你忙完了以后，咱们一起去吃饭。
    ///     
    ///     异步方法：发起调用，不等待完成，直接进入下一行代码的执行，启动一个新的线程来完成计算
    ///     
    ///     客气一下请人吃饭：我请你吃饭，你说你现在需要忙一会儿，我就不等你了，我自己先去吃饭了，你忙完以后，自己去吃饭。
    ///     
    /// 
    /// </summary>
    public partial class frmThreads : Form
    {
        public frmThreads()
        {
            InitializeComponent();
            Console.WriteLine("欢迎来到.net高级班vip课程，从今天开始我们将开启一轮多线程系列的课程，我是Richard老师！");
        }

        #region Sync
        /// <summary>
        /// 同步方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSync_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"****************btnSync_Click Start {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}***************");
            int l = 3;
            int m = 4;
            int n = l + m;
            for (int i = 0; i < 5; i++)
            {
                string name = string.Format($"btnSync_Click_{i}");
                this.DoSomethingLong(name);
            }
            Console.WriteLine($"****************btnSync_Click   End {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}***************");

        }
        #endregion

        #region Async
        /// <summary>  
        /// 异步方法：
        ///  1、同步方法卡界面：主线线程（UI线程）忙于计算，无暇他顾 
        ///     异步方法不卡界面：因为异步方法是新启动一个线程去完后计算，主线程闲置
        ///     改善用户体验，winform程序点击某一个按钮，不会卡死界面；
        ///     发短信，发邮件可以交给一个子线程去完成
        ///     
        ///  2、同步方法执行慢:只有一个线程完成计算
        ///     异步方法执行快：多个线程去完成计算
        ///     10000ms   3000ms   快了三倍多
        ///     20000ms   15000ms  cpu密集型计算
        ///     资源换性能
        ///     
        ///  3、同步方法有序执行，异步多线程无顺序
        ///     启动无序，线程资源是向操作系统申请的，操作系统有自己的调度策略，所以启动是随机的；
        ///     以上两点得出： 结束也是没有顺序
        ///    
        /// 如果需要控制顺序呢？怎么实现? 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAsync_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"****************btnAsync_Click Start {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}***************");

            //Action<string> action = new Action<string>(this.DoSomethingLong);
            Action<string> action = this.DoSomethingLong;
            //action.Invoke("大白");
            //action("蓝冰");

            for (int i = 0; i < 5; i++)
            {
                action.BeginInvoke("btnAsync_Click", null, null);
            }

            Console.WriteLine($"****************btnAsync_Click End   {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}***************");
        }
        #endregion


        #region Private Method
        /// <summary>
        /// 一个比较耗时耗资源的私有方法
        /// </summary>
        /// <param name="name"></param>
        private void DoSomethingLong(string name)
        {
            Console.WriteLine($"****************DoSomethingLong Start  {name}  {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}***************");
            long lResult = 0;

            //for (int i = 0; i < 1_000_000_000; i++)
            //{
            //    lResult += i;
            //} 
            Thread.Sleep(2000);//线程等待

            Console.WriteLine($"****************DoSomethingLong   End  {name}  {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} {lResult}***************");
        }

        #endregion

        private void btnAsyncAdvanced_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"****************btnAsyncAdvanced_Click Start   {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}***************");

            {

                //1、回调：把后续的动作通过回调参数传递进去，子线程完成计算以后，去嗲用这个回调委托
                AsyncCallback callback = ar =>
                {
                    Console.WriteLine($"计算结束了。。。。{Thread.CurrentThread.ManagedThreadId}");
                };

                //Action<string> action = this.DoSomethingLong;
                ////action.Invoke("杰克");
                ////action("天苍苍");
                ////Console.WriteLine("计算结束了。。。。");

                //var asyncResult = action.BeginInvoke("btnAsyncAdvanced_Click", callback, null);
                ////Console.WriteLine("计算结束了。。。。");
                
                IAsyncResult asyncResult = null; 
                {
                    Func<string, string> func = (ar) => {
                        Console.WriteLine($"线程Id：{Thread.CurrentThread.ManagedThreadId}");
                        return "Hyl";
                    };
                    asyncResult = func.BeginInvoke("大白", callback, null); 
                }

                //现在是21:45 大家开始提问，21:50开始答疑。期间老师不说话！

            }

            Console.WriteLine($"****************btnAsyncAdvanced_Click   End   {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}  ***************");
        }
    }
}
