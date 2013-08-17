unit main;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, StrUtils,shellAPI;

type
  TMainForm = class(TForm)
    GroupBox1: TGroupBox;
    GroupBox2: TGroupBox;
    Label2: TLabel;
    Label3: TLabel;
    IPList: TComboBox;
    IPEdit1: TEdit;
    IPEdit2: TEdit;
    IPEdit3: TEdit;
    IPEdit4: TEdit;
    PrintDemo: TButton;
    PrinterStatus: TButton;
    ExitButton: TButton;
    SetIP: TRadioButton;
    AutoGetIP: TRadioButton;
    procedure SetIPClick(Sender: TObject);
    procedure AutoGetIPMouseDown(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer);
    procedure ExitButtonClick(Sender: TObject);
    procedure PrintDemoClick(Sender: TObject);
    procedure IPListChange(Sender: TObject);
    procedure PrinterStatusClick(Sender: TObject); 
    procedure FormKeyDown(Sender: TObject; var Key: Word;
      Shift: TShiftState);

  private
    { Private declarations }
  public
    { Public declarations }
  end;
//BYNetPortAPI DLL function adduction
function NetWriteOpen(ipaddr:string;connecttime:integer):boolean;stdcall;external 'BYNetPortAPI.dll';
function NetWrite(databuf:pchar;length:integer;writetime:integer):integer;stdcall;external 'BYNetPortAPI.dll';
function NetWriteClose():boolean;stdcall;external 'BYNetPortAPI.dll';
function NetGetPrinterIP(ip:pchar):integer;stdcall;external 'BYNetPortAPI.dll';
function HtmlHelpA (hwndcaller:Longint; lpHelpFile:string; wCommand:Longint;dwData:string): HWND;stdcall; external 'hhctrl.ocx'

var
  MainForm: TMainForm;
  getipmode:integer;
  ipstr:string;
  ipliststr:string;

function DelBlank(Str: String):String;    //delet blank
function DelZero (srcstr:string):string; //delet '0'

implementation

uses status;
{$R *.dfm}


function DelBlank(Str: String):String;    //delet blank
var
  i: Integer;
  ReturnStr: String;
begin
  for i := 1 to Length(Str) do begin
    if Copy(Str,i,1) <> ' ' then ReturnStr := ReturnStr +Copy(Str,i,1);
  end;
  Result := ReturnStr;
end;


function DelZero (srcstr:string):string; //delet '0'
var
    i:integer;
    ReturnStr:string;
Begin
    for i := 1 To Length(srcstr) Do Begin
        if Copy(srcstr, i, 1) <> '0' then
            break;
    End;
    if i = Length(srcStr) + 1 then         
    begin
        ReturnStr := '0';
    End
    Else
    Begin
        ReturnStr := MidStr(srcstr, i, Length(srcstr) - i + 1);
    End;
    Result := ReturnStr;
End;


procedure TMainForm.SetIPClick(Sender: TObject);
begin
  getipmode := 0;
  SetIP.Checked := true;
  AutoGetIP.Checked := false;
  ipedit1.Enabled := true;
  ipedit2.Enabled := true;
  ipedit3.Enabled := true;
  ipedit4.Enabled := true;
  iplist.Enabled := false; 
end;

procedure TMainForm.AutoGetIPMouseDown(Sender: TObject; Button: TMouseButton;
  Shift: TShiftState; X, Y: Integer);
var
  ip:pchar;
  number:integer;
  ipdata:string;
  len:integer;
  n:integer;
  i:integer;
  str:string;
  p:integer;
  q:integer;
  ipaddress:array[0..255] of string;
  w:integer;
  sameip:string;
begin
  Screen.Cursor := crHourGlass;
  getipmode := 1;
  setip.Checked := false;
  autogetip.Checked := true;
  iplist.Enabled := true;
  ipedit1.Enabled := false;
  ipedit2.Enabled := false;
  ipedit3.Enabled := false;
  ipedit4.Enabled := false;
  iplist.Clear();

  getmem(ip,1024);

  number := NetGetPrinterIP(ip);  //Auto get printer ip address

  if number < 0 then
    begin
    showmessage('Get ip address error!');
    FreeMem(ip);
    Screen.Cursor := crArrow;
    IPList.Clear();
    IPList.Items.Add('<NULL>');
    IPList.ItemIndex := 0;
    exit;
    end;

  if number = 0 then
    begin
    showmessage('Can not find printer!');
    FreeMem(ip);
    Screen.Cursor := crArrow;
    IPList.Clear();
    IPList.Items.Add('<NULL>');
    IPList.ItemIndex := 0;
    exit;
    end;

  if number > 0 then
    begin
    ipdata := string(ip);
    len := length(ipdata);
    n := 1;  

    // parse ip address data
    for i := 1 to len do     
      begin
      if ip[i] = '@' then
        begin
        str := midstr(ipdata,n,i-n+1);
        IPList.Items.Add(str);
        n := i + 2;
        end;
      end;

    for p := 0 to number do
      begin
      ipaddress[p] := IPList.Items.Strings[p];
      end;

    for q := 0 to number do
      begin
      for w := q+1 to number do
        begin
        if ipaddress[q] = ipaddress[w] then
          begin
          sameip :=  'IP address exist conflict!' + string(ipaddress[q]);
          showmessage(sameip);
          IPList.Clear();   //Clear ip list
          IPList.Items.Add('<NULL>');
          IPList.ItemIndex := 0;
          ipliststr := IPList.Text;
          Screen.Cursor := crArrow;
          FreeMem(ip);
          exit;
          end;
        end;
      end;
    end;
  IPList.ItemIndex := 0;
  ipliststr := IPList.Text;
  Screen.Cursor := crArrow;
  FreeMem(ip);
end;

procedure TMainForm.ExitButtonClick(Sender: TObject);
begin
  close();
end;

//Printing demo
procedure TMainForm.PrintDemoClick(Sender: TObject);
var
  ipdata1:integer;
  ipdata2:integer;
  ipdata3:integer;
  ipdata4:integer;
  ipaddr:string;
  backcode:boolean;  //return code define
  backnum:integer;   
  databuf:array[0..255] of char;
  buf:array[0..255] of byte;
begin
  if getipmode = 0 then
    begin
    ipdata1 := strtoint(DelZero(DelBlank(IPEdit1.Text)));
    ipdata2 := strtoint(DelZero(DelBlank(IPEdit2.Text)));
    ipdata3 := strtoint(DelZero(DelBlank(IPEdit3.Text)));
    ipdata4 := strtoint(DelZero(DelBlank(IPEdit4.Text)));

    if (ipdata1 < 0) or (ipdata1 > 255) then
      begin
      showmessage('IP address is illogical!');
      exit;
      end;

    if (ipdata2 < 0) or (ipdata2 > 255) then
      begin
      showmessage('IP address is illogical!');
      exit;
      end;

    if (ipdata3 < 0) or (ipdata3 > 255) then
      begin
      showmessage('IP address is illogical!');
      exit;
      end;

    if (ipdata4 < 0) or (ipdata4 > 255) then
      begin
      showmessage('IP address is illogical!');
      exit;
      end;

    ipstr := DelZero(DelBlank(ipedit1.Text)) + '.' +  DelZero(DelBlank(ipedit2.Text)) + '.' + DelZero(DelBlank(ipedit3.Text)) + '.' + DelZero(DelBlank(ipedit4.Text));
    if ipstr = '0.0.0.0' then
      begin
      showmessage('IP address is null!');
      Screen.Cursor:=crArrow; //set the cursor shape
      exit;
      end; 
    ipaddr := ipstr;
    end;

  if getipmode = 1 then
    begin
    if ipliststr = '0.0.0.0' then
      begin
      showmessage('IP address is null!');
      exit;
      end;

    if ipliststr = '<NULL>' then
      begin
      showmessage('IP address is null!');
      exit;
      end;
    ipaddr := ipliststr;
    end;

  backcode := NetWriteOpen(ipaddr,3);  //Open write port
  if backcode = false then
    begin
    showmessage('Open write port error!');
    exit;
    end;

  databuf := 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz';
  backnum := NetWrite(databuf,length(databuf),5);    //write data to write port
  if backnum < 0 then
    begin
    showmessage('Write data error!');
    exit;
    end;

  buf[0] := $0a;
  backnum := NetWrite(@buf,1,2);  
  if backnum < 0 then
    begin
    showmessage('Write data error!');
    exit;
    end;

  backcode := NetWriteClose();  //Close write port
  if backcode = false then
    begin
    showmessage('Close write port error!');
    exit;
    end;
end;
 
procedure TMainForm.IPListChange(Sender: TObject);
begin
  ipliststr := IPList.Text;
end;

procedure TMainForm.PrinterStatusClick(Sender: TObject);
var
  ipdata1:integer;
  ipdata2:integer;
  ipdata3:integer;
  ipdata4:integer;
begin
  if getipmode = 0 then
    begin
    ipdata1 := strtoint(DelZero(DelBlank(IPEdit1.Text)));
    ipdata2 := strtoint(DelZero(DelBlank(IPEdit2.Text)));
    ipdata3 := strtoint(DelZero(DelBlank(IPEdit3.Text)));
    ipdata4 := strtoint(DelZero(DelBlank(IPEdit4.Text)));

    if (ipdata1 < 0) or (ipdata1 > 255) then
      begin
      showmessage('IP address is illogical!');
      exit;
      end;

    if (ipdata2 < 0) or (ipdata2 > 255) then
      begin
      showmessage('IP address is illogical!');
      exit;
      end;

    if (ipdata3 < 0) or (ipdata3 > 255) then
      begin
      showmessage('IP address is illogical!');
      exit;
      end;

    if (ipdata4 < 0) or (ipdata4 > 255) then
      begin
      showmessage('IP address is illogical!');
      exit;
      end;

    ipstr := DelZero(DelBlank(ipedit1.Text)) + '.' +  DelZero(DelBlank(ipedit2.Text)) + '.' + DelZero(DelBlank(ipedit3.Text)) + '.' + DelZero(DelBlank(ipedit4.Text));
    if ipstr = '0.0.0.0' then
      begin
      showmessage('IP address is null!');
      Screen.Cursor:=crArrow; //set the cursor shape
      exit;
      end;
    status.ipaddress := ipstr;
    end;
    
  if getipmode = 1 then
    begin
    if ipliststr = '0.0.0.0' then
      begin
      showmessage('IP address is null!');
      exit;
      end;

    if ipliststr = '<NULL>' then
      begin
      showmessage('IP address is null!');
      exit;
      end;
    status.ipaddress  := ipliststr;
    end;

  StatusForm := TStatusForm.Create(Self);
  StatusForm.ShowModal; //show status windows
  StatusForm.Free;
end; 

procedure TMainForm.FormKeyDown(Sender: TObject; var Key: Word;
  Shift: TShiftState);
var
  fpath:string;
begin
  if Key = VK_F1 then
  begin
    fpath:=ExtractFilePath(ParamStr(0))+'NetPrnStatusDemo Guide.chm';
    ShellExecute(handle,nil,pchar(fpath),nil,nil,sw_shownormal);
  end;
end;

end.
