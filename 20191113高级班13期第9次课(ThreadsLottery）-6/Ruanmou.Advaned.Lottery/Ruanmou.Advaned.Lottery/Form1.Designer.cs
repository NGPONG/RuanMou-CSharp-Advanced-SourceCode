namespace Ruanmou.Advaned.Lottery
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gboSSQ = new System.Windows.Forms.GroupBox();
            this.lblRed1 = new System.Windows.Forms.Label();
            this.lblRed2 = new System.Windows.Forms.Label();
            this.lblRed3 = new System.Windows.Forms.Label();
            this.lblRed4 = new System.Windows.Forms.Label();
            this.lblRed5 = new System.Windows.Forms.Label();
            this.lblRed6 = new System.Windows.Forms.Label();
            this.lblBlue = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.gboSSQ.SuspendLayout();
            this.SuspendLayout();
            // 
            // gboSSQ
            // 
            this.gboSSQ.Controls.Add(this.lblBlue);
            this.gboSSQ.Controls.Add(this.lblRed6);
            this.gboSSQ.Controls.Add(this.lblRed5);
            this.gboSSQ.Controls.Add(this.lblRed4);
            this.gboSSQ.Controls.Add(this.lblRed3);
            this.gboSSQ.Controls.Add(this.lblRed2);
            this.gboSSQ.Controls.Add(this.lblRed1);
            this.gboSSQ.Location = new System.Drawing.Point(23, 31);
            this.gboSSQ.Name = "gboSSQ";
            this.gboSSQ.Size = new System.Drawing.Size(463, 121);
            this.gboSSQ.TabIndex = 0;
            this.gboSSQ.TabStop = false;
            this.gboSSQ.Text = "双色球结果区";
            // 
            // lblRed1
            // 
            this.lblRed1.AutoSize = true;
            this.lblRed1.ForeColor = System.Drawing.Color.Red;
            this.lblRed1.Location = new System.Drawing.Point(8, 55);
            this.lblRed1.Name = "lblRed1";
            this.lblRed1.Size = new System.Drawing.Size(17, 12);
            this.lblRed1.TabIndex = 0;
            this.lblRed1.Text = "00";
            // 
            // lblRed2
            // 
            this.lblRed2.AutoSize = true;
            this.lblRed2.ForeColor = System.Drawing.Color.Red;
            this.lblRed2.Location = new System.Drawing.Point(68, 55);
            this.lblRed2.Name = "lblRed2";
            this.lblRed2.Size = new System.Drawing.Size(17, 12);
            this.lblRed2.TabIndex = 1;
            this.lblRed2.Text = "00";
            // 
            // lblRed3
            // 
            this.lblRed3.AutoSize = true;
            this.lblRed3.ForeColor = System.Drawing.Color.Red;
            this.lblRed3.Location = new System.Drawing.Point(130, 55);
            this.lblRed3.Name = "lblRed3";
            this.lblRed3.Size = new System.Drawing.Size(17, 12);
            this.lblRed3.TabIndex = 2;
            this.lblRed3.Text = "00";
            // 
            // lblRed4
            // 
            this.lblRed4.AutoSize = true;
            this.lblRed4.ForeColor = System.Drawing.Color.Red;
            this.lblRed4.Location = new System.Drawing.Point(195, 55);
            this.lblRed4.Name = "lblRed4";
            this.lblRed4.Size = new System.Drawing.Size(17, 12);
            this.lblRed4.TabIndex = 3;
            this.lblRed4.Text = "00";
            // 
            // lblRed5
            // 
            this.lblRed5.AutoSize = true;
            this.lblRed5.ForeColor = System.Drawing.Color.Red;
            this.lblRed5.Location = new System.Drawing.Point(255, 55);
            this.lblRed5.Name = "lblRed5";
            this.lblRed5.Size = new System.Drawing.Size(17, 12);
            this.lblRed5.TabIndex = 4;
            this.lblRed5.Text = "00";
            // 
            // lblRed6
            // 
            this.lblRed6.AutoSize = true;
            this.lblRed6.ForeColor = System.Drawing.Color.Red;
            this.lblRed6.Location = new System.Drawing.Point(308, 55);
            this.lblRed6.Name = "lblRed6";
            this.lblRed6.Size = new System.Drawing.Size(17, 12);
            this.lblRed6.TabIndex = 5;
            this.lblRed6.Text = "00";
            // 
            // lblBlue
            // 
            this.lblBlue.AutoSize = true;
            this.lblBlue.ForeColor = System.Drawing.Color.Blue;
            this.lblBlue.Location = new System.Drawing.Point(402, 55);
            this.lblBlue.Name = "lblBlue";
            this.lblBlue.Size = new System.Drawing.Size(17, 12);
            this.lblBlue.TabIndex = 6;
            this.lblBlue.Text = "00";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(139, 171);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(259, 171);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 262);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.gboSSQ);
            this.Name = "Form1";
            this.Text = "Form1";
            this.gboSSQ.ResumeLayout(false);
            this.gboSSQ.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gboSSQ;
        private System.Windows.Forms.Label lblBlue;
        private System.Windows.Forms.Label lblRed6;
        private System.Windows.Forms.Label lblRed5;
        private System.Windows.Forms.Label lblRed4;
        private System.Windows.Forms.Label lblRed3;
        private System.Windows.Forms.Label lblRed2;
        private System.Windows.Forms.Label lblRed1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
    }
}

