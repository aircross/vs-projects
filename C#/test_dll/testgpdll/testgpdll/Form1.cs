using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace testgpdll
{
    public partial class Form1 : Form
    {

        IntPtr posPtr = IntPtr.Zero ;

        public Form1()
        {
            InitializeComponent();
        }

        private void btOpen_Click(object sender, EventArgs e)
        {
            posPtr = POSDLL.POS_Open("COM1", 9600, 8, 0, 0, 0x01);
            
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            int ret;
            ret = POSDLL.POS_Close();
        }

        private void btWrite_Click(object sender, EventArgs e)
        {
            byte[] data;
            if ((posPtr == IntPtr.Zero) || (txbContent.Text == null) || ("".Equals(txbContent.Text)))
                return;
            data = Encoding.Default.GetBytes(txbContent.Text+"\n");
            POSDLL.POS_WriteFile(posPtr, data, data.Length);
        }

        private void btStartDoc_Click(object sender, EventArgs e)
        {
            POSDLL.POS_StartDoc();
        }

        private void btEndDoc_Click(object sender, EventArgs e)
        {
            POSDLL.POS_EndDoc();
        }

        private void btReset_Click(object sender, EventArgs e)
        {
            POSDLL.POS_Reset();
        }

        private void btFeedLine_Click(object sender, EventArgs e)
        {
            POSDLL.POS_FeedLine();
        }

        private void btSetMode_Click(object sender, EventArgs e)
        {
            POSDLL.POS_SetMode(cbPrintMode.SelectedIndex);
        }

        private void btSetMotionUnit_Click(object sender, EventArgs e)
        {
            POSDLL.POS_SetMotionUnit(Convert.ToInt32(numMotionUnitH.Value),Convert.ToInt32(numMotionUnitV.Value));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbPrintMode.SelectedIndex = 0;
            cbCharSet.SelectedIndex = 0;
            cbCodePage.SelectedIndex = 0;
            cbDrawerPin.SelectedIndex = 0;
            cbCutPaperMode.SelectedIndex = 0;
            cbSTextOutFontType.SelectedIndex = 0;
            cbSBarcodeType.SelectedIndex = 0;
            cbSBarcodeFontType.SelectedIndex = 0;
            cbSBarcodeHriFontPosition.SelectedIndex = 2;
            cbSPrintBmpMode.SelectedIndex = 0;
            cbSModePrintBmpInRAM.SelectedIndex = 0;
            cbSModePrintBmpInFlash.SelectedIndex = 0;
        }

        private void btSetCharSetAndCodePage_Click(object sender, EventArgs e)
        {
            POSDLL.POS_SetCharSetAndCodePage(cbCharSet.SelectedIndex, cbCodePage.SelectedIndex);
        }

        private void btSetLineSpacing_Click(object sender, EventArgs e)
        {
            POSDLL.POS_SetLineSpacing(Convert.ToInt32(numLineSpacing.Value));
        }

        private void btSetRightSpacing_Click(object sender, EventArgs e)
        {
            POSDLL.POS_SetRightSpacing(Convert.ToInt32(numRightSpacing.Value));
        }

        private void btPreDownloadBmpToRAM_Click(object sender, EventArgs e)
        {
            POSDLL.POS_PreDownloadBmpToRAM("Kitty.bmp",Convert.ToInt32(numBmpIDinRAM.Value));
        }

        private void btPreDownloadBmpsToFlash_Click(object sender, EventArgs e)
        {
            ret = POSDLL.POS_PreDownloadBmpsToFlash(new string[] { "Kitty.bmp" }, 1);
        }

        private void btKickOutDrawer_Click(object sender, EventArgs e)
        {
            POSDLL.POS_KickOutDrawer(cbDrawerPin.SelectedIndex, Convert.ToInt32(numDrawerOnTimes.Value), Convert.ToInt32(numDrawerOffTimes.Value));
        }

        private void btQueryStatus_Click(object sender, EventArgs e)
        {
            byte[] buf = new byte[1];
            POSDLL.POS_QueryStatus(buf, 500);
        }

        private void btRTQueryStatus_Click(object sender, EventArgs e)
        {
            byte[] buf = new byte[1];
            POSDLL.POS_RTQueryStatus(buf);
        }

        private void btCutPaper_Click(object sender, EventArgs e)
        {
            POSDLL.POS_CutPaper(cbCutPaperMode.SelectedIndex, Convert.ToInt32(numCutPaperDistance.Value));
        }

        private void btSetAreaWidth_Click(object sender, EventArgs e)
        {
            POSDLL.POS_S_SetAreaWidth(Convert.ToInt32(numSTextOutAreaWidth.Value));
        }

        private void btSTextOut_Click(object sender, EventArgs e)
        {
            if ((txbSTextOut.Text == null) || ("".Equals(txbSTextOut.Text)))
                return;

            int nFontStyle = 0;
            for (int i = 0; i <= 6; i++)
            {
                if (chkedlbSFontStyle.GetItemChecked(i))
                {
                    if (i == 0)
                        nFontStyle |= 1 << 3;
                    else
                        nFontStyle |= 1 << (i + 6);
                }
            }

            POSDLL.POS_S_TextOut(txbSTextOut.Text + "\n", Convert.ToInt32(numSTextOutOrgx.Value), Convert.ToInt32(numSWidthTimes.Value),
                Convert.ToInt32(numSHeightTimes.Value), cbSTextOutFontType.SelectedIndex, nFontStyle);
        }

        private void btSetBarcode_Click(object sender, EventArgs e)
        {
            if ((txbSBarcode.Text == null) || ("".Equals(txbSBarcode.Text)))
                return;
            POSDLL.POS_S_SetBarcode(txbSBarcode.Text,Convert.ToInt32(numSBarcodeOrgx.Value),cbSBarcodeType.SelectedIndex+0x41,
                Convert.ToInt32(numSBarcodeUnitWidth.Value),Convert.ToInt32(numSBarcodeHeight.Value),
                cbSBarcodeFontType.SelectedIndex,cbSBarcodeHriFontPosition.SelectedIndex,txbSBarcode.Text.Length);
        }

        private void btSDownloadAndPrintBmp_Click(object sender, EventArgs e)
        {
            int nMode = cbSPrintBmpMode.SelectedIndex;
            if (nMode == 2)
                nMode = 0x20;
            else if (nMode == 3)
                nMode = 0x21;
            POSDLL.POS_S_DownloadAndPrintBmp("Kitty.bmp", Convert.ToInt32(numSDownloadAndPrintBmpOrgx.Value), nMode);
        }

        private void btPrintBmpInRAM_Click(object sender, EventArgs e)
        {
            POSDLL.POS_S_PrintBmpInRAM(Convert.ToInt32(numSIDPrintBmpInRAM.Value),Convert.ToInt32(numSOrgxPrintBmpInRAM.Value),cbSModePrintBmpInRAM.SelectedIndex);
        }

        private void btPrintBmpInFlash_Click(object sender, EventArgs e)
        {
            POSDLL.POS_S_PrintBmpInFlash(Convert.ToInt32(numSOrgxPrintBmpInFlash.Value),Convert.ToInt32(numSOrgxPrintBmpInFlash.Value),cbSModePrintBmpInFlash.SelectedIndex);
        }



    }
}