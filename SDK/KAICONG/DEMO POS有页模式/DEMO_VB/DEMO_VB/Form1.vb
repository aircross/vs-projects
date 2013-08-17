Public Class Form1
    Public lpName As String
    Public nParam As Int32
    Public nBaudrate As Int32
    Public nDataBits As Int32
    Public nStopBits As Int32
    Public nParity As Int32
    Public RAMimagePatha As String
    Public RAMimagePathb As String

    Private Sub btOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btOpen.Click
        btOpen.Enabled = False
        btPrint.Enabled = True
        btClose.Enabled = True
        Dim rValue As Int32
        rValue = POSDLL_V1.C_POSDLL.POS_Open(lpName, nBaudrate, nDataBits, nStopBits, nParity, nParam)
        MessageBox.Show("0x" + rValue.ToString("x"))

    End Sub

    Private Sub rbCom_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbCom.CheckedChanged
        cbDriveName.Enabled = False
        cbComName.Enabled = True
        cbDataBits.Enabled = True
        cbParity.Enabled = True
        cbStopBits.Enabled = True
        cbStreamCtl.Enabled = True
        cbBaudrate.Enabled = True
    End Sub

    Private Sub rbDriveName_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbDriveName.CheckedChanged
        cbComName.Enabled = False
        cbDataBits.Enabled = False
        cbParity.Enabled = False
        cbStopBits.Enabled = False
        cbStreamCtl.Enabled = False
        cbBaudrate.Enabled = False
        cbDriveName.Enabled = True
        nParam = POSDLL_V1.C_POSDLL.POS_OPEN_PRINTNAME
    End Sub

    Private Sub btClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btClose.Click
        Dim rValue As Int32
        rValue = POSDLL_V1.C_POSDLL.POS_Close()
        MessageBox.Show("0x" + rValue.ToString("x"))
        btOpen.Enabled = True
        btPrint.Enabled = False
        btClose.Enabled = False
    End Sub

    Private Sub cbComName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbComName.SelectedIndexChanged
        lpName = cbComName.Text
    End Sub

    Private Sub cbDriveName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDriveName.SelectedIndexChanged
        lpName = cbDriveName.Text
    End Sub

    Private Sub cbStreamCtl_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbStreamCtl.SelectedIndexChanged
        nParam = cbStreamCtl.SelectedIndex
    End Sub

    Private Sub btPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btPrint.Click
        POSDLL_V1.C_POSDLL.POS_SetMode(0)
        POSDLL_V1.C_POSDLL.POS_S_TextOut("KaiCong POS Thermal Printer", 48, 0, 2, 0, &H0)
        POSDLL_V1.C_POSDLL.POS_FeedLine()
        POSDLL_V1.C_POSDLL.POS_FeedLine()
        POSDLL_V1.C_POSDLL.POS_S_TextOut("开聪热敏打印机", 24, 0, 0, 0, &H100)
        POSDLL_V1.C_POSDLL.POS_FeedLine()
        POSDLL_V1.C_POSDLL.POS_SetRightSpacing(12)
        POSDLL_V1.C_POSDLL.POS_S_TextOut("开聪热敏打印机", 24, 0, 0, 0, &H80)
        POSDLL_V1.C_POSDLL.POS_FeedLine()
        POSDLL_V1.C_POSDLL.POS_FeedLine()
        POSDLL_V1.C_POSDLL.POS_SetRightSpacing(0)
        POSDLL_V1.C_POSDLL.POS_S_TextOut("BM9000", 0, 0, 0, 1, &H80)
        POSDLL_V1.C_POSDLL.POS_S_TextOut("POS PRINTER", 192, 0, 0, 0, &H0)
        POSDLL_V1.C_POSDLL.POS_FeedLine()
        POSDLL_V1.C_POSDLL.POS_SetRightSpacing(3)
        POSDLL_V1.C_POSDLL.POS_S_TextOut("BM9000", 0, 0, 0, 1, &H80)
        POSDLL_V1.C_POSDLL.POS_S_TextOut("POS PRINTER", 192, 0, 0, 0, &H0)
        POSDLL_V1.C_POSDLL.POS_FeedLine()
        POSDLL_V1.C_POSDLL.POS_SetRightSpacing(6)
        POSDLL_V1.C_POSDLL.POS_S_TextOut("BM9000", 0, 0, 0, 1, &H80)
        POSDLL_V1.C_POSDLL.POS_S_TextOut("POS PRINTER", 192, 0, 0, 0, &H0)
        POSDLL_V1.C_POSDLL.POS_FeedLine()
        POSDLL_V1.C_POSDLL.POS_S_TextOut("正常字体打印", 0, 0, 0, 0, &H0)
        POSDLL_V1.C_POSDLL.POS_FeedLine()
        POSDLL_V1.C_POSDLL.POS_S_TextOut("反显字体打印", 0, 0, 0, 0, &H400)
        POSDLL_V1.C_POSDLL.POS_FeedLine()
        POSDLL_V1.C_POSDLL.POS_S_TextOut("顺时针旋转90度字体打印", 0, 0, 0, 0, &H1000)
        POSDLL_V1.C_POSDLL.POS_FeedLine()
        POSDLL_V1.C_POSDLL.POS_S_TextOut("倒置字体打印", 0, 0, 0, 0, &H200)
        POSDLL_V1.C_POSDLL.POS_FeedLine()
        POSDLL_V1.C_POSDLL.POS_S_TextOut("    ----------------> Logo 1", 0, 0, 0, 0, 0)
        POSDLL_V1.C_POSDLL.POS_FeedLine()
        POSDLL_V1.C_POSDLL.POS_PreDownloadBmpToRAM(RAMimagePatha, 0)
        POSDLL_V1.C_POSDLL.POS_S_PrintBmpInRAM(0, 96, 0)
        POSDLL_V1.C_POSDLL.POS_S_TextOut("    ----------------> Logo 2", 0, 0, 0, 0, 0)
        POSDLL_V1.C_POSDLL.POS_FeedLine()
        POSDLL_V1.C_POSDLL.POS_PreDownloadBmpToRAM(RAMimagePathb, 0)
        POSDLL_V1.C_POSDLL.POS_S_PrintBmpInRAM(0, 0, 3)
        POSDLL_V1.C_POSDLL.POS_S_TextOut("    ----------------> Logo 3", 0, 0, 0, 0, 0)
        POSDLL_V1.C_POSDLL.POS_FeedLine()
        POSDLL_V1.C_POSDLL.POS_S_PrintBmpInFlash(1, 96, 0)
        POSDLL_V1.C_POSDLL.POS_S_TextOut("UPC-A", 0, 0, 0, 0, 0)
        POSDLL_V1.C_POSDLL.POS_FeedLine()
        POSDLL_V1.C_POSDLL.POS_S_SetBarcode("01234567890", 24, &H41, 3, 100, &H0, &H2, 11)
        POSDLL_V1.C_POSDLL.POS_FeedLine()
        POSDLL_V1.C_POSDLL.POS_S_TextOut("UPC-E", 0, 0, 0, 0, 0)
        POSDLL_V1.C_POSDLL.POS_FeedLine()
        POSDLL_V1.C_POSDLL.POS_S_SetBarcode("042100005264", 96, &H42, 3, 100, &H0, &H2, 12)
        POSDLL_V1.C_POSDLL.POS_FeedLine()
        POSDLL_V1.C_POSDLL.POS_S_TextOut("EAN13", 0, 0, 0, 0, 0)
        POSDLL_V1.C_POSDLL.POS_FeedLine()
        POSDLL_V1.C_POSDLL.POS_S_SetBarcode("104210000526", 24, &H43, 3, 100, &H0, &H2, 12)
        POSDLL_V1.C_POSDLL.POS_FeedLine()
        POSDLL_V1.C_POSDLL.POS_S_TextOut("EAN8", 0, 0, 0, 0, 0)
        POSDLL_V1.C_POSDLL.POS_FeedLine()
        POSDLL_V1.C_POSDLL.POS_S_SetBarcode("2042100", 24, &H44, 3, 100, &H0, &H2, 7)
        POSDLL_V1.C_POSDLL.POS_FeedLine()
        POSDLL_V1.C_POSDLL.POS_S_TextOut("CODE39", 0, 0, 0, 0, 0)
        POSDLL_V1.C_POSDLL.POS_FeedLine()
        POSDLL_V1.C_POSDLL.POS_S_SetBarcode("*0423*", 0, &H45, 2, 100, &H0, &H2, 6)
        POSDLL_V1.C_POSDLL.POS_FeedLine()
        POSDLL_V1.C_POSDLL.POS_S_TextOut("ITF", 0, 0, 0, 0, 0)
        POSDLL_V1.C_POSDLL.POS_FeedLine()
        POSDLL_V1.C_POSDLL.POS_S_SetBarcode("0423", 96, &H46, 3, 100, &H0, &H2, 4)
        POSDLL_V1.C_POSDLL.POS_FeedLine()
        POSDLL_V1.C_POSDLL.POS_S_TextOut("CODEBAR", 0, 0, 0, 0, 0)
        POSDLL_V1.C_POSDLL.POS_FeedLine()
        POSDLL_V1.C_POSDLL.POS_S_SetBarcode("A42368B", 24, &H47, 3, 100, &H0, &H2, 7)
        POSDLL_V1.C_POSDLL.POS_FeedLine()
        POSDLL_V1.C_POSDLL.POS_S_TextOut("CODE93", 0, 0, 0, 0, 0)
        POSDLL_V1.C_POSDLL.POS_FeedLine()
        POSDLL_V1.C_POSDLL.POS_S_SetBarcode("342368ABC", 24, &H48, 3, 100, &H0, &H2, 9)
        POSDLL_V1.C_POSDLL.POS_FeedLine()
        POSDLL_V1.C_POSDLL.POS_S_TextOut("CODE128", 0, 0, 0, 0, 0)
        POSDLL_V1.C_POSDLL.POS_FeedLine()
        POSDLL_V1.C_POSDLL.POS_S_SetBarcode("{AHI{C345678", 0, &H49, 2, 100, &H0, &H2, 12)
        POSDLL_V1.C_POSDLL.POS_FeedLine()

        POSDLL_V1.C_POSDLL.POS_SetMotionUnit(180, 180)
        POSDLL_V1.C_POSDLL.POS_PL_SetArea(0, 0, 384, 740, 0)
        POSDLL_V1.C_POSDLL.POS_SetMode(1)
        POSDLL_V1.C_POSDLL.POS_PL_TextOut("PageMode:KaiCongDianZi Thermal Printer", 0, 32, 0, 0, 0, 0)
        POSDLL_V1.C_POSDLL.POS_PL_TextOut("页模式：开聪电子热敏打印机测试页", 0, 96, 0, 0, 0, 0)
        POSDLL_V1.C_POSDLL.POS_PL_TextOut("反显", 96, 128, 0, 0, 0, &H400)
        POSDLL_V1.C_POSDLL.POS_PL_TextOut("下划线", 96, 160, 0, 0, 0, &H100)
        POSDLL_V1.C_POSDLL.POS_PL_TextOut("    ----------------> Logo 4", 0, 192, 0, 0, 0, 0)
        POSDLL_V1.C_POSDLL.POS_PreDownloadBmpToRAM(RAMimagePatha, 0)
        POSDLL_V1.C_POSDLL.POS_PL_PrintBmpInRAM(0, 48, 465, 0)
        POSDLL_V1.C_POSDLL.POS_PL_SetBarcode("{AHI{C345678", 0, 627, &H49, 2, 162, &H0, &H2, 12)
        POSDLL_V1.C_POSDLL.POS_PL_TextOut("页模式：开聪电子热敏打印机测试页 end", 0, 699, 0, 0, 0, 0)
        POSDLL_V1.C_POSDLL.POS_PL_Print()
        POSDLL_V1.C_POSDLL.POS_PL_Clear()
    End Sub

    Private Sub cbParity_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbParity.SelectedIndexChanged
        nParity = cbParity.SelectedIndex
    End Sub

    Private Sub cbStopBits_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbStopBits.SelectedIndexChanged
        nStopBits = cbStopBits.SelectedIndex
    End Sub

    Private Sub cbBaudrate_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbBaudrate.SelectedIndexChanged
        nBaudrate = Int32.Parse(cbBaudrate.Text)
    End Sub

    Private Sub cbDataBits_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDataBits.SelectedIndexChanged
        nDataBits = Int32.Parse(cbDataBits.Text)
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cbComName.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames())
        RAMimagePatha = "Kitty.bmp"
        RAMimagePathb = "Look.bmp"
    End Sub
End Class
