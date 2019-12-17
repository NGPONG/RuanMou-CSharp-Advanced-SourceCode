using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyWinform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btndl_Click(object sender, EventArgs e)
        {
            Console.WriteLine("登录");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("支付");
        }
    }
}
