namespace Rbt6100AutoLine.Controls
{
    partial class CamSetFrm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.reset_btn = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cameralink_btn = new System.Windows.Forms.Button();
            this.cameragrab_btn = new System.Windows.Forms.Button();
            this.bitper_cbx = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cp_cbx = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.vr_cbx = new System.Windows.Forms.ComboBox();
            this.hr_cbx = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cameraName_cbx = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.camerasetting_statutelable = new System.Windows.Forms.ToolStripStatusLabel();
            this.videoControl1 = new Rbt6100AutoLine.Controls.VideoControl();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(845, 570);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "相机";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(7, 21);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(832, 543);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.reset_btn);
            this.tabPage1.Controls.Add(this.comboBox1);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Controls.Add(this.bitper_cbx);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.cp_cbx);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.vr_cbx);
            this.tabPage1.Controls.Add(this.hr_cbx);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.cameraName_cbx);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(824, 517);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "连接";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // reset_btn
            // 
            this.reset_btn.Location = new System.Drawing.Point(420, 163);
            this.reset_btn.Name = "reset_btn";
            this.reset_btn.Size = new System.Drawing.Size(75, 23);
            this.reset_btn.TabIndex = 18;
            this.reset_btn.Text = "重置";
            this.reset_btn.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "上料",
            "装配_1",
            "装配_2",
            "下料"});
            this.comboBox1.Location = new System.Drawing.Point(80, 165);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(334, 20);
            this.comboBox1.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 168);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 16;
            this.label7.Text = "对应工作站：";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.cameralink_btn, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cameragrab_btn, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(8, 198);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(805, 74);
            this.tableLayoutPanel1.TabIndex = 15;
            // 
            // cameralink_btn
            // 
            this.cameralink_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cameralink_btn.Location = new System.Drawing.Point(3, 3);
            this.cameralink_btn.Name = "cameralink_btn";
            this.cameralink_btn.Size = new System.Drawing.Size(396, 31);
            this.cameralink_btn.TabIndex = 10;
            this.cameralink_btn.Text = "连接";
            this.cameralink_btn.UseVisualStyleBackColor = true;
            this.cameralink_btn.Click += new System.EventHandler(this.cameralink_btn_Click);
            // 
            // cameragrab_btn
            // 
            this.cameragrab_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cameragrab_btn.Location = new System.Drawing.Point(405, 3);
            this.cameragrab_btn.Name = "cameragrab_btn";
            this.cameragrab_btn.Size = new System.Drawing.Size(397, 31);
            this.cameragrab_btn.TabIndex = 12;
            this.cameragrab_btn.Text = "实时";
            this.cameragrab_btn.UseVisualStyleBackColor = true;
            this.cameragrab_btn.Click += new System.EventHandler(this.cameragrab_btn_Click);
            // 
            // bitper_cbx
            // 
            this.bitper_cbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bitper_cbx.FormattingEnabled = true;
            this.bitper_cbx.Items.AddRange(new object[] {
            "-1",
            "8",
            "10",
            "12",
            "14",
            "16"});
            this.bitper_cbx.Location = new System.Drawing.Point(70, 125);
            this.bitper_cbx.Name = "bitper_cbx";
            this.bitper_cbx.Size = new System.Drawing.Size(743, 20);
            this.bitper_cbx.TabIndex = 9;
            this.bitper_cbx.SelectedIndexChanged += new System.EventHandler(this.bitper_cbx_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "位深度";
            // 
            // cp_cbx
            // 
            this.cp_cbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cp_cbx.FormattingEnabled = true;
            this.cp_cbx.Items.AddRange(new object[] {
            "default",
            "gray",
            "raw",
            "rgb",
            "yuv"});
            this.cp_cbx.Location = new System.Drawing.Point(70, 87);
            this.cp_cbx.Name = "cp_cbx";
            this.cp_cbx.Size = new System.Drawing.Size(743, 20);
            this.cp_cbx.TabIndex = 7;
            this.cp_cbx.SelectedIndexChanged += new System.EventHandler(this.cp_cbx_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "颜色空间";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(255, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "Y";
            // 
            // vr_cbx
            // 
            this.vr_cbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vr_cbx.FormattingEnabled = true;
            this.vr_cbx.Items.AddRange(new object[] {
            "默认值",
            "全部",
            "一半",
            "四分之一"});
            this.vr_cbx.Location = new System.Drawing.Point(272, 49);
            this.vr_cbx.Name = "vr_cbx";
            this.vr_cbx.Size = new System.Drawing.Size(541, 20);
            this.vr_cbx.TabIndex = 4;
            this.vr_cbx.SelectedIndexChanged += new System.EventHandler(this.vr_cbx_SelectedIndexChanged);
            // 
            // hr_cbx
            // 
            this.hr_cbx.FormattingEnabled = true;
            this.hr_cbx.Items.AddRange(new object[] {
            "默认值",
            "全部",
            "一半",
            "四分之一"});
            this.hr_cbx.Location = new System.Drawing.Point(70, 49);
            this.hr_cbx.Name = "hr_cbx";
            this.hr_cbx.Size = new System.Drawing.Size(158, 20);
            this.hr_cbx.TabIndex = 4;
            this.hr_cbx.SelectedIndexChanged += new System.EventHandler(this.hr_cbx_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "分辨率";
            // 
            // cameraName_cbx
            // 
            this.cameraName_cbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cameraName_cbx.FormattingEnabled = true;
            this.cameraName_cbx.Location = new System.Drawing.Point(41, 12);
            this.cameraName_cbx.Name = "cameraName_cbx";
            this.cameraName_cbx.Size = new System.Drawing.Size(772, 20);
            this.cameraName_cbx.TabIndex = 1;
            this.cameraName_cbx.SelectedIndexChanged += new System.EventHandler(this.cameraName_cbx_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "设备";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(824, 517);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "实时";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(680, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(141, 511);
            this.panel2.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(6, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(132, 504);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "设置";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "相机名称：";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.videoControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(677, 511);
            this.panel1.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.camerasetting_statutelable});
            this.statusStrip1.Location = new System.Drawing.Point(0, 590);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(870, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // camerasetting_statutelable
            // 
            this.camerasetting_statutelable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.camerasetting_statutelable.Name = "camerasetting_statutelable";
            this.camerasetting_statutelable.Size = new System.Drawing.Size(0, 17);
            // 
            // videoControl1
            // 
            this.videoControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.videoControl1.GetImage = false;
            this.videoControl1.IdentifyQRCode = false;
            this.videoControl1.Location = new System.Drawing.Point(0, 0);
            this.videoControl1.MatchImage = false;
            this.videoControl1.Name = "videoControl1";
            this.videoControl1.Size = new System.Drawing.Size(677, 511);
            this.videoControl1.TabIndex = 0;
            // 
            // CamSetFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 612);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CamSetFrm";
            this.Text = "CamSetFrm";
            this.Load += new System.EventHandler(this.CamSetFrm_Load);
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cameraName_cbx;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox hr_cbx;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox vr_cbx;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cp_cbx;
        private System.Windows.Forms.Button cameralink_btn;
        private System.Windows.Forms.ComboBox bitper_cbx;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button cameragrab_btn;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel camerasetting_statutelable;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button reset_btn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private VideoControl videoControl1;
    }
}