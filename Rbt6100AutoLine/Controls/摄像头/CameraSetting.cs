using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HalconDotNet;
namespace Rbt6100AutoLine.Controls
{
    public delegate void CameraErrorMessage(string text);
    public class CameraSetting
    {
        public event CameraErrorMessage camerErrorMessage;

        /// <summary>
        /// 获取相机信息
        /// </summary>
        /// <returns></returns>
        public string[] GetCameraInfo_GigEVision()
        {
            HTuple hv_callfunction = null, hv_CameraInfo = null;
            HOperatorSet.InfoFramegrabber("GigEVision", "info_boards", out hv_callfunction, out hv_CameraInfo);
            return hv_CameraInfo;
        }

        /// <summary>
        /// 获取所有连接相机的名字
        /// </summary>
        /// <returns></returns>
        public string[] GetCameraName_GigEVision()
        {
            HTuple hv_callfunction = null, hv_CameraName = null;
            HOperatorSet.InfoFramegrabber("GigEVision", "device", out hv_callfunction, out hv_CameraName);
            return hv_CameraName;
        }

        /// <summary>
        /// 获取相机默认值
        /// </summary>
        /// <returns></returns>
        public string GetCameraDefaultValue_GigEVision()
        {
            HTuple hv_callfunction = null, hv_CameraDefaultValue = null;
            HOperatorSet.InfoFramegrabber("GigEVision", "defaults", out hv_callfunction, out hv_CameraDefaultValue);
            return hv_CameraDefaultValue.ToString();
        }

        /// <summary>
        /// 打开相机
        /// </summary>
        /// <param name=相机名称></param>
		/// <param HorizontalResolution=水平分辨率></param>
		/// <param VerticalResolution=垂直分辨率></param>
		/// <param bitperChannel=位深></param>
		/// <param ColorSpace=颜色空间></param>
        /// <returns>HTuple hv_AcqCam</returns>
        public bool OpenCamera(string name, int HorizontalResolution, int VerticalResolution, int bitperChannel, string ColorSpace, out HTuple hv_AcqCam)
        {
            //  HTuple hv_callfunction = null;
            hv_AcqCam = null;
            try
            {
                HOperatorSet.OpenFramegrabber("GigeVision", HorizontalResolution, VerticalResolution, 0, 0, 0, 0, "default", bitperChannel,
ColorSpace, -1, "false", "default", name, 0, -1, out hv_AcqCam);

                return true;
            }
            catch (HalconException ex)
            {
                camerErrorMessage(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 获取对应设备当前的IP地址
        /// </summary>
        /// <param hv_AcqCam="连接句柄"></param>
        /// <returns>hv_CameraIP</returns>
        public string GetGtlCurrentIPAddress(HTuple hv_AcqCam)
        {
            HTuple hv_CameraIP = null;
            //    HTuple hv_AcqCam = null;
            HOperatorSet.GetFramegrabberParam(hv_AcqCam, "GtlCurrentIPAddress", out hv_CameraIP);
            //    HOperatorSet.CloseFramegrabber(hv_AcqCam);
            return hv_CameraIP;
        }

        /// <summary>
        /// 获取采集超时时间，单位MS
        /// </summary>
        /// <param hv_AcqCam="连接句柄"></param>
        /// <returns></returns>
        public int GetGrabTimeOut(HTuple hv_AcqCam)
        {
            HTuple hv_GrabTimeOut = null;
            HOperatorSet.GetFramegrabberParam(hv_AcqCam, "grab_timeout", out hv_GrabTimeOut);
            return (int)(new HTuple(hv_GrabTimeOut));
        }

        /// <summary>
        /// 获取所需图像宽度(0,代表完整图像)
        /// </summary>
        /// <param hv_AcqCam="连接句柄"></param>
        /// <returns></returns>
        public int GetImagePartWidth(HTuple hv_AcqCam)
        {
            HTuple hv_ImageWidth = null;
            HOperatorSet.GetFramegrabberParam(hv_AcqCam, "image_width", out hv_ImageWidth);
            return (int)(new HTuple(hv_ImageWidth));
        }

        /// <summary>
        /// 获取所需图像高度(0,代表完整图像)
        /// </summary>
        /// <param name="hv_AcqCam"></param>
        /// <returns></returns>
        public int GetImagePartHeight(HTuple hv_AcqCam)
        {
            HTuple hv_ImageHeight = null;
            HOperatorSet.GetFramegrabberParam(hv_AcqCam, "image_height", out hv_ImageHeight);
            return (int)(new HTuple(hv_ImageHeight));
        }

        /// <summary>
        /// 设置相机当前IP地址
        /// </summary>
        /// <param name="相机句柄"></param>
        /// <param name="IP值"></param>
        public void SetGevCurrentIPAddress(HTuple hv_AcqCam, string value)
        {
            HOperatorSet.SetFramegrabberParam(hv_AcqCam, "GevCurrentIPConfigurationDHCP", 1);
        }

        /// <summary>
        ///设置相机采集超时时间，单位ms
        /// </summary>
        /// <param name="hv_AcqCam"></param>
        /// <param name="value"></param>
        public void SetGrabTimeOut(HTuple hv_AcqCam, string value)
        {
            HOperatorSet.SetFramegrabberParam(hv_AcqCam, "grab_timeout", value);
        }

        /// <summary>
        /// 关闭相机
        /// </summary>
        /// <param name="相机句柄"></param>
        public bool CloseCamera(HTuple hv_AcqCam)
        {
            try
            {
                HOperatorSet.CloseFramegrabber(hv_AcqCam);
                return true;
            }
            catch (HalconException ex)
            {
                return false;
            }
        }
    }
}
