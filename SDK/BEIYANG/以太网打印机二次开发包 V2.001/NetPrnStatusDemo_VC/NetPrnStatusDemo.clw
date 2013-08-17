; CLW file contains information for the MFC ClassWizard

[General Info]
Version=1
LastClass=CNetPrnStatusDemoDlg
LastTemplate=CDialog
NewFileInclude1=#include "stdafx.h"
NewFileInclude2=#include "NetPrnStatusDemo.h"

ClassCount=4
Class1=CNetPrnStatusDemoApp
Class2=CNetPrnStatusDemoDlg
Class3=CAboutDlg

ResourceCount=6
Resource1=IDD_ABOUTBOX
Resource2=IDR_MAINFRAME
Resource3=IDD_NETPRNSTATUSDEMO_DIALOG
Resource4=IDD_ABOUTBOX (English (U.S.))
Resource5=IDD_MONITOR
Class4=CSTATUS
Resource6=IDD_NETPRNSTATUSDEMO_DIALOG (English (U.S.))

[CLS:CNetPrnStatusDemoApp]
Type=0
HeaderFile=NetPrnStatusDemo.h
ImplementationFile=NetPrnStatusDemo.cpp
Filter=N

[CLS:CNetPrnStatusDemoDlg]
Type=0
HeaderFile=NetPrnStatusDemoDlg.h
ImplementationFile=NetPrnStatusDemoDlg.cpp
Filter=D
BaseClass=CDialog
VirtualFilter=dWC
LastObject=IDC_Info

[CLS:CAboutDlg]
Type=0
HeaderFile=NetPrnStatusDemoDlg.h
ImplementationFile=NetPrnStatusDemoDlg.cpp
Filter=D

[DLG:IDD_ABOUTBOX]
Type=1
ControlCount=4
Control1=IDC_STATIC,static,1342177283
Control2=IDC_STATIC,static,1342308352
Control3=IDC_STATIC,static,1342308352
Control4=IDOK,button,1342373889
Class=CAboutDlg


[DLG:IDD_NETPRNSTATUSDEMO_DIALOG]
Type=1
ControlCount=3
Control1=IDOK,button,1342242817
Control2=IDCANCEL,button,1342242816
Control3=IDC_STATIC,static,1342308352
Class=CNetPrnStatusDemoDlg

[DLG:IDD_NETPRNSTATUSDEMO_DIALOG (English (U.S.))]
Type=1
Class=CNetPrnStatusDemoDlg
ControlCount=11
Control1=IDC_STATUS,button,1342373888
Control2=IDC_STATIC,button,1342177287
Control3=IDC_IPADDRESS1,SysIPAddress32,1342242816
Control4=IDC_PRINT,button,1342373888
Control5=IDC_STATIC,static,1342308352
Control6=IDC_BUTTON4,button,1342242816
Control7=IDC_STATIC,button,1476395015
Control8=IDC_STATIC,static,1342308352
Control9=IDC_COMBO2,combobox,1344340227
Control10=IDC_RADIO1,button,1342308361
Control11=IDC_RADIO2,button,1342177289

[DLG:IDD_ABOUTBOX (English (U.S.))]
Type=1
Class=CAboutDlg
ControlCount=4
Control1=IDC_STATIC,static,1342177283
Control2=IDC_STATIC,static,1342308480
Control3=IDC_STATIC,static,1342308352
Control4=IDOK,button,1342373889

[DLG:IDD_MONITOR]
Type=1
Class=CSTATUS
ControlCount=14
Control1=IDC_START,button,1342242816
Control2=IDCANCEL,button,1342242816
Control3=IDC_STATIC,button,1342177287
Control4=IDC_PAPEREND,button,1342242816
Control5=IDC_PAPERNAREEND,button,1342242816
Control6=IDC_COVER,button,1342242816
Control7=IDC_CUT,button,1342242816
Control8=IDC_AUTO,button,1342242816
Control9=IDC_CASHDRAWER,button,1342242816
Control10=IDC_FEED,button,1342242816
Control11=IDC_PRNBUSY,button,1342242816
Control12=IDC_RESTOR,button,1342242816
Control13=IDC_STOP,button,1342242816
Control14=IDC_OFFLINE,button,1342242816

[CLS:CSTATUS]
Type=0
HeaderFile=STATUS.h
ImplementationFile=STATUS.cpp
BaseClass=CDialog
Filter=D
VirtualFilter=dWC
LastObject=CSTATUS

