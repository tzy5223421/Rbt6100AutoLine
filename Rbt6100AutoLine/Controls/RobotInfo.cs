using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rbt6100AutoLine.Controls
{
    public partial class RobotInfo : UserControl
    {
        private Size initSize;
        private Size stretchSize;
        private Panel[] panelgroup = new Panel[3];
        private Boolean onDraw = false;
        /// <summary>
        /// 上料环节警告文本
        /// </summary>
        /// <param name="text"></param>
        public void WarnFmbText(string text)
        {
            this.Invoke(new Action(() =>
            {
                fm_rbx.SelectionColor = Color.Yellow;
                fm_rbx.AppendText(DateTime.Now + ":" + text);
            }));
        }
        /// <summary>
        /// 上料环节信息文本
        /// </summary>
        /// <param name="text"></param>
        public void InfoFmbText(string text)
        {
            this.Invoke(new Action(() =>
            {
                fm_rbx.SelectionColor = Color.Black;
                fm_rbx.AppendText(DateTime.Now + ":" + text);
            }));
        }
        /// <summary>
        /// 上料环节错误文本
        /// </summary>
        /// <param name="text"></param>
        public void ErrorFmbText(string text)
        {
            this.Invoke(new Action(() =>
            {
                fm_rbx.SelectionColor = Color.Red;
                fm_rbx.AppendText(DateTime.Now + ":" + text);
            }));
        }
        /// <summary>
        /// 装配环节警告文本
        /// </summary>
        /// <param name="text"></param>
        public void WarnMtbText(string text)
        {
            this.Invoke(new Action(() =>
            {
                mt_rbx.SelectionColor = Color.Yellow;
                mt_rbx.AppendText(DateTime.Now + ":" + text);
            }));
        }
        /// <summary>
        /// 装配环节信息文本
        /// </summary>
        /// <param name="text"></param>
        public void InfoMtbText(string text)
        {
            this.Invoke(new Action(() =>
            {
                mt_rbx.SelectionColor = Color.Black;
                mt_rbx.AppendText(DateTime.Now + ":" + text);
            }));
        }
        /// <summary>
        /// 装配环节错误文本
        /// </summary>
        /// <param name="text"></param>
        public void ErrorMtbText(string text)
        {
            this.Invoke(new Action(() =>
            {
                mt_rbx.SelectionColor = Color.Red;
                mt_rbx.AppendText(DateTime.Now + ":" + text);
            }));
        }
        /// <summary>
        /// 下料环节警告文本
        /// </summary>
        /// <param name="text"></param>
        public void WarnRbbText(string text)
        {
            this.Invoke(new Action(() =>
            {
                rb_rbx.SelectionColor = Color.Yellow;
                rb_rbx.AppendText(DateTime.Now + ":" + text);
            }));
        }
        /// <summary>
        /// 下料环节信息文本
        /// </summary>
        /// <param name="text"></param>
        public void InfoRbbText(string text)
        {
            this.Invoke(new Action(() =>
            {
                rb_rbx.SelectionColor = Color.Black;
                rb_rbx.AppendText(DateTime.Now + ":" + text);
            }));
        }
        /// <summary>
        /// 下料环节错误文本
        /// </summary>
        /// <param name="text"></param>
        public void ErrorRbbText(string text)
        {
            this.Invoke(new Action(() =>
            {
                rb_rbx.SelectionBackColor = Color.Red;
                rb_rbx.AppendText(DateTime.Now + ":" + text);
            }));
        }

        public void ClearText()
        {
            this.Invoke(new Action(() =>
            {
                fm_rbx.Clear();
                rb_rbx.Clear();
                mt_rbx.Clear();
            }));
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public RobotInfo()
        {
            InitializeComponent();
            initSize = this.Size;
            panelgroup[0] = panel1;
            panelgroup[1] = panel2;
            panelgroup[2] = panel3;
            for (int i = 0; i < 3; i++)
            {
                // panelgroup[i].Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                ////    panelgroup[2].Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                //   panelgroup[i].AutoScroll = true;
            }
        }

        public Size[] GetPanelSize()
        {
            Size[] size = new Size[3];
            for (int i = 0; i < 3; i++)
            {
                size[i] = panelgroup[i].Size;
            }
            return size;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (onDraw)
            {
                onDraw = false;
                if (initSize != null && stretchSize != null)
                {
                    Size decSize = stretchSize - initSize;
                    initSize = stretchSize;
                    if (decSize.Height > 0)
                    {
                        int stretchHeight = (int)(decSize.Height / 3);
                        for (int i = 0; i < panelgroup.Length; i++)
                        {
                            panelgroup[i].Size = new Size(panelgroup[i].Size.Width, panelgroup[i].Size.Height + stretchHeight);
                            //if (i > 0 && i < 2)
                            //{
                            //    panelgroup[i].Location = new Point(panelgroup[i].Location.X, panelgroup[i].Location.Y + stretchHeight);
                            //}
                            //if (i == 2)
                            //{
                            //    panelgroup[i].Location = new Point(panelgroup[i].Location.X, panelgroup[i].Location.Y + stretchHeight * 2);
                            //}
                        }
                    }
                    else if (decSize.Height < 0)
                    {
                        int stretchHeight = (int)(decSize.Height / 3);
                        for (int i = 0; i < 3; i++)
                        {
                            panelgroup[i].Size = new Size(panelgroup[i].Size.Width, panelgroup[i].Size.Height + stretchHeight);
                            //if (i > 0 && i < 2)
                            //{
                            //    panelgroup[i].Location = new Point(panelgroup[i].Location.X, panelgroup[i].Location.Y + stretchHeight);
                            //}
                            //if (i == 2)
                            //{
                            //    panelgroup[i].Location = new Point(panelgroup[i].Location.X, panelgroup[i].Location.Y + stretchHeight * 2);
                            //}
                        }
                    }
                }
            }
        }

        private void panel4_SizeChanged(object sender, EventArgs e)
        {
            if (!onDraw)
            {
                onDraw = true;
                stretchSize = this.Size;
                this.Invalidate();
            }
        }

        private void RobotInfo_SizeChanged(object sender, EventArgs e)
        {
            if (!onDraw)
            {
                onDraw = true;
                stretchSize = this.Size;
                this.Invalidate();
            }
        }
    }
}
