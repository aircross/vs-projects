#if !defined(AFX_STATUS_H__607A25DE_904C_4B22_B37E_6CE247272AF4__INCLUDED_)
#define AFX_STATUS_H__607A25DE_904C_4B22_B37E_6CE247272AF4__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000
// STATUS.h : header file
//

/////////////////////////////////////////////////////////////////////////////

//Define finger and returning value of variable
typedef int (__stdcall *mNetGetStatus)(char *ipaddr,unsigned char *tobuf,int length,int connecttime,int readtime); 


// CSTATUS dialog

class CSTATUS : public CDialog
{
// Construction
public:
	char ipaddr[50];
	CSTATUS(CWnd* pParent = NULL);   // standard constructor
	BOOL m_bTimer;
    HINSTANCE hlib; // dll handle
// Dialog Data
	//{{AFX_DATA(CSTATUS)
	enum { IDD = IDD_MONITOR };
	CButton	m_stop;
	CButton	m_start;
	//}}AFX_DATA


// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CSTATUS)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:

	// Generated message map functions
	//{{AFX_MSG(CSTATUS)
	virtual BOOL OnInitDialog();
	afx_msg void OnPaint();
	afx_msg void OnTimer(UINT nIDEvent);
	afx_msg void OnStart();
	afx_msg void OnStop();
	virtual void OnCancel();
	afx_msg BOOL OnHelpInfo(HELPINFO* pHelpInfo);
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STATUS_H__607A25DE_904C_4B22_B37E_6CE247272AF4__INCLUDED_)
