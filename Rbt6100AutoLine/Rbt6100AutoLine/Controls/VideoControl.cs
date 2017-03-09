using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HalconDotNet;

namespace Rbt6100AutoLine
{
    public partial class VideoControl : UserControl
    {
        private string Cam = null;
        public HTuple hv_ExpDefaultWinHandle;
        public VideoControl()
        {
            InitializeComponent();
        }
        public VideoControl(string cam)
        {
            this.Cam = cam;
        }

        private void halconBkg_DoWork(object sender, DoWorkEventArgs e)
        {
            HObject ho_Image = null;
            HTuple hv_AcqCam = null;
            HOperatorSet.GenEmptyObj(out ho_Image);
            HOperatorSet.OpenFramegrabber("GigEVision", 0, 0, 0, 0, 0, 0, "default", -1,
         "default", -1, "false", "default", "000748dcdbab_TheImagingSourceEuropeGmbH_DFK33G4",
         0, -1, out hv_AcqCam);
            HOperatorSet.GrabImageStart(hv_AcqCam, -1);
            while (true)
            {
                ho_Image.Dispose();
                HOperatorSet.GrabImageAsync(out ho_Image, hv_AcqCam, -1);
                HOperatorSet.DispImage(ho_Image, this.hWindowControl1.HalconWindow);
            }
            //   HOperatorSet.CloseFramegrabber(hv_AcqCam);
            //ho_Image.Dispose();
        }
        public void RunCamera()
        {
            halconBkg.RunWorkerAsync();
        }
    }
}
