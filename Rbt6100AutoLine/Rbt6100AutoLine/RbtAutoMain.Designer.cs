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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsr_btn_connect = new System.Windows.Forms.ToolStripButton();
            this.tsr_btn_disconnect = new System.Windows.Forms.ToolStripButton();
            this.tsr_btn_check = new System.Windows.Forms.ToolStripButton();
            this.tsr_btn_config = new System.Windows.Forms.ToolStripButton();
            this.tsr_btn_exit = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 663);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1055, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(131, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
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
            this.toolStrip1.Size = new System.Drawing.Size(1055, 25);
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
            // 
            // tsr_btn_disconnect
            // 
            this.tsr_btn_disconnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsr_btn_disconnect.Image = ((System.Drawing.Image)(resources.GetObject("tsr_btn_disconnect.Image")));
            this.tsr_btn_disconnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsr_btn_disconnect.Name = "tsr_btn_disconnect";
            this.tsr_btn_disconnect.Size = new System.Drawing.Size(36, 22);
            this.tsr_btn_disconnect.Text = "断开";
            // 
            // tsr_btn_check
            // 
            this.tsr_btn_check.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsr_btn_check.Image = ((System.Drawing.Image)(resources.GetObject("tsr_btn_check.Image")));
            this.tsr_btn_check.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsr_btn_check.Name = "tsr_btn_check";
            this.tsr_btn_check.Size = new System.Drawing.Size(36, 22);
            this.tsr_btn_check.Text = "检测";
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
            // panel1
            // 
            this.panel1.BackgroundImage = global::Rbt6100AutoLine.Properties.Resources.red_Light;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(307, 128);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(210, 220);
            this.panel1.TabIndex = 3;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(120, 16);
            // 
            // RbtAutoMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 685);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "RbtAutoMain";
            this.Text = "Rbt6100AutoLine";
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
        private System.Windows.Forms.Panel panel1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
    }
}

