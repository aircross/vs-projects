/*命名空间POSDLL为公用
 * 带页模式的小票打印机为POSDLL_V1
 * 不带页模式的小票打印机为POSDLL_V2
 * V2目前还在开发中
 * 
 */ 
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using POSDLL;

namespace POSDLL_V2
{
    /// <summary>
    /// 不带页模式的小票打印机
    /// </summary>
     class C_POSDLL
    {
        public const int INVALID_HANDLE_VALUE = -1;
        public const int POS_SUCCESS = 1001;
        public const int POS_FAIL = 1002;
        public const int POS_ERROR_INVALID_HANDLE = 1101;
        public const int POS_ERROR_INVALID_PARAMETER = 1102;


        //指定串口的流控制（握手）方式，或表示通讯方式
        public const int POS_COM_DTR_DSR = 0x00;
        public const int POS_COM_RTS_CTS = 0x01;
        public const int POS_COM_XON_OXFF = 0x02;
        public const int POS_COM_NO_HANDSHAKE = 0x03;
        public const int POS_OPEN_PARALLEL_PORT = 0x12;
        public const int POS_OPEN_BYUSB_PORT = 0x13;
        public const int POS_OPEN_PRINTNAME = 0x14;
        public const int POS_OPEN_NETPORT = 0x15;

        //指定串口通讯时的数据停止位数
        public const int POS_COM_ONESTOPBIT = 0x00;
        public const int POS_COM_ONE5STOPBITS = 0x01;
        public const int POS_COM_TWOSTOPBITS = 0x02;

        //指定串口通讯时的奇偶校验方法
        public const int POS_COM_NOPARITY = 0x00;
        public const int POS_COM_ODDPARITY = 0x01;
        public const int POS_COM_EVENPARITY = 0x02;
        public const int POS_COM_MARKPARITY = 0x03;
        public const int POS_COM_SPACEPARITY = 0x04;

        //打印机设置标记
        public const int POS_PRINT_MODE_STANDARD = 0x00;
        public const int POS_PRINT_MODE_PAGE = 0x01;
        public const int POS_PRINT_MODE_BLACK_MARK_LABEL = 0x02;
        public const int POS_PRINT_MODE_WHITE_MARK_LABEL = 0x03;

        //字符集
        public const int CHARSET_USA = 0x00;
        public const int CHARSET_FRANCE = 0x01;
        public const int CHARSET_GERMANY = 0x02;
        public const int CHARSET_UK = 0x03;
        public const int CHARSET_DENMARK_1 = 0x04;
        public const int CHARSET_SWEDEN = 0x05;
        public const int CHARSET_ITALY = 0x06;
        public const int CHARSET_SPAIN_1 = 0x07;
        public const int CHARSET_JAPAN = 0x08;
        public const int CHARSET_NONWAY = 0x09;
        public const int CHARSET_DENMARK_2 = 0x0a;
        public const int CHARSET_SPAIN_2 = 0x0b;
        public const int CHARSET_LATIN_AMERICA = 0x0c;
        public const int CHARSET_KOREA = 0x0d;
        public const int CHARSET_CROATIA = 0x0e;
        public const int CHARSET_CHINESE = 0x0f;

        //代码页
        public const int CODEPAGE_PC437 = 0;
        public const int CODEPAGE_KATAKANA = 1;
        public const int CODEPAGE_PC850 = 2;
        public const int CODEPAGE_PC860 = 3;
        public const int CODEPAGE_PC863 = 4;
        public const int CODEPAGE_PC865 = 5;
        public const int CODEPAGE_WEST_EUROPE = 6;
        public const int CODEPAGE_GREEK = 7;
        public const int CODEPAGE_HEBREW = 8;
        public const int CODEPAGE_PC755_EAST_EUROPE = 9;
        public const int CODEPAGE_IRAN = 10;
        public const int CODEPAGE_WPC1252 = 16;
        public const int CODEPAGE_PC866_CYRILLICE_2 = 17;
        public const int CODEPAGE_PC852_LATIN_2 = 18;
        public const int CODEPAGE_PC858 = 19;

        /// <summary>
        /// 字体类型
        /// </summary>
        public const int POS_FONT_TYPE_STANDARD = 0x00;
        public const int POS_FONT_TYPE_COMPRESSED = 0x01;
        public const int POS_FONT_TYPE_UDC = 0x02;
        public const int POS_FONT_TYPE_CHINESE = 0x03;

        /// <summary>
        /// 字体风格
        /// </summary>
        public const int POS_FONT_STYLE_NORMAL = 0x00;
        public const int POS_FONT_STYLE_BOLD = 0x08;
        public const int POS_FONT_STYLE_THIN_UNDERLINE = 0x80;
        public const int POS_FONT_STYLE_THICK_UNDERLINE = 0x100;
        public const int POS_FONT_STYLE_UPSIDEDOWN = 0x200;
        public const int POS_FONT_STYLE_REVERSE = 0x400;
        public const int POS_FONT_STYLE_SMOOTH = 0x800;
        public const int POS_FONT_STYLE_CLOCKWISE_90 = 0x1000;

        /// <summary>
        /// 指定RAM位图打印模式
        /// </summary>
        public const int POS_BITMAP_PRINT_NORMAL = 0x00;
        public const int POS_BITMAP_PRINT_DOUBLE_WIDTH = 0x01;
        public const int POS_BITMAP_PRINT_DOUBLE_HEIGHT = 0x02;
        public const int POS_BITMAP_PRINT_QUADRUPLE = 0x03;

        /// <summary>
        /// 选择条码类型
        /// </summary>
        public const int POS_BARCODE_TYPE_UPC_A = 0x41;
        public const int POS_BARCODE_TYPE_UPC_E = 0x42;
        public const int POS_BARCODE_TYPE_JAN13 = 0x43;
        public const int POS_BARCODE_TYPE_JAN8 = 0x44;
        public const int POS_BARCODE_TYPE_CODE39 = 0x45;
        public const int POS_BARCODE_TYPE_ITF = 0x46;
        public const int POS_BARCODE_TYPE_CODEBAR = 0x47;
        public const int POS_BARCODE_TYPE_CODE93 = 0x48;
        public const int POS_BARCODE_TYPE_CODE128 = 0x49;

        /// <summary>
        /// 页模式下选择打印方向
        /// </summary>
        public const int POS_AREA_LEFT_TO_RIGHT = 0;
        public const int POS_AREA_BOTTOM_TO_TOP = 1;
        public const int POS_AREA_RIGHT_TO_LEFT = 2;
        public const int POS_AREA_TOP_TO_BOTTOM = 3;

        //记录哪一个被选定了
        public static bool POS_COM_SELECTED = false;
        public static bool POS_PARALLEL_SELECTED = false;
        public static bool POS_USBPORT_SELECTED = false;
        public static bool POS_PRINTNAME_SELECTED = false;
        public static bool POS_NETPORT_SELECTED = false;

        //记录端口句柄
        public static int POS_COM_HANDLE = -1;
        public static int POS_PRINTNAME_HANDLE = -1;

        /// <summary>
        /// 记录页模式是否选定
        /// </summary>
        public static bool POS_PAGEMODE_SELECTED = false;


        //IO类WINAPI函数
        private class IOCONTROL
        {
            //使用WindowsAPI打开设备
            public const uint GENERIC_READ = 0x80000000;
            public const uint GENERIC_WRITE = 0x40000000;
            public const int FILE_SHARE_READ = 0x00000001;
            public const int FILE_SHARE_WRITE = 0x00000002;
            public const int OPEN_EXISTING = 3;
            public const int CREATE_ALWAYS = 2;
            public const int FILE_ATTRIBUTE_READONLY = 1;
            public const int FILE_ATTRIBUTE_NORMAL = 128;
            [StructLayout(LayoutKind.Sequential)]
            public struct OVERLAPPED
            {
                public uint Internal;
                public uint InternalHigh;
                public uint Offset;
                public uint OffSetHigh;
                public uint hEvent;
            }
            //调用DLL
            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern int CreateFile(string lpFileName, uint dwDesiredAccess, uint dwShareMode, int lpSecurityAttributes, uint dwCreationDisposition, uint dwFlagsAndAttributes, int hTemplateFile);
            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern bool WriteFile(int hFile, byte[] lpBuffer, uint nNumberOfBytesToWrite, ref uint lpNumberOfBytesWritten, ref OVERLAPPED lpOverlapped);
            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern bool ReadFile(int hFile, byte[] lpBuffer, uint nNumberOfBytesToRead, ref uint lpNumberofBytesRead, ref OVERLAPPED lpOverlapped);
            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern bool CloseHandle(int hObject);

            //串口API及结构
            [StructLayout(LayoutKind.Sequential)]
            public struct DCB
            {
                public uint DCBlength;
                public uint BaudRate;
                public uint fFlags;
                public ushort wReserved;
                public ushort XonLim;
                public ushort XoffLim;
                public byte ByteSize;
                public byte Parity;
                public byte StopBits;
                public byte XonChar;
                public byte XoffChar;
                public byte ErrorChar;
                public byte EofChar;
                public byte EvtChar;
                public ushort wReserved1;

            }
            //表示对应flags需要左移的位数
            public const int fBinary = 0;
            public const int fParity = 1;
            public const int fOutxCtsFlow = 2;
            public const int fOutxDsrFlow = 3;
            public const int fDtrControl = 4;
            public const int fDsrSensitivity = 6;
            public const int fTXContinueOnXoff = 7;
            public const int fOutX = 8;
            public const int fInX = 9;
            public const int fErrorChar = 10;
            public const int fNull = 11;
            public const int fRtsControl = 12;
            public const int fAbortOnError = 14;
            public const int fDummy2 = 15;

            public const uint DTR_CONTROL_DISABLE = 0x00;
            public const uint DTR_CONTROL_ENABLE = 0x01;
            public const uint DTR_CONTROL_HANDSHAKE = 0x02;
            public const uint RTS_CONTROL_DISABLE = 0x00;
            public const uint RTS_CONTROL_ENABLE = 0x01;
            public const uint RTS_CONTROL_HANDSHAKE = 0x02;
            public const uint RTS_CONTROL_TOGGLE = 0x03;

            public const byte EVENPARITY = 2;
            public const byte MARKPARITY = 3;
            public const byte NOPARITY = 0;
            public const byte ODDPARITY = 1;
            public const byte SPACEPARITY = 4;
            public const byte ONESTOPBIT = 0;
            public const byte ONE5STOPBITS = 1;
            public const byte TWOSTOPBITS = 2;
            public static uint SetFlags(int whichFlag, uint value, uint orgFlags)
            {
                switch (whichFlag)
                {
                    case fBinary:
                    case fParity:
                    case fOutxCtsFlow:
                    case fOutxDsrFlow:
                    case fDsrSensitivity:
                    case fTXContinueOnXoff:
                    case fOutX:
                    case fInX:
                    case fErrorChar:
                    case fNull:
                    case fAbortOnError:
                        orgFlags &= (uint)(~(1 << whichFlag));
                        orgFlags |= value << whichFlag;
                        break;

                    case fDtrControl:
                    case fRtsControl:
                        orgFlags &= (uint)(~(3 << whichFlag));
                        orgFlags |= value << whichFlag;
                        break;

                    default:
                        break;
                }
                return orgFlags;
            }

            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern bool GetCommState(int hPort, ref DCB lpDCB);
            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern bool SetCommState(int hPort, ref DCB lpDCB);


        }

        private class PRINTEBYNAME
        {
            [StructLayout(LayoutKind.Sequential)]
            public struct DOC_INFO_1
            {
                public string pDocName;
                public string pOutputFile;
                public string pDatatype;
            }

            [DllImport("winspool.drv", SetLastError = true)]
            public static extern bool OpenPrinter(string pPrinterName, ref int phPrinter, IntPtr pDefault);

            [DllImport("winspool.drv", SetLastError = true)]
            public static extern uint StartDocPrinter(int hPrinter, uint Level, ref DOC_INFO_1 pDocInfo);

            [DllImport("winspool.drv", SetLastError = true)]
            public static extern bool StartPagePrinter(int hPrinter);

            [DllImport("winspool.drv", SetLastError = true)]
            public static extern bool WritePrinter(int hPrinter, byte[] pBuf, uint cbBuf, ref uint pcWritten);

            [DllImport("winspool.drv", SetLastError = true)]
            public static extern bool EndPagePrinter(int hPrinter);

            [DllImport("winspool.drv", SetLastError = true)]
            public static extern bool EndDocPrinter(int hPrinter);

            [DllImport("winspool.drv", SetLastError = true)]
            public static extern bool ClosePrinter(int hPrinter);
        }

        private class NETSOCKET
        {
            public const int AF_UNSPEC = 0;
            public const int AF_INET = 2;
            public const int AF_IPX = 6;
            public const int AF_APPLETALK = 16;
            public const int AF_NETBIOS = 17;
            public const int AF_INET6 = 23;
            public const int AF_IRDA = 26;
            public const int AF_BTH = 32;

            public const int SOCK_STREAM = 1;
            public const int SOCK_DGRAM = 2;
            public const int SOCK_RAW = 3;
            public const int SOCK_RDM = 4;
            public const int SOCK_SEQPACKET = 5;

            public const int IPPROTO_ICMP = 1;
            public const int IPPROTO_IGMP = 2;
            public const int BTHPROTO_RFCOMM = 3;
            public const int IPPROTO_TCP = 6;
            public const int IPPROTO_UDP = 17;
            public const int IPPROTO_ICMPV6 = 58;
            public const int IPPROTO_RM = 113;

            [DllImport("Ws2_32.dll", SetLastError = true)]
            public static extern int socket(int af, int type, int protocol);

        }

        /// <summary>
        /// 包含热敏打印机基本指令
        /// </summary>
        private class POSCOMMAND
        {

            public static byte[] ERROR = { 0x00 };

            /// <summary>
            /// 复位打印机
            /// </summary>
            public static byte[] ESC_ALT = { 0x1b, 0x40 };

            /// <summary>
            /// 选择页模式
            /// </summary>
            public static byte[] ESC_L = { 0x1b, 0x4c };

            /// <summary>
            /// 页模式下取消打印数据
            /// </summary>
            public static byte[] ESC_CAN = { 0x18 };

            /// <summary>
            /// 打印并回到标准模式（在页模式下）
            /// </summary>
            public static byte[] FF = { 0x0c };

            /// <summary>
            /// 页模式下打印缓冲区所有内容
            /// 只在页模式下有效，不清除缓冲区内容
            /// </summary>
            public static byte[] ESC_FF = { 0x1b, 0x0c };

            /// <summary>
            /// 选择标准模式
            /// </summary>
            public static byte[] ESC_S = { 0x1b, 0x53 };

            /// <summary>
            /// 设置横向和纵向移动单位
            /// 分别将横向移动单位近似设置成1/x英寸，纵向移动单位设置成1/y英寸。
            /// 当x和y为0时，x和y被设置成默认值200。
            /// </summary>
            public static byte[] GS_P_x_y = { 0x1d, 0x50, 0x00, 0x00 };

            /// <summary>
            /// 选择国际字符集，值可以为0-15。默认值为0（美国）。
            /// </summary>
            public static byte[] ESC_R_n = { 0x1b, 0x52, 0x00 };

            /// <summary>
            /// 选择字符代码表，值可以为0-10,16-19。默认值为0。 
            /// </summary>
            public static byte[] ESC_t_n = { 0x1b, 0x74, 0x00 };

            /// <summary>
            /// 打印并换行
            /// </summary>
            public static byte[] LF = { 0x0a };

            /// <summary>
            /// 设置行间距为[n*纵向或横向移动单位]英寸
            /// </summary>
            public static byte[] ESC_3_n = { 0x1b, 0x33, 0x00 };

            /// <summary>
            /// 设置字符右间距，当字符放大时，右间距也随之放大相同倍数
            /// </summary>
            public static byte[] ESC_SP_n = { 0x1b, 0x20, 0x00 };

            /// <summary>
            /// 在指定的钱箱插座引脚产生设定的开启脉冲。
            /// </summary>
            public static byte[] DLE_DC4_n_m_t = { 0x10, 0x14, 0x01, 0x00, 0x01 };

            /// <summary>
            /// 选择切纸模式并直接切纸，0为全切，1为半切
            /// </summary>
            public static byte[] GS_V_m = { 0x1d, 0x56, 0x00 };

            /// <summary>
            /// 进纸并且半切。
            /// </summary>
            public static byte[] GS_V_m_n = { 0x1d, 0x56, 0x42, 0x00 };

            /// <summary>
            /// 设置打印区域宽度，该命令仅在标准模式行首有效。
            /// 如果【左边距+打印区域宽度】超出可打印区域，则打印区域宽度为可打印区域-左边距。
            /// </summary>
            public static byte[] GS_W_nL_nH = { 0x1d, 0x57, 0x76, 0x02 };

            /// <summary>
            /// 设置绝对打印位置
            /// 将当前位置设置到距离行首（nL + nH x 256）处。
            /// 如果设置位置在指定打印区域外，该命令被忽略
            /// </summary>
            public static byte[] ESC_dollors_nL_nH ={ 0x1b, 0x24, 0x00, 0x00 };

            /// <summary>
            /// 选择字符大小
            /// 0-3位选择字符高度，4-7位选择字符宽度
            /// 范围为从0-7
            /// </summary>
            public static byte[] GS_exclamationmark_n ={ 0x1d, 0x21, 0x00 };

            /// <summary>
            /// 选择字体
            /// 0 标准ASCII字体
            /// 1 压缩ASCII字体
            /// </summary>
            public static byte[] ESC_M_n = { 0x1b, 0x4d, 0x00 };

            /// <summary>
            /// 选择/取消加粗模式
            /// n的最低位为0，取消加粗模式
            /// n最低位为1，选择加粗模式
            /// 与0x01即可
            /// </summary>
            public static byte[] GS_E_n = { 0x1b, 0x45, 0x00 };

            /// <summary>
            /// 选择/取消下划线模式
            /// 0 取消下划线模式
            /// 1 选择下划线模式（1点宽）
            /// 2 选择下划线模式（2点宽）
            /// </summary>
            public static byte[] ESC_line_n = { 0x1b, 0x2d, 0x00 };

            /// <summary>
            /// 选择/取消倒置打印模式
            /// 0 为取消倒置打印
            /// 1 选择倒置打印
            /// </summary>
            public static byte[] ESC_lbracket_n = { 0x1b, 0x7b, 0x00 };

            /// <summary>
            /// 选择/取消黑白反显打印模式
            /// n的最低位为0是，取消反显打印
            /// n的最低位为1时，选择反显打印
            /// </summary>
            public static byte[] GS_B_n = { 0x1d, 0x42, 0x00 };

            /// <summary>
            /// 选择/取消顺时针旋转90度
            /// </summary>
            public static byte[] ESC_V_n = { 0x1b, 0x56, 0x00 };

            /// <summary>
            /// 打印下载位图
            /// 0 正常
            /// 1 倍宽
            /// 2 倍高
            /// 3 倍宽、倍高
            /// </summary>
            public static byte[] GS_backslash_m = { 0x1d, 0x2f, 0x00 };

            /// <summary>
            /// 打印NV位图
            /// 以m指定的模式打印flash中图号为n的位图
            /// 1≤n≤255
            /// </summary>
            public static byte[] FS_p_n_m ={ 0x1c, 0x70, 0x01, 0x00 };

            /// <summary>
            /// 选择HRI字符的打印位置
            /// 0 不打印
            /// 1 条码上方
            /// 2 条码下方
            /// 3 条码上、下方都打印
            /// </summary>
            public static byte[] GS_H_n = { 0x1d, 0x48, 0x00 };

            /// <summary>
            /// 选择HRI使用字体
            /// 0 标准ASCII字体
            /// 1 压缩ASCII字体
            /// </summary>
            public static byte[] GS_f_n = { 0x1d, 0x66, 0x00 };

            /// <summary>
            /// 选择条码高度
            /// 1≤n≤255
            /// 默认值 n=162
            /// </summary>
            public static byte[] GS_h_n = { 0x1d, 0x68, 0xa2 };

            /// <summary>
            /// 设置条码宽度
            /// 2≤n≤6
            /// 默认值 n=3
            /// </summary>
            public static byte[] GS_w_n = { 0x1d, 0x77, 0x03 };

            /// <summary>
            /// 打印条码
            /// 0x41≤m≤0x49
            /// n的取值有条码类型m决定
            /// </summary>
            public static byte[] GS_k_m_n_ = { 0x1d, 0x6b, 0x41, 0x0c };

            /// <summary>
            /// 页模式下设置打印区域
            /// 该命令在标准模式下只设置内部标志位，不影响打印
            /// </summary>
            public static byte[] ESC_W_xL_xH_yL_yH_dxL_dxH_dyL_dyH ={ 0x1b, 0x57, 0x00, 0x00, 0x00, 0x00, 0x48, 0x02, 0xb0, 0x04 };

            /// <summary>
            /// 在页模式下选择打印区域方向
            /// 0≤n≤3
            /// </summary>
            public static byte[] ESC_T_n ={ 0x1b, 0x54, 0x00 };

            /// <summary>
            /// 页模式下设置纵向绝对位置
            /// 这条命令只有在页模式下有效
            /// </summary>
            public static byte[] GS_dollors_nL_nH = { 0x1d, 0x24, 0x00, 0x00 };

            /// <summary>
            /// 页模式下设置纵向相对位置
            /// 页模式下，以当前点位参考点设置纵向移动距离
            /// 这条命令只在页模式下有效
            /// </summary>
            public static byte[] GS_backslash_nL_nH ={ 0x1d, 0x5c, 0x00, 0x00 };

            /// <summary>
            /// 选择/取消汉字下划线模式
            /// </summary>
            public static byte[] FS_line_n = { 0x1c, 0x2d, 0x00 };

        }

        /// <summary>
        /// 目前支持打开串口，指定打印机名称
        /// </summary>
        /// <param name="lpName"></param>
        /// <param name="nComBaudrate"></param>
        /// <param name="nComDataBits"></param>
        /// <param name="nComStopBits"></param>
        /// <param name="nComParity"></param>
        /// <param name="nParam"></param>
        /// <returns></returns>
        public static int POS_Open(string lpName, int nComBaudrate, int nComDataBits, int nComStopBits, int nComParity, int nParam)
        {
            switch (nParam)
            {
                case POS_COM_DTR_DSR:
                case POS_COM_RTS_CTS:
                case POS_COM_XON_OXFF:
                case POS_COM_NO_HANDSHAKE:
                    {
                        POS_COM_HANDLE = IOCONTROL.CreateFile(lpName, IOCONTROL.GENERIC_READ | IOCONTROL.GENERIC_WRITE,
                            IOCONTROL.FILE_SHARE_READ | IOCONTROL.FILE_SHARE_WRITE,
                            0, IOCONTROL.OPEN_EXISTING, 0, 0);
                        IOCONTROL.DCB ComDcb = new IOCONTROL.DCB();
                        if (IOCONTROL.GetCommState(POS_COM_HANDLE, ref ComDcb))
                        {
                            ComDcb.BaudRate = (uint)nComBaudrate;
                            ComDcb.ByteSize = (byte)nComDataBits;
                            ComDcb.StopBits = (byte)nComStopBits;
                            ComDcb.Parity = (byte)nComParity;
                            switch (nParam)
                            {
                                case POS_COM_DTR_DSR:
                                    ComDcb.fFlags = IOCONTROL.SetFlags(IOCONTROL.fDtrControl, IOCONTROL.DTR_CONTROL_ENABLE, ComDcb.fFlags);
                                    break;
                                case POS_COM_RTS_CTS:
                                    ComDcb.fFlags = IOCONTROL.SetFlags(IOCONTROL.fRtsControl, IOCONTROL.RTS_CONTROL_ENABLE, ComDcb.fFlags);
                                    break;
                                case POS_COM_XON_OXFF:
                                    ComDcb.fFlags = IOCONTROL.SetFlags(IOCONTROL.fOutX, 1, ComDcb.fFlags);
                                    ComDcb.fFlags = IOCONTROL.SetFlags(IOCONTROL.fInX, 1, ComDcb.fFlags);
                                    break;
                                case POS_COM_NO_HANDSHAKE:
                                    ComDcb.fFlags = IOCONTROL.SetFlags(IOCONTROL.fRtsControl, IOCONTROL.RTS_CONTROL_DISABLE, ComDcb.fFlags);
                                    ComDcb.fFlags = IOCONTROL.SetFlags(IOCONTROL.fDtrControl, IOCONTROL.DTR_CONTROL_DISABLE, ComDcb.fFlags);
                                    break;
                                default:
                                    break;
                            }

                            if (IOCONTROL.SetCommState(POS_COM_HANDLE, ref ComDcb))
                            {
                                POS_COM_SELECTED = true;
                                return POS_COM_HANDLE;
                            }
                            else
                                return INVALID_HANDLE_VALUE;
                        }
                        else
                            return INVALID_HANDLE_VALUE;
                    }
                case POS_OPEN_PARALLEL_PORT:
                    {
                        return INVALID_HANDLE_VALUE;
                    }
                case POS_OPEN_BYUSB_PORT:
                    {
                        return INVALID_HANDLE_VALUE;
                    }
                case POS_OPEN_PRINTNAME:
                    {
                        if (PRINTEBYNAME.OpenPrinter(lpName, ref POS_PRINTNAME_HANDLE, IntPtr.Zero))
                        {
                            POS_PRINTNAME_SELECTED = true;
                            return POS_PRINTNAME_HANDLE;
                        }
                        else
                            return INVALID_HANDLE_VALUE;
                    }
                case POS_OPEN_NETPORT:
                    {
                        return INVALID_HANDLE_VALUE;
                    }
                default:
                    return INVALID_HANDLE_VALUE;
            }
        }

        /// <summary>
        /// 向指定端口写数据
        /// </summary>
        /// <param name="hPort"></param>
        /// <param name="bDataSendBuffer"></param>
        /// <param name="nBytesToWrite"></param>
        /// <returns></returns>
        public static bool POS_WriteFile(int hPort, byte[] bDataSendBuffer, int nBytesToWrite)
        {

            if (hPort == POS_COM_HANDLE)
            {
                POS_COM_SELECTED = true;
                IOCONTROL.OVERLAPPED tempOverLapped = new IOCONTROL.OVERLAPPED();
                uint BytesOfWritten = 0;
                return IOCONTROL.WriteFile(POS_COM_HANDLE, bDataSendBuffer, (uint)nBytesToWrite, ref BytesOfWritten, ref tempOverLapped);
            }
            else if (hPort == POS_PRINTNAME_HANDLE)
            {
                POS_NETPORT_SELECTED = true;
                PRINTEBYNAME.DOC_INFO_1 docInfo = new PRINTEBYNAME.DOC_INFO_1();
                docInfo.pDocName = "RAW Document";
                docInfo.pDatatype = "RAW";
                uint bytesOfWritten = 0;
                bool issuccessful = false;
                if (PRINTEBYNAME.StartDocPrinter(POS_PRINTNAME_HANDLE, 1, ref docInfo) != 0)
                {
                    if (PRINTEBYNAME.StartPagePrinter(POS_PRINTNAME_HANDLE))
                        issuccessful = PRINTEBYNAME.WritePrinter(POS_PRINTNAME_HANDLE, bDataSendBuffer, (uint)nBytesToWrite, ref bytesOfWritten);
                    PRINTEBYNAME.EndPagePrinter(POS_PRINTNAME_HANDLE);
                }
                PRINTEBYNAME.EndDocPrinter(POS_PRINTNAME_HANDLE);
                return issuccessful;
            }
            else
                return false;

        }

        /// <summary>
        /// 关闭已经打开的并口或串口，USB端口，网络接口或打印机。
        /// </summary>
        /// <returns></returns>
        public static int POS_Close()
        {
            if (POS_COM_SELECTED)
            {
                if (POS_COM_HANDLE == -1)
                    return POS_ERROR_INVALID_HANDLE;
                else
                {
                    if (IOCONTROL.CloseHandle(POS_COM_HANDLE))
                        return POS_SUCCESS;
                    else
                        return POS_FAIL;
                }
            }
            else if (POS_PRINTNAME_SELECTED)
            {
                if (POS_PRINTNAME_HANDLE == -1)
                    return POS_ERROR_INVALID_HANDLE;
                else
                {
                    if (PRINTEBYNAME.ClosePrinter(POS_PRINTNAME_HANDLE))
                        return POS_SUCCESS;
                    else
                        return POS_FAIL;
                }
            }
            else
                return POS_ERROR_INVALID_HANDLE;
        }

        public static int POS_Reset()
        {
            int hPort;
            if (POS_COM_SELECTED & (POS_COM_HANDLE != -1))
                hPort = POS_COM_HANDLE;
            else if (POS_PRINTNAME_SELECTED & (POS_PRINTNAME_HANDLE != -1))
                hPort = POS_PRINTNAME_HANDLE;
            else
                return POS_ERROR_INVALID_HANDLE;

            byte[] data = POSCOMMAND.ESC_ALT;
            if (POS_WriteFile(hPort, data, data.Length))
                return POS_SUCCESS;
            else
                return POS_FAIL;
        }

        /// <summary>
        /// 选择打印模式，该函数只对有页模式的打印机有效
        /// 无页模式的不需要设置，只需调用POS_PL_即可
        /// </summary>
        /// <param name="nPrintMode"></param>
        /// <returns></returns>
        public static int POS_SetMode(int nPrintMode)
        {
            if (nPrintMode == 0)
                POS_PAGEMODE_SELECTED = false;
            else
                POS_PAGEMODE_SELECTED = true;

            return POS_SUCCESS;
        }

        public static int POS_SetMotionUnit(int nHorizontalMU, int nVerticalMu)
        {
            if (nHorizontalMU < 0 | nHorizontalMU > 255 | nVerticalMu < 0 | nVerticalMu > 255)
                return POS_ERROR_INVALID_PARAMETER;

            int hPort;
            if (POS_COM_SELECTED & (POS_COM_HANDLE != -1))
                hPort = POS_COM_HANDLE;
            else if (POS_PRINTNAME_SELECTED & (POS_PRINTNAME_HANDLE != -1))
                hPort = POS_PRINTNAME_HANDLE;
            else
                return POS_ERROR_INVALID_HANDLE;

            byte[] data = POSCOMMAND.GS_P_x_y;
            data[2] = (byte)nHorizontalMU;
            data[3] = (byte)nVerticalMu;
            if (POS_WriteFile(hPort, data, data.Length))
                return POS_SUCCESS;
            else
                return POS_FAIL;
        }

        public static int POS_SetCharSetAndCodePage(int nCharSet, int nCodePage)
        {
            if (nCharSet < 0 | nCharSet > 15 | nCodePage < 0 | nCodePage > 19 | (nCodePage > 10 & nCodePage < 16))
                return POS_ERROR_INVALID_PARAMETER;
            int hPort;
            if (POS_COM_SELECTED & (POS_COM_HANDLE != -1))
                hPort = POS_COM_HANDLE;
            else if (POS_PRINTNAME_SELECTED & (POS_PRINTNAME_HANDLE != -1))
                hPort = POS_PRINTNAME_HANDLE;
            else
                return POS_ERROR_INVALID_HANDLE;

            byte[] data = new byte[POSCOMMAND.ESC_R_n.Length + POSCOMMAND.ESC_t_n.Length];
            POSCOMMAND.ESC_R_n[2] = (byte)nCharSet;
            POSCOMMAND.ESC_R_n.CopyTo(data, 0);
            POSCOMMAND.ESC_t_n[2] = (byte)nCodePage;
            POSCOMMAND.ESC_t_n.CopyTo(data, POSCOMMAND.ESC_R_n.Length);
            if (POS_WriteFile(hPort, data, data.Length))
                return POS_SUCCESS;
            else
                return POS_FAIL;
        }

        public static int POS_FeedLine()
        {
            int hPort;
            if (POS_COM_SELECTED & (POS_COM_HANDLE != -1))
                hPort = POS_COM_HANDLE;
            else if (POS_PRINTNAME_SELECTED & (POS_PRINTNAME_HANDLE != -1))
                hPort = POS_PRINTNAME_HANDLE;
            else
                return POS_ERROR_INVALID_HANDLE;

            byte[] data = POSCOMMAND.LF;
            if (POS_WriteFile(hPort, data, data.Length))
                return POS_SUCCESS;
            else
                return POS_FAIL;
        }

        public static int POS_SetLineSpacing(int nDistance)
        {
            if (nDistance < 0 | nDistance > 255)
                return POS_ERROR_INVALID_PARAMETER;
            int hPort;
            if (POS_COM_SELECTED & (POS_COM_HANDLE != -1))
                hPort = POS_COM_HANDLE;
            else if (POS_PRINTNAME_SELECTED & (POS_PRINTNAME_HANDLE != -1))
                hPort = POS_PRINTNAME_HANDLE;
            else
                return POS_ERROR_INVALID_HANDLE;

            POSCOMMAND.ESC_3_n[2] = (byte)nDistance;
            byte[] data = POSCOMMAND.ESC_3_n;
            if (POS_WriteFile(hPort, data, data.Length))
                return POS_SUCCESS;
            else
                return POS_FAIL;
        }

        public static int POS_SetRightSpacing(int nDistance)
        {
            if (nDistance < 0 | nDistance > 255)
                return POS_ERROR_INVALID_PARAMETER;
            int hPort;
            if (POS_COM_SELECTED & (POS_COM_HANDLE != -1))
                hPort = POS_COM_HANDLE;
            else if (POS_PRINTNAME_SELECTED & (POS_PRINTNAME_HANDLE != -1))
                hPort = POS_PRINTNAME_HANDLE;
            else
                return POS_ERROR_INVALID_HANDLE;

            POSCOMMAND.ESC_SP_n[2] = (byte)nDistance;
            byte[] data = POSCOMMAND.ESC_SP_n;
            if (POS_WriteFile(hPort, data, data.Length))
                return POS_SUCCESS;
            else
                return POS_FAIL;
        }

        /// <summary>
        /// nID指示引脚，0为引脚2,1为引脚5。
        /// 暂不支持nOffTimes，此参数可以为0。
        /// </summary>
        /// <param name="nID"></param>
        /// <param name="nOnTimes"></param>
        /// <param name="nOffTimes"></param>
        /// <returns></returns>
        public static int POS_KickOutDrawer(int nID, int nOnTimes, int nOffTimes)
        {
            if (nID > 1 | nID < 0 | nOnTimes < 1 | nOnTimes > 8)
                return POS_ERROR_INVALID_PARAMETER;
            int hPort;
            if (POS_COM_SELECTED & (POS_COM_HANDLE != -1))
                hPort = POS_COM_HANDLE;
            else if (POS_PRINTNAME_SELECTED & (POS_PRINTNAME_HANDLE != -1))
                hPort = POS_PRINTNAME_HANDLE;
            else
                return POS_ERROR_INVALID_HANDLE;

            POSCOMMAND.DLE_DC4_n_m_t[3] = (byte)nID;
            POSCOMMAND.DLE_DC4_n_m_t[4] = (byte)nOnTimes;
            byte[] data = POSCOMMAND.DLE_DC4_n_m_t;
            if (POS_WriteFile(hPort, data, data.Length))
                return POS_SUCCESS;
            else
                return POS_FAIL;
        }

        /// <summary>
        /// nMode为0，则全切，nMode为1，则半切。
        /// nMode为2，则进纸(打印点到切刀距离+nDistance)并切纸。
        /// </summary>
        /// <param name="nMode"></param>
        /// <param name="nDistance"></param>
        /// <returns></returns>
        public static int POS_CutPaper(int nMode, int nDistance)
        {
            if (nMode < 0 | nMode > 2 | (nMode == 2 & (nDistance > 255 | nDistance < 0)))
                return POS_ERROR_INVALID_PARAMETER;
            int hPort;
            if (POS_COM_SELECTED & (POS_COM_HANDLE != -1))
                hPort = POS_COM_HANDLE;
            else if (POS_PRINTNAME_SELECTED & (POS_PRINTNAME_HANDLE != -1))
                hPort = POS_PRINTNAME_HANDLE;
            else
                return POS_ERROR_INVALID_HANDLE;

            byte[] data;
            switch (nMode)
            {
                case 0:
                case 1:
                    POSCOMMAND.GS_V_m[2] = (byte)nMode;
                    data = POSCOMMAND.GS_V_m;
                    break;
                case 2:
                    POSCOMMAND.GS_V_m_n[3] = (byte)nDistance;
                    data = POSCOMMAND.GS_V_m_n;
                    break;
                default:
                    return POS_ERROR_INVALID_PARAMETER;
            }
            if (POS_WriteFile(hPort, data, data.Length))
                return POS_SUCCESS;
            else
                return POS_FAIL;
        }

        public static int POS_S_SetAreaWidth(int nWidth)
        {
            if (nWidth < 0 | nWidth > 65535)
                return POS_ERROR_INVALID_PARAMETER;
            int hPort;
            if (POS_COM_SELECTED & (POS_COM_HANDLE != -1))
                hPort = POS_COM_HANDLE;
            else if (POS_PRINTNAME_SELECTED & (POS_PRINTNAME_HANDLE != -1))
                hPort = POS_PRINTNAME_HANDLE;
            else
                return POS_ERROR_INVALID_HANDLE;

            byte nL = (byte)(nWidth % 0x100);
            byte nH = (byte)(nWidth / 0x100);
            POSCOMMAND.GS_W_nL_nH[2] = nL;
            POSCOMMAND.GS_W_nL_nH[3] = nH;
            byte[] data = POSCOMMAND.GS_W_nL_nH;
            if (POS_WriteFile(hPort, data, data.Length))
                return POS_SUCCESS;
            else
                return POS_FAIL;
        }

        public static int POS_S_TextOut(string pszString, int nOrgx, int nWidthTimes, int nHeightTimes, int nFontType, int nFontStyle)
        {
            if (nOrgx > 65535 | nOrgx < 0 |
                nWidthTimes > 7 | nWidthTimes < 0 | nHeightTimes > 7 | nHeightTimes < 0 |
                nFontType < 0 | nFontType > 4)
                return POS_ERROR_INVALID_PARAMETER;

            int hPort;
            if (POS_COM_SELECTED & (POS_COM_HANDLE != -1))
                hPort = POS_COM_HANDLE;
            else if (POS_PRINTNAME_SELECTED & (POS_PRINTNAME_HANDLE != -1))
                hPort = POS_PRINTNAME_HANDLE;
            else
                return POS_ERROR_INVALID_HANDLE;

            byte[] pbString = Encoding.Default.GetBytes(pszString);
            int dataLength = pbString.Length + POSCOMMAND.ESC_dollors_nL_nH.Length + POSCOMMAND.GS_exclamationmark_n.Length +
                POSCOMMAND.ESC_M_n.Length + POSCOMMAND.GS_E_n.Length + POSCOMMAND.FS_line_n.Length +
                POSCOMMAND.ESC_lbracket_n.Length + POSCOMMAND.GS_B_n.Length + POSCOMMAND.ESC_V_n.Length;

            byte[] data = new byte[dataLength];
            int offset = 0;
            POSCOMMAND.ESC_dollors_nL_nH[2] = (byte)(nOrgx % 0x100);
            POSCOMMAND.ESC_dollors_nL_nH[3] = (byte)(nOrgx / 0x100);
            POSCOMMAND.ESC_dollors_nL_nH.CopyTo(data, offset);
            offset += POSCOMMAND.ESC_dollors_nL_nH.Length;
            byte[] intToWidth = { 0x00, 0x10, 0x20, 0x30, 0x40, 0x50, 0x60, 0x70 };
            byte[] intToHeight = { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07 };
            POSCOMMAND.GS_exclamationmark_n[2] = (byte)(intToWidth[nWidthTimes] + intToHeight[nHeightTimes]);
            POSCOMMAND.GS_exclamationmark_n.CopyTo(data, offset);
            offset += POSCOMMAND.GS_exclamationmark_n.Length;
            POSCOMMAND.ESC_M_n[2] = (byte)nFontType;
            POSCOMMAND.ESC_M_n.CopyTo(data, offset);
            offset += POSCOMMAND.ESC_M_n.Length;

            //字体风格
            //暂不支持平滑处理
            POSCOMMAND.GS_E_n[2] = (byte)((nFontStyle >> 3) & 0x01);
            POSCOMMAND.GS_E_n.CopyTo(data, offset);
            offset += POSCOMMAND.GS_E_n.Length;
            POSCOMMAND.FS_line_n[2] = (byte)((nFontStyle >> 7) & 0x03);
            POSCOMMAND.FS_line_n.CopyTo(data, offset);
            offset += POSCOMMAND.FS_line_n.Length;
            POSCOMMAND.ESC_lbracket_n[2] = (byte)((nFontStyle >> 9) & 0x01);
            POSCOMMAND.ESC_lbracket_n.CopyTo(data, offset);
            offset += POSCOMMAND.ESC_lbracket_n.Length;
            POSCOMMAND.GS_B_n[2] = (byte)((nFontStyle >> 10) & 0x01);
            POSCOMMAND.GS_B_n.CopyTo(data, offset);
            offset += POSCOMMAND.GS_B_n.Length;
            POSCOMMAND.ESC_V_n[2] = (byte)((nFontStyle >> 12) & 0x01);
            POSCOMMAND.ESC_V_n.CopyTo(data, offset);
            offset += POSCOMMAND.ESC_V_n.Length;

            pbString.CopyTo(data, offset);
            if (POS_WriteFile(hPort, data, data.Length))
                return POS_SUCCESS;
            else
                return POS_FAIL;
        }

        /// <summary>
        /// 不带页模式的小票打印机
        /// 通过PAGEMODE类来实现对页模式的支持
        /// 当前版本不支持第二个参数，参数nOrgy被忽略
        /// </summary>
        /// <param name="nOrgx"></param>
        /// <param name="nOrgy"></param>
        /// <param name="nWidth"></param>
        /// <param name="nHeight"></param>
        /// <param name="nDirection"></param>
        /// <returns></returns>
        public static int POS_PL_SetArea(int nOrgx, int nOrgy, int nWidth, int nHeight, int nDirection)
        {
            if (BITMODE.POS_SelectPageMode(nOrgx, nOrgy, nWidth, nHeight, nDirection))
                return POS_SUCCESS;
            else
                return POS_FAIL;
        }

        /// <summary>
        /// 目前只支持字符串及放大倍数
        /// 该函数并不会立刻答应缓冲区数据，只有调用POS_PL_Print才会把缓冲区的数据打印出来
        /// </summary>
        /// <param name="pszString"></param>
        /// <param name="nOrgx"></param>
        /// <param name="nOrgy"></param>
        /// <param name="nWidthTimes"></param>
        /// <param name="nHeightTimes"></param>
        /// <param name="nFontType"></param>
        /// <param name="nFontStyle"></param>
        /// <returns></returns>
        public static int POS_PL_TextOut(string pszString, int nOrgx, int nOrgy, int nWidthTimes, int nHeightTimes, int nFontType, int nFontStyle)
        {
            BITMODE.POS_PL_TextOut(pszString, nOrgx, nOrgy,nWidthTimes,nHeightTimes,nFontStyle);
            return POS_SUCCESS;
        }

        /// <summary>
        /// 页模式下打印RAM中的位图
        /// 该函数并不立刻打印，而是等到调用POS_PL_Print函数才开始打印
        /// nOrgx为横向绝对位置，nOrgy为纵向绝对位置
        /// </summary>
        /// <param name="nID"></param>
        /// <param name="nOrgx"></param>
        /// <param name="nOrgy"></param>
        /// <param name="nMode"></param>
        /// <returns></returns>
        public static int POS_PL_PrintBmpInRAM(int nID, int nOrgx, int nOrgy, int nMode)
        {
            BITMODE.POS_PL_PrintBmpInRAM(nID, nOrgx, nOrgy, nMode);
            return POS_SUCCESS;
        }

        public static int POS_PL_DownloadAndPrintBmp(string pszPath, int nOrgx, int nOrgy, int nMode)
        {
            BITMODE.POS_PL_DownloadAndPrintBmp(pszPath, nOrgx, nOrgy, nMode);
            return POS_SUCCESS;
        }

        public static int POS_PL_SetBarcode(string pszInfoBuffer, int nOrgx, int nOrgy, int nType, int nWidthX, int nHeight, int nHriFontType, int nHriFontPosition, int nBytesToPrint)
        {

            return POS_FAIL;
        }
        public static int POS_PL_Print()
        {
            int hPort;
            if (POS_COM_SELECTED & (POS_COM_HANDLE != -1))
                hPort = POS_COM_HANDLE;
            else if (POS_PRINTNAME_SELECTED & (POS_PRINTNAME_HANDLE != -1))
                hPort = POS_PRINTNAME_HANDLE;
            else
                return POS_ERROR_INVALID_HANDLE;

            byte[] data = BITMODE.POS_Print();

            if (POS_WriteFile(hPort, data, data.Length))
                return POS_SUCCESS;
            else
                return POS_FAIL;
        }

        public static int POS_PL_Clear()
        {
            BITMODE.POS_Clear();
            return POS_SUCCESS;
        }

        /// <summary>
        /// 下载到RAM位图，暂时只支持一张图片，第二个参数将会被忽略。
        /// </summary>
        /// <param name="pszPath"></param>
        /// <param name="nID"></param>
        /// <returns></returns>
        public static int POS_PreDownloadBmpToRAM(string pszPath, int nID)
        {
            BITMODE.POS_PreDownloadBmpToRAM(pszPath, nID);
            int hPort;
            if (POS_COM_SELECTED & (POS_COM_HANDLE != -1))
                hPort = POS_COM_HANDLE;
            else if (POS_PRINTNAME_SELECTED & (POS_PRINTNAME_HANDLE != -1))
                hPort = POS_PRINTNAME_HANDLE;
            else
                return POS_ERROR_INVALID_HANDLE;

            byte[] data = TEXTANDPIC.TAC_PreDownloadBmpToRam(pszPath);
            if (POS_WriteFile(hPort, data, data.Length))
                return POS_SUCCESS;
            else
                return POS_FAIL;
        }

        /// <summary>
        /// 第二个参数被忽略，只接受第一个参数
        /// </summary>
        /// <param name="pszPaths"></param>
        /// <param name="nCount"></param>
        /// <returns></returns>
        public static int POS_PreDownloadBmpsToFlash(string[] pszPaths, int nCount)
        {
            int hPort;
            if (POS_COM_SELECTED & (POS_COM_HANDLE != -1))
                hPort = POS_COM_HANDLE;
            else if (POS_PRINTNAME_SELECTED & (POS_PRINTNAME_HANDLE != -1))
                hPort = POS_PRINTNAME_HANDLE;
            else
                return POS_ERROR_INVALID_HANDLE;

            byte[] data = TEXTANDPIC.TAC_PreDownloadBmpsToFlash(pszPaths);
            if (POS_WriteFile(hPort, data, data.Length))
                return POS_SUCCESS;
            else
                return POS_FAIL;
        }

        /// <summary>
        /// nID被忽略，只支持一张图片
        /// </summary>
        /// <param name="nID"></param>
        /// <param name="nOrgx"></param>
        /// <param name="nMode"></param>
        /// <returns></returns>
        public static int POS_S_PrintBmpInRAM(int nID, int nOrgx, int nMode)
        {
            if (nOrgx < 0 | nOrgx > 65535)
                return POS_ERROR_INVALID_PARAMETER;

            int hPort;
            if (POS_COM_SELECTED & (POS_COM_HANDLE != -1))
                hPort = POS_COM_HANDLE;
            else if (POS_PRINTNAME_SELECTED & (POS_PRINTNAME_HANDLE != -1))
                hPort = POS_PRINTNAME_HANDLE;
            else
                return POS_ERROR_INVALID_HANDLE;

            int dataLength = POSCOMMAND.ESC_dollors_nL_nH.Length + POSCOMMAND.GS_backslash_m.Length;
            byte[] data = new byte[dataLength];
            int offset = 0;
            POSCOMMAND.ESC_dollors_nL_nH[2] = (byte)(nOrgx % 0x100);
            POSCOMMAND.ESC_dollors_nL_nH[3] = (byte)(nOrgx / 0x100);
            POSCOMMAND.ESC_dollors_nL_nH.CopyTo(data, offset);
            offset += POSCOMMAND.ESC_dollors_nL_nH.Length;
            POSCOMMAND.GS_backslash_m[2] = (byte)(nMode & 0x03);
            POSCOMMAND.GS_backslash_m.CopyTo(data, offset);
            if (POS_WriteFile(hPort, data, data.Length))
                return POS_SUCCESS;
            else
                return POS_FAIL;
        }

        public static int POS_S_PrintBmpInFlash(int nID, int nOrgx, int nMode)
        {
            if (nOrgx < 0 | nOrgx > 65535 | nID < 1 | nID > 255)
                return POS_ERROR_INVALID_PARAMETER;

            int hPort;
            if (POS_COM_SELECTED & (POS_COM_HANDLE != -1))
                hPort = POS_COM_HANDLE;
            else if (POS_PRINTNAME_SELECTED & (POS_PRINTNAME_HANDLE != -1))
                hPort = POS_PRINTNAME_HANDLE;
            else
                return POS_ERROR_INVALID_HANDLE;

            int dataLength = POSCOMMAND.ESC_dollors_nL_nH.Length + POSCOMMAND.FS_p_n_m.Length;
            byte[] data = new byte[dataLength];
            int offset = 0;
            POSCOMMAND.ESC_dollors_nL_nH[2] = (byte)(nOrgx % 0x100);
            POSCOMMAND.ESC_dollors_nL_nH[3] = (byte)(nOrgx / 0x100);
            POSCOMMAND.ESC_dollors_nL_nH.CopyTo(data, offset);
            offset += POSCOMMAND.ESC_dollors_nL_nH.Length;
            POSCOMMAND.FS_p_n_m[2] = (byte)(nID);
            POSCOMMAND.FS_p_n_m[3] = (byte)(nMode & 0x03);
            POSCOMMAND.FS_p_n_m.CopyTo(data, offset);
            if (POS_WriteFile(hPort, data, data.Length))
                return POS_SUCCESS;
            else
                return POS_FAIL;
        }

        public static int POS_S_SetBarcode(string pszInfoBuffer, int nOrgx, int nType, int nWidthX, int nHeight, int nHriFontType, int nHriFontPosition, int nBytesToPrint)
        {
            if (nOrgx < 0 | nOrgx > 65535 | nType < 0x41 | nType > 0x49 | nWidthX < 2 | nWidthX > 6 | nHeight < 1 | nHeight > 255 | (pszInfoBuffer.Length != nBytesToPrint))
                return POS_ERROR_INVALID_PARAMETER;

            int hPort;
            if (POS_COM_SELECTED & (POS_COM_HANDLE != -1))
                hPort = POS_COM_HANDLE;
            else if (POS_PRINTNAME_SELECTED & (POS_PRINTNAME_HANDLE != -1))
                hPort = POS_PRINTNAME_HANDLE;
            else
                return POS_ERROR_INVALID_HANDLE;

            byte[] pbString = Encoding.Default.GetBytes(pszInfoBuffer);
            int dataLength = POSCOMMAND.ESC_dollors_nL_nH.Length + POSCOMMAND.GS_w_n.Length +
                POSCOMMAND.GS_h_n.Length + POSCOMMAND.GS_f_n.Length +
                POSCOMMAND.GS_H_n.Length + POSCOMMAND.GS_k_m_n_.Length + pbString.Length;

            byte[] data = new byte[dataLength];
            int offset = 0;
            POSCOMMAND.ESC_dollors_nL_nH[2] = (byte)(nOrgx % 0x100);
            POSCOMMAND.ESC_dollors_nL_nH[3] = (byte)(nOrgx / 0x100);
            POSCOMMAND.ESC_dollors_nL_nH.CopyTo(data, offset);
            offset += POSCOMMAND.ESC_dollors_nL_nH.Length;
            POSCOMMAND.GS_w_n[2] = (byte)nWidthX;
            POSCOMMAND.GS_w_n.CopyTo(data, offset);
            offset += POSCOMMAND.GS_w_n.Length;
            POSCOMMAND.GS_h_n[2] = (byte)nHeight;
            POSCOMMAND.GS_h_n.CopyTo(data, offset);
            offset += POSCOMMAND.GS_h_n.Length;
            POSCOMMAND.GS_f_n[2] = (byte)(nHriFontType & 0x01);
            POSCOMMAND.GS_f_n.CopyTo(data, offset);
            offset += POSCOMMAND.GS_f_n.Length;
            POSCOMMAND.GS_H_n[2] = (byte)(nHriFontPosition & 0x03);
            POSCOMMAND.GS_H_n.CopyTo(data, offset);
            offset += POSCOMMAND.GS_H_n.Length;
            POSCOMMAND.GS_k_m_n_[2] = (byte)nType;
            POSCOMMAND.GS_k_m_n_[3] = (byte)pbString.Length;
            POSCOMMAND.GS_k_m_n_.CopyTo(data, offset);
            offset += POSCOMMAND.GS_k_m_n_.Length;
            pbString.CopyTo(data, offset);

            if (POS_WriteFile(hPort, data, data.Length))
                return POS_SUCCESS;
            else
                return POS_FAIL;
        }

        public static int POS_PL_Test()
        {
            int hPort;
            if (POS_COM_SELECTED & (POS_COM_HANDLE != -1))
                hPort = POS_COM_HANDLE;
            else if (POS_PRINTNAME_SELECTED & (POS_PRINTNAME_HANDLE != -1))
                hPort = POS_PRINTNAME_HANDLE;
            else
                return POS_ERROR_INVALID_HANDLE;



            byte[] data = BITMODE.POS_Print();

            if (POS_WriteFile(hPort, data, data.Length))
                return POS_SUCCESS;
            else
                return POS_FAIL;
        }

    }
}
