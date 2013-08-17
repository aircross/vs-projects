#pragma once


namespace DEMO_C {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;
	using namespace POSDLL_V1;
	/// <summary>
	/// Form1 摘要
	///
	/// 警告: 如果更改此类的名称，则需要更改
	///          与此类所依赖的所有 .resx 文件关联的托管资源编译器工具的
	///          “资源文件名”属性。否则，
	///          设计器将不能与此窗体的关联
	///          本地化资源正确交互。
	/// </summary>
	public ref class Form1 : public System::Windows::Forms::Form
	{
	public:
		Form1(void)
		{
			InitializeComponent();
			//
			//TODO: 在此处添加构造函数代码
			//
		}

	protected:
		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		~Form1()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::GroupBox^  groupBox1;
	protected: 
	private: System::Windows::Forms::RadioButton^  rbDriveName;
	private: System::Windows::Forms::RadioButton^  rbCom;
	private: System::Windows::Forms::GroupBox^  gbPortSet;
	private: System::Windows::Forms::ComboBox^  cbComName;

	private: System::Windows::Forms::Label^  label3;
	private: System::Windows::Forms::Label^  label2;
	private: System::Windows::Forms::Label^  label1;
	private: System::Windows::Forms::Label^  lbComName;
	private: System::Windows::Forms::Label^  label6;
	private: System::Windows::Forms::Label^  label5;
	private: System::Windows::Forms::ComboBox^  cbParity;
	private: System::Windows::Forms::Label^  label4;
	private: System::Windows::Forms::ComboBox^  cbStopBits;
	private: System::Windows::Forms::ComboBox^  cbStreamCtl;
	private: System::Windows::Forms::ComboBox^  cbDriveName;
	private: System::Windows::Forms::ComboBox^  cbDataBits;
	private: System::Windows::Forms::ComboBox^  cbBaudrate;
	private: System::Windows::Forms::Button^  btOpen;
	private: System::Windows::Forms::Button^  btPrint;
	private: System::Windows::Forms::TextBox^  textBox1;
	private: System::Windows::Forms::Button^  btClose;


	private:
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// 设计器支持所需的方法 - 不要
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		void InitializeComponent(void)
		{
			this->groupBox1 = (gcnew System::Windows::Forms::GroupBox());
			this->rbDriveName = (gcnew System::Windows::Forms::RadioButton());
			this->rbCom = (gcnew System::Windows::Forms::RadioButton());
			this->gbPortSet = (gcnew System::Windows::Forms::GroupBox());
			this->label6 = (gcnew System::Windows::Forms::Label());
			this->label5 = (gcnew System::Windows::Forms::Label());
			this->cbParity = (gcnew System::Windows::Forms::ComboBox());
			this->label4 = (gcnew System::Windows::Forms::Label());
			this->cbStopBits = (gcnew System::Windows::Forms::ComboBox());
			this->cbStreamCtl = (gcnew System::Windows::Forms::ComboBox());
			this->cbDriveName = (gcnew System::Windows::Forms::ComboBox());
			this->cbDataBits = (gcnew System::Windows::Forms::ComboBox());
			this->cbBaudrate = (gcnew System::Windows::Forms::ComboBox());
			this->cbComName = (gcnew System::Windows::Forms::ComboBox());
			this->label3 = (gcnew System::Windows::Forms::Label());
			this->label2 = (gcnew System::Windows::Forms::Label());
			this->label1 = (gcnew System::Windows::Forms::Label());
			this->lbComName = (gcnew System::Windows::Forms::Label());
			this->btOpen = (gcnew System::Windows::Forms::Button());
			this->btPrint = (gcnew System::Windows::Forms::Button());
			this->textBox1 = (gcnew System::Windows::Forms::TextBox());
			this->btClose = (gcnew System::Windows::Forms::Button());
			this->groupBox1->SuspendLayout();
			this->gbPortSet->SuspendLayout();
			this->SuspendLayout();
			// 
			// groupBox1
			// 
			this->groupBox1->Controls->Add(this->rbDriveName);
			this->groupBox1->Controls->Add(this->rbCom);
			this->groupBox1->Location = System::Drawing::Point(13, 13);
			this->groupBox1->Name = L"groupBox1";
			this->groupBox1->Size = System::Drawing::Size(200, 56);
			this->groupBox1->TabIndex = 0;
			this->groupBox1->TabStop = false;
			this->groupBox1->Text = L"选择端口";
			// 
			// rbDriveName
			// 
			this->rbDriveName->AutoSize = true;
			this->rbDriveName->Location = System::Drawing::Point(82, 21);
			this->rbDriveName->Name = L"rbDriveName";
			this->rbDriveName->Size = System::Drawing::Size(71, 16);
			this->rbDriveName->TabIndex = 1;
			this->rbDriveName->TabStop = true;
			this->rbDriveName->Text = L"驱动程序";
			this->rbDriveName->UseVisualStyleBackColor = true;
			this->rbDriveName->CheckedChanged += gcnew System::EventHandler(this, &Form1::rbDriveName_CheckedChanged);
			// 
			// rbCom
			// 
			this->rbCom->AutoSize = true;
			this->rbCom->Location = System::Drawing::Point(7, 21);
			this->rbCom->Name = L"rbCom";
			this->rbCom->Size = System::Drawing::Size(47, 16);
			this->rbCom->TabIndex = 0;
			this->rbCom->TabStop = true;
			this->rbCom->Text = L"串口";
			this->rbCom->UseVisualStyleBackColor = true;
			this->rbCom->CheckedChanged += gcnew System::EventHandler(this, &Form1::rbCom_CheckedChanged);
			// 
			// gbPortSet
			// 
			this->gbPortSet->Controls->Add(this->label6);
			this->gbPortSet->Controls->Add(this->label5);
			this->gbPortSet->Controls->Add(this->cbParity);
			this->gbPortSet->Controls->Add(this->label4);
			this->gbPortSet->Controls->Add(this->cbStopBits);
			this->gbPortSet->Controls->Add(this->cbStreamCtl);
			this->gbPortSet->Controls->Add(this->cbDriveName);
			this->gbPortSet->Controls->Add(this->cbDataBits);
			this->gbPortSet->Controls->Add(this->cbBaudrate);
			this->gbPortSet->Controls->Add(this->cbComName);
			this->gbPortSet->Controls->Add(this->label3);
			this->gbPortSet->Controls->Add(this->label2);
			this->gbPortSet->Controls->Add(this->label1);
			this->gbPortSet->Controls->Add(this->lbComName);
			this->gbPortSet->Location = System::Drawing::Point(13, 75);
			this->gbPortSet->Name = L"gbPortSet";
			this->gbPortSet->Size = System::Drawing::Size(405, 183);
			this->gbPortSet->TabIndex = 1;
			this->gbPortSet->TabStop = false;
			this->gbPortSet->Text = L"端口配置";
			// 
			// label6
			// 
			this->label6->AutoSize = true;
			this->label6->Location = System::Drawing::Point(208, 100);
			this->label6->Name = L"label6";
			this->label6->Size = System::Drawing::Size(77, 12);
			this->label6->TabIndex = 14;
			this->label6->Text = L"数据流控制：";
			// 
			// label5
			// 
			this->label5->AutoSize = true;
			this->label5->Location = System::Drawing::Point(230, 67);
			this->label5->Name = L"label5";
			this->label5->Size = System::Drawing::Size(53, 12);
			this->label5->TabIndex = 13;
			this->label5->Text = L"停止位：";
			// 
			// cbParity
			// 
			this->cbParity->DropDownStyle = System::Windows::Forms::ComboBoxStyle::DropDownList;
			this->cbParity->FormattingEnabled = true;
			this->cbParity->Items->AddRange(gcnew cli::array< System::Object^  >(1) {L"无"});
			this->cbParity->Location = System::Drawing::Point(289, 26);
			this->cbParity->Name = L"cbParity";
			this->cbParity->Size = System::Drawing::Size(89, 20);
			this->cbParity->TabIndex = 8;
			this->cbParity->SelectedIndexChanged += gcnew System::EventHandler(this, &Form1::cbParity_SelectedIndexChanged);
			// 
			// label4
			// 
			this->label4->AutoSize = true;
			this->label4->Location = System::Drawing::Point(230, 29);
			this->label4->Name = L"label4";
			this->label4->Size = System::Drawing::Size(53, 12);
			this->label4->TabIndex = 12;
			this->label4->Text = L"校验位：";
			// 
			// cbStopBits
			// 
			this->cbStopBits->DropDownStyle = System::Windows::Forms::ComboBoxStyle::DropDownList;
			this->cbStopBits->FormattingEnabled = true;
			this->cbStopBits->Items->AddRange(gcnew cli::array< System::Object^  >(3) {L"1", L"1.5", L"2"});
			this->cbStopBits->Location = System::Drawing::Point(289, 64);
			this->cbStopBits->Name = L"cbStopBits";
			this->cbStopBits->Size = System::Drawing::Size(89, 20);
			this->cbStopBits->TabIndex = 11;
			this->cbStopBits->SelectedIndexChanged += gcnew System::EventHandler(this, &Form1::cbStopBits_SelectedIndexChanged);
			// 
			// cbStreamCtl
			// 
			this->cbStreamCtl->DropDownStyle = System::Windows::Forms::ComboBoxStyle::DropDownList;
			this->cbStreamCtl->FormattingEnabled = true;
			this->cbStreamCtl->Items->AddRange(gcnew cli::array< System::Object^  >(4) {L"0", L"1", L"2", L"3"});
			this->cbStreamCtl->Location = System::Drawing::Point(289, 100);
			this->cbStreamCtl->Name = L"cbStreamCtl";
			this->cbStreamCtl->Size = System::Drawing::Size(89, 20);
			this->cbStreamCtl->TabIndex = 10;
			this->cbStreamCtl->SelectedIndexChanged += gcnew System::EventHandler(this, &Form1::cbStreamCtl_SelectedIndexChanged);
			// 
			// cbDriveName
			// 
			this->cbDriveName->FormattingEnabled = true;
			this->cbDriveName->Location = System::Drawing::Point(91, 120);
			this->cbDriveName->Name = L"cbDriveName";
			this->cbDriveName->Size = System::Drawing::Size(88, 20);
			this->cbDriveName->TabIndex = 7;
			this->cbDriveName->SelectedIndexChanged += gcnew System::EventHandler(this, &Form1::cbDriveName_SelectedIndexChanged);
			// 
			// cbDataBits
			// 
			this->cbDataBits->DropDownStyle = System::Windows::Forms::ComboBoxStyle::DropDownList;
			this->cbDataBits->FormattingEnabled = true;
			this->cbDataBits->Items->AddRange(gcnew cli::array< System::Object^  >(4) {L"5", L"6", L"7", L"8"});
			this->cbDataBits->Location = System::Drawing::Point(91, 92);
			this->cbDataBits->Name = L"cbDataBits";
			this->cbDataBits->Size = System::Drawing::Size(88, 20);
			this->cbDataBits->TabIndex = 6;
			this->cbDataBits->SelectedIndexChanged += gcnew System::EventHandler(this, &Form1::cbDataBits_SelectedIndexChanged);
			// 
			// cbBaudrate
			// 
			this->cbBaudrate->DropDownStyle = System::Windows::Forms::ComboBoxStyle::DropDownList;
			this->cbBaudrate->FormattingEnabled = true;
			this->cbBaudrate->Items->AddRange(gcnew cli::array< System::Object^  >(7) {L"2400", L"4800", L"9600", L"19200", L"38400", 
				L"57600", L"115200"});
			this->cbBaudrate->Location = System::Drawing::Point(92, 59);
			this->cbBaudrate->Name = L"cbBaudrate";
			this->cbBaudrate->Size = System::Drawing::Size(88, 20);
			this->cbBaudrate->TabIndex = 5;
			this->cbBaudrate->SelectedIndexChanged += gcnew System::EventHandler(this, &Form1::cbBaudrate_SelectedIndexChanged);
			// 
			// cbComName
			// 
			this->cbComName->DropDownStyle = System::Windows::Forms::ComboBoxStyle::DropDownList;
			this->cbComName->FormattingEnabled = true;
			this->cbComName->Items->AddRange(gcnew cli::array< System::Object^  >(2) {L"COM2", L"COM3"});
			this->cbComName->Location = System::Drawing::Point(91, 26);
			this->cbComName->Name = L"cbComName";
			this->cbComName->Size = System::Drawing::Size(89, 20);
			this->cbComName->TabIndex = 4;
			this->cbComName->SelectedIndexChanged += gcnew System::EventHandler(this, &Form1::cbComName_SelectedIndexChanged);
			// 
			// label3
			// 
			this->label3->AutoSize = true;
			this->label3->Location = System::Drawing::Point(20, 128);
			this->label3->Name = L"label3";
			this->label3->Size = System::Drawing::Size(65, 12);
			this->label3->TabIndex = 3;
			this->label3->Text = L"驱动名称：";
			// 
			// label2
			// 
			this->label2->AutoSize = true;
			this->label2->Location = System::Drawing::Point(32, 95);
			this->label2->Name = L"label2";
			this->label2->Size = System::Drawing::Size(53, 12);
			this->label2->TabIndex = 2;
			this->label2->Text = L"数据位：";
			// 
			// label1
			// 
			this->label1->AutoSize = true;
			this->label1->Location = System::Drawing::Point(33, 62);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(53, 12);
			this->label1->TabIndex = 1;
			this->label1->Text = L"波特率：";
			// 
			// lbComName
			// 
			this->lbComName->AutoSize = true;
			this->lbComName->Location = System::Drawing::Point(20, 29);
			this->lbComName->Name = L"lbComName";
			this->lbComName->Size = System::Drawing::Size(65, 12);
			this->lbComName->TabIndex = 0;
			this->lbComName->Text = L"串口名称：";
			// 
			// btOpen
			// 
			this->btOpen->Location = System::Drawing::Point(13, 265);
			this->btOpen->Name = L"btOpen";
			this->btOpen->Size = System::Drawing::Size(75, 31);
			this->btOpen->TabIndex = 2;
			this->btOpen->Text = L"打开端口";
			this->btOpen->UseVisualStyleBackColor = true;
			this->btOpen->Click += gcnew System::EventHandler(this, &Form1::btOpen_Click);
			// 
			// btPrint
			// 
			this->btPrint->Location = System::Drawing::Point(95, 265);
			this->btPrint->Name = L"btPrint";
			this->btPrint->Size = System::Drawing::Size(52, 30);
			this->btPrint->TabIndex = 3;
			this->btPrint->Text = L"打印";
			this->btPrint->UseVisualStyleBackColor = true;
			this->btPrint->Click += gcnew System::EventHandler(this, &Form1::btPrint_Click);
			// 
			// textBox1
			// 
			this->textBox1->Location = System::Drawing::Point(153, 271);
			this->textBox1->Name = L"textBox1";
			this->textBox1->ReadOnly = true;
			this->textBox1->Size = System::Drawing::Size(197, 21);
			this->textBox1->TabIndex = 4;
			// 
			// btClose
			// 
			this->btClose->Location = System::Drawing::Point(363, 264);
			this->btClose->Name = L"btClose";
			this->btClose->Size = System::Drawing::Size(75, 31);
			this->btClose->TabIndex = 5;
			this->btClose->Text = L"关闭端口";
			this->btClose->UseVisualStyleBackColor = true;
			this->btClose->Click += gcnew System::EventHandler(this, &Form1::button1_Click);
			// 
			// Form1
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 12);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(450, 300);
			this->Controls->Add(this->btClose);
			this->Controls->Add(this->textBox1);
			this->Controls->Add(this->btPrint);
			this->Controls->Add(this->btOpen);
			this->Controls->Add(this->gbPortSet);
			this->Controls->Add(this->groupBox1);
			this->Name = L"Form1";
			this->Text = L"POSdllDemo";
			this->Load += gcnew System::EventHandler(this, &Form1::Form1_Load);
			this->groupBox1->ResumeLayout(false);
			this->groupBox1->PerformLayout();
			this->gbPortSet->ResumeLayout(false);
			this->gbPortSet->PerformLayout();
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion

		System::String^ lpName;
        int nParam ;
        int nBaudrate ;
        int nDataBits ;
        int nStopBits ;
        int nParity ;
		System::String^ patha;
		System::String^ pathb;
		System::String^ pathc;

	private: System::Void Form1_Load(System::Object^  sender, System::EventArgs^  e) {
				 patha=L"Look.bmp";
				 pathb=L"Kitty.bmp";
			 }
	private: System::Void rbCom_CheckedChanged(System::Object^  sender, System::EventArgs^  e) {
			cbDriveName->Enabled = false;
            cbComName->Enabled = true;
            cbDataBits->Enabled = true;
            cbParity->Enabled = true;
            cbStopBits->Enabled = true;
            cbStreamCtl->Enabled = true;
            cbBaudrate->Enabled = true;

			 }
private: System::Void rbDriveName_CheckedChanged(System::Object^  sender, System::EventArgs^  e) {
			 cbComName->Enabled = false;
            cbDataBits->Enabled = false;
            cbParity->Enabled = false;
            cbStopBits->Enabled = false;
            cbStreamCtl->Enabled = false;
            cbBaudrate->Enabled = false;
            cbDriveName->Enabled = true;
			nParam = C_POSDLL::POS_OPEN_PRINTNAME;
		 }
private: System::Void cbComName_SelectedIndexChanged(System::Object^  sender, System::EventArgs^  e) {
			 lpName = cbComName->Text;
		 }
private: System::Void btOpen_Click(System::Object^  sender, System::EventArgs^  e) {
			 btOpen->Enabled = false;
            btPrint->Enabled = true;
            btClose->Enabled = true;
			int rValue = C_POSDLL::POS_Open(lpName, nBaudrate, nDataBits, nStopBits, nParity, nParam);
			MessageBox::Show("0x" + rValue.ToString("x"));
		 }
private: System::Void button1_Click(System::Object^  sender, System::EventArgs^  e) {

			 int rValue = C_POSDLL::POS_Close();
			 MessageBox::Show("0x" + rValue.ToString("x"));
			 btOpen->Enabled = true;
            btPrint->Enabled = false;
            btClose->Enabled = false;

		 }
private: System::Void btPrint_Click(System::Object^  sender, System::EventArgs^  e) {
			 
            C_POSDLL::POS_SetMode(0);
            C_POSDLL::POS_S_TextOut("KaiCong POS Thermal Printer", 48, 0, 2, 0, 0x00);
            C_POSDLL::POS_FeedLine();
            C_POSDLL::POS_FeedLine();
            C_POSDLL::POS_S_TextOut("开聪热敏打印机", 24, 0, 0, 0, 0x100);
            C_POSDLL::POS_FeedLine();
            C_POSDLL::POS_SetRightSpacing(12);
            C_POSDLL::POS_S_TextOut("开聪热敏打印机", 24, 0, 0, 0, 0x80);
            C_POSDLL::POS_FeedLine();
            C_POSDLL::POS_FeedLine();
            C_POSDLL::POS_SetRightSpacing(0);
            C_POSDLL::POS_S_TextOut("BM9000", 0, 0, 0, 1, 0x80);
            C_POSDLL::POS_S_TextOut("POS PRINTER", 192, 0, 0, 0, 0x00);
            C_POSDLL::POS_FeedLine();
            C_POSDLL::POS_SetRightSpacing(3);
            C_POSDLL::POS_S_TextOut("BM9000", 0, 0, 0, 1, 0x80);
            C_POSDLL::POS_S_TextOut("POS PRINTER", 192, 0, 0, 0, 0x00);
            C_POSDLL::POS_FeedLine();
            C_POSDLL::POS_SetRightSpacing(6);
            C_POSDLL::POS_S_TextOut("BM9000", 0, 0, 0, 1, 0x80);
            C_POSDLL::POS_S_TextOut("POS PRINTER", 192, 0, 0, 0, 0x00);
            C_POSDLL::POS_FeedLine();
            C_POSDLL::POS_S_TextOut("正常字体打印", 0, 0, 0, 0, 0x00);
            C_POSDLL::POS_FeedLine();
            C_POSDLL::POS_S_TextOut("反显字体打印", 0, 0, 0, 0, 0x400);
            C_POSDLL::POS_FeedLine();
            C_POSDLL::POS_S_TextOut("顺时针旋转90度字体打印", 0, 0, 0, 0, 0x1000);
            C_POSDLL::POS_FeedLine();
            C_POSDLL::POS_S_TextOut("倒置字体打印", 0, 0, 0, 0, 0x200);
            C_POSDLL::POS_FeedLine();
            C_POSDLL::POS_S_TextOut("    ----------------> Logo 1", 0, 0, 0, 0, 0);
            C_POSDLL::POS_FeedLine();
            C_POSDLL::POS_PreDownloadBmpToRAM(patha, 0);
            C_POSDLL::POS_S_PrintBmpInRAM(0, 96, 0);
            C_POSDLL::POS_S_TextOut("    ----------------> Logo 2", 0, 0, 0, 0, 0);
            C_POSDLL::POS_FeedLine();
            C_POSDLL::POS_PreDownloadBmpToRAM(pathb, 0);
            C_POSDLL::POS_S_PrintBmpInRAM(0, 0, 3);
            C_POSDLL::POS_S_TextOut("    ----------------> Logo 3", 0, 0, 0, 0, 0);
            C_POSDLL::POS_FeedLine();
            C_POSDLL::POS_S_PrintBmpInFlash(1, 96, 0);
            C_POSDLL::POS_S_TextOut("UPC-A", 0, 0, 0, 0, 0);
            C_POSDLL::POS_FeedLine();
            C_POSDLL::POS_S_SetBarcode("01234567890", 24, 0x41, 3, 100, 0x00, 0x02, 11);
            C_POSDLL::POS_FeedLine();
            C_POSDLL::POS_S_TextOut("UPC-E", 0, 0, 0, 0, 0);
            C_POSDLL::POS_FeedLine();
            C_POSDLL::POS_S_SetBarcode("042100005264", 96, 0x42, 3, 100, 0x00, 0x02, 12);
            C_POSDLL::POS_FeedLine();
            C_POSDLL::POS_S_TextOut("EAN13", 0, 0, 0, 0, 0);
            C_POSDLL::POS_FeedLine();
            C_POSDLL::POS_S_SetBarcode("104210000526", 24, 0x43, 3, 100, 0x00, 0x02, 12);
            C_POSDLL::POS_FeedLine();
            C_POSDLL::POS_S_TextOut("EAN8", 0, 0, 0, 0, 0);
            C_POSDLL::POS_FeedLine();
            C_POSDLL::POS_S_SetBarcode("2042100", 24, 0x44, 3, 100, 0x00, 0x02, 7);
            C_POSDLL::POS_FeedLine();
            C_POSDLL::POS_S_TextOut("CODE39", 0, 0, 0, 0, 0);
            C_POSDLL::POS_FeedLine();
            C_POSDLL::POS_S_SetBarcode("*0423*", 0, 0x45, 2, 100, 0x00, 0x02, 6);
            C_POSDLL::POS_FeedLine();
            C_POSDLL::POS_S_TextOut("ITF", 0, 0, 0, 0, 0);
            C_POSDLL::POS_FeedLine();
            C_POSDLL::POS_S_SetBarcode("0423", 96, 0x46, 3, 100, 0x00, 0x02, 4);
            C_POSDLL::POS_FeedLine();
            C_POSDLL::POS_S_TextOut("CODEBAR", 0, 0, 0, 0, 0);
            C_POSDLL::POS_FeedLine();
            C_POSDLL::POS_S_SetBarcode("A42368B", 24, 0x47, 3, 100, 0x00, 0x02, 7);
            C_POSDLL::POS_FeedLine();
            C_POSDLL::POS_S_TextOut("CODE93", 0, 0, 0, 0, 0);
            C_POSDLL::POS_FeedLine();
            C_POSDLL::POS_S_SetBarcode("342368ABC", 24, 0x48, 3, 100, 0x00, 0x02, 9);
            C_POSDLL::POS_FeedLine();
            C_POSDLL::POS_S_TextOut("CODE128", 0, 0, 0, 0, 0);
            C_POSDLL::POS_FeedLine();
            C_POSDLL::POS_S_SetBarcode("{AHI{C345678", 0, 0x49, 2, 100, 0x00, 0x02, 12);
            C_POSDLL::POS_FeedLine();
            
            C_POSDLL::POS_SetMotionUnit(180, 180);
            C_POSDLL::POS_PL_SetArea(0, 0, 384, 740, 0);
            C_POSDLL::POS_SetMode(1);
            C_POSDLL::POS_PL_TextOut("PageMode:KaiCongDianZi Thermal Printer", 0, 32, 0, 0, 0, 0);
            C_POSDLL::POS_PL_TextOut("页模式：开聪电子热敏打印机测试页", 0, 96, 0, 0, 0, 0);
            C_POSDLL::POS_PL_TextOut("反显", 96, 128, 0, 0, 0, 0x400);
            C_POSDLL::POS_PL_TextOut("下划线", 96, 160, 0, 0, 0, 0x100);
            C_POSDLL::POS_PL_TextOut("    ----------------> Logo 4", 0, 192, 0, 0, 0, 0);
            C_POSDLL::POS_PreDownloadBmpToRAM(pathb, 0);
            C_POSDLL::POS_PL_PrintBmpInRAM(0, 48, 465, 0);
            C_POSDLL::POS_PL_SetBarcode("{AHI{C345678", 0, 627, 0x49, 2, 162, 0x00, 0x02, 12);
            C_POSDLL::POS_PL_TextOut("页模式：开聪电子热敏打印机测试页 end", 0, 699, 0, 0, 0, 0);
            C_POSDLL::POS_PL_Print();
            C_POSDLL::POS_PL_Clear();
            
		 }
private: System::Void cbDriveName_SelectedIndexChanged(System::Object^  sender, System::EventArgs^  e) {
			 lpName = cbDriveName->Text;
		 }
private: System::Void cbStreamCtl_SelectedIndexChanged(System::Object^  sender, System::EventArgs^  e) {
			 nParam = cbStreamCtl->SelectedIndex;
		 }
private: System::Void cbParity_SelectedIndexChanged(System::Object^  sender, System::EventArgs^  e) {
			 nParity = cbParity->SelectedIndex;
		 }
private: System::Void cbStopBits_SelectedIndexChanged(System::Object^  sender, System::EventArgs^  e) {
			 nStopBits = cbStopBits->SelectedIndex;
		 }
private: System::Void cbBaudrate_SelectedIndexChanged(System::Object^  sender, System::EventArgs^  e) {
			 nBaudrate = int::Parse(cbBaudrate->Text);
		 }
private: System::Void cbDataBits_SelectedIndexChanged(System::Object^  sender, System::EventArgs^  e) {
			 nDataBits = int::Parse(cbDataBits->Text);
		 }
};
}

