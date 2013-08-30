using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;

namespace printpic
{
    public partial class Form1 : Form
    {
        SerialPort mSerialPort;
        Parity[] paritys = { Parity.None, Parity.Odd, Parity.Even, Parity.Mark, Parity.Space };
        StopBits[] stopbitss = { StopBits.One, StopBits.OnePointFive, StopBits.Two };
        string pictureBoxFilePath = "iu.jpg";
        Bitmap mBitmap;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxBaudrate.SelectedIndex = 4;
            comboBoxDatabits.SelectedIndex = 3;
            comboBoxFlowControl.SelectedIndex = 0;
            comboBoxPort.SelectedIndex = 0;
            comboBoxStopbits.SelectedIndex = 0;
            comboBoxParitybits.SelectedIndex = 0;
            radioButton384.Select();
            buttonOpen.Enabled = true;
            buttonClose.Enabled = false;
            mSerialPort = new SerialPort();
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            string portname = comboBoxPort.Text;
            if (null == portname || "".Equals(portname))
                return;
            int baudrate = int.Parse(comboBoxBaudrate.Text);
            if (baudrate <= 0)
                return;
            Parity parity = paritys[comboBoxParitybits.SelectedIndex];
            StopBits stopbits = stopbitss[comboBoxStopbits.SelectedIndex];
            int databits = int.Parse(comboBoxDatabits.Text);

            mSerialPort.PortName = portname;
            mSerialPort.BaudRate = baudrate;
            mSerialPort.Parity = parity;
            mSerialPort.StopBits = stopbits;
            mSerialPort.DataBits = databits;
            if (comboBoxFlowControl.SelectedIndex != 0)
            {
                mSerialPort.DtrEnable = true;
                mSerialPort.RtsEnable = true;
            }

            mSerialPort.Open();
            if (mSerialPort.IsOpen)
            {
                buttonOpen.Enabled = false;
                buttonClose.Enabled = true;
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            if (null != mSerialPort)
            {
                mSerialPort.Close();
                buttonClose.Enabled = false;
                buttonOpen.Enabled = true;
            }
        }

        private void radioButton384_CheckedChanged(object sender, EventArgs e)
        {
            if (File.Exists(pictureBoxFilePath))
            {
                Bitmap b = new Bitmap(pictureBoxFilePath);
                int width = 384;
                int height = b.Height * width / b.Width;
                height = (height + 7) / 8 * 8;
                mBitmap = Pos.POS_ResizeBitmap(b, width, height);
                if (null != mBitmap)
                    pictureBoxPicture.Image = Image.FromHbitmap(mBitmap.GetHbitmap());
            }
        }

        private void radioButton576_CheckedChanged(object sender, EventArgs e)
        {
            if (File.Exists(pictureBoxFilePath))
            {
                Bitmap b = new Bitmap(pictureBoxFilePath);
                int width = 576;
                int height = b.Height * width / b.Width;
                height = (height + 7) / 8 * 8;
                mBitmap = Pos.POS_ResizeBitmap(b, width, height);
                if (null != mBitmap)
                    pictureBoxPicture.Image = Image.FromHbitmap(mBitmap.GetHbitmap());
            }
        }


        /* 外部调用，直接打印位图 */
        /* 该函数不会改变位图宽度，只会将位图的数据转为打印机可打印的流数据 */
        private void POS_PrintBitmap(Bitmap orgBitmap)
        {
            byte[][] data = Pos.POS_BitmapToStream(orgBitmap);
            if (null == data)
                return;
            Pos.format_K_dither16x16(data, data);
            byte[] combineddata = Pos.TurnBitStreamToByte(data);
            byte[] headdata = new byte[8];
            int widthbytes = (data[0].Length + 7) / 8;
            int heightbits = data.Length;
            headdata[0] = 0x1d;
            headdata[1] = 0x76;
            headdata[2] = 0x30;
            headdata[3] = 0x00;
            headdata[4] = (byte)(widthbytes % 256);
            headdata[5] = (byte)(widthbytes / 256);
            headdata[6] = (byte)(heightbits % 256);
            headdata[7] = (byte)(heightbits / 256);
            if (mSerialPort.IsOpen)
            {
                mSerialPort.Write(headdata, 0, headdata.Length);
                mSerialPort.Write(combineddata, 0, combineddata.Length);
            }
        }

        private void buttonLoadPicture_Click(object sender, EventArgs e)
        {
            openFileDialogLoadPicture.ShowDialog();
        }

        private void buttonPrintPicture_Click(object sender, EventArgs e)
        {
            if (null != mBitmap)
                POS_PrintBitmap(mBitmap);
        }

        private void openFileDialogLoadPicture_FileOk(object sender, CancelEventArgs e)
        {
            pictureBoxFilePath = openFileDialogLoadPicture.FileName;
            if (radioButton384.Checked)
                radioButton384_CheckedChanged(sender, e);
            else
                radioButton576_CheckedChanged(sender, e);
        }

        private void buttonPrintToFile_Click(object sender, EventArgs e)
        {
            if (null == mBitmap)
                return;
            if (checkBoxOutCcode.Checked)
                printBitmapToCcode(mBitmap, pictureBoxFilePath+".c");
            if (checkBoxOutBin.Checked)
                printBitmapToBin(mBitmap, pictureBoxFilePath+".bin");
        }

        private void printBitmapToCcode(Bitmap orgBitmap, string filepath)
        {
            byte[][] data = Pos.POS_BitmapToStream(orgBitmap);
            if (null == data)
                return;
            Pos.format_K_dither16x16(data, data);
            byte[] combineddata = Pos.TurnBitStreamToByte(data);
            byte[] headdata = new byte[8];
            int widthbytes = (data[0].Length + 7) / 8;
            int heightbits = data.Length;
            headdata[0] = 0x1d;
            headdata[1] = 0x76;
            headdata[2] = 0x30;
            headdata[3] = 0x00;
            headdata[4] = (byte)(widthbytes % 256);
            headdata[5] = (byte)(widthbytes / 256);
            headdata[6] = (byte)(heightbits % 256);
            headdata[7] = (byte)(heightbits / 256);

            try
            {
                StreamWriter sw = new StreamWriter(filepath, false, System.Text.Encoding.Default);
                sw.Write("{\r\n\t");
                for (int i = 0; i < headdata.Length; i++)
                {
                    sw.Write(string.Format("0x{0:x2}, ", headdata[i]));
                }
                sw.Write("\r\n\r\n\t");
                for (int i = 0; i < combineddata.Length; i++)
                {
                    sw.Write(string.Format("0x{0:x2}, ", combineddata[i]));
                    if (i % 8 == 7)
                        sw.Write("\r\n\t");
                }
                sw.Write("\r\n};");
                sw.Close();
            }
            catch (IOException e)
            {
            }
        }

        private void printBitmapToBin(Bitmap orgBitmap, string filepath)
        {
            byte[][] data = Pos.POS_BitmapToStream(orgBitmap);
            if (null == data)
                return;
            Pos.format_K_dither16x16(data, data);
            byte[] combineddata = Pos.TurnBitStreamToByte(data);
            byte[] headdata = new byte[8];
            int widthbytes = (data[0].Length + 7) / 8;
            int heightbits = data.Length;
            headdata[0] = 0x1d;
            headdata[1] = 0x76;
            headdata[2] = 0x30;
            headdata[3] = 0x00;
            headdata[4] = (byte)(widthbytes % 256);
            headdata[5] = (byte)(widthbytes / 256);
            headdata[6] = (byte)(heightbits % 256);
            headdata[7] = (byte)(heightbits / 256);

            try
            {
                FileStream fs = new FileStream(filepath, FileMode.Create);
                BinaryWriter bw = new BinaryWriter(fs);
                bw.Write(headdata);
                bw.Write(combineddata);
                bw.Close();
                fs.Close();
            }
            catch (IOException e)
            {

            }
        }

    }
}