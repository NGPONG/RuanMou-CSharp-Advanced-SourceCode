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
    /// 为什么可以多线程呢？ 
    /// 1、Cpu有多个核；可以并行计算；
    ///    双核四线：这里的线程是模拟核； 
    /// 2、cpu分片：某1s的处理能切分成1000份，操作系统调度去相应不同的任务；
    ///   从宏观角度来说：感觉就有多个任务在并发执行；
    ///   从微观角度来说：一个物理cpu不能在某一刻为某一个任务服务
    /// 同步异步：
    ///     同步方法：发起调用，只有在调用的方法完成以后，才能继续执行一下一行代码，按照顺序执行；
    ///     诚心请吃饭，我请你吃饭，你说你现在需要忙一会儿，我等你，等你忙完了以后，咱们一起去吃饭。
    ///     
    ///     异步方法：发起调用，不等待完成，直接进入下一行代码的执行，启动一个新的线程来完成计算
    ///     
    ///     客气一下请人吃饭：我请你吃饭，你说你现在需要忙一会儿，我就不等你了，我自己先去吃饭了，你忙完以后，自己去吃饭。
    ///      
    /// 1 thread：线程等待，回调，前台线程/后台线程
    /// 2 threadpool：线程池使用，设置线程池，ManualResetEvent
    /// 3 扩展封装thread&threadpool回调/等待  
    /// 
    /// 欢迎大家来到.net高级班的Vip课程，我是Richard老师；
    /// 课程8分钟之后准时开始！
    /// 
    /// 能听到老师讲话（声音很清晰） 能看到老师屏幕刷个1
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

            //IAsyncResult asyncResult = null;
            //AsyncCallback callback = ar =>
            //{

            //    Thread.Sleep(5000);
            //    Console.WriteLine($"这里是beginInvoke的第三个参数{ar.AsyncState}");
            //    Console.WriteLine(object.ReferenceEquals(ar, asyncResult));
            //    Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy - MM - dd HH: mm:ss.fff")}");
            //    Console.WriteLine("计算结束");
            //};
            //{
            //    //1、回调
            //    Action<string> action = this.DoSomethingLong;
            //    //如果把自定义的参数传入到回调函数中去？
            //    asyncResult = action.BeginInvoke("btnAsyncAdvanced_Click", callback, "八万公里");
            //    //Console.WriteLine("计算结束");
            //}

            //2、IsCompleted 完成等待 
            {
                //int i = 0;
                //while (!asyncResult.IsCompleted)
                //{
                //    if (i < 9)
                //    {
                //        Console.WriteLine($"正在玩命为你加载中。。。已经完成{++i * 10}%");
                //    }
                //    else
                //    {
                //        Console.WriteLine($"正在玩命为你加载中。。。已经完成99.9999%");
                //    }
                //    Thread.Sleep(200);
                //}

                //Console.WriteLine("加载完成。。。");
            }

            //以上两种都是为了等待任务的完成；
            //3、WaitOne等待
            //asyncResult.AsyncWaitHandle.WaitOne();//一直等待任务完成
            //asyncResult.AsyncWaitHandle.WaitOne(-1);//一直等待任务完成
            //asyncResult.AsyncWaitHandle.WaitOne(3000);//最多等待3000ms,如果超时了，就不等待了 

            {
                //4、EndInvoke也可以等待，可以获取委托返回值
                Func<int> func = () =>
                {
                    //Thread.Sleep(5000);
                    return DateTime.Now.Year;
                };
                func.Invoke();
                IAsyncResult asyncResult1 = func.BeginInvoke(ar =>
                  {
                      func.EndInvoke(ar);
                  }, null);

                int iResult = func.EndInvoke(asyncResult1);
                Console.WriteLine(iResult);

            }


            Console.WriteLine($"****************btnAsyncAdvanced_Click   End   {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}  ***************");
        }

        /// <summary>
        /// C#中的多线程 
        /// 1.0已经存在
        /// Thread:C#对线程对象的一个封装
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThread_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"****************btnThread_Click Start   {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}***************");
            //{ 
            //    ParameterizedThreadStart threadStart = ar => { 
            //        this.DoSomethingLong("btnThread_Click");
            //        Console.WriteLine($"****************btnThread_Click   End   {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}  ***************");
            //    };
            //    Thread thread = new Thread(threadStart);
            //    thread.Start(); //开启一个新线程
            //}
            {
                ThreadStart threadStart = () =>
                {
                    Thread.Sleep(5000);
                    this.DoSomethingLong("btnThread_Click");
                    Console.WriteLine($"****************btnThread_Click   End   {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}  ***************");
                };
                Thread thread = new Thread(threadStart);
                thread.Start(); //开启一个新线程  
                thread.Suspend();// 暂停线程
                thread.Resume();//恢复  无法实时的去暂停或者恢复线程 
                thread.Abort();//终结线程
                Thread.ResetAbort();//都会有延时
                 

                //如果我们需要等待；
                //1、等待
                //while (thread.ThreadState != ThreadState.Stopped)
                //{
                //    Thread.Sleep(200);
                //} 
                //2、Join等待
                //thread.Join();//可以限时等待
                //thread.Join(2000); //可以限时等待

                //thread.Priority = ThreadPriority.Highest;//是不是就可以保证是优先执行？
                //只是增加他的优先概率；并不能一定的

                // thread.IsBackground = true;//为后台线程  进程结束，线程结束了
                // thread.IsBackground = false; //前台线程   进程结束后，任务执行完毕以后，线程才结束 
                {
                    //ThreadStart threadStart1 = () => {
                    //    Console.WriteLine($"****************btnThread_Click   End   {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}  ***************");
                    //    Thread.Sleep(3000);  
                    //};

                    //Action action = () => {
                    //    Console.WriteLine($"****************btnThread_Click   End   {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}  ***************");

                    //    Thread.Sleep(3000);
                    //};
                    //this.ThreadWithCallBack(threadStart1, action); 
                }
                {
                    //Thread开启一个新的线程执行任务，如何获取返回结果：
                    Func<int> func = () =>
                    {
                        Thread.Sleep(5000);
                        return DateTime.Now.Year;
                    };
                    Func<int> FuncResult = this.ThreadWithReturn(func);
                    Console.WriteLine("欢迎大家来到.Net 高级班");
                    Console.WriteLine("欢迎大家来到.Net 高级班");
                    Console.WriteLine("欢迎大家来到.Net 高级班");
                    Console.WriteLine("欢迎大家来到.Net 高级班");
                    Console.WriteLine("欢迎大家来到.Net 高级班");
                    Console.WriteLine("欢迎大家来到.Net 高级班"); 
                    int iResult = FuncResult.Invoke();//如果需要得到执行结果，是必须要等待的

                    //如果返回一个委托，在需要执行结果的时候，再去执行这个委托；

                    //现在是21:57 大家开始提问，22:02开始答疑 期间老师就不说话了

                }


            }



            Console.WriteLine($"****************btnThread_Click   End   {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}  ***************");
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="threadStart"></param>
        /// <param name="actionCallback"></param>
        private void ThreadWithCallBack(ThreadStart threadStart, Action actionCallback)
        {
            //Thread thread = new Thread(threadStart);
            //thread.Start();
            //thread.Join();//
            //actionCallback.Invoke();

            ThreadStart threadStart1 = new ThreadStart(() =>
            {
                threadStart.Invoke();
                actionCallback.Invoke();
            });
            Thread thread = new Thread(threadStart1);
            thread.Start();
        }


        /// <summary>
        /// 既要不卡界面，又需要返回结果  
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        private Func<T> ThreadWithReturn<T>(Func<T> func)
        {
            T t = default(T);
            ThreadStart threadStart = new ThreadStart(() =>
            {
                t = func.Invoke();
            });
            Thread thread = new Thread(threadStart);
            thread.Start();

            return new Func<T>(() =>
            {
                thread.Join();
                return t;
            });


        }

        /// <summary>
        /// 线程池
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThreadPool_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"****************btnThreadPool_Click Start   {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}***************");


            Console.WriteLine($"****************btnThreadPool_Click   End   {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}  ***************");
        }
    }
}
