// DlgID.cpp : implementation file
//

#include "stdafx.h"
#include "TestUSB.h"
#include "DlgID.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CDlgID dialog


CDlgID::CDlgID(CWnd* pParent /*=NULL*/)
	: CDialog(CDlgID::IDD, pParent)
{
	//{{AFX_DATA_INIT(CDlgID)
	m_PrintID = 0;
	//}}AFX_DATA_INIT
}


void CDlgID::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CDlgID)
	DDX_Text(pDX, IDC_EDIT1, m_PrintID);
	DDV_MinMaxUInt(pDX, m_PrintID, 0, 500);
	//}}AFX_DATA_MAP
}


BEGIN_MESSAGE_MAP(CDlgID, CDialog)
	//{{AFX_MSG_MAP(CDlgID)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CDlgID message handlers

void CDlgID::OnOK() 
{
	// TODO: Add extra validation here
	
	CDialog::OnOK();
}

void CDlgID::OnCancel() 
{
	// TODO: Add extra cleanup here
	
	CDialog::OnCancel();
}

int CDlgID::DoModal() 
{
	// TODO: Add your specialized code here and/or call the base class
	
	return CDialog::DoModal();
}
