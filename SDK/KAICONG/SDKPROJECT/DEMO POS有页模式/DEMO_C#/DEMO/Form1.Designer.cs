namespace DEMO
{
    partial class POSDLL_V1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btOpen = new System.Windows.Forms.Button();
            this.gbSelectPort = new System.Windows.Forms.GroupBox();
            this.rbDriveProgram = new System.Windows.Forms.RadioButton();
            this.rbCom = new System.Windows.Forms.RadioButton();
            this.gbConfig = new System.Windows.Forms.GroupBox();
            this.cbDriveName = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbParity = new System.Windows.Forms.ComboBox();
            this.cbStopBits = new System.Windows.Forms.ComboBox();
            this.cbStreamCtr = new System.Windows.Forms.ComboBox();
            this.cbDataBits = new System.Windows.Forms.ComboBox();
            this.cbBaudrate = new System.Windows.Forms.ComboBox();
            this.cbComName = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbSet = new System.Windows.Forms.GroupBox();
            this.lbPageWidth = new System.Windows.Forms.Label();
            this.cbPageWidth = new System.Windows.Forms.ComboBox();
            this.gbSetMode = new System.Windows.Forms.GroupBox();
            this.rbPageMode = new System.Windows.Forms.RadioButton();
            this.rbStandardMode = new System.Windows.Forms.RadioButton();
            this.tbStatus = new System.Windows.Forms.TextBox();
            this.btClose = new System.Windows.Forms.Button();
            this.btPrint = new System.Windows.Forms.Button();
            this.btStatus = new System.Windows.Forms.Button();
            this.gbSelectPort.SuspendLayout();
            this.gbConfig.SuspendLayout();
            this.gbSet.SuspendLayout();
            this.gbSetMode.SuspendLayout();
            this.SuspendLayout();
            // 
            // btOpen
            // 
            this.btOpen.Location = new System.Drawing.Point(12, 313);
            this.btOpen.Name = "btOpen";
            this.btOpen.Size = new System.Drawing.Size(75, 28);
            this.btOpen.TabIndex = 0;
            this.btOpen.Text = "打开端口";
            this.btOpen.UseVisualStyleBackColor = true;
            this.btOpen.Click += new System.EventHandler(this.btOpen_Click);
            // 
            // gbSelectPort
            // 
            this.gbSelectPort.Controls.Add(this.rbDriveProgram);
            this.gbSelectPort.Controls.Add(this.rbCom);
            this.gbSelectPort.Location = new System.Drawing.Point(13, 13);
            this.gbSelectPort.Name = "gbSelectPort";
            this.gbSelectPort.Size = new System.Drawing.Size(370, 82);
            this.gbSelectPort.TabIndex = 1;
            this.gbSelectPort.TabStop = false;
            this.gbSelectPort.Text = "选择端口";
            // 
            // rbDriveProgram
            // 
            this.rbDriveProgram.AutoSize = true;
            this.rbDriveProgram.Location = new System.Drawing.Point(17, 52);
            this.rbDriveProgram.Name = "rbDriveProgram";
            this.rbDriveProgram.Size = new System.Drawing.Size(71, 16);
            this.rbDriveProgram.TabIndex = 1;
            this.rbDriveProgram.TabStop = true;
            this.rbDriveProgram.Text = "驱动程序";
            this.rbDriveProgram.UseVisualStyleBackColor = true;
            this.rbDriveProgram.CheckedChanged += new System.EventHandler(this.rbDriveProgram_CheckedChanged);
            // 
            // rbCom
            // 
            this.rbCom.AutoSize = true;
            this.rbCom.Location = new System.Drawing.Point(17, 21);
            this.rbCom.Name = "rbCom";
            this.rbCom.Size = new System.Drawing.Size(47, 16);
            this.rbCom.TabIndex = 0;
            this.rbCom.TabStop = true;
            this.rbCom.Text = "串口";
            this.rbCom.UseVisualStyleBackColor = true;
            this.rbCom.CheckedChanged += new System.EventHandler(this.rbCom_CheckedChanged);
            // 
            // gbConfig
            // 
            this.gbConfig.Controls.Add(this.cbDriveName);
            this.gbConfig.Controls.Add(this.label7);
            this.gbConfig.Controls.Add(this.cbParity);
            this.gbConfig.Controls.Add(this.cbStopBits);
            this.gbConfig.Controls.Add(this.cbStreamCtr);
            this.gbConfig.Controls.Add(this.cbDataBits);
            this.gbConfig.Controls.Add(this.cbBaudrate);
            this.gbConfig.Controls.Add(this.cbComName);
            this.gbConfig.Controls.Add(this.label6);
            this.gbConfig.Controls.Add(this.label5);
            this.gbConfig.Controls.Add(this.label4);
            this.gbConfig.Controls.Add(this.label3);
            this.gbConfig.Controls.Add(this.label2);
            this.gbConfig.Controls.Add(this.label1);
            this.gbConfig.Location = new System.Drawing.Point(13, 116);
            this.gbConfig.Name = "gbConfig";
            this.gbConfig.Size = new System.Drawing.Size(370, 190);
            this.gbConfig.TabIndex = 2;
            this.gbConfig.TabStop = false;
            this.gbConfig.Text = "端口配置";
            // 
            // cbDriveName
            // 
            this.cbDriveName.FormattingEnabled = true;
            this.cbDriveName.Location = new System.Drawing.Point(88, 107);
            this.cbDriveName.Name = "cbDriveName";
            this.cbDriveName.Size = new System.Drawing.Size(80, 20);
            this.cbDriveName.TabIndex = 13;
            this.cbDriveName.SelectedIndexChanged += new System.EventHandler(this.cbDriveName_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 110);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "驱动名称：";
            // 
            // cbParity
            // 
            this.cbParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbParity.FormattingEnabled = true;
            this.cbParity.Items.AddRange(new object[] {
            "无校验",
            "奇校验",
            "偶校验",
            "标记校验",
            "空格校验"});
            this.cbParity.Location = new System.Drawing.Point(269, 18);
            this.cbParity.Name = "cbParity";
            this.cbParity.Size = new System.Drawing.Size(80, 20);
            this.cbParity.TabIndex = 11;
            this.cbParity.SelectedIndexChanged += new System.EventHandler(this.cbParity_SelectedIndexChanged);
            // 
            // cbStopBits
            // 
            this.cbStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStopBits.FormattingEnabled = true;
            this.cbStopBits.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
            this.cbStopBits.Location = new System.Drawing.Point(269, 49);
            this.cbStopBits.Name = "cbStopBits";
            this.cbStopBits.Size = new System.Drawing.Size(80, 20);
            this.cbStopBits.TabIndex = 10;
            this.cbStopBits.SelectedIndexChanged += new System.EventHandler(this.cbStopBits_SelectedIndexChanged);
            // 
            // cbStreamCtr
            // 
            this.cbStreamCtr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStreamCtr.FormattingEnabled = true;
            this.cbStreamCtr.Items.AddRange(new object[] {
            "DTR_DSR",
            "RTS_CTS",
            "XON_XOFF",
            "NO_HANDSHAKE"});
            this.cbStreamCtr.Location = new System.Drawing.Point(269, 75);
            this.cbStreamCtr.Name = "cbStreamCtr";
            this.cbStreamCtr.Size = new System.Drawing.Size(80, 20);
            this.cbStreamCtr.TabIndex = 9;
            this.cbStreamCtr.SelectedIndexChanged += new System.EventHandler(this.cbStreamCtr_SelectedIndexChanged);
            // 
            // cbDataBits
            // 
            this.cbDataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDataBits.FormattingEnabled = true;
            this.cbDataBits.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.cbDataBits.Location = new System.Drawing.Point(88, 75);
            this.cbDataBits.Name = "cbDataBits";
            this.cbDataBits.Size = new System.Drawing.Size(80, 20);
            this.cbDataBits.TabIndex = 8;
            this.cbDataBits.SelectedIndexChanged += new System.EventHandler(this.cbDataBits_SelectedIndexChanged);
            // 
            // cbBaudrate
            // 
            this.cbBaudrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBaudrate.FormattingEnabled = true;
            this.cbBaudrate.Items.AddRange(new object[] {
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.cbBaudrate.Location = new System.Drawing.Point(88, 46);
            this.cbBaudrate.Name = "cbBaudrate";
            this.cbBaudrate.Size = new System.Drawing.Size(80, 20);
            this.cbBaudrate.TabIndex = 7;
            this.cbBaudrate.SelectedIndexChanged += new System.EventHandler(this.cbBaudrate_SelectedIndexChanged);
            // 
            // cbComName
            // 
            this.cbComName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbComName.FormattingEnabled = true;
            this.cbComName.Location = new System.Drawing.Point(88, 18);
            this.cbComName.Name = "cbComName";
            this.cbComName.Size = new System.Drawing.Size(80, 20);
            this.cbComName.TabIndex = 6;
            this.cbComName.SelectedIndexChanged += new System.EventHandler(this.cbComName_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(186, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "数据流控制：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(210, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "停止位：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(210, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "校验位：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "数据位：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "波特率：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "串口名称：";
            // 
            // gbSet
            // 
            this.gbSet.Controls.Add(this.lbPageWidth);
            this.gbSet.Controls.Add(this.cbPageWidth);
            this.gbSet.Controls.Add(this.gbSetMode);
            this.gbSet.Location = new System.Drawing.Point(399, 13);
            this.gbSet.Name = "gbSet";
            this.gbSet.Size = new System.Drawing.Size(138, 293);
            this.gbSet.TabIndex = 3;
            this.gbSet.TabStop = false;
            this.gbSet.Text = "示例设置";
            // 
            // lbPageWidth
            // 
            this.lbPageWidth.AutoSize = true;
            this.lbPageWidth.Location = new System.Drawing.Point(27, 163);
            this.lbPageWidth.Name = "lbPageWidth";
            this.lbPageWidth.Size = new System.Drawing.Size(29, 12);
            this.lbPageWidth.TabIndex = 2;
            this.lbPageWidth.Text = "页宽";
            // 
            // cbPageWidth
            // 
            this.cbPageWidth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPageWidth.FormattingEnabled = true;
            this.cbPageWidth.Items.AddRange(new object[] {
            "56mm",
            "80mm"});
            this.cbPageWidth.Location = new System.Drawing.Point(29, 181);
            this.cbPageWidth.Name = "cbPageWidth";
            this.cbPageWidth.Size = new System.Drawing.Size(92, 20);
            this.cbPageWidth.TabIndex = 1;
            this.cbPageWidth.SelectedIndexChanged += new System.EventHandler(this.cbPageWidth_SelectedIndexChanged);
            // 
            // gbSetMode
            // 
            this.gbSetMode.Controls.Add(this.rbPageMode);
            this.gbSetMode.Controls.Add(this.rbStandardMode);
            this.gbSetMode.Location = new System.Drawing.Point(17, 32);
            this.gbSetMode.Name = "gbSetMode";
            this.gbSetMode.Size = new System.Drawing.Size(104, 100);
            this.gbSetMode.TabIndex = 0;
            this.gbSetMode.TabStop = false;
            this.gbSetMode.Text = "选择模式";
            // 
            // rbPageMode
            // 
            this.rbPageMode.AutoSize = true;
            this.rbPageMode.Location = new System.Drawing.Point(12, 57);
            this.rbPageMode.Name = "rbPageMode";
            this.rbPageMode.Size = new System.Drawing.Size(59, 16);
            this.rbPageMode.TabIndex = 1;
            this.rbPageMode.TabStop = true;
            this.rbPageMode.Text = "页模式";
            this.rbPageMode.UseVisualStyleBackColor = true;
            // 
            // rbStandardMode
            // 
            this.rbStandardMode.AutoSize = true;
            this.rbStandardMode.Location = new System.Drawing.Point(12, 34);
            this.rbStandardMode.Name = "rbStandardMode";
            this.rbStandardMode.Size = new System.Drawing.Size(71, 16);
            this.rbStandardMode.TabIndex = 0;
            this.rbStandardMode.TabStop = true;
            this.rbStandardMode.Text = "标准模式";
            this.rbStandardMode.UseVisualStyleBackColor = true;
            // 
            // tbStatus
            // 
            this.tbStatus.Location = new System.Drawing.Point(167, 318);
            this.tbStatus.Name = "tbStatus";
            this.tbStatus.ReadOnly = true;
            this.tbStatus.Size = new System.Drawing.Size(207, 21);
            this.tbStatus.TabIndex = 4;
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(462, 313);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 28);
            this.btClose.TabIndex = 5;
            this.btClose.Text = "关闭端口";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // btPrint
            // 
            this.btPrint.Location = new System.Drawing.Point(380, 313);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(75, 28);
            this.btPrint.TabIndex = 3;
            this.btPrint.Text = "打印";
            this.btPrint.UseVisualStyleBackColor = true;
            this.btPrint.Click += new System.EventHandler(this.btPrint_Click);
            // 
            // btStatus
            // 
            this.btStatus.Location = new System.Drawing.Point(94, 313);
            this.btStatus.Name = "btStatus";
            this.btStatus.Size = new System.Drawing.Size(67, 28);
            this.btStatus.TabIndex = 6;
            this.btStatus.Text = "查询状态";
            this.btStatus.UseVisualStyleBackColor = true;
            // 
            // POSDLL_V1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 348);
            this.Controls.Add(this.btStatus);
            this.Controls.Add(this.btPrint);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.tbStatus);
            this.Controls.Add(this.gbSet);
            this.Controls.Add(this.gbConfig);
            this.Controls.Add(this.gbSelectPort);
            this.Controls.Add(this.btOpen);
            this.Name = "POSDLL_V1";
            this.Text = "POSdllDemo";
            this.Load += new System.EventHandler(this.POSDLL_V1_Load);
            this.gbSelectPort.ResumeLayout(false);
            this.gbSelectPort.PerformLayout();
            this.gbConfig.ResumeLayout(false);
            this.gbConfig.PerformLayout();
            this.gbSet.ResumeLayout(false);
            this.gbSet.PerformLayout();
            this.gbSetMode.ResumeLayout(false);
            this.gbSetMode.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btOpen;
        private System.Windows.Forms.GroupBox gbSelectPort;
        private System.Windows.Forms.RadioButton rbCom;
        private System.Windows.Forms.GroupBox gbConfig;
        private System.Windows.Forms.GroupBox gbSet;
        private System.Windows.Forms.Label lbPageWidth;
        private System.Windows.Forms.ComboBox cbPageWidth;
        private System.Windows.Forms.GroupBox gbSetMode;
        private System.Windows.Forms.RadioButton rbPageMode;
        private System.Windows.Forms.RadioButton rbStandardMode;
        private System.Windows.Forms.TextBox tbStatus;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button btPrint;
        private System.Windows.Forms.Button btStatus;
        private System.Windows.Forms.ComboBox cbComName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbParity;
        private System.Windows.Forms.ComboBox cbStopBits;
        private System.Windows.Forms.ComboBox cbStreamCtr;
        private System.Windows.Forms.ComboBox cbDataBits;
        private System.Windows.Forms.ComboBox cbBaudrate;
        private System.Windows.Forms.RadioButton rbDriveProgram;
        private System.Windows.Forms.ComboBox cbDriveName;
        private System.Windows.Forms.Label label7;
    }
}

