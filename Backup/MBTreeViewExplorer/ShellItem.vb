#Region "Import"
Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.IO
Imports MBTreeViewExplorer.ShellAPI
#End Region

#Region " Class ShellItem"

''' <summary>
''' ShellItem Class for MBTreeViewExplorer
''' </summary>
Public Class ShellItem
    Implements IDisposable, IComparable

#Region "   Shared Private Fields"
    'This class has occasion to refer to the TypeName as reported by
    ' SHGetFileInfo. It needs to compare this to the string
    ' (in English) "System Folder"
    'on non-English systems, we do not know, in the general case,
    ' what the equivalent string is to compare against
    'The following variable is set by Sub New() to the string that
    ' corresponds to "System Folder" on the current machine
    ' Sub New() depends on the existance of My Computer(CSIDL.DRIVES),
    ' to determine what the equivalent string is
    Private Shared m_strSystemFolder As String

    'My Computer is also commonly used (though not internally),
    ' so save & expose its name on the current machine
    Private Shared m_strMyComputer As String

    'To get My Documents sorted first, we need to know the Locale 
    'specific name of that folder.
    Private Shared m_strMyDocuments As String

    ' The DesktopBase is set up via Sub New() (one time only) and
    '  disposed of only when DesktopBase is finally disposed of
    Private Shared DesktopBase As ShellItem

    'We can avoid an extra SHGetFileInfo call once this is set up
    Private Shared OpenFolderIconIndex As Integer = -1

    ' It is also useful to know if the OS is XP or above.  
    ' Set up in Sub New() to avoid multiple calls to find this info
    Private Shared XPorAbove As Boolean
    ' Likewise if OS is Win2K or Above
    Private Shared Win2KOrAbove As Boolean

    ' DragDrop, possibly among others, needs to know the Path of
    ' the DeskTopDirectory in addition to the Desktop itself
    ' Also need the actual ShellItem for the DeskTopDirectory, so get it
    Private Shared m_DeskTopDirectory As ShellItem


#End Region

#Region "   Instance Private Fields"

    Private m_Folder As IShellFolder
    Private m_Pidl As IntPtr
    Private m_DisplayName As String = ""
    Private m_Path As String
    Private m_TypeName As String
    Private m_Parent As ShellItem
    Private m_IconIndexNormal As Integer
    Private m_IconIndexOpen As Integer
    Private m_IsBrowsable As Boolean
    Private m_IsFileSystem As Boolean
    Private m_IsFolder As Boolean
    Private m_HasSubFolders As Boolean
    Private m_IsLink As Boolean
    Private m_IsDisk As Boolean
    Private m_IsShared As Boolean
    Private m_IsHidden As Boolean
    Private m_IsNetWorkDrive As Boolean
    Private m_IsRemovable As Boolean
    Private m_IsReadOnly As Boolean

    Private m_CanMove As Boolean
    Private m_CanCopy As Boolean
    Private m_CanDelete As Boolean
    Private m_CanLink As Boolean
    Private m_IsDropTarget As Boolean
    Private m_Attributes As SFGAO

    Private m_SortFlag As Integer

    Private m_Directories As ArrayList


    Private m_XtrInfo As Boolean
    Private m_LastWriteTime As DateTime
    Private m_CreationTime As DateTime
    Private m_LastAccessTime As DateTime
    Private m_Length As Long
    Private m_HasDispType As Boolean
    Private m_IsReadOnlySetup As Boolean
    Private m_cPidl As cPidl
    Private m_IsDisposing As Boolean
    Private m_Disposed As Boolean

#End Region

#Region "   Destructor"
    ''' <summary>
    ''' Summary of Dispose.
    ''' </summary>
    ''' 
    Public Overloads Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        ' Take yourself off of the finalization queue
        ' to prevent finalization code for this object
        ' from executing a second time.
        GC.SuppressFinalize(Me)
    End Sub
    ''' <summary>
    ''' Deallocates CoTaskMem contianing m_Pidl and removes reference to m_Folder
    ''' </summary>
    ''' <param name="disposing"></param>
    ''' 
    Protected Overridable Overloads Sub Dispose(ByVal disposing As Boolean)
        ' Allow your Dispose method to be called multiple times,
        ' but throw an exception if the object has been disposed.
        ' Whenever you do something with this class, 
        ' check to see if it has been disposed.
        If Not (m_Disposed) Then
            ' If disposing equals true, dispose all managed 
            ' and unmanaged resources.
            m_Disposed = True
            If (disposing) Then
            End If
            ' Release unmanaged resources. If disposing is false,
            ' only the following code is executed. 
            If Not IsNothing(m_Folder) Then
                Marshal.ReleaseComObject(m_Folder)
            End If
            If Not m_Pidl.Equals(IntPtr.Zero) Then
                Marshal.FreeCoTaskMem(m_Pidl)
            End If
        Else
            Throw New Exception("ShellItem Disposed more than once")
        End If
    End Sub

    ' This Finalize method will run only if the 
    ' Dispose method does not get called.
    ' By default, methods are NotOverridable. 
    ' This prevents a derived class from overriding this method.
    ''' <summary>
    ''' Summary of Finalize.
    ''' </summary>
    ''' 
    Protected Overrides Sub Finalize()
        ' Do not re-create Dispose clean-up code here.
        ' Calling Dispose(false) is optimal in terms of
        ' readability and maintainability.
        Dispose(True)
    End Sub

#End Region

#Region "   Constructors"

#Region "       Sub New()"
    ''' <summary>
    ''' Private Constructor. Creates ShellItem of the Desktop
    ''' </summary>
    Sub New()
        Dim HR As Integer
        Dim tmpPidl As IntPtr
        HR = SHGetSpecialFolderLocation(0, CSIDL.DRIVES, tmpPidl)
        Dim shfi As New SHFILEINFO()
        Dim dwflag As Integer = SHGFI.DISPLAYNAME Or _
                                SHGFI.TYPENAME Or _
                                SHGFI.PIDL
        Dim dwAttr As Integer = 0
        SHGetFileInfo(tmpPidl, dwAttr, shfi, cbFileInfo, dwflag)
        m_strSystemFolder = shfi.szTypeName
        m_strMyComputer = shfi.szDisplayName
        Marshal.FreeCoTaskMem(tmpPidl)
        XPorAbove = ShellAPI.IsXpOrAbove()
        Win2KOrAbove = ShellAPI.Is2KOrAbove

        m_Path = "::{" & DesktopGUID.ToString & "}"
        m_IsFolder = True
        m_HasSubFolders = True
        m_IsBrowsable = False
        HR = SHGetDesktopFolder(m_Folder)
        m_Pidl = GetSpecialFolderLocation(IntPtr.Zero, CSIDL.DESKTOP)
        dwflag = SHGFI.DISPLAYNAME Or _
                 SHGFI.TYPENAME Or _
                 SHGFI.SYSICONINDEX Or _
                 SHGFI.PIDL
        dwAttr = 0
        Dim H As IntPtr = SHGetFileInfo(m_Pidl, dwAttr, shfi, cbFileInfo, dwflag)
        m_DisplayName = shfi.szDisplayName
        m_TypeName = strSystemFolder
        m_IconIndexNormal = shfi.iIcon
        m_IconIndexOpen = shfi.iIcon
        m_HasDispType = True
        m_IsDropTarget = True
        m_IsReadOnly = False
        m_IsReadOnlySetup = True


        Dim pchEaten As Integer
        tmpPidl = IntPtr.Zero
        HR = m_Folder.ParseDisplayName(Nothing, Nothing, "::{450d8fba-ad25-11d0-98a8-0800361b1103}", _
                 pchEaten, tmpPidl, Nothing)
        shfi = New SHFILEINFO()
        dwflag = SHGFI.DISPLAYNAME Or _
                                SHGFI.TYPENAME Or _
                                SHGFI.PIDL
        dwAttr = 0
        SHGetFileInfo(tmpPidl, dwAttr, shfi, cbFileInfo, dwflag)
        m_strMyDocuments = shfi.szDisplayName
        Marshal.FreeCoTaskMem(tmpPidl)

        m_SortFlag = ComputeSortFlag()

        DesktopBase = Me

        m_DeskTopDirectory = New ShellItem(CSIDL.DESKTOPDIRECTORY)
    End Sub
#End Region

#Region "       Private Sub New(ByVal folder As IShellFolder, ByVal pidl As IntPtr, ByVal parent As ShellItem)"
    ''' <summary>
    ''' Private Constructor, creates new ShellItem from the item's parent folder and
    '''  the item's PIDL relative to that folder.</summary>
    ''' <param name="folder">the folder interface of the parent</param>
    ''' <param name="pidl">the Relative PIDL of this item</param>
    ''' <param name="parent">the ShellItem of the parent</param>
    Private Sub New(ByVal folder As IShellFolder, ByVal pidl As IntPtr, ByVal parent As ShellItem)
        If IsNothing(DesktopBase) Then
            DesktopBase = New ShellItem()
        End If
        m_Parent = parent
        m_Pidl = concatPidls(parent.PIDL, pidl)
        SetUpAttributes(folder, pidl)
        m_IconIndexNormal = -1
        m_IconIndexOpen = -1
        If m_IsFolder Then
            Dim HR As Integer
            HR = folder.BindToObject(pidl, IntPtr.Zero, IID_IShellFolder, m_Folder)
            If HR <> NOERROR Then
                Marshal.ThrowExceptionForHR(HR)
            End If
        End If
    End Sub
#End Region

#Region "       New(ByVal ID As CSIDL)"
    ''' <summary>Create instance based on a non-desktop CSIDL.
    ''' Will create based on any CSIDL Except the DeskTop CSIDL</summary>
    ''' <param name="ID">Value from CSIDL enumeration denoting the folder to create this ShellItem of.</param>
    Sub New(ByVal ID As CSIDL)
        If IsNothing(DesktopBase) Then
            DesktopBase = New ShellItem() 'This initializes the Desktop folder
        End If
        Dim HR As Integer
        If ID = CSIDL.MYDOCUMENTS Then
            Dim pchEaten As Integer
            HR = DesktopBase.m_Folder.ParseDisplayName(Nothing, Nothing, "::{450d8fba-ad25-11d0-98a8-0800361b1103}", _
                     pchEaten, m_Pidl, Nothing)
        Else
            HR = SHGetSpecialFolderLocation(0, ID, m_Pidl)
        End If
        If HR = NOERROR Then
            Dim pParent As IShellFolder
            Dim relPidl As IntPtr = IntPtr.Zero

            pParent = GetParentOf(m_Pidl, relPidl)
            'Get the Attributes
            SetUpAttributes(pParent, relPidl)
            'Set unfetched value for IconIndex....
            m_IconIndexNormal = -1
            m_IconIndexOpen = -1
            'finally, set up my Folder
            If m_IsFolder Then
                HR = pParent.BindToObject(relPidl, IntPtr.Zero, IID_IShellFolder, m_Folder)
                If HR <> NOERROR Then
                    Marshal.ThrowExceptionForHR(HR)
                End If
            End If
            Marshal.ReleaseComObject(pParent)
            'if PidlCount(m_Pidl) = 1 then relPidl is same as m_Pidl, don't release
            If PidlCount(m_Pidl) > 1 Then Marshal.FreeCoTaskMem(relPidl)
        Else
            Marshal.ThrowExceptionForHR(HR)
        End If
    End Sub
#End Region

#Region "       New(ByVal path As String)"
    ''' <summary>Create a new ShellItem based on a Path Must be a valid FileSystem Path</summary>
    Sub New(ByVal path As String)
        If IsNothing(DesktopBase) Then
            DesktopBase = New ShellItem()
        End If
        Dim HR As Integer
        HR = DesktopBase.m_Folder.ParseDisplayName(0, IntPtr.Zero, path, 0, m_Pidl, 0)
        If Not HR = NOERROR Then Marshal.ThrowExceptionForHR(HR)
        Dim pParent As IShellFolder
        Dim relPidl As IntPtr = IntPtr.Zero
        pParent = GetParentOf(m_Pidl, relPidl)
        SetUpAttributes(pParent, relPidl)
        m_IconIndexNormal = -1
        m_IconIndexOpen = -1
        If m_IsFolder Then
            HR = pParent.BindToObject(relPidl, IntPtr.Zero, IID_IShellFolder, m_Folder)
            If HR <> NOERROR Then
                Marshal.ThrowExceptionForHR(HR)
            End If
        End If
        Marshal.ReleaseComObject(pParent)
        If PidlCount(m_Pidl) > 1 Then
            Marshal.FreeCoTaskMem(relPidl)
        End If
    End Sub
#End Region

#Region "       New(ByVal FoldBytes() as Byte, ByVal ItemBytes() as Byte)"
    '''<Summary>Given a Byte() containing the Pidl of the parent
    ''' folder and another Byte() containing the Pidl of the Item,
    ''' relative to the Folder, Create a ShellItem for the Item.
    ''' This is of primary use in dealing with "Shell IDList Array" 
    ''' formatted info passed in a Drag Operation
    ''' </Summary>
    Sub New(ByVal FoldBytes() As Byte, ByVal ItemBytes() As Byte)
        Debug.WriteLine("ShellItem.New(FoldBytes,ItemBytes) Fold len= " & FoldBytes.Length & " Item Len = " & ItemBytes.Length)
        If IsNothing(DesktopBase) Then
            DesktopBase = New ShellItem()
        End If
        Dim pParent As IShellFolder = MakeFolderFromBytes(FoldBytes)
        If IsNothing(pParent) Then
            GoTo XIT
        End If
        Dim ipParent As IntPtr = cPidl.BytesToPidl(FoldBytes)
        Dim ipItem As IntPtr = cPidl.BytesToPidl(ItemBytes)
        If ipParent.Equals(IntPtr.Zero) Or ipItem.Equals(IntPtr.Zero) Then
            GoTo XIT
        End If
        m_Pidl = concatPidls(ipParent, ipItem)
        SetUpAttributes(pParent, ipItem)
        m_IconIndexNormal = -1
        m_IconIndexOpen = -1
        If m_IsFolder Then
            Dim HR As Integer
            HR = pParent.BindToObject(ipItem, IntPtr.Zero, IID_IShellFolder, m_Folder)
#If DEBUG Then
            If HR <> NOERROR Then
                Marshal.ThrowExceptionForHR(HR)
            End If
#End If
        End If
XIT:
#If DEBUG Then
        If m_Pidl.Equals(IntPtr.Zero) Then
            Debug.WriteLine("ShellItem.New(FoldBytes,ItemBytes) Failed")
        Else
            Debug.WriteLine("ShellItem.New(FoldBytes,ItemBytes) Created " & Me.Path)
        End If
#End If
        If Not ipParent.Equals(IntPtr.Zero) Then
            Marshal.FreeCoTaskMem(ipParent)
        End If
        If Not ipItem.Equals(IntPtr.Zero) Then
            Marshal.FreeCoTaskMem(ipItem)
        End If
    End Sub

#End Region

#Region "       Utility functions used in Constructors"

#Region "       IsValidPidl"
    '''<Summary>It is impossible to validate a PIDL completely since its contents
    ''' are arbitrarily defined by the creating Shell Namespace.  However, it
    ''' is possible to validate the structure of a PIDL.</Summary>
    Public Shared Function IsValidPidl(ByVal b() As Byte) As Boolean
        IsValidPidl = False
        Dim bMax As Integer = b.Length - 1
        If bMax < 1 Then Exit Function
        Dim cb As Integer = b(0) + (b(1) * 256)
        Dim indx As Integer = 0
        Do While cb > 0
            If (indx + cb + 1) > bMax Then Exit Function
            indx += cb
            cb = b(indx) + (b(indx + 1) * 256)
        Loop
        IsValidPidl = True
    End Function
#End Region

#Region "   MakeFolderFromBytes"
    Public Shared Function MakeFolderFromBytes(ByVal b As Byte()) As IShellFolder
        MakeFolderFromBytes = Nothing
        If Not IsValidPidl(b) Then Return Nothing
        If b.Length = 2 AndAlso ((b(0) = 0) And (b(1) = 0)) Then
            Return DesktopBase.Folder
        ElseIf b.Length = 0 Then
            Return DesktopBase.Folder
        Else
            Dim ptr As IntPtr = Marshal.AllocCoTaskMem(b.Length)
            If ptr.Equals(IntPtr.Zero) Then Return Nothing
            Marshal.Copy(b, 0, ptr, b.Length)
            Dim hr As Integer = DesktopBase.Folder.BindToObject(ptr, IntPtr.Zero, IID_IShellFolder, MakeFolderFromBytes)
            If hr <> 0 Then MakeFolderFromBytes = Nothing
            Marshal.FreeCoTaskMem(ptr)
        End If
    End Function
#End Region

#Region "           GetParentOf"

    '''<Summary>Returns both the IShellFolder interface of the parent folder
    '''  and the relative pidl of the input PIDL</Summary>
    '''<remarks>Several internal functions need this information and do not have
    ''' it readily available. GetParentOf serves those functions</remarks>
    Friend Shared Function GetParentOf(ByVal pidl As IntPtr, ByRef relPidl As IntPtr) As IShellFolder
        GetParentOf = Nothing
        Dim HR As Integer
        Dim itemCnt As Integer = PidlCount(pidl)
        If itemCnt = 1 Then
            HR = SHGetDesktopFolder(GetParentOf)
            relPidl = pidl
        Else
            Dim tmpPidl As IntPtr
            tmpPidl = TrimPidl(pidl, relPidl)
            HR = DesktopBase.m_Folder.BindToObject(tmpPidl, IntPtr.Zero, IID_IShellFolder, GetParentOf)
            Marshal.FreeCoTaskMem(tmpPidl)
        End If
        If Not HR = NOERROR Then Marshal.ThrowExceptionForHR(HR)
    End Function
#End Region

#Region "           SetUpAttributes"
    ''' <summary>Get the base attributes of the folder/file that this ShellItem represents</summary>
    ''' <param name="folder">Parent Folder of this Item</param>
    ''' <param name="pidl">Relative Pidl of this Item.</param>
    Private Sub SetUpAttributes(ByVal folder As IShellFolder, ByVal pidl As IntPtr)
        Dim attrFlag As SFGAO
        attrFlag = SFGAO.BROWSABLE
        attrFlag = attrFlag Or SFGAO.FILESYSTEM
        attrFlag = attrFlag Or SFGAO.HASSUBFOLDER
        attrFlag = attrFlag Or SFGAO.FOLDER
        attrFlag = attrFlag Or SFGAO.LINK
        attrFlag = attrFlag Or SFGAO.SHARE
        attrFlag = attrFlag Or SFGAO.HIDDEN
        attrFlag = attrFlag Or SFGAO.REMOVABLE

        attrFlag = attrFlag Or SFGAO.CANCOPY
        attrFlag = attrFlag Or SFGAO.CANDELETE
        attrFlag = attrFlag Or SFGAO.CANLINK
        attrFlag = attrFlag Or SFGAO.CANMOVE
        attrFlag = attrFlag Or SFGAO.DROPTARGET

        Dim aPidl(0) As IntPtr
        aPidl(0) = pidl
        folder.GetAttributesOf(1, aPidl, attrFlag)
        m_Attributes = attrFlag
        m_IsBrowsable = CBool(attrFlag And SFGAO.BROWSABLE)
        m_IsFileSystem = CBool(attrFlag And SFGAO.FILESYSTEM)
        m_HasSubFolders = CBool(attrFlag And SFGAO.HASSUBFOLDER)
        m_IsFolder = CBool(attrFlag And SFGAO.FOLDER)
        m_IsLink = CBool(attrFlag And SFGAO.LINK)
        m_IsShared = CBool(attrFlag And SFGAO.SHARE)
        m_IsHidden = CBool(attrFlag And SFGAO.HIDDEN)
        m_IsRemovable = CBool(attrFlag And SFGAO.REMOVABLE)

        m_CanCopy = CBool(attrFlag And SFGAO.CANCOPY)
        m_CanDelete = CBool(attrFlag And SFGAO.CANDELETE)
        m_CanLink = CBool(attrFlag And SFGAO.CANLINK)
        m_CanMove = CBool(attrFlag And SFGAO.CANMOVE)
        m_IsDropTarget = CBool(attrFlag And SFGAO.DROPTARGET)

        Dim strr As IntPtr = Marshal.AllocCoTaskMem(MAX_PATH * 2 + 4)
        Marshal.WriteInt32(strr, 0, 0)
        Dim buf As New StringBuilder(MAX_PATH)
        Dim itemflags As SHGDN = SHGDN.FORPARSING
        folder.GetDisplayNameOf(pidl, itemflags, strr)
        Dim HR As Integer = StrRetToBuf(strr, pidl, buf, MAX_PATH)
        Marshal.FreeCoTaskMem(strr)
        If HR = NOERROR Then
            m_Path = buf.ToString
            If m_IsFolder AndAlso m_IsFileSystem AndAlso XPorAbove Then
                aPidl(0) = pidl
                attrFlag = SFGAO.STREAM
                folder.GetAttributesOf(1, aPidl, attrFlag)
                If attrFlag And SFGAO.STREAM Then
                    m_IsFolder = False
                End If
            End If
            If m_Path.Length = 3 AndAlso m_Path.Substring(1).Equals(":\") Then
                m_IsDisk = True
            End If
        Else
            Marshal.ThrowExceptionForHR(HR)
        End If
    End Sub

#End Region

#End Region

#Region "       Public Shared Function GetShellItem(ByVal ID As CSIDL) As ShellItem"
    Public Shared Function GetShellItems(ByVal ID As CSIDL) As ShellItem
        GetShellItems = Nothing
        If ID = CSIDL.DESKTOP Then
            Return GetDeskTop()
        End If
        Dim HR As Integer
        Dim tmpPidl As IntPtr
        If ID = CSIDL.MYDOCUMENTS Then
            Dim pchEaten As Integer
            HR = GetDeskTop.Folder.ParseDisplayName(Nothing, Nothing, "::{450d8fba-ad25-11d0-98a8-0800361b1103}", _
                     pchEaten, tmpPidl, Nothing)
        Else
            HR = SHGetSpecialFolderLocation(0, ID, tmpPidl)
        End If
        If HR = NOERROR Then
            GetShellItems = FindShellItem(tmpPidl)
            If IsNothing(GetShellItems) Then
                Try
                    GetShellItems = New ShellItem(ID)
                Catch
                    GetShellItems = Nothing
                End Try
            End If
        End If
        If Not tmpPidl.Equals(IntPtr.Zero) Then
            Marshal.FreeCoTaskMem(tmpPidl)
        End If
    End Function
#End Region

#Region "       Public Shared Function FindShellItem(ByVal b() As Byte) As ShellItem"
    'Public Shared Function FindShellItem(ByVal b() As Byte) As ShellItem
    '    If Not IsValidPidl(b) Then Return Nothing
    '    Dim thisPidl As IntPtr = Marshal.AllocCoTaskMem(b.Length)
    '    If thisPidl.Equals(IntPtr.Zero) Then Return Nothing
    '    Marshal.Copy(b, 0, thisPidl, b.Length)
    '    FindShellItem = FindShellItem(thisPidl)
    '    Marshal.FreeCoTaskMem(thisPidl)
    'End Function
#End Region

#End Region

#Region "   Icomparable -- for default Sorting"

    ''' <summary>Computes the Sort key of this ShellItem, based on its attributes</summary>
    Private Function ComputeSortFlag() As Integer
        Dim rVal As Integer = 0
        If m_IsDisk Then rVal = &H100000
        If m_TypeName.Equals(strSystemFolder) Then
            If Not m_IsBrowsable Then
                rVal = rVal Or &H10000
                If m_strMyDocuments.Equals(m_DisplayName) Then
                    rVal = rVal Or &H1
                End If
            Else
                rVal = rVal Or &H1000
            End If
        End If
        If m_IsFolder Then rVal = rVal Or &H100
        Return rVal
    End Function

    '''<Summary> CompareTo(obj as object)
    '''  Compares obj to this instance based on SortFlag-- obj must be a ShellItem</Summary>
    '''<SortOrder>  (low)Disks,non-browsable System Folders,browsable System Folders, Directories, Files, Nothing (high)</SortOrder>
    Public Overridable Overloads Function CompareTo(ByVal obj As Object) As Integer _
            Implements IComparable.CompareTo
        If IsNothing(obj) Then Return 1 'non-existant is always low
        Dim Other As ShellItem = DirectCast(obj, ShellItem)
        If Not m_HasDispType Then SetDispType()
        Dim cmp As Integer = Other.SortFlag - m_SortFlag 'Note the reversal
        If cmp <> 0 Then
            Return cmp
        Else
            If m_IsDisk Then
                Return String.Compare(m_Path, Other.Path)
            Else
                Return String.Compare(m_DisplayName, Other.DisplayName)
            End If
        End If
    End Function
#End Region

#Region "   Properties"

#Region "       Shared Properties"
    Public Shared ReadOnly Property strMyComputer() As String
        Get
            Return m_strMyComputer
        End Get
    End Property

    Public Shared ReadOnly Property strSystemFolder() As String
        Get
            Return m_strSystemFolder
        End Get
    End Property

    Public Shared ReadOnly Property DesktopDirectoryPath() As String
        Get
            Return m_DeskTopDirectory.Path
        End Get
    End Property

#End Region

#Region "       Normal Properties"
    Public ReadOnly Property PIDL() As IntPtr
        Get
            Return m_Pidl
        End Get
    End Property

    Public ReadOnly Property Folder() As IShellFolder
        Get
            Return m_Folder
        End Get
    End Property

    Public ReadOnly Property Path() As String
        Get
            Return m_Path
        End Get
    End Property
    Public ReadOnly Property Parent() As ShellItem
        Get
            Return m_Parent
        End Get
    End Property

    Public ReadOnly Property Attributes() As SFGAO
        Get
            Return m_Attributes
        End Get
    End Property
    Public ReadOnly Property IsBrowsable() As Boolean
        Get
            Return m_IsBrowsable
        End Get
    End Property
    Public ReadOnly Property IsFileSystem() As Boolean
        Get
            Return m_IsFileSystem
        End Get
    End Property
    Public ReadOnly Property IsFolder() As Boolean
        Get
            Return m_IsFolder
        End Get
    End Property
    Public ReadOnly Property HasSubFolders() As Boolean
        Get
            Return m_HasSubFolders
        End Get
    End Property
    Public ReadOnly Property IsDisk() As Boolean
        Get
            Return m_IsDisk
        End Get
    End Property
    Public ReadOnly Property IsLink() As Boolean
        Get
            Return m_IsLink
        End Get
    End Property
    Public ReadOnly Property IsShared() As Boolean
        Get
            Return m_IsShared
        End Get
    End Property
    Public ReadOnly Property IsHidden() As Boolean
        Get
            Return m_IsHidden
        End Get
    End Property
    Public ReadOnly Property IsRemovable() As Boolean
        Get
            Return m_IsRemovable
        End Get
    End Property
    'UPDATE: Add Size property
    Private m_size As String = "[]"
    Public ReadOnly Property Size() As String
        Get
            If m_size = "[]" Then
                GetSize()
            End If
            Return m_size
        End Get
    End Property
    Private Sub GetSize()
        'Split the file size into bytes, kb, MB and GB
        If (Not Me.IsFolder And Me.IsFileSystem) Or Me.IsDisk Then
            If Me.Length >= (1048576 * 1024) Then
                m_size = Format(Me.Length / (1048576 * 1024), "#,###.# GB")
            ElseIf Me.Length >= 1048576 Then
                m_size = Format(Me.Length / 1048576, "#,###.# MB")
            ElseIf Me.Length >= 1024 Then
                m_size = Format(Me.Length / 1024, "#,### KB")
            ElseIf Not (Me.IsRemovable And Me.Length = 0) Then 'Don't show a CD-ROM's size if it doesn't have a disk in it
                m_size = Format(Me.Length, "##0 Bytes")
            Else
                m_size = "" 'Empty CD-ROM
            End If
        Else
            m_size = ""
        End If
    End Sub

#Region "       Drag Ops Properties"
    Public ReadOnly Property CanMove() As Boolean
        Get
            Return m_CanMove
        End Get
    End Property
    Public ReadOnly Property CanCopy() As Boolean
        Get
            Return m_CanCopy
        End Get
    End Property
    Public ReadOnly Property CanDelete() As Boolean
        Get
            Return m_CanDelete
        End Get
    End Property
    Public ReadOnly Property CanLink() As Boolean
        Get
            Return m_CanLink
        End Get
    End Property
    Public ReadOnly Property IsDropTarget() As Boolean
        Get
            Return m_IsDropTarget
        End Get
    End Property
#End Region

#End Region

#Region "       Filled on Demand Properties"

#Region "           Filled based on m_HasDispType"
    ''' <summary>
    ''' Set DisplayName, TypeName, and SortFlag when actually needed
    ''' </summary>
    ''' 
    Private Sub SetDispType()
        'Get Displayname, TypeName
        Dim shfi As New SHFILEINFO()
        Dim dwflag As Integer = SHGFI.DISPLAYNAME Or _
                                SHGFI.TYPENAME Or _
                                SHGFI.PIDL
        Dim dwAttr As Integer = 0
        If m_IsFileSystem And Not m_IsFolder Then
            dwflag = dwflag Or SHGFI.USEFILEATTRIBUTES
            dwAttr = FILE_ATTRIBUTE_NORMAL
        End If
        Dim H As IntPtr = SHGetFileInfo(m_Pidl, dwAttr, shfi, cbFileInfo, dwflag)
        m_DisplayName = shfi.szDisplayName
        m_TypeName = shfi.szTypeName
        'fix DisplayName
        If m_DisplayName.Equals("") Then
            m_DisplayName = m_Path
        End If
        'Fix TypeName
        'If m_IsFolder And m_TypeName.Equals("File") Then
        '    m_TypeName = "File Folder"
        'End If
        m_SortFlag = ComputeSortFlag()
        m_HasDispType = True
    End Sub

    Public ReadOnly Property DisplayName() As String
        Get
            If Not m_HasDispType Then SetDispType()
            Return m_DisplayName
        End Get
    End Property

    Private ReadOnly Property SortFlag() As Integer
        Get
            If Not m_HasDispType Then SetDispType()
            Return m_SortFlag
        End Get
    End Property

    Public ReadOnly Property TypeName() As String
        Get
            If Not m_HasDispType Then SetDispType()
            Return m_TypeName
        End Get
    End Property
#End Region

#Region "           IconIndex properties"
    Public ReadOnly Property IconIndexNormal() As Integer
        Get
            If m_IconIndexNormal < 0 Then
                If Not m_HasDispType Then SetDispType()
                Dim shfi As New SHFILEINFO()
                Dim dwflag As Integer = SHGFI.PIDL Or _
                                        SHGFI.SYSICONINDEX
                Dim dwAttr As Integer = 0
                If m_IsFileSystem And Not m_IsFolder Then
                    dwflag = dwflag Or SHGFI.USEFILEATTRIBUTES
                    dwAttr = FILE_ATTRIBUTE_NORMAL
                End If
                Dim H As IntPtr = SHGetFileInfo(m_Pidl, dwAttr, shfi, cbFileInfo, dwflag)
                m_IconIndexNormal = shfi.iIcon
            End If
            Return m_IconIndexNormal
        End Get
    End Property
    ' IconIndexOpen is Filled on demand
    Public ReadOnly Property IconIndexOpen() As Integer
        Get
            If m_IconIndexOpen < 0 Then
                If Not m_HasDispType Then SetDispType()
                If Not m_IsDisk And m_IsFileSystem And m_IsFolder Then
                    If OpenFolderIconIndex < 0 Then
                        Dim dwflag As Integer = SHGFI.SYSICONINDEX Or SHGFI.PIDL
                        Dim shfi As New SHFILEINFO()
                        Dim H As IntPtr = SHGetFileInfo(m_Pidl, 0, _
                                          shfi, cbFileInfo, _
                                          dwflag Or SHGFI.OPENICON)
                        m_IconIndexOpen = shfi.iIcon
                        'If m_TypeName.Equals("File Folder") Then
                        '    OpenFolderIconIndex = shfi.iIcon
                        'End If
                    Else
                        m_IconIndexOpen = OpenFolderIconIndex
                    End If
                Else
                    m_IconIndexOpen = m_IconIndexNormal
                End If
            End If
            Return m_IconIndexOpen
        End Get
    End Property
#End Region

#Region "           FileInfo type Information"
    ''' <summary>
    ''' Obtains information available from FileInfo.
    ''' </summary>
    Private Sub FillDemandInfo()
        If m_IsDisk Then
            Try
                'See if this is a network drive
                'NoRoot = 1
                'Removable = 2
                'LocalDisk = 3
                'Network = 4
                'CD = 5
                'RAMDrive = 6
                Dim disk As New Management.ManagementObject("win32_logicaldisk.deviceid=""" & _
                                                m_Path.Substring(0, 2) & """")
                m_Length = CType(disk("Size"), Long)
                If CType(disk("DriveType"), UInt32).ToString = CStr(4) Then
                    m_IsNetWorkDrive = True
                End If
            Catch ex As Exception
                'Disconnected Network Drives etc. will generate 
                'an error here, just assume that it is a network
                'drive
                m_IsNetWorkDrive = True
            Finally
                m_XtrInfo = True
            End Try
        ElseIf Not m_IsDisk And m_IsFileSystem And Not m_IsFolder Then
            'in this case, it's a file
            If File.Exists(m_Path) Then
                Dim fi As New FileInfo(m_Path)
                m_LastWriteTime = fi.LastWriteTime
                m_LastAccessTime = fi.LastAccessTime
                m_CreationTime = fi.CreationTime
                m_Length = fi.Length
                m_XtrInfo = True
            End If
        Else
            If m_IsFileSystem And m_IsFolder Then
                If Directory.Exists(m_Path) Then
                    Dim di As New DirectoryInfo(m_Path)
                    m_LastWriteTime = di.LastWriteTime
                    m_LastAccessTime = di.LastAccessTime
                    m_CreationTime = di.CreationTime
                    m_XtrInfo = True
                End If
            End If
        End If
    End Sub

    Public ReadOnly Property LastWriteTime() As DateTime
        Get
            If Not m_XtrInfo Then
                FillDemandInfo()
            End If
            Return m_LastWriteTime
        End Get
    End Property
    Public ReadOnly Property LastAccessTime() As DateTime
        Get
            If Not m_XtrInfo Then
                FillDemandInfo()
            End If
            Return m_LastAccessTime
        End Get
    End Property
    Public ReadOnly Property CreationTime() As DateTime
        Get
            If Not m_XtrInfo Then
                FillDemandInfo()
            End If
            Return m_CreationTime
        End Get
    End Property
    Public ReadOnly Property Length() As Long
        Get
            If Not m_XtrInfo Then
                FillDemandInfo()
            End If
            Return m_Length
        End Get
    End Property
    Public ReadOnly Property IsNetworkDrive() As Boolean
        Get
            If Not m_XtrInfo Then
                FillDemandInfo()
            End If
            Return m_IsNetWorkDrive
        End Get
    End Property
#End Region

#Region "           cPidl information"
    Public ReadOnly Property clsPidl() As cPidl
        Get
            If IsNothing(m_cPidl) Then
                m_cPidl = New cPidl(m_Pidl)
            End If
            Return m_cPidl
        End Get
    End Property
#End Region

#Region "       IsReadOnly and IsSystem"
    '''<Summary>The IsReadOnly attribute causes an annoying access to any floppy drives
    ''' on the system. To postpone this (or avoid, depending on user action),
    ''' the attribute is only queried when asked for</Summary>
    Public ReadOnly Property IsReadOnly() As Boolean
        Get
            If m_IsReadOnlySetup Then
                Return m_IsReadOnly
            Else
                Dim shfi As New SHFILEINFO()
                shfi.dwAttributes = SFGAO.RDONLY
                Dim dwflag As Integer = SHGFI.PIDL Or _
                                        SHGFI.ATTRIBUTES Or _
                                        SHGFI.ATTR_SPECIFIED
                Dim dwAttr As Integer = 0
                Dim H As IntPtr = SHGetFileInfo(m_Pidl, dwAttr, shfi, cbFileInfo, dwflag)
                If H.ToInt32 <> NOERROR AndAlso H.ToInt32 <> 1 Then
                    Marshal.ThrowExceptionForHR(H.ToInt32)
                End If
                m_IsReadOnly = CBool(shfi.dwAttributes And SFGAO.RDONLY)
                'If m_IsReadOnly Then Debug.WriteLine("IsReadOnly -- " & m_Path)
                m_IsReadOnlySetup = True
                Return m_IsReadOnly
            End If
            'If Not m_XtrInfo Then
            '    FillDemandInfo()
            'End If
            'Return m_Attributes And FileAttributes.ReadOnly = FileAttributes.ReadOnly
        End Get
    End Property
    '''<Summary>The IsSystem attribute is seldom used, but required by DragDrop operations.
    ''' Since there is no way of getting ONLY the System attribute without getting
    ''' the RO attribute (which forces a reference to the floppy drive), we pay
    ''' the price of getting its own File/DirectoryInfo for this purpose alone.
    '''</Summary>
    Public ReadOnly Property IsSystem() As Boolean
        Get
            Static HaveSysInfo As Boolean   'true once we have gotten this attr
            Static m_IsSystem As Boolean    'the value of this attr once we have it
            If Not HaveSysInfo Then
                Try
                    m_IsSystem = (File.GetAttributes(m_Path) And FileAttributes.System) = FileAttributes.System
                    HaveSysInfo = True
                Catch ex As Exception
                    HaveSysInfo = True
                End Try
            End If
            Debug.WriteLine("In IsSystem -- Path = " & m_Path & " IsSystem = " & m_IsSystem)
            Return m_IsSystem
        End Get
    End Property

#End Region

#End Region

#End Region

#Region "   Public Methods"

#Region "       Shared Public Methods"

#Region "       GetDeskTop"

    Public Shared Function GetDeskTop() As ShellItem
        If IsNothing(DesktopBase) Then
            DesktopBase = New ShellItem()
        End If
        Return DesktopBase
    End Function
#End Region

#Region "       IsAncestorOf"
    Public Shared Function IsAncestorOf(ByVal ancestor As ShellItem, _
                                        ByVal current As ShellItem, _
                                        Optional ByVal fParent As Boolean = False) _
                                        As Boolean
        Return IsAncestorOf(ancestor.PIDL, current.PIDL, fParent)
    End Function
    Public Shared Function IsAncestorOf(ByVal AncestorPidl As IntPtr, _
                                        ByVal ChildPidl As IntPtr, _
                                        Optional ByVal fParent As Boolean = False) _
                                        As Boolean
        'If Is2KOrAbove() Then
        '    Return ILIsParent(AncestorPidl, ChildPidl, fParent)
        'Else
        '    Dim Child As New cPidl(ChildPidl)
        '    Dim Ancestor As New cPidl(AncestorPidl)
        '    IsAncestorOf = Child.StartsWith(Ancestor)
        '    If Not IsAncestorOf Then Exit Function
        '    If fParent Then ' check for immediate ancestor, if desired
        '        Dim oAncBytes() As Object = Ancestor.Decompose
        '        Dim oChildBytes() As Object = Child.Decompose
        '        If oAncBytes.Length <> (oChildBytes.Length - 1) Then
        '            IsAncestorOf = False
        '        End If
        '    End If
        'End If
    End Function
#End Region

#Region "      AllFolderWalk"
    Public Delegate Function WalkAllCallBack(ByVal info As ShellItem, _
                                             ByVal UserLevel As Integer, _
                                             ByVal Tag As Integer) _
                                             As Boolean
    Public Shared Function AllFolderWalk(ByVal cStart As ShellItem, _
                                          ByVal cback As WalkAllCallBack, _
                                          ByVal UserLevel As Integer, _
                                          ByVal Tag As Integer) _
                                          As Boolean
        If Not IsNothing(cStart) AndAlso cStart.IsFolder Then
            Dim cItem As ShellItem

            For Each cItem In cStart.GetFiles
                If Not cback(cItem, UserLevel, Tag) Then
                    Return False
                End If
            Next

            For Each cItem In cStart.GetDirectories
                If Not cback(cItem, UserLevel + 1, Tag) Then
                    Return False
                Else
                    If Not AllFolderWalk(cItem, cback, UserLevel + 1, Tag) Then
                        Return False
                    End If
                End If
            Next
            Return True
        Else
            Throw New ApplicationException("AllFolderWalk -- Invalid Start Directory")
        End If
    End Function
#End Region

#End Region

#Region "       Public Instance Methods"

#Region "           Equals"
    Public Overloads Function Equals(ByVal other As ShellItem) As Boolean
        Equals = Me.Path.Equals(other.Path)
    End Function
#End Region

#Region "       GetDirectories"

    Private Function GetDirectories(Optional ByVal doRefresh As Boolean = True) As ArrayList
        Dim rVal As New ArrayList()
        If m_IsFolder Then
            If doRefresh Then
                RefreshDirectories()  ' return an up-to-date List
            ElseIf m_Directories Is Nothing Then
                RefreshDirectories()
            End If
            Return m_Directories
        Else 'if it is not a Folder, then return empty arraylist
            Return New ArrayList()
        End If
    End Function

    Public Function GetAllDirectories() As ArrayList
        Dim rVal As New ArrayList()
        If m_IsFolder Then
            rVal.AddRange(Me.GetDirectories)
            rVal.Sort()
            Return rVal
        Else
            Return rVal
        End If
    End Function


#End Region

#Region "       GetFiles"

    Public Function GetFiles() As ArrayList
        If m_IsFolder Then
            Return GetContents(SHCONTF.NONFOLDERS Or SHCONTF.INCLUDEHIDDEN)
        Else
            Return New ArrayList()
        End If
    End Function

    ''' <summary>
    ''' Returns the Files of this sub-folder, filtered by a filtering string, as an
    '''   ArrayList of ShellItems
    ''' Note: we do not keep the arraylist of files, Generate it each time
    ''' </summary>
    ''' <param name="Filter">A filter string (for example: *.Doc)</param>
    ''' <returns>An ArrayList of ShellItems. May return an empty ArrayList if there are none.</returns>
    ''' 
    Public Function GetFiles(ByVal Filter As String) As ArrayList
        If m_IsFolder Then
            Dim dummy As New ArrayList()
            Dim fileentries() As String
            fileentries = Directory.GetFiles(m_Path, Filter)
            Dim vFile As String
            For Each vFile In fileentries
                dummy.Add(New ShellItem(vFile))
            Next
            Return dummy
        Else
            Return New ArrayList()
        End If
    End Function
#End Region

#Region "       GetItems"

    Public Function GetItems() As ArrayList
        Dim rVal As New ArrayList()
        If m_IsFolder Then
            rVal.AddRange(Me.GetDirectories)
            rVal.AddRange(Me.GetContents(SHCONTF.NONFOLDERS Or SHCONTF.INCLUDEHIDDEN))
            rVal.Sort()
            Return rVal
        Else
            Return rVal
        End If
    End Function
#End Region

#Region "       GetFileName"

    Public Function GetFileName() As String
        If m_Path.StartsWith("::{") Then 'Path is really a GUID
            Return Me.DisplayName
        Else
            If m_IsDisk Then
                Return m_Path.Substring(0, 1)
            Else
                Return IO.Path.GetFileName(m_Path)
            End If
        End If
    End Function
#End Region

#Region "       ReFreshDirectories"

    Public Function RefreshDirectories() As Boolean
        RefreshDirectories = False
        If m_IsFolder Then
            Dim InvalidDirs As New ArrayList()
            If IsNothing(m_Directories) Then
                m_Directories = GetContents(SHCONTF.FOLDERS Or SHCONTF.INCLUDEHIDDEN Or SHCONTF.EMPTY)
                RefreshDirectories = True
            Else

                Dim curPidls As ArrayList = GetContents(SHCONTF.FOLDERS Or SHCONTF.INCLUDEHIDDEN Or SHCONTF.EMPTY, True)
                Dim iptr As IntPtr
                If curPidls.Count < 1 Then
                    If m_Directories.Count > 0 Then
                        m_Directories = New ArrayList()
                        RefreshDirectories = True
                    Else
                    End If
                Else
                    If m_Directories.Count < 1 Then
                        m_Directories = GetContents(SHCONTF.FOLDERS Or SHCONTF.INCLUDEHIDDEN Or SHCONTF.EMPTY)
                        RefreshDirectories = True
                    Else

                        Dim compList As New ArrayList(curPidls)

                        Dim iOld As Integer
                        Dim OldRel(m_Directories.Count - 1) As IntPtr
                        For iOld = 0 To m_Directories.Count - 1
                            OldRel(iOld) = GetLastID(CType(m_Directories(iOld), ShellItem).PIDL)
                        Next
                        Dim iNew As Integer
                        For iOld = 0 To m_Directories.Count - 1
                            For iNew = 0 To compList.Count - 1
                                If IsEqual(CType(compList(iNew), IntPtr), OldRel(iOld)) Then
                                    compList.RemoveAt(iNew)
                                    GoTo NXTOLD
                                End If
                            Next

                            InvalidDirs.Add(m_Directories(iOld))
                            RefreshDirectories = True
NXTOLD:                 Next
                        Dim csi As ShellItem
                        For Each csi In InvalidDirs
                            m_Directories.Remove(csi)
                        Next
                        If compList.Count > 0 Then
                            RefreshDirectories = True
                            For Each iptr In compList
                                m_Directories.Add(New ShellItem(m_Folder, iptr, Me))
                            Next
                        End If
                        If RefreshDirectories Then
                            m_Directories.Sort()
                        End If
                    End If
                    For Each iptr In curPidls
                        Marshal.FreeCoTaskMem(iptr)
                    Next
                End If
            End If
        End If
    End Function

#End Region

#Region "       ToString"
    ''' <summary>
    ''' Returns the DisplayName as the normal ToString value
    ''' </summary>
    Public Overrides Function ToString() As String
        Return m_DisplayName
    End Function
#End Region

#Region "       Debug Dumper"
    ''' <summary>
    ''' Summary of DebugDump.
    ''' </summary>
    Public Sub DebugDump()
        Debug.WriteLine("DisplayName = " & m_DisplayName)
        Debug.WriteLine("PIDL        = " & m_Pidl.ToString)
        Debug.WriteLine(vbTab & "Path        = " & m_Path)
        Debug.WriteLine(vbTab & "TypeName    = " & Me.TypeName)
        Debug.WriteLine(vbTab & "iIconNormal = " & m_IconIndexNormal)
        Debug.WriteLine(vbTab & "iIconSelect = " & m_IconIndexOpen)
        Debug.WriteLine(vbTab & "IsBrowsable = " & m_IsBrowsable)
        Debug.WriteLine(vbTab & "IsFileSystem= " & m_IsFileSystem)
        Debug.WriteLine(vbTab & "IsFolder    = " & m_IsFolder)
        Debug.WriteLine(vbTab & "IsLink    = " & m_IsLink)
        Debug.WriteLine(vbTab & "IsDropTarget = " & m_IsDropTarget)
        Debug.WriteLine(vbTab & "IsReadOnly   = " & Me.IsReadOnly)
        Debug.WriteLine(vbTab & "CanCopy = " & Me.CanCopy)
        Debug.WriteLine(vbTab & "CanLink = " & Me.CanLink)
        Debug.WriteLine(vbTab & "CanMove = " & Me.CanMove)
        Debug.WriteLine(vbTab & "CanDelete = " & Me.CanDelete)
        If m_IsFolder Then
            If Not IsNothing(m_Directories) Then
                Debug.WriteLine(vbTab & "Directory Count = " & m_Directories.Count)
            Else
                Debug.WriteLine(vbTab & "Directory Count Not yet set")
            End If
        End If
    End Sub
#End Region

#Region "       GetDropTargetOf"
    Public Function GetDropTargetOf(ByVal tn As Control) As IDropTarget
        If IsNothing(m_Folder) Then Return Nothing
        Dim apidl(0) As IntPtr
        Dim HR As Integer
        Dim theInterface As IDropTarget = Nothing
        Dim tnH As IntPtr = tn.Handle
        HR = m_Folder.CreateViewObject(tnH, ShellAPI.IID_IDropTarget, theInterface)
        If HR <> 0 Then
            Marshal.ThrowExceptionForHR(HR)
        End If
        Return theInterface
    End Function
#End Region

#End Region

#End Region

#Region "   Private Instance Methods"

#Region "       GetContents"

    Private Function GetContents(ByVal flags As SHCONTF, Optional ByVal IntPtrOnly As Boolean = False) As ArrayList
        Dim rVal As New ArrayList()
        Dim HR As Integer
        Dim IEnum As IEnumIDList = Nothing
        HR = m_Folder.EnumObjects(0, flags, IEnum)
        If HR = NOERROR Then
            Dim item As IntPtr = IntPtr.Zero
            Dim itemCnt As Integer
            HR = IEnum.GetNext(1, item, itemCnt)
            If HR = NOERROR Then
                Do While itemCnt > 0 AndAlso Not item.Equals(IntPtr.Zero)
                    'there is no setting to exclude folders from enumeration,
                    ' just one to include non-folders
                    ' so we have to screen the results to return only
                    '  non-folders if folders are not wanted
                    If Not CBool(flags And SHCONTF.FOLDERS) Then 'don't want folders. see if this is one
                        Dim attrFlag As SFGAO
                        attrFlag = attrFlag Or SFGAO.FOLDER Or _
                                                SFGAO.STREAM
                        'Note: for GetAttributesOf, we must provide an array, in all cases with 1 element
                        Dim aPidl(0) As IntPtr
                        aPidl(0) = item
                        m_Folder.GetAttributesOf(1, aPidl, attrFlag)
                        If Not XPorAbove Then
                            If CBool(attrFlag And SFGAO.FOLDER) Then 'Don't need it
                                GoTo SKIPONE
                            End If
                        Else         'XP or above
                            If CBool(attrFlag And SFGAO.FOLDER) AndAlso _
                               Not CBool(attrFlag And SFGAO.STREAM) Then
                                GoTo SKIPONE
                            End If
                        End If
                    End If
                    If IntPtrOnly Then   'just relative pidls for fast look, no ShellItem overhead
                        rVal.Add(PIDLClone(item))   'caller must free
                    Else
                        rVal.Add(New ShellItem(m_Folder, item, Me))
                    End If
SKIPONE:            Marshal.FreeCoTaskMem(item) 'if New kept it, it kept a copy
                    item = IntPtr.Zero
                    itemCnt = 0
                    ' Application.DoEvents()
                    HR = IEnum.GetNext(1, item, itemCnt)
                Loop
            Else
                If HR <> 1 Then GoTo HRError '1 means no more
            End If
        Else : GoTo HRError
        End If
        'Normal Exit
NORMAL: If Not IsNothing(IEnum) Then
            Marshal.ReleaseComObject(IEnum)
        End If
        rVal.TrimToSize()
        Return rVal

        ' Error Exit for all Com errors
HRError:  'not ready disks will return the following error
        'If HR = &HFFFFFFFF800704C7 Then
        '    GoTo NORMAL
        'ElseIf HR = &HFFFFFFFF80070015 Then
        '    GoTo NORMAL
        '    'unavailable net resources will return these
        'ElseIf HR = &HFFFFFFFF80040E96 Or HR = &HFFFFFFFF80040E19 Then
        '    GoTo NORMAL
        'ElseIf HR = &HFFFFFFFF80004001 Then 'Certain "Not Implemented" features will return this
        '    GoTo NORMAL
        'ElseIf HR = &HFFFFFFFF80004005 Then
        '    GoTo NORMAL
        'ElseIf HR = &HFFFFFFFF800704C6 Then
        '    GoTo NORMAL
        'End If
        If Not IsNothing(IEnum) Then Marshal.ReleaseComObject(IEnum)
        '#If Debug Then
        '        Marshal.ThrowExceptionForHR(HR)
        '#End If
        rVal = New ArrayList() 'sometimes it is a non-fatal error,ignored
        GoTo NORMAL
    End Function
#End Region

#Region "       Really nasty Pidl manipulation"

    Private Shared Function ItemIDSize(ByVal pidl As IntPtr) As Integer
        If Not pidl.Equals(IntPtr.Zero) Then
            Dim b(1) As Byte
            Marshal.Copy(pidl, b, 0, 2)
            Return b(1) * 256 + b(0)
        Else
            Return 0
        End If
    End Function

    ''' <summary>
    ''' computes the actual size of the ItemIDList pointed to by pidl
    ''' </summary>
    ''' <param name="pidl">The pidl pointing to an ItemIDList</param>
    '''<returns> Returns actual size of the ItemIDList, less the terminating nulnul</returns> 
    Public Shared Function ItemIDListSize(ByVal pidl As IntPtr) As Integer
        If Not pidl.Equals(IntPtr.Zero) Then
            Dim i As Integer = ItemIDSize(pidl)
            Dim b As Integer = Marshal.ReadByte(pidl, i) + (Marshal.ReadByte(pidl, i + 1) * 256)
            Do While b > 0
                i += b
                b = Marshal.ReadByte(pidl, i) + (Marshal.ReadByte(pidl, i + 1) * 256)
            Loop
            Return i
        Else : Return 0
        End If
    End Function
    ''' <summary>
    ''' Counts the total number of SHItems in input pidl
    ''' </summary>
    ''' <param name="pidl">The pidl to obtain the count for</param>
    ''' <returns> Returns the count of SHItems pointed to by pidl</returns> 
    Public Shared Function PidlCount(ByVal pidl As IntPtr) As Integer
        If Not pidl.Equals(IntPtr.Zero) Then
            Dim cnt As Integer = 0
            Dim i As Integer = 0
            Dim b As Integer = Marshal.ReadByte(pidl, i) + (Marshal.ReadByte(pidl, i + 1) * 256)
            Do While b > 0
                cnt += 1
                i += b
                b = Marshal.ReadByte(pidl, i) + (Marshal.ReadByte(pidl, i + 1) * 256)
            Loop
            Return cnt
        Else : Return 0
        End If
    End Function

    '''<Summary>GetLastId -- returns a pointer to the last ITEMID in a valid
    ''' ITEMIDLIST. Returned pointer SHOULD NOT be released since it
    ''' points to place within the original PIDL</Summary>
    '''<returns>IntPtr pointing to last ITEMID in ITEMIDLIST structure,
    ''' Returns IntPtr.Zero if given a null pointer.
    ''' If given a pointer to the Desktop, will return same pointer.</returns>
    '''<remarks>This is what the API ILFindLastID does, however IL... 
    ''' functions are not supported before Win2K.</remarks>
    Public Shared Function GetLastID(ByVal pidl As IntPtr) As IntPtr
        If Not pidl.Equals(IntPtr.Zero) Then
            Dim prev As Integer = 0
            Dim i As Integer = 0
            Dim b As Integer = Marshal.ReadByte(pidl, i) + (Marshal.ReadByte(pidl, i + 1) * 256)
            Do While b > 0
                prev = i
                i += b
                b = Marshal.ReadByte(pidl, i) + (Marshal.ReadByte(pidl, i + 1) * 256)
            Loop
            Return New IntPtr(pidl.ToInt32 + prev)
        Else : Return IntPtr.Zero
        End If
    End Function

    Public Shared Function DecomposePIDL(ByVal pidl As IntPtr) As IntPtr()
        Dim lim As Integer = ItemIDListSize(pidl)
        Dim PIDLs(PidlCount(pidl) - 1) As IntPtr
        Dim i As Integer = 0
        Dim curB As Integer
        Dim offSet As Integer = 0
        Do While curB < lim
            Dim thisPtr As IntPtr = New IntPtr(pidl.ToInt32 + curB)
            offSet = Marshal.ReadByte(thisPtr) + (Marshal.ReadByte(thisPtr, 1) * 256)
            PIDLs(i) = Marshal.AllocCoTaskMem(offSet + 2)
            Dim b(offSet + 1) As Byte
            Marshal.Copy(thisPtr, b, 0, offSet)
            b(offSet) = 0 : b(offSet + 1) = 0
            Marshal.Copy(b, 0, PIDLs(i), offSet + 2)
            'DumpPidl(PIDLs(i))
            curB += offSet
            i += 1
        Loop
        Return PIDLs
    End Function

    Private Shared Function PIDLClone(ByVal pidl As IntPtr) As IntPtr
        Dim cb As Integer = ItemIDListSize(pidl)
        Dim b(cb + 1) As Byte
        Marshal.Copy(pidl, b, 0, cb) 'not including terminating nulnul
        b(cb) = 0 : b(cb + 1) = 0 'force to nulnul
        PIDLClone = Marshal.AllocCoTaskMem(cb + 2)
        Marshal.Copy(b, 0, PIDLClone, cb + 2)
    End Function

    Public Shared Function IsEqual(ByVal Pidl1 As IntPtr, ByVal Pidl2 As IntPtr) As Boolean
        If Win2KOrAbove Then
            Return ILIsEqual(Pidl1, Pidl2)
        Else 'do hard way, may not work for some folders on XP

            Dim cb1 As Integer, cb2 As Integer
            cb1 = ItemIDListSize(Pidl1)
            cb2 = ItemIDListSize(Pidl2)
            If cb1 <> cb2 Then Return False
            Dim lim32 As Integer = cb1 \ 4

            Dim i As Integer
            For i = 0 To lim32 - 1
                If Marshal.ReadInt32(Pidl1, i) <> Marshal.ReadInt32(Pidl2, i) Then
                    Return False
                End If
            Next
            Dim limB As Integer = cb1 Mod 4
            Dim offset As Integer = lim32 * 4
            For i = 0 To limB - 1
                If Marshal.ReadByte(Pidl1, offset + i) <> Marshal.ReadByte(Pidl2, offset + i) Then
                    Return False
                End If
            Next
            Return True 'made it to here, so they are equal
        End If
    End Function

    ''' <summary>
    ''' Concatenates the contents of two pidls into a new Pidl (ended by 00)
    ''' allocating CoTaskMem to hold the result,
    ''' placing the concatenation (followed by 00) into the
    ''' allocated Memory,
    ''' and returning an IntPtr pointing to the allocated mem
    ''' </summary>
    ''' <param name="pidl1">IntPtr to a well formed SHItemIDList or IntPtr.Zero</param>
    ''' <param name="pidl2">IntPtr to a well formed SHItemIDList or IntPtr.Zero</param>
    ''' <returns>Returns a ptr to an ItemIDList containing the 
    '''   concatenation of the two (followed by the req 2 zeros
    '''   Caller must Free this pidl when done with it</returns> 
    Public Shared Function concatPidls(ByVal pidl1 As IntPtr, ByVal pidl2 As IntPtr) As IntPtr
        Dim cb1 As Integer, cb2 As Integer
        cb1 = ItemIDListSize(pidl1)
        cb2 = ItemIDListSize(pidl2)
        Dim rawCnt As Integer = cb1 + cb2
        If (rawCnt) > 0 Then
            Dim b(rawCnt + 1) As Byte
            If cb1 > 0 Then
                Marshal.Copy(pidl1, b, 0, cb1)
            End If
            If cb2 > 0 Then
                Marshal.Copy(pidl2, b, cb1, cb2)
            End If
            Dim rVal As IntPtr = Marshal.AllocCoTaskMem(cb1 + cb2 + 2)
            b(rawCnt) = 0 : b(rawCnt + 1) = 0
            Marshal.Copy(b, 0, rVal, rawCnt + 2)
            Return rVal
        Else
            Return IntPtr.Zero
        End If
    End Function

    ''' <summary>
    ''' Returns an ItemIDList with the last ItemID trimed off
    '''  This is necessary since I cannot get SHBindToParent to work 
    '''  It's purpose is to generate an ItemIDList for the Parent of a
    '''  Special Folder which can then be processed with DesktopBase.BindToObject,
    '''  yeilding a Folder for the parent of the Special Folder
    '''  It also creates and passes back a RELATIVE pidl for this item
    ''' </summary>
    ''' <param name="pidl">A pointer to a well formed ItemIDList. The PIDL to trim</param>
    ''' <param name="relPidl">BYREF IntPtr which will point to a new relative pidl
    '''        containing the contents of the last ItemID in the ItemIDList
    '''        terminated by the required 2 nulls.</param>
    ''' <returns> an ItemIDList with the last element removed.
    '''  Caller must Free this item when through with it
    '''  Also returns the new relative pidl in the 2nd parameter
    '''   Caller must Free this pidl as well, when through with it
    '''</returns>
    Public Shared Function TrimPidl(ByVal pidl As IntPtr, ByRef relPidl As IntPtr) As IntPtr
        Dim cb As Integer = ItemIDListSize(pidl)
        Dim b(cb + 1) As Byte
        Marshal.Copy(pidl, b, 0, cb)
        Dim prev As Integer = 0
        Dim i As Integer = b(0) + (b(1) * 256)
        'Do While i < cb AndAlso b(i) <> 0
        Do While i > 0 AndAlso i < cb       'Changed code
            prev = i
            i += b(i) + (b(i + 1) * 256)
        Loop
        If (prev + 1) < cb Then
            'first set up the relative pidl
            b(cb) = 0
            b(cb + 1) = 0
            Dim cb1 As Integer = b(prev) + (b(prev + 1) * 256)
            relPidl = Marshal.AllocCoTaskMem(cb1 + 2)
            Marshal.Copy(b, prev, relPidl, cb1 + 2)
            b(prev) = 0 : b(prev + 1) = 0
            Dim rVal As IntPtr = Marshal.AllocCoTaskMem(prev + 2)
            Marshal.Copy(b, 0, rVal, prev + 2)
            Return rVal
        Else
            Return IntPtr.Zero
        End If
    End Function

#Region "   DumpPidl Routines"
    ''' <summary>
    ''' Dumps, to the Debug output, the contents of the mem block pointed to by
    ''' a PIDL. Depends on the internal structure of a PIDL
    ''' </summary>
    ''' <param name="pidl">The IntPtr(a PIDL) pointing to the block to dump</param>
    ''' 
    Public Shared Sub DumpPidl(ByVal pidl As IntPtr)
        Dim cb As Integer = ItemIDListSize(pidl)
        Debug.WriteLine("PIDL " & pidl.ToString & " contains " & cb & " bytes")
        If cb > 0 Then
            Dim b(cb + 1) As Byte
            Marshal.Copy(pidl, b, 0, cb + 1)
            Dim pidlCnt As Integer = 1
            Dim i As Integer = b(0) + (b(1) * 256)
            Dim curB As Integer = 0
            Do While i > 0
                Debug.Write("ItemID #" & pidlCnt & " Length = " & i)
                DumpHex(b, curB, curB + i - 1)
                pidlCnt += 1
                curB += i
                i = b(curB) + (b(curB + 1) * 256)
            Loop
        End If
    End Sub

    '''<Summary>Dump a portion or all of a Byte Array to Debug output</Summary>
    '''<param name = "b">A single dimension Byte Array</param>
    '''<param name = "sPos">Optional start index of area to dump (default = 0)</param>
    '''<param name = "epos">Optional last index position to dump (default = end of array)</param>
    '''<Remarks>
    '''</Remarks>
    Public Shared Sub DumpHex(ByVal b() As Byte, _
                            Optional ByVal sPos As Integer = 0, _
                            Optional ByVal ePos As Integer = 0)
        If ePos = 0 Then ePos = b.Length - 1
        Dim j As Integer
        Dim curB As Integer = sPos
        Dim sTmp As String
        Dim ch As Char
        Dim SBH As New StringBuilder()
        Dim SBT As New StringBuilder()
        For j = 0 To ePos - sPos
            If j Mod 16 = 0 Then
                Debug.WriteLine(SBH.ToString & SBT.ToString)
                SBH = New StringBuilder() : SBT = New StringBuilder("          ")
                SBH.Append(HexNum(j + sPos, 4) & "). ")
            End If
            If b(curB) < 16 Then
                sTmp = "0" & Hex(b(curB))
            Else
                sTmp = Hex(b(curB))
            End If
            SBH.Append(sTmp) : SBH.Append(" ")
            ch = Chr(b(curB))
            If Char.IsControl(ch) Then
                SBT.Append(".")
            Else
                SBT.Append(ch)
            End If
            curB += 1
        Next

        Dim fill As Integer = (j) Mod 16
        If fill <> 0 Then
            SBH.Append(" "c, 48 - (3 * ((j) Mod 16)))
        End If
        Debug.WriteLine(SBH.ToString & SBT.ToString)
    End Sub

    Public Shared Function HexNum(ByVal num As Integer, ByVal nrChrs As Integer) As String
        Dim h As String = Hex(num)
        Dim SB As New StringBuilder()
        Dim i As Integer
        For i = 1 To nrChrs - h.Length
            SB.Append("0")
        Next
        SB.Append(h)
        Return SB.ToString
    End Function
#End Region

#End Region

#End Region

#Region "   TagComparer Class"
    Public Class TagComparer
        Implements IComparer
        Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer _
         Implements IComparer.Compare
            Dim xTag As ShellItem = x.tag
            Dim yTag As ShellItem = y.tag
            Return xTag.CompareTo(y.tag)
        End Function
    End Class
#End Region

#Region "   cPidl Class"
    Public Class cPidl
        Implements IEnumerable

#Region "       Private Fields"
        Dim m_bytes() As Byte   'The local copy of the PIDL
        Dim m_ItemCount As Integer      'the # of ItemIDs in this ItemIDList (PIDL)
        Dim m_OffsetToRelative As Integer 'the index of the start of the last itemID in m_bytes
#End Region

#Region "       Constructor"
        Sub New(ByVal pidl As IntPtr)
            Dim cb As Integer = ItemIDListSize(pidl)
            If cb > 0 Then
                ReDim m_bytes(cb + 1)
                Marshal.Copy(pidl, m_bytes, 0, cb)
                'DumpPidl(pidl)
            Else
                ReDim m_bytes(1)  'This is the DeskTop (we hope)
            End If
            'ensure nulnul
            m_bytes(m_bytes.Length - 2) = 0 : m_bytes(m_bytes.Length - 1) = 0
            m_ItemCount = PidlCount(pidl)
        End Sub
#End Region

#Region "       Public Properties"
        Public ReadOnly Property PidlBytes() As Byte()
            Get
                Return m_bytes
            End Get
        End Property

        Public ReadOnly Property Length() As Integer
            Get
                Return m_bytes.Length
            End Get
        End Property

        Public ReadOnly Property ItemCount() As Integer
            Get
                Return m_ItemCount
            End Get
        End Property

#End Region

#Region "       Public Intstance Methods -- ToPIDL, Decompose, and IsEqual"

        '''<Summary> Copy the contents of a byte() containing a pidl to
        '''  CoTaskMemory, returning an IntPtr that points to that mem block
        ''' Assumes that this cPidl is properly terminated, as all New 
        ''' cPidls are.
        ''' Caller must Free the returned IntPtr when done with mem block.
        '''</Summary>
        Public Function ToPIDL() As IntPtr
            ToPIDL = BytesToPidl(m_bytes)
        End Function

        '''<Summary>Returns an object containing a byte() for each of this cPidl's
        ''' ITEMIDs (individual PIDLS), in order such that obj(0) is
        ''' a byte() containing the bytes of the first ITEMID, etc.
        ''' Each ITEMID is properly terminated with a nulnul
        '''</Summary>
        Public Function Decompose() As Object()
            Dim bArrays(Me.ItemCount - 1) As Object
            Dim eByte As ICPidlEnumerator = CType(Me.GetEnumerator(), ICPidlEnumerator)
            Dim i As Integer
            Do While eByte.MoveNext
                bArrays(i) = eByte.Current
                i += 1
            Loop
            Return bArrays
        End Function

        '''<Summary>Returns True if input cPidl's content exactly match the 
        ''' contents of this instance</Summary>
        Public Function IsEqual(ByVal other As cPidl) As Boolean
            IsEqual = False     'assume not
            If other.Length <> Me.Length Then Exit Function
            Dim ob() As Byte = other.PidlBytes
            Dim i As Integer
            For i = 0 To Me.Length - 1  'note: we look at nulnul also
                If ob(i) <> m_bytes(i) Then Exit Function
            Next
            Return True         'all equal on fall thru
        End Function
#End Region

#Region "       Public Shared Methods"

#Region "           JoinPidlBytes"
        '''<Summary> Join two byte arrays containing PIDLS, returning a 
        ''' Byte() containing the resultant ITEMIDLIST. Both Byte() must
        ''' be properly terminated (nulnul)
        ''' Returns NOTHING if error
        ''' </Summary>
        Public Shared Function JoinPidlBytes(ByVal b1() As Byte, ByVal b2() As Byte) As Byte()
            If IsValidPidl(b1) And IsValidPidl(b2) Then
                Dim b(b1.Length + b2.Length - 3) As Byte 'allow for leaving off first nulnul
                Array.Copy(b1, b, b1.Length - 2)
                Array.Copy(b2, 0, b, b1.Length - 2, b2.Length)
                If IsValidPidl(b) Then
                    Return b
                Else
                    Return Nothing
                End If
            Else
                Return Nothing
            End If
        End Function
#End Region

#Region "           BytesToPidl"
        '''<Summary> Copy the contents of a byte() containing a pidl to
        '''  CoTaskMemory, returning an IntPtr that points to that mem block
        ''' Caller must free the IntPtr when done with it
        '''</Summary>
        Public Shared Function BytesToPidl(ByVal b() As Byte) As IntPtr
            BytesToPidl = IntPtr.Zero       'assume failure
            If IsValidPidl(b) Then
                Dim bLen As Integer = b.Length
                BytesToPidl = Marshal.AllocCoTaskMem(bLen)
                If BytesToPidl.Equals(IntPtr.Zero) Then Exit Function 'another bad error
                Marshal.Copy(b, 0, BytesToPidl, bLen)
            End If
        End Function
#End Region

#Region "           StartsWith"
        '''<Summary>returns True if the beginning of pidlA matches PidlB exactly for pidlB's entire length</Summary>
        Public Shared Function StartsWith(ByVal pidlA As IntPtr, ByVal pidlB As IntPtr) As Boolean
            Return cPidl.StartsWith(New cPidl(pidlA), New cPidl(pidlB))
        End Function

        '''<Summary>returns True if the beginning of A matches B exactly for B's entire length</Summary>
        Public Shared Function StartsWith(ByVal A As cPidl, ByVal B As cPidl) As Boolean
            Return A.StartsWith(B)
        End Function

        '''<Summary>Returns true if the CPidl input parameter exactly matches the
        ''' beginning of this instance of CPidl</Summary>
        Public Function StartsWith(ByVal cp As cPidl) As Boolean
            Dim b() As Byte = cp.PidlBytes
            If b.Length > m_bytes.Length Then Return False 'input is longer
            Dim i As Integer
            For i = 0 To b.Length - 3 'allow for nulnul at end of cp.PidlBytes
                If b(i) <> m_bytes(i) Then Return False
            Next
            Return True
        End Function
#End Region

#End Region

#Region "       GetEnumerator"
        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return New ICPidlEnumerator(m_bytes)
        End Function
#End Region

#Region "       PIDL enumerator Class"
        Private Class ICPidlEnumerator
            Implements IEnumerator

            Private m_sPos As Integer   'the first index in the current PIDL
            Private m_ePos As Integer   'the last index in the current PIDL
            Private m_bytes() As Byte   'the local copy of the PIDL
            Private m_NotEmpty As Boolean = False 'the desktop PIDL is zero length

            Sub New(ByVal b() As Byte)
                m_bytes = b
                If b.Length > 0 Then m_NotEmpty = True
                m_sPos = -1 : m_ePos = -1
            End Sub

            Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
                Get
                    If m_sPos < 0 Then Throw New InvalidOperationException("ICPidlEnumerator --- attempt to get Current with invalidated list")
                    Dim b((m_ePos - m_sPos) + 2) As Byte    'room for nulnul
                    Array.Copy(m_bytes, m_sPos, b, 0, b.Length - 2)
                    b(b.Length - 2) = 0 : b(b.Length - 1) = 0 'add nulnul
                    Return b
                End Get
            End Property

            Public Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
                If m_NotEmpty Then
                    If m_sPos < 0 Then
                        m_sPos = 0 : m_ePos = -1
                    Else
                        m_sPos = m_ePos + 1
                    End If
                    If m_bytes.Length < m_sPos + 1 Then Throw New InvalidCastException("Malformed PIDL")
                    Dim cb As Integer = m_bytes(m_sPos) + m_bytes(m_sPos + 1) * 256
                    If cb = 0 Then
                        Return False 'have passed all back
                    Else
                        m_ePos += cb
                    End If
                Else
                    m_sPos = 0 : m_ePos = 0
                    Return False        'in this case, we have exhausted the list of 0 ITEMIDs
                End If
                Return True
            End Function

            Public Sub Reset() Implements System.Collections.IEnumerator.Reset
                m_sPos = -1 : m_ePos = -1
            End Sub
        End Class
#End Region

    End Class
#End Region

#Region "       Public Shared Function GetShellItem(ByVal path As String) As ShellItem"
    Public Shared Function GetShellItem(ByVal path As String) As ShellItem
        GetShellItem = Nothing    'assume failure
        Dim HR As Integer
        Dim tmpPidl As IntPtr
        HR = GetDeskTop.Folder.ParseDisplayName(0, IntPtr.Zero, path, 0, tmpPidl, 0)
        If HR = 0 Then
            GetShellItem = FindShellItem(tmpPidl)
            If IsNothing(GetShellItem) Then
                Try
                    GetShellItem = New ShellItem(path)
                Catch
                    GetShellItem = Nothing
                End Try
            End If
        End If
        If Not tmpPidl.Equals(IntPtr.Zero) Then
            Marshal.FreeCoTaskMem(tmpPidl)
        End If
    End Function
#End Region

#Region "       Public Shared Function GetShellItem(ByVal ID As CSIDL) As ShellItem"
    Public Shared Function GetShellItem(ByVal ID As CSIDL) As ShellItem
        If ID = CSIDL.DESKTOP Then
            Return GetDeskTop()
        End If
        Dim HR As Integer
        Dim tmpPidl As IntPtr
        If ID = CSIDL.MYDOCUMENTS Then
            Dim pchEaten As Integer
            HR = GetDeskTop.Folder.ParseDisplayName(Nothing, Nothing, "::{450d8fba-ad25-11d0-98a8-0800361b1103}", _
                     pchEaten, tmpPidl, Nothing)
        Else
            HR = SHGetSpecialFolderLocation(0, ID, tmpPidl)
        End If
        If HR = NOERROR Then
            GetShellItem = FindShellItem(tmpPidl)
            If IsNothing(GetShellItem) Then
                Try
                    GetShellItem = New ShellItem(CType(ID, CSIDL))
                Catch
                    GetShellItem = Nothing
                End Try
            End If
        End If
        If Not tmpPidl.Equals(IntPtr.Zero) Then
            Marshal.FreeCoTaskMem(tmpPidl)
        End If
        Return Nothing
    End Function
#End Region

#Region "       Public Shared Function GetShellItem(ByVal FoldBytes() As Byte, ByVal ItemBytes() As Byte) As ShellItem"
    Public Shared Function GetShellItem(ByVal FoldBytes() As Byte, ByVal ItemBytes() As Byte) As ShellItem
        GetShellItem = Nothing    'assume failure
        Dim b() As Byte = cPidl.JoinPidlBytes(FoldBytes, ItemBytes)
        If IsNothing(b) Then Exit Function 'can do no more with invalid pidls
        'otherwise do like below, skipping unnecessary validation check
        Dim thisPidl As IntPtr = Marshal.AllocCoTaskMem(b.Length)
        If thisPidl.Equals(IntPtr.Zero) Then Return Nothing
        Marshal.Copy(b, 0, thisPidl, b.Length)
        GetShellItem = FindShellItem(thisPidl)
        Marshal.FreeCoTaskMem(thisPidl)
        If IsNothing(GetShellItem) Then   'didn't find it, make new
            Try
                GetShellItem = New ShellItem(FoldBytes, ItemBytes)
            Catch

            End Try
        End If
        If GetShellItem.PIDL.Equals(IntPtr.Zero) Then GetShellItem = Nothing
    End Function
#End Region

#Region "       Public Shared Function FindShellItem(ByVal b() As Byte) As ShellItem"
    Public Shared Function FindShellItem(ByVal b() As Byte) As ShellItem
        If Not IsValidPidl(b) Then Return Nothing
        Dim thisPidl As IntPtr = Marshal.AllocCoTaskMem(b.Length)
        If thisPidl.Equals(IntPtr.Zero) Then Return Nothing
        Marshal.Copy(b, 0, thisPidl, b.Length)
        FindShellItem = FindShellItem(thisPidl)
        Marshal.FreeCoTaskMem(thisPidl)
    End Function
#End Region

#Region "       Public Shared Function FindShellItem(ByVal ptr As IntPtr) As ShellItem"

    Public Shared Function FindShellItem(ByVal ptr As IntPtr) As ShellItem
        Dim BaseItem As ShellItem = ShellItem.GetDeskTop
        Dim CSI As ShellItem
        Dim FoundIt As Boolean = False      'True if we found item or an ancestor
        Do Until FoundIt
            For Each CSI In BaseItem.GetDirectories
                If IsAncestorOf(CSI.PIDL, ptr) Then
                    If ShellItem.IsEqual(CSI.PIDL, ptr) Then  'we found the desired item
                        Return CSI
                    Else
                        BaseItem = CSI
                        FoundIt = True
                        Exit For
                    End If
                End If
            Next
            If Not FoundIt Then Return Nothing 'didn't find an ancestor
            'The complication is that the desired item may not be a directory
            If Not IsAncestorOf(BaseItem.PIDL, ptr, True) Then  'Don't have immediate ancestor
                FoundIt = False     'go around again
            Else
                For Each CSI In BaseItem.GetItems
                    If ShellItem.IsEqual(CSI.PIDL, ptr) Then
                        Return CSI
                    End If
                Next
                'fall thru here means it doesn't exist or we can't find it because of funny PIDL from SHParseDisplayName
                Return Nothing
            End If
        Loop
        Return Nothing
    End Function

#End Region

    Public ReadOnly Property IsSharePoint() As Boolean
        Get
            If m_Path.ToLower.StartsWith("http://") Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property

End Class

#End Region