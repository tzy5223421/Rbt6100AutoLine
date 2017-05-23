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
    public partial class ProcessControl : UserControl
    {
        bool isOndraw = false;
        Size InitSize;

        public ProcessControl()
        {
            InitializeComponent();
            //MultipleAssembleX = (double)(this.Size.Width) / (double)(Assembling_Light.Location.X);
            //MultipleAssembleY = (double)this.Size.Height / (double)(Assembling_Light.Location.Y);

            //MultipleFeedX = (double)(this.Size.Width) / (double)(FeedLight.Location.X);
            //MultipleFeedY = (double)(this.Size.Height) / (double)(FeedLight.Location.Y);

            //MultipleBaitX = (double)(this.Size.Width) / (double)(Baiting_Light.Location.X);
            //MultipleBaitY = (double)(this.Size.Height) / (double)(Baiting_Light.Location.Y);
            InitSize = this.Size;

        }

        private void ProcessControl_SizeChanged(object sender, EventArgs e)
        {
            Invalidate();
            isOndraw = true;
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            if (isOndraw)
            {
                this.Size = new Size(InitSize.Width, InitSize.Height);
                isOndraw = false;
            }
            base.OnPaint(e);

        }
    }
}
