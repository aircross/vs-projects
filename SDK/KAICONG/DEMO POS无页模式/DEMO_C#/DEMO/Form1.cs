using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using POSDLL_V2;
using POSDLL;

namespace DEMO
{
    public partial class POSDLL_V1 : Form
    {
        public static POSDLL_V1 fmPOSDLL_V1; 
        public static int hPort = -1;
        string lpName = string.Empty;
        int nParam = -1;
        int nBaudrate = -1;
        int nDataBits = -1;
        int nStopBits = -1;
        int nParity = -1;
        string[] RAMimagePath = new string[2];

        public POSDLL_V1()
        {
            InitializeComponent();
            fmPOSDLL_V1 = this;
        }

        private void rbCom_CheckedChanged(object sender, EventArgs e)
        {
            cbDriveName.Enabled = false;
            cbComName.Enabled = true;
            cbDataBits.Enabled = true;
            cbParity.Enabled = true;
            cbStopBits.Enabled = true;
            cbStreamCtr.Enabled = true;
            cbBaudrate.Enabled = true;

        }

        private void rbDriveProgram_CheckedChanged(object sender, EventArgs e)
        {
            cbComName.Enabled = false;
            cbDataBits.Enabled = false;
            cbParity.Enabled = false;
            cbStopBits.Enabled = false;
            cbStreamCtr.Enabled = false;
            cbBaudrate.Enabled = false;
            cbDriveName.Enabled = true;
            nParam = C_POSDLL.POS_OPEN_PRINTNAME;
        }

        private void btOpen_Click(object sender, EventArgs e)
        {
            btOpen.Enabled = false;
            btStatus.Enabled = true;
            btPrint.Enabled = true;
            btClose.Enabled = true;
            hPort = C_POSDLL.POS_Open(lpName, nBaudrate, nDataBits, nStopBits, nParity, nParam);
            MessageBox.Show("0x" + hPort.ToString("x"));

        }

        private void btClose_Click(object sender, EventArgs e)
        {
            int rValue = C_POSDLL.POS_Close();
            MessageBox.Show("0x" + rValue.ToString("x"));
            btOpen.Enabled = true;
            btStatus.Enabled = false;
            btPrint.Enabled = false;
            btClose.Enabled = false;
        }

        private void cbDriveName_SelectedIndexChanged(object sender, EventArgs e)
        {
            lpName = cbDriveName.Text;
        }

        private void cbComName_SelectedIndexChanged(object sender, EventArgs e)
        {
            lpName = cbComName.Text;
        }

        private void cbStreamCtr_SelectedIndexChanged(object sender, EventArgs e)
        {
            nParam = cbStreamCtr.SelectedIndex;
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            
            C_POSDLL.POS_SetMode(0);
            C_POSDLL.POS_S_TextOut("POS Thermal Printer", 48, 0, 2, 0, 0x00);
            C_POSDLL.POS_FeedLine();
            C_POSDLL.POS_FeedLine();
            C_POSDLL.POS_S_TextOut("热敏打印机", 24, 0, 0, 0, 0x100);
            C_POSDLL.POS_FeedLine();
            C_POSDLL.POS_SetRightSpacing(12);
            C_POSDLL.POS_S_TextOut("热敏打印机", 24, 0, 0, 0, 0x80);
            C_POSDLL.POS_FeedLine();
            C_POSDLL.POS_FeedLine();
            C_POSDLL.POS_SetRightSpacing(0);
            C_POSDLL.POS_S_TextOut("BM9000", 0, 0, 0, 1, 0x80);
            C_POSDLL.POS_S_TextOut("POS PRINTER", 192, 0, 0, 0, 0x00);
            C_POSDLL.POS_FeedLine();
            C_POSDLL.POS_SetRightSpacing(3);
            C_POSDLL.POS_S_TextOut("BM9000", 0, 0, 0, 1, 0x80);
            C_POSDLL.POS_S_TextOut("POS PRINTER", 192, 0, 0, 0, 0x00);
            C_POSDLL.POS_FeedLine();
            C_POSDLL.POS_SetRightSpacing(6);
            C_POSDLL.POS_S_TextOut("BM9000", 0, 0, 0, 1, 0x80);
            C_POSDLL.POS_S_TextOut("POS PRINTER", 192, 0, 0, 0, 0x00);
            C_POSDLL.POS_FeedLine();
            C_POSDLL.POS_S_TextOut("正常字体打印", 0, 0, 0, 0, 0x00);
            C_POSDLL.POS_FeedLine();
            C_POSDLL.POS_S_TextOut("反显字体打印", 0, 0, 0, 0, 0x400);
            C_POSDLL.POS_FeedLine();
            C_POSDLL.POS_S_TextOut("顺时针旋转90度字体打印", 0, 0, 0, 0, 0x1000);
            C_POSDLL.POS_FeedLine();
            C_POSDLL.POS_S_TextOut("倒置字体打印", 0, 0, 0, 0, 0x200);
            C_POSDLL.POS_FeedLine();
            C_POSDLL.POS_S_TextOut("    ----------------> Logo 1", 0, 0, 0, 0, 0);
            C_POSDLL.POS_FeedLine();
            C_POSDLL.POS_PreDownloadBmpToRAM(RAMimagePath[0], 0);
            C_POSDLL.POS_S_PrintBmpInRAM(0, 96, 0);
            C_POSDLL.POS_S_TextOut("    ----------------> Logo 2", 0, 0, 0, 0, 0);
            C_POSDLL.POS_FeedLine();
            C_POSDLL.POS_PreDownloadBmpToRAM(RAMimagePath[1], 0);
            C_POSDLL.POS_S_PrintBmpInRAM(0, 0, 3);
            C_POSDLL.POS_S_TextOut("    ----------------> Logo 3", 0, 0, 0, 0, 0);
            C_POSDLL.POS_FeedLine();
            C_POSDLL.POS_S_PrintBmpInFlash(1, 96, 0);
            C_POSDLL.POS_S_TextOut("UPC-A", 0, 0, 0, 0, 0);
            C_POSDLL.POS_FeedLine();
            C_POSDLL.POS_S_SetBarcode("01234567890", 24, 0x41, 3, 100, 0x00, 0x02, 11);
            C_POSDLL.POS_FeedLine();
            C_POSDLL.POS_S_TextOut("UPC-E", 0, 0, 0, 0, 0);
            C_POSDLL.POS_FeedLine();
            C_POSDLL.POS_S_SetBarcode("042100005264", 96, 0x42, 3, 100, 0x00, 0x02, 12);
            C_POSDLL.POS_FeedLine();
            C_POSDLL.POS_S_TextOut("EAN13", 0, 0, 0, 0, 0);
            C_POSDLL.POS_FeedLine();
            C_POSDLL.POS_S_SetBarcode("104210000526", 24, 0x43, 3, 100, 0x00, 0x02, 12);
            C_POSDLL.POS_FeedLine();
            C_POSDLL.POS_S_TextOut("EAN8", 0, 0, 0, 0, 0);
            C_POSDLL.POS_FeedLine();
            C_POSDLL.POS_S_SetBarcode("2042100", 24, 0x44, 3, 100, 0x00, 0x02, 7);
            C_POSDLL.POS_FeedLine();
            C_POSDLL.POS_S_TextOut("CODE39", 0, 0, 0, 0, 0);
            C_POSDLL.POS_FeedLine();
            C_POSDLL.POS_S_SetBarcode("0423", 0, 0x45, 2, 100, 0x00, 0x02, 4);
            C_POSDLL.POS_FeedLine();
            C_POSDLL.POS_S_TextOut("ITF", 0, 0, 0, 0, 0);
            C_POSDLL.POS_FeedLine();
            C_POSDLL.POS_S_SetBarcode("0423", 96, 0x46, 3, 100, 0x00, 0x02, 4);
            C_POSDLL.POS_FeedLine();
            C_POSDLL.POS_S_TextOut("CODEBAR", 0, 0, 0, 0, 0);
            C_POSDLL.POS_FeedLine();
            C_POSDLL.POS_S_SetBarcode("A42368B", 24, 0x47, 3, 100, 0x00, 0x02, 7);
            C_POSDLL.POS_FeedLine();
            C_POSDLL.POS_S_TextOut("CODE93", 0, 0, 0, 0, 0);
            C_POSDLL.POS_FeedLine();
            C_POSDLL.POS_S_SetBarcode("342368ABC", 24, 0x48, 3, 100, 0x00, 0x02, 9);
            C_POSDLL.POS_FeedLine();
            C_POSDLL.POS_S_TextOut("CODE128", 0, 0, 0, 0, 0);
            C_POSDLL.POS_FeedLine();
            C_POSDLL.POS_S_SetBarcode("{AHI{C345678", 0, 0x49, 2, 100, 0x00, 0x02, 12);
            C_POSDLL.POS_FeedLine();

            C_POSDLL.POS_SetMotionUnit(180, 180);
            C_POSDLL.POS_PL_SetArea(0, 0, 384, 740, 0);
            C_POSDLL.POS_SetMode(1);
            C_POSDLL.POS_PL_TextOut("PageMode:Thermal Printer", 0, 32, 0, 0, 0, 0);
            C_POSDLL.POS_PL_TextOut("页模式：热敏打印机测试页", 0, 96, 0, 0, 0, 0);
            C_POSDLL.POS_PL_TextOut("反显", 96, 128, 0, 0, 0, 0x400);
            C_POSDLL.POS_PL_TextOut("下划线", 96, 160, 0, 0, 0, 0x100);
            C_POSDLL.POS_PL_TextOut("    ----------------> Logo 4", 0, 192, 0, 0, 0, 0);
            C_POSDLL.POS_PreDownloadBmpToRAM(RAMimagePath[0], 0);
            C_POSDLL.POS_PL_PrintBmpInRAM(0, 48, 465, 0);
            C_POSDLL.POS_PL_SetBarcode("{AHI{C345678", 0, 627, 0x49, 2, 162, 0x00, 0x02, 12);
            C_POSDLL.POS_PL_TextOut("页模式：热敏打印机测试页 end", 0, 699, 0, 0, 0, 0);
            C_POSDLL.POS_PL_Print();
            C_POSDLL.POS_PL_Clear();
            
        }

        private void cbParity_SelectedIndexChanged(object sender, EventArgs e)
        {
            nParity = cbParity.SelectedIndex;
        }

        private void cbStopBits_SelectedIndexChanged(object sender, EventArgs e)
        {
            nStopBits = cbStopBits.SelectedIndex;
        }

        private void cbBaudrate_SelectedIndexChanged(object sender, EventArgs e)
        {
            nBaudrate = int.Parse(cbBaudrate.Text);
        }

        private void cbDataBits_SelectedIndexChanged(object sender, EventArgs e)
        {
            nDataBits = int.Parse(cbDataBits.Text);
        }

        private void POSDLL_V1_Load(object sender, EventArgs e)
        {
            cbComName.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
            foreach (string i in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                cbDriveName.Items.Add(i);
        }

        private void cbPageWidth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPageWidth.Text == "56mm")
            {
                RAMimagePath[0] = "Look.bmp";
                RAMimagePath[1] = "Kitty.bmp";
            }
            else if (cbPageWidth.Text == "80mm")
            {
                RAMimagePath[0] = "刀剑神域单色位图.bmp";
                RAMimagePath[1] = "羊.jpg";
            }
            else
                MessageBox.Show("请选择页宽");

        }

        private void btStatus_Click(object sender, EventArgs e)
        {
            MessageBox.Show(C_POSDLL.POS_RTQueryStatus());
        }

        private void btShotPrint_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2();
            form2.InstanceRef = this;
            form2.Show();
        }

        

    }
}