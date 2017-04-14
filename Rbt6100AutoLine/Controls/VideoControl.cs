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

namespace Rbt6100AutoLine.Controls
{
    public partial class VideoControl : UserControl
    {
        private CameraName Camera;
        HTuple hv_AcqCam = null;
        public VideoControl()
        {
            InitializeComponent();
        }
        public VideoControl(CameraName Camera)
        {
            this.Camera = Camera;
        }

        private void halconBkg_DoWork(object sender, DoWorkEventArgs e)
        {
            HObject ho_Image = null;
            HTuple hv_AcqCam = null;
            HOperatorSet.GenEmptyObj(out ho_Image);
            HOperatorSet.OpenFramegrabber("GigEVision", 0, 0, 0, 0, 0, 0, "default", -1,
         "default", -1, "false", "default", Camera.ToString(),
         0, -1, out hv_AcqCam);
            HOperatorSet.GrabImageStart(hv_AcqCam, -1);
            while (true)
            {
                ho_Image.Dispose();
                HOperatorSet.GrabImageAsync(out ho_Image, hv_AcqCam, -1);
                HOperatorSet.DispColor(ho_Image, this.hWindowControl1.HalconWindow);
            }
            //   HOperatorSet.CloseFramegrabber(hv_AcqCam);
            //ho_Image.Dispose();
        }
        public void GrabImageAsync()
        {
            halconBkg.RunWorkerAsync();
        }
        public void GrabImage()
        {
            HObject ho_Image = null;
            // HTuple hv_AcqCam = null;
            HOperatorSet.GenEmptyObj(out ho_Image);
            HOperatorSet.OpenFramegrabber("GigEVision", 0, 0, 0, 0, 0, 0, "default", -1,
   "default", -1, "false", "default", Camera.ToString(),
   0, -1, out hv_AcqCam);
            HOperatorSet.GrabImageAsync(out ho_Image, hv_AcqCam, -1);
            HOperatorSet.DispColor(ho_Image, this.hWindowControl1.HalconWindow);
            //HOperatorSet.CloseFramegrabber(hv_AcqCam);
        }
        ~VideoControl()
        {
            halconBkg.CancelAsync();
            HOperatorSet.CloseFramegrabber(this.hWindowControl1.HalconWindow);
        }
    }
    public enum CameraName
    {
        [Description("上料处相机")]
        FeedingCam = 1,
        [Description("装配处相机")]
        AssemblingCam = 2,
        [Description("拧螺丝处相机")]
        ScrewCam = 3,
        [Description("下料处相机")]
        PalletizingCam = 4,

    }
}
