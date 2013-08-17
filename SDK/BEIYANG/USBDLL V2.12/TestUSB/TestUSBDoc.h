// TestUSBDoc.h : interface of the CTestUSBDoc class
//
/////////////////////////////////////////////////////////////////////////////

#if !defined(AFX_TESTUSBDOC_H__89E792D4_3DBC_42B1_8CBE_B8D45A62BECF__INCLUDED_)
#define AFX_TESTUSBDOC_H__89E792D4_3DBC_42B1_8CBE_B8D45A62BECF__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000


class CTestUSBDoc : public CDocument
{
protected: // create from serialization only
	CTestUSBDoc();
	DECLARE_DYNCREATE(CTestUSBDoc)

// Attributes
public:

// Operations
public:

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CTestUSBDoc)
	public:
	virtual BOOL OnNewDocument();
	virtual void Serialize(CArchive& ar);
	//}}AFX_VIRTUAL

// Implementation
public:
	virtual ~CTestUSBDoc();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:

// Generated message map functions
protected:
	//{{AFX_MSG(CTestUSBDoc)
		// NOTE - the ClassWizard will add and remove member functions here.
		//    DO NOT EDIT what you see in these blocks of generated code !
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_TESTUSBDOC_H__89E792D4_3DBC_42B1_8CBE_B8D45A62BECF__INCLUDED_)
