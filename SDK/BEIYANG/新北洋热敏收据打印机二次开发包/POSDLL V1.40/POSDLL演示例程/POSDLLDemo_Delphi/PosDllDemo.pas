unit PosDllDemo;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ExtCtrls,PosdllFuncs,IniFiles,
  winspool, XPMan;
type
  TMainForm = class(TForm)
    PortSet: TGroupBox;
    Label1: TLabel;
    Label2: TLabel;
    Label3: TLabel;
    Label5: TLabel;
    Label4: TLabel;
    Label8: TLabel;
    Label6: TLabel;
    Label7: TLabel;
    Label9: TLabel;
    cbPortName: TComboBox;
    cbBaud: TComboBox;
    cbData: TComboBox;
    cbParity: TComboBox;
    cbStop: TComboBox;
    cbFlow: TComboBox;
    cbLPT: TComboBox;
    edDrive: TEdit;
    ChkWrite: TCheckBox;
    OpenPort: TButton;
    Aboutinquire: TButton;
    edQuery: TEdit;
    Print: TButton;
    ClosePort: TButton;
    GroupBox3: TGroupBox;
    Label10: TLabel;
    pagewide: TComboBox;
    IP1: TEdit;
    IP2: TEdit;
    IP3: TEdit;
    IP4: TEdit;
    PortChoice: TRadioGroup;
    ModeSelect: TRadioGroup;
    procedure FormResize(Sender: TObject);
    procedure IP4KeyPress(Sender: TObject; var Key: Char);
  //procedure Button1Click(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure OpenPortClick(Sender: TObject);
    procedure AboutinquireClick(Sender: TObject);
    procedure ClosePortClick(Sender: TObject);
    procedure PrintClick(Sender: TObject);
    procedure IP1KeyPress(Sender: TObject; var Key: Char);
    procedure IP2KeyPress(Sender: TObject; var Key: Char);
    procedure IP3KeyPress(Sender: TObject; var Key: Char);
    procedure PortChoiceClick(Sender: TObject);
    procedure cbPortNameChange(Sender: TObject);
    procedure IP1Change(Sender: TObject);
    procedure IP2Change(Sender: TObject);
    procedure IP3Change(Sender: TObject);
    procedure IP4Change(Sender: TObject);
    procedure cbLPTChange(Sender: TObject);
  private
    { Private declarations }
    procedure PrintInStandardMode80();
    procedure PrintInPageMode80();
    procedure PrintInStandardMode56();
    procedure PrintInPageMode56();
  public
    { Public declarations }
  end;

var
  MainForm: TMainForm;
  b_OpenPort :boolean;//�Ƿ�򿪶˿�.
  Portname,Portname1 : String;///�˿�����
  baudRate1,StopBit,DataBit,HandShake,Paritytemp :Integer;
  ComName,LptName,UsbName: integer;
  Porttype :integer;
  state:integer;
  
  bHasDownToFlash56: Bool;
  bHasDownToFlash80: Bool;
  bHasDownToRAM56: Bool;
  bHasDownToRAM80: Bool;
  portid:integer;

  i_portIndex : integer;
  ipConst : String;        //����ӿ������IPֵ
  iReturndate : integer;

implementation

{$R *.dfm}

procedure TMainForm.PrintInStandardMode80();   //80���ױ�׼ģʽ���ź���
var
  strBitImages: array[0..2] of string;
  iCount: Integer;
begin
   iReturndate:=POS_SetMotionUnit(180, 180);
  if iReturndate<>1001 then
  begin
     edQuery.Text:='��ӡʧ�ܣ�';
     OpenPort.Enabled:=true;
     Aboutinquire.Enabled:=false;
     Print.Enabled:=False;
     ClosePort.Enabled:=False;
     exit;
  end;

  // Ԥ����λͼ�� Flash��������粻�ᶪʧ

  strBitImages[0] := 'Kitty.bmp';
  strBitImages[1] := 'Look.bmp';
  iCount := 2;

  if bHasDownToFlash80 = False then
  begin
    POS_PreDownloadBmpsToFlash(strBitImages, iCount);
    bHasDownToFlash80 := True;
 {   if PortChoice.ItemIndex=1 then
    begin
      Print.Enabled:=False;
    end;
 }
  end;


	POS_SetMode(POS_PRINT_MODE_STANDARD);

	POS_SetRightSpacing(0);

	POS_SetLineSpacing(100);
	POS_S_TextOut('Beiyang POS Printer', 50, 2, 3, POS_FONT_TYPE_STANDARD,
		POS_FONT_STYLE_NORMAL);
		
	POS_SetLineSpacing(35);

	POS_FeedLine();
	POS_FeedLine();

	POS_S_TextOut('����������ӡ��', 20, 1, 1, POS_FONT_TYPE_CHINESE,
		POS_FONT_STYLE_THICK_UNDERLINE);
	POS_FeedLine();
	POS_S_TextOut('�� �� �� �� �� ӡ ��', 20, 1, 1, POS_FONT_TYPE_CHINESE,
		POS_FONT_STYLE_THIN_UNDERLINE);
	POS_FeedLine();
	POS_FeedLine();

	POS_SetLineSpacing(24);

	// ��ͬ���ַ��Ҽ��

	POS_SetRightSpacing(0);
	POS_S_TextOut('BTP-2000CP', 20, 1, 1, POS_FONT_TYPE_STANDARD, 
		POS_FONT_STYLE_NORMAL);
	POS_S_TextOut('POS Thermal Printer', 200, 1, 1, POS_FONT_TYPE_STANDARD,
		POS_FONT_STYLE_NORMAL);
	POS_FeedLine();

	POS_SetRightSpacing(2);
	POS_S_TextOut('BTP-2001CP', 20, 1, 1, POS_FONT_TYPE_STANDARD,
		POS_FONT_STYLE_NORMAL);
	POS_S_TextOut('POS Thermal Printer', 200, 1, 1, POS_FONT_TYPE_STANDARD,
		POS_FONT_STYLE_NORMAL);
	POS_FeedLine();

	POS_SetRightSpacing(4);
	POS_S_TextOut('BTP-2002CP', 20, 1, 1, POS_FONT_TYPE_STANDARD,
		POS_FONT_STYLE_NORMAL);
	POS_S_TextOut('POS Thermal Printer', 200, 1, 1, POS_FONT_TYPE_STANDARD,
		POS_FONT_STYLE_NORMAL);
	POS_FeedLine();
	POS_FeedLine();

	// ��ͬ���ַ����

	POS_SetRightSpacing(2);
	POS_S_TextOut('���������ӡ', 20, 1, 1, POS_FONT_TYPE_CHINESE,
		POS_FONT_STYLE_NORMAL);
	POS_FeedLine();
  POS_S_TextOut('���������ӡ', 20, 1, 1, POS_FONT_TYPE_CHINESE,
		POS_FONT_STYLE_REVERSE);
	POS_FeedLine();
	POS_S_TextOut('˳ʱ����ת90�������ӡ', 20, 1, 1, POS_FONT_TYPE_CHINESE,
		POS_FONT_STYLE_CLOCKWISE_90);
	POS_FeedLine();
	POS_S_TextOut('���������ӡ', 20, 1, 1, POS_FONT_TYPE_CHINESE,
		POS_FONT_STYLE_UPSIDEDOWN);
	POS_FeedLine();
	POS_FeedLine();
	

	// ��ӡ����

	POS_SetRightSpacing(0);

	POS_S_TextOut('----------------------------------', 50, 1, 1, POS_FONT_TYPE_STANDARD,
		POS_FONT_STYLE_NORMAL);
	POS_FeedLine();

	POS_S_TextOut('Barcode - Code 128', 160, 1, 1, POS_FONT_TYPE_COMPRESSED,
		POS_FONT_STYLE_NORMAL);
	POS_FeedLine();
	POS_FeedLine();

	POS_S_SetBarcode('{A*1234ABCDE*{C5678', 40, POS_BARCODE_TYPE_CODE128,
    2, 50, POS_FONT_TYPE_COMPRESSED, POS_HRI_POSITION_BOTH, 19);
	POS_FeedLine();
	
	POS_S_TextOut('----------------------------------', 50, 1, 1, POS_FONT_TYPE_STANDARD,
		POS_FONT_STYLE_NORMAL);	
	POS_FeedLine();

	// ��ӡ�����ص� Flash �е�λͼ

	POS_FeedLine();
	POS_S_TextOut('-------------> Logo 1', 20, 1, 1, POS_FONT_TYPE_STANDARD,
		POS_FONT_STYLE_NORMAL);
	POS_FeedLine();
	POS_S_PrintBmpInFlash(1, 20, POS_BITMAP_PRINT_NORMAL);

	POS_FeedLine();
	POS_S_TextOut('-------------> Logo 2', 20, 1, 1, POS_FONT_TYPE_STANDARD,
		POS_FONT_STYLE_NORMAL);
	POS_FeedLine();
	POS_S_PrintBmpInFlash(2, 20, POS_BITMAP_PRINT_NORMAL);

	POS_FeedLine();
	POS_FeedLine();
  POS_FeedLine();
	POS_FeedLine();
  POS_FeedLine();
	POS_FeedLine();
  POS_FeedLine();
	POS_FeedLine();
  POS_FeedLine();
	POS_FeedLine();
  POS_FeedLine();
	POS_FeedLine();

	// ��ֽ
	POS_CutPaper(POS_CUT_MODE_FULL, 0);
  edQuery.Text:='��ӡ�ɹ�!';

end;

procedure TMainForm.PrintInPageMode80();     //80���׵�ҳģʽ���ź���
begin
   iReturndate:=POS_SetMotionUnit(180, 180);
  if iReturndate<>1001 then
  begin
     edQuery.Text:='��ӡʧ�ܣ�';
     OpenPort.Enabled:=true;
     Aboutinquire.Enabled:=false;
     Print.Enabled:=False;
     ClosePort.Enabled:=False;
     exit;
  end;

   // Ԥ����λͼ�� RAM�����������ʧ
  if bHasDownToRAM80 = False then
  begin
    POS_PreDownloadBmpToRAM('Kitty.bmp', 0);      // ID ��Ϊ 0
		POS_PreDownloadBmpToRAM('Look.bmp', 1);     // ID ��Ϊ 1
   // bHasDownToRAM80 := True;
  end;

  //POS_SetMotionUnit(180, 180);
	POS_SetMode(POS_PRINT_MODE_PAGE);	

	POS_PL_SetArea(10, 10, 620, 800, POS_AREA_BOTTOM_TO_TOP);
	POS_PL_Clear();

	POS_SetRightSpacing(0);

	POS_PL_TextOut('Beiyang POS Thermal Printer', 20, 80, 2, 2, POS_FONT_TYPE_STANDARD,
		POS_FONT_STYLE_THICK_UNDERLINE);

	// ��ͬ�ַ��Ҽ��

	POS_SetRightSpacing(0);
	POS_PL_TextOut('BTP-2000CP', 30, 140, 1, 1, POS_FONT_TYPE_STANDARD,
		POS_FONT_STYLE_NORMAL);
	POS_PL_TextOut('POS Thermal Printer', 300, 140, 1, 1, POS_FONT_TYPE_STANDARD,
		POS_FONT_STYLE_NORMAL);

	POS_SetRightSpacing(4);
	POS_PL_TextOut('BTP-2001CP', 30, 180, 1, 1, POS_FONT_TYPE_STANDARD,
		POS_FONT_STYLE_NORMAL);
	POS_PL_TextOut('POS Thermal Printer', 300, 180, 1, 1, POS_FONT_TYPE_STANDARD,
		POS_FONT_STYLE_NORMAL);

	POS_SetRightSpacing(8);
	POS_PL_TextOut('BTP-2002CP', 30, 220, 1, 1, POS_FONT_TYPE_STANDARD,
		POS_FONT_STYLE_NORMAL);
	POS_PL_TextOut('POS Thermal Printer', 300, 220, 1, 1, POS_FONT_TYPE_STANDARD,
		POS_FONT_STYLE_NORMAL);

	POS_SetRightSpacing(0);

	POS_PL_TextOut('********************', 110, 260, 2, 1, POS_FONT_TYPE_STANDARD,
		POS_FONT_STYLE_NORMAL);

	// ��ӡ����

	POS_PL_TextOut('Barcode - Code 128', 260, 290, 1, 1, POS_FONT_TYPE_STANDARD,
		POS_FONT_STYLE_NORMAL);
	POS_PL_SetBarcode('{A*123ABC*{C34567890', 40, 360, POS_BARCODE_TYPE_CODE128, 3, 50,
		POS_FONT_TYPE_COMPRESSED, POS_HRI_POSITION_BELOW, 20);

	// ��ӡ�Ѿ����ص� RAM �е�λͼ

	POS_PL_PrintBmpInRAM(0, 50, 450, POS_BITMAP_PRINT_NORMAL);
	POS_PL_PrintBmpInRAM(0, 230, 450, POS_BITMAP_PRINT_NORMAL);
	POS_PL_PrintBmpInRAM(1, 410, 450, POS_BITMAP_PRINT_NORMAL);
	POS_PL_PrintBmpInRAM(1, 590, 450, POS_BITMAP_PRINT_NORMAL);

	POS_PL_Print();
	POS_PL_Clear();
	POS_CutPaper(POS_CUT_MODE_PARTIAL, 150);
  edQuery.Text:='��ӡ�ɹ�!';
{  if PortChoice.ItemIndex=1 then
    begin
      Print.Enabled:=False;
    end;
 }
end;

procedure TMainForm.PrintInStandardMode56();    //56���ױ�׼ģʽ���ź���
var
  strBitImages: array[0..2] of string;
  iCount: Integer;
begin
 iReturndate:=POS_SetMotionUnit(180, 180);
  if iReturndate<>1001 then
  begin
     edQuery.Text:='��ӡʧ�ܣ�';
     OpenPort.Enabled:=true;
     Aboutinquire.Enabled:=false;
     Print.Enabled:=False;
     ClosePort.Enabled:=False;
     exit;
  end;

  // Ԥ����λͼ�� Flash��������粻�ᶪʧ

  strBitImages[0] := 'Kitty.bmp';
  strBitImages[1] := 'Look.bmp';
  iCount := 2;

  if bHasDownToFlash56 = False then
  begin
    POS_PreDownloadBmpsToFlash(strBitImages, iCount);
    bHasDownToFlash56 := True;
  end;

  //POS_SetMotionUnit(180, 180);
	POS_SetMode(POS_PRINT_MODE_STANDARD);

	POS_SetRightSpacing(0);

	POS_SetLineSpacing(100);
	POS_S_TextOut('Beiyang POS Thermal Printer', 30, 1, 2, POS_FONT_TYPE_STANDARD,
		POS_FONT_STYLE_NORMAL);

	POS_SetLineSpacing(35);

	POS_FeedLine();
	POS_FeedLine();
	POS_S_TextOut('����������ӡ��', 20, 1, 1, POS_FONT_TYPE_CHINESE,
		POS_FONT_STYLE_THICK_UNDERLINE);
	POS_FeedLine();
	POS_S_TextOut('�� �� �� �� �� ӡ ��', 20, 1, 1, POS_FONT_TYPE_CHINESE,
		POS_FONT_STYLE_THIN_UNDERLINE);
	POS_FeedLine();
	POS_FeedLine();

  POS_SetLineSpacing(24);

	// ��ͬ���ַ��Ҽ��

	POS_SetRightSpacing(0);
	POS_S_TextOut('BTP-2000CP', 20, 1, 1, POS_FONT_TYPE_STANDARD,
		POS_FONT_STYLE_NORMAL);
	POS_S_TextOut('POS Printer', 200, 1, 1, POS_FONT_TYPE_STANDARD,
		POS_FONT_STYLE_NORMAL);
	POS_FeedLine();

	POS_SetRightSpacing(2);
	POS_S_TextOut('BTP-2001CP', 20, 1, 1, POS_FONT_TYPE_STANDARD,
		POS_FONT_STYLE_NORMAL);
	POS_S_TextOut('POS Printer', 200, 1, 1, POS_FONT_TYPE_STANDARD,
		POS_FONT_STYLE_NORMAL);
	POS_FeedLine();

	POS_SetRightSpacing(4);
	POS_S_TextOut('BTP-2002CP', 20, 1, 1, POS_FONT_TYPE_STANDARD,
		POS_FONT_STYLE_NORMAL);
	POS_S_TextOut('POS Printer', 200, 1, 1, POS_FONT_TYPE_STANDARD,
		POS_FONT_STYLE_NORMAL);
	POS_FeedLine();
	POS_FeedLine();

	// ��ͬ�������ʽ

	POS_SetRightSpacing(5);
	POS_S_TextOut('���������ӡ', 20, 1, 1, POS_FONT_TYPE_CHINESE,
		POS_FONT_STYLE_NORMAL);
	POS_FeedLine();
  POS_S_TextOut('���������ӡ', 20, 1, 1, POS_FONT_TYPE_CHINESE,
		POS_FONT_STYLE_REVERSE);
	POS_FeedLine();
	POS_S_TextOut('˳ʱ����ת90�������ӡ', 20, 1, 1, POS_FONT_TYPE_CHINESE,
		POS_FONT_STYLE_CLOCKWISE_90);
	POS_FeedLine();
	POS_S_TextOut('���������ӡ', 20, 1, 1, POS_FONT_TYPE_CHINESE,
		POS_FONT_STYLE_UPSIDEDOWN);
	POS_FeedLine();
	POS_FeedLine();

	// ��ӡ����

	POS_SetRightSpacing(0);

	POS_S_TextOut('-----------------------', 50, 1, 1, POS_FONT_TYPE_STANDARD,
		POS_FONT_STYLE_NORMAL);

	POS_FeedLine();

	POS_S_TextOut('Barcode - Code 128', 100, 1, 1, POS_FONT_TYPE_COMPRESSED,
		POS_FONT_STYLE_NORMAL);

	POS_FeedLine();

	POS_S_SetBarcode('{A*123AB{C567', 50, POS_BARCODE_TYPE_CODE128, 2, 50,
    POS_FONT_TYPE_COMPRESSED, POS_HRI_POSITION_BOTH, 13);

	POS_S_TextOut('-----------------------', 50, 1, 1, POS_FONT_TYPE_STANDARD,
		POS_FONT_STYLE_NORMAL);

	POS_FeedLine();

	// ��ӡ�����ص� Flash �е�λͼ

	POS_FeedLine();
	POS_S_TextOut('-------------> Logo 1', 20, 1, 1, POS_FONT_TYPE_STANDARD,
		POS_FONT_STYLE_NORMAL);
	POS_FeedLine();
	POS_S_PrintBmpInFlash(1, 20, POS_BITMAP_PRINT_NORMAL);
	POS_FeedLine();

	POS_S_TextOut('-------------> Logo 2', 20, 1, 1, POS_FONT_TYPE_STANDARD,
		POS_FONT_STYLE_NORMAL);
	POS_FeedLine();
	POS_S_PrintBmpInFlash(2, 20, POS_BITMAP_PRINT_NORMAL);

	POS_FeedLine();
	POS_FeedLine();
  POS_FeedLine();
	POS_FeedLine();
  POS_FeedLine();
	POS_FeedLine();
  POS_FeedLine();
	POS_FeedLine();
  POS_FeedLine();
	POS_FeedLine();
  POS_FeedLine();
	POS_FeedLine();

	// ��ֽ
	POS_CutPaper(POS_CUT_MODE_FULL, 0);
  edQuery.Text:='��ӡ�ɹ�!';
{  if PortChoice.ItemIndex=1 then
    begin
      Print.Enabled:=False;
    end;

 }
end;

procedure TMainForm.PrintInPageMode56();    //56����ҳģʽ���ź���
begin
  iReturndate:=POS_SetMotionUnit(180, 180);
  if iReturndate<>1001 then
    begin
     edQuery.Text:='��ӡʧ�ܣ�';
     OpenPort.Enabled:=true;
     Aboutinquire.Enabled:=false;
     Print.Enabled:=False;
     ClosePort.Enabled:=False;
     exit;
    end;

  // Ԥ����λͼ�� RAM�����������ʧ
  if bHasDownToRAM56 = False then
    begin
      POS_PreDownloadBmpToRAM('Kitty.bmp', 0);      // ID ��Ϊ 0
		  POS_PreDownloadBmpToRAM('Look.bmp', 1);     // ID ��Ϊ 1
    //bHasDownToRAM56 := True;
    end;

  //POS_SetMotionUnit(180, 180);
	POS_SetMode(POS_PRINT_MODE_PAGE);

	POS_PL_SetArea(10, 10, 440, 800, POS_AREA_BOTTOM_TO_TOP);

	POS_PL_Clear();

	POS_SetRightSpacing(0);

	POS_PL_TextOut('Beiyang POS Thermal Printer', 0, 50, 1, 1, POS_FONT_TYPE_STANDARD,
		POS_FONT_STYLE_THICK_UNDERLINE);

	// ��ͬ�ַ��Ҽ��

	POS_SetRightSpacing(0);
	POS_PL_TextOut('BTP-2000CP', 5, 80, 1, 1, POS_FONT_TYPE_STANDARD,
		POS_FONT_STYLE_NORMAL);
	POS_PL_TextOut('POS Thermal Printer', 230, 80, 1, 1, POS_FONT_TYPE_STANDARD,
		POS_FONT_STYLE_NORMAL);


	POS_SetRightSpacing(4);
	POS_PL_TextOut('BTP-2001CP', 5, 110, 1, 1, POS_FONT_TYPE_STANDARD,
		POS_FONT_STYLE_NORMAL);
	POS_PL_TextOut('POS Thermal Printer', 230, 110, 1, 1, POS_FONT_TYPE_STANDARD,
		POS_FONT_STYLE_NORMAL);

	POS_SetRightSpacing(8);
	POS_PL_TextOut('BTP-2002CP', 5, 140, 1, 1, POS_FONT_TYPE_STANDARD,
		POS_FONT_STYLE_NORMAL);
	POS_PL_TextOut('POS Thermal Printer', 230, 140, 1, 1, POS_FONT_TYPE_STANDARD,
		POS_FONT_STYLE_NORMAL);
	
	POS_SetRightSpacing(0);
	POS_SetLineSpacing(0);

	POS_PL_TextOut('********************', 70, 170, 2, 1, POS_FONT_TYPE_STANDARD,
		POS_FONT_STYLE_NORMAL);

	// ��ӡ����

	POS_PL_TextOut('Barcode - Code 128', 180, 195, 1, 1, POS_FONT_TYPE_STANDARD,
		POS_FONT_STYLE_NORMAL);

	POS_PL_SetBarcode('{A*12345ABC*{C90', 5, 260, POS_BARCODE_TYPE_CODE128, 3, 50,
    POS_FONT_TYPE_COMPRESSED, POS_HRI_POSITION_BELOW, 16);
	
	// ��ӡ�Ѿ����ص� RAM �е�λͼ

	POS_PL_PrintBmpInRAM(0, 50, 330, POS_BITMAP_PRINT_NORMAL);
//	POS_PL_PrintBmpInRAM(0, 230, 370, POS_BITMAP_PRINT_NORMAL);
	POS_PL_PrintBmpInRAM(1, 410, 330, POS_BITMAP_PRINT_NORMAL);
//	POS_PL_PrintBmpInRAM(1, 590, 370, POS_BITMAP_PRINT_NORMAL);

	POS_PL_Print();

	POS_PL_Clear();

	POS_CutPaper(POS_CUT_MODE_PARTIAL, 150);
  edQuery.Text:='��ӡ�ɹ�!';
{  if PortChoice.ItemIndex=1 then
    begin
      Print.Enabled:=False;
    end;

 }
end;
//���ú������״̬��ѯ�Ĺ���----------------------------------------------------
procedure TMainForm.AboutinquireClick(Sender: TObject);
var
  bits: array [0..7] of Integer;
  chStatus: Char;
  i: Integer;
  iReturn: Integer;
  strInfo: string;
begin
  if state <= 0  then
  begin
    edQuery.Text :='�˿�δ��';
    exit;
  end;
  strInfo := '';
   if PortChoice.ItemIndex=1 then
     iReturn:=POS_NETQueryStatus(PChar(ipConst),@chStatus)
   else
   begin
     iReturn := POS_RTQueryStatus(@chStatus);
   end;
  If iReturn <> POS_SUCCESS Then
  begin
    strInfo := '��ѯ״̬ʧ�ܣ�';
    edQuery.Text := strInfo;
    OpenPort.Enabled:=true;
    Aboutinquire.Enabled:=false;
    Print.Enabled:=False;
    ClosePort.Enabled:=False;
    exit;
  End;

  If (Integer(chStatus) = 1) then
  begin
   edQuery.Text := 'һ��������';
    exit;
  end;

  for i := 0 to 7 do
  begin
    bits[i] := (Integer(chStatus) shr i) And 1;
  end;

  if bits[0] = 0 then
    strInfo := '��Ǯ��򿪣�';

	if bits[1] = 1 then
    strInfo := strInfo + '��ӡ���ѻ���';

	if bits[2] = 1 then
	  strInfo := strInfo + '�ϸǴ򿪣�';

  if bits[3] = 1 then
    strInfo := Strinfo + '���ڽ�ֽ��';

	if bits[4] = 1 then
	  strInfo := strInfo + '��ӡ������';

	if bits[5] = 1 then
	  strInfo := strInfo + '�е�����';

	if bits[6] = 1 then
	  strInfo := strInfo + 'ֽ������';

	if bits[7] = 1 then
    strInfo := strInfo + 'ȱֽ��';

  if strInfo = '' then
    strInfo := 'һ������!';

  edQuery.Text:= strInfo;
end;
//���ú������״̬��ѯ�Ĺ���----------------------------------------------------
//------------------------------------------------------------------------------
//����ı�ѡ�������Ƚ��Ѵ򿪵Ķ˿ڹر�------------------------------------------
procedure TMainForm.cbLPTChange(Sender: TObject);
begin
    if  state  > 0 then
  begin
    POS_Close();
    state := 0;
  end;
end;

procedure TMainForm.cbPortNameChange(Sender: TObject);
begin
 if  state  > 0 then
  begin
    POS_Close();
    state := 0;
  end;
end;
//����ı�ѡ�������Ƚ��Ѵ򿪵Ķ˿ڹر�------------------------------------------
//******************************************************************************
//�˿ڹرյĲ���----------------------------------------------------------------
procedure TMainForm.ClosePortClick(Sender: TObject);
begin
  POS_Close();
  state := 0;
  if state<=0 then
  begin
     edQuery.Text:='�˿ڹرճɹ���';
     OpenPort.Enabled:=true;
  end;
  if state>0 then
  begin
     edQuery.Text:='�˿ڹر�ʧ�ܣ�';
  end;
  ClosePort.Enabled:=False;
  Aboutinquire.Enabled:=False;
  print.Enabled:=False;
end;


//�˿ڹرյĲ���----------------------------------------------------------------
//******************************************************************************
//���ð汾˵����������Ӧ�汾��Ϣ------------------------------------------------
procedure TMainForm.FormCreate(Sender: TObject);
var
    m_version,aaa : String;
    X,Y:integer;
    p1,p2:Pinteger;
begin
    p1:=@X;
    p2:=@Y;
    m_version := Format('һ���������汾��--%d',[POS_GetVersionInfo(@X,@Y)]);
    edQuery.Text :='һ���������汾��V'+IntToStr(X)+'.'+IntToStr(Y);
    cbLPT.Enabled:=False;
    edDrive.Enabled:=False;
    IP1.Enabled:=False;
    IP2.Enabled:=False;
    IP3.Enabled:=False;
    IP4.Enabled:=False;
    ClosePort.Enabled:=False;
    Print.Enabled:=False;
end;
procedure TMainForm.FormResize(Sender: TObject);
begin

end;

//���ð汾˵����������Ӧ�汾��Ϣ------------------------------------------------
//******************************************************************************
//����ӿڵ��������------------------------------------------------------------
procedure TMainForm.IP1Change(Sender: TObject);
begin
if IP1.Text<>'' then
  begin
    if (StrToInt(IP1.Text)>255)or (StrToInt(IP1.Text)<0) then
    begin
     IP1.Text:='255';
    end;
  end;
end;

procedure TMainForm.IP1KeyPress(Sender: TObject; var Key: Char);
begin
  begin
  //ѡ�е�����ɾ��
    IP1.SetSelTextBuf('');
  //�����롮'.',����������ƶ�����һ���ؼ�
  if(Key = '.') then
  begin
    IP2.SetFocus();
    Key :=  #0;
    Exit;
  end;
  if(length(IP1.Text) >= 3) and (Key <> #8) then
  begin
    Key := #0;
    MessageBeep(1);
    exit;
  end;
  if not (Key in ['0'..'9',#8]) then
  begin
    Key := #0;
    MessageBeep(1);
  end;
end;
end;

procedure TMainForm.IP2Change(Sender: TObject);
begin
  if IP2.Text<>'' then
  begin
    if (StrToInt(IP2.Text)>255)or (StrToInt(IP2.Text)<0) then
    begin
     IP2.Text:='255';
    end;
  end;
end;

procedure TMainForm.IP2KeyPress(Sender: TObject; var Key: Char);
begin
  begin
  //ѡ�е�����ɾ��
    IP2.SetSelTextBuf('');
  //�����롮'.',����������ƶ�����һ���ؼ�
  if(Key = '.') then
  begin
    IP3.SetFocus();
    Key :=  #0;
    Exit;
  end;
  if(length(IP2.Text) >= 3) and (Key <> #8) then
  begin
    Key := #0;
    MessageBeep(1);
    exit;
  end;
  if not (Key in ['0'..'9',#8]) then
  begin
    Key := #0;
    MessageBeep(1);
  end;
end;

end;
procedure TMainForm.IP3Change(Sender: TObject);
begin
  if IP3.Text<>'' then
  begin
    if (StrToInt(IP3.Text)>255)or (StrToInt(IP3.Text)<0) then
    begin
     IP3.Text:='255';
    end;
  end;
end;

procedure TMainForm.IP3KeyPress(Sender: TObject; var Key: Char);
begin
  begin
  //ѡ�е�����ɾ��
    IP3.SetSelTextBuf('');
  //�����롮'.',����������ƶ�����һ���ؼ�
  if(Key = '.') then
  begin
    IP4.SetFocus();
    Key :=  #0;
    Exit;
  end;
  if(length(IP3.Text) >= 3) and (Key <> #8) then
  begin
    Key := #0;
    MessageBeep(1);
    exit;
  end;
  if not (Key in ['0'..'9',#8]) then
  begin
    Key := #0;
    MessageBeep(1);
  end;
end;
end;
procedure TMainForm.IP4Change(Sender: TObject);
begin
  if IP4.Text<>'' then
  begin
    if (StrToInt(IP4.Text)>255)or (StrToInt(IP4.Text)<0) then
    begin
     IP4.Text:='255';
    end;
  end;
end;

procedure TMainForm.IP4KeyPress(Sender: TObject; var Key: Char);
begin
  begin
  //ѡ�е�����ɾ��
    IP4.SetSelTextBuf('');
  //�����롮'.',����������ƶ�����һ���ؼ�
  if(Key = '.') then
  begin
    ChkWrite.SetFocus();
    Key :=  #0;
    Exit;
  end;
  if(length(IP4.Text) >= 3) and (Key <> #8) then
  begin
    Key := #0;
    MessageBeep(1);
    exit;
  end;
  if not (Key in ['0'..'9',#8]) then
  begin
    Key := #0;
    MessageBeep(1);
  end;
end;

end;

//����ӿڵ��������------------------------------------------------------------
//******************************************************************************
//�򿪶˿ڲ������̴����ж˿ڵĺ������ù���------------------------------------
procedure TMainForm.OpenPortClick(Sender: TObject);
var
  baudrate:integer;        //������
  portName : pchar;        //�˿�����
  i_DriverData : pchar;   //���������
  I_cbData  : integer;    //����λ����
begin
  if state > 0 then
  begin
    POS_Close();
    state := 0;
    ClosePort.Enabled:=False;
  end;
  if i_portIndex = 0 then          //���ڲ���
  begin
//����Ʒ����������Ϊ��
// �������˿ڲ�����Ϊ������
    case cbPortName.ItemIndex of
      0: portName := 'COM1';
      1: portName := 'COM2';
      2: portName := 'COM3';
      3: portName := 'COM4';
      4: portName := 'COM5';
      5: portName := 'COM6';
      6: portName := 'COM7';
      7: portName := 'COM8';
      8: portName := 'COM9';
      9: portName := 'COM10';
    end;
    case cbBaud.ItemIndex of
      0: baudrate := 2400;
      1: baudrate := 4800;
      2: baudrate := 9600;
      3: baudrate := 19200;
      4: baudrate := 38400;
      5: baudrate := 57600;
      6: baudrate := 115200;
    end;
    case cbData.ItemIndex of
      0: I_cbData:=7;
      1: I_cbData:=8;
    end;
    state := POS_Open(portName, baudrate, I_cbData, POS_COM_ONESTOPBIT, cbParity.ItemIndex, cbFlow.ItemIndex);
//�ж϶˿��Ƿ��--------------------------------------------------------------
   { if state <> -1 then
    begin
      Print.Enabled := true;
      edQuery.Text := '�򿪶˿ڳɹ���';
    end
    else
     begin
      Print.Enabled := true;
      edQuery.Text := '�򿪶˿�ʧ�ܣ�';
    end }
//�ж϶˿��Ƿ��--------------------------------------------------------------
  end
  else if i_portIndex = 1 then  //����ӿڲ�������IP�Ӷ���ȷ��������Ҫ�Ĳ���
  begin
    edQuery.Text:='ѡ���������';
    ipConst:=(IP1.Text+'.'+IP2.Text+'.'+IP3.Text+'.'+IP4.Text);
    if (IP1.Text='')or (IP2.Text='')or (IP3.Text='') or (IP4.Text='') then
  begin
    edQuery.Text:='IP��ַ����Ϊ��';
    exit;
  end;
    state := POS_Open(PChar(ipConst),0,0,0,0,$15);
  end
  else if i_portIndex =2  then  //���ڲ����˴�ֻ�о��������ڸ�����Ҫ�������
  begin
     case cbLPT.ItemIndex of
       0:  portName:='LPT1';
       1:  portName:='LPT2';
     end;
    state := POS_Open(portName,0, 0,0,0,$12);
  end
  else if i_portIndex = 3 then  //���������ֶ��������Ѱ�װ�Ĵ�ӡ������
  begin
  if edDrive.Text='' then
  begin
    edQuery.text:='��������������Ϊ�գ�';
    exit;
  end;
    i_DriverData:=PAnsiChar(edDrive.Text);
  //state := POS_Open('BTP-2002CP(S)',0,0,0,0,$14); //��ʱĬ�ϲ�����һ����ӡ������
    state := POS_Open(i_DriverData,0,0,0,0,$14);    //����������������Ѿ����ڵĴ�ӡ��
  end
  else
  begin
    state := POS_Open('BYUSB-0', 0, 0, 0, 0, $13);  //USB�ӿڲ���
  end;

//�ж϶˿��Ƿ��--------------------------------------------------------------
   if state <> -1 then
    begin
      Print.Enabled := true;
      edQuery.Text := '�˿ڴ򿪳ɹ���';
      OpenPort.Enabled:=False;
      ClosePort.Enabled:=True;
      if i_portIndex =2 then
      begin
         Aboutinquire.Enabled:=False;
      end;
      if i_portIndex <>2 then
      begin
        Aboutinquire.Enabled:=true;
      end;
      Print.Enabled:=True;
      ClosePort.Enabled:=True;
    end
    else
     begin
      Print.Enabled := true;
      edQuery.Text := '�˿ڴ�ʧ�ܣ�';
      Aboutinquire.Enabled:=False;
      Print.Enabled:=False;
      ClosePort.Enabled:=False;
    end;
//�ж϶˿��Ƿ��--------------------------------------------------------------

end;
//����ѡ��Ĳ�ͬ����ʾ���棬���ݶ˿�ѡ��Ĳ�ͬ����ʾ������Ϣ--------------------
procedure TMainForm.PortChoiceClick(Sender: TObject);
begin
  if  state  > 0 then
  begin
    POS_Close();
    state := 0;
    OpenPort.Enabled:=true;
    ClosePort.Enabled:=False;
    Print.Enabled:=False;
    Aboutinquire.Enabled:=False;
  end;
  i_portIndex :=  PortChoice.ItemIndex;
  if i_portIndex = 0 then
  begin
    cbLPT.Enabled:=False;
    edDrive.Enabled:=False;
    IP1.Enabled:=False;
    IP2.Enabled:=False;
    IP3.Enabled:=False;
    IP4.Enabled:=False;
    cbPortName.Enabled:=true;
    cbData.Enabled:=true;
    cbBaud.Enabled:=True;
    cbStop.Enabled:=true;
    cbParity.Enabled:=true;
    cbFlow.Enabled:=True;
    edQuery.Text:='�˿�ѡ��Ϊ����';
    //����Ʒ����������Ϊ��
    // �������˿ڲ�����Ϊ������
  end
  else if i_portIndex = 1 then
  begin
    cbLPT.Enabled:=False;
    edDrive.Enabled:=False;
    IP1.Enabled:=true;
    IP2.Enabled:=true;
    IP3.Enabled:=true;
    IP4.Enabled:=true;
    cbPortName.Enabled:=False;
    cbData.Enabled:=False;
    cbBaud.Enabled:=False;
    cbStop.Enabled:=False;
    cbParity.Enabled:=False;
    cbFlow.Enabled:=False;
   edQuery.Text:='�˿�ѡ��Ϊ����ӿ�';
  end
  else if i_portIndex =2  then
  begin
    edQuery.Text:='�˿�ѡ��Ϊ����';
    cbLPT.Enabled:=True;
    edDrive.Enabled:=False;
    IP1.Enabled:=False;
    IP2.Enabled:=False;
    IP3.Enabled:=False;
    IP4.Enabled:=False;
    cbPortName.Enabled:=False;
    cbData.Enabled:=False;
    cbBaud.Enabled:=False;
    cbStop.Enabled:=False;
    cbParity.Enabled:=False;
    cbFlow.Enabled:=False;
  end
  else if i_portIndex = 3 then
  begin
    edQuery.Text:='�˿�ѡ��Ϊ��������';
    cbLPT.Enabled:=False;
    edDrive.Enabled:=True;
    IP1.Enabled:=False;
    IP2.Enabled:=False;
    IP3.Enabled:=False;
    IP4.Enabled:=False;
    cbPortName.Enabled:=False;
    cbData.Enabled:=False;
    cbBaud.Enabled:=False;
    cbStop.Enabled:=False;
    cbParity.Enabled:=False;
    cbFlow.Enabled:=False;
  end
  else
  begin
    edQuery.Text:='�˿�ѡ��ΪUSB��';
    cbLPT.Enabled:=False;
    edDrive.Enabled:=False;
    IP1.Enabled:=False;
    IP2.Enabled:=False;
    IP3.Enabled:=False;
    IP4.Enabled:=False;
    cbPortName.Enabled:=False;
    cbData.Enabled:=False;
    cbBaud.Enabled:=False;
    cbStop.Enabled:=False;
    cbParity.Enabled:=False;
    cbFlow.Enabled:=False;
  end;
end;
//����ѡ��Ĳ�ͬ����ʾ���棬���ݶ˿�ѡ��Ĳ�ͬ����ʾ������Ϣ--------------------
//******************************************************************************
//��ӡ�ľ������----------------------------------------------------------------
procedure TMainForm.PrintClick(Sender: TObject);
var
    printwidth: integer;
    printtype :integer;
    //�����еı���----------------------------
    {DocInfo:DOC_INFO_1;
    hport : Thandle;
    i: Integer;
    buf : array[1..50] of char;
    dwBytesWritten :DWORD;     }
    //�����еı���-----------------------------
begin
    if ChkWrite.Checked  then
      begin
       POS_BeginSaveFile(PAnsiChar(ExtractFilePath(paramstr(0))+'Test.txt'),false);
      end;
    printtype := ModeSelect.ItemIndex;
    printwidth := pagewide.ItemIndex;
    if i_portIndex =  3 then
      begin
        POS_StartDoc();
      end;
    if printtype = 0 then
      begin
        if printwidth = 0 then
          PrintInStandardMode80()
        else   PrintInStandardMode56();
      end
    else
    begin
      if printwidth = 0 then
         PrintInPageMode80()
      else
         PrintInPageMode56();
    end;
   if i_portIndex=3 then
      begin
         if POS_EndDoc()=true then
          begin
            edQuery.Text:='��ӡ�ɹ���';
          end;
   {if ChkWrite.Checked  then
      begin
        POS_EndSaveFile();
      end;    }
  end;
	 { DocInfo.pDocName := 'My Document';
    DocInfo.pOutputFile := nil;
    DocInfo.pDatatype := 'RAW';
    OpenPrinter('BTP-2002CP(S)',hport,Nil);
    StartDocPrinter(hPort, 1, @DocInfo);
    for i := 1 to 50 do
    begin
      buf[i] := #$32;
    end;
    buf[50] := #$0a;
    dwBytesWritten := 0;
    WritePrinter(hPort,@buf,50,dwBytesWritten);
    EndDocPrinter(hPort);
   end; } //�˴�Ϊͨ���·�ָ�������ӡ��ͨ��������ӡ�����������

end;

end.
//��ӡ�ľ������----------------------------------------------------------------
