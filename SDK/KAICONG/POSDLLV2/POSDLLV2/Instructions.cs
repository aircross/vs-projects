using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace POSDLL
{
    /// <summary>
    /// GP80打印指令集
    /// </summary>
    public class GP80
    {
        public byte[] ERROR = { 0x00 };

        /// <summary>
        /// 复位打印机
        /// </summary>
        public byte[] ESC_ALT = { 0x1b, 0x40 };

        /// <summary>
        /// 选择页模式
        /// </summary>
        public byte[] ESC_L = { 0x1b, 0x4c };

        /// <summary>
        /// 页模式下取消打印数据
        /// </summary>
        public byte[] ESC_CAN = { 0x18 };

        /// <summary>
        /// 打印并回到标准模式（在页模式下）
        /// </summary>
        public byte[] FF = { 0x0c };

        /// <summary>
        /// 页模式下打印缓冲区所有内容
        /// 只在页模式下有效，不清除缓冲区内容
        /// </summary>
        public byte[] ESC_FF = { 0x1b, 0x0c };

        /// <summary>
        /// 选择标准模式
        /// </summary>
        public byte[] ESC_S = { 0x1b, 0x53 };

        /// <summary>
        /// 设置横向和纵向移动单位
        /// 分别将横向移动单位近似设置成1/x英寸，纵向移动单位设置成1/y英寸。
        /// 当x和y为0时，x和y被设置成默认值200。
        /// </summary>
        public byte[] GS_P_x_y = { 0x1d, 0x50, 0x00, 0x00 };

        /// <summary>
        /// 选择国际字符集，值可以为0-15。默认值为0（美国）。
        /// </summary>
        public byte[] ESC_R_n = { 0x1b, 0x52, 0x00 };

        /// <summary>
        /// 选择字符代码表，值可以为0-10,16-19。默认值为0。 
        /// </summary>
        public byte[] ESC_t_n = { 0x1b, 0x74, 0x00 };

        /// <summary>
        /// 打印并换行
        /// </summary>
        public byte[] LF = { 0x0a };

        /// <summary>
        /// 设置行间距为[n*纵向或横向移动单位]
        /// </summary>
        public byte[] ESC_3_n = { 0x1b, 0x33, 0x00 };

        /// <summary>
        /// 设置字符右间距，当字符放大时，右间距也随之放大相同倍数
        /// </summary>
        public byte[] ESC_SP_n = { 0x1b, 0x20, 0x00 };

        /// <summary>
        /// 在指定的钱箱插座引脚产生设定的开启脉冲。
        /// </summary>
        public byte[] DLE_DC4_n_m_t = { 0x10, 0x14, 0x01, 0x00, 0x01 };

        /// <summary>
        /// 选择切纸模式并直接切纸，0为全切，1为半切
        /// </summary>
        public byte[] GS_V_m = { 0x1d, 0x56, 0x00 };

        /// <summary>
        /// 进纸并且半切。
        /// </summary>
        public byte[] GS_V_m_n = { 0x1d, 0x56, 0x42, 0x00 };

        /// <summary>
        /// 设置打印区域宽度，该命令仅在标准模式行首有效。
        /// 如果【左边距+打印区域宽度】超出可打印区域，则打印区域宽度为可打印区域-左边距。
        /// </summary>
        public byte[] GS_W_nL_nH = { 0x1d, 0x57, 0x76, 0x02 };

        /// <summary>
        /// 设置绝对打印位置
        /// 将当前位置设置到距离行首（nL + nH x 256）处。
        /// 如果设置位置在指定打印区域外，该命令被忽略
        /// </summary>
        public byte[] ESC_dollors_nL_nH ={ 0x1b, 0x24, 0x00, 0x00 };

        /// <summary>
        /// 选择字符大小
        /// 0-3位选择字符高度，4-7位选择字符宽度
        /// 范围为从0-7
        /// </summary>
        public byte[] GS_exclamationmark_n ={ 0x1d, 0x21, 0x00 };

        /// <summary>
        /// 选择字体
        /// 0 标准ASCII字体
        /// 1 压缩ASCII字体
        /// </summary>
        public byte[] ESC_M_n = { 0x1b, 0x4d, 0x00 };

        /// <summary>
        /// 选择/取消加粗模式
        /// n的最低位为0，取消加粗模式
        /// n最低位为1，选择加粗模式
        /// 与0x01即可
        /// </summary>
        public byte[] GS_E_n = { 0x1b, 0x45, 0x00 };

        /// <summary>
        /// 选择/取消下划线模式
        /// 0 取消下划线模式
        /// 1 选择下划线模式（1点宽）
        /// 2 选择下划线模式（2点宽）
        /// </summary>
        public byte[] ESC_line_n = { 0x1b, 0x2d, 0x00 };

        /// <summary>
        /// 选择/取消倒置打印模式
        /// 0 为取消倒置打印
        /// 1 选择倒置打印
        /// </summary>
        public byte[] ESC_lbracket_n = { 0x1b, 0x7b, 0x00 };

        /// <summary>
        /// 选择/取消黑白反显打印模式
        /// n的最低位为0是，取消反显打印
        /// n的最低位为1时，选择反显打印
        /// </summary>
        public byte[] GS_B_n = { 0x1d, 0x42, 0x00 };

        /// <summary>
        /// 选择/取消顺时针旋转90度
        /// </summary>
        public byte[] ESC_V_n = { 0x1b, 0x56, 0x00 };

        /// <summary>
        /// 打印下载位图
        /// 0 正常
        /// 1 倍宽
        /// 2 倍高
        /// 3 倍宽、倍高
        /// </summary>
        public byte[] GS_backslash_m = { 0x1d, 0x2f, 0x00 };

        /// <summary>
        /// 打印NV位图
        /// 以m指定的模式打印flash中图号为n的位图
        /// 1≤n≤255
        /// </summary>
        public byte[] FS_p_n_m ={ 0x1c, 0x70, 0x01, 0x00 };

        /// <summary>
        /// 选择HRI字符的打印位置
        /// 0 不打印
        /// 1 条码上方
        /// 2 条码下方
        /// 3 条码上、下方都打印
        /// </summary>
        public byte[] GS_H_n = { 0x1d, 0x48, 0x00 };

        /// <summary>
        /// 选择HRI使用字体
        /// 0 标准ASCII字体
        /// 1 压缩ASCII字体
        /// </summary>
        public byte[] GS_f_n = { 0x1d, 0x66, 0x00 };

        /// <summary>
        /// 选择条码高度
        /// 1≤n≤255
        /// 默认值 n=162
        /// </summary>
        public byte[] GS_h_n = { 0x1d, 0x68, 0xa2 };

        /// <summary>
        /// 设置条码宽度
        /// 2≤n≤6
        /// 默认值 n=3
        /// </summary>
        public byte[] GS_w_n = { 0x1d, 0x77, 0x03 };

        /// <summary>
        /// 打印条码
        /// 0x41≤m≤0x49
        /// n的取值有条码类型m决定
        /// </summary>
        public byte[] GS_k_m_n_ = { 0x1d, 0x6b, 0x41, 0x0c };

        /// <summary>
        /// 页模式下设置打印区域
        /// 该命令在标准模式下只设置内部标志位，不影响打印
        /// </summary>
        public byte[] ESC_W_xL_xH_yL_yH_dxL_dxH_dyL_dyH ={ 0x1b, 0x57, 0x00, 0x00, 0x00, 0x00, 0x48, 0x02, 0xb0, 0x04 };

        /// <summary>
        /// 在页模式下选择打印区域方向
        /// 0≤n≤3
        /// </summary>
        public byte[] ESC_T_n ={ 0x1b, 0x54, 0x00 };

        /// <summary>
        /// 页模式下设置纵向绝对位置
        /// 这条命令只有在页模式下有效
        /// </summary>
        public byte[] GS_dollors_nL_nH = { 0x1d, 0x24, 0x00, 0x00 };

        /// <summary>
        /// 页模式下设置纵向相对位置
        /// 页模式下，以当前点位参考点设置纵向移动距离
        /// 这条命令只在页模式下有效
        /// </summary>
        public byte[] GS_backslash_nL_nH ={ 0x1d, 0x5c, 0x00, 0x00 };

        /// <summary>
        /// 选择/取消汉字下划线模式
        /// </summary>
        public byte[] FS_line_n = { 0x1c, 0x2d, 0x00 };

        /// <summary>
        /// 实时传送状态
        /// n=1：传送打印机状态
        /// n=2：传送脱机状态
        /// n=3：传送错误状态
        /// n=4：传送纸传感器状态
        /// </summary>
        public byte[] DLE_EOT_n = { 0x10, 0x04, 0x01 };

        /// <summary>
        /// 设置左边距
        /// 如果超出可打印范围，则取最大可打印范围
        /// </summary>
        public byte[] GS_L_nL_nH ={ 0x1d, 0x4c, 0x00, 0x00 };


        /// <summary>
        /// 设置相对横向打印位置
        /// </summary>
        public byte[] ESC_backslash_nL_nH ={ 0x1b, 0x5c, 0x00, 0x00 };


        /// <summary>
        /// 打印并换行
        /// 这条命令在标准模式下打印缓冲区数据并移动到下一行
        /// 在页模式下，只是移动到下一行
        /// </summary>
        /// <returns></returns>
        public byte[] FeedLine()
        {
            return LF;
        }

        /// <summary>
        /// 设置横纵向移动单位为(25.4/x)mm
        /// 行高和字符间距
        /// 一个打印点和移动单位不一定相同
        /// </summary>
        /// <returns></returns>
        public byte[] SetMULSRS(int nMotionUnitx, int nMotionUnity, int nRightSpacing, int nLineSpacing)
        {
            if (nMotionUnitx < 0 | nMotionUnitx > 255 | nMotionUnity < 0 | nMotionUnity > 255 | nRightSpacing < 0 | nRightSpacing > 255 | nLineSpacing < 0 | nLineSpacing > 255)
            {
                MessageBox.Show("输入值超出范围");
                return ERROR;
            }

            byte[] data = new byte[10];
            int offset = 0;
            GS_P_x_y[2] = (byte)nMotionUnitx;
            GS_P_x_y[3] = (byte)nMotionUnity;
            GS_P_x_y.CopyTo(data, offset);
            offset += GS_P_x_y.Length;
            ESC_SP_n[2] = (byte)nRightSpacing;
            ESC_SP_n.CopyTo(data, offset);
            offset += ESC_SP_n.Length;
            ESC_3_n[2] = (byte)nLineSpacing;
            ESC_3_n.CopyTo(data, offset);

            return data;
        }

        /// <summary>
        /// 标准模式下设置左边距和打印区域宽度
        /// 该命令只在标准模式的行首有效
        /// </summary>
        /// <returns></returns>
        public byte[] S_SetLMarginToPrintW(int nLeftMargin, int nPrintWidth)
        {
            if (nLeftMargin < 0 | nLeftMargin > 65535 | nPrintWidth < 0 | nPrintWidth > 65535)
            {
                MessageBox.Show("输入值超出范围");
                return ERROR;
            }

            byte[] data = new byte[8];
            int offset = 0;
            GS_L_nL_nH[2] = (byte)(nLeftMargin % 0x100);
            GS_L_nL_nH[3] = (byte)(nLeftMargin / 0x100);
            GS_L_nL_nH.CopyTo(data, offset);
            offset += GS_L_nL_nH.Length;
            GS_W_nL_nH[2] = (byte)(nPrintWidth % 0x100);
            GS_W_nL_nH[3] = (byte)(nPrintWidth / 0x100);
            GS_W_nL_nH.CopyTo(data, offset);

            return data;
        }

        /// <summary>
        /// pszString要输出的字符串，nOrgx绝对横向打印位置
        /// </summary>
        /// <param name="pszString"></param>
        /// <param name="nOrgx"></param>
        /// <param name="nWidthTimes"></param>
        /// <param name="nHeightTimes"></param>
        /// <param name="nFontType"></param>
        /// <param name="nFontStyle"></param>
        /// <returns></returns>
        public byte[] S_TextOut(string pszString, int nOrgx, int nWidthTimes, int nHeightTimes, int nFontType, int nFontStyle)
        {
            if (nOrgx > 65535 | nOrgx < 0 |
                nWidthTimes > 7 | nWidthTimes < 0 | nHeightTimes > 7 | nHeightTimes < 0 |
                nFontType < 0 | nFontType > 4)
            {
                MessageBox.Show("参数出错");
                return ERROR;
            }

            byte[] pbString = Encoding.Default.GetBytes(pszString);
            int dataLength = pbString.Length + ESC_dollors_nL_nH.Length + GS_exclamationmark_n.Length +
                ESC_M_n.Length + GS_E_n.Length + FS_line_n.Length +
                ESC_lbracket_n.Length + GS_B_n.Length + ESC_V_n.Length;

            byte[] data = new byte[dataLength];
            int offset = 0;
            ESC_dollors_nL_nH[2] = (byte)(nOrgx % 0x100);
            ESC_dollors_nL_nH[3] = (byte)(nOrgx / 0x100);
            ESC_dollors_nL_nH.CopyTo(data, offset);
            offset += ESC_dollors_nL_nH.Length;
            byte[] intToWidth = { 0x00, 0x10, 0x20, 0x30, 0x40, 0x50, 0x60, 0x70 };
            byte[] intToHeight = { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07 };
            GS_exclamationmark_n[2] = (byte)(intToWidth[nWidthTimes] + intToHeight[nHeightTimes]);
            GS_exclamationmark_n.CopyTo(data, offset);
            offset += GS_exclamationmark_n.Length;
            ESC_M_n[2] = (byte)nFontType;
            ESC_M_n.CopyTo(data, offset);
            offset += ESC_M_n.Length;

            //字体风格
            //暂不支持平滑处理
            GS_E_n[2] = (byte)((nFontStyle >> 3) & 0x01);
            GS_E_n.CopyTo(data, offset);
            offset += GS_E_n.Length;
            FS_line_n[2] = (byte)((nFontStyle >> 7) & 0x03);
            FS_line_n.CopyTo(data, offset);
            offset += FS_line_n.Length;
            ESC_lbracket_n[2] = (byte)((nFontStyle >> 9) & 0x01);
            ESC_lbracket_n.CopyTo(data, offset);
            offset += ESC_lbracket_n.Length;
            GS_B_n[2] = (byte)((nFontStyle >> 10) & 0x01);
            GS_B_n.CopyTo(data, offset);
            offset += GS_B_n.Length;
            ESC_V_n[2] = (byte)((nFontStyle >> 12) & 0x01);
            ESC_V_n.CopyTo(data, offset);
            offset += ESC_V_n.Length;
            pbString.CopyTo(data, offset);

            return data;
        }

        public byte[] S_TextOut(string pszString, Encoding POSEncoding, int nOrgx, int nWidthTimes, int nHeightTimes, int nFontType, int nFontStyle)
        {
            if (nOrgx > 65535 | nOrgx < 0 |
                nWidthTimes > 7 | nWidthTimes < 0 | nHeightTimes > 7 | nHeightTimes < 0 |
                nFontType < 0 | nFontType > 4)
            {
                MessageBox.Show("参数出错");
                return ERROR;
            }

            byte[] pbString = Encoding.Default.GetBytes(pszString);
            if (POSEncoding != Encoding.Default)
                pbString = Encoding.Convert(Encoding.Default, POSEncoding, pbString);

            int dataLength = pbString.Length + ESC_dollors_nL_nH.Length + GS_exclamationmark_n.Length +
                ESC_M_n.Length + GS_E_n.Length + FS_line_n.Length +
                ESC_lbracket_n.Length + GS_B_n.Length + ESC_V_n.Length;

            byte[] data = new byte[dataLength];
            int offset = 0;
            ESC_dollors_nL_nH[2] = (byte)(nOrgx % 0x100);
            ESC_dollors_nL_nH[3] = (byte)(nOrgx / 0x100);
            ESC_dollors_nL_nH.CopyTo(data, offset);
            offset += ESC_dollors_nL_nH.Length;
            byte[] intToWidth = { 0x00, 0x10, 0x20, 0x30, 0x40, 0x50, 0x60, 0x70 };
            byte[] intToHeight = { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07 };
            GS_exclamationmark_n[2] = (byte)(intToWidth[nWidthTimes] + intToHeight[nHeightTimes]);
            GS_exclamationmark_n.CopyTo(data, offset);
            offset += GS_exclamationmark_n.Length;
            ESC_M_n[2] = (byte)nFontType;
            ESC_M_n.CopyTo(data, offset);
            offset += ESC_M_n.Length;

            //字体风格
            //暂不支持平滑处理
            GS_E_n[2] = (byte)((nFontStyle >> 3) & 0x01);
            GS_E_n.CopyTo(data, offset);
            offset += GS_E_n.Length;
            FS_line_n[2] = (byte)((nFontStyle >> 7) & 0x03);
            FS_line_n.CopyTo(data, offset);
            offset += FS_line_n.Length;
            ESC_lbracket_n[2] = (byte)((nFontStyle >> 9) & 0x01);
            ESC_lbracket_n.CopyTo(data, offset);
            offset += ESC_lbracket_n.Length;
            GS_B_n[2] = (byte)((nFontStyle >> 10) & 0x01);
            GS_B_n.CopyTo(data, offset);
            offset += GS_B_n.Length;
            ESC_V_n[2] = (byte)((nFontStyle >> 12) & 0x01);
            ESC_V_n.CopyTo(data, offset);
            offset += ESC_V_n.Length;
            pbString.CopyTo(data, offset);

            return data;
        }

        public byte[] S_SetBarcode(string pszInfoBuffer, int nOrgx, int nType, int nWidthX, int nHeight, int nHriFontType, int nHriFontPosition, int nBytesToPrint)
        {
            if (nOrgx < 0 | nOrgx > 65535 | nType < 0x41 | nType > 0x49 | nWidthX < 2 | nWidthX > 6 | nHeight < 1 | nHeight > 255 | (pszInfoBuffer.Length != nBytesToPrint))
                return ERROR;

            byte[] pbString = Encoding.Default.GetBytes(pszInfoBuffer);
            int dataLength = ESC_dollors_nL_nH.Length + GS_w_n.Length +
                GS_h_n.Length + GS_f_n.Length +
                GS_H_n.Length + GS_k_m_n_.Length + pbString.Length;

            byte[] data = new byte[dataLength];
            int offset = 0;
            ESC_dollors_nL_nH[2] = (byte)(nOrgx % 0x100);
            ESC_dollors_nL_nH[3] = (byte)(nOrgx / 0x100);
            ESC_dollors_nL_nH.CopyTo(data, offset);
            offset += ESC_dollors_nL_nH.Length;
            GS_w_n[2] = (byte)nWidthX;
            GS_w_n.CopyTo(data, offset);
            offset += GS_w_n.Length;
            GS_h_n[2] = (byte)nHeight;
            GS_h_n.CopyTo(data, offset);
            offset += GS_h_n.Length;
            GS_f_n[2] = (byte)(nHriFontType & 0x01);
            GS_f_n.CopyTo(data, offset);
            offset += GS_f_n.Length;
            GS_H_n[2] = (byte)(nHriFontPosition & 0x03);
            GS_H_n.CopyTo(data, offset);
            offset += GS_H_n.Length;
            GS_k_m_n_[2] = (byte)nType;
            GS_k_m_n_[3] = (byte)pbString.Length;
            GS_k_m_n_.CopyTo(data, offset);
            offset += GS_k_m_n_.Length;
            pbString.CopyTo(data, offset);

            return data;
        }
    

    
    
    }

    /// <summary>
    /// EPSON打印指令集
    /// </summary>
    public class EPSON
    {
        private byte[] ERROR = { 0x00 };

        /// <summary>
        /// 复位打印机
        /// </summary>
        private byte[] ESC_ALT = { 0x1b, 0x40 };

        /// <summary>
        /// 选择国际字符集，值可以为0-15。默认值为0（美国）。
        /// </summary>
        private byte[] ESC_R_n = { 0x1b, 0x52, 0x00 };

        /// <summary>
        /// 选择字符代码表，值可以为0-10,16-19。默认值为0。 
        /// </summary>
        private byte[] ESC_t_n = { 0x1b, 0x74, 0x00 };

        /// <summary>
        /// 打印并换行
        /// </summary>
        private byte[] LF = { 0x0a };

        /// <summary>
        /// 设置行间距为[n*纵向或横向移动单位]英寸
        /// </summary>
        private byte[] ESC_3_n = { 0x1b, 0x33, 0x00 };

        /// <summary>
        /// 设置字符右间距，当字符放大时，右间距也随之放大相同倍数
        /// </summary>
        private byte[] ESC_SP_n = { 0x1b, 0x20, 0x00 };

        /// <summary>
        /// 设置汉字字符左右间距
        /// </summary>
        private byte[] FS_S_n1_n2 = { 0x1c, 0x53, 0x00, 0x00 };

        /// <summary>
        /// 设置打印区域宽度，该命令仅在标准模式行首有效。
        /// 如果【左边距+打印区域宽度】超出可打印区域，则打印区域宽度为可打印区域-左边距。
        /// </summary>
        private byte[] GS_W_nL_nH = { 0x1d, 0x57, 0x80, 0x01 };

        /// <summary>
        /// 设置绝对打印位置
        /// 将当前位置设置到距离行首（nL + nH x 256）处。
        /// 如果设置位置在指定打印区域外，该命令被忽略
        /// </summary>
        private byte[] ESC_dollors_nL_nH ={ 0x1b, 0x24, 0x00, 0x00 };

        /// <summary>
        /// 选择字符大小
        /// 0-3位选择字符高度，4-7位选择字符宽度
        /// 范围为从0-7
        /// </summary>
        private byte[] GS_exclamationmark_n ={ 0x1d, 0x21, 0x00 };

        /// <summary>
        /// 选择字体
        /// 0 标准ASCII字体
        /// 1 压缩ASCII字体
        /// </summary>
        private byte[] ESC_M_n = { 0x1b, 0x4d, 0x00 };

        /// <summary>
        /// 选择/取消加粗模式
        /// n的最低位为0，取消加粗模式
        /// n最低位为1，选择加粗模式
        /// 与0x01即可
        /// </summary>
        private byte[] GS_E_n = { 0x1b, 0x45, 0x00 };

        /// <summary>
        /// 选择/取消下划线模式
        /// 0 取消下划线模式
        /// 1 选择下划线模式（1点宽）
        /// 2 选择下划线模式（2点宽）
        /// </summary>
        private byte[] ESC_line_n = { 0x1b, 0x2d, 0x00 };

        /// <summary>
        /// 选择/取消倒置打印模式
        /// 0 为取消倒置打印
        /// 1 选择倒置打印
        /// </summary>
        private byte[] ESC_lbracket_n = { 0x1b, 0x7b, 0x00 };

        /// <summary>
        /// 选择/取消黑白反显打印模式
        /// n的最低位为0是，取消反显打印
        /// n的最低位为1时，选择反显打印
        /// </summary>
        private byte[] GS_B_n = { 0x1d, 0x42, 0x00 };

        /// <summary>
        /// 选择/取消顺时针旋转90度
        /// </summary>
        private byte[] ESC_V_n = { 0x1b, 0x56, 0x00 };

        /// <summary>
        /// 选择对齐方式
        /// </summary>
        private byte[] ESC_a_n = { 0x1b, 0x61, 0x00 };

        /// <summary>
        /// 打印下载位图
        /// 0 正常
        /// 1 倍宽
        /// 2 倍高
        /// 3 倍宽、倍高
        /// </summary>
        private byte[] GS_backslash_m = { 0x1d, 0x2f, 0x00 };

        /// <summary>
        /// 打印NV位图
        /// 以m指定的模式打印flash中图号为n的位图
        /// 1≤n≤255
        /// </summary>
        private byte[] FS_p_n_m ={ 0x1c, 0x70, 0x01, 0x00 };

        /// <summary>
        /// 选择HRI字符的打印位置
        /// 0 不打印
        /// 1 条码上方
        /// 2 条码下方
        /// 3 条码上、下方都打印
        /// </summary>
        private byte[] GS_H_n = { 0x1d, 0x48, 0x00 };

        /// <summary>
        /// 选择HRI使用字体
        /// 0 标准ASCII字体
        /// 1 压缩ASCII字体
        /// </summary>
        private byte[] GS_f_n = { 0x1d, 0x66, 0x00 };

        /// <summary>
        /// 选择条码高度
        /// 1≤n≤255
        /// 默认值 n=162
        /// </summary>
        private byte[] GS_h_n = { 0x1d, 0x68, 0xa2 };

        /// <summary>
        /// 设置条码宽度
        /// 2≤n≤6
        /// 默认值 n=3
        /// </summary>
        private byte[] GS_w_n = { 0x1d, 0x77, 0x03 };

        /// <summary>
        /// 打印条码
        /// 0x41≤m≤0x49
        /// n的取值有条码类型m决定
        /// </summary>
        private byte[] GS_k_m_n_ = { 0x1d, 0x6b, 0x41, 0x0c };

        /// <summary>
        /// 选择/取消汉字下划线模式
        /// </summary>
        private byte[] FS_line_n = { 0x1c, 0x2d, 0x00 };

        /// <summary>
        /// 选择/取消下划线模式（不影响汉字字符设定）
        /// </summary>
        private byte[] ESC_cross_n = { 0x1b, 0x2d, 0x00 };

        /// <summary>
        /// 实时传送状态
        /// n=1：传送打印机状态
        /// n=2：传送脱机状态
        /// n=3：传送错误状态
        /// n=4：传送纸传感器状态
        /// </summary>
        private byte[] DLE_EOT_n = { 0x10, 0x04, 0x01 };

        /// <summary>
        /// 设置左边距
        /// 如果超出可打印范围，则取最大可打印范围
        /// </summary>
        private byte[] GS_L_nL_nH ={ 0x1d, 0x4c, 0x00, 0x00 };

        /// <summary>
        /// m=0x61
        /// 1≤v小于等于17
        /// 1≤r≤4
        /// 打印二维码
        /// </summary>
        private byte[] GS_k_m_v_r_nL_nH = { 0x1d, 0x6b, 0x61, 0x07, 0x02, 0x00, 0x00 };



        /// <summary>
        /// 打印并换行
        /// 这条命令在标准模式下打印缓冲区数据并移动到下一行
        /// 在页模式下，只是移动到下一行
        /// </summary>
        /// <returns></returns>
        public byte[] FeedLine()
        {
            return LF;
        }

        /// <summary>
        /// 复位打印机
        /// </summary>
        /// <returns></returns>
        public byte[] Reset()
        {
            return ESC_ALT;
        }
        /// <summary>
        /// 选择国际字符集和字符代码页
        /// </summary>
        /// <param name="nCharSet"></param>
        /// <param name="nCodePage"></param>
        /// <returns></returns>
        public byte[] SetCharSetAndCodePage(int nCharSet, int nCodePage)
        {
            if (nCharSet < 0 | nCharSet > 15 | nCodePage < 0 | nCodePage > 19 | (nCodePage > 10 & nCodePage < 16))
                return ERROR;

            byte[] data = new byte[ESC_R_n.Length + ESC_t_n.Length];
            ESC_R_n[2] = (byte)nCharSet;
            ESC_R_n.CopyTo(data, 0);
            ESC_t_n[2] = (byte)nCodePage;
            ESC_t_n.CopyTo(data, ESC_R_n.Length);

            return data;
        }

        /// <summary>
        /// 设置行高和字符间距
        /// （字符间距包括ASCII字符和汉字字符）
        /// 一个打印点和移动单位不一定相同
        /// </summary>
        /// <returns></returns>
        public byte[] SetLSRS(int nRightSpacing, int nLineSpacing)
        {
            if (nRightSpacing < 0 | nRightSpacing > 255 | nLineSpacing < 0 | nLineSpacing > 255)
            {
                MessageBox.Show("输入值超出范围");
                return ERROR;
            }

            byte[] data = new byte[10];
            int offset = 0;
            ESC_SP_n[2] = (byte)nRightSpacing;
            ESC_SP_n.CopyTo(data, offset);
            offset += ESC_SP_n.Length;
            FS_S_n1_n2[3] = (byte)nRightSpacing;
            FS_S_n1_n2.CopyTo(data, offset);
            offset += FS_S_n1_n2.Length;
            ESC_3_n[2] = (byte)nLineSpacing;
            ESC_3_n.CopyTo(data, offset);

            return data;
        }

        /// <summary>
        /// 标准模式下设置左边距和打印区域宽度
        /// 该命令只在标准模式的行首有效
        /// 值*移动单位
        /// </summary>
        /// <returns></returns>
        public byte[] SetLMarginToPrintW(int nLeftMargin, int nPrintWidth)
        {
            if (nLeftMargin < 0 | nLeftMargin > 65535 | nPrintWidth < 0 | nPrintWidth > 65535)
            {
                MessageBox.Show("输入值超出范围");
                return ERROR;
            }

            byte[] data = new byte[8];
            int offset = 0;
            GS_L_nL_nH[2] = (byte)(nLeftMargin % 0x100);
            GS_L_nL_nH[3] = (byte)(nLeftMargin / 0x100);
            GS_L_nL_nH.CopyTo(data, offset);
            offset += GS_L_nL_nH.Length;
            GS_W_nL_nH[2] = (byte)(nPrintWidth % 0x100);
            GS_W_nL_nH[3] = (byte)(nPrintWidth / 0x100);
            GS_W_nL_nH.CopyTo(data, offset);

            return data;
        }

        /// <summary>
        /// pszString要输出的字符串，nOrgx绝对横向打印位置
        /// </summary>
        /// <param name="pszString"></param>
        /// <param name="nOrgx"></param>
        /// <param name="nWidthTimes"></param>
        /// <param name="nHeightTimes"></param>
        /// <param name="nFontType"></param>
        /// <param name="nFontStyle"></param>
        /// <returns></returns>
        public byte[] TextOut(string pszString, int nOrgx, int nWidthTimes, int nHeightTimes, int nFontType, int nFontStyle)
        {
            if (nOrgx > 65535 | nOrgx < 0 |
                nWidthTimes > 7 | nWidthTimes < 0 | nHeightTimes > 7 | nHeightTimes < 0 |
                nFontType < 0 | nFontType > 4)
            {
                MessageBox.Show("参数出错");
                return ERROR;
            }

            byte[] pbString = Encoding.Default.GetBytes(pszString);
            int dataLength = pbString.Length + ESC_dollors_nL_nH.Length + GS_exclamationmark_n.Length +
                ESC_M_n.Length + GS_E_n.Length + FS_line_n.Length + ESC_cross_n.Length +
                ESC_lbracket_n.Length + GS_B_n.Length + ESC_V_n.Length + ESC_a_n.Length;

            byte[] data = new byte[dataLength];
            int offset = 0;
            ESC_dollors_nL_nH[2] = (byte)(nOrgx % 0x100);
            ESC_dollors_nL_nH[3] = (byte)(nOrgx / 0x100);
            ESC_dollors_nL_nH.CopyTo(data, offset);
            offset += ESC_dollors_nL_nH.Length;
            byte[] intToWidth = { 0x00, 0x10, 0x20, 0x30, 0x40, 0x50, 0x60, 0x70 };
            byte[] intToHeight = { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07 };
            GS_exclamationmark_n[2] = (byte)(intToWidth[nWidthTimes] + intToHeight[nHeightTimes]);
            GS_exclamationmark_n.CopyTo(data, offset);
            offset += GS_exclamationmark_n.Length;
            ESC_M_n[2] = (byte)nFontType;
            ESC_M_n.CopyTo(data, offset);
            offset += ESC_M_n.Length;

            //字体风格
            //暂不支持平滑处理
            GS_E_n[2] = (byte)((nFontStyle >> 3) & 0x01);
            GS_E_n.CopyTo(data, offset);
            offset += GS_E_n.Length;
            FS_line_n[2] = (byte)((nFontStyle >> 7) & 0x03);
            FS_line_n.CopyTo(data, offset);
            offset += FS_line_n.Length;
            ESC_cross_n[2] = (byte)((nFontStyle >> 7) & 0x03);
            ESC_cross_n.CopyTo(data, offset);
            offset += ESC_cross_n.Length;
            ESC_lbracket_n[2] = (byte)((nFontStyle >> 9) & 0x01);
            ESC_lbracket_n.CopyTo(data, offset);
            offset += ESC_lbracket_n.Length;
            GS_B_n[2] = (byte)((nFontStyle >> 10) & 0x01);
            GS_B_n.CopyTo(data, offset);
            offset += GS_B_n.Length;
            ESC_V_n[2] = (byte)((nFontStyle >> 12) & 0x01);
            ESC_V_n.CopyTo(data, offset);
            offset += ESC_V_n.Length;
            ESC_a_n[2] = (byte)((nFontStyle >> 14) & 0x03);
            ESC_a_n.CopyTo(data, offset);
            offset += ESC_a_n.Length;
            pbString.CopyTo(data, offset);

            return data;
        }

        public byte[] SetBarcode(string pszInfoBuffer, int nOrgx, int nType, int nWidthX, int nHeight, int nHriFontType, int nHriFontPosition, int nBytesToPrint)
        {
            if (nOrgx < 0 | nOrgx > 65535 | nType < 0x41 | nType > 0x49 | nWidthX < 2 | nWidthX > 6 | nHeight < 1 | nHeight > 255 | (pszInfoBuffer.Length != nBytesToPrint))
                return ERROR;

            byte[] pbString = Encoding.Default.GetBytes(pszInfoBuffer);
            int dataLength = ESC_dollors_nL_nH.Length + GS_w_n.Length +
                GS_h_n.Length + GS_f_n.Length +
                GS_H_n.Length + GS_k_m_n_.Length + pbString.Length;

            byte[] data = new byte[dataLength];
            int offset = 0;
            ESC_dollors_nL_nH[2] = (byte)(nOrgx % 0x100);
            ESC_dollors_nL_nH[3] = (byte)(nOrgx / 0x100);
            ESC_dollors_nL_nH.CopyTo(data, offset);
            offset += ESC_dollors_nL_nH.Length;
            GS_w_n[2] = (byte)nWidthX;
            GS_w_n.CopyTo(data, offset);
            offset += GS_w_n.Length;
            GS_h_n[2] = (byte)nHeight;
            GS_h_n.CopyTo(data, offset);
            offset += GS_h_n.Length;
            GS_f_n[2] = (byte)(nHriFontType & 0x01);
            GS_f_n.CopyTo(data, offset);
            offset += GS_f_n.Length;
            GS_H_n[2] = (byte)(nHriFontPosition & 0x03);
            GS_H_n.CopyTo(data, offset);
            offset += GS_H_n.Length;
            GS_k_m_n_[2] = (byte)nType;
            GS_k_m_n_[3] = (byte)pbString.Length;
            GS_k_m_n_.CopyTo(data, offset);
            offset += GS_k_m_n_.Length;
            pbString.CopyTo(data, offset);

            return data;
        }

        public byte[] SetQRCode(string pszInfoBuffer, int nOrgx, int nType)
        {
            if (nOrgx < 0 | nOrgx > 65535 | (nType != 0x61))
                return ERROR;

            byte[] pbString = Encoding.Default.GetBytes(pszInfoBuffer);
            int dataLength = ESC_dollors_nL_nH.Length + GS_k_m_v_r_nL_nH.Length + pbString.Length;

            byte[] data = new byte[dataLength];
            int offset = 0;
            ESC_dollors_nL_nH[2] = (byte)(nOrgx % 0x100);
            ESC_dollors_nL_nH[3] = (byte)(nOrgx / 0x100);
            ESC_dollors_nL_nH.CopyTo(data, offset);
            GS_k_m_v_r_nL_nH[5] = (byte)(pbString.Length % 0x100);
            GS_k_m_v_r_nL_nH[6] = (byte)(pbString.Length / 0x100);
            GS_k_m_v_r_nL_nH.CopyTo(data, offset);
            offset += GS_k_m_v_r_nL_nH.Length;
            pbString.CopyTo(data, offset);

            return data;
        }

        /// <summary>
        /// 下载到RAM位图，暂时只支持一张图片，第二个参数将会被忽略。
        /// </summary>
        /// <param name="pszPath"></param>
        /// <param name="nID"></param>
        /// <returns></returns>
        public byte[] PreDownloadBmpToRAM(string pszPath, int nID)
        {
            return TEXTANDPIC.TAC_PreDownloadBmpToRam(pszPath);
        }

        /// <summary>
        /// 第二个参数被忽略，只接受第一个参数
        /// </summary>
        /// <param name="pszPaths"></param>
        /// <param name="nCount"></param>
        /// <returns></returns>
        public byte[] PreDownloadBmpsToFlash(string[] pszPaths, int nCount)
        {
            return TEXTANDPIC.TAC_PreDownloadBmpsToFlash(pszPaths);
        }

        /// <summary>
        /// nID被忽略，只支持一张图片
        /// </summary>
        /// <param name="nID"></param>
        /// <param name="nOrgx"></param>
        /// <param name="nMode"></param>
        /// <returns></returns>
        public byte[] PrintBmpInRAM(int nID, int nOrgx, int nMode)
        {
            if (nOrgx < 0 | nOrgx > 65535)
                return ERROR;

            int dataLength = ESC_dollors_nL_nH.Length + GS_backslash_m.Length;
            byte[] data = new byte[dataLength];
            int offset = 0;
            ESC_dollors_nL_nH[2] = (byte)(nOrgx % 0x100);
            ESC_dollors_nL_nH[3] = (byte)(nOrgx / 0x100);
            ESC_dollors_nL_nH.CopyTo(data, offset);
            offset += ESC_dollors_nL_nH.Length;
            GS_backslash_m[2] = (byte)(nMode & 0x03);
            GS_backslash_m.CopyTo(data, offset);

            return data;
        }

        /// <summary>
        /// 打印FLASH中的位图
        /// </summary>
        /// <param name="nID"></param>
        /// <param name="nOrgx"></param>
        /// <param name="nMode"></param>
        /// <returns></returns>
        public byte[] PrintBmpInFlash(int nID, int nOrgx, int nMode)
        {
            if (nOrgx < 0 | nOrgx > 65535 | nID < 1 | nID > 255)
                return ERROR;

            int dataLength = ESC_dollors_nL_nH.Length + FS_p_n_m.Length;
            byte[] data = new byte[dataLength];
            int offset = 0;
            ESC_dollors_nL_nH[2] = (byte)(nOrgx % 0x100);
            ESC_dollors_nL_nH[3] = (byte)(nOrgx / 0x100);
            ESC_dollors_nL_nH.CopyTo(data, offset);
            offset += ESC_dollors_nL_nH.Length;
            FS_p_n_m[2] = (byte)(nID);
            FS_p_n_m[3] = (byte)(nMode & 0x03);
            FS_p_n_m.CopyTo(data, offset);

            return data;
        }

        /// <summary>
        /// 打印光栅位图
        /// </summary>
        /// <param name="pszPath"></param>
        /// <param name="nOrgx"></param>
        /// <param name="nMode"></param>
        /// <returns></returns>
        public byte[] PrintBitMap(string pszPath, int nOrgx, int nMode)
        {
            byte[][] orgData = TEXTANDPIC.TAC_TurnPicToPixData(pszPath);

            int nHeight = orgData.Length;
            int nWidth = orgData[0].Length;
            int blukHeight = 96;
            int blukSum = (nHeight + blukHeight - 1) / blukHeight;
            int byteLength = 8 * blukSum + (nWidth + 7) / 8 * ((nHeight + 7) / 8 * 8) + ESC_dollors_nL_nH.Length * blukSum;
            byte[] latestData = new byte[byteLength];
            ESC_dollors_nL_nH[2] = (byte)(nOrgx % 0x100);
            ESC_dollors_nL_nH[3] = (byte)(nOrgx / 0x100);

            int offset = 0;
            byte[][] desData;
            desData = CACULATE.getSampleDesData(blukHeight, nWidth);
            for (int i = 0; i < nHeight; i = i + blukHeight)
            {
                if ((nHeight - i > 0) & (nHeight - i < blukHeight))
                    desData = CACULATE.getSampleDesData(nHeight - i, nWidth);

                CACULATE.CACU_CutToData(orgData, i, 0, desData);
                byte[] temp = CACULATE.CACU_PixDataToPrintedCommand(desData, nMode);
                ESC_dollors_nL_nH.CopyTo(latestData, offset);
                offset += ESC_dollors_nL_nH.Length;
                temp.CopyTo(latestData, offset);
                offset += temp.Length;
            }
            return latestData;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte[] RTQueryStatus()
        {
            byte[] data = new byte[12];
            DLE_EOT_n.CopyTo(data, 0);
            DLE_EOT_n.CopyTo(data, 3);
            DLE_EOT_n.CopyTo(data, 6);
            DLE_EOT_n.CopyTo(data, 9);
            data[5] = 0x02;
            data[8] = 0x03;
            data[11] = 0x04;

            return data;
        }
    }


    /// <summary>
    /// MTP打印指令集
    /// </summary>
    public class MTP
    {
        private byte[] ERROR = { 0x00 };

        /// <summary>
        /// 复位打印机
        /// </summary>
        private byte[] ESC_ALT = { 0x1b, 0x40 };

        /// <summary>
        /// 选择国际字符集，值可以为0-15。默认值为0（美国）。
        /// </summary>
        private byte[] ESC_R_n = { 0x1b, 0x52, 0x00 };

        /// <summary>
        /// 选择字符代码表，值可以为0-10,16-19。默认值为0。 
        /// </summary>
        private byte[] ESC_t_n = { 0x1b, 0x74, 0x00 };

        /// <summary>
        /// 打印并换行
        /// </summary>
        private byte[] LF = { 0x0a };

        /// <summary>
        /// 设置行间距为[n*纵向或横向移动单位]英寸
        /// </summary>
        private byte[] ESC_3_n = { 0x1b, 0x33, 0x00 };

        /// <summary>
        /// 设置字符右间距，当字符放大时，右间距也随之放大相同倍数
        /// </summary>
        private byte[] ESC_SP_n = { 0x1b, 0x20, 0x00 };

        /// <summary>
        /// 设置汉字字符左右间距
        /// </summary>
        private byte[] FS_S_n1_n2 = { 0x1c, 0x53, 0x00, 0x00 };

        /// <summary>
        /// 设置打印区域宽度，该命令仅在标准模式行首有效。
        /// 如果【左边距+打印区域宽度】超出可打印区域，则打印区域宽度为可打印区域-左边距。
        /// </summary>
        private byte[] GS_W_nL_nH = { 0x1d, 0x57, 0x80, 0x01 };

        /// <summary>
        /// 设置绝对打印位置
        /// 将当前位置设置到距离行首（nL + nH x 256）处。
        /// 如果设置位置在指定打印区域外，该命令被忽略
        /// </summary>
        private byte[] ESC_dollors_nL_nH ={ 0x1b, 0x24, 0x00, 0x00 };

        /// <summary>
        /// 选择字符大小
        /// 0-3位选择字符高度，4-7位选择字符宽度
        /// 范围为从0-7
        /// </summary>
        private byte[] GS_exclamationmark_n ={ 0x1d, 0x21, 0x00 };

        /// <summary>
        /// 选择字体
        /// 0 标准ASCII字体
        /// 1 压缩ASCII字体
        /// </summary>
        private byte[] ESC_M_n = { 0x1b, 0x4d, 0x00 };

        /// <summary>
        /// 选择/取消加粗模式
        /// n的最低位为0，取消加粗模式
        /// n最低位为1，选择加粗模式
        /// 与0x01即可
        /// </summary>
        private byte[] GS_E_n = { 0x1b, 0x45, 0x00 };

        /// <summary>
        /// 选择/取消下划线模式
        /// 0 取消下划线模式
        /// 1 选择下划线模式（1点宽）
        /// 2 选择下划线模式（2点宽）
        /// </summary>
        private byte[] ESC_line_n = { 0x1b, 0x2d, 0x00 };

        /// <summary>
        /// 选择/取消倒置打印模式
        /// 0 为取消倒置打印
        /// 1 选择倒置打印
        /// </summary>
        private byte[] ESC_lbracket_n = { 0x1b, 0x7b, 0x00 };

        /// <summary>
        /// 选择/取消黑白反显打印模式
        /// n的最低位为0是，取消反显打印
        /// n的最低位为1时，选择反显打印
        /// </summary>
        private byte[] GS_B_n = { 0x1d, 0x42, 0x00 };

        /// <summary>
        /// 选择/取消顺时针旋转90度
        /// </summary>
        private byte[] ESC_V_n = { 0x1b, 0x56, 0x00 };

        /// <summary>
        /// 选择对齐方式
        /// </summary>
        private byte[] ESC_a_n = { 0x1b, 0x61, 0x00 };

        /// <summary>
        /// 打印下载位图
        /// 0 正常
        /// 1 倍宽
        /// 2 倍高
        /// 3 倍宽、倍高
        /// </summary>
        private byte[] GS_backslash_m = { 0x1d, 0x2f, 0x00 };

        /// <summary>
        /// 打印NV位图
        /// 以m指定的模式打印flash中图号为n的位图
        /// 1≤n≤255
        /// </summary>
        private byte[] FS_p_n_m ={ 0x1c, 0x70, 0x01, 0x00 };

        /// <summary>
        /// 选择HRI字符的打印位置
        /// 0 不打印
        /// 1 条码上方
        /// 2 条码下方
        /// 3 条码上、下方都打印
        /// </summary>
        private byte[] GS_H_n = { 0x1d, 0x48, 0x00 };

        /// <summary>
        /// 选择HRI使用字体
        /// 0 标准ASCII字体
        /// 1 压缩ASCII字体
        /// </summary>
        private byte[] GS_f_n = { 0x1d, 0x66, 0x00 };

        /// <summary>
        /// 选择条码高度
        /// 1≤n≤255
        /// 默认值 n=162
        /// </summary>
        private byte[] GS_h_n = { 0x1d, 0x68, 0xa2 };

        /// <summary>
        /// 设置条码宽度
        /// 2≤n≤6
        /// 默认值 n=3
        /// </summary>
        private byte[] GS_w_n = { 0x1d, 0x77, 0x03 };

        /// <summary>
        /// 打印条码
        /// 0x41≤m≤0x49
        /// n的取值有条码类型m决定
        /// </summary>
        private byte[] GS_k_m_n_ = { 0x1d, 0x6b, 0x41, 0x0c };

        /// <summary>
        /// 选择/取消汉字下划线模式
        /// </summary>
        private byte[] FS_line_n = { 0x1c, 0x2d, 0x00 };

        /// <summary>
        /// 选择/取消下划线模式（不影响汉字字符设定）
        /// </summary>
        private byte[] ESC_cross_n = { 0x1b, 0x2d, 0x00 };

        /// <summary>
        /// 实时传送状态
        /// n=1：传送打印机状态
        /// n=2：传送脱机状态
        /// n=3：传送错误状态
        /// n=4：传送纸传感器状态
        /// </summary>
        private byte[] DLE_EOT_n = { 0x10, 0x04, 0x01 };

        /// <summary>
        /// 设置左边距
        /// 如果超出可打印范围，则取最大可打印范围
        /// </summary>
        private byte[] GS_L_nL_nH ={ 0x1d, 0x4c, 0x00, 0x00 };

        /// <summary>
        /// m=0x61
        /// 1≤v小于等于17
        /// 1≤r≤4
        /// 打印二维码
        /// </summary>
        private byte[] GS_k_m_v_r_nL_nH = { 0x1d, 0x6b, 0x61, 0x07, 0x02, 0x00, 0x00 };

        /// <summary>
        /// 最多设置32个跳格位置，如果后面的位置小于前面，则后面的数据做普通数据处理
        /// </summary>
        private byte[] ESC_D_n1__n32_NUL = { 0x1b, 0x44, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

        private byte[] ESC_D_NUL = { 0x1b, 0x44, 0x00 };

        /// <summary>
        /// 打印并换行
        /// 这条命令在标准模式下打印缓冲区数据并移动到下一行
        /// 在页模式下，只是移动到下一行
        /// </summary>
        /// <returns></returns>
        public byte[] FeedLine()
        {
            return LF;
        }

        /// <summary>
        /// 复位打印机
        /// </summary>
        /// <returns></returns>
        public byte[] Reset()
        {
            return ESC_ALT;
        }

        public byte[] TestHTPosition()
        {
            ESC_D_n1__n32_NUL[2] = 0x01;
            ESC_D_n1__n32_NUL[3] = 0x05;
            ESC_D_n1__n32_NUL[4] = 0x09;
            ESC_D_n1__n32_NUL[5] = 0x0d;

            byte[] data = { 0x09, 0xc9, 0xe8, 0x09, 0xd6, 0xc3, 0x09, 0xcc, 0xf8, 0x09, 0xb8, 0xf1 };
            int length = ESC_D_n1__n32_NUL.Length + data.Length + ESC_D_NUL.Length;
            byte[] lastdata = new byte[length];
            int offset = 0;
            ESC_D_n1__n32_NUL.CopyTo(lastdata, offset);
            offset += ESC_D_n1__n32_NUL.Length;
            data.CopyTo(lastdata, offset);
            offset += data.Length;
            ESC_D_NUL.CopyTo(lastdata, offset);
            offset += ESC_D_NUL.Length;

            return lastdata;
        }

        /// <summary>
        /// 选择国际字符集和字符代码页
        /// </summary>
        /// <param name="nCharSet"></param>
        /// <param name="nCodePage"></param>
        /// <returns></returns>
        public byte[] SetCharSetAndCodePage(int nCharSet, int nCodePage)
        {
            if (nCharSet < 0 | nCharSet > 15 | nCodePage < 0 | nCodePage > 19 | (nCodePage > 10 & nCodePage < 16))
                return ERROR;
            
            byte[] data = new byte[ESC_R_n.Length + ESC_t_n.Length];
            ESC_R_n[2] = (byte)nCharSet;
            ESC_R_n.CopyTo(data, 0);
            ESC_t_n[2] = (byte)nCodePage;
            ESC_t_n.CopyTo(data, ESC_R_n.Length);

            return data;
        }

        /// <summary>
        /// 设置行高和字符间距
        /// （字符间距包括ASCII字符和汉字字符）
        /// 一个打印点和移动单位不一定相同
        /// </summary>
        /// <returns></returns>
        public byte[] SetLSRS(int nRightSpacing, int nLineSpacing)
        {
            if ( nRightSpacing < 0 | nRightSpacing > 255 | nLineSpacing < 0 | nLineSpacing > 255)
            {
                MessageBox.Show("输入值超出范围");
                return ERROR;
            }

            byte[] data = new byte[10];
            int offset = 0;
            ESC_SP_n[2] = (byte)nRightSpacing;
            ESC_SP_n.CopyTo(data, offset);
            offset += ESC_SP_n.Length;
            FS_S_n1_n2[3] = (byte)nRightSpacing;
            FS_S_n1_n2.CopyTo(data, offset);
            offset += FS_S_n1_n2.Length;
            ESC_3_n[2] = (byte)nLineSpacing;
            ESC_3_n.CopyTo(data, offset);

            return data;
        }

        /// <summary>
        /// 标准模式下设置左边距和打印区域宽度
        /// 该命令只在标准模式的行首有效
        /// 值*移动单位
        /// </summary>
        /// <returns></returns>
        public byte[] SetLMarginToPrintW(int nLeftMargin, int nPrintWidth)
        {
            if (nLeftMargin < 0 | nLeftMargin > 65535 | nPrintWidth < 0 | nPrintWidth > 65535)
            {
                MessageBox.Show("输入值超出范围");
                return ERROR;
            }

            byte[] data = new byte[8];
            int offset = 0;
            GS_L_nL_nH[2] = (byte)(nLeftMargin % 0x100);
            GS_L_nL_nH[3] = (byte)(nLeftMargin / 0x100);
            GS_L_nL_nH.CopyTo(data, offset);
            offset += GS_L_nL_nH.Length;
            GS_W_nL_nH[2] = (byte)(nPrintWidth % 0x100);
            GS_W_nL_nH[3] = (byte)(nPrintWidth / 0x100);
            GS_W_nL_nH.CopyTo(data, offset);

            return data;
        }

        /// <summary>
        /// pszString要输出的字符串，nOrgx绝对横向打印位置
        /// </summary>
        /// <param name="pszString"></param>
        /// <param name="nOrgx"></param>
        /// <param name="nWidthTimes"></param>
        /// <param name="nHeightTimes"></param>
        /// <param name="nFontType"></param>
        /// <param name="nFontStyle"></param>
        /// <returns></returns>
        public byte[] TextOut(string pszString, int nOrgx, int nWidthTimes, int nHeightTimes, int nFontType, int nFontStyle)
        {
            if (nOrgx > 65535 | nOrgx < 0 |
                nWidthTimes > 7 | nWidthTimes < 0 | nHeightTimes > 7 | nHeightTimes < 0 |
                nFontType < 0 | nFontType > 4)
            {
                MessageBox.Show("参数出错");
                return ERROR;
            }

            byte[] pbString = Encoding.Default.GetBytes(pszString);
            int dataLength = pbString.Length + ESC_dollors_nL_nH.Length + GS_exclamationmark_n.Length +
                ESC_M_n.Length + GS_E_n.Length + FS_line_n.Length + ESC_cross_n.Length +
                ESC_lbracket_n.Length + GS_B_n.Length + ESC_V_n.Length +ESC_a_n.Length ;

            byte[] data = new byte[dataLength];
            int offset = 0;
            ESC_dollors_nL_nH[2] = (byte)(nOrgx % 0x100);
            ESC_dollors_nL_nH[3] = (byte)(nOrgx / 0x100);
            ESC_dollors_nL_nH.CopyTo(data, offset);
            offset += ESC_dollors_nL_nH.Length;
            byte[] intToWidth = { 0x00, 0x10, 0x20, 0x30, 0x40, 0x50, 0x60, 0x70 };
            byte[] intToHeight = { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07 };
            GS_exclamationmark_n[2] = (byte)(intToWidth[nWidthTimes] + intToHeight[nHeightTimes]);
            GS_exclamationmark_n.CopyTo(data, offset);
            offset += GS_exclamationmark_n.Length;
            ESC_M_n[2] = (byte)nFontType;
            ESC_M_n.CopyTo(data, offset);
            offset += ESC_M_n.Length;

            //字体风格
            //暂不支持平滑处理
            GS_E_n[2] = (byte)((nFontStyle >> 3) & 0x01);
            GS_E_n.CopyTo(data, offset);
            offset += GS_E_n.Length;
            FS_line_n[2] = (byte)((nFontStyle >> 7) & 0x03);
            FS_line_n.CopyTo(data, offset);
            offset += FS_line_n.Length;
            ESC_cross_n[2] = (byte)((nFontStyle >> 7) & 0x03);
            ESC_cross_n.CopyTo(data, offset);
            offset += ESC_cross_n.Length;
            ESC_lbracket_n[2] = (byte)((nFontStyle >> 9) & 0x01);
            ESC_lbracket_n.CopyTo(data, offset);
            offset += ESC_lbracket_n.Length;
            GS_B_n[2] = (byte)((nFontStyle >> 10) & 0x01);
            GS_B_n.CopyTo(data, offset);
            offset += GS_B_n.Length;
            ESC_V_n[2] = (byte)((nFontStyle >> 12) & 0x01);
            ESC_V_n.CopyTo(data, offset);
            offset += ESC_V_n.Length;
            ESC_a_n[2] = (byte)((nFontStyle >> 14) & 0x03);
            ESC_a_n.CopyTo(data, offset);
            offset += ESC_a_n.Length;
            pbString.CopyTo(data, offset);

            return data;
        }

        public byte[] SetBarcode(string pszInfoBuffer, int nOrgx, int nType, int nWidthX, int nHeight, int nHriFontType, int nHriFontPosition, int nBytesToPrint)
        {
            if (nOrgx < 0 | nOrgx > 65535 | nType < 0x41 | nType > 0x49 | nWidthX < 2 | nWidthX > 6 | nHeight < 1 | nHeight > 255 | (pszInfoBuffer.Length != nBytesToPrint))
                return ERROR;

            byte[] pbString = Encoding.Default.GetBytes(pszInfoBuffer);
            int dataLength = ESC_dollors_nL_nH.Length + GS_w_n.Length +
                GS_h_n.Length + GS_f_n.Length +
                GS_H_n.Length + GS_k_m_n_.Length + pbString.Length;

            byte[] data = new byte[dataLength];
            int offset = 0;
            ESC_dollors_nL_nH[2] = (byte)(nOrgx % 0x100);
            ESC_dollors_nL_nH[3] = (byte)(nOrgx / 0x100);
            ESC_dollors_nL_nH.CopyTo(data, offset);
            offset += ESC_dollors_nL_nH.Length;
            GS_w_n[2] = (byte)nWidthX;
            GS_w_n.CopyTo(data, offset);
            offset += GS_w_n.Length;
            GS_h_n[2] = (byte)nHeight;
            GS_h_n.CopyTo(data, offset);
            offset += GS_h_n.Length;
            GS_f_n[2] = (byte)(nHriFontType & 0x01);
            GS_f_n.CopyTo(data, offset);
            offset += GS_f_n.Length;
            GS_H_n[2] = (byte)(nHriFontPosition & 0x03);
            GS_H_n.CopyTo(data, offset);
            offset += GS_H_n.Length;
            GS_k_m_n_[2] = (byte)nType;
            GS_k_m_n_[3] = (byte)pbString.Length;
            GS_k_m_n_.CopyTo(data, offset);
            offset += GS_k_m_n_.Length;
            pbString.CopyTo(data, offset);

            return data;
        }

        public byte[] SetQRCode(string pszInfoBuffer, int nOrgx, int nWidthX, int nType)
        {
            if (nOrgx < 0 | nOrgx > 65535 | (nType != 0x61))
                return ERROR;

            byte[] pbString = Encoding.Default.GetBytes(pszInfoBuffer);
            int dataLength = ESC_dollors_nL_nH.Length + GS_w_n.Length + GS_k_m_v_r_nL_nH.Length + pbString.Length;

            byte[] data = new byte[dataLength];
            int offset = 0;
            ESC_dollors_nL_nH[2] = (byte)(nOrgx % 0x100);
            ESC_dollors_nL_nH[3] = (byte)(nOrgx / 0x100);
            ESC_dollors_nL_nH.CopyTo(data, offset);
            GS_w_n[2] = (byte)nWidthX;
            GS_w_n.CopyTo(data, offset);
            offset += GS_w_n.Length;
            GS_k_m_v_r_nL_nH[5] = (byte)(pbString.Length % 0x100);
            GS_k_m_v_r_nL_nH[6] = (byte)(pbString.Length / 0x100);
            GS_k_m_v_r_nL_nH.CopyTo(data, offset);
            offset += GS_k_m_v_r_nL_nH.Length;
            pbString.CopyTo(data, offset);

            return data;
        }

        /// <summary>
        /// 下载到RAM位图，暂时只支持一张图片，第二个参数将会被忽略。
        /// </summary>
        /// <param name="pszPath"></param>
        /// <param name="nID"></param>
        /// <returns></returns>
        public byte[] PreDownloadBmpToRAM(string pszPath, int nID)
        {
            return TEXTANDPIC.TAC_PreDownloadBmpToRam(pszPath);
        }

        /// <summary>
        /// 第二个参数被忽略，只接受第一个参数
        /// </summary>
        /// <param name="pszPaths"></param>
        /// <param name="nCount"></param>
        /// <returns></returns>
        public byte[] PreDownloadBmpsToFlash(string[] pszPaths, int nCount)
        {
            return TEXTANDPIC.TAC_PreDownloadBmpsToFlash(pszPaths);
        }

        /// <summary>
        /// nID被忽略，只支持一张图片
        /// </summary>
        /// <param name="nID"></param>
        /// <param name="nOrgx"></param>
        /// <param name="nMode"></param>
        /// <returns></returns>
        public byte[] PrintBmpInRAM(int nID, int nOrgx, int nMode)
        {
            if (nOrgx < 0 | nOrgx > 65535)
                return ERROR;

            int dataLength = ESC_dollors_nL_nH.Length + GS_backslash_m.Length;
            byte[] data = new byte[dataLength];
            int offset = 0;
            ESC_dollors_nL_nH[2] = (byte)(nOrgx % 0x100);
            ESC_dollors_nL_nH[3] = (byte)(nOrgx / 0x100);
            ESC_dollors_nL_nH.CopyTo(data, offset);
            offset += ESC_dollors_nL_nH.Length;
            GS_backslash_m[2] = (byte)(nMode & 0x03);
            GS_backslash_m.CopyTo(data, offset);

            return data;
        }

        /// <summary>
        /// 打印FLASH中的位图
        /// </summary>
        /// <param name="nID"></param>
        /// <param name="nOrgx"></param>
        /// <param name="nMode"></param>
        /// <returns></returns>
        public byte[] PrintBmpInFlash(int nID, int nOrgx, int nMode)
        {
            if (nOrgx < 0 | nOrgx > 65535 | nID < 1 | nID > 255)
                return ERROR;

            int dataLength = ESC_dollors_nL_nH.Length + FS_p_n_m.Length;
            byte[] data = new byte[dataLength];
            int offset = 0;
            ESC_dollors_nL_nH[2] = (byte)(nOrgx % 0x100);
            ESC_dollors_nL_nH[3] = (byte)(nOrgx / 0x100);
            ESC_dollors_nL_nH.CopyTo(data, offset);
            offset += ESC_dollors_nL_nH.Length;
            FS_p_n_m[2] = (byte)(nID);
            FS_p_n_m[3] = (byte)(nMode & 0x03);
            FS_p_n_m.CopyTo(data, offset);

            return data;
        }

        /// <summary>
        /// 打印光栅位图
        /// </summary>
        /// <param name="pszPath"></param>
        /// <param name="nOrgx"></param>
        /// <param name="nMode"></param>
        /// <returns></returns>
        public byte[] PrintBitMap(string pszPath, int nOrgx, int nMode)
        {
            byte[][] orgData = TEXTANDPIC.TAC_TurnPicToPixData(pszPath);

            int nHeight = orgData.Length;
            int nWidth = orgData[0].Length;
            int blukHeight = 96;
            int blukSum = (nHeight + blukHeight - 1) / blukHeight;
            int byteLength = 8 * blukSum + (nWidth + 7) / 8 * ((nHeight + 7) / 8 * 8) + ESC_dollors_nL_nH.Length * blukSum;
            byte[] latestData = new byte[byteLength];
            ESC_dollors_nL_nH[2] = (byte)(nOrgx % 0x100);
            ESC_dollors_nL_nH[3] = (byte)(nOrgx / 0x100);
            
            int offset = 0;
            byte[][] desData;
            desData = CACULATE.getSampleDesData(blukHeight, nWidth);
            for (int i = 0; i < nHeight; i = i + blukHeight)
            {
                if ((nHeight - i > 0) & (nHeight - i < blukHeight))
                    desData = CACULATE.getSampleDesData(nHeight - i, nWidth);

                CACULATE.CACU_CutToData(orgData, i, 0, desData);
                byte[] temp = CACULATE.CACU_PixDataToPrintedCommand(desData, nMode);
                ESC_dollors_nL_nH.CopyTo(latestData, offset);
                offset += ESC_dollors_nL_nH.Length;
                temp.CopyTo(latestData, offset);
                offset += temp.Length;
            }
            return latestData;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte[] RTQueryStatus()
        {
            byte[] data = new byte[12];
            DLE_EOT_n.CopyTo(data, 0);
            DLE_EOT_n.CopyTo(data, 3);
            DLE_EOT_n.CopyTo(data, 6);
            DLE_EOT_n.CopyTo(data, 9);
            data[5] = 0x02;
            data[8] = 0x03;
            data[11] = 0x04;

            return data;
        }
    }
}
