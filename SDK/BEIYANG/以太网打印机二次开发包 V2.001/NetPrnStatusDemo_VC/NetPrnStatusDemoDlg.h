// NetPrnStatusDemoDlg.h : header file
//

#if !defined(AFX_NETPRNSTATUSDEMODLG_H__E8C01091_BC69_46E8_BFB9_F570D1844D5A__INCLUDED_)
#define AFX_NETPRNSTATUSDEMODLG_H__E8C01091_BC69_46E8_BFB9_F570D1844D5A__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

/////////////////////////////////////////////////////////////////////////////

typedef bool (__stdcall *mNetWriteOpen)(char *ipaddr,int connecttime);
typedef int  (__stdcall *mNetWrite)(char *databuf,int len,int writetime);
typedef bool (__stdcall *mNetWriteClose)();
typedef int  (__stdcall *mNetGetPrinterIP)(char *iplist);
// CNetPrnStatusDemoDlg dialog

class CNetPrnStatusDemoDlg : public CDialog
{
// Construction
public:
	CNetPrnStatusDemoDlg(CWnd* pParent = NULL);	// standard constructor
	CString ipstr;
	CString iplist;
// Dialog Data
	//{{AFX_DATA(CNetPrnStatusDemoDlg)
	enum { IDD = IDD_NETPRNSTATUSDEMO_DIALOG };
	CComboBox	m_iplist;	
	CIPAddressCtrl	ip;
	int		m_option;
	//}}AFX_DATA

	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CNetPrnStatusDemoDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	//{{AFX_MSG(CNetPrnStatusDemoDlg)
	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	afx_msg void OnButton4();
	afx_msg void OnManufacturer();
	afx_msg void OnPrint();
	afx_msg void OnStatus();
	afx_msg void OnFieldchangedIpaddress1(NMHDR* pNMHDR, LRESULT* pResult);
	afx_msg void OnRadio1();
	afx_msg void OnRadio2();
	afx_msg void OnSelchangeCombo2();
	afx_msg BOOL OnHelpInfo(HELPINFO* pHelpInfo);
	afx_msg void OnSelchangeCombo1();
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_NETPRNSTATUSDEMODLG_H__E8C01091_BC69_46E8_BFB9_F570D1844D5A__INCLUDED_)
