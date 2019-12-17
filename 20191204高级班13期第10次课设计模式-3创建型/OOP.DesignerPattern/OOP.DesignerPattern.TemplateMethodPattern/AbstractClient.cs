using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.DesignerPattern.TemplateMethodPattern
{
    /// <summary>
    /// 银行客户端
    /// </summary>
    public abstract class AbstractClient
    {
        public void Query(int id, string name, string password)
        {
            if (this.CheckUser(id, password))
            {
                double balance = this.QueryBalance(id);
                double interest = this.CalculateInterest(balance);
                this.Show(name, balance, interest);
            }
            else
            {
                Console.WriteLine("账户密码错误");
            }
        }
        /// <summary>
        /// 全部子类都相同的  普通方法 写在父类
        /// </summary>
        /// <param name="id"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool CheckUser(int id, string password)
        {
            return DateTime.Now < DateTime.Now.AddDays(1);
        }
        /// <summary>
        /// 全部子类都相同的  普通方法 写在父类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public double QueryBalance(int id)
        {
            return new Random().Next(10000, 1000000);
        }

        /// <summary>
        /// 活期  定期  利率不同
        /// 各种子类都不同的，但是都有这个功能
        /// </summary>
        /// <param name="balance"></param>
        /// <returns></returns>
        public abstract double CalculateInterest(double balance);

        /// <summary>
        /// 个别子类不一样的  用虚方法
        /// </summary>
        /// <param name="name"></param>
        /// <param name="balance"></param>
        /// <param name="interest"></param>
        public virtual void Show(string name, double balance, double interest)
        {
            Console.WriteLine("尊敬的{0}客户，你的账户余额为：{1}，利息为{2}",
                name, balance, interest);
        }
        //private void Show(string name, double balance, double interest)
        //{
        //    Console.WriteLine("尊贵的{0} vip客户，您的账户余额为：{1}，利息为{2}",
        //        name, balance, interest);
        //}

    }
}
