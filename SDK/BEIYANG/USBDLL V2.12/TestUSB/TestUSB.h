// TestUSB.h : main header file for the TESTUSB application
//

#if !defined(AFX_TESTUSB_H__F3B6CC35_F26D_42AE_AB2F_829F69E098C6__INCLUDED_)
#define AFX_TESTUSB_H__F3B6CC35_F26D_42AE_AB2F_829F69E098C6__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#ifndef __AFXWIN_H__
	#error include 'stdafx.h' before including this file for PCH
#endif

#include "resource.h"       // main symbols

/////////////////////////////////////////////////////////////////////////////
// CTestUSBApp:
// See TestUSB.cpp for the implementation of this class
//

class CTestUSBApp : public CWinApp
{
public:
	CTestUSBApp();

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CTestUSBApp)
	public:
	virtual BOOL InitInstance();
	//}}AFX_VIRTUAL

// Implementation
	//{{AFX_MSG(CTestUSBApp)
	afx_msg void OnAppAbout();
		// NOTE - the ClassWizard will add and remove member functions here.
		//    DO NOT EDIT what you see in these blocks of generated code !
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};


/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_TESTUSB_H__F3B6CC35_F26D_42AE_AB2F_829F69E098C6__INCLUDED_)
