/*命名空间：POSDLL
 * 引用：
 * using System;
 * using System.Collections.Generic;
 * using System.Text;
 * using System.Threading;
 * using System.IO.Ports;
 * using System.Net;
 * using System.Net.Sockets;
 * using System.Windows.Forms;
 * using System.Text.RegularExpressions;
 * 类名：COMMUNICATION
 * 作用：专职通信类，打开、关闭端口，侦听端口，发送数据，二进制文件。
 * 
 * 
 * 
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO.Ports;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using Microsoft.Win32;
namespace POSDLL
{
    //专职通信连接
    public class COMMUNICATION
    {
        //不需要的时候，需要结束侦听。
        public static Boolean CMNCT_StartListen(Object obReceive)
        {
            try
            {
                bIsKilling = false;
                System.Threading.Thread newThread = new Thread(new ParameterizedThreadStart(threadHandler));
                newThread.Start(obReceive);
                return true;
            }
            catch { return false; }
        }
        public static void CMNCT_StopListen()
        {
            bIsKilling = true;
            return;
        }
        //receiveBuffer以暂时存储需要传递的数据
        private static String strReceiveBuffer = String.Empty;
        private static Boolean bIsKilling = false;
        private delegate void setTextDelegate(Object obReceive);

        private static void threadHandler(Object obReceive)
        {
            long i = 0;
            while (!bIsKilling)
            {
                byte[] tempData = new byte[4096];
                try
                {
                    if (CmnctSk != null)
                        CmnctSk.Receive(tempData);
                    else if (CmnctSp != null)
                        CmnctSp.Read(tempData, 0, CmnctSp.ReceivedBytesThreshold);
                    else if (CmnctUc != null)
                        CmnctUc.Read(tempData);
                    else
                        return;
                }
                catch { threadHandler(obReceive); }
                strReceiveBuffer = "*" + i.ToString() + "*";
                int k = 0;
                while (tempData[k] != 0)
                {
                    strReceiveBuffer += tempData[k].ToString("x");
                    k++;
                }
                UIHandler(obReceive);
                Thread.Sleep(100);
                i++;
            }
        }
        //子线程的方法
        private static void UIHandler(Object obReceive)
        {
            Type obReceiveType = obReceive.GetType();
            String strObReceiveType = obReceiveType.Name;
            TextBox tbReceive = null;
            Button btReceive = null;
            Label lbReceive = null;

            if (strObReceiveType == "TextBox")
            {
                tbReceive = (TextBox)obReceive;
                if (tbReceive.InvokeRequired)  //判断TextBox控件是否是调用线程(即newThread线程)创建的,也就是是否跨线程调用,如果是则返回true,否则返回false
                    tbReceive.BeginInvoke(new setTextDelegate(setTBText), new object[] { obReceive });  //异步调用setLabelText方法，并传递一个参数   
                else
                    tbReceive.Text = strReceiveBuffer;
            }
            else if (strObReceiveType == "Button")
            {
                btReceive = (Button)obReceive;
                if (tbReceive.InvokeRequired)
                    tbReceive.BeginInvoke(new setTextDelegate(setTBText), new object[] { obReceive });
                else
                    tbReceive.Text = strReceiveBuffer;
            }
            else if (strObReceiveType == "Label")
            {
                lbReceive = (Label)obReceive;
                if (tbReceive.InvokeRequired)
                    tbReceive.BeginInvoke(new setTextDelegate(setTBText), new object[] { obReceive });
                else
                    tbReceive.Text = strReceiveBuffer;
            }
            else
                return;
        }
        //当跨线程调用时，调用该方法进行UI界面更新 
        private static void setTBText(Object obReceive)
        {
            Type obReceiveType = obReceive.GetType();
            String strObReceiveType = obReceiveType.Name;
            TextBox tbReceive = null;
            Button btReceive = null;
            Label lbReceive = null;

            if (strObReceiveType == "TextBox")
            {
                tbReceive = (TextBox)obReceive;
                tbReceive.Text = strReceiveBuffer;
            }
            else if (strObReceiveType == "Button")
            {
                btReceive = (Button)obReceive;
                btReceive.Text = strReceiveBuffer;
            }
            else if (strObReceiveType == "Label")
            {
                lbReceive = (Label)obReceive;
                lbReceive.Text = strReceiveBuffer;
            }
            else
                return;
        }

        /*以上为开启线程侦听的相关函数
         * 
         * 
         * 以下为开启端口并发送数据的相关函数
         */
        private static SerialPort CmnctSp = null;
        private static Socket CmnctSk = null;
        private static USBControl CmnctUc = null;
        //打开一个串口
        public static SerialPort CMNCT_OpenCom(String sComName, int nBaudrate, int nDataBits, float nStopBits, int nParity)
        {
            try
            {
                StopBits[] intToStopBits ={ StopBits.One, StopBits.OnePointFive, StopBits.Two };
                Parity[] intToParity = { Parity.None, Parity.Odd, Parity.Even };
                CmnctSp = new SerialPort(sComName, nBaudrate, intToParity[nParity], nDataBits, intToStopBits[(int)(nStopBits * 2 - 2)]);
                CmnctSp.Open();
                //载入Init资源
                //TEXTANDPIC.TAC_Init();
            }
            catch (Exception Mistake)
            {
                MessageBox.Show(Mistake.ToString());
                CMNCT_CloseCom();
            }
            return CmnctSp;
        }
        public static void CMNCT_CloseCom()
        {
            if (CmnctSp != null)
                CmnctSp.Close();
            CmnctSp = null;
        }

        //打开一个网口，成功则返回一个可用Socket，失败返回null。Port一般指定为9100
        public static Socket CMNCT_OpenLan(String ipAddress, int Port)
        {
            Regex rx = new Regex(@"((?:(?:25[0-5]|2[0-4]\d|((1\d{2})|([1-9]?\d)))\.){3}(?:25[0-5]|2[0-4]\d|((1\d{2})|([1-9]?\d))))");
            if (!rx.IsMatch(ipAddress))
            {
                MessageBox.Show("非法IP。请注意格式形如xxx.xxx.xxx.xxx的字符串才是有效ip地址");
                return null;
            }
            IPAddress ipPrinter = IPAddress.Parse(ipAddress);
            IPEndPoint ipPrinterPoint = new IPEndPoint(ipPrinter, Port);

            if (CmnctSk == null)
            {
                CmnctSk = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    CmnctSk.Connect(ipPrinterPoint);
                    if (!CmnctSk.Connected)
                        throw new Exception("连接失败！");
                    //载入Init资源
                    //TEXTANDPIC.TAC_Init();
                }
                catch (Exception Mistake)
                {
                    MessageBox.Show(Mistake.ToString());
                    CMNCT_CloseLan();
                }
            }
            return CmnctSk;
        }
        public static void CMNCT_CloseLan()
        {
            if (CmnctSk != null)
                CmnctSk.Close();
            CmnctSk = null;
        }

        //打开一个USB口
        public static Int32 CMNCT_OpenUsb(String sDevicePath)
        {
            CmnctUc = new USBControl();
            return CmnctUc.Open(sDevicePath);
        }
        public static bool CMNCT_CloseUsb()
        {
            bool ret = CmnctUc.Close();
            CmnctUc = null;
            return ret;
        }

        //winapi，打开设备，文件等
        private class USBControl
        {
            private const uint GENERIC_READ = 0x80000000;
            private const uint GENERIC_WRITE = 0x40000000;
            private const int FILE_SHARE_READ = 0x00000001;
            private const int FILE_SHARE_WRITE = 0x00000002;
            private const int OPEN_EXISTING = 3;
            private const int CREATE_ALWAYS = 2;
            private const int FILE_ATTRIBUTE_READONLY = 1;
            private const int FILE_ATTRIBUTE_NORMAL = 128;
            [StructLayout(LayoutKind.Sequential)]
            private struct OVERLAPPED
            {
                int Internal;
                int InternalHigh;
                int Offset;
                int OffSetHigh;
                int hEvent;
            }
            //调用DLL.
            [DllImport("kernel32.dll", SetLastError = true)]
            private static extern int CreateFile(string lpFileName, uint dwDesiredAccess, int dwShareMode, int lpSecurityAttributes, int dwCreationDisposition, int dwFlagsAndAttributes, int hTemplateFile);
            [DllImport("kernel32.dll", SetLastError = true)]
            private static extern bool WriteFile(int hFile, byte[] lpBuffer, int nNumberOfBytesToWrite, ref int lpNumberOfBytesWritten, ref OVERLAPPED lpOverlapped);
            [DllImport("kernel32.dll", SetLastError = true)]
            private static extern bool CloseHandle(int hObject);
            [DllImport("kernel32.dll", SetLastError = true)]
            private static extern bool ReadFile(int hFile, byte[] lpBuffer, int nNumberOfBytesToRead, ref int lpNumberofBytesRead, ref OVERLAPPED lpOverlapped);
            private int iHandle;



            /// <summary>
            /// 打开端口
            /// </summary>
            /// <returns></returns>
            public Int32 Open(String sDevicePath)
            {
                iHandle = CreateFile(sDevicePath, GENERIC_WRITE | GENERIC_READ, FILE_SHARE_READ | FILE_SHARE_WRITE, 0, OPEN_EXISTING, 0, 0);
                Int32 lastErrorWrite = Marshal.GetLastWin32Error();
                if (lastErrorWrite != 0)
                {
                    MessageBox.Show("LastError:" + lastErrorWrite.ToString());
                    iHandle = -1;
                }
                return iHandle;
            }

            /// <summary>
            /// 打印命令，通过参数，可以打印小票打印机的一些命令，比如换行，行间距，打印位图等。
            /// </summary>
            /// <param name="mybyte"></param>
            /// <returns></returns>
            public bool Write(byte[] bByteData)
            {
                //如果端口为打开，则提示，打开，则打印
                if (iHandle != -1)
                {
                    int i = 0;
                    OVERLAPPED overlappedPub = new OVERLAPPED();
                    return WriteFile(iHandle, bByteData, bByteData.Length, ref i, ref overlappedPub);
                }
                else
                {
                    throw new Exception("不能连接到打印机!");
                }
            }

            public bool Read(byte[] bByteData)
            {
                //如果端口为打开，则提示，打开，则打印
                if (iHandle != -1)
                {
                    int i = 0;
                    OVERLAPPED overlappedPub = new OVERLAPPED();
                    if (ReadFile(iHandle, bByteData, bByteData.Length, ref i, ref overlappedPub))
                        return true;
                    else
                    {
                        int lasterror = Marshal.GetLastWin32Error();
                        return false;
                    }
                }
                else
                {
                    throw new Exception("不能连接到打印机!");
                }
            }

            /// <summary>
            /// 关闭端口
            /// </summary>
            /// <returns></returns>
            public bool Close()
            {
                return CloseHandle(iHandle);
            }

        }
        //遍历注册表中的DeviceClasses
        public class DeviceClasses
        {
            private static ArrayList deviceClasses = null;
            public static string DC_GetDevices(int vid, int pid)
            {//得到所有可用的设备路径
                deviceClasses = new ArrayList();
                RegistryKey rgkDevices = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\DeviceClasses");
                DC_SubKey(rgkDevices);
                foreach (object d in deviceClasses)
                {
                    string temp = (string)d;
                    if (temp.Contains(vid.ToString()) & temp.Contains(pid.ToString()))
                        return temp;
                }
                return null;
            }
            private static void DC_SubKey(RegistryKey reKey)
            {
                int subNum = reKey.SubKeyCount;
                Object strDevicePath = reKey.GetValue("SymbolicLink", null);
                if (strDevicePath != null)
                    deviceClasses.Add(strDevicePath);
                else if (subNum != 0)
                {
                    string[] tempStr = reKey.GetSubKeyNames();
                    for (int i = 0; i < subNum; i++)
                    {
                        RegistryKey tempKey = reKey.OpenSubKey(tempStr[i]);
                        DC_SubKey(tempKey);
                    }
                }
                else
                    return;
            }

            //得到USB设备的GUID和信息
            private static ArrayList USBDevices = null;
            public static ArrayList DC_GetUSBDevices()
            {
                USBDevices = new ArrayList();
                RegistryKey rgkUSBDevices = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Enum\USB");
                DC_USBSubKey(rgkUSBDevices);
                return USBDevices;
            }
            private static void DC_USBSubKey(RegistryKey reKey)
            {
                RegistryKey subRegKey = reKey.OpenSubKey("Device Parameters");
                if (subRegKey != null)
                {//如果成功打开则可以返回
                    object strUSBDevicePath = subRegKey.GetValue("SymbolicName", null);
                    if (strUSBDevicePath != null)
                    {
                        object[] USBDeviceInfo = new object[2];
                        USBDeviceInfo[0] = reKey.GetValue("DeviceDesc", "UNKNOWN");
                        USBDeviceInfo[1] = strUSBDevicePath;
                        USBDevices.Add(USBDeviceInfo);
                    }
                }
                else
                {//否则，进入子键寻找
                    int subNum = reKey.SubKeyCount;
                    string[] subTemp = reKey.GetSubKeyNames();
                    for (int i = 0; i < subNum; i++)
                    {//如果subNum == 0，则进不去循环直接退出了。
                        RegistryKey tempKey = reKey.OpenSubKey(subTemp[i]);
                        DC_USBSubKey(tempKey);
                    }
                }
            }

            //删除非USBHUB的子键
            public static void DC_USBDelete()
            {
                RegistryKey rgkUSB = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Enum\USB", true);
                string[] strSubUSB = rgkUSB.GetSubKeyNames();
                int k = strSubUSB.Length;
                for (int i = 0; i < k; i++)
                    if (!strSubUSB[i].Contains("ROOT_HUB"))
                        rgkUSB.DeleteSubKeyTree(strSubUSB[i]);
            }

        }

        //下面就要发送数据。将二进制字节数组发送到已打开的端口
        public static Boolean CMNCT_Send(byte[] bArrayCommand)
        {
            try
            {
                if (CmnctSk != null)
                    CmnctSk.Send(bArrayCommand);
                else if (CmnctSp != null)
                    CmnctSp.Write(bArrayCommand, 0, bArrayCommand.Length);
                else if (CmnctUc != null)
                    CmnctUc.Write(bArrayCommand);
                else
                    return false;
            }
            catch (Exception Mistake)
            {
                MessageBox.Show(Mistake.ToString());
                return false;
            }
            return true;
        }
        //可以是绝对路径或相对路径
        public static Boolean CMNCT_Send(String sBinaryFilePath)
        {
            try
            {
                if (CmnctSk != null)
                    CmnctSk.SendFile(sBinaryFilePath);
                else if (CmnctSp != null)
                {
                    System.IO.FileStream fileStream = new System.IO.FileStream(sBinaryFilePath, System.IO.FileMode.Open);
                    byte[] dataToSend = new byte[fileStream.Length];
                    if (dataToSend.Length > Int32.MaxValue)
                    {
                        MessageBox.Show("数据超长");
                        fileStream.Close();
                        return false;
                    }
                    fileStream.Read(dataToSend, 0, (int)fileStream.Length);
                    CmnctSp.Write(dataToSend, 0, dataToSend.Length);
                    fileStream.Close();
                }
                else if (CmnctUc != null)
                {
                    System.IO.FileStream fileStream = new System.IO.FileStream(sBinaryFilePath, System.IO.FileMode.Open);
                    byte[] dataToSend = new byte[fileStream.Length];
                    if (dataToSend.Length > Int32.MaxValue)
                    {
                        MessageBox.Show("数据超长");
                        fileStream.Close();
                        return false;
                    }
                    fileStream.Read(dataToSend, 0, (int)fileStream.Length);
                    CmnctUc.Write(dataToSend);
                    fileStream.Close();
                }
                else
                    return false;
            }
            catch (Exception Mistake)
            {
                MessageBox.Show(Mistake.ToString());
                return false;
            }
            return true;
        }
        //异步发送
        public static Boolean CMNCT_SendByNewThread(byte[] bArrayCommand)
        {
            try
            {
                System.Threading.Thread trWrite = new Thread(new ParameterizedThreadStart(CMNCT_TRStart));
                trWrite.Start(bArrayCommand);
                return true;
            }
            catch (Exception Mistake)
            {
                MessageBox.Show(Mistake.ToString());
                return false;
            }
        }

        private static Boolean[] boIsComplete = new Boolean[4096];//指示线程是否完成
        private static int index = 1;//线程序号
        private static void CMNCT_TRStart(Object obArrayCommand)
        {
            int nWatashiNoIndex = index++;//只要start了，index就要+1
            boIsComplete[0] = true;//如果是第一个线程，那么就将添加0号线程为已完成
            try
            {
                while (true)
                {
                    if (boIsComplete[nWatashiNoIndex - 1])
                    {
                        byte[] bArrayCommand = (byte[])obArrayCommand;
                        if (CmnctSk != null)
                        {
                            CmnctSk.Send(bArrayCommand);
                            boIsComplete[nWatashiNoIndex] = true;
                            return;
                        }
                        else if (CmnctSp != null)
                        {
                            CmnctSp.Write(bArrayCommand, 0, bArrayCommand.Length);
                            boIsComplete[nWatashiNoIndex] = true;
                            return;
                        }
                        else
                            throw (new Exception("未将对象设置引用到对象实例？"));

                    }
                }
            }
            catch (Exception Mistake)
            {
                MessageBox.Show(Mistake.ToString());
                boIsComplete[nWatashiNoIndex] = true;
            }
        }

        public static class Status
        {
            public static string[] MoneyBox = { "一个或两个钱箱打开", "两个钱箱都关闭" };
            public static string[] OnLineOrNot = { "联机", "脱机" };
            public static string[] Cover = { "上盖关", "上盖开" };
            public static string[] FeedButton = { "未按走纸键", "按下走纸键" };
            public static string[] PaperNeeded = { "打印机不缺纸", "打印机缺纸" };
            public static string[] NotError = { "没有出错情况", "有错误情况" };
            public static string[] Knife = { "切刀无错误", "切刀有错误" };
            public static string[] UnRestoreableError = { "无不可恢复错误", "有不可恢复错误" };
            public static string[] PrintPoint = { "打印头温度和电压正常", "打印头温度和电压超出范围" };
            public static string[] PaperNeartheend = { "有纸","纸将尽"};
            public static string[] PaperEnd ={ "有纸", "纸尽" };

            public static byte[] RQStatus = { 0x10, 0x04, 0x01 };

            public const int DLE_EOT_01 = 1;
            public const int DLE_EOT_02 = 2;
            public const int DLE_EOT_03 = 3;
            public const int DLE_EOT_04 = 4;

            public static string Sta_ReturnStatus(byte reValue, int ReCode)
            {
                if (reValue == 0)
                    return "数据为0\n";
                string temp = string.Empty;
                switch (ReCode)
                {
                    case DLE_EOT_01:
                        temp += MoneyBox[(reValue >> 2) & 0x01] + "\n";
                        temp += OnLineOrNot[(reValue >> 3) & 0x01] + "\n";
                        return temp;
                    case DLE_EOT_02:
                        temp += Cover[(reValue >> 2) & 0x01] + "\n";
                        temp += FeedButton[(reValue >> 3) & 0x01] + "\n";
                        temp += PaperNeeded[(reValue >> 5) & 0x01] + "\n";
                        temp += NotError[(reValue >> 6) & 0x01] + "\n";
                        return temp;
                    case DLE_EOT_03:
                        temp += Knife[(reValue >> 3) & 0x01] + "\n";
                        temp += UnRestoreableError[(reValue >> 5) & 0x01] + "\n";
                        temp += PrintPoint[(reValue >> 6) & 0x01] + "\n";
                        return temp;
                    case DLE_EOT_04:
                        temp += PaperNeartheend[(reValue >> 3) & 0x01] + "\n";
                        temp += PaperEnd[(reValue >> 6) & 0x01] + "\n";
                        return temp;
                    default:
                        return null;
                }
            }
        }
        
    }
}
