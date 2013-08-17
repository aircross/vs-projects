; CLW file contains information for the MFC ClassWizard

[General Info]
Version=1
LastClass=CTestUSBView
LastTemplate=CDialog
NewFileInclude1=#include "stdafx.h"
NewFileInclude2=#include "TestUSB.h"
LastPage=0

ClassCount=7
Class1=CTestUSBApp
Class2=CTestUSBDoc
Class3=CTestUSBView
Class4=CMainFrame

ResourceCount=6
Resource1=IDD_ABOUTBOX
Resource2=IDR_MAINFRAME
Class5=CAboutDlg
Resource3=IDD_TimeOut (English (U.S.))
Resource4=IDR_MAINFRAME (English (U.S.))
Class6=CInputBox
Resource5=IDD_ABOUTBOX (English (U.S.))
Class7=CDlgID
Resource6=IDD_ID (English (U.S.))

[CLS:CTestUSBApp]
Type=0
HeaderFile=TestUSB.h
ImplementationFile=TestUSB.cpp
Filter=N

[CLS:CTestUSBDoc]
Type=0
HeaderFile=TestUSBDoc.h
ImplementationFile=TestUSBDoc.cpp
Filter=N

[CLS:CTestUSBView]
Type=0
HeaderFile=TestUSBView.h
ImplementationFile=TestUSBView.cpp
Filter=C
BaseClass=CView
VirtualFilter=VWC
LastObject=ID_GET_DRIVER_VERSION


[CLS:CMainFrame]
Type=0
HeaderFile=MainFrm.h
ImplementationFile=MainFrm.cpp
Filter=T
LastObject=CMainFrame
BaseClass=CFrameWnd
VirtualFilter=fWC




[CLS:CAboutDlg]
Type=0
HeaderFile=TestUSB.cpp
ImplementationFile=TestUSB.cpp
Filter=D

[DLG:IDD_ABOUTBOX]
Type=1
ControlCount=4
Control1=IDC_STATIC,static,1342177283
Control2=IDC_STATIC,static,1342308352
Control3=IDC_STATIC,static,1342308352
Control4=IDOK,button,1342373889
Class=CAboutDlg

[MNU:IDR_MAINFRAME]
Type=1
Class=CMainFrame
Command3=ID_FILE_SAVE
Command4=ID_FILE_SAVE_AS
Command5=ID_FILE_MRU_FILE1
Command6=ID_APP_EXIT
Command10=ID_EDIT_PASTE
Command11=ID_VIEW_TOOLBAR
Command12=ID_VIEW_STATUS_BAR
Command13=ID_APP_ABOUT
CommandCount=13
Command1=ID_FILE_NEW
Command2=ID_FILE_OPEN
Command7=ID_EDIT_UNDO
Command8=ID_EDIT_CUT
Command9=ID_EDIT_COPY

[ACL:IDR_MAINFRAME]
Type=1
Class=CMainFrame
Command1=ID_FILE_NEW
Command2=ID_FILE_OPEN
Command3=ID_FILE_SAVE
Command5=ID_EDIT_CUT
Command6=ID_EDIT_COPY
Command7=ID_EDIT_PASTE
Command8=ID_EDIT_UNDO
Command9=ID_EDIT_CUT
Command10=ID_EDIT_COPY
Command11=ID_EDIT_PASTE
Command12=ID_NEXT_PANE
CommandCount=13
Command4=ID_EDIT_UNDO
Command13=ID_PREV_PANE


[MNU:IDR_MAINFRAME (English (U.S.))]
Type=1
Class=CMainFrame
Command1=ID_FILE_NEW
Command2=ID_FILE_OPEN
Command3=ID_FILE_SAVE
Command4=ID_FILE_SAVE_AS
Command5=ID_FILE_MRU_FILE1
Command6=ID_APP_EXIT
Command7=ID_EDIT_UNDO
Command8=ID_EDIT_CUT
Command9=ID_EDIT_COPY
Command10=ID_EDIT_PASTE
Command11=ID_VIEW_TOOLBAR
Command12=ID_VIEW_STATUS_BAR
Command13=ID_OPEN_DEVICE
Command14=ID_OPEN_BYINTERNALID
Command15=ID_OPENDEVICE_BYNAME
Command16=ID_OPENDEVICE_BYNAME2
Command17=ID_CLOSE_DEVICE
Command18=ID_AUTOSTATUS_RETURN
Command19=ID_CTRL_READ
Command20=ID_BULK_WRITE
Command21=ID_WRITE_SCOMMAND
Command22=ID_BULK_READ
Command23=ID_ABORT_RPIPE
Command24=ID_ABORT_WPIPE
Command25=ID_CLEAR_ERROR
Command26=ID_RESET_COMMAND
Command27=ID_SET_TIMEOUTS
Command28=ID_GET_DLLVERSION
Command29=ID_GET_DRIVER_VERSION
Command30=ID_APP_ABOUT
CommandCount=30

[TB:IDR_MAINFRAME (English (U.S.))]
Type=1
Class=?
Command1=ID_FILE_NEW
Command2=ID_FILE_OPEN
Command3=ID_FILE_SAVE
Command4=ID_EDIT_CUT
Command5=ID_EDIT_COPY
Command6=ID_EDIT_PASTE
Command7=ID_FILE_PRINT
Command8=ID_APP_ABOUT
CommandCount=8

[ACL:IDR_MAINFRAME (English (U.S.))]
Type=1
Class=?
Command1=ID_FILE_NEW
Command2=ID_FILE_OPEN
Command3=ID_FILE_SAVE
Command4=ID_EDIT_UNDO
Command5=ID_EDIT_CUT
Command6=ID_EDIT_COPY
Command7=ID_EDIT_PASTE
Command8=ID_EDIT_UNDO
Command9=ID_EDIT_CUT
Command10=ID_EDIT_COPY
Command11=ID_EDIT_PASTE
Command12=ID_NEXT_PANE
Command13=ID_PREV_PANE
CommandCount=13

[DLG:IDD_ABOUTBOX (English (U.S.))]
Type=1
Class=CAboutDlg
ControlCount=4
Control1=IDC_STATIC,static,1342177283
Control2=IDC_STATIC,static,1342308480
Control3=IDC_STATIC,static,1342308352
Control4=IDOK,button,1342373889

[CLS:CInputBox]
Type=0
HeaderFile=InputBox.h
ImplementationFile=InputBox.cpp
BaseClass=CDialog
Filter=D
VirtualFilter=dWC
LastObject=IDC_EDIT1

[CLS:CDlgID]
Type=0
HeaderFile=DlgID.h
ImplementationFile=DlgID.cpp
BaseClass=CDialog
Filter=D
VirtualFilter=dWC
LastObject=CDlgID

[DLG:IDD_ID (English (U.S.))]
Type=1
Class=CDlgID
ControlCount=4
Control1=IDOK,button,1342242817
Control2=IDCANCEL,button,1342242816
Control3=IDC_EDIT1,edit,1350631552
Control4=IDC_STATIC,static,1342308352

[DLG:IDD_TimeOut (English (U.S.))]
Type=1
Class=CInputBox
ControlCount=6
Control1=IDOK,button,1342242817
Control2=IDCANCEL,button,1342242816
Control3=IDC_EDIT1,edit,1350631552
Control4=IDC_STATIC,static,1342308352
Control5=IDC_EDIT2,edit,1350631552
Control6=IDC_STATIC,static,1342308352

