namespace printpic
{
    partial class Form1
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
            this.comboBoxPort = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxBaudrate = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxDatabits = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxParitybits = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxStopbits = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxFlowControl = new System.Windows.Forms.ComboBox();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.pictureBoxPicture = new System.Windows.Forms.PictureBox();
            this.groupBoxPaperSize = new System.Windows.Forms.GroupBox();
            this.radioButton576 = new System.Windows.Forms.RadioButton();
            this.radioButton384 = new System.Windows.Forms.RadioButton();
            this.buttonLoadPicture = new System.Windows.Forms.Button();
            this.buttonPrintPicture = new System.Windows.Forms.Button();
            this.openFileDialogLoadPicture = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPicture)).BeginInit();
            this.groupBoxPaperSize.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxPort
            // 
            this.comboBoxPort.FormattingEnabled = true;
            this.comboBoxPort.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10"});
            this.comboBoxPort.Location = new System.Drawing.Point(84, 12);
            this.comboBoxPort.Name = "comboBoxPort";
            this.comboBoxPort.Size = new System.Drawing.Size(121, 20);
            this.comboBoxPort.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Port#";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(222, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Baudrate";
            // 
            // comboBoxBaudrate
            // 
            this.comboBoxBaudrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBaudrate.FormattingEnabled = true;
            this.comboBoxBaudrate.Items.AddRange(new object[] {
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.comboBoxBaudrate.Location = new System.Drawing.Point(309, 11);
            this.comboBoxBaudrate.Name = "comboBoxBaudrate";
            this.comboBoxBaudrate.Size = new System.Drawing.Size(121, 20);
            this.comboBoxBaudrate.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "Databits";
            // 
            // comboBoxDatabits
            // 
            this.comboBoxDatabits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDatabits.FormattingEnabled = true;
            this.comboBoxDatabits.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.comboBoxDatabits.Location = new System.Drawing.Point(84, 50);
            this.comboBoxDatabits.Name = "comboBoxDatabits";
            this.comboBoxDatabits.Size = new System.Drawing.Size(121, 20);
            this.comboBoxDatabits.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(224, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "Paritybits";
            // 
            // comboBoxParitybits
            // 
            this.comboBoxParitybits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxParitybits.FormattingEnabled = true;
            this.comboBoxParitybits.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even",
            "Mark",
            "Space"});
            this.comboBoxParitybits.Location = new System.Drawing.Point(309, 50);
            this.comboBoxParitybits.Name = "comboBoxParitybits";
            this.comboBoxParitybits.Size = new System.Drawing.Size(121, 20);
            this.comboBoxParitybits.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(470, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "Stopbits";
            // 
            // comboBoxStopbits
            // 
            this.comboBoxStopbits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStopbits.FormattingEnabled = true;
            this.comboBoxStopbits.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
            this.comboBoxStopbits.Location = new System.Drawing.Point(548, 51);
            this.comboBoxStopbits.Name = "comboBoxStopbits";
            this.comboBoxStopbits.Size = new System.Drawing.Size(121, 20);
            this.comboBoxStopbits.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(472, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "FlowControl";
            // 
            // comboBoxFlowControl
            // 
            this.comboBoxFlowControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFlowControl.FormattingEnabled = true;
            this.comboBoxFlowControl.Items.AddRange(new object[] {
            "None",
            "HW Flow Control"});
            this.comboBoxFlowControl.Location = new System.Drawing.Point(549, 11);
            this.comboBoxFlowControl.Name = "comboBoxFlowControl";
            this.comboBoxFlowControl.Size = new System.Drawing.Size(121, 20);
            this.comboBoxFlowControl.TabIndex = 11;
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(723, 10);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(75, 23);
            this.buttonOpen.TabIndex = 12;
            this.buttonOpen.Text = "Open";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(723, 47);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 13;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // pictureBoxPicture
            // 
            this.pictureBoxPicture.Location = new System.Drawing.Point(91, 106);
            this.pictureBoxPicture.Name = "pictureBoxPicture";
            this.pictureBoxPicture.Size = new System.Drawing.Size(576, 384);
            this.pictureBoxPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxPicture.TabIndex = 14;
            this.pictureBoxPicture.TabStop = false;
            // 
            // groupBoxPaperSize
            // 
            this.groupBoxPaperSize.Controls.Add(this.radioButton576);
            this.groupBoxPaperSize.Controls.Add(this.radioButton384);
            this.groupBoxPaperSize.Location = new System.Drawing.Point(706, 106);
            this.groupBoxPaperSize.Name = "groupBoxPaperSize";
            this.groupBoxPaperSize.Size = new System.Drawing.Size(92, 85);
            this.groupBoxPaperSize.TabIndex = 15;
            this.groupBoxPaperSize.TabStop = false;
            this.groupBoxPaperSize.Text = "PaperSize";
            // 
            // radioButton576
            // 
            this.radioButton576.AutoSize = true;
            this.radioButton576.Location = new System.Drawing.Point(17, 49);
            this.radioButton576.Name = "radioButton576";
            this.radioButton576.Size = new System.Drawing.Size(41, 16);
            this.radioButton576.TabIndex = 1;
            this.radioButton576.TabStop = true;
            this.radioButton576.Text = "576";
            this.radioButton576.UseVisualStyleBackColor = true;
            this.radioButton576.CheckedChanged += new System.EventHandler(this.radioButton576_CheckedChanged);
            // 
            // radioButton384
            // 
            this.radioButton384.AutoSize = true;
            this.radioButton384.Location = new System.Drawing.Point(17, 21);
            this.radioButton384.Name = "radioButton384";
            this.radioButton384.Size = new System.Drawing.Size(41, 16);
            this.radioButton384.TabIndex = 0;
            this.radioButton384.TabStop = true;
            this.radioButton384.Text = "384";
            this.radioButton384.UseVisualStyleBackColor = true;
            this.radioButton384.CheckedChanged += new System.EventHandler(this.radioButton384_CheckedChanged);
            // 
            // buttonLoadPicture
            // 
            this.buttonLoadPicture.Location = new System.Drawing.Point(706, 397);
            this.buttonLoadPicture.Name = "buttonLoadPicture";
            this.buttonLoadPicture.Size = new System.Drawing.Size(92, 22);
            this.buttonLoadPicture.TabIndex = 16;
            this.buttonLoadPicture.Text = "LoadPicture";
            this.buttonLoadPicture.UseVisualStyleBackColor = true;
            this.buttonLoadPicture.Click += new System.EventHandler(this.buttonLoadPicture_Click);
            // 
            // buttonPrintPicture
            // 
            this.buttonPrintPicture.Location = new System.Drawing.Point(706, 467);
            this.buttonPrintPicture.Name = "buttonPrintPicture";
            this.buttonPrintPicture.Size = new System.Drawing.Size(92, 23);
            this.buttonPrintPicture.TabIndex = 17;
            this.buttonPrintPicture.Text = "PrintPicture";
            this.buttonPrintPicture.UseVisualStyleBackColor = true;
            this.buttonPrintPicture.Click += new System.EventHandler(this.buttonPrintPicture_Click);
            // 
            // openFileDialogLoadPicture
            // 
            this.openFileDialogLoadPicture.FileName = "LoadPicture";
            this.openFileDialogLoadPicture.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialogLoadPicture_FileOk);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 514);
            this.Controls.Add(this.buttonPrintPicture);
            this.Controls.Add(this.buttonLoadPicture);
            this.Controls.Add(this.groupBoxPaperSize);
            this.Controls.Add(this.pictureBoxPicture);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.comboBoxFlowControl);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBoxStopbits);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxParitybits);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxDatabits);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxBaudrate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxPort);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPicture)).EndInit();
            this.groupBoxPaperSize.ResumeLayout(false);
            this.groupBoxPaperSize.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxBaudrate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxDatabits;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxParitybits;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxStopbits;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxFlowControl;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.PictureBox pictureBoxPicture;
        private System.Windows.Forms.GroupBox groupBoxPaperSize;
        private System.Windows.Forms.RadioButton radioButton576;
        private System.Windows.Forms.RadioButton radioButton384;
        private System.Windows.Forms.Button buttonLoadPicture;
        private System.Windows.Forms.Button buttonPrintPicture;
        private System.Windows.Forms.OpenFileDialog openFileDialogLoadPicture;
    }
}

