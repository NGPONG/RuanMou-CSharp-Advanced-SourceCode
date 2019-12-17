using Ruanmou.Advaned.Lottery.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ruanmou.Advaned.Lottery
{
    /// <summary>
    /// 能听见我说话的，能看到我桌面的小伙伴儿们，刷个1
    /// 高级班的传统，准备好学习的小伙伴儿，给Eleven老师刷个专属字母E，然后课程就正式开始了
    /// 
    /// 
    /// 多线程双色球项目--
    /// 1 理解需求:
    /// 双色球：投注号码由6个红色球号码和1个蓝色球号码组成。
    /// 红色球号码从01--33中选择,不重复
    /// 蓝色球号码从01--16中选择
    /// 
    /// 球号码随机的规则，远程获取一个随机数据的，这个会有较长的时间损耗
    /// 
    /// 
    /// 对双色球颇有经验打个1  否则打个2
    /// 
    /// 1 start里面分拆方法，做些重用
    /// 2 启动的时候，停止按钮上面来个倒计时
    /// 3 结束的时候，能不能按顺序结束
    /// 4 大家能不能加点套路进去呢？
    ///   增加数字重复
    /// </summary>
    public partial class frmSSQ : Form
    {
        public frmSSQ()
        {
            InitializeComponent();
            this.btnStart.Enabled = true;
            this.btnStop.Enabled = false;
        }

        #region Data 
        /// <summary>
        /// 红球集合  其实可以写入配置文件
        /// </summary>
        private string[] RedNums =
        {
            "01","02","03","04","05","06","07","08","09","10",
            "11","12","13","14","15","16","17","18","19","20",
            "21","22","23","24","25","26","27","28","29","30",
            "31","32","33"
        };

        /// <summary>
        /// 蓝球集合
        /// </summary>
        private string[] BlueNums =
        {
            "01","02","03","04","05","06","07","08","09","10",
            "11","12","13","14","15","16"
        };

        private bool IsGoOn = true;
        private List<Task> taskList = new List<Task>();

        #endregion

        #region UI
        /// <summary>
        /// 点击开始：
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                #region 初始化动作
                this.btnStart.Text = "运行ing";
                this.btnStart.Enabled = false;
                this.IsGoOn = true;
                this.taskList = new List<Task>();
                this.lblBlue.Text = "00";
                this.lblRed1.Text = "00";
                this.lblRed2.Text = "00";
                this.lblRed3.Text = "00";
                this.lblRed4.Text = "00";
                this.lblRed5.Text = "00";
                this.lblRed6.Text = "00";
                #endregion
                Thread.Sleep(1000);
                foreach (var control in this.gboSSQ.Controls)
                {
                    if (control is Label)
                    {
                        Label label = (Label)control;
                        if (label.Name.Contains("Blue"))
                        {
                            taskList.Add(Task.Run(() =>
                            {
                                try
                                {
                                    while (IsGoOn)
                                    {
                                        //1 获取随机数 
                                        int index = new RandomHelper().GetRandomNumberDelay(0, 16);
                                        string sNumber = this.BlueNums[index];
                                        //2 更新界面
                                        //this.lblBlue.Text = sNumber;
                                        //子线程不能操作控件，委托给主线程操作
                                        //this.Invoke
                                        this.Invoke(new Action(() =>
                                        {
                                            label.Text = sNumber;
                                        }));
                                        //3 循环
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }));
                        }
                        else if (label.Name.Contains("Red"))
                        {
                            taskList.Add(Task.Run(() =>
                            {
                                try
                                {
                                    while (IsGoOn)
                                    {
                                        int index = new RandomHelper().GetRandomNumberDelay(0, 33);
                                        string sNumber = this.RedNums[index];
                                        //可能重复  得去重
                                        //1 过河的卒子  一次性拿6个，一次更新，但是界面更新有规律
                                        //2 再来个数组标记一下，有点笨拙；其实界面不就有吗？
                                        //3 80奋斗  数据分隔，安全高效，但是有规律

                                        //检测下是否重复，  直接比对界面
                                        //获取随机   比对界面   更新
                                        lock (SSQ_Lock)
                                        {
                                            List<string> usedNumberList = this.GetUsedRedNumbers();
                                            if (!usedNumberList.Contains(sNumber))
                                            {
                                                this.Invoke(new Action(() =>
                                                 {
                                                     //Thread.Sleep(10);
                                                     label.Text = sNumber;
                                                 }));//实际上是同步的
                                            }
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }));
                        }
                    }
                }
                Task.Factory.ContinueWhenAll(this.taskList.ToArray(), tArray =>
                {
                    this.ShowResult();
                    this.Invoke(new Action(() =>
                    {
                        this.btnStart.Enabled = true;
                        this.btnStop.Enabled = false;
                    }));
                });
                Task.Delay(10 * 1000).ContinueWith(t =>
                {
                    this.Invoke(new Action(() =>
                    {
                        this.btnStop.Enabled = true;
                    }));
                });

            }
            catch (Exception ex)
            {
                Console.WriteLine("双色球启动出现异常：{0}", ex.Message);
            }
        }

        private static readonly object SSQ_Lock = new object();

        private List<string> GetUsedRedNumbers()
        {
            List<string> usedNumberList = new List<string>();
            foreach (var controler in this.gboSSQ.Controls)
            {
                if (controler is Label)
                {
                    if (((Label)controler).Name.Contains("Red"))
                    {
                        usedNumberList.Add(((Label)controler).Text);
                    }
                }
            }
            //if (usedNumberList.Distinct<string>().Count() < 6)
            //{
            //    usedNumberList.ForEach(s => Console.WriteLine($"This is {s}"));
            //}
            return usedNumberList;
        }

        /// <summary>
        /// 点击结束
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            this.IsGoOn = false;

            //Thread.Sleep(5 * 1000);//不要这样等待
            //Task.Run(() =>//不止直接waitall 会死锁
            //{
            //    Task.WaitAll(this.taskList.ToArray());
            //    this.ShowResult();
            //});
        }

        /// <summary>
        /// 弹框提示数据
        /// </summary>
        private void ShowResult()
        {
            MessageBox.Show(string.Format("本期双色球结果为：{0} {1} {2} {3} {4} {5}  蓝球{6}"
                , this.lblRed1.Text
                , this.lblRed2.Text
                , this.lblRed3.Text
                , this.lblRed4.Text
                , this.lblRed5.Text
                , this.lblRed6.Text
                , this.lblBlue.Text));
        }
        #endregion


        #region PrivateMethod

        #endregion
    }
}
