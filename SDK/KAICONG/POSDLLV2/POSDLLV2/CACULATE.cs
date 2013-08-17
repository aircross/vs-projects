using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace POSDLL
{
    //计算类，专职各种类型的数据
    public class CACULATE
    {
        //测试用
        private static byte[][] getSampleDesData()
        {
            byte[][] des = new byte[6][];
            des[0] = new byte[] { 0, 0, 0, 0, 0 };
            des[1] = new byte[] { 0, 0, 0, 0, 0 };
            des[2] = new byte[] { 0, 0, 0, 0, 0 };
            des[3] = new byte[] { 0, 0, 0, 0, 0 };
            des[4] = new byte[] { 0, 0, 0, 0 };
            des[5] = new byte[] { 0, 0, 0, 0, 0 };
            return des;
        }
        private static byte[][] getSampleOrgData()
        {
            byte[][] org = new byte[3][];
            org[0] = new byte[] { 0, 1, 2 };
            org[1] = new byte[] { 3, 4 };
            org[2] = new byte[] { 5, 6, 7 };
            return org;
        }
        public static byte[][] getSampleDesData(int nHeight, int nWidth)
        {
            if (nHeight < 1 | nWidth < 1)
            {
                MessageBox.Show("必须大于零");
                return null;
            }

            byte[][] tempDesData = new byte[nHeight][];
            for (int i = 0; i < nHeight; i++)
                tempDesData[i] = new byte[nWidth];
            return tempDesData;
        }
        //测试用函数和数据结束


        //将源数据写入目标数据。如果超出范围，超出部分数据忽略。返回值为写入的高度和宽度。desY为第一维，desX为第二维。
        public static int[] CACU_CopyData(byte[][] orgData, int desY, int desX, byte[][] desData)
        {
            if (orgData == null | desData == null)
            {
                MessageBox.Show("数组没有正确初始化");
                return null;
            }
            int height = orgData.Length;//数组的第一维高度，这个是一定确定的。但是第二维宽度却有可能每一行不一样
            int desHeight = desData.Length;
            int[] heiAndWdiWrited = { 0, 0 };
            for (int i = 0; i < height; i++)
            {
                if (desY + i > desHeight - 1)//判断超界用坐标
                    break;
                else
                {
                    int width = orgData[i].Length;
                    int desWidth = desData[desY + i].Length;
                    for (int j = 0; j < width; j++)
                    {
                        if (desX + j > desWidth - 1)//判断超界用坐标
                            break;//x方向上超出，后面不用试了，直接换下一行
                        else
                        {
                            desData[desY + i][desX + j] = orgData[i][j];
                            heiAndWdiWrited[1] = heiAndWdiWrited[1] < j + 1 ? j + 1 : heiAndWdiWrited[1];
                        }
                    }
                }
                heiAndWdiWrited[0] = i + 1;
            }
            return heiAndWdiWrited;
        }

        //从源数据中截取一段数据放入目标数据
        public static void CACU_CutToData(byte[][] orgData, int posY, int posX, byte[][] desData)
        {
            if (orgData == null | desData == null)
            {
                MessageBox.Show("数组没有正确初始化");
                return;
            }
            //以安全为主，先不考虑速度，先考虑周全
            int orgHeight = orgData.Length;
            int orgWidth = orgData[0].Length;
            int desHeight = desData.Length;
            int desWidth = desData[0].Length;

            if (posY < 0 | posY + desHeight > orgHeight | posX < 0 | posX + desWidth > orgWidth)
            {
                MessageBox.Show("尺寸不对");
                return;
            }

            for (int i = 0; i < desHeight; i++)
                for (int j = 0; j < desWidth; j++)
                    desData[i][j] = orgData[posY + i][posX + j];

        }

        //将源数据反转按0与非零反转
        public static void CACU_ReserveData(byte[][] orgData)
        {
            if (orgData == null)
            {
                MessageBox.Show("数组没有正确初始化");
                return;
            }
            for (int i = 0; i < orgData.Length; i++)
            {
                for (int j = 0, mainichiWidth = orgData[i].Length; j < mainichiWidth; j++)
                {
                    if (orgData[i][j] == 0)
                        orgData[i][j] = 0xfe;
                    else
                        orgData[i][j] = 0x00;
                }
            }
        }

        //将源数据按水平线镜面对称180°，也即上下翻转。返回目标数据。如果涉及到这类坐标会变化的，为了防止不对称数据，还是返回数组的好。
        public static byte[][] CACU_MirrorSideHorizontal(byte[][] orgData)
        {
            if (orgData == null)
            {
                MessageBox.Show("数组没有正确初始化");
                return null;
            }

            int orgHeight = orgData.Length;
            byte[][] tempDesData = new byte[orgHeight][];
            for (int i = 0; i < orgHeight; i++)
            {
                int orgWidth = orgData[i].Length;
                tempDesData[i] = new byte[orgWidth];
                orgData[orgHeight - 1 - i].CopyTo(tempDesData[i], 0);
            }
            return tempDesData;
        }

        //将源数据按竖直线镜面对称180°，也即左右翻转。返回目标数据。如果源数组不对称，将补齐零。返回的数组是对称的。
        public static byte[][] CACU_MirrorSideVertical(byte[][] orgData)
        {
            if (orgData == null)
            {
                MessageBox.Show("数组没有正确初始化");
                return null;
            }

            int orgHeight = orgData.Length;
            int orgWidthAbs = 0;
            for (int i = 0; i < orgHeight; i++)
                orgWidthAbs = orgWidthAbs < orgData[i].Length ? orgData[i].Length : orgWidthAbs;
            byte[][] tempDesData = new byte[orgHeight][];
            for (int i = 0; i < orgHeight; i++)
            {
                tempDesData[i] = new byte[orgWidthAbs];
                int orgWidth = orgData[i].Length;
                for (int j = 0; j < orgWidth; j++)
                    tempDesData[i][orgWidthAbs - 1 - j] = orgData[i][j];

            }
            return tempDesData;
        }

        //将源数据横向纵向分别放大为指定倍数，并返回
        public static byte[][] CACU_TimesData(byte[][] orgData, int nHeightTimes, int nWidthTimes)
        {
            if (orgData == null)
            {
                MessageBox.Show("数组没有正确初始化");
                return null;
            }

            if (nHeightTimes < 1 | nWidthTimes < 1)
            {
                MessageBox.Show("请选择正确的放大倍数");
                return null;
            }

            int orgHeight = orgData.Length;
            int desHeight = orgHeight * nHeightTimes;
            byte[][] tempDesData = new byte[desHeight][];
            for (int i = 0; i < orgHeight; i++)//以源数据为准，复制完成即可
            {
                int orgWidth = orgData[i].Length;
                int desWidth = orgWidth * nWidthTimes;
                for (int m = 0; m < nHeightTimes; m++)
                {
                    tempDesData[i * nHeightTimes + m] = new byte[desWidth];//初始化当前行
                    for (int j = 0; j < orgWidth; j++)
                    {
                        for (int n = 0; n < nWidthTimes; n++)
                            tempDesData[i * nHeightTimes + m][j * nWidthTimes + n] = orgData[i][j];
                    }
                }
            }
            return tempDesData;
        }

        //将源数据添加边框。这会使点阵数组的尺寸扩大，请小心使用
        public static byte[][] CACU_AroundLine(byte[][] orgData, bool bUp, bool bRight, bool bDown, bool bLeft)
        {
            if (orgData == null)
            {
                MessageBox.Show("数组没有正确初始化");
                return null;
            }

            int orgHeight = orgData.Length;
            int orgWidthAbs = 0;
            for (int i = 0; i < orgHeight; i++)
                orgWidthAbs = orgWidthAbs < orgData[i].Length ? orgData[i].Length : orgWidthAbs;

            int desHeight = orgHeight;
            int desWidth = orgWidthAbs;
            if (bUp)
                desHeight++;
            if (bRight)
                desWidth++;
            if (bDown)
                desHeight++;
            if (bLeft)
                desWidth++;
            //目标数据宽高已经可以确定
            byte[][] tempDesData = new byte[desHeight][];
            for (int k = 0; k < desHeight; k++)
                tempDesData[k] = new byte[desWidth];
            int tempY = 0;
            int tempX = 0;
            if (bUp)
            {
                for (int u = 0; u < desWidth; u++)
                    tempDesData[0][u] = 0xfe;
                tempY++;
            }
            if (bLeft)
            {
                for (int l = 0; l < desHeight; l++)
                    tempDesData[l][0] = 0xfe;
                tempX++;
            }
            if (bDown)
            {
                for (int d = 0; d < desWidth; d++)
                    tempDesData[desHeight - 1][d] = 0xfe;
            }
            if (bRight)
            {
                for (int r = 0; r < desHeight; r++)
                    tempDesData[r][desWidth - 1] = 0xfe;
            }
            //边框已经画好

            //调用函数CACU_CopyData将源数据写入目标函数
            CACU_CopyData(orgData, tempY, tempX, tempDesData);
            return tempDesData;
        }

        //将源数据以中心旋转0°，90°，180°，270°并返回目标数据。为了规范格式起见，必须注意点。像那个为零的时候，也要补零返回。
        public static byte[][] CACU_ClockTurn(byte[][] orgData, int nDegree)
        {
            if (orgData == null)
            {
                MessageBox.Show("数组没有正确初始化");
                return null;
            }
            if (!(nDegree == 0 | nDegree == 90 | nDegree == 180 | nDegree == 270))
            {
                MessageBox.Show("暂不支持任意角度旋转，请在{0,90,180,270}中选择一个");
                return null;
            }

            int orgHeight = orgData.Length;
            int orgWidthAbs = 0;
            for (int i = 0; i < orgHeight; i++)
                orgWidthAbs = orgWidthAbs < orgData[i].Length ? orgData[i].Length : orgWidthAbs;

            if (nDegree == 0)
            {
                byte[][] tempDesData = new byte[orgHeight][];
                for (int i = 0; i < orgHeight; i++)
                {
                    tempDesData[i] = new byte[orgWidthAbs];
                    orgData[i].CopyTo(tempDesData[i], 0);
                }
                return tempDesData;
            }
            else
            {
                //这样速度会快，如果直接嵌套调用，会比较慢
                switch (nDegree)
                {
                    case 90:
                        {
                            byte[][] tempDesData = new byte[orgWidthAbs][];
                            for (int k = 0; k < orgWidthAbs; k++)
                                tempDesData[k] = new byte[orgHeight];
                            for (int i = 0; i < orgHeight; i++)
                            {
                                int orgWidth = orgData[i].Length;
                                for (int j = 0; j < orgWidth; j++)
                                {
                                    tempDesData[j][orgHeight - 1 - i] = orgData[i][j];
                                }
                            }
                            return tempDesData;
                        }
                    case 180:
                        {
                            byte[][] tempDesData = new byte[orgHeight][];
                            for (int i = 0; i < orgHeight; i++)
                            {
                                tempDesData[orgHeight - 1 - i] = new byte[orgWidthAbs];
                                int orgWidth = orgData[i].Length;
                                for (int j = 0; j < orgWidth; j++)
                                {
                                    tempDesData[orgHeight - 1 - i][orgWidthAbs - 1 - j] = orgData[i][j];
                                }
                            }
                            return tempDesData;
                        }
                    case 270:
                        {
                            byte[][] tempDesData = new byte[orgWidthAbs][];
                            for (int k = 0; k < orgWidthAbs; k++)
                                tempDesData[k] = new byte[orgHeight];
                            for (int i = 0; i < orgHeight; i++)
                            {
                                int orgWidth = orgData[i].Length;
                                for (int j = 0; j < orgWidth; j++)
                                {
                                    tempDesData[orgWidthAbs - 1 - j][i] = orgData[i][j];
                                }
                            }
                            return tempDesData;
                        }
                }
            }
            return null;
        }

        //对点阵数据运行加粗算法，返回目标数据。试试左上的加粗算法如何
        public static byte[][] CACU_BlodData(byte[][] orgData)
        {
            if (orgData == null)
            {
                MessageBox.Show("数组没有正确初始化");
                return null;
            }

            int orgHeight = orgData.Length;
            int orgWidthAbs = 0;
            for (int i = 0; i < orgHeight; i++)
                orgWidthAbs = orgWidthAbs < orgData[i].Length ? orgData[i].Length : orgWidthAbs;
            byte[][] tempDesData = new byte[orgHeight][];
            for (int i = 0; i < orgHeight; i++)
            {
                tempDesData[i] = new byte[orgWidthAbs];
                orgData[i].CopyTo(tempDesData[i], 0);
            }
            //复制一份副本

            //下面对副本进行加粗算法
            for (int i = 0; i < orgHeight; i++)
                for (int j = 0; j < orgWidthAbs; j++)
                {
                    if (j > 0)
                        tempDesData[i][j - 1] = ((tempDesData[i][j - 1] == 0) & (tempDesData[i][j] != 0)) ? tempDesData[i][j] : tempDesData[i][j - 1];
                    if (i > 0)
                        tempDesData[i - 1][j] = ((tempDesData[i - 1][j] == 0) & (tempDesData[i][j] != 0)) ? tempDesData[i][j] : tempDesData[i - 1][j];
                }

            return tempDesData;
        }

        //向源数据四周添加白边，单位为像素
        public static byte[][] CACU_AddBlankAroundData(byte[][] orgData, int nUpBlank, int nRightBlank, int nDownBlank, int nLeftBlank)
        {
            if (orgData == null)
            {
                MessageBox.Show("数组没有正确初始化");
                return null;
            }
            if (nUpBlank < 0 | nRightBlank < 0 | nDownBlank < 0 | nLeftBlank < 0)
            {
                MessageBox.Show("添加空白数不能为负");
                return null;
            }

            int orgHeight = orgData.Length;
            int orgWidthAbs = 0;
            for (int i = 0; i < orgHeight; i++)
                orgWidthAbs = orgWidthAbs < orgData[i].Length ? orgData[i].Length : orgWidthAbs;

            int desHeight = orgHeight + nUpBlank + nDownBlank;
            int desWidth = orgWidthAbs + nLeftBlank + nRightBlank;

            //目标数据宽高已经可以确定
            byte[][] tempDesData = new byte[desHeight][];
            for (int k = 0; k < desHeight; k++)
                tempDesData[k] = new byte[desWidth];
            int tempY = nUpBlank;
            int tempX = nLeftBlank;

            //调用函数CACU_CopyData将源数据写入目标数组
            CACU_CopyData(orgData, tempY, tempX, tempDesData);
            return tempDesData;
        }

        //将数据以指定的模式转成可被标准打印机执行的二进制字节数组
        //长和宽都会自动扩充到8的倍数，多余部分用空白填充
        public static byte[] CACU_PixDataToPrintedCommand(byte[][] orgData, int nMode)
        {
            //sent的名字歧义了，别在意。
            if (!(nMode == 0 | nMode == 1 | nMode == 2 | nMode == 3))
            {
                MessageBox.Show("打印模式选择有误！\n0\t正常\n1\t倍宽\n2\t倍高\n3\t倍宽+倍高");
                return null;
            }
            if (orgData == null)
            {
                MessageBox.Show("数组没有正确初始化");
                return null;
            }

            int orgHeight = orgData.Length;
            int orgWidth = orgData[0].Length;
            int desHeight = ((orgHeight + 7) / 8) * 8;//转成8的倍数之后的高和宽，为了速度，这里暂时不新建二维数组，直接用一维
            int desWidth = ((orgWidth + 7) / 8) * 8;//

            long lDataSum = 8 + desHeight * desWidth / 8;//
            byte[] dataToSend = new byte[lDataSum];

            int xl = (desWidth / 8) % 0x00000100;
            int xh = (desWidth / 8) / 0x00000100;
            int yl = desHeight % 0x00000100;
            int yh = desHeight / 0x00000100;
            dataToSend[0] = 0x1d;
            dataToSend[1] = 0x76;
            dataToSend[2] = 0x30;
            dataToSend[3] = (byte)nMode;
            dataToSend[4] = (byte)xl;
            dataToSend[5] = (byte)xh;
            dataToSend[6] = (byte)yl;
            dataToSend[7] = (byte)yh;
            //这个算法比较精简
            byte[] bitToByte = { 0x80, 0x40, 0x20, 0x10, 0x08, 0x04, 0x02, 0x01 };
            for (int i = 0, k = 8; i < desHeight; i++)
            {
                if (i < orgHeight)
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

        /// <summary>
        /// 小板缓冲区小的，分割成一段一段来打印较长图片
        /// </summary>
        /// <param name="orgData"></param>
        /// <param name="nMode"></param>
        /// <returns></returns>
        public static byte[] CACU_PixDataToPrintedCommand_small(byte[][] orgData, int nMode)
        {
            int nHeight = orgData.Length;
            int nWidth = orgData[0].Length;
            int blukHeight = 96;
            int blukSum = (nHeight + blukHeight - 1) / blukHeight;
            int byteLength = 8 * blukSum + (nWidth + 7) / 8 * ((nHeight + 7) / 8 * 8);
            byte[] latestData = new byte[byteLength];
            int offset = 0;
            byte[][] desData;
            desData = getSampleDesData(blukHeight, nWidth);

            for (int i = 0; i < nHeight; i = i + blukHeight)
            {
                if ((nHeight - i > 0) & (nHeight - i < blukHeight))
                    desData = getSampleDesData(nHeight - i, nWidth);

                CACU_CutToData(orgData, i, 0, desData);
                byte[] temp = CACU_PixDataToPrintedCommand(desData, 0);
                temp.CopyTo(latestData, offset);
                offset += temp.Length;
            }
            return latestData;
        }

        //将点阵数据转成RAM位图格式数据并返回

        //将点阵数据转成NV位图格式数据并返回

    }
}
