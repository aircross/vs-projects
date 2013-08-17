#if !defined(AFX_DLGID_H__618025DD_5B03_4FE5_A684_68B4F1356F4A__INCLUDED_)
#define AFX_DLGID_H__618025DD_5B03_4FE5_A684_68B4F1356F4A__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000
// DlgID.h : header file
//

/////////////////////////////////////////////////////////////////////////////
// CDlgID dialog

class CDlgID : public CDialog
{
// Construction
public:
	CDlgID(CWnd* pParent = NULL);   // standard constructor

// Dialog Data
	//{{AFX_DATA(CDlgID)
	enum { IDD = IDD_ID };
	UINT	m_PrintID;
	//}}AFX_DATA


// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CDlgID)
	public:
	virtual int DoModal();
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:

	// Generated message map functions
	//{{AFX_MSG(CDlgID)
	virtual void OnOK();
	virtual void OnCancel();
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_DLGID_H__618025DD_5B03_4FE5_A684_68B4F1356F4A__INCLUDED_)
