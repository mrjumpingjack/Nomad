// MFCLibrary1.h : Hauptheaderdatei f�r die MFCLibrary1-DLL
//

#pragma once

#ifndef __AFXWIN_H__
	#error "'stdafx.h' vor dieser Datei f�r PCH einschlie�en"
#endif

#include "resource.h"		// Hauptsymbole


// CMFCLibrary1App
// Siehe MFCLibrary1.cpp f�r die Implementierung dieser Klasse
//

class CMFCLibrary1App : public CWinApp
{
public:
	CMFCLibrary1App();

// �berschreibungen
public:
	virtual BOOL InitInstance();

	DECLARE_MESSAGE_MAP()
};
