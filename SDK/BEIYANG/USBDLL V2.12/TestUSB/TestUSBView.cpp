// TestUSBView.cpp : implementation of the CTestUSBView class
//

#include "stdafx.h"
#include "TestUSB.h"

#include "TestUSBDoc.h"
#include "TestUSBView.h"
#include "InputBox.h"
#include "DlgID.h"


#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


// USB DLL export function
typedef  HANDLE (__stdcall *OpenDevice)(void);
typedef  HANDLE (__stdcall *OpenDeviceByName)(char *pDeviceTypeName, char iNumber);

typedef  BOOL   (__stdcall *CloseDevice)(HANDLE hdev);
typedef  int    (__stdcall * uWrite)(HANDLE hdev, int pipeNum, char *buf, UINT bufSize);
typedef  int    (__stdcall * uRead)(HANDLE hdev, int pipeNum, char *buf, UINT bufSize);

typedef  BOOL   (__stdcall *AbortPipes)(HANDLE hdev, int pipe);
typedef  BOOL   (__stdcall *GetDllVersion)(void);
typedef  BOOL	(__stdcall *GetDriverVersion)(HANDLE hdev,char *buffer); //control pipe

typedef  BOOL	(__stdcall *GetSpecStatus)(HANDLE hdev, char *buffer, UINT bufferSize, PULONG nBytes); //control pipe
typedef  BOOL	(__stdcall *SendSpecCommand)(HANDLE hdev, BYTE command);//control pipe

typedef  BOOL	(__stdcall *SetUSBTimeouts)(HANDLE hdev, WORD wReadTimeouts, WORD wWriteTimeouts);
typedef  HANDLE (__stdcall *OpenDeviceByInternalID)(DWORD iID);


// define USB interface pipe
// USB interface pipe of printer£ºwrite pipe 0; read pipe 1¡£
#define  WRITE_PIPENUM	0
#define  READ_PIPENUM	1

// define USB printer status
//#define PAPER_NEAROUT			0
//#define PRINTERHEADER_OPEN		2
//#define PAPER_END				4
//#define PRINTERCUT_ERROR		8

// define specific command for USB device: Reset,clear
// Only valid for KIOSK series printers.
#define RESET_USB_DEVICE 192 // 0xC0
#define CLEAR_USB_ERROR  193 // 0xC1

HANDLE hdev; // device handle
HINSTANCE hlib; // dll handle
CString str; // show information text

// declare read and write function here
// it will be called by thread and main process
uRead f_uRead = NULL;
uWrite f_uWrite = NULL;

char buf[1024 * 64  + 200];
CInputBox dlg_Inputbox;
CDlgID dlg_id;

/////////////////////////////////////////////////////////////////////////////


// CTestUSBView

IMPLEMENT_DYNCREATE(CTestUSBView, CView)

BEGIN_MESSAGE_MAP(CTestUSBView, CView)
	//{{AFX_MSG_MAP(CTestUSBView)
	ON_COMMAND(ID_BULK_READ, OnBulkRead)
	ON_COMMAND(ID_BULK_WRITE, OnBulkWrite)
	ON_COMMAND(ID_CLOSE_DEVICE, OnCloseDevice)
	ON_COMMAND(ID_CTRL_READ, OnSpecificStatus)
	ON_COMMAND(ID_AUTOSTATUS_RETURN, OnAutostatusReturn)
	ON_COMMAND(ID_OPEN_DEVICE, OnOpenDevice)
	ON_COMMAND(ID_GET_DLLVERSION, OnGetDllversion)
	ON_COMMAND(ID_OPENDEVICE_BYNAME, OnOpendeviceByname)
	ON_COMMAND(ID_ABORT_WPIPE, OnAbortWpipe)
	ON_COMMAND(ID_ABORT_RPIPE, OnAbortRpipe)
	ON_COMMAND(ID_CLEAR_ERROR, OnClearError)
	ON_COMMAND(ID_RESET_COMMAND, OnResetCommand)
	ON_COMMAND(ID_WRITE_SCOMMAND, OnWriteScommand)
	ON_COMMAND(ID_OPENDEVICE_BYNAME2, OnOpendeviceByname2)
	ON_COMMAND(ID_SET_TIMEOUTS, OnSetTimeouts)
	ON_COMMAND(ID_OPEN_BYINTERNALID, OnOpenDeviceByInternalID)
	ON_COMMAND(ID_GET_DRIVER_VERSION, OnGetDriverVersion)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CTestUSBView construction/destruction

CTestUSBView::CTestUSBView()
{
	// TODO: add construction code here
	hdev = INVALID_HANDLE_VALUE;

	hlib = LoadLibrary("ByUsbInt");

	if(!hlib)
	{
		ShowMessage("can't find dll file");
		return;
	}
/*
	bool bExistDevice = OnOpenDevice();

	OnCloseDevice();

	if(bExistDevice)
	{
		ShowMessage("find device");
	}
	else
	{
		ShowMessage("no device attached");
	}
*/
}


/*-----------------------------------------------------------------*/ 
/* CloseUSBDevice                                                   */ 
/*                                                                 */ 
/* function: close device handle.                                  */
/* Parameters:                                                     */ 
/*									                               */ 
/* Returns:													       */ 
/*-----------------------------------------------------------------*/ 
BOOL CloseUSBDevice() 
{
	// TODO: Add your command handler code here
	if(hdev == INVALID_HANDLE_VALUE)
	{
		return FALSE;
	}

	if(!hlib)
	{
		return FALSE;
	}


	CloseDevice f_CloseDevice = NULL;
	f_CloseDevice = (CloseDevice) GetProcAddress(hlib,"CloseDevice");
	if(!f_CloseDevice)
	{
		return FALSE;
	}

	BOOL bResult = f_CloseDevice(hdev);

//	ShowMessage("close device ok");	

//	hdev = INVALID_HANDLE_VALUE;

	return bResult;
}


CTestUSBView::~CTestUSBView()
{

	CloseUSBDevice();
	if(hlib)
	{
		FreeLibrary(hlib);	
	}
	
	hlib = NULL;
}

BOOL CTestUSBView::PreCreateWindow(CREATESTRUCT& cs)
{
	// TODO: Modify the Window class or styles here by modifying
	//  the CREATESTRUCT cs

	return CView::PreCreateWindow(cs);
}

/////////////////////////////////////////////////////////////////////////////
// CTestUSBView drawing

void CTestUSBView::OnDraw(CDC* pDC)
{
	CTestUSBDoc* pDoc = GetDocument();
	ASSERT_VALID(pDoc);

	// TODO: add draw code for native data here

	// show information
	pDC->TextOut(60, 100, str);
}


void CTestUSBView::ShowMessage(CString str1)
{
	str = str1;
	Invalidate(TRUE);

}
/////////////////////////////////////////////////////////////////////////////
// CTestUSBView diagnostics

#ifdef _DEBUG
void CTestUSBView::AssertValid() const
{
	CView::AssertValid();
}

void CTestUSBView::Dump(CDumpContext& dc) const
{
	CView::Dump(dc);
}

CTestUSBDoc* CTestUSBView::GetDocument() // non-debug version is inline
{
	ASSERT(m_pDocument->IsKindOf(RUNTIME_CLASS(CTestUSBDoc)));
	return (CTestUSBDoc*)m_pDocument;
}
#endif //_DEBUG

/////////////////////////////////////////////////////////////////////////////
// CTestUSBView message handlers

/*-----------------------------------------------------------------*/ 
/* OnOpenDevice                                                    */ 
/*                                                                 */ 
/* function: open  device.		                                   */
/* Parameters:                                                     */ 
/*									                               */ 
/* Returns:													       */ 
/*-----------------------------------------------------------------*/ 

bool CTestUSBView::OnOpenDevice() 
{
	// TODO: Add your command handler code here
	if(hdev != INVALID_HANDLE_VALUE)
	{
		OnCloseDevice();
	}

	
	if(!hlib)
	{
		ShowMessage("can't find dll file");
		return FALSE;
	}

	OpenDevice f_OpenDevice = NULL;
	f_OpenDevice = (OpenDevice) GetProcAddress(hlib,"OpenDevice");
	if(!f_OpenDevice)
	{
		ShowMessage("load function f_OpenDevice error");
		return FALSE;
	}

	hdev = f_OpenDevice();// 0: is the first USB device
	TRACE("OpenDevice return handle: %d\n", hdev);
	if(hdev == INVALID_HANDLE_VALUE)
	{
		ShowMessage("no device attached");
		return FALSE;
	}
	

	ShowMessage("open device ok");	

	return TRUE;
}

void CTestUSBView::OnCloseDevice() 
{
	// TODO: Add your command handler code here
	BOOL bResult = CloseUSBDevice();
	if(bResult)
	{
		ShowMessage("close device ok");
	}
	else
	{
		ShowMessage("close device failed");
	}
}


/*-----------------------------------------------------------------*/ 
/* OnAutostatusReturn                                              */ 
/*                                                                 */ 
/* function: To get the printer status, call this function first.  */
/* Parameters:						                               */ 
/*       refer to command: 1d 61 n                                 */ 
/* Returns:													       */ 
/*-----------------------------------------------------------------*/ 

void CTestUSBView::OnAutostatusReturn() 
{
	// TODO: Add your command handler code here
	unsigned char sBuf[4];

	// send ASB command
    sBuf[0] = 0x1D;
    sBuf[1] = 0x61;
    sBuf[2] = 0x0F;
    sBuf[3] = 0x00;

	if(hdev == INVALID_HANDLE_VALUE)
	{
		ShowMessage("open device first");
		return;
	}    

	if(!hlib)
	{
		ShowMessage("can't find dll file");
		return;
	}


	uWrite f_uWrite = NULL;
	f_uWrite = (uWrite) GetProcAddress(hlib,"uWrite");
	if(!f_uWrite)
	{
		ShowMessage("load function f_uWrite error");
		return;
	}
	
	int result = f_uWrite(hdev, WRITE_PIPENUM, (char *)sBuf, 3);	
	if(result <= 0)
	{
		OnCloseDevice();
		ShowMessage("Send command error");
		return;
	}
	else
	{
		ShowMessage("Send command ok");		
	}
}

UINT USB_Read(void * pParam)
{
	struct CThreadParam * threadParam;

	UINT bufSize;
	CTestUSBView *testView;

	threadParam=(struct CThreadParam *)pParam;

	bufSize = threadParam->uiLength;
	testView = threadParam->testView;

	
	testView->ShowMessage("read pending...");

	DWORD  start ,end;
	start = GetTickCount();
	int result = f_uRead(hdev, READ_PIPENUM, (char *)buf, bufSize);	
	end = GetTickCount();
	CString str;
	str.Format("%d,%d,%d",start,end,end-start);
	AfxMessageBox(str);
	if(result < 0 )
	{
		// if use AbortPipes function to cancel read command
		// don't close device, otherwise close device and repower device.

		// if(bAbortRead)
		//	   CloseUSBDevice();

		testView->ShowMessage("read error");
	
		return -1;
	}
	else
	{
		CString str;
		CString tmp;

		// show returned data
		str = "return value = ";
		for(int i=0; i < result; i++)
		{

			if((unsigned char )buf[i] > 0xf)
			{
				tmp.Format("%2X",(unsigned char )buf[i]);
			}
			else
			{
				tmp.Format("0%X",(unsigned char )buf[i]);
			}
			str += tmp;

		}
		tmp.Format("return data length = %d;   ", result);

		str = tmp + str;

		testView->ShowMessage(str);
	}
	return result;
}
/*-----------------------------------------------------------------*/ 
/* OnBulkRead                                                      */ 
/*                                                                 */ 
/* function: read data from printer or other device.               */
/* Parameters:  buffer length <= 64k                               */ 
/*                                                                 */ 
/* Returns:													       */ 
/*-----------------------------------------------------------------*/ 
void CTestUSBView::OnBulkRead() 
{
	// TODO: Add your command handler code here
//	char buf[100];
	UINT bufSize = 100;
	BOOL bResult = 0;

	if(hdev == INVALID_HANDLE_VALUE)
	{
		ShowMessage("open device first");
		return;
	}
	
	if(!hlib)
	{
		ShowMessage("can't find dll file");
		return;
	}

	f_uRead = (uRead) GetProcAddress(hlib,"uRead");
	if(!f_uRead)
	{
		ShowMessage("load function f_uRead error");
		return;
	}

	memset(buf, 0, 100);

	m_read.uiLength = bufSize;
	m_read.testView = this;


	
	m_hReadThread = AfxBeginThread( 
		USB_Read, // thread function 
		&m_read); // argument to thread function 
		
}


UINT USB_Write(void * pParam)
{
	struct CThreadParam * threadParam;

//	char *buf;
	UINT bufSize;
	CTestUSBView *testView;
	int result;

	threadParam=(struct CThreadParam *)pParam;

	bufSize = threadParam->uiLength;
	testView = threadParam->testView;

	testView->ShowMessage("write pending...");
	
	DWORD  start ,end;

	start = GetTickCount();

	result = f_uWrite(hdev, WRITE_PIPENUM, buf, bufSize);	
	end = GetTickCount();
	CString str;
	str.Format("%d,%d,%d",start,end,end-start);
	AfxMessageBox(str);
	if(result != (int)bufSize)
	{
		// if use AbortPipes function to cancel write command
		// don't close device, otherwise close device and repower device.

		// if(bAbortWrite) 
		//	   CloseUSBDevice();
		CString str;
		str.Format("length %d", result);
		str = "write error" + str;


		testView->ShowMessage(str);
	}
	else
	{
		testView->ShowMessage("write ok");	
	}

	return result;
}
/*-----------------------------------------------------------------*/ 
/* OnBulkWrite                                                     */ 
/*                                                                 */ 
/* function: write data to printer or other device.                */
/* Parameters:						                               */ 
/*                                                                 */ 
/* Returns:													       */ 
/*-----------------------------------------------------------------*/ 
#define WRITE_LENGTH (64*1024)

void CTestUSBView::OnBulkWrite() 
{
	// TODO: Add your command handler code here
	UINT bufSize = WRITE_LENGTH; // write to device

	if(hdev == INVALID_HANDLE_VALUE)
	{
		ShowMessage("open device first");
		return;
	}
	if(!hlib)
	{
		ShowMessage("can't find dll file");
		return;
	}
	memset(buf,0x33,WRITE_LENGTH);
	for(int i=1; i<64;i++)
	{
		buf[i*1024-3] = 0x30+i;
		buf[i*1024-2] = 0x30+i;
		buf[i*1024-1] = 0x30+i;
		buf[i*1024] = 0x0a;
	}
	
	buf[WRITE_LENGTH -9] = 0x32;
	buf[WRITE_LENGTH -8] = 0x32;
	buf[WRITE_LENGTH -7] = 0x32;
	buf[WRITE_LENGTH -6] = 0x32;
	buf[WRITE_LENGTH -5] = 0x32;
	buf[WRITE_LENGTH -4] = 0x32;
	buf[WRITE_LENGTH -3] = 0x32;
	buf[WRITE_LENGTH -2] = 0x32;
	buf[WRITE_LENGTH -1] = 0x0a;


	f_uWrite = (uWrite) GetProcAddress(hlib,"uWrite");
	if(!f_uWrite)
	{
		ShowMessage("load function f_uWrite error");
		return;
	}
	
	m_write.uiLength = WRITE_LENGTH;
	m_write.testView = this;
	m_hReadThread = AfxBeginThread( 
		USB_Write, // thread function 
		&m_write); // argument to thread function
}

/*-----------------------------------------------------------------*/ 
/* OnSpecificStatus                                                */ 
/*                                                                 */ 
/* function: read printer status in control pipe.                  */
/*           can return status anytime by this function            */
/* Parameters:                                                     */ 
/*                                                                 */ 
/* Returns:													       */ 
/* Remark: call function one time before call this function	       */ 
/*-----------------------------------------------------------------*/ 
void CTestUSBView::OnSpecificStatus() 
{
	// TODO: Add your command handler code here

	GetSpecStatus f_GetSpecStatus = NULL;
	BOOL bResult = FALSE;

	ULONG bufferSize = 8;
    ULONG     nBytes  = 0;
	unsigned char pRecvBuf[8];

	// check whether device handle is available
	if(hdev == INVALID_HANDLE_VALUE)
	{
		ShowMessage("open device first");
		return;
	}

	if(!hlib)
	{
		ShowMessage("can't find dll file");
		return;
	}

	f_GetSpecStatus = (GetSpecStatus) GetProcAddress(hlib,"GetSpecStatus");
	if(!f_GetSpecStatus)
	{
		ShowMessage("load function GetSpecStatus error");
		return;
	}

	memset(pRecvBuf, 0, 8);
	
	bResult = f_GetSpecStatus(hdev,
			(char *)pRecvBuf,
	    	bufferSize,
			&nBytes
	    	);

	if (!bResult)
	{
		OnCloseDevice();
		ShowMessage("read error");
		return;
	}
	else
	{
		// analyze printer's status
		// to get the detail status information of printer
		// 
/*
		if(pRecvBuf[0] & PAPER_NEAROUT)
		{
		}
		if(pRecvBuf[0] & PRINTERHEADER_OPEN)
		{
		}
		if(pRecvBuf[0] & PAPER_END)
		{
		}

		if(pRecvBuf[1] & ...)
		{
		}
		//......

*/		
		// Show return data in hex format
		CString str;
		str = "Return value = ";

		for(UINT i=0; i < nBytes; i++)
		{
			CString tmp;

			if((unsigned char )pRecvBuf[i] > 0xf)
			{
				tmp.Format(" %2X",(unsigned char )pRecvBuf[i]);
			}
			else
			{
				tmp.Format(" 0%X",(unsigned char )pRecvBuf[i]);
			}
		
			str += tmp;
		}

		ShowMessage(str);
	}

    return;   	
}


/*-----------------------------------------------------------------*/ 
/* OnGetDllversion                                                 */ 
/*                                                                 */ 
/* function: get dll version                                       */
/* Parameters:                                                     */ 
/*                                                                 */ 
/* Returns:													       */ 
/*-----------------------------------------------------------------*/ 
void CTestUSBView::OnGetDllversion() 
{
	// TODO: Add your command handler code here
	DWORD dwVer = 0;
	GetDllVersion f_GetDllVersion = NULL;

	if(!hlib)
	{
		ShowMessage("can't find dll file");
		return;
	}

	f_GetDllVersion = (GetDllVersion) GetProcAddress(hlib,"GetDllVersion");
	if(!f_GetDllVersion)
	{
		ShowMessage("load function GetDllVersion error");
		return;
	}
	else
	{
		dwVer = f_GetDllVersion();
		CString str;
		str.Format("The Dll version is : %u", dwVer);
		ShowMessage(str);
	}

	return;
}

/*-----------------------------------------------------------------*/ 
/* OnOpendeviceByname                                              */ 
/*                                                                 */ 
/* function: make sure has installed printer dirver before call    */
/*           this function, otherwise function return failed.      */
/* Parameters:                                                     */ 
/*                                                                 */ 
/* Returns:                                                        */
/* Remark:this function is not available after version 2.0		   */
/*-----------------------------------------------------------------*/ 
void CTestUSBView::OnOpendeviceByname() 
{
	// TODO: Add your command handler code here
	char cPrinterType[] = "BK-L2163"; //"BTP-2002CP";
	
	// serial number of printer name
	// default value is 1, it can be changed by driver installer
	char cSerial = 1; // serial number of printer name 

	if(hdev != INVALID_HANDLE_VALUE)
	{
		OnCloseDevice();
	}

	if(!hlib)
	{
		ShowMessage("can't find dll file");
		return;
	}

	// get function address
	OpenDeviceByName f_OpenDeviceByName = NULL;
	f_OpenDeviceByName = (OpenDeviceByName) GetProcAddress(hlib,"OpenDeviceByName");
	if(!f_OpenDeviceByName)
	{
		ShowMessage("load function OpenDeviceByName error");
		return;
	}

	// open device
	hdev = f_OpenDeviceByName(cPrinterType, cSerial);// 0: is the first USB device

	if(hdev == INVALID_HANDLE_VALUE)
	{
		ShowMessage("no device attached");
		return;
	}


	ShowMessage("open device ok");	

}
/*-----------------------------------------------------------------*/ 
/* OnOpendeviceByname2                                              */ 
/*                                                                 */ 
/* function: make sure has installed printer dirver before call    */
/*           this function, otherwise function return failed.      */
/* Parameters:                                                     */ 
/*                                                                 */ 
/* Returns:                                                        */
/* Remark:this function is not available after version 2.0		   */									      
/*-----------------------------------------------------------------*/ 

void CTestUSBView::OnOpendeviceByname2() 
{
	// TODO: Add your command handler code here
	char cPrinterType[] = "BK-L2163"; //"BTP-2002CP";
	
	// serial number of printer name
	// default value is 1, it can be changed by driver installer
	char cSerial = 2; // serial number of printer name 

	if(hdev != INVALID_HANDLE_VALUE)
	{
		OnCloseDevice();
	}

	if(!hlib)
	{
		ShowMessage("can't find dll file");
		return;
	}

	// get function address
	OpenDeviceByName f_OpenDeviceByName = NULL;
	f_OpenDeviceByName = (OpenDeviceByName) GetProcAddress(hlib,"OpenDeviceByName");
	if(!f_OpenDeviceByName)
	{
		ShowMessage("load function OpenDeviceByName error");
		return;
	}

	// open device
	hdev = f_OpenDeviceByName(cPrinterType, cSerial);// 0: is the first USB device

	if(hdev == INVALID_HANDLE_VALUE)
	{
		ShowMessage("no device attached");
		return;
	}


	ShowMessage("open device ok");		
}

/*-----------------------------------------------------------------*/ 
/* OnAbortWpipe                                                    */ 
/*                                                                 */ 
/* function: when pending a write command, use this function to    */
/*           cance the command. better to call this function in    */
/*           another thread.                                       */ 
/* Parameters:                                                     */ 
/*                                                                 */ 
/* Returns:													       */ 
/*-----------------------------------------------------------------*/ 
void CTestUSBView::OnAbortWpipe() 
{
	// TODO: Add your command handler code here

	AbortPipes f_AbortPipes = NULL;

	OpenDevice f_OpenDevice = NULL;
	f_OpenDevice = (OpenDevice) GetProcAddress(hlib,"OpenDevice");
	if(!f_OpenDevice)
	{
		ShowMessage("load function f_OpenDevice error");
		return ;
	}

	// here need to open the same device again to get the handle
	// and use a diffrent handle name: hdev1.
	// When AbortPipes is over, close the handle.
	HANDLE hdev1 = f_OpenDevice();// 0: is the first USB device
	TRACE("OpenDevice return handle: %d\n", hdev);
	if(hdev1 == INVALID_HANDLE_VALUE)
	{
		ShowMessage("open device first");
		return ;
	}

	if(!hlib)
	{
		ShowMessage("can't find dll file");
		return;
	}

	f_AbortPipes = (AbortPipes) GetProcAddress(hlib,"AbortPipes");
	if(!f_AbortPipes)
	{
		ShowMessage("load function AbortPipes error");
		return;
	}


	// Reset read pipe
	BOOL bResult = f_AbortPipes(hdev1, WRITE_PIPENUM);
	if(!bResult)
	{
		OnCloseDevice();
		ShowMessage("abort write pipe error");
		return;
	}

	// close handle hdev1, not hdev
	CloseDevice f_CloseDevice = NULL;
	f_CloseDevice = (CloseDevice) GetProcAddress(hlib,"CloseDevice");
	if(!f_CloseDevice)
	{
		return;
	}

	f_CloseDevice(hdev1);	
	
	ShowMessage("abort write pipe ok");		
}

/*-----------------------------------------------------------------*/ 
/* OnAbortRpipe                                                    */ 
/*                                                                 */ 
/* function: when pending a read command, use this function to     */
/*           cance the command. better to call this function in    */
/*           another thread.                                       */ 
/* Parameters:                                                     */ 
/*                                                                 */ 
/* Returns:													       */ 
/*-----------------------------------------------------------------*/ 

void CTestUSBView::OnAbortRpipe() 
{
	// TODO: Add your command handler code here
	AbortPipes f_AbortPipes = NULL;

	OpenDevice f_OpenDevice = NULL;
	f_OpenDevice = (OpenDevice) GetProcAddress(hlib,"OpenDevice");
	if(!f_OpenDevice)
	{
		ShowMessage("load function f_OpenDevice error");
		return ;
	}

	// here need to open the same device again to get the handle
	// and use a diffrent handle name: hdev1.
	// When AbortPipes is over, close the handle.
	HANDLE hdev1 = f_OpenDevice();// open the first USB device connected to host
	TRACE("OpenDevice return handle: %d\n", hdev);
	if(hdev1 == INVALID_HANDLE_VALUE)
	{
		ShowMessage("open device first");
		return;
	}


	if(!hlib)
	{
		ShowMessage("can't find dll file");
		return;
	}

	f_AbortPipes = (AbortPipes) GetProcAddress(hlib,"AbortPipes");
	if(!f_AbortPipes)
	{
		ShowMessage("load function error");
		return;
	}

	// abort read pipe
	BOOL bResult = f_AbortPipes(hdev1,READ_PIPENUM);
	if(!bResult)
	{
		OnCloseDevice();
		ShowMessage("abort read pipe error");
		return;
	}


	// close handle hdev1, not hdev
	CloseDevice f_CloseDevice = NULL;
	f_CloseDevice = (CloseDevice) GetProcAddress(hlib,"CloseDevice");
	if(!f_CloseDevice)
	{
		return;
	}

	f_CloseDevice(hdev1);



	ShowMessage("abort read pipe ok");	
}

/*-----------------------------------------------------------------*/ 
/* OnClearError                                                    */ 
/*                                                                 */ 
/* function: send clear error command.                             */ 
/* Parameters:                                                     */ 
/*                                                                 */ 
/* Returns:													       */ 
/*-----------------------------------------------------------------*/ 
//#define CLEAR_USB_ERROR  0xC1

// Only valid for KIOSK series printers.

void CTestUSBView::OnClearError() 
{
	// TODO: Add your command handler code here
	SendSpecCommand f_SendSpecCommand = NULL;
	BOOL bResult = FALSE;

	if(hdev == INVALID_HANDLE_VALUE)
	{
		ShowMessage("open device first");
		return;
	}

	if(!hlib)
	{
		ShowMessage("can't find dll file");
		return;
	}

	f_SendSpecCommand = (SendSpecCommand) GetProcAddress(hlib,"SendSpecCommand");
	if(!f_SendSpecCommand)
	{
		ShowMessage("load function error");
		return;
	}
	
	bResult = f_SendSpecCommand(hdev,
			(unsigned char)CLEAR_USB_ERROR
	    	);

	if (!bResult)
	{
		OnCloseDevice();
		ShowMessage("clear error");
		return;
	}

	ShowMessage("clear ok");

}

/*-----------------------------------------------------------------*/ 
/* OnResetCommand                                                  */ 
/*                                                                 */ 
/* function: send reset command.                                   */ 
/* Parameters:                                                     */ 
/*                                                                 */ 
/* Returns:													       */ 
/*-----------------------------------------------------------------*/ 
//#define RESET_USB_DEVICE 0xC1

// Only valid for KIOSK series printers.

void CTestUSBView::OnResetCommand() 
{
	// TODO: Add your command handler code here
	SendSpecCommand f_SendSpecCommand = NULL;
	BOOL bResult = FALSE;

	if(hdev == INVALID_HANDLE_VALUE)
	{
		ShowMessage("open device first");
		return;
	}

				
	if(!hlib)
	{
		ShowMessage("can't find dll file");
		return;
	}

	f_SendSpecCommand = (SendSpecCommand) GetProcAddress(hlib,"SendSpecCommand");
	if(!f_SendSpecCommand)
	{
		ShowMessage("load function SendSpecCommand error");
		return;
	}
	
	bResult = f_SendSpecCommand(hdev,
			(unsigned char)RESET_USB_DEVICE
	    	);

	if (!bResult)
	{
		OnCloseDevice();
		ShowMessage("reset device error");
		return;
	}
	
	ShowMessage("reset device ok");

}


void CTestUSBView::OnWriteScommand() 
{
	// TODO: Add your command handler code here
	unsigned char sBuf[4];

	// send ASD command
    sBuf[0] = 0x1D;
    sBuf[1] = 0x49;
    sBuf[2] = 0x44;
    sBuf[3] = 0x00;

	if(hdev == INVALID_HANDLE_VALUE)
	{
		ShowMessage("open device first");
		return;
	}    

	if(!hlib)
	{
		ShowMessage("can't find dll file");
		return;
	}


	uWrite f_uWrite = NULL;
	f_uWrite = (uWrite) GetProcAddress(hlib,"uWrite");
	if(!f_uWrite)
	{
		ShowMessage("load function f_uWrite error");
		return;
	}
	
	int result = f_uWrite(hdev, WRITE_PIPENUM, (char *)sBuf, 3);	
	if(result <= 0)
	{
		OnCloseDevice();
		ShowMessage("Send command error");
		return;
	}
	else
	{
		ShowMessage("Send command ok");		
	}	
}


/*---------------------------------------------------------------------*/ 
/* SetUSBTimeouts(HANDLE hdev, WORD wReadTimeouts, WORD wWriteTimeouts) */ 
/*                                                                     */ 
/* function: set USB interface timeouts.                               */ 
/* Parameters:                                                         */ 
/*    hdev: device handle 
/*    wReadTimeouts: Specifies the maximum time, in 100 milliseconds.  */
/*          A value of zero indicates that time-outs are not used.     */
/*    wWriteTimeouts:Specifies the maximum time, in 100 milliseconds.  */
/*          A value of zero indicates that time-outs are not used.     */
/* Returns:													           */ 
/*---------------------------------------------------------------------*/ 

void CTestUSBView::OnSetTimeouts() 
{
	// TODO: Add your command handler code here
	if(hdev == INVALID_HANDLE_VALUE)
	{
		ShowMessage("open device first");
		return;
	}

	if(!hlib)
	{
		ShowMessage("can't find dll file");
		return;
	}

	SetUSBTimeouts f_SetUSBTimeouts = NULL;	

	f_SetUSBTimeouts = (SetUSBTimeouts) GetProcAddress(hlib,"SetUSBTimeouts");
	if(!f_SetUSBTimeouts)
	{
		ShowMessage("load function SetUSBTimeouts error");
		return;
	}
	else
	{
		// timeouts unit: 100ms/unit
		// Read timeouts: 100, means 10Sec
		// Write timeouts: 200, means 20Sec
		if(dlg_Inputbox.DoModal() != IDOK)
		{
			return;
		}
		if(f_SetUSBTimeouts(hdev,dlg_Inputbox.m_RTimeOut,dlg_Inputbox.m_WTimeOut))
		{
			ShowMessage("Set timeouts success!");
		}
		else
		{
			ShowMessage("Set timeouts failed!");
		}
	}	
}

void CTestUSBView::OnOpenDeviceByInternalID() 
{
	// TODO: Add your command handler code here
	if(hdev != INVALID_HANDLE_VALUE)
	{
		OnCloseDevice();
	}
	if(!hlib)
	{
		ShowMessage("can't find dll file");
		return ;
	}

	DWORD iID;

	OpenDeviceByInternalID f_OpenDeviceByInternalID = NULL;	
	if(!hlib)
	{
		ShowMessage("can't find dll file");
		return;
	}

	f_OpenDeviceByInternalID = (OpenDeviceByInternalID) GetProcAddress(hlib,"OpenDeviceByInternalID");
	if(!f_OpenDeviceByInternalID)
	{
		ShowMessage("load function OpenDeviceByInternalID error");
		return;
	}
	else
	{
		if(dlg_id.DoModal()!=IDOK)
		{
			return;
		}
		iID =dlg_id.m_PrintID; // BTP-2002CP Internal ID: 0~7; 
				// USB_BTP-2002CP_1: 0
				// USB_BTP-2002CP_2: 1

		hdev = f_OpenDeviceByInternalID(iID);
		if(hdev == INVALID_HANDLE_VALUE)
		{
			ShowMessage("no device attached");
			return ;
		}

		ShowMessage("Open device ok");
	}	
}


void CTestUSBView::OnGetDriverVersion() 
{
	// TODO: Add your command handler code here

	GetDriverVersion f_GetDriverVersion = NULL;
	BOOL bResult = FALSE;

	ULONG bufferSize = 8;
	unsigned char pRecvBuf[8];

	// check whether device handle is available
	if(hdev == INVALID_HANDLE_VALUE)
	{
		ShowMessage("open device first");
		return;
	}    
	if(!hlib)
	{
		ShowMessage("can't find dll file");
		return;
	}

	f_GetDriverVersion = (GetDriverVersion) GetProcAddress(hlib,"GetDriverVersion");
	if(!f_GetDriverVersion)
	{
		ShowMessage("load function GetSpecStatus error");
		return;
	}

	memset(pRecvBuf, 0, 8);
	bResult = f_GetDriverVersion(hdev,(char *)pRecvBuf);

	if (!bResult)
	{
		OnCloseDevice();
		ShowMessage("read error");
		return;
	}
	else
	{
		int MajorVersion,MinorVersion,BuildVersion;
		MajorVersion = pRecvBuf[0]+pRecvBuf[1]*256;
		MinorVersion = pRecvBuf[2]+pRecvBuf[3]*256;
		BuildVersion = pRecvBuf[4]+pRecvBuf[5]*256;
		CString str;
		str.Format("MajorVersion = %d    MinorVersion = %d     BuildVersion = %d",MajorVersion,MinorVersion,BuildVersion) ;
		ShowMessage(str);
	}

    return;   	
}


