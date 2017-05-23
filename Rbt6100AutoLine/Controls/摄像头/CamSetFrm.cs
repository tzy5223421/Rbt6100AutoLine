using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rbt6100AutoLine;
using HalconDotNet;

namespace Rbt6100AutoLine.Controls
{
    public partial class CamSetFrm : Form
    {
        CameraSetting cs;
        private List<Camera_Paramter> CameraParamterList = new List<Camera_Paramter>();
        private string colorspace;
        private int horizontalResolution;
        private int verticalResolution;
        private int bitperChannel = -1;
        private string ChoseCameraName = null;
        private HTuple hv_AcqCam = null;
        private bool CameraLink = false;
        public CamSetFrm()
        {
            InitializeComponent();
            this.videoControl1.imageEvent += new ImageEvent(VideoControl_Image);
        }

        private void CamSetFrm_Load(object sender, EventArgs e)
        {
            cs = new CameraSetting();
            cs.camerErrorMessage += Cs_camerErrorMessage;
            //   cs.GetCameraName_GigEVision();
            string[] info = cs.GetCameraInfo_GigEVision();
            GetDeviceName(info);
            if (CameraParamterList != null)
            {
                if (CameraParamterList.Count != 0)
                {
                    for (int i = 0; i < CameraParamterList.Count; i++)
                    {
                        cameraName_cbx.Items.Add(CameraParamterList[i].CameraName);
                    }
                    cameraName_cbx.SelectedIndex = 0;
                }
            }
            string[] defaultvalue = cs.GetCameraDefaultValue_GigEVision().Split(',');
            DefaultValueDeal(defaultvalue);
        }

        public void VideoControl_Image(object sender, object e)
        {
            if ((int)e == 0)
            {
                this.Invoke(new Action(() =>
                {
                    HObject ho_Image = (HObject)sender;
                    Form frm = new Form();
                    HTuple hv_Width = null, hv_Height = null, hv_Type = null, hv_Pointer = null;
                    HOperatorSet.GetImagePointer1(ho_Image, out hv_Pointer, out hv_Type, out hv_Width, out hv_Height);
                    frm.Width = new HTuple(hv_Width);
                    frm.Height = hv_Height;
                    HWindowControl hw = new HWindowControl();
                    hw.Dock = DockStyle.Fill;
                    hw.ImagePart = new Rectangle(0, 0, hv_Width, hv_Height);
                    hw.Width = hv_Width;
                    hw.Height = hv_Height;
                    frm.Controls.Add(hw);
                    frm.Show();
                    HOperatorSet.DispColor(ho_Image, hw.HalconWindow);
                }));
            }
        }

        private void Cs_camerErrorMessage(string text)
        {
            // throw new NotImplementedException();
            this.Invoke(new Action(() => { camerasetting_statutelable.Text = text; }));
        }

        private void GetDeviceName(string[] device)
        {
            string[] devicename = new string[device.Length];
            for (int i = 0; i < device.Length; i++)
            {
                string[] str = device[i].Split('|');
                Camera_Paramter cameraParameter = new Camera_Paramter();
                for (int j = 0; j < str.Length; j++)
                {
                    string[] cameraInfo = str[j].Split(':');
                    if (cameraInfo[0] == " device")
                    {
                        cameraParameter.CameraName = cameraInfo[1].Trim();
                    }
                    if (cameraInfo[0] == " suggestion")
                    {
                        cameraParameter.CameraSuggestion = cameraInfo[1].Trim();
                    }
                }
                CameraParamterList.Add(cameraParameter);
            }
        }

        private void DefaultValueDeal(string[] defaultvalue)
        {
            if (defaultvalue[0].Equals("[0") | defaultvalue[0].Equals("[1"))
            {
                hr_cbx.SelectedIndex = (int)(HorizontalResolution.default_value);
            }
            if (defaultvalue[0].Equals("[2"))
            {
                hr_cbx.SelectedIndex = (int)(HorizontalResolution.Half_resolution);
            }
            if (defaultvalue[0].Equals("[4"))
            {
                hr_cbx.SelectedIndex = (int)(HorizontalResolution.Quarter_resolution) - 1;
            }
            if (defaultvalue[1].Equals(" 0") | defaultvalue[1].Equals(" 1"))
            {
                vr_cbx.SelectedIndex = (int)VerticalResolution.default_value;
            }
            if (defaultvalue[1].Equals(" 2"))
            {
                vr_cbx.SelectedIndex = (int)VerticalResolution.Half_resolution;
            }
            if (defaultvalue[1].Equals(" 4"))
            {
                vr_cbx.SelectedIndex = (int)VerticalResolution.Quarter_resolution - 1;
            }
            if (defaultvalue[8].Equals(" \"default\""))
            {
                cp_cbx.SelectedIndex = (int)(ColorSpace.default_value);
            }
            if (defaultvalue[8].Equals(" \"gray\""))
            {
                cp_cbx.SelectedIndex = (int)(ColorSpace.gray);
            }
            if (defaultvalue[8].Equals(" \"raw\""))
            {
                cp_cbx.SelectedIndex = (int)(ColorSpace.raw);
            }
            if (defaultvalue[8].Equals(" \"rgb\""))
            {
                cp_cbx.SelectedIndex = (int)ColorSpace.rgb;
            }
            if (defaultvalue[8].Equals(" \"yuv\""))
            {
                cp_cbx.SelectedIndex = (int)ColorSpace.yuv;
            }
            if (defaultvalue[7].Equals(" -1"))
            {
                bitper_cbx.SelectedIndex = 0;
            }
            if (defaultvalue[7].Equals(" 8"))
            {
                bitper_cbx.SelectedIndex = 1;
            }
            if (defaultvalue[7].Equals(" 10"))
            {
                bitper_cbx.SelectedIndex = 2;
            }
            if (defaultvalue[7].Equals(" 12"))
            {
                bitper_cbx.SelectedIndex = 3;
            }
            if (defaultvalue[7].Equals(" 14"))
            {
                bitper_cbx.SelectedIndex = 4;
            }
            if (defaultvalue[7].Equals(" 16"))
            {
                bitper_cbx.SelectedIndex = 5;
            }
        }

        private void cameraName_cbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChoseCameraName = CameraParamterList[cameraName_cbx.SelectedIndex].CameraName;
            if (CameraParamterList != null)
            {
                if (CameraLink)
                {
                    cameralink_btn_Click(sender, e);
                }
            }
        }
        // public HTuple 
        private void cameralink_btn_Click(object sender, EventArgs e)
        {
            if (cameralink_btn.Text.Equals("连接"))
            {
                CameraLink = cs.OpenCamera(ChoseCameraName, (int)horizontalResolution, (int)verticalResolution, bitperChannel, colorspace.ToString(), out hv_AcqCam);
                if (CameraLink)
                {
                    cameralink_btn.Text = "断开";
                    this.Invoke(new Action(() => { camerasetting_statutelable.Text = null; }));
                }
            }
            else
            {
                if (cs.CloseCamera(hv_AcqCam))
                {
                    cameralink_btn.Text = "连接";
                    cameragrab_btn.Text = "实时";
                    CameraLink = false;
                    hv_AcqCam = null;
                }
            }
        }

        private void hr_cbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (hr_cbx.SelectedIndex == 0)
            {
                horizontalResolution = (int)HorizontalResolution.default_value;
            }
            if (hr_cbx.SelectedIndex == 1)
            {
                horizontalResolution = (int)HorizontalResolution.Full_resolution;
            }
            if (hr_cbx.SelectedIndex == 2)
            {
                horizontalResolution = (int)HorizontalResolution.Half_resolution;
            }
            if (hr_cbx.SelectedIndex == 3)
            {
                horizontalResolution = (int)HorizontalResolution.Quarter_resolution;
            }
        }

        private void vr_cbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (vr_cbx.SelectedIndex == 0)
            {
                verticalResolution = (int)VerticalResolution.default_value;
            }
            if (vr_cbx.SelectedIndex == 1)
            {
                verticalResolution = (int)VerticalResolution.Full_resolution;
            }
            if (vr_cbx.SelectedIndex == 2)
            {
                verticalResolution = (int)VerticalResolution.Half_resolution;
            }
            if (vr_cbx.SelectedIndex == 3)
            {
                verticalResolution = (int)VerticalResolution.Quarter_resolution;
            }
        }

        private void cp_cbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cp_cbx.SelectedIndex == 0)
            {
                colorspace = "default";
            }
            if (cp_cbx.SelectedIndex == 1)
            {
                colorspace = ColorSpace.gray.ToString();
            }
            if (cp_cbx.SelectedIndex == 2)
            {
                colorspace = ColorSpace.raw.ToString();
            }
            if (cp_cbx.SelectedIndex == 3)
            {
                colorspace = ColorSpace.rgb.ToString();
            }
            if (cp_cbx.SelectedIndex == 4)
            {
                colorspace = ColorSpace.yuv.ToString();
            }
        }

        private void bitper_cbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bitper_cbx.SelectedIndex == 0)
            {
                bitperChannel = -1;
            }
            if (bitper_cbx.SelectedIndex == 1)
            {
                bitperChannel = 8;
            }
            if (bitper_cbx.SelectedIndex == 2)
            {
                bitperChannel = 10;
            }
            if (bitper_cbx.SelectedIndex == 3)
            {
                bitperChannel = 12;
            }
            if (bitper_cbx.SelectedIndex == 4)
            {
                bitperChannel = 14;
            }
            if (bitper_cbx.SelectedIndex == 5)
            {
                bitperChannel = 16;
            }
        }

        private void cameragrab_btn_Click(object sender, EventArgs e)
        {
            if (cameragrab_btn.Text.Equals("实时"))
            {

                if (!CameraLink)
                {
                    //  CameraLink = cs.OpenCamera(ChoseCameraName, (int)horizontalResolution, (int)verticalResolution, bitperChannel, colorspace.ToString(), out hv_AcqCam);
                    cameralink_btn_Click(sender, e);
                }
                // this.cameralink_btn.Text = "断开";
                this.videoControl1.GetHanlder(hv_AcqCam);
                this.videoControl1.GrabImageAsync();
                cameragrab_btn.Text = "停止";
            }
            else
            {
                cameralink_btn_Click(sender, e);
                this.videoControl1.StopGrabImage();
                hv_AcqCam = null;
                this.cameragrab_btn.Text = "实时";

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CameraLink)
            {
                videoControl1.GetImage = true;
            }
        }
    }
}
