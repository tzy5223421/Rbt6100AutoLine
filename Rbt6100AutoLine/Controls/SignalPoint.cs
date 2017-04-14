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
    public partial class SignalPoint : UserControl
    {
        private Color _inbackcolor = Color.Green;
        private Color _outbackcolor = Color.Red;
        private bool _signal = false;
        private int _diameter = 15;
        public int Diameter
        {
            get { return _diameter; }
            set
            {
                _diameter = value;
                Invalidate();
            }
        }
        public Color InBackColor
        {
            get { return _inbackcolor; }
            set
            {
                _inbackcolor = value;
                Invalidate();
            }
        }
        public Color OutBackColor
        {
            get { return _outbackcolor; }
            set
            {
                _outbackcolor = value;
                Invalidate();
            }
        }
        public bool SingalIn
        {
            get { return _signal; }
            set
            {
                _signal = value;
                Invalidate();
            }
        }

        public SignalPoint()
        {
            InitializeComponent();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            // OnDrawCircle(_diameter);
            if (_signal) //有信号输入
            {
                this.Size = new Size(_diameter + 1, _diameter + 1);
                Graphics g = this.CreateGraphics();
                Rectangle rect = this.ClientRectangle;
                rect = new Rectangle(0, 0, _diameter, _diameter);
                Pen p = new Pen(_inbackcolor);
                g.DrawEllipse(p, rect);
                Brush b = new SolidBrush(_inbackcolor);
                g.FillEllipse(b, rect);
            }
            else
            {
                this.Size = new Size(_diameter + 1, _diameter + 1);
                Graphics g = this.CreateGraphics();
                Rectangle rect = this.ClientRectangle;
                rect = new Rectangle(0, 0, _diameter, _diameter);
                Pen p = new Pen(_outbackcolor);
                g.DrawEllipse(p, rect);
                Brush b = new SolidBrush(_outbackcolor);
                g.FillEllipse(b, rect);
            }
            base.OnPaint(e);
        }
    }
}
