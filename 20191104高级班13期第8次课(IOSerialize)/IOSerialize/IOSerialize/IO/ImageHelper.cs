using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOSerialize.IO
{
    /// <summary>
    /// 
    /// </summary>
    public class ImageHelper
    {
        private static string ImagePath = ConfigurationManager.AppSettings["ImagePath"];
        private static string VerifyPath = ConfigurationManager.AppSettings["ImagePath"];
        //绘图的原理很简单：Bitmap就像一张画布，Graphics如同画图的手，把Pen或Brush等绘图对象画在Bitmap这张画布上

        /// <summary>
        /// 画验证码
        /// </summary>
        public static void Drawing()
        {
            Bitmap bitmapobj = new Bitmap(100, 100);
            //在Bitmap上创建一个新的Graphics对象
            Graphics g = Graphics.FromImage(bitmapobj);
            //创建绘画对象，如Pen,Brush等
            Pen redPen = new Pen(Color.Red, 8);
            g.Clear(Color.White);
            //绘制图形
            g.DrawLine(redPen, 50, 20, 500, 20);
            g.DrawEllipse(Pens.Black, new Rectangle(0, 0, 200, 100));//画椭圆
            g.DrawArc(Pens.Black, new Rectangle(0, 0, 100, 100), 60, 180);//画弧线
            g.DrawLine(Pens.Black, 10, 10, 100, 100);//画直线
            g.DrawRectangle(Pens.Black, new Rectangle(0, 0, 100, 200));//画矩形
            g.DrawString("我爱北京天安门", new Font("微软雅黑", 12), new SolidBrush(Color.Red), new PointF(10, 10));//画字符串
            //g.DrawImage(
            if (!Directory.Exists(ImagePath))
                Directory.CreateDirectory(ImagePath);
            bitmapobj.Save(ImagePath + "pic1.jpg", ImageFormat.Jpeg);
            //释放所有对象
            bitmapobj.Dispose();
            g.Dispose();
        }

        public static void VerificationCode()
        {
            Bitmap bitmapobj = new Bitmap(300, 300);
            //在Bitmap上创建一个新的Graphics对象
            Graphics g = Graphics.FromImage(bitmapobj);
            g.DrawRectangle(Pens.Black, new Rectangle(0, 0, 150, 50));//画矩形
            g.FillRectangle(Brushes.White, new Rectangle(1, 1, 149, 49));
            g.DrawArc(Pens.Blue, new Rectangle(10, 10, 140, 10), 150, 90);//干扰线
            string[] arrStr = new string[] { "我", "们", "孝", "行", "白", "到", "国", "中", "来", "真" };
            Random r = new Random();
            int i;
            for (int j = 0; j < 4; j++)
            {
                i = r.Next(10);
                g.DrawString(arrStr[i], new Font("微软雅黑", 15), Brushes.Red, new PointF(j * 30, 10));
            }
            bitmapobj.Save(Path.Combine(VerifyPath, "Verif.jpg"), ImageFormat.Jpeg);
            bitmapobj.Dispose();
            g.Dispose();
        }

        /// <summary>
        /// 按比例缩放,图片不会变形，会优先满足原图和最大长宽比例最高的一项
        /// </summary>
        /// <param name="oldPath"></param>
        /// <param name="newPath"></param>
        /// <param name="maxWidth"></param>
        /// <param name="maxHeight"></param>
        public static void CompressPercent(string oldPath, string newPath, int maxWidth, int maxHeight)
        {
            Image _sourceImg = Image.FromFile(oldPath);
            double _newW = (double)maxWidth;
            double _newH = (double)maxHeight;
            double percentWidth = (double)_sourceImg.Width > maxWidth ? (double)maxWidth : (double)_sourceImg.Width;

            if ((double)_sourceImg.Height * (double)percentWidth / (double)_sourceImg.Width > (double)maxHeight)
            {
                _newH = (double)maxHeight;
                _newW = (double)maxHeight / (double)_sourceImg.Height * (double)_sourceImg.Width;
            }
            else
            {
                _newW = percentWidth;
                _newH = (percentWidth / (double)_sourceImg.Width) * (double)_sourceImg.Height;
            }
            Image bitmap = new Bitmap((int)_newW, (int)_newH);
            Graphics g = Graphics.FromImage(bitmap);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.Clear(Color.Transparent);
            g.DrawImage(_sourceImg, new Rectangle(0, 0, (int)_newW, (int)_newH), new Rectangle(0, 0, _sourceImg.Width, _sourceImg.Height), GraphicsUnit.Pixel);
            _sourceImg.Dispose();
            g.Dispose();
            bitmap.Save(newPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            bitmap.Dispose();
        }

        /// <summary>
        /// 按照指定大小对图片进行缩放，可能会图片变形
        /// </summary>
        /// <param name="oldPath"></param>
        /// <param name="newPath"></param>
        /// <param name="newWidth"></param>
        /// <param name="newHeight"></param>
        public static void ImageChangeBySize(string oldPath, string newPath, int newWidth, int newHeight)
        {
            Image sourceImg = Image.FromFile(oldPath);
            System.Drawing.Image bitmap = new System.Drawing.Bitmap(newWidth, newHeight);
            Graphics g = Graphics.FromImage(bitmap);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.Clear(Color.Transparent);
            g.DrawImage(sourceImg, new Rectangle(0, 0, newWidth, newHeight), new Rectangle(0, 0, sourceImg.Width, sourceImg.Height), GraphicsUnit.Pixel);
            sourceImg.Dispose();
            g.Dispose();
            bitmap.Save(newPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            bitmap.Dispose();
        }
        //添加水印
        //二维码 QRCode  二维码其实对应的是一个Url
        
    }
}
