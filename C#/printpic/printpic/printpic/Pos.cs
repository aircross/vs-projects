using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace printpic
{
    class Pos
    {
        public static string lasterror = "no error";

        public static Bitmap POS_ResizeBitmap(Bitmap orgBitmap, int newWidth, int newHeight)
        {
            try
            {
                Bitmap b = new Bitmap(newWidth, newHeight);
                Graphics g = Graphics.FromImage(b);

                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(orgBitmap, new Rectangle(0, 0, newWidth, newHeight), new Rectangle(0, 0, orgBitmap.Width, orgBitmap.Height), GraphicsUnit.Pixel);
                g.Dispose();
                return b;
            }
            catch
            {
                return null;
            }
        }

        /* 将位图转换为256色光栅位图流数据 */
        /* byte[height][width] */
        public static byte[][] POS_BitmapToStream(Bitmap orgBitmap)
        {
            try
            {
                int widthPix = orgBitmap.Width;
                int heightPix = orgBitmap.Height;
                Rectangle rct = new Rectangle(0, 0, widthPix, heightPix);
                System.Drawing.Imaging.BitmapData bmpData = orgBitmap.LockBits(rct, System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppRgb);

                //先将像素复制出来
                byte[][] bmpBitData = new byte[heightPix][];
                unsafe
                {
                    byte* pBmpData = (byte*)bmpData.Scan0;
                    double gray = 0;

                    for (int i = 0; i < heightPix; i++)
                    {
                        bmpBitData[i] = new byte[widthPix];
                        for (int j = 0; j < widthPix; j++)
                        {
                            gray = *(pBmpData + 1) * 0.3 + *(pBmpData + 2) * 0.59 + *(pBmpData + 3) * 0.11;
                            bmpBitData[i][j] = (byte)gray;
                            pBmpData += 4;
                        }
                        pBmpData += bmpData.Stride - bmpData.Width * 4;
                    }
                }
                orgBitmap.UnlockBits(bmpData);
                return bmpBitData;
            }
            catch (Exception Mistake)
            {
                lasterror = Mistake.ToString();
                return null;
            }
        }

        	// 16*16
	private static int[,] Floyd16x16 = /* Traditional Floyd ordered dither */
	{
			{ 0, 128, 32, 160, 8, 136, 40, 168, 2, 130, 34, 162, 10, 138, 42,
					170 },
			{ 192, 64, 224, 96, 200, 72, 232, 104, 194, 66, 226, 98, 202, 74,
					234, 106 },
			{ 48, 176, 16, 144, 56, 184, 24, 152, 50, 178, 18, 146, 58, 186,
					26, 154 },
			{ 240, 112, 208, 80, 248, 120, 216, 88, 242, 114, 210, 82, 250,
					122, 218, 90 },
			{ 12, 140, 44, 172, 4, 132, 36, 164, 14, 142, 46, 174, 6, 134, 38,
					166 },
			{ 204, 76, 236, 108, 196, 68, 228, 100, 206, 78, 238, 110, 198, 70,
					230, 102 },
			{ 60, 188, 28, 156, 52, 180, 20, 148, 62, 190, 30, 158, 54, 182,
					22, 150 },
			{ 252, 124, 220, 92, 244, 116, 212, 84, 254, 126, 222, 94, 246,
					118, 214, 86 },
			{ 3, 131, 35, 163, 11, 139, 43, 171, 1, 129, 33, 161, 9, 137, 41,
					169 },
			{ 195, 67, 227, 99, 203, 75, 235, 107, 193, 65, 225, 97, 201, 73,
					233, 105 },
			{ 51, 179, 19, 147, 59, 187, 27, 155, 49, 177, 17, 145, 57, 185,
					25, 153 },
			{ 243, 115, 211, 83, 251, 123, 219, 91, 241, 113, 209, 81, 249,
					121, 217, 89 },
			{ 15, 143, 47, 175, 7, 135, 39, 167, 13, 141, 45, 173, 5, 133, 37,
					165 },
			{ 207, 79, 239, 111, 199, 71, 231, 103, 205, 77, 237, 109, 197, 69,
					229, 101 },
			{ 63, 191, 31, 159, 55, 183, 23, 151, 61, 189, 29, 157, 53, 181,
					21, 149 },
			{ 254, 127, 223, 95, 247, 119, 215, 87, 253, 125, 221, 93, 245,
					117, 213, 85 } };
	

        public static void format_K_dither16x16(byte[][] orgpixels, byte[][] despixels)
        {
            int ysize = orgpixels.Length;
            int xsize = orgpixels[0].Length;
            for (int y = 0; y < ysize; y++)
            {
                for (int x = 0; x < xsize; x++)
                {

                    if ((orgpixels[y][x] & 0xff) > Floyd16x16[x & 15,y & 15])
                        despixels[y][x] = 0;// black
                    else
                        despixels[y][x] = 1;
                }
            }
        }

        //将bit点阵数据转成水平排列的光栅数据，返回字节。每水平8个位一个字节，不足则补齐
        public static byte[] TurnBitStreamToByte(byte[][] orgData)
        {
            int orgHeight = orgData.Length;
            int orgWidth = orgData[0].Length;
            int desHeight = orgHeight;//转成8的倍数之后的高和宽，为了速度，这里暂时不新建二维数组，直接用一维
            int desWidth = ((orgWidth + 7) / 8) * 8;//

            int nDataSum = desHeight * desWidth / 8;//
            byte[] dataToSend = new byte[nDataSum];

            //这个算法比较精简
            byte[] bitToByte = { 0x80, 0x40, 0x20, 0x10, 0x08, 0x04, 0x02, 0x01 };
            for (int i = 0, k = 0; i < desHeight; i++)
            {
                for (int j = 0; j < desWidth; j = j + 8)
                {
                    if (j + 8 < orgWidth)
                    {
                        for (int m = 0; m < 8; m++)
                            if (orgData[i][j + m] != 0)
                                dataToSend[k] |= bitToByte[m];
                    }
                    else
                    {
                        for (int m = 0; m < 8 - (desWidth - orgWidth); m++)
                            if (orgData[i][j + m] != 0)
                                dataToSend[k] |= bitToByte[m];
                    }
                    k++;
                }
            }
            return dataToSend;
        }

    }
}
