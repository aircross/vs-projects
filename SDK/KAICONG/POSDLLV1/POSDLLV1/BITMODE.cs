/* 小打印机不支持超长光栅位图
 * 只能将光栅位图分割开来打印
 * 
 * 
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace POSDLL
{
    class BITMODE
    {
        private static byte[][] PageBuffer;//页缓存
        private static byte[][] tempData;//实时旋转之前，先保存页副本。待操作完成之后，再把页副本贴合。
        private static byte[][] bmpBuffer;
        private static int PrintDirection = 0;//打印模式。为0，不变。为1，顺时针转90°。为2，顺时针转180°。为3，顺时针转270°。
        private static int LeftPad;//左边留白
        private static int TopPad;//顶部留白
        private static int PrintAreaWidth;//打印区域宽度
        private static int PrintAreaHeight;//打印区域高度
        private static int PrintPositionX = 0;
        private static int PrintPositionY = 0;
        private static int NextPrintingWidth = 24;
        private static int NextPrintingHeight = 24;

        private static int WordBufferSize = 72;//
        private static int KanjiWidth = 24;//汉字宽
        private static int KanjiHeight = 24;//汉字高
        private static int CharWidth = 12;//字符宽12
        private static int CharHeight = 24;//字符高
        private static Boolean UNDERLINE = false;
        private static Boolean RESERVE = false;
        private static Boolean TURN = false;

        private static int WidthTimes = 0;
        private static int HeightTimes = 0;
        private static int RightSpacing = 2;
        private static int LineSpacing = 4;
        private static int LineHeight = KanjiHeight + LineSpacing;


        public static Boolean setWordTimes(int nWidthTimes, int nHeightTimes)
        {
            WidthTimes = nWidthTimes;
            HeightTimes = nHeightTimes;
            return true;
        }
        //设置左边留白
        public static bool setLeftPad(int nLeftPad)//设置LeftPad为nLeftPad，并返回先前的LeftPad。
        {
            if (nLeftPad < 0)
                return false;
            else
            {
                LeftPad = nLeftPad;
                return true;
            }
        }

        public static bool setTopPad(int nTopPad)
        {
            if (nTopPad < 0)
                return false;
            else
            {
                TopPad = nTopPad;
                return true;
            }
        }

        //设置字体风格
        public static void POS_SetFontStyle(Boolean turn, Boolean Reserve, Boolean underLine)
        {
            UNDERLINE = underLine;
            TURN = turn;
            RESERVE = Reserve;
        }

        //设置打印区域宽度
        private static bool setPageWidth(int nPageWidth)
        {
            if (nPageWidth < 0)
                return false;
            else
            {
                PrintAreaWidth = nPageWidth;
                return true;
            }
        }

        //设置打印区域高度
        private static bool setPageHeight(int nPageHeight)
        {
            if (nPageHeight < 0)
                return false;
            else
            {
                PrintAreaHeight = nPageHeight;
                return true;
            }
        }

        //设置打印方向，与标记PrintDirection息息相关
        public static void SYS_SetPrintDirection(int nPrintDirection)
        {
            if (PrintDirection == 0)//从右上到右下
            {
                switch (nPrintDirection)
                {
                    case 1:
                    case 3:
                        {
                            tempData = new byte[PageBuffer.Length][];
                            for (int i = 0; i < PageBuffer.Length; i++)
                            {
                                tempData[i] = new byte[PageBuffer[0].Length];
                                PageBuffer[i].CopyTo(tempData[i], 0);
                            }//副本已存好

                            PrintDirection = nPrintDirection;
                            //重置guangShanData
                            int temp = PrintAreaWidth;
                            PrintAreaWidth = PrintAreaHeight;
                            PrintAreaHeight = temp;//宽高对调

                            /* 坐标对换
                            temp = imaPrintPoint.x;
                            imaPrintPoint.x = imaPrintPoint.y;
                            imaPrintPoint.y = temp;
                            */
                            //重新初始化
                            PageBuffer = new byte[PrintAreaHeight][];
                            for (int i = 0; i < PrintAreaHeight; i++)
                                PageBuffer[i] = new byte[LeftPad + PrintAreaWidth];
                            PrintPositionX = LeftPad;
                            PrintPositionY = 0;
                            return;
                        }
                    case 2://转180°
                        {
                            tempData = new byte[PrintAreaHeight][];
                            for (int i = 0; i < PrintAreaHeight; i++)
                            {
                                tempData[i] = new byte[PrintAreaWidth];
                                PageBuffer[i].CopyTo(tempData[i], 0);
                            }//副本已存好
                            PrintDirection = nPrintDirection;
                            //重置guangShanData

                            PageBuffer = new byte[PrintAreaHeight][];
                            for (int i = 0; i < PrintAreaHeight; i++)
                                PageBuffer[i] = new byte[LeftPad + PrintAreaWidth];//PageWidth和左边距
                            PrintPositionX = LeftPad;
                            PrintPositionY = 0;
                            return;
                        }
                }
            }
            else//用户已经设置过旋转 
            {
                if (nPrintDirection == 0)//用户如果不恢复正常，那么你调用一次，把它合成
                {
                    switch (PrintDirection)
                    {
                        //从转向打再恢复到正常方向
                        case 1:
                            {
                                int y = tempData.Length;
                                int x = tempData[0].Length;
                                for (int i = 0; i < y; i++)
                                    for (int j = 0; j < x; j++)
                                        tempData[i][j] |= PageBuffer[x - 1 - j][i];//
                                PrintAreaHeight = y;
                                PrintAreaWidth = x;
                                PrintDirection = nPrintDirection;
                                PageBuffer = new byte[PrintAreaHeight][];
                                for (int i = 0; i < PrintAreaHeight; i++)
                                {
                                    PageBuffer[i] = new byte[LeftPad + PrintAreaWidth];
                                    tempData[i].CopyTo(PageBuffer[i], 0);
                                }
                                PrintPositionX = LeftPad;
                                PrintPositionY = 0;
                                return;
                            }
                        case 3:
                            {
                                int y = tempData.Length;
                                int x = tempData[0].Length;
                                for (int i = 0; i < y; i++)
                                    for (int j = 0; j < x; j++)
                                        tempData[i][j] |= PageBuffer[j][y - 1 - i];//后来居上，不用|=，就用=
                                PrintAreaHeight = y;
                                PrintAreaWidth = x;
                                PrintDirection = nPrintDirection;
                                PageBuffer = new byte[PrintAreaHeight][];
                                for (int i = 0; i < PrintAreaHeight; i++)
                                {
                                    PageBuffer[i] = new byte[LeftPad + PrintAreaWidth];
                                    tempData[i].CopyTo(PageBuffer[i], 0);
                                }
                                PrintPositionX = LeftPad;
                                PrintPositionY = 0;
                                return;
                            }
                        case 2:
                            {
                                int y = PrintAreaHeight;
                                int x = PrintAreaWidth;
                                for (int i = 0; i < y; i++)
                                    for (int j = 0; j < x; j++)
                                        tempData[i][j] |= PageBuffer[y - 1 - i][x - 1 - j];//后来居上，不用|=，就用=

                                PrintDirection = nPrintDirection;
                                PageBuffer = new byte[PrintAreaHeight][];
                                for (int i = 0; i < PrintAreaHeight; i++)
                                {
                                    PageBuffer[i] = new byte[LeftPad + PrintAreaWidth];
                                    tempData[i].CopyTo(PageBuffer[i], 0);
                                }
                                PrintPositionX = LeftPad;
                                PrintPositionY = 0;
                                return;
                            }
                    }
                }
                else
                {
                    SYS_SetPrintDirection(0);
                    SYS_SetPrintDirection(nPrintDirection);
                }
            }

        }

        //选择页模式
        public static bool POS_SelectPageMode(int nLeftPad, int nTopPad, int nPageWidth, int nPageHeight, int nPrintDirection)
        {
            setLeftPad(nLeftPad);
            setTopPad(nTopPad);
            setPageWidth(nPageWidth);
            setPageHeight(nPageHeight);
            int desH = nTopPad + nPageHeight;
            int desW = nLeftPad + nPageWidth;
            PageBuffer = new byte[desH][];
            for (int i = 0; i < desH; i++)
                PageBuffer[i] = new byte[desW];
            SYS_SetPrintDirection(nPrintDirection);

            return true;
        }

        //向缓冲区输入字符串
        //nOrgx和nOrgy表示绝对打印位置
        public static bool POS_PL_TextOut(String text, int nOrgx, int nOrgy,int nWidthTimes,int nHeightTimes,int nFontStyle)
        {
            byte[][] temp = TEXTANDPIC.TAC_WriteStringToPixel(text, LineSpacing, RightSpacing, LeftPad + PrintAreaWidth - nOrgx);

            byte[][] temptimes = CACULATE.CACU_TimesData(temp, nHeightTimes + 1, nWidthTimes + 1);

            CACULATE.CACU_CopyData(temptimes, nOrgy - LineHeight * nHeightTimes, nOrgx, PageBuffer);
            return true;
        }

        public static bool POS_PL_DownloadAndPrintBmp(string pszPath, int nOrgx, int nOrgy, int nMode)
        {
            byte[][] temp = TEXTANDPIC.TAC_TurnPicToPixData(pszPath);
            CACULATE.CACU_CopyData(temp, nOrgy - temp.Length, nOrgx, PageBuffer);
            return true;
        }

        public static bool POS_PreDownloadBmpToRAM(string pszPath, int nID)
        {
            bmpBuffer = TEXTANDPIC.TAC_TurnPicToPixData(pszPath);
            return true;
        }

        public static bool POS_PL_PrintBmpInRAM(int nID, int nOrgx, int nOrgy, int nMode)
        {
            nOrgy -= bmpBuffer.Length;
            CACULATE.CACU_CopyData(bmpBuffer, nOrgy, nOrgx, PageBuffer);
            return true;
        }

        //完成最后一系列工作，并把缓冲区的内容转成字节数据返回
        public static byte[] POS_Print()
        {
            if (PrintDirection != 0)
                SYS_SetPrintDirection(0);

            int nHeight = PageBuffer.Length;
            int nWidth = PageBuffer[0].Length;
            int blukHeight = 96;
            int blukSum = (nHeight + blukHeight - 1) / blukHeight;
            int byteLength = 8 * blukSum + (nWidth + 7) / 8 * ((nHeight + 7) / 8 * 8);
            byte[] latestData = new byte[byteLength];
            int offset = 0;
            byte[][] desData;
            desData = CACULATE.getSampleDesData(blukHeight, nWidth);

            for (int i = 0; i < nHeight; i = i + blukHeight)
            {
                if ((nHeight - i > 0) & (nHeight - i < blukHeight))
                    desData = CACULATE.getSampleDesData(nHeight - i, nWidth);

                CACULATE.CACU_CutToData(PageBuffer, i, 0, desData);
                byte[] temp = CACULATE.CACU_PixDataToPrintedCommand(desData, 0);
                temp.CopyTo(latestData, offset);
                offset += temp.Length;
            }
            return latestData;
        }

        //把缓冲区的内容清除
        public static void POS_Clear()
        {
            int h = PageBuffer.Length;
            int w = PageBuffer[0].Length;
            for (int i = 0; i < h; i++)
                for (int j = 0; j < w; j++)
                    PageBuffer[i][j] = 0x00;
        }

        public static Boolean POS_SetPrintPositionY(int y)
        {
            if (y < 0 | y > PrintAreaHeight + TopPad)
                return false;
            else
            {
                PrintPositionY = y;
                return true;
            }
        }

        public static Boolean POS_SetPrintPositionX(int x)
        {
            if (x < 0 | x > (LeftPad + PrintAreaWidth))
                return false;
            else
            {
                PrintPositionX = x;
                return true;
            }
        }

    }
}
