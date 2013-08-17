using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace DEMO
{
    class ScreenShot
    {
        public static void CaptureImage(Point SourcePoint, Point DestinationPoint, Rectangle SelectionRectangle)
        {
            using (Bitmap bitmap = new Bitmap(SelectionRectangle.Width, SelectionRectangle.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(SourcePoint, DestinationPoint, SelectionRectangle.Size);
                }
                int newWidth = bitmap.Width;
                int newHeight = bitmap.Height;
                if (newWidth > 384)
                {
                    newWidth = 384;
                    newHeight = (int)(newHeight / (newWidth / 384.0));
                }
                Bitmap tmpBitmap = KiResizeImage(bitmap, newWidth, newHeight, 0);
                tmpBitmap.Save(@"c:\demo.bmp", ImageFormat.Bmp); 
            }
        }
        public static Bitmap KiResizeImage(Bitmap bmp, int newW, int newH, int Mode)
        {
            try
            {
                Bitmap b = new Bitmap(newW, newH);
                Graphics g = Graphics.FromImage(b);
                // 插值算法的质量
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(bmp, new Rectangle(0, 0, newW, newH), new Rectangle(0, 0, bmp.Width, bmp.Height), GraphicsUnit.Pixel);
                g.Dispose();
                return b;
            }
            catch
            {
                return null;
            }
        }
    }
}