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
    public class Client
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
        public bool CheckUser(int id, string password)
        {
            if (true) { }
            else { }

            return DateTime.Now < DateTime.Now.AddDays(1);
        }

        public double QueryBalance(int id)
        {
            if (true) { }
            else { }

            return new Random().Next(10000, 1000000);
        }
        public double CalculateInterest(double balance)
        {
            if (true) { }
            else { }
            return balance * 0.005;
        }

        public void Show(string name, double balance, double interest)
        {
            Console.WriteLine("尊敬的{0}客户，你的账户余额为：{1}，利息为{2}",
                name, balance, interest);
        }
    }
}
