namespace MyWinform
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btndl = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
             
            this.SuspendLayout();
            // 
            // btndl
            // 
            this.btndl.Location = new System.Drawing.Point(65, 53);
            this.btndl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btndl.Name = "btndl";
            this.btndl.Size = new System.Drawing.Size(138, 86);
            this.btndl.TabIndex = 0;
            this.btndl.Text = "登录";
            this.btndl.UseVisualStyleBackColor = true;
            this.btndl.Click += new System.EventHandler(this.btndl_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(65, 209);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 86);
            this.button1.TabIndex = 0;
            this.button1.Text = "支付";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(584, 93);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(155, 88);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 422);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btndl);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btndl;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

