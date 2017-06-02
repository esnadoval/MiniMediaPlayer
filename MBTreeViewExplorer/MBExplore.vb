#Region "   About Auhor"
'
'   UserControl Name    :   MBTreeViewExplorer Control
'   Created             :   17 Dec 2011
'   Purpose             :   To Browse Folders and Files 
'   Vision              :   1.0.4368.33361
'   IDE                 :   Visual Basic .Net 2008
'   Author              :   Manoj K Bhoir
'
'   You can not:
'   Sell or redistribute this code or the binary for profit.
'   Use this in spyware, malware, or any generally acknowledged form of malicious software.
'   Remove or alter the above author accreditation, or this disclaimer.
'
'   You can:
'   Use this code in your applications in any way you like.
'   Use this in a published program, (a credit to MBUserControls would be nice)
'
'   I will not:
'   Except any responsibility for this code whatsoever. 
'   There is no guarantee of fitness, nor should you have any expectation of support. 
'   
'                                                                   Manoj K Bhoir
'                                                                   manojbhoir28@gmail.com    
#End Region

#Region "   Import"
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Drawing
#End Region
''' <summary>
''' MBTreeViewExplorer Class © Manoj K Bhoir
''' </summary>
''' <remarks>Version 1.0</remarks>
<ToolboxItem(True), ToolboxBitmap(GetType(MBExplorer), "MBTreeViewExplorer.MBTreeViewExplorer.bmp"), ToolboxItemFilter("System.Windows.Forms"), Description("Explore Folders for Browse.")> _
Public Class MBExplorer
    Inherits System.Windows.Forms.TreeView
    ''' <summary>
    ''' Constructor for MBTreeViewExplorer
    ''' </summary>
    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        SystemImageList.SetTreeViewImageList(Me, False)
        LoadNodes()
        'AddHandler Me.ForeColorChanged, AddressOf MBExplorer_ForeColorChanged
    End Sub
    ''' <summary>
    ''' Initialize Components of MBExplorer
    ''' </summary>
    Private Sub InitializeComponent()
        Me.Name = "MBTreeViewExplorer"
        Me.Size = New System.Drawing.Size(180, 250)
        Me.Nodes.Clear()
    End Sub

    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
    End Sub

    Private Sub MBExplorer_BeforeExpand(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles Me.BeforeExpand
        e.Node.Nodes.Clear()
        Dim shNode As ShellItem = e.Node.Tag
        Dim arrSub As ArrayList = shNode.GetAllDirectories()
        For Each shChild As ShellItem In arrSub
            Dim tvwChild As TreeNode = New TreeNode()
            tvwChild.Name = shChild.Path
            tvwChild.Text = shChild.DisplayName
            tvwChild.ImageIndex = shChild.IconIndexNormal
            tvwChild.SelectedImageIndex = shChild.IconIndexOpen
            tvwChild.Tag = shChild
            If shChild.IsFolder And shChild.HasSubFolders Then tvwChild.Nodes.Add("PH")
            e.Node.Nodes.Add(tvwChild)
        Next
    End Sub
    ''' <summary>
    ''' Handles MBTreeViewExplorer ForeColor Property
    ''' </summary>
    Private Sub MBExplorer_ForeColorChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ForeColorChanged
        Me.ForeColor = Me.ForeColor
    End Sub
    ''' <summary>
    ''' Load Nodes for MBTreeViewExplorer
    ''' </summary>
    Private Sub LoadNodes()
        Dim m_shDesktop As ShellItem = New ShellItem()
        Dim tvwRoot As TreeNode = New TreeNode()
        tvwRoot.Name = m_shDesktop.Path
        tvwRoot.Text = m_shDesktop.DisplayName
        tvwRoot.ImageIndex = m_shDesktop.IconIndexNormal
        tvwRoot.SelectedImageIndex = m_shDesktop.IconIndexOpen
        tvwRoot.Tag = m_shDesktop

        Dim arrChildren As ArrayList = m_shDesktop.GetAllDirectories
        For Each shChild As ShellItem In arrChildren
            Dim tvwChild As TreeNode = New TreeNode()
            tvwChild.Name = shChild.Path
            tvwChild.Text = shChild.DisplayName
            tvwChild.ImageIndex = shChild.IconIndexNormal
            tvwChild.SelectedImageIndex = shChild.IconIndexOpen
            tvwChild.Tag = shChild
            If shChild.IsFolder And shChild.HasSubFolders Then tvwChild.Nodes.Add("PH")
            tvwRoot.Nodes.Add(tvwChild)
        Next
        Me.Nodes.Clear()
        Me.Nodes.Add(tvwRoot)
        tvwRoot.Expand()
    End Sub
    ''' <summary>
    ''' Get or Set CheckBox for MBTreeViewExplorer
    ''' </summary>
    Private _showCheckBox As Boolean = False
    Public Overloads Property CheckBoxes() As Boolean
        Get
            Return _showCheckBox
        End Get
        Set(ByVal value As Boolean)
            _showCheckBox = value
            'MBTreeViewExplorer_Validating(Me, EventArgs.Empty)
        End Set
    End Property

    Private _SelectedNode As ShellItem = Nothing
    Public Overloads Property SelectedNode() As ShellItem
        Get
            Return _SelectedNode
        End Get
        Set(ByVal value As ShellItem)
            _SelectedNode = value
        End Set
    End Property


    'Private Sub MBExplorer_NodeMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles Me.NodeMouseClick
    '    _SelectedNode = e.Node.Tag
    'End Sub
End Class
