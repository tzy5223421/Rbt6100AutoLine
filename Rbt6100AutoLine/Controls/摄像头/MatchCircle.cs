using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HalconDotNet;

namespace Rbt6100AutoLine.Controls
{
    public class MatchCircle
    {
        /***************************************************************/
        //函数说明
        //GenEllipseContourXld(out HObject contEllipse, HTuple row, HTuple column, HTuple phi, HTuple radius1, HTuple radius2, HTuple startPhi, HTuple endPhi, HTuple pointOrder, HTuple resolution);
        //
        // 摘要:
        //     根据相应的椭圆弧创建一个XLD轮廓(contour)
        //
        // 参数:
        //   contEllipse:
        //     产生的轮廓
        //
        //   row:
        //     椭圆的中心行坐标. Default: 200.0
        //
        //   column:
        //    椭圆的中心列坐标. Default: 200.0
        //
        //   phi:
        //    取向的主要轴角度(rad). Default: 0.0
        //
        //   radius1:
        //     长度较大的半轴. Default: 100.0
        //
        //   radius2:
        //    长度较小的半轴. Default: 50.0
        //
        //   startPhi:
        //    最小圆的始脚 [rad]. Default: 0.0
        //
        //   endPhi:
        //     最小圆的结束角度 [rad]. Default: 6.28318
        //
        //   pointOrder:
        //     沿着边界点的顺序。 Default: "positive"
        //
        //   resolution:
        //     Resolution: 相邻等高线之间的最大距离点. Default: 1.5
        //
        // GenImageConst(out HObject image, HTuple type, HTuple width, HTuple height);
        //
        // 摘要:
        //     创建一个固定灰度值的图像
        //
        // 参数:
        //   image:
        //     创建图像的新图像矩阵。
        //
        //   type:
        //     像素类型. Default: "byte"
        //
        //   width:
        //     图像宽度. Default: 512
        //
        //   height:
        //     图像高度. Default: 512
        //
        // InspectShapeModel(HObject image, out HObject modelImages, out HObject modelRegions, HTuple numLevels, HTuple contrast);
        //
        // 摘要:
        //     创建一个形状的表示模型。
        //
        // 参数:
        //   image:
        //     输入图像.
        //
        //   modelImages:
        //     Image pyramid of the input image
        //
        //   modelRegions:
        //     金字塔模型区域
        //
        //   numLevels:
        //     金字塔的数量水平. Default: 4
        //
        //   contrast:
        //     Threshold or hysteresis thresholds for the contrast of the object in the image
        //     and optionally minimum size of the object parts. Default: 30
        //
        // CreateScaledShapeModel(HObject template, HTuple numLevels, HTuple angleStart, HTuple angleExtent, HTuple angleStep, HTuple scaleMin, HTuple scaleMax, HTuple scaleStep, HTuple optimization, HTuple metric, HTuple contrast, HTuple minContrast, out HTuple modelID);
        //
        // 摘要:
        //    准备规模不变的形状模型匹配。
        //
        // 参数:
        //   template:
        //    输入图像的领域将被用来创建模型。
        //
        //   numLevels:
        //     Maximum number of pyramid levels. Default: "auto"
        //
        //   angleStart:
        //     最小的旋转模式. Default: -0.39
        //
        //   angleExtent:
        //     程度的旋转角度. Default: 0.79
        //
        //   angleStep:
        //    角的步长(分辨率). Default: "auto"
        //
        //   scaleMin:
        //     最小比例模式. Default: 0.9
        //
        //   scaleMax:
        //     最大比例模式. Default: 1.1
        //
        //   scaleStep:
        //     Scale step length (resolution). Default: "auto"
        //
        //   optimization:
        //     Kind of optimization and optionally method used for generating the model. Default:
        //     "auto"
        //
        //   metric:
        //     Match metric. Default: "use_polarity"
        //
        //   contrast:
        //     图像中物体的对比和选中最小部分对象的阈值或者滞后阈值
        //     Default: "auto"
        //
        //   minContrast:
        //     搜索图像中对象的最小比例. Default: "auto"
        //
        //   modelID:
        //    处理后的模型.
        //
        // GetShapeModelContours(out HObject modelContours, HTuple modelID, HTuple level);
        // 
        // 摘要:
        //     Return the contour representation of a shape model.
        //
        // 参数:
        //   modelContours:
        //     返回一个形状的轮廓表示模型。
        //
        //   modelID:
        //    处理后的模型.
        //
        //   level:
        //     Pyramid level for which the contour representation should be returned. Default:
        //     1
        //
        // Rgb1ToGray(HObject RGBImage, out HObject grayImage);
        //
        // 摘要:
        //    将RGB图像转换为灰度图像。
        //
        // 参数:
        //   RGBImage:
        //    三通道RGB图像.
        //
        //   grayImage:
        //     灰度图像.

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ho_Image" 匹配图像></param>
        /// <param name="CircleRadius" 圆直径></param>
        /// <param name="MatchNum" 匹配个数></param>
        /// <param name="minMatchScore" 最小匹配分值></param>
        /// <param name="ho_ModelAtNewPosition" 匹配到的图像所在位置></param>
        /// <param name="hv_Score" 匹配分值输出></param>
        public static void FindCircle(HObject ho_Image, int CircleRadius, int MatchNum, int minMatchScore, out HObject ho_ModelAtNewPosition, out HTuple hv_Score)
        {
            HObject ho_Circle, ho_EmptyImage;
            HObject ho_SyntheticModelImage, ho_ModelImages, ho_ModelRegions;
            HObject ho_ModelContours, ho_SearchImage = null, ho_GrayImage = null;
            //   HObject ho_ModelAtNewPosition = null;

            HTuple hv_Pointer = null;
            HTuple hv_Type = null, hv_Width = null, hv_Height = null;
            HTuple hv_WindowHandle = new HTuple(), hv_RadiusCircle = null;
            HTuple hv_SizeSynthImage = null, hv_WindowHandleSynthetic = new HTuple();
            HTuple hv_ModelID = null, hv_RowCheck = new HTuple();
            HTuple hv_ColumnCheck = new HTuple(), hv_AngleCheck = new HTuple();
            HTuple hv_ScaleCheck = new HTuple();
            hv_Score = new HTuple();
            HTuple hv_j = new HTuple(), hv_MovementOfObject = new HTuple();
            HTuple hv_MoveAndScaleOfObject = new HTuple();
            // Initialize local and output iconic variables 
            //   HOperatorSet.GenEmptyObj(out ho_Image);
            HOperatorSet.GenEmptyObj(out ho_Circle);
            HOperatorSet.GenEmptyObj(out ho_EmptyImage);
            HOperatorSet.GenEmptyObj(out ho_SyntheticModelImage);
            HOperatorSet.GenEmptyObj(out ho_ModelImages);
            HOperatorSet.GenEmptyObj(out ho_ModelRegions);
            HOperatorSet.GenEmptyObj(out ho_ModelContours);
            HOperatorSet.GenEmptyObj(out ho_SearchImage);
            HOperatorSet.GenEmptyObj(out ho_GrayImage);
            HOperatorSet.GenEmptyObj(out ho_ModelAtNewPosition);
            try
            {
                HOperatorSet.GetImagePointer1(ho_Image, out hv_Pointer, out hv_Type, out hv_Width,
            out hv_Height);
                //dev_open_window(...);
                // HOperatorSet.DispObj(ho_Image, hv_ExpDefaultWinHandle);

                //绘制直径为60的圆形,这里可以进行更改
                hv_RadiusCircle = CircleRadius / 2;
                hv_SizeSynthImage = (2 * hv_RadiusCircle) + 10;
                ho_Circle.Dispose();
                //根据相应的椭圆弧创建一个XLD轮廓(contour)
                HOperatorSet.GenEllipseContourXld(out ho_Circle, hv_SizeSynthImage / 2, hv_SizeSynthImage / 2, 0, hv_RadiusCircle, hv_RadiusCircle, 0, 6.28318, "positive", 1.5);
                //  HOperatorSet.SetPart(hv_ExpDefaultWinHandle, 0, 0, hv_SizeSynthImage - 1, hv_SizeSynthImage - 1);
                //创建灰度图像
                ho_EmptyImage.Dispose();
                HOperatorSet.GenImageConst(out ho_EmptyImage, "byte", hv_SizeSynthImage, hv_SizeSynthImage);
                //将XLD以一个恒定的灰度值绘制到Image图像中
                ho_SyntheticModelImage.Dispose();
                HOperatorSet.PaintXld(ho_Circle, ho_EmptyImage, out ho_SyntheticModelImage,
                    128);
                //创建一个轮廓模型的表示
                ho_ModelImages.Dispose(); ho_ModelRegions.Dispose();
                HOperatorSet.InspectShapeModel(ho_SyntheticModelImage, out ho_ModelImages,
                    out ho_ModelRegions, 1, 30);
                // HOperatorSet.SetColor(hv_ExpDefaultWinHandle, "blue");
                //创建一个比例不变的匹配的轮廓模型
                HOperatorSet.CreateScaledShapeModel(ho_SyntheticModelImage, "auto", 0, 0, 0.01,
                    0.8, 1.2, "auto", "none", "use_polarity", 30, 10, out hv_ModelID);
                //返回一个轮廓模型的轮廓表示。
                ho_ModelContours.Dispose();
                HOperatorSet.GetShapeModelContours(out ho_ModelContours, hv_ModelID, 1);
                //  hv_k = 0;
                //  ho_SearchImage.Dispose();
                //将RGB图像灰度化
                ho_GrayImage.Dispose();
                HOperatorSet.Rgb1ToGray(ho_Image, out ho_GrayImage);
                //在一个图像中找出一个尺度不变轮廓模型的最佳匹配。
                HOperatorSet.FindScaledShapeModel(ho_GrayImage, hv_ModelID, 0, 0, 0.8, 1.2,
                    minMatchScore, MatchNum/*匹配数目*/, 0.5, "least_squares", 3, 0, out hv_RowCheck, out hv_ColumnCheck,
                    out hv_AngleCheck, out hv_ScaleCheck, out hv_Score);
                Console.WriteLine((int)(new HTuple((new HTuple(hv_Score.TupleLength())).TupleGreater(0.8))));
                if ((int)(new HTuple((new HTuple(hv_Score.TupleLength())).TupleGreater(0.8))) != 0)
                {
                    for (hv_j = 0; (int)hv_j <= (int)((new HTuple(hv_Score.TupleLength())) - 1); hv_j = (int)hv_j + 1)
                    {
                        HOperatorSet.VectorAngleToRigid(0, 0, 0, hv_RowCheck.TupleSelect(hv_j),
                            hv_ColumnCheck.TupleSelect(hv_j), hv_AngleCheck.TupleSelect(hv_j),
                            out hv_MovementOfObject);
                        HOperatorSet.HomMat2dScale(hv_MovementOfObject, hv_ScaleCheck.TupleSelect(
                            hv_j), hv_ScaleCheck.TupleSelect(hv_j), hv_RowCheck.TupleSelect(hv_j),
                            hv_ColumnCheck.TupleSelect(hv_j), out hv_MoveAndScaleOfObject);
                        ho_ModelAtNewPosition.Dispose();
                        HOperatorSet.AffineTransContourXld(ho_ModelContours, out ho_ModelAtNewPosition,
                            hv_MoveAndScaleOfObject);
                        //  HOperatorSet.DispObj(ho_ModelAtNewPosition, hv_ExpDefaultWinHandle);
                    }
                }
            }
            catch (HalconException HDevExpDefaultException)
            {
                ho_Image.Dispose();
                ho_Circle.Dispose();
                ho_EmptyImage.Dispose();
                ho_SyntheticModelImage.Dispose();
                ho_ModelImages.Dispose();
                ho_ModelRegions.Dispose();
                ho_ModelContours.Dispose();
                ho_SearchImage.Dispose();
                ho_GrayImage.Dispose();
                ho_ModelAtNewPosition.Dispose();
                throw HDevExpDefaultException;
            }
        }
    }
}
