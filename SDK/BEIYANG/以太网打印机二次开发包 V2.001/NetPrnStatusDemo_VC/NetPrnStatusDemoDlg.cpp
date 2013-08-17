// NetPrnStatusDemoDlg.cpp : implementation file
//

#include "stdafx.h"
#include "NetPrnStatusDemo.h"
#include "NetPrnStatusDemoDlg.h"
#include "STATUS.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CAboutDlg dialog used for App About

class CAboutDlg : public CDialog
{
public:
	CAboutDlg();
	
// Dialog Data
	//{{AFX_DATA(CAboutDlg)
	enum { IDD = IDD_ABOUTBOX };
	//}}AFX_DATA

	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CAboutDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:
	//{{AFX_MSG(CAboutDlg)
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

CAboutDlg::CAboutDlg() : CDialog(CAboutDlg::IDD)
{
	//{{AFX_DATA_INIT(CAboutDlg)
	//}}AFX_DATA_INIT
}

void CAboutDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CAboutDlg)
	//}}AFX_DATA_MAP
}

BEGIN_MESSAGE_MAP(CAboutDlg, CDialog)
	//{{AFX_MSG_MAP(CAboutDlg)
		// No message handlers
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CNetPrnStatusDemoDlg dialog

CNetPrnStatusDemoDlg::CNetPrnStatusDemoDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CNetPrnStatusDemoDlg::IDD, pParent)
{
	//{{AFX_DATA_INIT(CNetPrnStatusDemoDlg)	
	m_option = -1;
	//}}AFX_DATA_INIT
	// Note that LoadIcon does not require a subsequent DestroyIcon in Win32
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CNetPrnStatusDemoDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CNetPrnStatusDemoDlg)
	DDX_Control(pDX, IDC_COMBO2, m_iplist);
	DDX_Control(pDX, IDC_IPADDRESS1, ip);
	DDX_Radio(pDX, IDC_RADIO1, m_option);
	//}}AFX_DATA_MAP
}

BEGIN_MESSAGE_MAP(CNetPrnStatusDemoDlg, CDialog)
	//{{AFX_MSG_MAP(CNetPrnStatusDemoDlg)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_BN_CLICKED(IDC_BUTTON4, OnButton4)
	ON_BN_CLICKED(IDC_PRINT, OnPrint)
	ON_BN_CLICKED(IDC_STATUS, OnStatus)
	ON_NOTIFY(IPN_FIELDCHANGED, IDC_IPADDRESS1, OnFieldchangedIpaddress1)
	ON_BN_CLICKED(IDC_RADIO1, OnRadio1)
	ON_BN_CLICKED(IDC_RADIO2, OnRadio2)
	ON_CBN_SELCHANGE(IDC_COMBO2, OnSelchangeCombo2)
	ON_WM_HELPINFO()
	ON_CBN_SELCHANGE(IDC_COMBO1, OnSelchangeCombo1)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CNetPrnStatusDemoDlg message handlers

BOOL CNetPrnStatusDemoDlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	// Add "About..." menu item to system menu.

	// IDM_ABOUTBOX must be in the system command range.
	ASSERT((IDM_ABOUTBOX & 0xFFF0) == IDM_ABOUTBOX);
	ASSERT(IDM_ABOUTBOX < 0xF000);

	CMenu* pSysMenu = GetSystemMenu(FALSE);
	if (pSysMenu != NULL)
	{
		CString strAboutMenu;
		strAboutMenu.LoadString(IDS_ABOUTBOX);
		if (!strAboutMenu.IsEmpty())
		{
			pSysMenu->AppendMenu(MF_SEPARATOR);
			pSysMenu->AppendMenu(MF_STRING, IDM_ABOUTBOX, strAboutMenu);
		}
	}

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon
	
	// TODO: Add extra initialization here
	UpdateData(TRUE);
	ip.EnableWindow(TRUE);
	m_iplist.EnableWindow(FALSE);
	m_iplist.SetCurSel(0);
	m_option = 1;
	UpdateData(FALSE);

    //default ip address
	ipstr = _T("192.168.192.168");
	ip.SetWindowText(ipstr); 

	
	return TRUE;  // return TRUE  unless you set the focus to a control
}

void CNetPrnStatusDemoDlg::OnSysCommand(UINT nID, LPARAM lParam)
{
	if ((nID & 0xFFF0) == IDM_ABOUTBOX)
	{
		CAboutDlg dlgAbout;
		dlgAbout.DoModal();
	}
	else
	{
		CDialog::OnSysCommand(nID, lParam);
	}
}

// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.

void CNetPrnStatusDemoDlg::OnPaint() 
{
	if (IsIconic())
	{
		CPaintDC dc(this); // device context for painting

		SendMessage(WM_ICONERASEBKGND, (WPARAM) dc.GetSafeHdc(), 0);

		// Center icon in client rectangle
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// Draw the icon
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialog::OnPaint();
	}
}

// The system calls this to obtain the cursor to display while the user drags
//  the minimized window.
HCURSOR CNetPrnStatusDemoDlg::OnQueryDragIcon()
{
	return (HCURSOR) m_hIcon;
}

void CNetPrnStatusDemoDlg::OnButton4() 
{
	// TODO: Add your control notification handler code here
	CDialog::OnCancel();
}


void CNetPrnStatusDemoDlg::OnPrint() 
{	
	//set the cursor shape
	SetCursor(LoadCursor(NULL, IDC_WAIT));

	char ipaddr[50];

	memset(ipaddr,0,50);
	
	//Get ip address
	if(m_option == 1) //set ip mode
	{//check ip address
		if(ipstr.IsEmpty())
		{
			AfxMessageBox("IP address is null!");
			return;
		}

		if(ipstr.Find("0.0.0.0") != -1)
		{
			AfxMessageBox("IP address is null!");
			return;
		}
		
		strcpy(ipaddr,ipstr);
	}

	if(m_option == 0) //Auto get ip mode
	{//check ip address
		if(iplist.IsEmpty())
		{
			AfxMessageBox("IP address is null!");
			return;
		}

		if(iplist.Find("0.0.0.0") != -1)
		{
			AfxMessageBox("IP address is null!");
			return;
		}

		if(iplist.Find("<NULL>") != -1)
		{
			AfxMessageBox("IP address is null!");
			return;
		}
	
		strcpy(ipaddr,iplist);
	}	

	HINSTANCE hlib; // dll handle

	//carry dll
	hlib = LoadLibrary("BYNetPortAPI.dll");

	if(!hlib)
	{
		AfxMessageBox("Connect DLL error!");
		return;
	} 

	//Carry "BTPNetOpenWrite"function
	mNetWriteOpen NetWriteOpen = NULL;
	NetWriteOpen= (mNetWriteOpen) GetProcAddress(hlib,"NetWriteOpen");

	if(NetWriteOpen == NULL)
	{
		AfxMessageBox("Don't find 'NetWriteOpen' function!");
		return;
	}

	//Carry "BTPNetWrite"function
	mNetWrite NetWrite = NULL;
	NetWrite = (mNetWrite) GetProcAddress(hlib,"NetWrite");

	if(NetWrite == NULL)
	{
		AfxMessageBox("Don't find 'NetWrite' function!");
		return;
	}		

	//Carry "BTPNetCloseWrite"function
	mNetWriteClose NetWriteClose = NULL;
	NetWriteClose = (mNetWriteClose) GetProcAddress(hlib,"NetWriteClose");

	if(NetWriteClose == NULL)
	{
		AfxMessageBox("Don't find 'NetWriteClose' function!");
		return;
	}	

	//Connect the printer
	if(NetWriteOpen(ipaddr,3) == FALSE)
	{
		AfxMessageBox("Open write port error!");
		return;
	}	
	
	//input data
	char databuf[1024];
	memset(databuf,0,1024);	
	
    CString str = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz\n";
   
	int len = str.GetLength();

	strcpy(databuf,str);

	databuf[len] = 0x0a;

	int returncode;

	returncode = NetWrite(databuf,1024,5);

	//Print data
	if(returncode == -1)
	{
		AfxMessageBox("Write data error!");
		return;
	}

	if(returncode == -2)
	{
		AfxMessageBox("Write parameter error!");
		return;
	}

	//Close socket
	if(NetWriteClose() == FALSE)
	{
		AfxMessageBox("Close write port error!");
		return;
	}

	//Release dll
	FreeLibrary(hlib);
	Sleep(2000);
}

void CNetPrnStatusDemoDlg::OnStatus() 
{
	// TODO: Add your control notification handler code here
	CSTATUS dlg;	
	
	//Get ip address
	if(m_option == 1) //set ip mode
	{
		if(ipstr.IsEmpty())
		{
			AfxMessageBox("IP address is null!");
			return;
		}

		if(ipstr.Find("0.0.0.0") != -1)
		{
			AfxMessageBox("IP address is null!");
			return;
		}		
		
		strcpy(dlg.ipaddr,ipstr);
	}

	if(m_option == 0) //Auto get ip mode
	{
		if(iplist.IsEmpty())
		{
			AfxMessageBox("IP address is null!");
			return;
		}

		if(iplist.Find("0.0.0.0") != -1)
		{
			AfxMessageBox("IP address is null!");
			return;
		}

		if(iplist.Find("<NULL>") != -1)
		{
			AfxMessageBox("IP address is null!");
			return;
		}
	
		strcpy(dlg.ipaddr,iplist);
	}	

	dlg.DoModal();
}

void CNetPrnStatusDemoDlg::OnFieldchangedIpaddress1(NMHDR* pNMHDR, LRESULT* pResult) 
{
	// TODO: Add your control notification handler code here
	ip.GetWindowText(ipstr); 
	
	*pResult = 0;
}

void CNetPrnStatusDemoDlg::OnRadio1() 
{
	// TODO: Add your control notification handler code here
	m_option = 0;

	//Set cursor shape 
	SetCursor(LoadCursor(NULL, IDC_WAIT));
	
	m_iplist.ResetContent();

	HINSTANCE hlib; // dll handle

	//carry dll
	hlib = LoadLibrary("BYNetPortAPI.dll");

	if(!hlib)
	{
		AfxMessageBox("Connect DLL error!");
		return;
	} 

	//Carry "NetGetPrinterIP" function
	mNetGetPrinterIP NetGetPrinterIP = NULL;
	NetGetPrinterIP= (mNetGetPrinterIP) GetProcAddress(hlib,"NetGetPrinterIP");

	if(NetGetPrinterIP == NULL)
	{
		AfxMessageBox("Don't find 'NetGetPrinterIP' function!");
		return;
	}

	int number;
	char ipbuf[1024];

	memset(ipbuf,0,1024);

	//Auto get ip address
	number = NetGetPrinterIP(ipbuf);

	//judg number of device
	if(number <= 0)
	{
		AfxMessageBox("Can not find printer!");
		m_iplist.AddString("<NULL>");
		ip.EnableWindow(FALSE);
		m_iplist.EnableWindow(TRUE);
		m_iplist.SetCurSel(0);
		return;
	}

	CString ipstr;
	CString str;

	ipstr.Format("%s",ipbuf);

	int m;
	int n = 0;
	int length;

	length = strlen(ipstr);

	//parse ip address
	for(m = 0;m < length;m++)
	{
		if(ipbuf[m] == '@')
		{
			str = ipstr.Mid(n,m-n);
			n = m+1;

			m_iplist.AddString(str);
		}
	}

	//judg ip address conflict
	CString ipaddress[1024];
	int indexnum;
	int p = 0;
	int q = 0;
	int w;	
	
	indexnum = m_iplist.GetCount();	

	for(p;p < indexnum;p++)
	{
		m_iplist.GetLBText(p,ipaddress[p]);
	}

	for(q;q < indexnum;q++)
	{
		w = q + 1;
		for(w;w < indexnum;w++)
		{
			if(ipaddress[q] == ipaddress[w])
			{
				CString sameip;

				sameip.Format("IP address exist conflict!%s",ipaddress[q]);				
				
				m_iplist.ResetContent();

				m_iplist.AddString("<NULL>");
				m_iplist.SetCurSel(0);
				
				ip.EnableWindow(FALSE);
				m_iplist.EnableWindow(TRUE);

				UpdateData(FALSE);
				
				AfxMessageBox(sameip);
				return;
			}
		}		
	}

	m_iplist.SetCurSel(0);

	char buf[20];

	memset(buf,0,20);
	int nIndex = m_iplist.GetCurSel();    
	m_iplist.GetLBText(nIndex, buf);
	
	iplist.Format("%s",buf);

	ip.EnableWindow(FALSE);
	m_iplist.EnableWindow(TRUE);

	UpdateData(FALSE);	
}

void CNetPrnStatusDemoDlg::OnRadio2() 
{
	// TODO: Add your control notification handler code here
	m_option = 1;

	ip.EnableWindow(TRUE);
	m_iplist.EnableWindow(FALSE);

	UpdateData(FALSE);
}

void CNetPrnStatusDemoDlg::OnSelchangeCombo2() 
{
	// TODO: Add your control notification handler code here
	char buf[20];

	memset(buf,0,20);
	int nIndex = m_iplist.GetCurSel();    
	m_iplist.GetLBText(nIndex, buf);

	
	iplist.Format("%s",buf);
}

BOOL CNetPrnStatusDemoDlg::OnHelpInfo(HELPINFO* pHelpInfo) 
{
	// TODO: Add your message handler code here and/or call default
	
	ShellExecute(NULL,"open",".\\NetPrnStatusDemo Guide.chm",NULL,NULL,SW_SHOW);
	return TRUE;
}

void CNetPrnStatusDemoDlg::OnSelchangeCombo1() 
{
	// TODO: Add your control notification handler code here

	UpdateData(FALSE);
}
