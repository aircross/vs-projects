// TestUSBView.h : interface of the CTestUSBView class
//
/////////////////////////////////////////////////////////////////////////////

#if !defined(AFX_TESTUSBVIEW_H__141AD4AD_41F6_4E9C_8C9F_AD2DB7C7940A__INCLUDED_)
#define AFX_TESTUSBVIEW_H__141AD4AD_41F6_4E9C_8C9F_AD2DB7C7940A__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

class CTestUSBView;

struct CThreadParam {
	CTestUSBView* testView;
	UINT uiLength;
//    char * pcIoBuffer;
public:
};

class CTestUSBView : public CView
{
protected: // create from serialization only
	CTestUSBView();
	DECLARE_DYNCREATE(CTestUSBView)

// Attributes
public:
	CTestUSBDoc* GetDocument();

	CWinThread *m_hWriteThread, *m_hReadThread;
	CThreadParam m_write, m_read;

// Operations
public:
//HANDLE hdev; // device handle
//HINSTANCE hlib; 
//CString str;
// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CTestUSBView)
	public:
	virtual void OnDraw(CDC* pDC);  // overridden to draw this view
	virtual BOOL PreCreateWindow(CREATESTRUCT& cs);
	protected:
	//}}AFX_VIRTUAL

// Implementation
public:
	void ShowMessage(CString str);
	virtual ~CTestUSBView();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:

// Generated message map functions
protected:
	//{{AFX_MSG(CTestUSBView)
	afx_msg void OnBulkRead();
	afx_msg void OnBulkWrite();
	afx_msg void OnCloseDevice();
	afx_msg void OnSpecificStatus();
	afx_msg void OnAutostatusReturn();
	afx_msg bool OnOpenDevice();
	afx_msg void OnGetDllversion();
	afx_msg void OnOpendeviceByname();
	afx_msg void OnAbortWpipe();
	afx_msg void OnAbortRpipe();
	afx_msg void OnClearError();
	afx_msg void OnResetCommand();
	afx_msg void OnWriteScommand();
	afx_msg void OnOpendeviceByname2();
	afx_msg void OnSetTimeouts();
	afx_msg void OnOpenDeviceByInternalID();
	afx_msg void OnGetDriverVersion();
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

#ifndef _DEBUG  // debug version in TestUSBView.cpp
inline CTestUSBDoc* CTestUSBView::GetDocument()
   { return (CTestUSBDoc*)m_pDocument; }
#endif

/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_TESTUSBVIEW_H__141AD4AD_41F6_4E9C_8C9F_AD2DB7C7940A__INCLUDED_)
