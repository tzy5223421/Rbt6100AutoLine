using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbt6100AutoLine.Controls
{
    public class Camera_Paramter
    {
        private string cameraName;
        private ColorSpace cameraColorSpace;
        private HorizontalResolution cameraHorizontalResolution;
        private VerticalResolution cameraVertcialResolution;
        private string cameraBitPerChannel;
        private string suggestion;
        public string CameraName
        {
            get { return cameraName; }
            set { this.cameraName = value; }
        }
        public ColorSpace CameraColorSpace
        {
            get
            {
                return cameraColorSpace;
            }
            set { this.cameraColorSpace = value; }
        }
        public HorizontalResolution CameraHorizontalResolution
        {
            get { return cameraHorizontalResolution; }
            set { this.cameraHorizontalResolution = value; }
        }
        public VerticalResolution CameraVerticalResolution
        {
            get { return cameraVertcialResolution; }
            set { this.cameraVertcialResolution = value; }
        }
        public string CameraBitPerChannel
        {
            get { return cameraBitPerChannel; }
            set { this.cameraBitPerChannel = value; }
        }
        public string CameraSuggestion
        {
            get { return suggestion; }
            set { this.suggestion = value; }
        }
    }
    public enum ColorSpace
    {
        default_value = 0,
        gray = 1,
        raw = 2,
        rgb = 3,
        yuv = 4,
    }
    public enum HorizontalResolution
    {
        default_value = 0,
        Full_resolution = 1,
        Half_resolution = 2,
        Quarter_resolution = 4,
    }
    public enum VerticalResolution
    {
        default_value = 0,
        Full_resolution = 1,
        Half_resolution = 2,
        Quarter_resolution = 4,
    }
}
