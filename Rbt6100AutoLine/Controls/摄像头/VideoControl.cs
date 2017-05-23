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
    public delegate void ImageEvent(object sender, object type);
    public partial class VideoControl : UserControl
    {
        HTuple hv_AcqCam = null;
        private bool isGetImage = false;
        private bool isMatch = false;
        private bool isIdentifyQRCode = false;
        public EventHandler ImageEventHandler = null;
        public ImageEvent imageEvent;
        public VideoControl()
        {
            InitializeComponent();
        }
        public void GetHanlder(HTuple hv_AcqCam)
        {
            this.hv_AcqCam = hv_AcqCam;
        }

        public bool GetImage
        {
            get { return isGetImage; }
            set { isGetImage = value; }
        }

        public bool MatchImage
        {
            get { return isMatch; }
            set { isMatch = value; }
        }
        public bool IdentifyQRCode
        {
            get { return isIdentifyQRCode; }
            set { isIdentifyQRCode = value; }
        }


        private void halconBkg_DoWork(object sender, DoWorkEventArgs e)
        {
            HObject ho_Image = null;
            HTuple hv_Pointer = null, hv_Type = null, hv_Width = null, hv_Height = null;
            HOperatorSet.GenEmptyObj(out ho_Image);
            HOperatorSet.GrabImageStart(hv_AcqCam, -1);
            HOperatorSet.GetImagePointer1(ho_Image, out hv_Pointer, out hv_Type, out hv_Width,
       out hv_Height);
            try
            {
                while (!halconBkg.CancellationPending)
                {
                    ho_Image.Dispose();
                    HOperatorSet.GrabImageAsync(out ho_Image, hv_AcqCam, -1);
                    HOperatorSet.DispColor(ho_Image, this.hWindowControl1.HalconWindow);
                    if (IdentifyQRCode)
                    {
                        // e.Result = 2;
                        isIdentifyQRCode = false;
                        HOperatorSet.GrabImage(out ho_Image, hv_AcqCam);
                        imageEvent(ho_Image, 2);
                    }
                    if (GetImage)
                    {
                        //   e.Result = 0;
                        GetImage = false;
                        HOperatorSet.GrabImage(out ho_Image, hv_AcqCam);
                        imageEvent(ho_Image, 0);
                    }
                    if (MatchImage)
                    {
                        //HObject ho_ModelAtNewPosition;
                        //HTuple hv_Score = null;
                        ////     MatchCircle.FindCircle(ho_Image, out ho_ModelAtNewPosition, out hv_Score);
                        ////   e.Result = 1;
                        //MatchImage = false;
                        //imageEvent(hv_Score, 1);
                    }
                }
            }
            catch (HalconException halex)
            {
                Console.WriteLine(halex.Message);
            }
        }
        public void GrabImageAsync()
        {
            halconBkg.RunWorkerAsync();
        }
        public void StopGrabImage()
        {
            halconBkg.CancelAsync();
        }
        /*  public void GrabImage()
          {
              HObject ho_Image = null;
              HTuple hv_AcqCam = null;
              HOperatorSet.GenEmptyObj(out ho_Image);
              HOperatorSet.OpenFramegrabber("GigEVision", 0, 0, 0, 0, 0, 0, "default", -1,
      "default", -1, "false", "default", "000748dcdbab_TheImagingSourceEuropeGmbH_DFK33G4",
      0, -1, out hv_AcqCam);
              HOperatorSet.GrabImageAsync(out ho_Image, hv_AcqCam, -1);
              HOperatorSet.DispColor(ho_Image, this.hWindowControl1.HalconWindow);
              HObject ho_ModelAtNewPosition;
              HTuple hv_Score;
              MatchCircle.FindCircle(ho_Image, out ho_ModelAtNewPosition, out hv_Score);
              HOperatorSet.SetColor(this.hWindowControl1.HalconWindow, "red");
              HOperatorSet.DispObj(ho_ModelAtNewPosition, this.hWindowControl1.HalconWindow);
              //   HOperatorSet.DispColor(ho_ModelAtNewPosition, this.hWindowControl1.HalconWindow);
              HOperatorSet.CloseFramegrabber(hv_AcqCam);
              MessageBox.Show((Convert.ToString((int)(new HTuple(hv_Score.TupleLength())))));
          }*/
        ~VideoControl()
        {
            halconBkg.CancelAsync();
            //  HOperatorSet.CloseFramegrabber(this.hWindowControl1.HalconWindow);
        }
    }
}
