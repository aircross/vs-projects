program NetPrnStatusDemo_delphi;

uses
  Forms,
  main in 'main.pas' {MainForm},
  status in 'status.pas' {StatusForm};

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TMainForm, MainForm);
  Application.CreateForm(TStatusForm, StatusForm);
  Application.Run;
end.
