// MFCLibrary1.h : Hauptheaderdatei für die MFCLibrary1-DLL
//

#pragma once

#ifndef __AFXWIN_H__
	#error "'stdafx.h' vor dieser Datei für PCH einschließen"
#endif

#include "resource.h"		// Hauptsymbole


// CMFCLibrary1App
// Siehe MFCLibrary1.cpp für die Implementierung dieser Klasse
//

class CMFCLibrary1App : public CWinApp
{
public:
	CMFCLibrary1App();

// Überschreibungen
public:
	virtual BOOL InitInstance();

	DECLARE_MESSAGE_MAP()
};
