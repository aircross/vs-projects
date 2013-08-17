using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;
using System.Text.RegularExpressions;
using System.IO;

namespace POSDLL
{



    //图文类。支持将文字，图片，窗口指定区域转成点阵数据
    //结合CACULATE类可以得到很多种变换效果
    //利用COMMUNICATION类的方法可以将数据下发
    //支持将字符串命令转成16进制指令
    public class TEXTANDPIC
    {
        //将形如 1b 40 的字符串指令转成字节数组（机器可识别的指令）new byte[] { 0x1b, 0x40 }。空白符将被忽略（回车，空格，制表符）。
        public static byte[] TAC_StrToHexCommand(String strCommand)
        {
            Regex rxHex = new Regex(@"[0-9]|[a-z]|[A-Z]");
            Regex rxBlank = new Regex(@"\s");

            byte[] desHexCommand = new byte[strCommand.Trim().Length];
            int k = 0;
            for (int i = 0; i < strCommand.Length; i++)
            {
                if (rxBlank.IsMatch(strCommand[i].ToString()))
                    continue;
                else if (rxHex.IsMatch(strCommand.Substring(i, 2)))
                    desHexCommand[k++] = Convert.ToByte(strCommand.Substring(i++, 2), 16);
                else
                {
                    MessageBox.Show("字符串含有非法字符！");
                    return null;
                }
            }
            byte[] tempDesHex = new byte[k];
            for (int i = 0; i < k; i++)
                tempDesHex[i] = desHexCommand[i];
            return tempDesHex;
        }

        //当前窗口上指定相对坐标，指定范围，转为点阵数据。
        public static byte[][] TAC_TurnAreaToPixData(Form fmImaNoScreen, int nPositionX, int nPositionY, int nAreaWidth, int nAreaHeight)
        {
            byte[][] tempDesData = new byte[nAreaHeight][];
            for (int i = 0; i < nAreaHeight; i++)
                tempDesData[i] = new byte[nAreaWidth];
            try
            {
                Bitmap bmpForm = new Bitmap(fmImaNoScreen.Width, fmImaNoScreen.Height);
                fmImaNoScreen.DrawToBitmap(bmpForm, new Rectangle(0, 0, bmpForm.Width, bmpForm.Height));
                Bitmap bmpDes = new Bitmap(nAreaWidth, nAreaHeight);
                Graphics grpForm = Graphics.FromImage(bmpDes);
                int Border = (fmImaNoScreen.Width - fmImaNoScreen.ClientSize.Width) / 2;
                Rectangle destRect = new Rectangle(nPositionX + Border,
                    nPositionY + fmImaNoScreen.Height - fmImaNoScreen.ClientSize.Height - Border,
                    nAreaWidth, nAreaHeight);
                Rectangle srcRect = new Rectangle(0, 0, nAreaWidth, nAreaHeight);
                grpForm.DrawImage(bmpForm, srcRect, destRect, GraphicsUnit.Pixel);

                System.Drawing.Imaging.BitmapData tempBitmapData = bmpDes.LockBits(srcRect, System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

                fmImaNoScreen.Enabled = false;
                unsafe
                {
                    byte* tempPixelData = (byte*)tempBitmapData.Scan0.ToPointer();
                    int jump = tempBitmapData.Stride - nAreaWidth * 3;
                    for (int i = 0; i < nAreaHeight; i++)
                    {
                        for (int j = 0; j < nAreaWidth; j++)
                        {
                            tempDesData[i][j] = TAC_IsBlack(*tempPixelData ^ 0xff, *(tempPixelData + 1) ^ 0xff, *(tempPixelData + 2) ^ 0xff, 1);
                            tempPixelData += 3;
                        }
                        tempPixelData += jump;
                    }
                }
                fmImaNoScreen.Enabled = true;
            }
            catch (Exception Mistake)
            {
                MessageBox.Show(Mistake.ToString());
                return null;
            }
            return tempDesData;
        }

        //将图片转成点阵数据
        public static byte[][] TAC_TurnPicToPixData(String sFilePath)
        {
            try
            {
                Bitmap bmp = new Bitmap(sFilePath);
                int widthPix = bmp.Width;
                int heightPix = bmp.Height;
                Rectangle rct = new Rectangle(0, 0, widthPix, heightPix);
                System.Drawing.Imaging.BitmapData bmpData = bmp.LockBits(rct, System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppRgb);

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
                            if (gray < 128)
                                bmpBitData[i][j] = 0xfe;
                            else
                                bmpBitData[i][j] = 0x00;
                            pBmpData += 4;
                        }
                        pBmpData += bmpData.Stride - bmpData.Width * 4;
                    }
                }
                return bmpBitData;
            }
            catch (Exception Mistake)
            {
                MessageBox.Show(Mistake.ToString());
                return null;
            }
        }

        public static byte[][] TAC_TurnBmpToPixData(Bitmap bmp)
        {
            try
            {
                int widthPix = bmp.Width;
                int heightPix = bmp.Height;
                Rectangle rct = new Rectangle(0, 0, widthPix, heightPix);
                System.Drawing.Imaging.BitmapData bmpData = bmp.LockBits(rct, System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppRgb);

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
                            if (gray < 128)
                                bmpBitData[i][j] = 0xfe;
                            else
                                bmpBitData[i][j] = 0x00;
                            pBmpData += 4;
                        }
                        pBmpData += bmpData.Stride - bmpData.Width * 4;
                    }
                }
                return bmpBitData;
            }
            catch (Exception Mistake)
            {
                MessageBox.Show(Mistake.ToString());
                return null;
            }
        }

        //得到字库数据的索引
        private static long TAC_GetIndex(byte chh, byte chl)
        {
            if (chh < 0x80)
            {   // 第四区汉字，4字节汉字区
                return (chh * 1260 + chl - 12439 + 21008);
            }
            if ((chh <= 0xF7) & (chh >= 0xb0) & (chl >= 0xa1))
            {   // 第一区汉字 (0xB0A1~0xF7FE) = 72 x 94 = 6768
                if ((chl == 0xFF)) return (0x40000000);
                return ((chh - 0xb0) * 94 + (chl - 0xa1));
            }
            if (chh <= 0xa0)
            {   // 第二区汉字 (0x8140~0xA0FE) = 32 x 190 = 6080       (0xXX7F除外)
                if (chl > 0x7f) chl--;
                else if ((chl == 0x7F) | (chl == 0xFF)) return (0x40000000);
                return (6768 + (chh - 0x81) * 190 + chl - 0x40);
            }
            if ((chh >= 0xaa) & (chl <= 0xa0))
            {   // 第三区汉字 (0xAA40~0xFEA0) = 85 x 96 = 8160       (0xXX7F除外)
                if (chl > 0x7f) chl--;
                else if ((chl == 0x7F) | (chl == 0xFF)) return (0x40000000);
                return (6768 + 6080 + (chh - 0xaa) * 96 + chl - 0x40);
            }
            long v = 27538;

            if ((chl == 0xa0) | (chl == 0x7F) | (chl == 0xFF)) return (0x40000000);
            if ((chl >= 0xa1) & (chh >= 0xA1) & (chh <= 0xA9))
            {   // 第一区字符 (0xA1A1~0xA9FE) = 9 x 94 = 846
                if ((chh == 0xA9) & (chl >= 0xF0))
                    return (0x40000000);
                return (v + (chh - 0xa1) * 94 + chl - 0xa1);
            }
            else if (((chl >= 0x40) & (chl < 0xA0)) & ((chh == 0xA8) | (chh == 0xA9)))
            {   // 第二区字符 (0xA840~0xA9A0) = 2 x 96 = 192       (0xXX7F除外)
                v = chl - 0x40 + (chh - 0xA8) * 0x60 + 0x20000000;
                if (chl > 0x7F)
                    v--;
                return v;
            }
            else
                return (0x40000000);

        }

        //将字符串转成点阵数据。可以设置行间留白，字符右间距，以及页宽。
        public static byte[][] TAC_WriteStringToPixel(String sText, int nLineSpacing, int nRightSpacing, int nPageWidth)
        {
            //使用24*24的默认字体
            int fontHeight = 24;
            int fontWidth = 24;
            int fontWidthASCII = 12;
            int nPerFontBytes = 72;
            int nPerASCIIBytes = 36;
            int desWidth = nPageWidth;
            int desHeight = ((sText.Length * (fontWidth + nRightSpacing) + nPageWidth - 1) / nPageWidth) * (fontHeight + nLineSpacing);

            byte[][] desData = new byte[desHeight][];
            for (int i = 0; i < desHeight; i++)
                desData[i] = new byte[desWidth];
            //将sText转成点阵数据返回，nHeight和nWidth为行下间距和字符右间距

            FileStream fileStream = new FileStream("GB10830(24x24)_All", FileMode.Open);
            FileStream fileStreamASCII = new FileStream("(1b0000)base12X24", FileMode.Open);
            byte[] readBuffer = new byte[nPerFontBytes];
            byte[] readBufferASCII = new byte[nPerASCIIBytes];
            byte[] GBKBytes = Encoding.Default.GetBytes(sText);
            int gbkBytesLength = GBKBytes.Length;
            int ch = 0;
            int cl = 0;
            int desY = 0;
            int desX = 0;
            for (int i = 0; i < gbkBytesLength; i++)
            {
                ch = GBKBytes[i];
                if (ch < 128)
                {
                    if (ch < 20)
                        continue;
                    fileStreamASCII.Seek(TAC_GetASCIIFontDataIndex((byte)ch) * nPerASCIIBytes, SeekOrigin.Begin);
                    fileStreamASCII.Read(readBufferASCII, 0, readBufferASCII.Length);
                    if (desX + fontWidthASCII + nRightSpacing > desWidth - 1)
                    {
                        desX = 0;
                        desY = desY + fontHeight + nLineSpacing;
                    }
                    CACULATE.CACU_CopyData(TAC_TurnFontDataToBit(readBufferASCII, 24, 12), desY, desX, desData);
                    desX = desX + fontWidthASCII + nRightSpacing;
                }
                else
                {
                    i++;
                    cl = GBKBytes[i];
                    fileStream.Seek(TAC_GetIndex((byte)ch, (byte)cl) * nPerFontBytes, SeekOrigin.Begin);
                    fileStream.Read(readBuffer, 0, readBuffer.Length);
                    if (desX + fontWidth + nRightSpacing > desWidth - 1)
                    {
                        desX = 0;
                        desY = desY + fontHeight + nLineSpacing;
                    }
                    CACULATE.CACU_CopyData(TAC_TurnFontDataToBit(readBuffer, 24, 24), desY, desX, desData);
                    desX = desX + fontWidth + nRightSpacing;
                }
            }
            fileStream.Close();
            fileStreamASCII.Close();
            return desData;
        }

        //返回值非零表示有点，0表示无点。
        //貌似图片里来的像素是反得蛋碎得一地
        private static byte TAC_IsBlack(Color coPixelColor, int nAlgorithm)
        {
            //一切为了效率
            //彩色转黑白，而不是灰度。
            switch (nAlgorithm)
            {
                case 0:
                    {
                        uint red = coPixelColor.R;
                        uint green = coPixelColor.G;
                        uint blue = coPixelColor.B;
                        if (red < 96 | green < 96 | blue < 96)
                            return 0;
                        else
                            return 0xfe;
                    }
                case 1:
                    {
                        uint red = coPixelColor.R;
                        uint green = coPixelColor.G;
                        uint blue = coPixelColor.B;
                        if (red < 128 | green < 128 | blue < 128)
                            return 0;
                        else
                            return 0xfe;
                    }
                case 2:
                    {
                        uint red = coPixelColor.R;
                        uint green = coPixelColor.G;
                        uint blue = coPixelColor.B;
                        double gray = 0.3 * red + 0x59 * green + 0.11 * blue;
                        if (gray < 128)
                            return 0;
                        else
                            return 0xfe;
                    }
                default:
                    MessageBox.Show("算法选择错误请选0或1");
                    return 0;
            }
        }
        private static byte TAC_IsBlack(int red, int green, int blue, int nAlgorithm)
        {
            switch (nAlgorithm)
            {
                case 1:
                    {
                        if (red < 128 | green < 128 | blue < 128)
                            return 0;
                        else
                            return 0xfe;
                    }
                default:
                    return 0;
            }
        }

        //为了优化算法
        private static uint[] D = new uint[256];
        private static uint[] E = new uint[256];
        private static uint[] F = new uint[256];
        private static Boolean bIsInited = false;
        private static void TAC_Init()
        {
            if (!bIsInited)
            {
                for (uint i = 0; i < 256; i++)
                {
                    D[i] = (i * 1224) >> 12;
                    E[i] = (i * 2404) >> 12;
                    F[i] = (i * 467) >> 12;
                }
                bIsInited = true;
            }
        }

        //将字体以指定像素画到屏幕上，再从屏幕上取点得到字体点阵信息
        //按照一定的顺序写入二进制文件，以此制成字库文件
        //写的有问题，还是得改一改
        private static void TAC_CreateFontLibrary(TextBox tbFont, int nFontHeight, int nFontWidth, int nLines, int nClos, String sFontName)
        {
            //直接产生GBK字库文件
            //这是在PC端用的
            Encoding GBK = Encoding.GetEncoding("GBK");
            int nPerWordByte = (nFontWidth + 7) / 8 * nFontHeight;
            int nPerPageByte = nPerWordByte * nLines * nClos;
            byte[] barWriteFontDataBuffer = new byte[nPerPageByte * 0x7e];
            byte[] GbkBytes = new byte[nLines * nClos * 2];
            int bufferOffeset = 0;
            for (int ch = 0x81; ch <= 0xfe; ch++)
            {
                int k = 0;
                for (int cl = 0x40; cl <= 0xff; cl++)
                {
                    GbkBytes[k++] = (byte)ch;
                    GbkBytes[k++] = (byte)cl;
                }
                byte[] RealGbkBytes = Encoding.Convert(GBK, Encoding.Default, GbkBytes);
                String strPageText = Encoding.Default.GetString(TAC_ReplaceQuesToDoubleBlank(RealGbkBytes));
                tbFont.Text = strPageText;
                tbFont.Refresh();
                byte[][] tbFontBitData = TAC_TurnTextBoxToPix(tbFont);
                byte[] temp = TAC_CutToGridAndTurnToByte(tbFontBitData, nFontHeight, nFontWidth, nLines, nClos);
                temp.CopyTo(barWriteFontDataBuffer, bufferOffeset);
                bufferOffeset += nPerPageByte;
            }
            FileStream wFileStream = new FileStream(sFontName, FileMode.Create);
            wFileStream.Write(barWriteFontDataBuffer, 0, barWriteFontDataBuffer.Length);
            wFileStream.Close();
        }
        private static void TAC_CreateASCIILibrary(TextBox tbFont, int nFontHeight, int nFontWidth, int nLines, int nClos, String sFontName)
        {
            //直接产生ASCII字库文件
            //这是在PC端用的

            int nPerWordByte = (nFontWidth + 7) / 8 * nFontHeight;
            int nPerPageByte = nPerWordByte * nLines * nClos;
            byte[] barWriteFontDataBuffer = new byte[nPerPageByte];
            /*tbFont.Text = " !\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~";
            tbFont.Refresh();
            */
            byte[][] tbFontBitData = TAC_TurnTextBoxToPix(tbFont);
            byte[] temp = TAC_CutToGridAndTurnToByte(tbFontBitData, nFontHeight, nFontWidth, nLines, nClos);
            temp.CopyTo(barWriteFontDataBuffer, 0);

            FileStream wFileStream = new FileStream(sFontName, FileMode.Create);
            wFileStream.Write(barWriteFontDataBuffer, 0, barWriteFontDataBuffer.Length);
            wFileStream.Close();
        }
        private static void TAC_PrintLibrary(String sZikuPath, int nFontHeight, int nFontWidth, int nPerWordByte)
        {
            FileStream readFileStream = new FileStream(sZikuPath, FileMode.Open);
            byte[] wordData = new byte[nPerWordByte];
            int nWidth = nFontWidth * 16;
            int nHeight = (nFontHeight + 4) * 12;
            byte[][] pageData = new byte[nHeight][];
            for (int i = 0; i < nHeight; i++)
                pageData[i] = new byte[nWidth];
            for (int i = 0; i < nHeight; i = i + nFontHeight + 4)
            {
                for (int j = 0; j < nWidth; j = j + nFontWidth)
                {
                    readFileStream.Read(wordData, 0, nPerWordByte);
                    CACULATE.CACU_CopyData(TAC_TurnFontDataToBit(wordData, nFontHeight, nFontWidth), i, j, pageData);
                }
            }
            COMMUNICATION.CMNCT_Send(CACULATE.CACU_PixDataToPrintedCommand(pageData, 0));
        }
        private static byte[] TAC_ReplaceQuesToDoubleBlank(byte[] orgByte)
        {
            int orgLength = orgByte.Length;
            int desLength = orgLength * 2;
            byte[] tempByte = new byte[desLength];
            int k = 0;
            for (int i = 0; i < orgLength; i++)
            {
                if (orgByte[i] < 128)
                {
                    tempByte[k++] = 0x20;
                    tempByte[k++] = 0x20;
                }
                else
                {
                    tempByte[k++] = orgByte[i++];
                    tempByte[k++] = orgByte[i];
                }
            }
            byte[] desByte = new byte[k];
            for (int i = 0; i < k; i++)
                desByte[i] = tempByte[i];
            return desByte;
        }

        //临时测试用
        private static byte[] TAC_ReadFontByteData(String sFontFile, long location, int nBytesOfData)
        {
            FileStream rFileStream = new FileStream(sFontFile, FileMode.Open);
            rFileStream.Seek(location, SeekOrigin.Begin);
            byte[] bFontByteData = new byte[nBytesOfData];
            rFileStream.Read(bFontByteData, 0, nBytesOfData);
            rFileStream.Close();
            return bFontByteData;
        }
        private static long TAC_GetFontDataIndex(byte ch, byte cl)
        {
            //GBK段
            long location = (ch - 0x81) * 0xc0 + cl - 0x40;
            return location;
        }
        private static long TAC_GetASCIIFontDataIndex(byte ch)
        {
            long location = ch - 0x20;
            return location;
        }

        //返回转换的点阵数据
        private static byte[][] TAC_TurnTextBoxToPix(TextBox tbFont)
        {
            int nWidth = tbFont.Width;
            int nHeight = tbFont.Height;
            Bitmap bmpTbFont = new Bitmap(nWidth, nHeight);
            Rectangle rctTbFont = new Rectangle(0, 0, nWidth, nHeight);
            tbFont.DrawToBitmap(bmpTbFont, rctTbFont);
            byte[][] tempDesData = new byte[nHeight][];
            Color coTemp = Color.Empty;
            for (int i = 0; i < nHeight; i++)
            {
                tempDesData[i] = new byte[nWidth];
                for (int j = 0; j < nWidth; j++)
                {
                    Color coRealPixel = Color.FromArgb(bmpTbFont.GetPixel(j, i).ToArgb() ^ 0xffffff);
                    tempDesData[i][j] = TAC_IsBlack(coRealPixel, 1);
                }
            }
            return tempDesData;
        }

        //将源数据按指定的宽高分割成小方格图片，以每个图片为单位，返回光栅数据
        private static byte[] TAC_CutToGridAndTurnToByte(byte[][] orgData, int nPerHeight, int nPerWidth, int nLines, int nClos)
        {
            //测试时为bFontWidth = 24,bFontHeight = 24,bLines = 12, bClos = 16;
            //12行，每行16个汉字
            int nHeight = nPerHeight * nLines;
            int nWidht = nPerWidth * nClos;
            byte[][] tempGridData = new byte[nPerHeight][];
            for (int i = 0; i < nPerHeight; i++)
                tempGridData[i] = new byte[nPerWidth];
            int nPerGridByte = ((nPerWidth + 7) / 8) * nPerHeight;
            byte[] bWordsByte = new byte[nPerGridByte * nLines * nClos];
            int k = 0;
            for (int i = 0; i < nHeight; i += nPerHeight)
                for (int j = 0; j < nWidht; j += nPerWidth)
                {
                    CACULATE.CACU_CutToData(orgData, i, j, tempGridData);//已经获得光栅的点阵数据了
                    TAC_TurnBitToByte(tempGridData).CopyTo(bWordsByte, k);
                    k += nPerGridByte;
                }
            return bWordsByte;
        }

        //将bitmap转成光栅位图
        public static byte[] TAC_TurnBmpToByte(Bitmap bitmap,int nMode,int nWidth)
        {
            
        }

        //将bit点阵数据转成水平排列的光栅数据，返回字节。每水平8个位一个字节，不足则补齐
        private static byte[] TAC_TurnBitToByte(byte[][] orgData)
        {
            if (orgData == null)
            {
                MessageBox.Show("数组没有正确初始化");
                return null;
            }

            int orgHeight = orgData.Length;
            int orgWidth = orgData[0].Length;
            int desHeight = orgHeight;//转成8的倍数之后的高和宽，为了速度，这里暂时不新建二维数组，直接用一维
            int desWidth = ((orgWidth + 7) / 8) * 8;//

            int nDataSum = desHeight * desWidth / 8;//
            byte[] dataToSave = new byte[nDataSum];

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
                                dataToSave[k] |= bitToByte[m];
                    }
                    else
                    {
                        for (int m = 0; m < 8 - (desWidth - orgWidth); m++)
                            if (orgData[i][j + m] != 0)
                                dataToSave[k] |= bitToByte[m];
                    }
                    k++;
                }
            }
            return dataToSave;
        }

        //将字体数据转成指定像素的点阵数据
        private static byte[] byteToBit = { 0x80, 0x40, 0x20, 0x10, 0x08, 0x04, 0x02, 0x01 };
        private static byte[][] TAC_TurnFontDataToBit(byte[] orgByte, int nHeightPix, int nWidthPix)
        {
            byte[] desAllPix = new byte[nHeightPix * nWidthPix];
            int orgLength = orgByte.Length;
            int k = 0;
            for (int i = 0; i < orgLength; i++)
            {
                for (int a = 0; a < 8; a++)
                {
                    if ((orgByte[i] & byteToBit[a]) != 0)
                        desAllPix[k] = 0xfe;
                    k++;
                }
            }

            byte[][] desData = new byte[nHeightPix][];
            k = 0;
            for (int i = 0; i < nHeightPix; i++)
            {
                desData[i] = new byte[nWidthPix];
                for (int j = 0; j < nWidthPix; j++)
                    desData[i][j] = desAllPix[k++];
            }
            return desData;
        }

        //下载位图到RAM
        //将位图转成可被标准打印机执行的命令
        public static byte[] TAC_PreDownloadBmpToRam(string sBmpPath)
        {
            Bitmap bmp = new Bitmap(sBmpPath);
            int widthPix = bmp.Width;
            int heightPix = bmp.Height;
            Rectangle rct = new Rectangle(0, 0, widthPix, heightPix);
            System.Drawing.Imaging.BitmapData bmpData = bmp.LockBits(rct, System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppRgb);

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
                        if (gray < 128)
                            bmpBitData[i][j] = 0xfe;
                        else
                            bmpBitData[i][j] = 0x00;
                        pBmpData += 4;
                    }
                    pBmpData += bmpData.Stride - bmpData.Width * 4;
                }

            }

            //再将像素转成RAM命令
            int x = (widthPix + 7) / 8;
            int y = (heightPix + 7) / 8;
            if (x > 255 | y > 48 | x * y > 912)
            {
                MessageBox.Show("超出范围\nx:0-255\ny:0-48\nx*y:0-912");
                return new byte[] { 0x00 };
            }
            byte[] desData = new byte[4 + x * y * 8];
            desData[0] = 0x1d;
            desData[1] = 0x2a;
            desData[2] = (byte)x;
            desData[3] = (byte)y;
            int k = 4;
            byte[] posToVa = { 0x80, 0x40, 0x20, 0x10, 0x08, 0x04, 0x02, 0x01 };
            for (int j = 0; j < widthPix; j++)
            {
                for (int i = 0; i < heightPix; i = i + 8)
                {
                    for (int a = 0; a < 8; a++)
                    {
                        if (i + a > heightPix - 1)
                            break;
                        if (bmpBitData[i + a][j] != 0)
                            desData[k] |= posToVa[a];
                    }
                    k++;
                }
            }
            return desData;
        }

        public static byte[] TAC_PreDownloadBmpToRam(Bitmap bmp)
        {
            int widthPix = bmp.Width;
            int heightPix = bmp.Height;
            Rectangle rct = new Rectangle(0, 0, widthPix, heightPix);
            System.Drawing.Imaging.BitmapData bmpData = bmp.LockBits(rct, System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppRgb);

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
                        if (gray < 128)
                            bmpBitData[i][j] = 0xfe;
                        else
                            bmpBitData[i][j] = 0x00;
                        pBmpData += 4;
                    }
                    pBmpData += bmpData.Stride - bmpData.Width * 4;
                }

            }

            //再将像素转成RAM命令
            int x = (widthPix + 7) / 8;
            int y = (heightPix + 7) / 8;
            if (x > 255 | y > 48 | x * y > 912)
            {
                MessageBox.Show("超出范围\nx:0-255\ny:0-48\nx*y:0-912");
                return new byte[] { 0x00 };
            }
            byte[] desData = new byte[4 + x * y * 8];
            desData[0] = 0x1d;
            desData[1] = 0x2a;
            desData[2] = (byte)x;
            desData[3] = (byte)y;
            int k = 4;
            byte[] posToVa = { 0x80, 0x40, 0x20, 0x10, 0x08, 0x04, 0x02, 0x01 };
            for (int j = 0; j < widthPix; j++)
            {
                for (int i = 0; i < heightPix; i = i + 8)
                {
                    for (int a = 0; a < 8; a++)
                    {
                        if (i + a > heightPix - 1)
                            break;
                        if (bmpBitData[i + a][j] != 0)
                            desData[k] |= posToVa[a];
                    }
                    k++;
                }
            }
            return desData;
        }

        //下载位图到FLASH
        //将位图转成可被标准打印机执行的命令
        public static byte[] TAC_PreDownloadBmpsToFlash(string[] pszPaths)
        {
            int bmpNum = pszPaths.Length;
            int DataLength = 3;//前3个字节

            for (int i = 0; i < bmpNum; i++)
            {
                Bitmap bmp = new Bitmap(pszPaths[i]);
                int maIniLength = 4 + ((bmp.Width + 7) / 8) * ((bmp.Height + 7) / 8) * 8;
                DataLength += maIniLength;
            }
            if (DataLength > 8096)
            {
                MessageBox.Show("超出范围\n最大不能超过8096字节");
                return new byte[] { 0x00 };
            }

            byte[] desData = new byte[DataLength];
            desData[0] = 0x1c;
            desData[1] = 0x71;
            desData[2] = (byte)bmpNum;
            int k = 3;
            for (int p = 0; p < bmpNum; p++)
            {
                Bitmap bmp = new Bitmap(pszPaths[p]);
                int widthPix = bmp.Width;
                int heightPix = bmp.Height;
                Rectangle rct = new Rectangle(0, 0, widthPix, heightPix);
                System.Drawing.Imaging.BitmapData bmpData = bmp.LockBits(rct, System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppRgb);

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
                            if (gray < 128)
                                bmpBitData[i][j] = 0xfe;
                            else
                                bmpBitData[i][j] = 0x00;
                            pBmpData += 4;
                        }
                        pBmpData += bmpData.Stride - bmpData.Width * 4;
                    }

                }

                //再将像素转成FLASH命令
                int x = (widthPix + 7) / 8;
                int y = (heightPix + 7) / 8;
                byte xL = (byte)(x % 0x100);
                byte xH = (byte)(x / 0x100);
                byte yL = (byte)(y % 0x100);
                byte yH = (byte)(y / 0x100);
                desData[k++] = xL;
                desData[k++] = xH;
                desData[k++] = yL;
                desData[k++] = yH;
                byte[] posToVa = { 0x80, 0x40, 0x20, 0x10, 0x08, 0x04, 0x02, 0x01 };
                for (int j = 0; j < widthPix; j++)
                {
                    for (int i = 0; i < heightPix; i = i + 8)
                    {
                        for (int a = 0; a < 8; a++)
                        {
                            if (i + a > heightPix - 1)
                                break;
                            if (bmpBitData[i + a][j] != 0)
                                desData[k] |= posToVa[a];
                        }
                        k++;
                    }
                }
                k += (x * 8 - widthPix) * y;
            }
            return desData;
        }

    }

}
