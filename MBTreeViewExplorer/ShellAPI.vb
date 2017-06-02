#Region " Import"
Imports System
Imports System.Text
Imports System.Runtime.InteropServices
#End Region

#Region "Shell Api Class"
''' <summary>
''' ShellAPI Class for MBTreeViewExplorer
''' </summary>
Public Class ShellAPI

#Region "       Constants"

    Public Const MAX_PATH As Integer = 260
    Public Const FILE_ATTRIBUTE_NORMAL As Integer = &H80
    Public Shared IID_IShellFolder As New Guid("{000214E6-0000-0000-C000-000000000046}")
    Public Shared DesktopGUID As New Guid("{00021400-0000-0000-C000-000000000046}")
    Public Shared IID_IDropTarget As New Guid("{00000122-0000-0000-C000-000000000046}")
    Public Const NOERROR As Integer = 0
    Public Const CMD_FIRST As UInteger = 1
    Public Const CMD_LAST As UInteger = 30000

#End Region

#Region "       DLL Imports"

#Region "           Send Message"
    '''<Summary>
    '''   Sends a message to some Window
    '''</Summary>
    Declare Auto Function SendMessage Lib "user32" ( _
        ByVal hWnd As IntPtr, _
        ByVal wMsg As Integer, _
        ByVal wParam As Integer, _
        ByVal lParam As IntPtr) As Integer
#End Region

#Region "           SHGetDesktopFolder"
    '''<Summary>
    ''' Retrieves the IShellFolder interface for the desktop folder, which is the root of the Shell's namespace. 
    '''<param>ppshf -- Recieves the IShellFolder interface for the desktop folder</param>
    ''' </Summary>
    Declare Auto Function SHGetDesktopFolder Lib "shell32.dll" ( _
                ByRef ppshf As IShellFolder) As Integer
#End Region

#Region "           SHGetFileInfo"
    ''' <Summary>
    '''  SHGetFileInfo  - for a given Path as a string
    ''' </Summary>
    Declare Auto Function SHGetFileInfo Lib "shell32" ( _
         ByVal pszPath As String, _
         ByVal dwFileAttributes As Integer, _
         ByRef sfi As SHFILEINFO, _
         ByVal cbsfi As Integer, _
         ByVal uFlags As Integer) As IntPtr
    ''' <Summary>
    '''  SHGetFileInfo  - for a given ItemIDList as IntPtr
    ''' </Summary>
    Declare Auto Function SHGetFileInfo Lib "shell32" ( _
             ByVal ppidl As IntPtr, _
             ByVal dwFileAttributes As Integer, _
             ByRef sfi As SHFILEINFO, _
             ByVal cbsfi As Integer, _
             ByVal uFlags As Integer) As IntPtr
#End Region

#Region "           SHGetSpecialFolderLocation"

    Declare Function SHGetSpecialFolderLocation Lib "Shell32" ( _
        ByVal hWndOwner As Integer, _
        ByVal csidl As Integer, _
        ByRef ppidl As IntPtr) As Integer
#End Region

    Declare Auto Function StrRetToBuf Lib "shlwapi.dll" ( _
                    ByVal pstr As IntPtr, _
                    ByVal pidl As IntPtr, _
                    ByVal pszBuf As StringBuilder, _
                    <MarshalAs(UnmanagedType.U4)> _
                    ByVal cchBuf As Integer) As Integer

    Declare Auto Function ILIsEqual Lib "shell32" Alias "#21" ( _
                            ByVal pidl1 As IntPtr, _
                            ByVal pidl2 As IntPtr) As Boolean

#End Region

#Region "       Enumerations"

    Public Enum SW
        HIDE = 0
        SHOWNORMAL = 1
        NORMAL = 1
        SHOWMINIMIZED = 2
        SHOWMAXIMIZED = 3
        MAXIMIZE = 3
        SHOWNOACTIVATE = 4
        SHOW = 5
        MINIMIZE = 6
        SHOWMINNOACTIVE = 7
        SHOWNA = 8
        RESTORE = 9
        SHOWDEFAULT = 10
    End Enum

    Public Enum CMIC
        HOTKEY = &H20
        ICON = &H10
        FLAG_NO_UI = &H400
        UNICODE = &H4000
        NO_CONSOLE = &H8000
        ASYNCOK = &H100000
        NOZONECHECKS = &H800000
        SHIFT_DOWN = &H10000000
        CONTROL_DOWN = &H40000000
        FLAG_LOG_USAGE = &H4000000
        PTINVOKE = &H20000000
    End Enum

#Region "           SHGDN"
    <Flags()> _
    Public Enum SHGDN
        NORMAL = 0
        INFOLDER = 1
        FORADDRESSBAR = 16384
        FORPARSING = 32768
    End Enum
#End Region

#Region "           SHCONTF"
    <Flags()> _
    Public Enum SHCONTF
        EMPTY = 0                      ' used to zero a SHCONTF variable
        FOLDERS = &H20                 ' only want folders enumerated (FOLDER)
        NONFOLDERS = &H40              ' include non folders
        INCLUDEHIDDEN = &H80           ' show items normally hidden
        INIT_ON_FIRST_NEXT = &H100     ' allow EnumObject() to return before validating enum
        NETPRINTERSRCH = &H200         ' hint that client is looking for printers
        SHAREABLE = &H400              ' hint that client is looking sharable resources (remote shares)
        STORAGE = &H800                ' include all items with accessible storage and their ancestors
        SYSTEM = &H1000
    End Enum
#End Region

#Region "           SFGAO"
    <Flags()> _
    Public Enum SFGAO
        CANCOPY = &H1                    ' Objects can be copied    
        CANMOVE = &H2                    ' Objects can be moved     
        CANLINK = &H4                    ' Objects can be linked    
        STORAGE = &H8                    ' supports BindToObject(IID_IStorage)
        CANRENAME = &H10                 ' Objects can be renamed
        CANDELETE = &H20                 ' Objects can be deleted
        HASPROPSHEET = &H40              ' Objects have property sheets
        DROPTARGET = &H100               ' Objects are drop target
        CAPABILITYMASK = &H177           ' This flag is a mask for the capability flags.
        ENCRYPTED = &H2000               ' object is encrypted (use alt color)
        ISSLOW = &H4000                  ' 'slow' object
        GHOSTED = &H8000                 ' ghosted icon
        LINK = &H10000                   ' Shortcut (link)
        SHARE = &H20000                  ' shared
        RDONLY = &H40000               ' read-only
        HIDDEN = &H80000                 ' hidden object
        DISPLAYATTRMASK = &HFC000        ' This flag is a mask for the display attributes.
        FILESYSANCESTOR = &H10000000     ' may contain children with FILESYSTEM
        FOLDER = &H20000000              ' support BindToObject(IID_IShellFolder)
        FILESYSTEM = &H40000000          ' is a win32 file system object (file/folder/root)
        HASSUBFOLDER = &H80000000        ' may contain children with FOLDER
        CONTENTSMASK = &H80000000        ' This flag is a mask for the contents attributes.
        VALIDATE = &H1000000             ' invalidate cached information
        REMOVABLE = &H2000000            ' is this removeable media?
        COMPRESSED = &H4000000           ' Object is compressed (use alt color)
        BROWSABLE = &H8000000            ' supports IShellFolder but only implements CreateViewObject() (non-folder view)
        NONENUMERATED = &H100000         ' is a non-enumerated object
        NEWCONTENT = &H200000            ' should show bold in explorer tree
        CANMONIKER = &H400000            ' defunct
        HASSTORAGE = &H400000            ' defunct
        STREAM = &H400000                ' supports BindToObject(IID_IStream)
        STORAGEANCESTOR = &H800000       ' may contain children with STORAGE or STREAM
        STORAGECAPMASK = &H70C50008      ' for determining storage capabilities ie for open/save semantics
    End Enum
#End Region

#Region "           E_STRRET"

    <Flags()> _
    Private Enum E_STRRET : int
        WSTR = &H0          ' Use STRRET.pOleStr
        OFFSET = &H1        ' Use STRRET.uOffset to Ansi
        C_STR = &H2         ' Use STRRET.cStr
    End Enum
#End Region

#Region "           SHGFI"
    <Flags()> _
    Public Enum SHGFI
        ICON = &H100                ' get icon 
        DISPLAYNAME = &H200         ' get display name 
        TYPENAME = &H400            ' get type name 
        ATTRIBUTES = &H800          ' get attributes 
        ICONLOCATION = &H1000       ' get icon location 
        EXETYPE = &H2000            ' return exe type 
        SYSICONINDEX = &H4000       ' get system icon index 
        LINKOVERLAY = &H8000        ' put a link overlay on icon 
        SELECTED = &H10000          ' show icon in selected state 
        ATTR_SPECIFIED = &H20000    ' get only specified attributes 
        LARGEICON = &H0             ' get large icon 
        SMALLICON = &H1             ' get small icon 
        OPENICON = &H2              ' get open icon 
        SHELLICONSIZE = &H4         ' get shell size icon 
        PIDL = &H8                  ' pszPath is a pidl 
        USEFILEATTRIBUTES = &H10    ' use passed dwFileAttribute 
        ADDOVERLAYS = &H20          ' apply the appropriate overlays
        OVERLAYINDEX = &H40         ' Get the index of the overlay
    End Enum
#End Region

#Region "           CSIDL"
    Public Enum CSIDL As Integer
        DESKTOP = &H0
        INTERNET = &H1
        PROGRAMS = &H2
        CONTROLS = &H3
        PRINTERS = &H4
        PERSONAL = &H5
        FAVORITES = &H6
        STARTUP = &H7
        RECENT = &H8
        SENDTO = &H9
        BITBUCKET = &HA
        STARTMENU = &HB
        MYDOCUMENTS = &HC
        MYMUSIC = &HD
        MYVIDEO = &HE
        DESKTOPDIRECTORY = &H10
        DRIVES = &H11
        NETWORK = &H12
        NETHOOD = &H13
        FONTS = &H14
        TEMPLATES = &H15
        COMMON_STARTMENU = &H16
        COMMON_PROGRAMS = &H17
        COMMON_STARTUP = &H18
        COMMON_DESKTOPDIRECTORY = &H19
        APPDATA = &H1A
        PRINTHOOD = &H1B
        LOCAL_APPDATA = &H1C
        ALTSTARTUP = &H1D
        COMMON_ALTSTARTUP = &H1E
        COMMON_FAVORITES = &H1F
        INTERNET_CACHE = &H20
        COOKIES = &H21
        HISTORY = &H22
        COMMON_APPDATA = &H23
        WINDOWS = &H24
        SYSTEM = &H25
        PROGRAM_FILES = &H26
        MYPICTURES = &H27
        PROFILE = &H28
        SYSTEMX86 = &H29
        PROGRAM_FILESX86 = &H2A
        PROGRAM_FILES_COMMON = &H2B
        PROGRAM_FILES_COMMONX86 = &H2C
        COMMON_TEMPLATES = &H2D
        COMMON_DOCUMENTS = &H2E
        COMMON_ADMINTOOLS = &H2F
        ADMINTOOLS = &H30
        CONNECTIONS = &H31
        COMMON_MUSIC = &H35
        COMMON_PICTURES = &H36
        COMMON_VIDEO = &H37
        RESOURCES = &H38
        RESOURCES_LOCALIZED = &H39
        COMMON_OEM_LINKS = &H3A
        CDBURN_AREA = &H3B
        COMPUTERSNEARME = &H3D
        FLAG_PER_USER_INIT = &H800
        FLAG_NO_ALIAS = &H1000
        FLAG_DONT_VERIFY = &H4000
        FLAG_CREATE = &H8000
        FLAG_MASK = &HFF00
    End Enum
#End Region

#Region "   SLGP --- IShellLink.GetPath Flags"
    <Flags()> _
    Public Enum SLGP
        SHORTPATH = &H1
        UNCPRIORITY = &H2
        RAWPATH = &H4
    End Enum
#End Region

#Region "   SLR --- IShellLink.Resolve Flags"
    <Flags()> _
    Public Enum SLR
        NO_UI = &H1
        ANY_MATCH = &H2
        UPDATE = &H4
        NOUPDATE = &H8
        NOSEARCH = &H10
        NOTRACK = &H20
        NOLINKINFO = &H40
        INVOKE_MSI = &H80
        NO_UI_WITH_MSG_PUMP = &H101
    End Enum
#End Region

#End Region

#Region "       Structures"

#Region "       SHFILEINFO"
    '///<Summary>
    ' SHFILEINFO structure for VB.Net
    '///</Summary>
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Auto)> _
    Public Structure SHFILEINFO
        Public hIcon As IntPtr
        Public iIcon As Integer
        Public dwAttributes As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=MAX_PATH)> _
        Public szDisplayName As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=80)> _
        Public szTypeName As String
    End Structure
    Private Shared shfitmp As SHFILEINFO   'just used for the following
    Public Shared cbFileInfo As Integer = Marshal.SizeOf(shfitmp.GetType())
#End Region

#Region "       W32_FIND_DATA"
    <StructLayoutAttribute(LayoutKind.Sequential, _
     CharSet:=CharSet.Auto)> _
     Public Structure WIN32_FIND_DATA
        Public dwFileAttributes As Integer
        Public ftCreationTime As ComTypes.FILETIME
        Public ftLastAccessTime As ComTypes.FILETIME
        Public ftLastWriteTime As ComTypes.FILETIME
        Public nFileSizeHigh As Integer
        Public nFileSizeLow As Integer
        Public dwReserved0 As Integer
        Public dwReserved1 As Integer
        <MarshalAs(UnmanagedType.ByValTStr, _
                   SizeConst:=MAX_PATH)> _
        Public cFileName As String
        <MarshalAs(UnmanagedType.ByValTStr, _
                   SizeConst:=14)> _
        Public cAlternateFileName As String
    End Structure

#End Region

#End Region

#Region "       Interfaces"

#Region "       Com Interop for IUnknown"
    <ComImport(), Guid("00000000-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
      Interface IUnknown

        <PreserveSig()> _
        Function QueryInterface(ByRef riid As Guid, ByRef pVoid As IntPtr) As Integer
        <PreserveSig()> _
         Function AddRef() As Integer
        <PreserveSig()> _
       Function Release() As Integer
    End Interface
#End Region

#Region "       COM Interop for IShellFolder"

    <ComImportAttribute(), _
    InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown), _
    Guid("000214E6-0000-0000-C000-000000000046")> _
Public Interface IShellFolder
        <PreserveSig()> _
        Function ParseDisplayName( _
            ByVal hwndOwner As Integer, _
            ByVal pbcReserved As IntPtr, _
            <MarshalAs(UnmanagedType.LPWStr)> _
            ByVal lpszDisplayName As String, _
            ByRef pchEaten As Integer, _
            ByRef ppidl As IntPtr, _
            ByRef pdwAttributes As Integer) As Integer

        <PreserveSig()> _
        Function EnumObjects( _
            ByVal hwndOwner As Integer, _
            <MarshalAs(UnmanagedType.U4)> ByVal _
            grfFlags As SHCONTF, _
            ByRef ppenumIDList As IEnumIDList) As Integer

        <PreserveSig()> _
        Function BindToObject( _
            ByVal pidl As IntPtr, _
            ByVal pbcReserved As IntPtr, _
            ByRef riid As Guid, _
            ByRef ppvOut As IShellFolder) As Integer

        <PreserveSig()> _
        Function BindToStorage( _
            ByVal pidl As IntPtr, _
            ByVal pbcReserved As IntPtr, _
            ByRef riid As Guid, _
            ByVal ppvObj As IntPtr) As Integer

        <PreserveSig()> _
        Function CompareIDs( _
            ByVal lParam As IntPtr, _
            ByVal pidl1 As IntPtr, _
            ByVal pidl2 As IntPtr) As Integer

        <PreserveSig()> _
        Function CreateViewObject( _
            ByVal hwndOwner As IntPtr, _
            ByRef riid As Guid, _
            ByRef ppvOut As IUnknown) As Integer

        <PreserveSig()> _
        Function GetAttributesOf( _
            ByVal cidl As Integer, _
            <MarshalAs(UnmanagedType.LPArray, sizeparamindex:=0)> _
            ByVal apidl() As IntPtr, _
            ByRef rgfInOut As SFGAO) As Integer

        <PreserveSig()> _
        Function GetUIObjectOf( _
            ByVal hwndOwner As IntPtr, _
            ByVal cidl As Integer, _
            <MarshalAs(UnmanagedType.LPArray, sizeparamindex:=0)> _
            ByVal apidl() As IntPtr, _
            ByRef riid As Guid, _
            ByRef prgfInOut As Integer, _
            ByRef ppvOut As IUnknown) As Integer
        'ByRef ppvOut As IDropTarget) As Integer

        <PreserveSig()> _
        Function GetDisplayNameOf( _
            ByVal pidl As IntPtr, _
            <MarshalAs(UnmanagedType.U4)> _
            ByVal uFlags As SHGDN, _
            ByVal lpName As IntPtr) As Integer

        <PreserveSig()> _
        Function SetNameOf( _
            ByVal hwndOwner As Integer, _
            ByVal pidl As IntPtr, _
            <MarshalAs(UnmanagedType.LPWStr)> ByVal _
            lpszName As String, _
            <MarshalAs(UnmanagedType.U4)> ByVal _
            uFlags As SHCONTF, _
            ByRef ppidlOut As IntPtr) As Integer
    End Interface

#End Region

#Region "       Com Interop for IEnumIDList"
    <ComImportAttribute(), _
     InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown), _
     Guid("000214F2-0000-0000-C000-000000000046")> _
        Public Interface IEnumIDList
        <PreserveSig()> _
        Function GetNext( _
            ByVal celt As Integer, _
            ByRef rgelt As IntPtr, _
            ByRef pceltFetched As Integer) As Integer

        <PreserveSig()> _
        Function Skip( _
            ByVal celt As Integer) As Integer

        <PreserveSig()> _
        Function Reset() As Integer

        <PreserveSig()> _
        Function Clone( _
            ByRef ppenum As IEnumIDList) As Integer
    End Interface

#End Region

#End Region

#Region "       GetSpecialFolderLocation"
    Public Shared Function GetSpecialFolderLocation(ByVal hWnd As IntPtr, ByVal csidl As Integer) As IntPtr
        Dim rVal As IntPtr
        Dim res As Integer
        res = SHGetSpecialFolderLocation(0, csidl, rVal)
        Return rVal
    End Function
#End Region

#Region "       ImageList_ReplaceIcon"
    Declare Auto Function ImageList_ReplaceIcon Lib "comctl32" _
                                    (ByVal hImageList As IntPtr, _
                                    ByVal IconIndex As Integer, _
                                    ByVal hIcon As IntPtr) _
                                    As Integer

#End Region

#Region "       ImageList_GetIcon"
    Declare Function ImageList_GetIcon Lib "comctl32" ( _
                ByVal himl As IntPtr, _
                ByVal i As Integer, _
                ByVal flags As Integer) As IntPtr
#End Region

#Region "       DestroyIcon"
    Declare Function DestroyIcon Lib "user32.dll" ( _
                ByVal hIcon As IntPtr) As Integer
#End Region

#Region "       ImageList Structures"
    <StructLayout(LayoutKind.Sequential)> _
     Public Structure POINT
        Dim x As Integer
        Dim y As Integer
    End Structure
#End Region

#Region "       IsXpOrAbove and Is2KOrAbove"
    Public Shared Function IsXpOrAbove() As Boolean
        Dim rVal As Boolean = False
        If Environment.OSVersion.Version.Major > 5 Then
            rVal = True
        ElseIf Environment.OSVersion.Version.Major = 5 AndAlso _
               Environment.OSVersion.Version.Minor >= 1 Then
            rVal = True
        End If
        Return rVal
    End Function
    Public Shared Function Is2KOrAbove() As Boolean
        If Environment.OSVersion.Version.Major >= 5 Then
            Return True
        Else
            Return False
        End If
    End Function
#End Region

End Class
#End Region


