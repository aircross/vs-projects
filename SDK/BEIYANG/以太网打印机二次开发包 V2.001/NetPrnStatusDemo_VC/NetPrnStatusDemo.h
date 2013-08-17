// NetPrnStatusDemo.h : main header file for the NETPRNSTATUSDEMO application
//

#if !defined(AFX_NETPRNSTATUSDEMO_H__80E1C3C0_FC19_42E6_AB33_3FA97EDB0278__INCLUDED_)
#define AFX_NETPRNSTATUSDEMO_H__80E1C3C0_FC19_42E6_AB33_3FA97EDB0278__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#ifndef __AFXWIN_H__
	#error include 'stdafx.h' before including this file for PCH
#endif

#include "resource.h"		// main symbols

/////////////////////////////////////////////////////////////////////////////
// CNetPrnStatusDemoApp:
// See NetPrnStatusDemo.cpp for the implementation of this class
//

class CNetPrnStatusDemoApp : public CWinApp
{
public:
	CNetPrnStatusDemoApp();

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CNetPrnStatusDemoApp)
	public:
	virtual BOOL InitInstance();
	//}}AFX_VIRTUAL

// Implementation

	//{{AFX_MSG(CNetPrnStatusDemoApp)
		// NOTE - the ClassWizard will add and remove member functions here.
		//    DO NOT EDIT what you see in these blocks of generated code !
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};


/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_NETPRNSTATUSDEMO_H__80E1C3C0_FC19_42E6_AB33_3FA97EDB0278__INCLUDED_)
