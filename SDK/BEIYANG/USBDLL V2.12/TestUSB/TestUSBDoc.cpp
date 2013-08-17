// TestUSBDoc.cpp : implementation of the CTestUSBDoc class
//

#include "stdafx.h"
#include "TestUSB.h"

#include "TestUSBDoc.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CTestUSBDoc

IMPLEMENT_DYNCREATE(CTestUSBDoc, CDocument)

BEGIN_MESSAGE_MAP(CTestUSBDoc, CDocument)
	//{{AFX_MSG_MAP(CTestUSBDoc)
		// NOTE - the ClassWizard will add and remove mapping macros here.
		//    DO NOT EDIT what you see in these blocks of generated code!
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CTestUSBDoc construction/destruction

CTestUSBDoc::CTestUSBDoc()
{
	// TODO: add one-time construction code here

}

CTestUSBDoc::~CTestUSBDoc()
{
}

BOOL CTestUSBDoc::OnNewDocument()
{
	if (!CDocument::OnNewDocument())
		return FALSE;

	// TODO: add reinitialization code here
	// (SDI documents will reuse this document)

	return TRUE;
}



/////////////////////////////////////////////////////////////////////////////
// CTestUSBDoc serialization

void CTestUSBDoc::Serialize(CArchive& ar)
{
	if (ar.IsStoring())
	{
		// TODO: add storing code here
	}
	else
	{
		// TODO: add loading code here
	}
}

/////////////////////////////////////////////////////////////////////////////
// CTestUSBDoc diagnostics

#ifdef _DEBUG
void CTestUSBDoc::AssertValid() const
{
	CDocument::AssertValid();
}

void CTestUSBDoc::Dump(CDumpContext& dc) const
{
	CDocument::Dump(dc);
}
#endif //_DEBUG

/////////////////////////////////////////////////////////////////////////////
// CTestUSBDoc commands
