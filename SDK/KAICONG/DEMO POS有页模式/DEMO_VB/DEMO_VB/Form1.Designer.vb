<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rbDriveName = New System.Windows.Forms.RadioButton
        Me.rbCom = New System.Windows.Forms.RadioButton
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cbStreamCtl = New System.Windows.Forms.ComboBox
        Me.cbStopBits = New System.Windows.Forms.ComboBox
        Me.cbParity = New System.Windows.Forms.ComboBox
        Me.cbDriveName = New System.Windows.Forms.ComboBox
        Me.cbDataBits = New System.Windows.Forms.ComboBox
        Me.cbBaudrate = New System.Windows.Forms.ComboBox
        Me.cbComName = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.btOpen = New System.Windows.Forms.Button
        Me.btPrint = New System.Windows.Forms.Button
        Me.btClose = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbDriveName)
        Me.GroupBox1.Controls.Add(Me.rbCom)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(243, 107)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "选择端口"
        '
        'rbDriveName
        '
        Me.rbDriveName.AutoSize = True
        Me.rbDriveName.Location = New System.Drawing.Point(7, 68)
        Me.rbDriveName.Name = "rbDriveName"
        Me.rbDriveName.Size = New System.Drawing.Size(71, 16)
        Me.rbDriveName.TabIndex = 1
        Me.rbDriveName.TabStop = True
        Me.rbDriveName.Text = "驱动程序"
        Me.rbDriveName.UseVisualStyleBackColor = True
        '
        'rbCom
        '
        Me.rbCom.AutoSize = True
        Me.rbCom.Location = New System.Drawing.Point(7, 33)
        Me.rbCom.Name = "rbCom"
        Me.rbCom.Size = New System.Drawing.Size(47, 16)
        Me.rbCom.TabIndex = 0
        Me.rbCom.TabStop = True
        Me.rbCom.Text = "串口"
        Me.rbCom.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cbStreamCtl)
        Me.GroupBox2.Controls.Add(Me.cbStopBits)
        Me.GroupBox2.Controls.Add(Me.cbParity)
        Me.GroupBox2.Controls.Add(Me.cbDriveName)
        Me.GroupBox2.Controls.Add(Me.cbDataBits)
        Me.GroupBox2.Controls.Add(Me.cbBaudrate)
        Me.GroupBox2.Controls.Add(Me.cbComName)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(13, 144)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(408, 174)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "端口配置"
        '
        'cbStreamCtl
        '
        Me.cbStreamCtl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbStreamCtl.FormattingEnabled = True
        Me.cbStreamCtl.Items.AddRange(New Object() {"DTR_DSR", "RTS_CTS", "XON_XOFF", "NO_HANDSHAKE"})
        Me.cbStreamCtl.Location = New System.Drawing.Point(271, 91)
        Me.cbStreamCtl.Name = "cbStreamCtl"
        Me.cbStreamCtl.Size = New System.Drawing.Size(89, 20)
        Me.cbStreamCtl.TabIndex = 13
        '
        'cbStopBits
        '
        Me.cbStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbStopBits.FormattingEnabled = True
        Me.cbStopBits.Items.AddRange(New Object() {"1", "1.5", "2"})
        Me.cbStopBits.Location = New System.Drawing.Point(271, 61)
        Me.cbStopBits.Name = "cbStopBits"
        Me.cbStopBits.Size = New System.Drawing.Size(89, 20)
        Me.cbStopBits.TabIndex = 12
        '
        'cbParity
        '
        Me.cbParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbParity.FormattingEnabled = True
        Me.cbParity.Items.AddRange(New Object() {"无校验", "奇校验", "偶校验", "标记校验", "空格校验"})
        Me.cbParity.Location = New System.Drawing.Point(271, 29)
        Me.cbParity.Name = "cbParity"
        Me.cbParity.Size = New System.Drawing.Size(89, 20)
        Me.cbParity.TabIndex = 11
        '
        'cbDriveName
        '
        Me.cbDriveName.FormattingEnabled = True
        Me.cbDriveName.Location = New System.Drawing.Point(84, 123)
        Me.cbDriveName.Name = "cbDriveName"
        Me.cbDriveName.Size = New System.Drawing.Size(89, 20)
        Me.cbDriveName.TabIndex = 10
        '
        'cbDataBits
        '
        Me.cbDataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDataBits.FormattingEnabled = True
        Me.cbDataBits.Items.AddRange(New Object() {"5", "6", "7", "8"})
        Me.cbDataBits.Location = New System.Drawing.Point(84, 93)
        Me.cbDataBits.Name = "cbDataBits"
        Me.cbDataBits.Size = New System.Drawing.Size(89, 20)
        Me.cbDataBits.TabIndex = 9
        '
        'cbBaudrate
        '
        Me.cbBaudrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbBaudrate.FormattingEnabled = True
        Me.cbBaudrate.Items.AddRange(New Object() {"2400", "4800", "9600", "19200", "38400", "57600", "115200"})
        Me.cbBaudrate.Location = New System.Drawing.Point(84, 61)
        Me.cbBaudrate.Name = "cbBaudrate"
        Me.cbBaudrate.Size = New System.Drawing.Size(89, 20)
        Me.cbBaudrate.TabIndex = 8
        '
        'cbComName
        '
        Me.cbComName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbComName.FormattingEnabled = True
        Me.cbComName.Location = New System.Drawing.Point(84, 29)
        Me.cbComName.Name = "cbComName"
        Me.cbComName.Size = New System.Drawing.Size(89, 20)
        Me.cbComName.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(212, 64)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 12)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "停止位："
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(188, 94)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 12)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "数据流控制："
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(212, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 12)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "校验位："
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 126)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 12)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "驱动名称："
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(23, 94)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 12)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "数据位："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(23, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 12)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "波特率："
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "串口名称："
        '
        'btOpen
        '
        Me.btOpen.Location = New System.Drawing.Point(20, 324)
        Me.btOpen.Name = "btOpen"
        Me.btOpen.Size = New System.Drawing.Size(75, 31)
        Me.btOpen.TabIndex = 2
        Me.btOpen.Text = "打开"
        Me.btOpen.UseVisualStyleBackColor = True
        '
        'btPrint
        '
        Me.btPrint.Location = New System.Drawing.Point(289, 325)
        Me.btPrint.Name = "btPrint"
        Me.btPrint.Size = New System.Drawing.Size(51, 30)
        Me.btPrint.TabIndex = 3
        Me.btPrint.Text = "打印"
        Me.btPrint.UseVisualStyleBackColor = True
        '
        'btClose
        '
        Me.btClose.Location = New System.Drawing.Point(346, 324)
        Me.btClose.Name = "btClose"
        Me.btClose.Size = New System.Drawing.Size(75, 31)
        Me.btClose.TabIndex = 4
        Me.btClose.Text = "关闭"
        Me.btClose.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(101, 330)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(177, 21)
        Me.TextBox1.TabIndex = 5
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 359)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.btClose)
        Me.Controls.Add(Me.btPrint)
        Me.Controls.Add(Me.btOpen)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbDriveName As System.Windows.Forms.RadioButton
    Friend WithEvents rbCom As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbStreamCtl As System.Windows.Forms.ComboBox
    Friend WithEvents cbStopBits As System.Windows.Forms.ComboBox
    Friend WithEvents cbParity As System.Windows.Forms.ComboBox
    Friend WithEvents cbDriveName As System.Windows.Forms.ComboBox
    Friend WithEvents cbDataBits As System.Windows.Forms.ComboBox
    Friend WithEvents cbBaudrate As System.Windows.Forms.ComboBox
    Friend WithEvents cbComName As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btOpen As System.Windows.Forms.Button
    Friend WithEvents btPrint As System.Windows.Forms.Button
    Friend WithEvents btClose As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox

End Class
