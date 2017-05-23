namespace Rbt6100AutoLine
{
    partial class RbtAutoMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RbtAutoMain));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ipaddress = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.port = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.autolineStatue = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsr_btn_connect = new System.Windows.Forms.ToolStripButton();
            this.tsr_btn_disconnect = new System.Windows.Forms.ToolStripButton();
            this.tsr_btn_check = new System.Windows.Forms.ToolStripButton();
            this.tsr_btn_config = new System.Windows.Forms.ToolStripButton();
            this.tsr_btn_exit = new System.Windows.Forms.ToolStripButton();
            this.monitor1 = new Rbt6100AutoLine.Controls.Monitor();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.ipaddress,
            this.toolStripStatusLabel3,
            this.port,
            this.toolStripStatusLabel5,
            this.autolineStatue,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 970);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1019, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(79, 17);
            this.toolStripStatusLabel1.Text = "本机IP地址：";
            // 
            // ipaddress
            // 
            this.ipaddress.Name = "ipaddress";
            this.ipaddress.Size = new System.Drawing.Size(59, 17);
            this.ipaddress.Text = "127.0.0.1";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(104, 17);
            this.toolStripStatusLabel3.Text = "服务器监听端口：";
            // 
            // port
            // 
            this.port.Name = "port";
            this.port.Size = new System.Drawing.Size(36, 17);
            this.port.Text = "5000";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(80, 17);
            this.toolStripStatusLabel5.Text = "流水线状态：";
            // 
            // autolineStatue
            // 
            this.autolineStatue.Name = "autolineStatue";
            this.autolineStatue.Size = new System.Drawing.Size(32, 17);
            this.autolineStatue.Text = "待机";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(120, 16);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsr_btn_connect,
            this.tsr_btn_disconnect,
            this.tsr_btn_check,
            this.tsr_btn_config,
            this.tsr_btn_exit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1019, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsr_btn_connect
            // 
            this.tsr_btn_connect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsr_btn_connect.Image = ((System.Drawing.Image)(resources.GetObject("tsr_btn_connect.Image")));
            this.tsr_btn_connect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsr_btn_connect.Name = "tsr_btn_connect";
            this.tsr_btn_connect.Size = new System.Drawing.Size(36, 22);
            this.tsr_btn_connect.Text = "连接";
            this.tsr_btn_connect.Click += new System.EventHandler(this.tsr_btn_connect_Click);
            // 
            // tsr_btn_disconnect
            // 
            this.tsr_btn_disconnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsr_btn_disconnect.Image = ((System.Drawing.Image)(resources.GetObject("tsr_btn_disconnect.Image")));
            this.tsr_btn_disconnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsr_btn_disconnect.Name = "tsr_btn_disconnect";
            this.tsr_btn_disconnect.Size = new System.Drawing.Size(36, 22);
            this.tsr_btn_disconnect.Text = "断开";
            this.tsr_btn_disconnect.Click += new System.EventHandler(this.tsr_btn_disconnect_Click);
            // 
            // tsr_btn_check
            // 
            this.tsr_btn_check.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsr_btn_check.Image = ((System.Drawing.Image)(resources.GetObject("tsr_btn_check.Image")));
            this.tsr_btn_check.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsr_btn_check.Name = "tsr_btn_check";
            this.tsr_btn_check.Size = new System.Drawing.Size(36, 22);
            this.tsr_btn_check.Text = "检测";
            this.tsr_btn_check.Click += new System.EventHandler(this.tsr_btn_check_Click);
            // 
            // tsr_btn_config
            // 
            this.tsr_btn_config.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsr_btn_config.Image = ((System.Drawing.Image)(resources.GetObject("tsr_btn_config.Image")));
            this.tsr_btn_config.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsr_btn_config.Name = "tsr_btn_config";
            this.tsr_btn_config.Size = new System.Drawing.Size(36, 22);
            this.tsr_btn_config.Text = "设置";
            this.tsr_btn_config.Click += new System.EventHandler(this.tsr_btn_config_Click);
            // 
            // tsr_btn_exit
            // 
            this.tsr_btn_exit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsr_btn_exit.Image = ((System.Drawing.Image)(resources.GetObject("tsr_btn_exit.Image")));
            this.tsr_btn_exit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsr_btn_exit.Name = "tsr_btn_exit";
            this.tsr_btn_exit.Size = new System.Drawing.Size(36, 22);
            this.tsr_btn_exit.Text = "退出";
            // 
            // monitor1
            // 
            this.monitor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.monitor1.Location = new System.Drawing.Point(0, 25);
            this.monitor1.Name = "monitor1";
            this.monitor1.Size = new System.Drawing.Size(1019, 945);
            this.monitor1.TabIndex = 3;
            // 
            // RbtAutoMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(1010, 580);
            this.ClientSize = new System.Drawing.Size(1019, 992);
            this.Controls.Add(this.monitor1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "RbtAutoMain";
            this.Text = "Rbt6100AutoLine";
            this.Load += new System.EventHandler(this.RbtAutoMain_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsr_btn_connect;
        private System.Windows.Forms.ToolStripButton tsr_btn_disconnect;
        private System.Windows.Forms.ToolStripButton tsr_btn_check;
        private System.Windows.Forms.ToolStripButton tsr_btn_config;
        private System.Windows.Forms.ToolStripButton tsr_btn_exit;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private Rbt6100AutoLine.Controls.Monitor monitor1;
        private System.Windows.Forms.ToolStripStatusLabel ipaddress;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel port;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel autolineStatue;
    }
}

