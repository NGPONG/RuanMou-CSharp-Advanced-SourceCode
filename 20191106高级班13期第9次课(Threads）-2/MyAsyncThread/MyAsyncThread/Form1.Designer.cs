namespace MyAsyncThread
{
    partial class frmThreads
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
            this.btnSync = new System.Windows.Forms.Button();
            this.btnAsync = new System.Windows.Forms.Button();
            this.btnAsyncAdvanced = new System.Windows.Forms.Button();
            this.btnThread = new System.Windows.Forms.Button();
            this.btnThreadPool = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSync
            // 
            this.btnSync.Location = new System.Drawing.Point(177, 71);
            this.btnSync.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(109, 50);
            this.btnSync.TabIndex = 0;
            this.btnSync.Text = "同步方法";
            this.btnSync.UseVisualStyleBackColor = true;
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
            // 
            // btnAsync
            // 
            this.btnAsync.Location = new System.Drawing.Point(177, 146);
            this.btnAsync.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAsync.Name = "btnAsync";
            this.btnAsync.Size = new System.Drawing.Size(109, 52);
            this.btnAsync.TabIndex = 1;
            this.btnAsync.Text = "Async";
            this.btnAsync.UseVisualStyleBackColor = true;
            this.btnAsync.Click += new System.EventHandler(this.btnAsync_Click);
            // 
            // btnAsyncAdvanced
            // 
            this.btnAsyncAdvanced.Location = new System.Drawing.Point(177, 224);
            this.btnAsyncAdvanced.Name = "btnAsyncAdvanced";
            this.btnAsyncAdvanced.Size = new System.Drawing.Size(109, 49);
            this.btnAsyncAdvanced.TabIndex = 2;
            this.btnAsyncAdvanced.Text = "Async进阶";
            this.btnAsyncAdvanced.UseVisualStyleBackColor = true;
            this.btnAsyncAdvanced.Click += new System.EventHandler(this.btnAsyncAdvanced_Click);
            // 
            // btnThread
            // 
            this.btnThread.Location = new System.Drawing.Point(177, 314);
            this.btnThread.Name = "btnThread";
            this.btnThread.Size = new System.Drawing.Size(109, 49);
            this.btnThread.TabIndex = 3;
            this.btnThread.Text = "Thread";
            this.btnThread.UseVisualStyleBackColor = true;
            this.btnThread.Click += new System.EventHandler(this.btnThread_Click);
            // 
            // btnThreadPool
            // 
            this.btnThreadPool.Location = new System.Drawing.Point(177, 410);
            this.btnThreadPool.Name = "btnThreadPool";
            this.btnThreadPool.Size = new System.Drawing.Size(109, 51);
            this.btnThreadPool.TabIndex = 4;
            this.btnThreadPool.Text = "ThreadPool";
            this.btnThreadPool.UseVisualStyleBackColor = true;
            this.btnThreadPool.Click += new System.EventHandler(this.btnThreadPool_Click);
            // 
            // frmThreads
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 571);
            this.Controls.Add(this.btnThreadPool);
            this.Controls.Add(this.btnThread);
            this.Controls.Add(this.btnAsyncAdvanced);
            this.Controls.Add(this.btnAsync);
            this.Controls.Add(this.btnSync);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmThreads";
            this.Text = "异步多线程学习";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSync;
        private System.Windows.Forms.Button btnAsync;
        private System.Windows.Forms.Button btnAsyncAdvanced;
        private System.Windows.Forms.Button btnThread;
        private System.Windows.Forms.Button btnThreadPool;
    }
}

