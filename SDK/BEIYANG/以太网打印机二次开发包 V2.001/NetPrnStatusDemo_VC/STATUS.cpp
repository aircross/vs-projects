// STATUS.cpp : implementation file
//

#include "stdafx.h"
#include "NetPrnStatusDemo.h"
#include "STATUS.h"
#include "BtnST.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////

unsigned char buf[8];

//button variable
CButtonST m_offline,m_cashdrawer,m_paperend,m_papernearend,m_coveropen,m_cutter,m_busy,m_restorable,m_autorestorable,m_feedkey;

//indicate variable
bool    m_OfflineFlg,m_CashdrawerFlg,m_PaperNearEndFlg, m_CoverOpenFlg, m_PaperEndFlg, m_BusyFlg,m_CuttorErrFlg, m_AutoInstallErrFlg, m_FeedkeyFlg, m_RestorableFlg;

//declare index variable of function
mNetGetStatus NetGetStatus = NULL;

// CSTATUS dialog

CSTATUS::CSTATUS(CWnd* pParent /*=NULL*/)
	: CDialog(CSTATUS::IDD, pParent)
{
	//{{AFX_DATA_INIT(CSTATUS)
		// NOTE: the ClassWizard will add member initialization here
	//}}AFX_DATA_INIT
}


void CSTATUS::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CSTATUS)
	DDX_Control(pDX, IDC_STOP, m_stop);
	DDX_Control(pDX, IDC_START, m_start);
	//}}AFX_DATA_MAP
	DDX_Control(pDX, IDC_PAPEREND, m_paperend);
	DDX_Control(pDX, IDC_PAPERNAREEND, m_papernearend);
	DDX_Control(pDX, IDC_COVER, m_coveropen);
	DDX_Control(pDX, IDC_CUT, m_cutter);
	DDX_Control(pDX, IDC_PRNBUSY, m_busy);
	DDX_Control(pDX, IDC_RESTOR, m_restorable);
	DDX_Control(pDX, IDC_AUTO, m_autorestorable);
	DDX_Control(pDX, IDC_FEED, m_feedkey);
	DDX_Control(pDX, IDC_CASHDRAWER, m_cashdrawer);
	DDX_Control(pDX, IDC_OFFLINE, m_offline);
}


BEGIN_MESSAGE_MAP(CSTATUS, CDialog)
	//{{AFX_MSG_MAP(CSTATUS)
	ON_WM_PAINT()
	ON_WM_TIMER()
	ON_BN_CLICKED(IDC_START, OnStart)
	ON_BN_CLICKED(IDC_STOP, OnStop)
	ON_WM_HELPINFO()
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CSTATUS message handlers

BOOL CSTATUS::OnInitDialog() 
{
	CDialog::OnInitDialog();
	
	// TODO: Add extra initialization here
	m_stop.EnableWindow(FALSE);
	m_start.EnableWindow(TRUE);
    
	//default initialization status
	m_paperend.SetIcon(IDI_BLACK);
	m_paperend.DrawBorder(false);
	m_paperend.SetColor(3,RGB(39,6,227),true);

	m_papernearend.SetIcon(IDI_BLACK);
	m_papernearend.DrawBorder(false);
	m_papernearend.SetColor(3,RGB(39,6,227),true);

	m_cashdrawer.SetIcon(IDI_BLACK);
	m_cashdrawer.DrawBorder(false);
	m_cashdrawer.SetColor(3,RGB(39,6,227),true);

	m_cutter.SetIcon(IDI_BLACK);
	m_cutter.DrawBorder(false);
	m_cutter.SetColor(3,RGB(39,6,227),true);

	m_coveropen.SetIcon(IDI_BLACK);
	m_coveropen.DrawBorder(false);
	m_coveropen.SetColor(3,RGB(39,6,227),true);

	m_busy.SetIcon(IDI_BLACK);
	m_busy.DrawBorder(false);
	m_busy.SetColor(3,RGB(39,6,227),true);

	m_restorable.SetIcon(IDI_BLACK);
	m_restorable.DrawBorder(false);
	m_restorable.SetColor(3,RGB(39,6,227),true);

	m_autorestorable.SetIcon(IDI_BLACK);
	m_autorestorable.DrawBorder(false);
	m_autorestorable.SetColor(3,RGB(39,6,227),true);

	m_feedkey.SetIcon(IDI_BLACK);
	m_feedkey.DrawBorder(false);
	m_feedkey.SetColor(3,RGB(39,6,227),true);
	
	m_offline.SetIcon(IDI_BLACK);
	m_offline.DrawBorder(false);
	m_offline.SetColor(3,RGB(39,6,227),true);

	return TRUE;  // return TRUE unless you set the focus to a control
	              // EXCEPTION: OCX Property Pages should return FALSE
}

void CSTATUS::OnPaint() 
{
	CPaintDC dc(this); // device context for painting
	
	// TODO: Add your message handler code here
	CFont   font3d, *oldfont;
	COLORREF OldColor;
	CRect txtRect,rect;
	GetClientRect(&rect);

	char  * mstr ;
	mstr = new char [256];
	memset(mstr,0x00,256);  
	strcat(mstr ,"      Status Monitor for the Printer ");
	strcat(mstr ,"\0");
	CString str;
	str = "Status Monitor for the Printer";

	font3d.CreateFont( 30, 0, 0, 0, FW_BOLD,0,FALSE,0,0,0,0,0,0,"Arival" );
	oldfont = dc.SelectObject(&font3d); 

	SetRect( &txtRect,rect.left,rect.top,rect.right,rect.bottom/8 );
	SetBkMode( dc, TRANSPARENT );

    OldColor = SetTextColor( dc, RGB( 200, 50, 20 ) );

	dc.DrawText( str, str.GetLength(), &txtRect, DT_SINGLELINE|DT_CENTER|DT_VCENTER );

	delete []mstr;

	dc.SelectObject(oldfont);
	DeleteObject(font3d);
	// Do not call CDialog::OnPaint() for painting messages
}

void CSTATUS::OnStart() 
{
	// TODO: Add your control notification handler code here
	SetCursor(LoadCursor(NULL, IDC_WAIT)); 
	
		HINSTANCE hlib; // dll handle
	//carry dll
	hlib = LoadLibrary("BYNetPortAPI.dll");

	if(!hlib)
	{
		AfxMessageBox("Connect DLL error!");
		return;
	} 

	//Carry "NetGetStatus"function
	mNetGetStatus NetGetStatus = NULL;
	NetGetStatus= (mNetGetStatus) GetProcAddress(hlib,"NetGetStatus");

	if(NetGetStatus == NULL)
	{
		AfxMessageBox("Don't find 'NetGetManufacturerInfo' function!");
		return;
	}

	memset(buf,0,8);

	int rr = NetGetStatus(ipaddr,buf,4,3,2);
	if(rr < 0)
	{
		m_paperend.SetIcon(IDI_BLACK);
		m_cashdrawer.SetIcon(IDI_BLACK);
		m_papernearend.SetIcon(IDI_BLACK);
		m_cutter.SetIcon(IDI_BLACK);
		m_coveropen.SetIcon(IDI_BLACK);
		m_busy.SetIcon(IDI_BLACK);
		m_restorable.SetIcon(IDI_BLACK);
		m_autorestorable.SetIcon(IDI_BLACK);
		m_feedkey.SetIcon(IDI_BLACK);
		m_offline.SetIcon(IDI_RED);


		//This method enables or disables input to a specified window.
		m_stop.EnableWindow(FALSE);
		m_start.EnableWindow(TRUE);
		UpdateData(FALSE);
		
		return;		
	}

	//Initialized status is right status 
	m_OfflineFlg = m_CashdrawerFlg = m_PaperNearEndFlg = m_CoverOpenFlg = m_PaperEndFlg = m_BusyFlg = m_CuttorErrFlg = m_AutoInstallErrFlg = m_FeedkeyFlg = m_RestorableFlg = true;

	m_paperend.SetIcon(IDI_GREEN);
	m_cashdrawer.SetIcon(IDI_GREEN);
	m_papernearend.SetIcon(IDI_GREEN);
	m_cutter.SetIcon(IDI_GREEN);
	m_coveropen.SetIcon(IDI_GREEN);
	m_busy.SetIcon(IDI_GREEN);
	m_restorable.SetIcon(IDI_GREEN);
	m_autorestorable.SetIcon(IDI_GREEN);
	m_feedkey.SetIcon(IDI_GREEN);
	m_offline.SetIcon(IDI_GREEN);


	//This method enables or disables input to a specified window.
	m_stop.EnableWindow(TRUE);
	m_start.EnableWindow(FALSE);
	UpdateData(FALSE);	

    //Setting timer parameter
	m_bTimer = SetTimer(1,1000,NULL); 
}

void CSTATUS::OnTimer(UINT nIDEvent) 
{
	// TODO: Add your message handler code here and/or call default
	BOOL IsSingularity,IsPaperEnd,IsPaperNearEnd,IsCoverOpen,IsCashdrawerOpen,IsCuterError,PrinterBusy,RunFeedKey,ExistRestoreError,ExistAutoRestoreError;

	HINSTANCE hlib; // dll handle
	//carry dll
	hlib = LoadLibrary("BYNetPortAPI.dll");

	if(!hlib)
	{
		AfxMessageBox("Connect DLL error!");
		return;
	} 

	//Carry "NetGetStatus"function
	mNetGetStatus NetGetStatus = NULL;
	NetGetStatus= (mNetGetStatus) GetProcAddress(hlib,"NetGetStatus");

	if(NetGetStatus == NULL)
	{
		AfxMessageBox("Don't find 'NetGetStatus' function!");
		return;
	}

	memset(buf,0,8);
	if(NetGetStatus(ipaddr,buf,4,3,2) < 0)
	{		
		memset(buf,0,8);
		if(NetGetStatus(ipaddr,buf,4,2,2) < 0)
		{
			memset(buf,0,8);
			if(NetGetStatus(ipaddr,buf,4,2,2) < 0)
			{			
				memset(buf,0,8);
				if(NetGetStatus(ipaddr,buf,4,2,2) < 0)
				{
					memset(buf,0,8);
					if(NetGetStatus(ipaddr,buf,4,2,2) < 0)
					{
						//Destroy the specified timer
						KillTimer(m_bTimer);

						m_paperend.SetIcon(IDI_BLACK);
						m_papernearend.SetIcon(IDI_BLACK);
						m_cutter.SetIcon(IDI_BLACK);
						m_coveropen.SetIcon(IDI_BLACK);
						m_cashdrawer.SetIcon(IDI_BLACK);
						m_busy.SetIcon(IDI_BLACK);
						m_restorable.SetIcon(IDI_BLACK);
						m_autorestorable.SetIcon(IDI_BLACK);
						m_feedkey.SetIcon(IDI_BLACK);
						m_offline.SetIcon(IDI_RED);

						m_stop.EnableWindow(FALSE);
						m_start.EnableWindow(TRUE);
						UpdateData(FALSE);			
								
						return;
					}
				}
			}	
		}
	}

	// Parse status data
	IsSingularity = (buf[0] & 0x10) == 0x00 ? 0:1;
	IsPaperEnd = (buf[2] & 0x0C) == 0x00 ? 0:1;
	IsPaperNearEnd = (buf[2] & 0x03) == 0x00 ? 0:1;
	IsCoverOpen = (buf[0] & 0x20) == 0x00 ? 0:1;
	IsCashdrawerOpen = (buf[0] & 0x04) == 0x00 ? 0:1;
	IsCuterError = (buf[1] & 0x08) == 0x00 ? 0:1;
	PrinterBusy = (buf[0] & 0x08) == 0x00 ? 0:1;
	RunFeedKey = (buf[0] & 0x40) == 0x00 ? 0:1;
	ExistRestoreError = (buf[1] & 0x20) == 0x00 ? 0:1;
	ExistAutoRestoreError = (buf[1] & 0x40) == 0x00 ? 0:1;
	
	//Is printer's status singular?	
	if(IsSingularity == FALSE)
	{
		//Destroy the specified timer
		KillTimer(m_bTimer);		

		m_paperend.SetIcon(IDI_BLACK);
		m_papernearend.SetIcon(IDI_BLACK);
		m_cutter.SetIcon(IDI_BLACK);
		m_coveropen.SetIcon(IDI_BLACK);
		m_cashdrawer.SetIcon(IDI_BLACK);
		m_busy.SetIcon(IDI_BLACK);
		m_restorable.SetIcon(IDI_BLACK);
		m_autorestorable.SetIcon(IDI_BLACK);
		m_feedkey.SetIcon(IDI_BLACK);
		m_offline.SetIcon(IDI_BLACK);

		m_stop.EnableWindow(FALSE);
		m_start.EnableWindow(TRUE);
		UpdateData(FALSE);

        AfxMessageBox("Printer's status is abnormal!");
		
		return;
	}

	//Is paper end ?	
	if(IsPaperEnd == TRUE )
	{//Display error 
		if(m_PaperEndFlg)
		{
			m_PaperEndFlg = false;
			m_paperend.SetIcon(IDI_RED);	
		}
	}
	else
	{//Display right 
		if(!m_PaperEndFlg)
		{
			m_PaperEndFlg = true;
			m_paperend.SetIcon(IDI_GREEN);
		}
	}
    UpdateData(FALSE);

    //Is paper near end ?	
	if(IsPaperNearEnd == TRUE)
	{//display error 
		if(m_PaperNearEndFlg)
		{
			m_PaperNearEndFlg = false;
			m_papernearend.SetIcon(IDI_RED);	
		}		
	}
	else
	{//Display right 
		if(!m_PaperNearEndFlg)
		{
			m_PaperNearEndFlg = true;
			m_papernearend.SetIcon(IDI_GREEN);	
		}
	}
	UpdateData(FALSE);

    //Is cover open ?	
	if(IsCoverOpen == TRUE)
	{//Display error 
		if(m_CoverOpenFlg)
		{
			m_CoverOpenFlg = false;
			m_coveropen.SetIcon(IDI_RED);
		}	
	}
	else
	{//Display right 
		if(!m_CoverOpenFlg)
		{
			m_CoverOpenFlg = true;
			m_coveropen.SetIcon(IDI_GREEN);	
		}	
	}
	UpdateData(FALSE);

	//Is cashdrawer open ?	
	if(IsCashdrawerOpen == FALSE)
	{//display error 
		if(m_CashdrawerFlg)
		{
			m_CashdrawerFlg = false;
			m_cashdrawer.SetIcon(IDI_RED);
		}	
	}
	else
	{//Display right 
		if(!m_CashdrawerFlg)
		{
			m_CashdrawerFlg = true;
			m_cashdrawer.SetIcon(IDI_GREEN);	
		}	
	}
	UpdateData(FALSE);

    //Is cutter error ?	
	if(IsCuterError == TRUE)
	{//Display error 
		if(m_CuttorErrFlg)
		{
			m_CuttorErrFlg = false;
			m_cutter.SetIcon(IDI_RED);	
		}		
	}
	else
	{//Display right 
		if(!m_CuttorErrFlg)
		{
			m_CuttorErrFlg = true;
			m_cutter.SetIcon(IDI_GREEN);	
		}
	}
	UpdateData(FALSE);

    //Is printer off-line ? 
	if(PrinterBusy == TRUE)
	{//Display error 
		if(m_BusyFlg)
		{
			m_BusyFlg = false;
			m_busy.SetIcon(IDI_RED);	
		}
	}
	else
	{//Display right 
		if(!m_BusyFlg)
		{
			m_BusyFlg = true;
			m_busy.SetIcon(IDI_GREEN);		
		}	
	}
	UpdateData(FALSE);	

    //Run feed button ?	
	if(RunFeedKey == TRUE)
	{//display error
		if(m_FeedkeyFlg)
		{
			m_FeedkeyFlg = false;
			m_feedkey.SetIcon(IDI_RED);	
		}
	}
 	else
	{//Display right
		if(!m_FeedkeyFlg)
		{
			m_FeedkeyFlg = true;
			m_feedkey.SetIcon(IDI_GREEN);	
		}		
	}
	UpdateData(FALSE);

    //Exist restorable error ?
	if(ExistRestoreError == TRUE)
	{//Display error 
		if(m_RestorableFlg)
		{
			m_RestorableFlg = false;
			m_restorable.SetIcon(IDI_RED);	
		}
	}
	else
	{//Display right 
		if(!m_RestorableFlg)
		{
			m_RestorableFlg = true;
			m_restorable.SetIcon(IDI_GREEN);	
		}
	}
	UpdateData(FALSE);

    //Exist automatice restorable error ?	
	if(ExistAutoRestoreError == TRUE)
	{//Display error 
		if(m_AutoInstallErrFlg)
		{
			m_AutoInstallErrFlg = false;
			m_autorestorable.SetIcon(IDI_RED);	
		}
	}
	else
	{//Display right 
		if(!m_AutoInstallErrFlg)
		{
			m_AutoInstallErrFlg = true;
			m_autorestorable.SetIcon(IDI_GREEN);	
		}
	}
	UpdateData(FALSE); 

	FreeLibrary(hlib);
	
	CDialog::OnTimer(nIDEvent);
}


void CSTATUS::OnStop() 
{
	// TODO: Add your control notification handler code here
	m_stop.EnableWindow(FALSE);
	m_start.EnableWindow(TRUE);
	UpdateData(FALSE);	

    //Destroy the specified timer
	KillTimer(m_bTimer);
	
	//Interface show ashy  
	m_paperend.SetIcon(IDI_BLACK);
	m_papernearend.SetIcon(IDI_BLACK);
	m_cutter.SetIcon(IDI_BLACK);
	m_coveropen.SetIcon(IDI_BLACK);
	m_cashdrawer.SetIcon(IDI_BLACK);
	m_busy.SetIcon(IDI_BLACK);
	m_restorable.SetIcon(IDI_BLACK);
	m_autorestorable.SetIcon(IDI_BLACK);
	m_feedkey.SetIcon(IDI_BLACK);
	m_offline.SetIcon(IDI_BLACK);

	//Release dll
	FreeLibrary(hlib);
}

void CSTATUS::OnCancel() 
{
	// TODO: Add extra cleanup here
	m_stop.EnableWindow(FALSE);
	m_start.EnableWindow(TRUE);
	UpdateData(FALSE);	

    //Destroy the specified timer
	KillTimer(m_bTimer);
	
	//Interface show ashy  
	m_paperend.SetIcon(IDI_BLACK);
	m_papernearend.SetIcon(IDI_BLACK);
	m_cutter.SetIcon(IDI_BLACK);
	m_coveropen.SetIcon(IDI_BLACK);
	m_cashdrawer.SetIcon(IDI_BLACK);
	m_busy.SetIcon(IDI_BLACK);
	m_restorable.SetIcon(IDI_BLACK);
	m_autorestorable.SetIcon(IDI_BLACK);
	m_feedkey.SetIcon(IDI_BLACK);
	m_offline.SetIcon(IDI_BLACK);

		//Release dll
	FreeLibrary(hlib);

	CDialog::OnCancel();
}

BOOL CSTATUS::OnHelpInfo(HELPINFO* pHelpInfo) 
{
	// TODO: Add your message handler code here and/or call default	
	ShellExecute(NULL,"open",".\\NetPrnStatusDemo Guid.chm",NULL,NULL,SW_SHOW);
	return TRUE;
}
