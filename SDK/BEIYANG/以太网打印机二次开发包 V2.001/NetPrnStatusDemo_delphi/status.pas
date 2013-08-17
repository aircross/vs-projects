unit status;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Buttons, ExtCtrls,shellapi;

type
  TStatusForm = class(TForm)
    BitBtn1: TBitBtn;
    Label1: TLabel;
    BitBtn2: TBitBtn;
    BitBtn3: TBitBtn;
    BitBtn4: TBitBtn;
    BitBtn5: TBitBtn;
    BitBtn6: TBitBtn;
    BitBtn7: TBitBtn;
    BitBtn8: TBitBtn;
    BitBtn9: TBitBtn;
    StartMonitor: TButton;
    StopMonitor: TButton;
    Button3: TButton;
    GroupBox1: TGroupBox;
    Timer1: TTimer;
    BitBtn10: TBitBtn;
    BitBtn11: TBitBtn;
    BitBtn12: TBitBtn;
    BitBtn13: TBitBtn;
    procedure StartMonitorClick(Sender: TObject);
    procedure StopMonitorClick(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure Timer1Timer(Sender: TObject);
    procedure FormKeyDown(Sender: TObject; var Key: Word;
      Shift: TShiftState);
  private
    { Private declarations }
  public
    { Public declarations }
  end;
function  NetGetStatus(ipaddr:string;tobuf:pchar;length:integer;connecttime:integer;readtime:integer):integer;stdcall;external 'BYNetPortAPI.dll';
var
  StatusForm: TStatusForm;
  ipaddress:string;
  len:integer;
  paperend:boolean;
  papernearend:boolean;
  coveropen:boolean;
  cuterror:boolean;
  cashdraweropen:boolean;
  printeroff:boolean;
  runfeed:boolean;
  restorable:boolean;
  autoerror:boolean;


implementation

uses main;

{$R *.dfm}

procedure TStatusForm.StartMonitorClick(Sender: TObject);
var
  buf:array[0..3] of byte;
  str1:string;
  str2:string;
  str3:string;
  str4:string;
  str:string;
begin
  Screen.Cursor:=crHourGlass; //set the cursor shape

  len := NetGetStatus(ipaddress,@buf,4,3,3);//read printer status
  if len < 0 then
    begin
    Screen.Cursor:=crArrow;

    BitBtn1.Glyph := BitBtn12.Glyph;
    BitBtn2.Glyph := BitBtn12.Glyph;
    BitBtn3.Glyph := BitBtn12.Glyph;
    BitBtn4.Glyph := BitBtn12.Glyph;
    BitBtn5.Glyph := BitBtn12.Glyph;
    BitBtn6.Glyph := BitBtn12.Glyph;
    BitBtn7.Glyph := BitBtn12.Glyph;
    BitBtn8.Glyph := BitBtn12.Glyph;
    BitBtn9.Glyph := BitBtn12.Glyph;
    BitBtn10.Glyph := BitBtn11.Glyph;
    exit;
    end;

  str1 := inttostr(buf[0]);
  str2 := inttostr(buf[1]);
  str3 := inttostr(buf[2]);
  str4 := inttostr(buf[3]);

  str := str1 + str2 + str3 + str4;

  Screen.Cursor:=crArrow;
  StartMonitor.Enabled := false;
  StopMonitor.Enabled := true;

  BitBtn1.Glyph := BitBtn13.Glyph;
  BitBtn2.Glyph := BitBtn13.Glyph;
  BitBtn3.Glyph := BitBtn13.Glyph;
  BitBtn4.Glyph := BitBtn13.Glyph;
  BitBtn5.Glyph := BitBtn13.Glyph;
  BitBtn6.Glyph := BitBtn13.Glyph;
  BitBtn7.Glyph := BitBtn13.Glyph;
  BitBtn8.Glyph := BitBtn13.Glyph;
  BitBtn9.Glyph := BitBtn13.Glyph;
  BitBtn10.Glyph := BitBtn13.Glyph;
                           
  paperend := true;
  papernearend := true;
  coveropen := true;
  cuterror := true;
  cashdraweropen := true;
  printeroff := true;
  runfeed := true;
  restorable := true;
  autoerror := true;
  Timer1.Enabled := true;  //start timer even
end;

procedure TStatusForm.StopMonitorClick(Sender: TObject);
begin
  StopMonitor.Enabled := false;
  StartMonitor.Enabled := true;

  BitBtn1.Glyph := BitBtn12.Glyph;
  BitBtn2.Glyph := BitBtn12.Glyph;
  BitBtn3.Glyph := BitBtn12.Glyph;
  BitBtn4.Glyph := BitBtn12.Glyph;
  BitBtn5.Glyph := BitBtn12.Glyph;
  BitBtn6.Glyph := BitBtn12.Glyph;
  BitBtn7.Glyph := BitBtn12.Glyph;
  BitBtn8.Glyph := BitBtn12.Glyph;
  BitBtn9.Glyph := BitBtn12.Glyph;
  BitBtn10.Glyph := BitBtn12.Glyph;
  timer1.Enabled := false;  //close timer even
end;

procedure TStatusForm.Button3Click(Sender: TObject);
begin
  Close;
  timer1.Enabled := false;
end;

procedure TStatusForm.Timer1Timer(Sender: TObject);
var
  buf:array[0..3] of byte;
  IsSingularity:byte;
  IsPaperEnd:byte;
  IsPaperNearEnd:byte;
  IsCoverOpen:byte;
  IsCashdrawerOpen:byte;
  IsCuterError:byte;
  PrinterBusy:byte;
  RunFeedKey:byte;
  ExistRestoreError:byte;
  ExistAutoRestoreError:byte;
  str1:string;
  str2:string;
  str3:string;
  str4:string;
  str:string;
begin
  //read printer status
  len := NetGetStatus(ipaddress,@buf,4,3,2);
  if len < 0 then
    begin  
    len := NetGetStatus(ipaddress,@buf,4,3,2);
    if len < 0 then
      begin
      len := NetGetStatus(ipaddress,@buf,4,3,2);
      if len < 0 then
        begin
          len := NetGetStatus(ipaddress,@buf,4,3,2);
          if len < 0 then
            begin
              len := NetGetStatus(ipaddress,@buf,4,3,2);
              if len < 0 then
                begin
                  timer1.Enabled := false;

                  BitBtn1.Glyph := BitBtn12.Glyph;
                  BitBtn2.Glyph := BitBtn12.Glyph;
                  BitBtn3.Glyph := BitBtn12.Glyph;
                  BitBtn4.Glyph := BitBtn12.Glyph;
                  BitBtn5.Glyph := BitBtn12.Glyph;
                  BitBtn6.Glyph := BitBtn12.Glyph;
                  BitBtn7.Glyph := BitBtn12.Glyph;
                  BitBtn8.Glyph := BitBtn12.Glyph;
                  BitBtn9.Glyph := BitBtn12.Glyph;
                  BitBtn10.Glyph := BitBtn11.Glyph;

                  StopMonitor.Enabled := false;
                  StartMonitor.Enabled := true;
                  exit;
                end;
            end;
        end;
      end;
    end;

  if(buf[0] and $10) = $10 then
    begin
    IsSingularity := 0;
    end
  else
    begin
    IsSingularity := 1;
    end;

   if(buf[2] and $0C) = $0C then
    begin
    IsPaperEnd := 1;
    end
  else
    begin
    IsPaperEnd := 0;
    end;

   if(buf[2] and $03) = $03 then
    begin
    IsPaperNearEnd := 1;
    end
  else
    begin
    IsPaperNearEnd := 0;
    end;

   if(buf[0] and $20) = $20 then
    begin
    IsCoverOpen := 1;
    end
  else
    begin
    IsCoverOpen := 0;
    end;

  if(buf[0] and $04) = $04 then
    begin
    IsCashdrawerOpen := 0;
    end
  else
    begin
    IsCashdrawerOpen := 1;
    end;

  if(buf[1] and $08) = $08 then
    begin
    IsCuterError := 1;
    end
  else
    begin
    IsCuterError := 0;
    end;

  if(buf[0] and $08) = $08 then
    begin
    PrinterBusy := 1;
    end
  else
    begin
    PrinterBusy := 0;
    end;

  if(buf[0] and $40) = $40 then
    begin
    RunFeedKey := 1;
    end
  else
    begin
    RunFeedKey := 0;
    end;

   if(buf[1] and $20) = $20 then
    begin
    ExistRestoreError := 1;
    end
  else
    begin
    ExistRestoreError := 0;
    end;

  if(buf[1] and $40) = $40 then
    begin
    ExistAutoRestoreError := 1;
    end
  else
    begin
    ExistAutoRestoreError := 0;
    end;
	
  // status is  singularity
  if IsSingularity = 1 then
    begin
    timer1.Enabled := false;

    BitBtn1.Glyph := BitBtn12.Glyph;
    BitBtn2.Glyph := BitBtn12.Glyph;
    BitBtn3.Glyph := BitBtn12.Glyph;
    BitBtn4.Glyph := BitBtn12.Glyph;
    BitBtn5.Glyph := BitBtn12.Glyph;
    BitBtn6.Glyph := BitBtn12.Glyph;
    BitBtn7.Glyph := BitBtn12.Glyph;
    BitBtn8.Glyph := BitBtn12.Glyph;
    BitBtn9.Glyph := BitBtn12.Glyph;
    BitBtn10.Glyph := BitBtn12.Glyph;
    StopMonitor.Enabled := false;
    StartMonitor.Enabled := true;
    showmessage('Printer status is abnormal!');
    exit;
    end;

  //paper is end ?
  if IsPaperEnd = 1 then
    begin
    if  paperend = true then
      begin
      BitBtn1.Glyph := BitBtn11.Glyph;
      paperend := false;
      end;
    end
  else
    begin
    if  paperend = false then
      begin
      BitBtn1.Glyph := BitBtn13.Glyph;
      paperend := true;
      end;
    end;

  // paper is near end?
  if IsPaperNearEnd = 1 then
    begin
    if  papernearend = true then
      begin
      BitBtn4.Glyph := BitBtn11.Glyph;
      papernearend := false;
      end;
    end
  else
    begin
    if  papernearend = false then
      begin
      BitBtn4.Glyph := BitBtn13.Glyph;
      papernearend := true;
      end;
    end;

  //cover is open?
  if IsCoverOpen = 1 then
    begin
    if  coveropen = true then
      begin
      BitBtn2.Glyph := BitBtn11.Glyph;
      coveropen := false;
      end;
    end
  else
    begin
    if  coveropen = false then
      begin
      BitBtn2.Glyph := BitBtn13.Glyph;
      coveropen := true;
      end;
    end;

  //cutter is error?
  if IsCuterError = 1 then
    begin
    if  cuterror = true then
      begin
      BitBtn3.Glyph := BitBtn11.Glyph;
      cuterror := false;
      end;
    end
  else
    begin
    if  cuterror = false then
      begin
      BitBtn3.Glyph := BitBtn13.Glyph;
      cuterror := true;
      end;
    end;

  // auto restorabled error is exist?
  if ExistAutoRestoreError = 1 then
    begin
    if  autoerror = true then
      begin
      BitBtn5.Glyph := BitBtn11.Glyph;
      autoerror := false;
      end;
    end
  else
    begin
    if  autoerror = false then
      begin
      BitBtn5.Glyph := BitBtn13.Glyph;
      autoerror := true;
      end;
    end;

  //cashdrawer is open?
  if IsCashdrawerOpen = 1 then
    begin
    if  cashdraweropen = true then
      begin
      BitBtn6.Glyph := BitBtn11.Glyph;
      cashdraweropen := false;
      end;
    end
  else
    begin
    if  cashdraweropen = false then
      begin
      BitBtn6.Glyph := BitBtn13.Glyph;
      cashdraweropen := true;
      end;
    end;

  // run feed button?
  if RunFeedKey = 1 then
    begin
    if  runfeed = true then
      begin
      BitBtn7.Glyph := BitBtn11.Glyph;
      runfeed := false;
      end;
    end
  else
    begin
    if  runfeed = false then
      begin
      BitBtn7.Glyph := BitBtn13.Glyph;
      runfeed := true;
      end;
    end;

  // printer is off-line?
  if PrinterBusy = 1 then
    begin
    if  printeroff = true then
      begin
      BitBtn8.Glyph := BitBtn11.Glyph;
      printeroff := false;
      end;
    end
  else
    begin
    if  printeroff = false then
      begin
      BitBtn8.Glyph := BitBtn13.Glyph;
      printeroff := true;
      end;
    end;

  //restorabled error is exist?
  if ExistRestoreError = 1 then
    begin
    if  restorable = true then
      begin
      BitBtn9.Glyph := BitBtn11.Glyph;
      restorable := false;
      end;
    end
  else
    begin
    if  restorable = false then
      begin   
      BitBtn9.Glyph := BitBtn13.Glyph;
      restorable := true;
      end;
    end; 
end; 

procedure TStatusForm.FormKeyDown(Sender: TObject; var Key: Word;
  Shift: TShiftState);
var
  fpath:string;
begin
  if Key = VK_F1 then
  begin
    fpath:=ExtractFilePath(ParamStr(0))+'NetPrnStatusDemo Guid.chm';
    ShellExecute(handle,nil,pchar(fpath),nil,nil,sw_shownormal);
  end;
end;
end.
