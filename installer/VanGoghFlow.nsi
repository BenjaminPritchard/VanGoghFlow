; Script generated with the Venis Install Wizard

; Define your application name
!define APPNAME "Van Gogh Flow"
!define APPNAMEANDVERSION "Van Gogh Flow 1.5"

; Main Install settings
Name "${APPNAMEANDVERSION}"
InstallDir "$PROGRAMFILES\Van Gogh Flow"
InstallDirRegKey HKLM "Software\${APPNAME}" ""
OutFile "VanGoghFlowx64-1.5.exe"

; Modern interface settings
!include "MUI.nsh"

!define MUI_ABORTWARNING
!define MUI_FINISHPAGE_RUN "$INSTDIR\VanGoghFlow.exe"

!insertmacro MUI_PAGE_WELCOME
!insertmacro MUI_PAGE_DIRECTORY
!insertmacro MUI_PAGE_INSTFILES
!insertmacro MUI_PAGE_FINISH

!insertmacro MUI_UNPAGE_CONFIRM
!insertmacro MUI_UNPAGE_INSTFILES

; Set languages (first is default language)
!insertmacro MUI_LANGUAGE "English"
!insertmacro MUI_RESERVEFILE_LANGDLL

Section "Van Gogh Flow" Section1

	; Set Section properties
	SetOverwrite on

	; Set Section Files and Shortcuts
	SetOutPath "$INSTDIR\"
	File "..\VanGoghFlow\bin\x64\Release\VanGoghFlow.ini"
	File "..\VanGoghFlow\bin\x64\Release\help.txt"
	File "..\VanGoghFlow\bin\x64\Release\cef.pak"
	File "..\VanGoghFlow\bin\x64\Release\CefSharp.BrowserSubprocess.Core.dll"
	File "..\VanGoghFlow\bin\x64\Release\CefSharp.BrowserSubprocess.Core.pdb"
	File "..\VanGoghFlow\bin\x64\Release\CefSharp.BrowserSubprocess.exe"
	File "..\VanGoghFlow\bin\x64\Release\CefSharp.BrowserSubprocess.pdb"
	File "..\VanGoghFlow\bin\x64\Release\CefSharp.Core.dll"
	File "..\VanGoghFlow\bin\x64\Release\CefSharp.Core.pdb"
	File "..\VanGoghFlow\bin\x64\Release\CefSharp.Core.xml"
	File "..\VanGoghFlow\bin\x64\Release\CefSharp.dll"
	File "..\VanGoghFlow\bin\x64\Release\CefSharp.pdb"
	File "..\VanGoghFlow\bin\x64\Release\CefSharp.WinForms.dll"
	File "..\VanGoghFlow\bin\x64\Release\CefSharp.WinForms.pdb"
	File "..\VanGoghFlow\bin\x64\Release\CefSharp.WinForms.XML"
	File "..\VanGoghFlow\bin\x64\Release\CefSharp.XML"
	File "..\VanGoghFlow\bin\x64\Release\cef_100_percent.pak"
	File "..\VanGoghFlow\bin\x64\Release\cef_200_percent.pak"
	File "..\VanGoghFlow\bin\x64\Release\cef_extensions.pak"
	File "..\VanGoghFlow\bin\x64\Release\chrome_elf.dll"
	File "..\VanGoghFlow\bin\x64\Release\d3dcompiler_47.dll"
	File "..\VanGoghFlow\bin\x64\Release\devtools_resources.pak"
	File "..\VanGoghFlow\bin\x64\Release\icudtl.dat"
	File "..\VanGoghFlow\bin\x64\Release\libcef.dll"
	File "..\VanGoghFlow\bin\x64\Release\libEGL.dll"
	File "..\VanGoghFlow\bin\x64\Release\libGLESv2.dll"
	File "..\VanGoghFlow\bin\x64\Release\README.txt"
	File "..\VanGoghFlow\bin\x64\Release\snapshot_blob.bin"
	File "..\VanGoghFlow\bin\x64\Release\v8_context_snapshot.bin"
	File "..\VanGoghFlow\bin\x64\Release\VanGoghFlow.exe"
	File "..\VanGoghFlow\bin\x64\Release\VanGoghFlow.exe.config"
	File "..\VanGoghFlow\bin\x64\Release\VanGoghFlow.pdb"
	SetOutPath "$INSTDIR\locales\"
	File "..\VanGoghFlow\bin\x64\Release\locales\am.pak"
	File "..\VanGoghFlow\bin\x64\Release\locales\ar.pak"
	File "..\VanGoghFlow\bin\x64\Release\locales\bg.pak"
	File "..\VanGoghFlow\bin\x64\Release\locales\bn.pak"
	File "..\VanGoghFlow\bin\x64\Release\locales\ca.pak"
	File "..\VanGoghFlow\bin\x64\Release\locales\cs.pak"
	File "..\VanGoghFlow\bin\x64\Release\locales\da.pak"
	File "..\VanGoghFlow\bin\x64\Release\locales\de.pak"
	File "..\VanGoghFlow\bin\x64\Release\locales\el.pak"
	File "..\VanGoghFlow\bin\x64\Release\locales\en-GB.pak"
	File "..\VanGoghFlow\bin\x64\Release\locales\en-US.pak"
	File "..\VanGoghFlow\bin\x64\Release\locales\es-419.pak"
	File "..\VanGoghFlow\bin\x64\Release\locales\es.pak"
	File "..\VanGoghFlow\bin\x64\Release\locales\et.pak"
	File "..\VanGoghFlow\bin\x64\Release\locales\fa.pak"
	File "..\VanGoghFlow\bin\x64\Release\locales\fi.pak"
	File "..\VanGoghFlow\bin\x64\Release\locales\fil.pak"
	File "..\VanGoghFlow\bin\x64\Release\locales\fr.pak"
	File "..\VanGoghFlow\bin\x64\Release\locales\gu.pak"
	File "..\VanGoghFlow\bin\x64\Release\locales\he.pak"
	File "..\VanGoghFlow\bin\x64\Release\locales\hi.pak"
	File "..\VanGoghFlow\bin\x64\Release\locales\hr.pak"
	File "..\VanGoghFlow\bin\x64\Release\locales\hu.pak"
	File "..\VanGoghFlow\bin\x64\Release\locales\id.pak"
	File "..\VanGoghFlow\bin\x64\Release\locales\it.pak"
	File "..\VanGoghFlow\bin\x64\Release\locales\ja.pak"
	File "..\VanGoghFlow\bin\x64\Release\locales\kn.pak"
	File "..\VanGoghFlow\bin\x64\Release\locales\ko.pak"
	File "..\VanGoghFlow\bin\x64\Release\locales\lt.pak"
	File "..\VanGoghFlow\bin\x64\Release\locales\lv.pak"
	File "..\VanGoghFlow\bin\x64\Release\locales\ml.pak"
	File "..\VanGoghFlow\bin\x64\Release\locales\mr.pak"
	File "..\VanGoghFlow\bin\x64\Release\locales\ms.pak"
	File "..\VanGoghFlow\bin\x64\Release\locales\nb.pak"
	File "..\VanGoghFlow\bin\x64\Release\locales\nl.pak"
	File "..\VanGoghFlow\bin\x64\Release\locales\pl.pak"
	File "..\VanGoghFlow\bin\x64\Release\locales\pt-BR.pak"
	File "..\VanGoghFlow\bin\x64\Release\locales\pt-PT.pak"
	File "..\VanGoghFlow\bin\x64\Release\locales\ro.pak"
	File "..\VanGoghFlow\bin\x64\Release\locales\ru.pak"
	File "..\VanGoghFlow\bin\x64\Release\locales\sk.pak"
	File "..\VanGoghFlow\bin\x64\Release\locales\sl.pak"
	File "..\VanGoghFlow\bin\x64\Release\locales\sr.pak"
	File "..\VanGoghFlow\bin\x64\Release\locales\sv.pak"
	File "..\VanGoghFlow\bin\x64\Release\locales\sw.pak"
	File "..\VanGoghFlow\bin\x64\Release\locales\ta.pak"
	File "..\VanGoghFlow\bin\x64\Release\locales\te.pak"
	File "..\VanGoghFlow\bin\x64\Release\locales\th.pak"
	File "..\VanGoghFlow\bin\x64\Release\locales\tr.pak"
	File "..\VanGoghFlow\bin\x64\Release\locales\uk.pak"
	File "..\VanGoghFlow\bin\x64\Release\locales\vi.pak"
	File "..\VanGoghFlow\bin\x64\Release\locales\zh-CN.pak"
	File "..\VanGoghFlow\bin\x64\Release\locales\zh-TW.pak"
	SetOutPath "$INSTDIR\swiftshader\"
	File "..\VanGoghFlow\bin\x64\Release\swiftshader\libEGL.dll"
	File "..\VanGoghFlow\bin\x64\Release\swiftshader\libGLESv2.dll"
	
	CreateShortCut "$DESKTOP\Van Gogh Flow.lnk" "$INSTDIR\VanGoghFlow.exe"
	CreateDirectory "$SMPROGRAMS\Van Gogh Flow"
	CreateShortCut "$SMPROGRAMS\Van Gogh Flow\Van Gogh Flow.lnk" "$INSTDIR\VanGoghFlow.exe"
	CreateShortCut "$SMPROGRAMS\Van Gogh Flow\Uninstall.lnk" "$INSTDIR\uninstall.exe"

SectionEnd

Section -FinishSection

	WriteRegStr HKLM "Software\${APPNAME}" "" "$INSTDIR"
	WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${APPNAME}" "DisplayName" "${APPNAME}"
	WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${APPNAME}" "UninstallString" "$INSTDIR\uninstall.exe"
	WriteUninstaller "$INSTDIR\uninstall.exe"

SectionEnd

; Modern install component descriptions
!insertmacro MUI_FUNCTION_DESCRIPTION_BEGIN
	!insertmacro MUI_DESCRIPTION_TEXT ${Section1} ""
!insertmacro MUI_FUNCTION_DESCRIPTION_END

;Uninstall section
Section Uninstall

	;Remove from registry...
	DeleteRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${APPNAME}"
	DeleteRegKey HKLM "SOFTWARE\${APPNAME}"

	; Delete self
	Delete "$INSTDIR\uninstall.exe"

	; Delete Shortcuts
	Delete "$DESKTOP\Van Gogh Flow.lnk"
	Delete "$SMPROGRAMS\Van Gogh Flow\Van Gogh Flow.lnk"
	Delete "$SMPROGRAMS\Van Gogh Flow\Uninstall.lnk"

	; Clean up Van Gogh Flow
	Delete "$INSTDIR\cef.pak"
	Delete "$INSTDIR\CefSharp.BrowserSubprocess.Core.dll"
	Delete "$INSTDIR\CefSharp.BrowserSubprocess.Core.pdb"
	Delete "$INSTDIR\CefSharp.BrowserSubprocess.exe"
	Delete "$INSTDIR\CefSharp.BrowserSubprocess.pdb"
	Delete "$INSTDIR\CefSharp.Core.dll"
	Delete "$INSTDIR\CefSharp.Core.pdb"
	Delete "$INSTDIR\CefSharp.Core.xml"
	Delete "$INSTDIR\CefSharp.dll"
	Delete "$INSTDIR\CefSharp.pdb"
	Delete "$INSTDIR\CefSharp.WinForms.dll"
	Delete "$INSTDIR\CefSharp.WinForms.pdb"
	Delete "$INSTDIR\CefSharp.WinForms.XML"
	Delete "$INSTDIR\CefSharp.XML"
	Delete "$INSTDIR\cef_100_percent.pak"
	Delete "$INSTDIR\cef_200_percent.pak"
	Delete "$INSTDIR\cef_extensions.pak"
	Delete "$INSTDIR\chrome_elf.dll"
	Delete "$INSTDIR\d3dcompiler_47.dll"
	Delete "$INSTDIR\debug.log"
	Delete "$INSTDIR\devtools_resources.pak"
	Delete "$INSTDIR\icudtl.dat"
	Delete "$INSTDIR\libcef.dll"
	Delete "$INSTDIR\libEGL.dll"
	Delete "$INSTDIR\libGLESv2.dll"
	Delete "$INSTDIR\natives_blob.bin"
	Delete "$INSTDIR\README.txt"
	Delete "$INSTDIR\snapshot_blob.bin"
	Delete "$INSTDIR\v8_context_snapshot.bin"
	Delete "$INSTDIR\VanGoghFlow.exe"
	Delete "$INSTDIR\VanGoghFlow.exe.config"
	Delete "$INSTDIR\VanGoghFlow.pdb"
	Delete "$INSTDIR\locales\am.pak"
	Delete "$INSTDIR\locales\ar.pak"
	Delete "$INSTDIR\locales\bg.pak"
	Delete "$INSTDIR\locales\bn.pak"
	Delete "$INSTDIR\locales\ca.pak"
	Delete "$INSTDIR\locales\cs.pak"
	Delete "$INSTDIR\locales\da.pak"
	Delete "$INSTDIR\locales\de.pak"
	Delete "$INSTDIR\locales\el.pak"
	Delete "$INSTDIR\locales\en-GB.pak"
	Delete "$INSTDIR\locales\en-US.pak"
	Delete "$INSTDIR\locales\es-419.pak"
	Delete "$INSTDIR\locales\es.pak"
	Delete "$INSTDIR\locales\et.pak"
	Delete "$INSTDIR\locales\fa.pak"
	Delete "$INSTDIR\locales\fi.pak"
	Delete "$INSTDIR\locales\fil.pak"
	Delete "$INSTDIR\locales\fr.pak"
	Delete "$INSTDIR\locales\gu.pak"
	Delete "$INSTDIR\locales\he.pak"
	Delete "$INSTDIR\locales\hi.pak"
	Delete "$INSTDIR\locales\hr.pak"
	Delete "$INSTDIR\locales\hu.pak"
	Delete "$INSTDIR\locales\id.pak"
	Delete "$INSTDIR\locales\it.pak"
	Delete "$INSTDIR\locales\ja.pak"
	Delete "$INSTDIR\locales\kn.pak"
	Delete "$INSTDIR\locales\ko.pak"
	Delete "$INSTDIR\locales\lt.pak"
	Delete "$INSTDIR\locales\lv.pak"
	Delete "$INSTDIR\locales\ml.pak"
	Delete "$INSTDIR\locales\mr.pak"
	Delete "$INSTDIR\locales\ms.pak"
	Delete "$INSTDIR\locales\nb.pak"
	Delete "$INSTDIR\locales\nl.pak"
	Delete "$INSTDIR\locales\pl.pak"
	Delete "$INSTDIR\locales\pt-BR.pak"
	Delete "$INSTDIR\locales\pt-PT.pak"
	Delete "$INSTDIR\locales\ro.pak"
	Delete "$INSTDIR\locales\ru.pak"
	Delete "$INSTDIR\locales\sk.pak"
	Delete "$INSTDIR\locales\sl.pak"
	Delete "$INSTDIR\locales\sr.pak"
	Delete "$INSTDIR\locales\sv.pak"
	Delete "$INSTDIR\locales\sw.pak"
	Delete "$INSTDIR\locales\ta.pak"
	Delete "$INSTDIR\locales\te.pak"
	Delete "$INSTDIR\locales\th.pak"
	Delete "$INSTDIR\locales\tr.pak"
	Delete "$INSTDIR\locales\uk.pak"
	Delete "$INSTDIR\locales\vi.pak"
	Delete "$INSTDIR\locales\zh-CN.pak"
	Delete "$INSTDIR\locales\zh-TW.pak"
	Delete "$INSTDIR\swiftshader\libEGL.dll"
	Delete "$INSTDIR\swiftshader\libGLESv2.dll"
	Delete "$INSTDIR\swiftshader\VanGoghFlow.ini"

	; Remove remaining directories
	RMDir "$SMPROGRAMS\Van Gogh Flow"
	RMDir "$INSTDIR\swiftshader\"
	RMDir "$INSTDIR\locales\"
	RMDir "$INSTDIR\"

SectionEnd

BrandingText "A program for gently inducing connected flow states"

; eof