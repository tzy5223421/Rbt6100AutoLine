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
    public partial class Indicator_light : UserControl
    {
        public Indicator_light()
        {
            InitializeComponent();
        }
        private Image _redbackImage = Rbt6100AutoLine.Controls.Properties.Resources.red_Light;

        private Image _greenbackImage = Rbt6100AutoLine.Controls.Properties.Resources.green_Light;
        //public abstract class backimage
        //{
        //    public abstract Image GreenLight
        //    {
        //        get;
        //    }
        //    public abstract Image RedLight
        //    {
        //        get;
        //    }
        //}
        //public class ibackImage : backimage
        //{
        //    public override Image GreenLight
        //    {
        //        get
        //        {
        //            //  throw new NotImplementedException();
        //            //    return Properties.Resources.green_Light;
        //            return Rbt6100AutoLine.Controls.Properties.Resources.green_Light;
        //        }
        //    }
        //    public override Image RedLight
        //    {
        //        get
        //        {
        //            return Rbt6100AutoLine.Controls.Properties.Resources.red_Light;
        //        }
        //    }
        //}
        public void OnGreenLight()
        {
            this.BackgroundImage = _greenbackImage;
        }
        public void OnRedLight()
        {
            this.BackgroundImage = _redbackImage;
        }

        private void Indicator_light_SizeChanged(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}
