<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Principal
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        IconoBarra.Visible = False
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Principal))
        Dim ShellItem2 As MBTreeViewExplorer.ShellItem = New MBTreeViewExplorer.ShellItem()
        Me.botonParar = New System.Windows.Forms.Button()
        Me.botonRepro = New System.Windows.Forms.Button()
        Me.botonAnt = New System.Windows.Forms.Button()
        Me.botonSig = New System.Windows.Forms.Button()
        Me.botonAbrir = New System.Windows.Forms.Button()
        Me.botonCarpeta = New System.Windows.Forms.Button()
        Me.botonLista = New System.Windows.Forms.Button()
        Me.botonOpciones = New System.Windows.Forms.Button()
        Me.botonSobre = New System.Windows.Forms.Button()
        Me.infoSiguiente = New System.Windows.Forms.Label()
        Me.dspLugar = New System.Windows.Forms.PictureBox()
        Me.dspModo = New System.Windows.Forms.PictureBox()
        Me.dspOrden = New System.Windows.Forms.PictureBox()
        Me.dspEsta = New System.Windows.Forms.PictureBox()
        Me.dspTipo = New System.Windows.Forms.Label()
        Me.dspTrac = New System.Windows.Forms.Label()
        Me.posicionBar = New EConTech.Windows.MACUI.MACTrackBar()
        Me.volBar = New EConTech.Windows.MACUI.MACTrackBar()
        Me.posicion = New System.Windows.Forms.Timer(Me.components)
        Me.AnimPau = New System.Windows.Forms.Timer(Me.components)
        Me.AnimTipo = New System.Windows.Forms.Timer(Me.components)
        Me.dspPos = New System.Windows.Forms.Label()
        Me.PanelLista = New System.Windows.Forms.Panel()
        Me.btnArr = New System.Windows.Forms.Button()
        Me.btnAba = New System.Windows.Forms.Button()
        Me.listaNombres = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.anadePlist = New System.Windows.Forms.Button()
        Me.guardarLista = New System.Windows.Forms.Button()
        Me.borrarTodoLista = New System.Windows.Forms.Button()
        Me.abrirLista = New System.Windows.Forms.Button()
        Me.borrarSellista = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.totalesLista = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.seleccionLista = New System.Windows.Forms.Label()
        Me.PanelCarpeta = New System.Windows.Forms.Panel()
        Me.LabelDirectory = New System.Windows.Forms.Label()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.selecCarpeta = New System.Windows.Forms.Label()
        Me.listaArchivos = New System.Windows.Forms.ListView()
        Me.lAnomb = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lATitulo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.añadeTodoCarpeta = New System.Windows.Forms.Button()
        Me.totalCarpeta = New System.Windows.Forms.Label()
        Me.PanelOpcion = New System.Windows.Forms.Panel()
        Me.OpcTeclasD = New System.Windows.Forms.CheckBox()
        Me.OpcTeclKit = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.OpcButtCambioTeclas = New System.Windows.Forms.Button()
        Me.OpcCambioTeclas = New System.Windows.Forms.ComboBox()
        Me.OpcTeclas = New System.Windows.Forms.CheckBox()
        Me.OpcMsnAudio = New System.Windows.Forms.CheckBox()
        Me.OpcMSNVideo = New System.Windows.Forms.CheckBox()
        Me.OpcMsnTx = New System.Windows.Forms.TextBox()
        Me.OpcEnablMSN = New System.Windows.Forms.CheckBox()
        Me.OpcMostrarMensIconoBarra = New System.Windows.Forms.CheckBox()
        Me.OpcMinimizarIconoBarra = New System.Windows.Forms.CheckBox()
        Me.OpcIconoBarra = New System.Windows.Forms.CheckBox()
        Me.OpcVideo = New System.Windows.Forms.CheckBox()
        Me.OpcGuard = New System.Windows.Forms.CheckBox()
        Me.PanelSobre = New System.Windows.Forms.Panel()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.DialogoAbrir = New System.Windows.Forms.OpenFileDialog()
        Me.DialogoGuardar = New System.Windows.Forms.SaveFileDialog()
        Me.delRepro = New System.Windows.Forms.Timer(Me.components)
        Me.IconoBarra = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.Menupop = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Msiguien = New System.Windows.Forms.ToolStripMenuItem()
        Me.Manterior = New System.Windows.Forms.ToolStripMenuItem()
        Me.Mpausarepro = New System.Windows.Forms.ToolStripMenuItem()
        Me.Mparar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Mactivartecl = New System.Windows.Forms.ToolStripMenuItem()
        Me.MactivarteclD = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Minfo = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.Mcerrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnimTrack = New System.Windows.Forms.Timer(Me.components)
        Me.AnimTitBarra = New System.Windows.Forms.Timer(Me.components)
        Me.BtnCerr = New System.Windows.Forms.Button()
        Me.BtnMini = New System.Windows.Forms.Button()
        Me.dspTempor = New System.Windows.Forms.Label()
        Me.TimerAdelan = New System.Windows.Forms.Timer(Me.components)
        Me.AnimPas = New System.Windows.Forms.Timer(Me.components)
        Me.BtnMute = New System.Windows.Forms.Button()
        Me.dspItipo = New System.Windows.Forms.PictureBox()
        Me.dspRem = New System.Windows.Forms.Label()
        Me.PanelCtrl = New System.Windows.Forms.Panel()
        Me.panelDspTrac = New System.Windows.Forms.Panel()
        Me.botonComp = New System.Windows.Forms.Button()
        Me.botonDVD = New System.Windows.Forms.Button()
        Me.botonCdAudio = New System.Windows.Forms.Button()
        Me.PanelDVD = New System.Windows.Forms.Panel()
        Me.dspDVDDir = New System.Windows.Forms.Label()
        Me.btnDvdMenPrinc = New System.Windows.Forms.Button()
        Me.btnDvdMenuTit = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.comboDvdSubs = New System.Windows.Forms.ComboBox()
        Me.comboDvdIdiomas = New System.Windows.Forms.ComboBox()
        Me.listaDvdCapis = New System.Windows.Forms.ListBox()
        Me.comboDvdTitulos = New System.Windows.Forms.ComboBox()
        Me.btnReproducDVD = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.PanelCDAudio = New System.Windows.Forms.Panel()
        Me.dspAudioEst = New System.Windows.Forms.Label()
        Me.listaAudioTracks = New System.Windows.Forms.ListBox()
        Me.btnReproAudio = New System.Windows.Forms.Button()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.PanelRadio = New System.Windows.Forms.Panel()
        Me.btnGuardarRadio = New System.Windows.Forms.Button()
        Me.btnAbrirRadio = New System.Windows.Forms.Button()
        Me.dspRecout = New System.Windows.Forms.Label()
        Me.btnBorrarTodosTunes = New System.Windows.Forms.Button()
        Me.ListaTunes = New System.Windows.Forms.ListView()
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnAndirRadio = New System.Windows.Forms.Button()
        Me.btnGrabarRadio = New System.Windows.Forms.Button()
        Me.btnQuitarRadio = New System.Windows.Forms.Button()
        Me.btnRadio = New System.Windows.Forms.Button()
        Me.botonSleep = New System.Windows.Forms.Button()
        Me.PanelSleep = New System.Windows.Forms.Panel()
        Me.dspSleep = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.CheckSleep = New System.Windows.Forms.CheckBox()
        Me.SleepSel = New System.Windows.Forms.NumericUpDown()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.SleepTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TreeDir = New MBTreeViewExplorer.MBTreeViewExplorer()
        CType(Me.dspLugar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dspModo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dspOrden, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dspEsta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelLista.SuspendLayout()
        Me.PanelCarpeta.SuspendLayout()
        Me.PanelOpcion.SuspendLayout()
        Me.PanelSobre.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Menupop.SuspendLayout()
        CType(Me.dspItipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelCtrl.SuspendLayout()
        Me.panelDspTrac.SuspendLayout()
        Me.PanelDVD.SuspendLayout()
        Me.PanelCDAudio.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.PanelRadio.SuspendLayout()
        Me.PanelSleep.SuspendLayout()
        CType(Me.SleepSel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'botonParar
        '
        Me.botonParar.BackColor = System.Drawing.Color.Transparent
        Me.botonParar.BackgroundImage = Global.Reproductor_3._0_DVD.My.Resources.Resources.btnParar
        Me.botonParar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.botonParar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.botonParar.FlatAppearance.BorderSize = 0
        Me.botonParar.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.botonParar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.botonParar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.botonParar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.botonParar.Location = New System.Drawing.Point(25, 67)
        Me.botonParar.Name = "botonParar"
        Me.botonParar.Size = New System.Drawing.Size(45, 45)
        Me.botonParar.TabIndex = 2
        Me.botonParar.TabStop = False
        Me.botonParar.UseVisualStyleBackColor = False
        '
        'botonRepro
        '
        Me.botonRepro.BackColor = System.Drawing.Color.Transparent
        Me.botonRepro.BackgroundImage = Global.Reproductor_3._0_DVD.My.Resources.Resources.btnRepro
        Me.botonRepro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.botonRepro.Cursor = System.Windows.Forms.Cursors.Hand
        Me.botonRepro.FlatAppearance.BorderSize = 0
        Me.botonRepro.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.botonRepro.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.botonRepro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.botonRepro.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.botonRepro.Location = New System.Drawing.Point(2, 12)
        Me.botonRepro.Name = "botonRepro"
        Me.botonRepro.Size = New System.Drawing.Size(160, 160)
        Me.botonRepro.TabIndex = 4
        Me.botonRepro.TabStop = False
        Me.botonRepro.UseVisualStyleBackColor = False
        '
        'botonAnt
        '
        Me.botonAnt.BackColor = System.Drawing.Color.Transparent
        Me.botonAnt.BackgroundImage = Global.Reproductor_3._0_DVD.My.Resources.Resources.btnAnt
        Me.botonAnt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.botonAnt.Cursor = System.Windows.Forms.Cursors.Hand
        Me.botonAnt.FlatAppearance.BorderSize = 0
        Me.botonAnt.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.botonAnt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.botonAnt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.botonAnt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.botonAnt.Location = New System.Drawing.Point(-2, 0)
        Me.botonAnt.Name = "botonAnt"
        Me.botonAnt.Size = New System.Drawing.Size(65, 65)
        Me.botonAnt.TabIndex = 5
        Me.botonAnt.TabStop = False
        Me.botonAnt.UseVisualStyleBackColor = False
        '
        'botonSig
        '
        Me.botonSig.BackColor = System.Drawing.Color.Transparent
        Me.botonSig.BackgroundImage = Global.Reproductor_3._0_DVD.My.Resources.Resources.btnSig
        Me.botonSig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.botonSig.Cursor = System.Windows.Forms.Cursors.Hand
        Me.botonSig.FlatAppearance.BorderSize = 0
        Me.botonSig.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.botonSig.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.botonSig.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.botonSig.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.botonSig.Location = New System.Drawing.Point(-3, 110)
        Me.botonSig.Name = "botonSig"
        Me.botonSig.Size = New System.Drawing.Size(65, 65)
        Me.botonSig.TabIndex = 6
        Me.botonSig.TabStop = False
        Me.botonSig.UseVisualStyleBackColor = False
        '
        'botonAbrir
        '
        Me.botonAbrir.BackColor = System.Drawing.Color.Transparent
        Me.botonAbrir.BackgroundImage = Global.Reproductor_3._0_DVD.My.Resources.Resources.btnAbrir
        Me.botonAbrir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.botonAbrir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.botonAbrir.FlatAppearance.BorderSize = 0
        Me.botonAbrir.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.botonAbrir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.botonAbrir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.botonAbrir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.botonAbrir.Location = New System.Drawing.Point(136, 13)
        Me.botonAbrir.Name = "botonAbrir"
        Me.botonAbrir.Size = New System.Drawing.Size(20, 20)
        Me.botonAbrir.TabIndex = 7
        Me.botonAbrir.TabStop = False
        Me.botonAbrir.UseVisualStyleBackColor = False
        '
        'botonCarpeta
        '
        Me.botonCarpeta.BackColor = System.Drawing.Color.Transparent
        Me.botonCarpeta.BackgroundImage = Global.Reproductor_3._0_DVD.My.Resources.Resources.btnCarp
        Me.botonCarpeta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.botonCarpeta.Cursor = System.Windows.Forms.Cursors.Hand
        Me.botonCarpeta.FlatAppearance.BorderSize = 0
        Me.botonCarpeta.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.botonCarpeta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.botonCarpeta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.botonCarpeta.Font = New System.Drawing.Font("Impact", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.botonCarpeta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(39, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.botonCarpeta.Location = New System.Drawing.Point(171, 293)
        Me.botonCarpeta.Name = "botonCarpeta"
        Me.botonCarpeta.Size = New System.Drawing.Size(30, 30)
        Me.botonCarpeta.TabIndex = 9
        Me.botonCarpeta.TabStop = False
        Me.botonCarpeta.UseVisualStyleBackColor = False
        '
        'botonLista
        '
        Me.botonLista.BackColor = System.Drawing.Color.Transparent
        Me.botonLista.BackgroundImage = Global.Reproductor_3._0_DVD.My.Resources.Resources.btnLis
        Me.botonLista.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.botonLista.Cursor = System.Windows.Forms.Cursors.Hand
        Me.botonLista.FlatAppearance.BorderSize = 0
        Me.botonLista.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.botonLista.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.botonLista.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.botonLista.Font = New System.Drawing.Font("Impact", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.botonLista.ForeColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(39, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.botonLista.Location = New System.Drawing.Point(265, 294)
        Me.botonLista.Name = "botonLista"
        Me.botonLista.Size = New System.Drawing.Size(30, 30)
        Me.botonLista.TabIndex = 10
        Me.botonLista.TabStop = False
        Me.botonLista.UseVisualStyleBackColor = False
        '
        'botonOpciones
        '
        Me.botonOpciones.BackColor = System.Drawing.Color.Transparent
        Me.botonOpciones.BackgroundImage = Global.Reproductor_3._0_DVD.My.Resources.Resources.btnOpc
        Me.botonOpciones.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.botonOpciones.Cursor = System.Windows.Forms.Cursors.Hand
        Me.botonOpciones.FlatAppearance.BorderSize = 0
        Me.botonOpciones.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.botonOpciones.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.botonOpciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.botonOpciones.Font = New System.Drawing.Font("Impact", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.botonOpciones.ForeColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(39, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.botonOpciones.Location = New System.Drawing.Point(410, 293)
        Me.botonOpciones.Name = "botonOpciones"
        Me.botonOpciones.Size = New System.Drawing.Size(30, 30)
        Me.botonOpciones.TabIndex = 11
        Me.botonOpciones.TabStop = False
        Me.botonOpciones.UseVisualStyleBackColor = False
        '
        'botonSobre
        '
        Me.botonSobre.BackColor = System.Drawing.Color.Transparent
        Me.botonSobre.BackgroundImage = Global.Reproductor_3._0_DVD.My.Resources.Resources.btnSobre
        Me.botonSobre.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.botonSobre.Cursor = System.Windows.Forms.Cursors.Hand
        Me.botonSobre.FlatAppearance.BorderSize = 0
        Me.botonSobre.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.botonSobre.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.botonSobre.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.botonSobre.Font = New System.Drawing.Font("Impact", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.botonSobre.ForeColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(39, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.botonSobre.Location = New System.Drawing.Point(26, 294)
        Me.botonSobre.Name = "botonSobre"
        Me.botonSobre.Size = New System.Drawing.Size(30, 30)
        Me.botonSobre.TabIndex = 12
        Me.botonSobre.TabStop = False
        Me.botonSobre.UseVisualStyleBackColor = False
        '
        'infoSiguiente
        '
        Me.infoSiguiente.BackColor = System.Drawing.Color.Transparent
        Me.infoSiguiente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.infoSiguiente.ForeColor = System.Drawing.Color.White
        Me.infoSiguiente.Location = New System.Drawing.Point(107, 67)
        Me.infoSiguiente.Name = "infoSiguiente"
        Me.infoSiguiente.Size = New System.Drawing.Size(226, 17)
        Me.infoSiguiente.TabIndex = 13
        Me.infoSiguiente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dspLugar
        '
        Me.dspLugar.BackColor = System.Drawing.Color.Transparent
        Me.dspLugar.BackgroundImage = Global.Reproductor_3._0_DVD.My.Resources.Resources.btnLugCarp
        Me.dspLugar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.dspLugar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dspLugar.Location = New System.Drawing.Point(219, 293)
        Me.dspLugar.Name = "dspLugar"
        Me.dspLugar.Size = New System.Drawing.Size(30, 30)
        Me.dspLugar.TabIndex = 21
        Me.dspLugar.TabStop = False
        '
        'dspModo
        '
        Me.dspModo.BackColor = System.Drawing.Color.Transparent
        Me.dspModo.BackgroundImage = Global.Reproductor_3._0_DVD.My.Resources.Resources.btnRepOnMov
        Me.dspModo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.dspModo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dspModo.Location = New System.Drawing.Point(378, 40)
        Me.dspModo.Name = "dspModo"
        Me.dspModo.Size = New System.Drawing.Size(27, 27)
        Me.dspModo.TabIndex = 22
        Me.dspModo.TabStop = False
        '
        'dspOrden
        '
        Me.dspOrden.BackColor = System.Drawing.Color.Transparent
        Me.dspOrden.BackgroundImage = Global.Reproductor_3._0_DVD.My.Resources.Resources.btnOrdenMov
        Me.dspOrden.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.dspOrden.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dspOrden.Location = New System.Drawing.Point(378, 71)
        Me.dspOrden.Name = "dspOrden"
        Me.dspOrden.Size = New System.Drawing.Size(27, 27)
        Me.dspOrden.TabIndex = 23
        Me.dspOrden.TabStop = False
        '
        'dspEsta
        '
        Me.dspEsta.BackColor = System.Drawing.Color.Transparent
        Me.dspEsta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.dspEsta.Location = New System.Drawing.Point(107, 45)
        Me.dspEsta.Name = "dspEsta"
        Me.dspEsta.Size = New System.Drawing.Size(15, 15)
        Me.dspEsta.TabIndex = 24
        Me.dspEsta.TabStop = False
        '
        'dspTipo
        '
        Me.dspTipo.BackColor = System.Drawing.Color.Transparent
        Me.dspTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.dspTipo.ForeColor = System.Drawing.Color.White
        Me.dspTipo.Location = New System.Drawing.Point(181, 84)
        Me.dspTipo.Name = "dspTipo"
        Me.dspTipo.Size = New System.Drawing.Size(78, 16)
        Me.dspTipo.TabIndex = 25
        Me.dspTipo.Text = "Preparado"
        Me.dspTipo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dspTrac
        '
        Me.dspTrac.AutoSize = True
        Me.dspTrac.BackColor = System.Drawing.Color.Transparent
        Me.dspTrac.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.dspTrac.ForeColor = System.Drawing.Color.White
        Me.dspTrac.Location = New System.Drawing.Point(2, 0)
        Me.dspTrac.Name = "dspTrac"
        Me.dspTrac.Size = New System.Drawing.Size(0, 13)
        Me.dspTrac.TabIndex = 26
        Me.dspTrac.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'posicionBar
        '
        Me.posicionBar.BackColor = System.Drawing.Color.Transparent
        Me.posicionBar.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Me.posicionBar.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.posicionBar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(123, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(123, Byte), Integer))
        Me.posicionBar.IndentHeight = 6
        Me.posicionBar.LargeChange = 1
        Me.posicionBar.Location = New System.Drawing.Point(100, 106)
        Me.posicionBar.Maximum = 10
        Me.posicionBar.Minimum = 0
        Me.posicionBar.Name = "posicionBar"
        Me.posicionBar.Size = New System.Drawing.Size(240, 25)
        Me.posicionBar.TabIndex = 59
        Me.posicionBar.TextTickStyle = System.Windows.Forms.TickStyle.None
        Me.posicionBar.TickColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.posicionBar.TickHeight = 4
        Me.posicionBar.TickStyle = System.Windows.Forms.TickStyle.None
        Me.posicionBar.TrackerColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.posicionBar.TrackerSize = New System.Drawing.Size(13, 13)
        Me.posicionBar.TrackLineColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.posicionBar.TrackLineHeight = 3
        Me.posicionBar.Value = 0
        '
        'volBar
        '
        Me.volBar.BackColor = System.Drawing.Color.Transparent
        Me.volBar.BorderColor = System.Drawing.Color.Red
        Me.volBar.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.volBar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(123, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(123, Byte), Integer))
        Me.volBar.IndentHeight = 6
        Me.volBar.LargeChange = 1
        Me.volBar.Location = New System.Drawing.Point(361, 128)
        Me.volBar.Maximum = 1000
        Me.volBar.Minimum = 0
        Me.volBar.Name = "volBar"
        Me.volBar.Size = New System.Drawing.Size(59, 25)
        Me.volBar.TabIndex = 60
        Me.volBar.TextTickStyle = System.Windows.Forms.TickStyle.None
        Me.volBar.TickColor = System.Drawing.Color.Silver
        Me.volBar.TickHeight = 4
        Me.volBar.TickStyle = System.Windows.Forms.TickStyle.None
        Me.volBar.TrackerColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.volBar.TrackerSize = New System.Drawing.Size(13, 13)
        Me.volBar.TrackLineColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.volBar.TrackLineHeight = 5
        Me.volBar.Value = 1000
        '
        'posicion
        '
        Me.posicion.Interval = 250
        '
        'AnimPau
        '
        Me.AnimPau.Interval = 150
        '
        'AnimTipo
        '
        Me.AnimTipo.Interval = 500
        '
        'dspPos
        '
        Me.dspPos.BackColor = System.Drawing.Color.Transparent
        Me.dspPos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.dspPos.ForeColor = System.Drawing.Color.White
        Me.dspPos.Location = New System.Drawing.Point(76, 126)
        Me.dspPos.Name = "dspPos"
        Me.dspPos.Size = New System.Drawing.Size(78, 14)
        Me.dspPos.TabIndex = 61
        Me.dspPos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PanelLista
        '
        Me.PanelLista.BackColor = System.Drawing.Color.Black
        Me.PanelLista.Controls.Add(Me.btnArr)
        Me.PanelLista.Controls.Add(Me.btnAba)
        Me.PanelLista.Controls.Add(Me.listaNombres)
        Me.PanelLista.Controls.Add(Me.anadePlist)
        Me.PanelLista.Controls.Add(Me.guardarLista)
        Me.PanelLista.Controls.Add(Me.borrarTodoLista)
        Me.PanelLista.Controls.Add(Me.abrirLista)
        Me.PanelLista.Controls.Add(Me.borrarSellista)
        Me.PanelLista.Controls.Add(Me.Label7)
        Me.PanelLista.Controls.Add(Me.totalesLista)
        Me.PanelLista.Controls.Add(Me.Label9)
        Me.PanelLista.Controls.Add(Me.seleccionLista)
        Me.PanelLista.Location = New System.Drawing.Point(24, 16)
        Me.PanelLista.Name = "PanelLista"
        Me.PanelLista.Size = New System.Drawing.Size(411, 275)
        Me.PanelLista.TabIndex = 67
        Me.PanelLista.Visible = False
        '
        'btnArr
        '
        Me.btnArr.BackColor = System.Drawing.Color.Transparent
        Me.btnArr.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.btnArr.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnArr.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnArr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.btnArr.ForeColor = System.Drawing.Color.White
        Me.btnArr.Location = New System.Drawing.Point(215, 204)
        Me.btnArr.Name = "btnArr"
        Me.btnArr.Size = New System.Drawing.Size(31, 26)
        Me.btnArr.TabIndex = 102
        Me.btnArr.Text = "^"
        Me.btnArr.UseVisualStyleBackColor = False
        '
        'btnAba
        '
        Me.btnAba.BackColor = System.Drawing.Color.Transparent
        Me.btnAba.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.btnAba.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnAba.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAba.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.btnAba.ForeColor = System.Drawing.Color.White
        Me.btnAba.Location = New System.Drawing.Point(173, 204)
        Me.btnAba.Name = "btnAba"
        Me.btnAba.Size = New System.Drawing.Size(31, 26)
        Me.btnAba.TabIndex = 102
        Me.btnAba.Text = "v"
        Me.btnAba.UseVisualStyleBackColor = False
        '
        'listaNombres
        '
        Me.listaNombres.BackColor = System.Drawing.Color.Black
        Me.listaNombres.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.listaNombres.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader5, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10})
        Me.listaNombres.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.listaNombres.ForeColor = System.Drawing.Color.White
        Me.listaNombres.FullRowSelect = True
        Me.listaNombres.HideSelection = False
        Me.listaNombres.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.listaNombres.Location = New System.Drawing.Point(5, 1)
        Me.listaNombres.MultiSelect = False
        Me.listaNombres.Name = "listaNombres"
        Me.listaNombres.ShowItemToolTips = True
        Me.listaNombres.Size = New System.Drawing.Size(399, 199)
        Me.listaNombres.TabIndex = 96
        Me.listaNombres.UseCompatibleStateImageBehavior = False
        Me.listaNombres.View = System.Windows.Forms.View.Details
        Me.listaNombres.VirtualListSize = 20
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Nombre"
        Me.ColumnHeader1.Width = 284
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Artista"
        Me.ColumnHeader5.Width = 91
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Titulo"
        Me.ColumnHeader7.Width = 77
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Album"
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Genero"
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Directorio"
        '
        'anadePlist
        '
        Me.anadePlist.BackColor = System.Drawing.Color.Transparent
        Me.anadePlist.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.anadePlist.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.anadePlist.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.anadePlist.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.anadePlist.ForeColor = System.Drawing.Color.White
        Me.anadePlist.Location = New System.Drawing.Point(118, 204)
        Me.anadePlist.Name = "anadePlist"
        Me.anadePlist.Size = New System.Drawing.Size(31, 26)
        Me.anadePlist.TabIndex = 64
        Me.anadePlist.Text = "+"
        Me.anadePlist.UseVisualStyleBackColor = False
        '
        'guardarLista
        '
        Me.guardarLista.BackColor = System.Drawing.Color.Transparent
        Me.guardarLista.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.guardarLista.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.guardarLista.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.guardarLista.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.guardarLista.ForeColor = System.Drawing.Color.White
        Me.guardarLista.Location = New System.Drawing.Point(282, 242)
        Me.guardarLista.Name = "guardarLista"
        Me.guardarLista.Size = New System.Drawing.Size(124, 26)
        Me.guardarLista.TabIndex = 62
        Me.guardarLista.Text = "Guardar Lista"
        Me.guardarLista.UseVisualStyleBackColor = False
        '
        'borrarTodoLista
        '
        Me.borrarTodoLista.BackColor = System.Drawing.Color.Transparent
        Me.borrarTodoLista.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.borrarTodoLista.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.borrarTodoLista.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.borrarTodoLista.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.borrarTodoLista.ForeColor = System.Drawing.Color.White
        Me.borrarTodoLista.Location = New System.Drawing.Point(145, 243)
        Me.borrarTodoLista.Name = "borrarTodoLista"
        Me.borrarTodoLista.Size = New System.Drawing.Size(124, 26)
        Me.borrarTodoLista.TabIndex = 61
        Me.borrarTodoLista.Text = "Borrar Todo"
        Me.borrarTodoLista.UseVisualStyleBackColor = False
        '
        'abrirLista
        '
        Me.abrirLista.BackColor = System.Drawing.Color.Transparent
        Me.abrirLista.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.abrirLista.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.abrirLista.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.abrirLista.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.abrirLista.ForeColor = System.Drawing.Color.White
        Me.abrirLista.Location = New System.Drawing.Point(7, 244)
        Me.abrirLista.Name = "abrirLista"
        Me.abrirLista.Size = New System.Drawing.Size(124, 26)
        Me.abrirLista.TabIndex = 60
        Me.abrirLista.Text = "Abrir Lista"
        Me.abrirLista.UseVisualStyleBackColor = False
        '
        'borrarSellista
        '
        Me.borrarSellista.BackColor = System.Drawing.Color.Transparent
        Me.borrarSellista.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.borrarSellista.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.borrarSellista.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.borrarSellista.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.borrarSellista.ForeColor = System.Drawing.Color.White
        Me.borrarSellista.Location = New System.Drawing.Point(271, 204)
        Me.borrarSellista.Name = "borrarSellista"
        Me.borrarSellista.Size = New System.Drawing.Size(31, 26)
        Me.borrarSellista.TabIndex = 59
        Me.borrarSellista.Text = "-"
        Me.borrarSellista.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(307, 203)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(99, 13)
        Me.Label7.TabIndex = 57
        Me.Label7.Text = "Totales"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'totalesLista
        '
        Me.totalesLista.BackColor = System.Drawing.Color.Transparent
        Me.totalesLista.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.totalesLista.ForeColor = System.Drawing.Color.White
        Me.totalesLista.Location = New System.Drawing.Point(307, 220)
        Me.totalesLista.Name = "totalesLista"
        Me.totalesLista.Size = New System.Drawing.Size(99, 13)
        Me.totalesLista.TabIndex = 56
        Me.totalesLista.Text = "0"
        Me.totalesLista.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(4, 203)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(99, 13)
        Me.Label9.TabIndex = 55
        Me.Label9.Text = "Seleccion"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'seleccionLista
        '
        Me.seleccionLista.BackColor = System.Drawing.Color.Transparent
        Me.seleccionLista.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.seleccionLista.ForeColor = System.Drawing.Color.White
        Me.seleccionLista.Location = New System.Drawing.Point(4, 220)
        Me.seleccionLista.Name = "seleccionLista"
        Me.seleccionLista.Size = New System.Drawing.Size(99, 13)
        Me.seleccionLista.TabIndex = 54
        Me.seleccionLista.Text = "0"
        Me.seleccionLista.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PanelCarpeta
        '
        Me.PanelCarpeta.BackColor = System.Drawing.Color.Black
        Me.PanelCarpeta.Controls.Add(Me.LabelDirectory)
        Me.PanelCarpeta.Controls.Add(Me.btnUpdate)
        Me.PanelCarpeta.Controls.Add(Me.Label5)
        Me.PanelCarpeta.Controls.Add(Me.Label4)
        Me.PanelCarpeta.Controls.Add(Me.selecCarpeta)
        Me.PanelCarpeta.Controls.Add(Me.TreeDir)
        Me.PanelCarpeta.Controls.Add(Me.listaArchivos)
        Me.PanelCarpeta.Controls.Add(Me.añadeTodoCarpeta)
        Me.PanelCarpeta.Controls.Add(Me.totalCarpeta)
        Me.PanelCarpeta.Location = New System.Drawing.Point(26, 18)
        Me.PanelCarpeta.Name = "PanelCarpeta"
        Me.PanelCarpeta.Size = New System.Drawing.Size(411, 275)
        Me.PanelCarpeta.TabIndex = 68
        Me.PanelCarpeta.Visible = False
        '
        'LabelDirectory
        '
        Me.LabelDirectory.BackColor = System.Drawing.Color.Transparent
        Me.LabelDirectory.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.LabelDirectory.ForeColor = System.Drawing.Color.White
        Me.LabelDirectory.Location = New System.Drawing.Point(5, 90)
        Me.LabelDirectory.Name = "LabelDirectory"
        Me.LabelDirectory.Size = New System.Drawing.Size(327, 17)
        Me.LabelDirectory.TabIndex = 38
        Me.LabelDirectory.Text = "Seleccione un directorio"
        Me.LabelDirectory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnUpdate
        '
        Me.btnUpdate.BackColor = System.Drawing.Color.Transparent
        Me.btnUpdate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.btnUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.btnUpdate.ForeColor = System.Drawing.Color.White
        Me.btnUpdate.Location = New System.Drawing.Point(339, 3)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(31, 26)
        Me.btnUpdate.TabIndex = 37
        Me.btnUpdate.Text = "U"
        Me.btnUpdate.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(338, 71)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 19)
        Me.Label5.TabIndex = 33
        Me.Label5.Text = "Totales"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(337, 37)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 19)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "Seleccion"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'selecCarpeta
        '
        Me.selecCarpeta.BackColor = System.Drawing.Color.Transparent
        Me.selecCarpeta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.selecCarpeta.ForeColor = System.Drawing.Color.White
        Me.selecCarpeta.Location = New System.Drawing.Point(339, 56)
        Me.selecCarpeta.Name = "selecCarpeta"
        Me.selecCarpeta.Size = New System.Drawing.Size(70, 19)
        Me.selecCarpeta.TabIndex = 30
        Me.selecCarpeta.Text = "0"
        Me.selecCarpeta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'listaArchivos
        '
        Me.listaArchivos.BackColor = System.Drawing.Color.Black
        Me.listaArchivos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.listaArchivos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lAnomb, Me.lATitulo, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.listaArchivos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.listaArchivos.ForeColor = System.Drawing.Color.White
        Me.listaArchivos.FullRowSelect = True
        Me.listaArchivos.HideSelection = False
        Me.listaArchivos.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.listaArchivos.Location = New System.Drawing.Point(3, 109)
        Me.listaArchivos.MultiSelect = False
        Me.listaArchivos.Name = "listaArchivos"
        Me.listaArchivos.ShowItemToolTips = True
        Me.listaArchivos.Size = New System.Drawing.Size(406, 157)
        Me.listaArchivos.TabIndex = 35
        Me.listaArchivos.UseCompatibleStateImageBehavior = False
        Me.listaArchivos.View = System.Windows.Forms.View.Details
        '
        'lAnomb
        '
        Me.lAnomb.Text = "Nombre"
        Me.lAnomb.Width = 175
        '
        'lATitulo
        '
        Me.lATitulo.Text = "Artista"
        Me.lATitulo.Width = 103
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Titulo"
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Album"
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Genero"
        '
        'añadeTodoCarpeta
        '
        Me.añadeTodoCarpeta.BackColor = System.Drawing.Color.Transparent
        Me.añadeTodoCarpeta.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.añadeTodoCarpeta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.añadeTodoCarpeta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.añadeTodoCarpeta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.añadeTodoCarpeta.ForeColor = System.Drawing.Color.White
        Me.añadeTodoCarpeta.Location = New System.Drawing.Point(377, 3)
        Me.añadeTodoCarpeta.Name = "añadeTodoCarpeta"
        Me.añadeTodoCarpeta.Size = New System.Drawing.Size(31, 26)
        Me.añadeTodoCarpeta.TabIndex = 34
        Me.añadeTodoCarpeta.Text = "+"
        Me.añadeTodoCarpeta.UseVisualStyleBackColor = False
        '
        'totalCarpeta
        '
        Me.totalCarpeta.BackColor = System.Drawing.Color.Transparent
        Me.totalCarpeta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.totalCarpeta.ForeColor = System.Drawing.Color.White
        Me.totalCarpeta.Location = New System.Drawing.Point(339, 91)
        Me.totalCarpeta.Name = "totalCarpeta"
        Me.totalCarpeta.Size = New System.Drawing.Size(70, 19)
        Me.totalCarpeta.TabIndex = 32
        Me.totalCarpeta.Text = "0"
        Me.totalCarpeta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PanelOpcion
        '
        Me.PanelOpcion.BackColor = System.Drawing.Color.Black
        Me.PanelOpcion.Controls.Add(Me.OpcTeclasD)
        Me.PanelOpcion.Controls.Add(Me.OpcTeclKit)
        Me.PanelOpcion.Controls.Add(Me.Label8)
        Me.PanelOpcion.Controls.Add(Me.Label6)
        Me.PanelOpcion.Controls.Add(Me.Label3)
        Me.PanelOpcion.Controls.Add(Me.Label2)
        Me.PanelOpcion.Controls.Add(Me.Label1)
        Me.PanelOpcion.Controls.Add(Me.OpcButtCambioTeclas)
        Me.PanelOpcion.Controls.Add(Me.OpcCambioTeclas)
        Me.PanelOpcion.Controls.Add(Me.OpcTeclas)
        Me.PanelOpcion.Controls.Add(Me.OpcMsnAudio)
        Me.PanelOpcion.Controls.Add(Me.OpcMSNVideo)
        Me.PanelOpcion.Controls.Add(Me.OpcMsnTx)
        Me.PanelOpcion.Controls.Add(Me.OpcEnablMSN)
        Me.PanelOpcion.Controls.Add(Me.OpcMostrarMensIconoBarra)
        Me.PanelOpcion.Controls.Add(Me.OpcMinimizarIconoBarra)
        Me.PanelOpcion.Controls.Add(Me.OpcIconoBarra)
        Me.PanelOpcion.Controls.Add(Me.OpcVideo)
        Me.PanelOpcion.Controls.Add(Me.OpcGuard)
        Me.PanelOpcion.Location = New System.Drawing.Point(26, 15)
        Me.PanelOpcion.Name = "PanelOpcion"
        Me.PanelOpcion.Size = New System.Drawing.Size(411, 276)
        Me.PanelOpcion.TabIndex = 70
        Me.PanelOpcion.Visible = False
        '
        'OpcTeclasD
        '
        Me.OpcTeclasD.AutoSize = True
        Me.OpcTeclasD.BackColor = System.Drawing.Color.Black
        Me.OpcTeclasD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.OpcTeclasD.ForeColor = System.Drawing.Color.White
        Me.OpcTeclasD.Location = New System.Drawing.Point(114, 228)
        Me.OpcTeclasD.Name = "OpcTeclasD"
        Me.OpcTeclasD.Size = New System.Drawing.Size(82, 21)
        Me.OpcTeclasD.TabIndex = 95
        Me.OpcTeclasD.Text = "Activar Kit 2"
        Me.OpcTeclasD.UseVisualStyleBackColor = False
        '
        'OpcTeclKit
        '
        Me.OpcTeclKit.BackColor = System.Drawing.Color.Black
        Me.OpcTeclKit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.OpcTeclKit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.OpcTeclKit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.OpcTeclKit.ForeColor = System.Drawing.Color.White
        Me.OpcTeclKit.FormattingEnabled = True
        Me.OpcTeclKit.Items.AddRange(New Object() {"Kit 1", "Kit 2"})
        Me.OpcTeclKit.Location = New System.Drawing.Point(6, 247)
        Me.OpcTeclKit.Name = "OpcTeclKit"
        Me.OpcTeclKit.Size = New System.Drawing.Size(89, 17)
        Me.OpcTeclKit.TabIndex = 94
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel)
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(11, 215)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(400, 13)
        Me.Label8.TabIndex = 90
        Me.Label8.Text = "______Teclas De Operacion Directa______"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel)
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(11, 136)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(397, 13)
        Me.Label6.TabIndex = 89
        Me.Label6.Text = "______Plugin MSN Messenger______"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(11, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(382, 13)
        Me.Label3.TabIndex = 88
        Me.Label3.Text = "______Barra De Tareas______"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(11, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(397, 13)
        Me.Label2.TabIndex = 87
        Me.Label2.Text = "______Opciones De Video______"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(11, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(397, 13)
        Me.Label1.TabIndex = 86
        Me.Label1.Text = "______Estado Del Reproductor______"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'OpcButtCambioTeclas
        '
        Me.OpcButtCambioTeclas.BackColor = System.Drawing.Color.Transparent
        Me.OpcButtCambioTeclas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.OpcButtCambioTeclas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
        Me.OpcButtCambioTeclas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.OpcButtCambioTeclas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.OpcButtCambioTeclas.ForeColor = System.Drawing.Color.White
        Me.OpcButtCambioTeclas.Location = New System.Drawing.Point(284, 247)
        Me.OpcButtCambioTeclas.Name = "OpcButtCambioTeclas"
        Me.OpcButtCambioTeclas.Size = New System.Drawing.Size(124, 26)
        Me.OpcButtCambioTeclas.TabIndex = 85
        Me.OpcButtCambioTeclas.Text = "Cambiar Tecla"
        Me.OpcButtCambioTeclas.UseVisualStyleBackColor = False
        '
        'OpcCambioTeclas
        '
        Me.OpcCambioTeclas.BackColor = System.Drawing.Color.Black
        Me.OpcCambioTeclas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.OpcCambioTeclas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.OpcCambioTeclas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.OpcCambioTeclas.ForeColor = System.Drawing.Color.White
        Me.OpcCambioTeclas.FormattingEnabled = True
        Me.OpcCambioTeclas.Items.AddRange(New Object() {"Reproducc. / Pausa", "Siguiente", "Anterior", "Parar", "Adelantar", "Atrazar", "Subir Volumen", "Bajar Volumen", "Silenciar"})
        Me.OpcCambioTeclas.Location = New System.Drawing.Point(99, 247)
        Me.OpcCambioTeclas.Name = "OpcCambioTeclas"
        Me.OpcCambioTeclas.Size = New System.Drawing.Size(182, 17)
        Me.OpcCambioTeclas.TabIndex = 10
        '
        'OpcTeclas
        '
        Me.OpcTeclas.AutoSize = True
        Me.OpcTeclas.BackColor = System.Drawing.Color.Black
        Me.OpcTeclas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.OpcTeclas.ForeColor = System.Drawing.Color.White
        Me.OpcTeclas.Location = New System.Drawing.Point(10, 228)
        Me.OpcTeclas.Name = "OpcTeclas"
        Me.OpcTeclas.Size = New System.Drawing.Size(82, 21)
        Me.OpcTeclas.TabIndex = 9
        Me.OpcTeclas.Text = "Activar Kit 1"
        Me.OpcTeclas.UseVisualStyleBackColor = False
        '
        'OpcMsnAudio
        '
        Me.OpcMsnAudio.AutoSize = True
        Me.OpcMsnAudio.BackColor = System.Drawing.Color.Black
        Me.OpcMsnAudio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.OpcMsnAudio.ForeColor = System.Drawing.Color.White
        Me.OpcMsnAudio.Location = New System.Drawing.Point(250, 194)
        Me.OpcMsnAudio.Name = "OpcMsnAudio"
        Me.OpcMsnAudio.Size = New System.Drawing.Size(131, 21)
        Me.OpcMsnAudio.TabIndex = 8
        Me.OpcMsnAudio.Text = "Mostrar Mens con audio"
        Me.OpcMsnAudio.UseVisualStyleBackColor = False
        '
        'OpcMSNVideo
        '
        Me.OpcMSNVideo.AutoSize = True
        Me.OpcMSNVideo.BackColor = System.Drawing.Color.Black
        Me.OpcMSNVideo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.OpcMSNVideo.ForeColor = System.Drawing.Color.White
        Me.OpcMSNVideo.Location = New System.Drawing.Point(12, 193)
        Me.OpcMSNVideo.Name = "OpcMSNVideo"
        Me.OpcMSNVideo.Size = New System.Drawing.Size(132, 21)
        Me.OpcMSNVideo.TabIndex = 7
        Me.OpcMSNVideo.Text = "Mostrar Mens con video"
        Me.OpcMSNVideo.UseVisualStyleBackColor = False
        '
        'OpcMsnTx
        '
        Me.OpcMsnTx.BackColor = System.Drawing.Color.Black
        Me.OpcMsnTx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.OpcMsnTx.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OpcMsnTx.ForeColor = System.Drawing.Color.White
        Me.OpcMsnTx.Location = New System.Drawing.Point(12, 172)
        Me.OpcMsnTx.Name = "OpcMsnTx"
        Me.OpcMsnTx.Size = New System.Drawing.Size(396, 26)
        Me.OpcMsnTx.TabIndex = 6
        '
        'OpcEnablMSN
        '
        Me.OpcEnablMSN.AutoSize = True
        Me.OpcEnablMSN.BackColor = System.Drawing.Color.Black
        Me.OpcEnablMSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.OpcEnablMSN.ForeColor = System.Drawing.Color.White
        Me.OpcEnablMSN.Location = New System.Drawing.Point(12, 152)
        Me.OpcEnablMSN.Name = "OpcEnablMSN"
        Me.OpcEnablMSN.Size = New System.Drawing.Size(257, 21)
        Me.OpcEnablMSN.TabIndex = 5
        Me.OpcEnablMSN.Text = "Mostrar ""lo que estoy escuchando"" en MSN messenger"
        Me.OpcEnablMSN.UseVisualStyleBackColor = False
        '
        'OpcMostrarMensIconoBarra
        '
        Me.OpcMostrarMensIconoBarra.AutoSize = True
        Me.OpcMostrarMensIconoBarra.BackColor = System.Drawing.Color.Black
        Me.OpcMostrarMensIconoBarra.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.OpcMostrarMensIconoBarra.ForeColor = System.Drawing.Color.White
        Me.OpcMostrarMensIconoBarra.Location = New System.Drawing.Point(12, 117)
        Me.OpcMostrarMensIconoBarra.Name = "OpcMostrarMensIconoBarra"
        Me.OpcMostrarMensIconoBarra.Size = New System.Drawing.Size(133, 21)
        Me.OpcMostrarMensIconoBarra.TabIndex = 4
        Me.OpcMostrarMensIconoBarra.Text = "Mostrar mensajes popup"
        Me.OpcMostrarMensIconoBarra.UseVisualStyleBackColor = False
        '
        'OpcMinimizarIconoBarra
        '
        Me.OpcMinimizarIconoBarra.AutoSize = True
        Me.OpcMinimizarIconoBarra.BackColor = System.Drawing.Color.Black
        Me.OpcMinimizarIconoBarra.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.OpcMinimizarIconoBarra.ForeColor = System.Drawing.Color.White
        Me.OpcMinimizarIconoBarra.Location = New System.Drawing.Point(12, 99)
        Me.OpcMinimizarIconoBarra.Name = "OpcMinimizarIconoBarra"
        Me.OpcMinimizarIconoBarra.Size = New System.Drawing.Size(151, 21)
        Me.OpcMinimizarIconoBarra.TabIndex = 3
        Me.OpcMinimizarIconoBarra.Text = "Minimizar a la barra de tareas"
        Me.OpcMinimizarIconoBarra.UseVisualStyleBackColor = False
        '
        'OpcIconoBarra
        '
        Me.OpcIconoBarra.AutoSize = True
        Me.OpcIconoBarra.BackColor = System.Drawing.Color.Black
        Me.OpcIconoBarra.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.OpcIconoBarra.ForeColor = System.Drawing.Color.White
        Me.OpcIconoBarra.Location = New System.Drawing.Point(12, 81)
        Me.OpcIconoBarra.Name = "OpcIconoBarra"
        Me.OpcIconoBarra.Size = New System.Drawing.Size(173, 21)
        Me.OpcIconoBarra.TabIndex = 2
        Me.OpcIconoBarra.Text = "Añadir un icono a la barra de tareas"
        Me.OpcIconoBarra.UseVisualStyleBackColor = False
        '
        'OpcVideo
        '
        Me.OpcVideo.AutoSize = True
        Me.OpcVideo.BackColor = System.Drawing.Color.Black
        Me.OpcVideo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.OpcVideo.ForeColor = System.Drawing.Color.White
        Me.OpcVideo.Location = New System.Drawing.Point(12, 49)
        Me.OpcVideo.Name = "OpcVideo"
        Me.OpcVideo.Size = New System.Drawing.Size(246, 21)
        Me.OpcVideo.TabIndex = 1
        Me.OpcVideo.Text = "Reiniciar la posicion y tamaño de la ventana de video"
        Me.OpcVideo.UseVisualStyleBackColor = False
        '
        'OpcGuard
        '
        Me.OpcGuard.AutoSize = True
        Me.OpcGuard.BackColor = System.Drawing.Color.Black
        Me.OpcGuard.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.OpcGuard.ForeColor = System.Drawing.Color.White
        Me.OpcGuard.Location = New System.Drawing.Point(12, 16)
        Me.OpcGuard.Name = "OpcGuard"
        Me.OpcGuard.Size = New System.Drawing.Size(193, 21)
        Me.OpcGuard.TabIndex = 0
        Me.OpcGuard.Text = "Guardar el ultimo estado del reproductor"
        Me.OpcGuard.UseVisualStyleBackColor = False
        '
        'PanelSobre
        '
        Me.PanelSobre.BackColor = System.Drawing.Color.Black
        Me.PanelSobre.Controls.Add(Me.Label21)
        Me.PanelSobre.Controls.Add(Me.Label20)
        Me.PanelSobre.Controls.Add(Me.PictureBox5)
        Me.PanelSobre.Location = New System.Drawing.Point(27, 15)
        Me.PanelSobre.Name = "PanelSobre"
        Me.PanelSobre.Size = New System.Drawing.Size(411, 275)
        Me.PanelSobre.TabIndex = 69
        Me.PanelSobre.Visible = False
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.Label21.ForeColor = System.Drawing.Color.White
        Me.Label21.Location = New System.Drawing.Point(91, 106)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(220, 28)
        Me.Label21.TabIndex = 36
        Me.Label21.Text = "Version 3.3 DVD"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Black
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(49, 131)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(322, 129)
        Me.Label20.TabIndex = 35
        Me.Label20.Text = resources.GetString("Label20.Text")
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox5.BackgroundImage = Global.Reproductor_3._0_DVD.My.Resources.Resources.imgLogo
        Me.PictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox5.Location = New System.Drawing.Point(108, 3)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(191, 103)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox5.TabIndex = 33
        Me.PictureBox5.TabStop = False
        '
        'delRepro
        '
        Me.delRepro.Interval = 50
        '
        'IconoBarra
        '
        Me.IconoBarra.ContextMenuStrip = Me.Menupop
        Me.IconoBarra.Icon = CType(resources.GetObject("IconoBarra.Icon"), System.Drawing.Icon)
        Me.IconoBarra.Text = "Mini Media Player 3"
        '
        'Menupop
        '
        Me.Menupop.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.Menupop.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Msiguien, Me.Manterior, Me.Mpausarepro, Me.Mparar, Me.ToolStripSeparator1, Me.Mactivartecl, Me.MactivarteclD, Me.ToolStripSeparator2, Me.Minfo, Me.ToolStripSeparator3, Me.Mcerrar})
        Me.Menupop.Name = "Menupop"
        Me.Menupop.Size = New System.Drawing.Size(246, 262)
        '
        'Msiguien
        '
        Me.Msiguien.Image = CType(resources.GetObject("Msiguien.Image"), System.Drawing.Image)
        Me.Msiguien.Name = "Msiguien"
        Me.Msiguien.Size = New System.Drawing.Size(245, 30)
        Me.Msiguien.Text = "Siguiente"
        '
        'Manterior
        '
        Me.Manterior.Image = CType(resources.GetObject("Manterior.Image"), System.Drawing.Image)
        Me.Manterior.Name = "Manterior"
        Me.Manterior.Size = New System.Drawing.Size(245, 30)
        Me.Manterior.Text = "Anterior"
        '
        'Mpausarepro
        '
        Me.Mpausarepro.Image = CType(resources.GetObject("Mpausarepro.Image"), System.Drawing.Image)
        Me.Mpausarepro.Name = "Mpausarepro"
        Me.Mpausarepro.Size = New System.Drawing.Size(245, 30)
        Me.Mpausarepro.Text = "Pausa / Reproducir"
        '
        'Mparar
        '
        Me.Mparar.Image = CType(resources.GetObject("Mparar.Image"), System.Drawing.Image)
        Me.Mparar.Name = "Mparar"
        Me.Mparar.Size = New System.Drawing.Size(245, 30)
        Me.Mparar.Text = "Parar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(242, 6)
        '
        'Mactivartecl
        '
        Me.Mactivartecl.Image = CType(resources.GetObject("Mactivartecl.Image"), System.Drawing.Image)
        Me.Mactivartecl.Name = "Mactivartecl"
        Me.Mactivartecl.Size = New System.Drawing.Size(245, 30)
        Me.Mactivartecl.Text = "Activar Kit 1"
        '
        'MactivarteclD
        '
        Me.MactivarteclD.Image = Global.Reproductor_3._0_DVD.My.Resources.Resources.popKey
        Me.MactivarteclD.Name = "MactivarteclD"
        Me.MactivarteclD.Size = New System.Drawing.Size(245, 30)
        Me.MactivarteclD.Text = "Activar kit 2"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(242, 6)
        '
        'Minfo
        '
        Me.Minfo.Image = CType(resources.GetObject("Minfo.Image"), System.Drawing.Image)
        Me.Minfo.Name = "Minfo"
        Me.Minfo.Size = New System.Drawing.Size(245, 30)
        Me.Minfo.Text = "Informacion"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(242, 6)
        '
        'Mcerrar
        '
        Me.Mcerrar.Image = CType(resources.GetObject("Mcerrar.Image"), System.Drawing.Image)
        Me.Mcerrar.Name = "Mcerrar"
        Me.Mcerrar.Size = New System.Drawing.Size(245, 30)
        Me.Mcerrar.Text = "Cerrar"
        '
        'AnimTrack
        '
        Me.AnimTrack.Interval = 30
        '
        'AnimTitBarra
        '
        Me.AnimTitBarra.Interval = 3000
        '
        'BtnCerr
        '
        Me.BtnCerr.BackColor = System.Drawing.Color.Transparent
        Me.BtnCerr.BackgroundImage = Global.Reproductor_3._0_DVD.My.Resources.Resources.btnClose
        Me.BtnCerr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnCerr.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCerr.FlatAppearance.BorderSize = 0
        Me.BtnCerr.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.BtnCerr.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BtnCerr.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.BtnCerr.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCerr.Font = New System.Drawing.Font("Impact", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCerr.ForeColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(39, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.BtnCerr.Location = New System.Drawing.Point(392, 10)
        Me.BtnCerr.Name = "BtnCerr"
        Me.BtnCerr.Size = New System.Drawing.Size(20, 20)
        Me.BtnCerr.TabIndex = 88
        Me.BtnCerr.TabStop = False
        Me.BtnCerr.UseVisualStyleBackColor = False
        '
        'BtnMini
        '
        Me.BtnMini.BackColor = System.Drawing.Color.Transparent
        Me.BtnMini.BackgroundImage = Global.Reproductor_3._0_DVD.My.Resources.Resources.btnMin
        Me.BtnMini.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnMini.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnMini.FlatAppearance.BorderSize = 0
        Me.BtnMini.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.BtnMini.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BtnMini.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.BtnMini.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnMini.Font = New System.Drawing.Font("Impact", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnMini.ForeColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(39, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.BtnMini.Location = New System.Drawing.Point(371, 10)
        Me.BtnMini.Name = "BtnMini"
        Me.BtnMini.Size = New System.Drawing.Size(20, 20)
        Me.BtnMini.TabIndex = 89
        Me.BtnMini.TabStop = False
        Me.BtnMini.UseVisualStyleBackColor = False
        '
        'dspTempor
        '
        Me.dspTempor.BackColor = System.Drawing.Color.Transparent
        Me.dspTempor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dspTempor.ForeColor = System.Drawing.Color.White
        Me.dspTempor.Location = New System.Drawing.Point(180, 126)
        Me.dspTempor.Name = "dspTempor"
        Me.dspTempor.Size = New System.Drawing.Size(78, 14)
        Me.dspTempor.TabIndex = 90
        Me.dspTempor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TimerAdelan
        '
        Me.TimerAdelan.Interval = 500
        '
        'AnimPas
        '
        Me.AnimPas.Interval = 500
        '
        'BtnMute
        '
        Me.BtnMute.BackColor = System.Drawing.Color.Transparent
        Me.BtnMute.BackgroundImage = Global.Reproductor_3._0_DVD.My.Resources.Resources.btnSpk
        Me.BtnMute.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnMute.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnMute.FlatAppearance.BorderSize = 0
        Me.BtnMute.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.BtnMute.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BtnMute.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.BtnMute.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnMute.Font = New System.Drawing.Font("Impact", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnMute.ForeColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(39, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.BtnMute.Location = New System.Drawing.Point(378, 102)
        Me.BtnMute.Name = "BtnMute"
        Me.BtnMute.Size = New System.Drawing.Size(27, 27)
        Me.BtnMute.TabIndex = 91
        Me.BtnMute.TabStop = False
        Me.BtnMute.UseVisualStyleBackColor = False
        '
        'dspItipo
        '
        Me.dspItipo.BackColor = System.Drawing.Color.Transparent
        Me.dspItipo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.dspItipo.Location = New System.Drawing.Point(128, 43)
        Me.dspItipo.Name = "dspItipo"
        Me.dspItipo.Size = New System.Drawing.Size(13, 17)
        Me.dspItipo.TabIndex = 92
        Me.dspItipo.TabStop = False
        '
        'dspRem
        '
        Me.dspRem.BackColor = System.Drawing.Color.Transparent
        Me.dspRem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.dspRem.ForeColor = System.Drawing.Color.White
        Me.dspRem.Location = New System.Drawing.Point(294, 126)
        Me.dspRem.Name = "dspRem"
        Me.dspRem.Size = New System.Drawing.Size(72, 14)
        Me.dspRem.TabIndex = 93
        Me.dspRem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PanelCtrl
        '
        Me.PanelCtrl.BackColor = System.Drawing.Color.Transparent
        Me.PanelCtrl.BackgroundImage = Global.Reproductor_3._0_DVD.My.Resources.Resources.minibase
        Me.PanelCtrl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PanelCtrl.Controls.Add(Me.botonParar)
        Me.PanelCtrl.Controls.Add(Me.panelDspTrac)
        Me.PanelCtrl.Controls.Add(Me.dspTempor)
        Me.PanelCtrl.Controls.Add(Me.botonComp)
        Me.PanelCtrl.Controls.Add(Me.dspPos)
        Me.PanelCtrl.Controls.Add(Me.BtnMini)
        Me.PanelCtrl.Controls.Add(Me.botonSig)
        Me.PanelCtrl.Controls.Add(Me.botonAnt)
        Me.PanelCtrl.Controls.Add(Me.infoSiguiente)
        Me.PanelCtrl.Controls.Add(Me.BtnCerr)
        Me.PanelCtrl.Controls.Add(Me.dspRem)
        Me.PanelCtrl.Controls.Add(Me.dspTipo)
        Me.PanelCtrl.Controls.Add(Me.posicionBar)
        Me.PanelCtrl.Controls.Add(Me.BtnMute)
        Me.PanelCtrl.Controls.Add(Me.dspItipo)
        Me.PanelCtrl.Controls.Add(Me.dspModo)
        Me.PanelCtrl.Controls.Add(Me.dspOrden)
        Me.PanelCtrl.Controls.Add(Me.volBar)
        Me.PanelCtrl.Controls.Add(Me.dspEsta)
        Me.PanelCtrl.Location = New System.Drawing.Point(165, 2)
        Me.PanelCtrl.Name = "PanelCtrl"
        Me.PanelCtrl.Size = New System.Drawing.Size(444, 176)
        Me.PanelCtrl.TabIndex = 94
        '
        'panelDspTrac
        '
        Me.panelDspTrac.BackColor = System.Drawing.Color.Transparent
        Me.panelDspTrac.Controls.Add(Me.dspTrac)
        Me.panelDspTrac.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.panelDspTrac.Location = New System.Drawing.Point(153, 42)
        Me.panelDspTrac.Name = "panelDspTrac"
        Me.panelDspTrac.Size = New System.Drawing.Size(176, 18)
        Me.panelDspTrac.TabIndex = 94
        '
        'botonComp
        '
        Me.botonComp.BackColor = System.Drawing.Color.Transparent
        Me.botonComp.BackgroundImage = Global.Reproductor_3._0_DVD.My.Resources.Resources.btnComp
        Me.botonComp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.botonComp.Cursor = System.Windows.Forms.Cursors.Hand
        Me.botonComp.FlatAppearance.BorderSize = 0
        Me.botonComp.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.botonComp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.botonComp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.botonComp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.botonComp.Font = New System.Drawing.Font("Impact", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.botonComp.ForeColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(39, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.botonComp.Location = New System.Drawing.Point(210, 149)
        Me.botonComp.Name = "botonComp"
        Me.botonComp.Size = New System.Drawing.Size(20, 20)
        Me.botonComp.TabIndex = 95
        Me.botonComp.TabStop = False
        Me.botonComp.UseVisualStyleBackColor = False
        '
        'botonDVD
        '
        Me.botonDVD.BackColor = System.Drawing.Color.Transparent
        Me.botonDVD.BackgroundImage = Global.Reproductor_3._0_DVD.My.Resources.Resources.btnDVD
        Me.botonDVD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.botonDVD.Cursor = System.Windows.Forms.Cursors.Hand
        Me.botonDVD.FlatAppearance.BorderSize = 0
        Me.botonDVD.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.botonDVD.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.botonDVD.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.botonDVD.Font = New System.Drawing.Font("Impact", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.botonDVD.ForeColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(39, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.botonDVD.Location = New System.Drawing.Point(126, 294)
        Me.botonDVD.Name = "botonDVD"
        Me.botonDVD.Size = New System.Drawing.Size(30, 30)
        Me.botonDVD.TabIndex = 96
        Me.botonDVD.TabStop = False
        Me.botonDVD.UseVisualStyleBackColor = False
        '
        'botonCdAudio
        '
        Me.botonCdAudio.BackColor = System.Drawing.Color.Transparent
        Me.botonCdAudio.BackgroundImage = Global.Reproductor_3._0_DVD.My.Resources.Resources.btnAudio
        Me.botonCdAudio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.botonCdAudio.Cursor = System.Windows.Forms.Cursors.Hand
        Me.botonCdAudio.FlatAppearance.BorderSize = 0
        Me.botonCdAudio.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.botonCdAudio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.botonCdAudio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.botonCdAudio.Font = New System.Drawing.Font("Impact", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.botonCdAudio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(39, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.botonCdAudio.Location = New System.Drawing.Point(315, 294)
        Me.botonCdAudio.Name = "botonCdAudio"
        Me.botonCdAudio.Size = New System.Drawing.Size(30, 30)
        Me.botonCdAudio.TabIndex = 97
        Me.botonCdAudio.TabStop = False
        Me.botonCdAudio.UseVisualStyleBackColor = False
        '
        'PanelDVD
        '
        Me.PanelDVD.BackColor = System.Drawing.Color.Black
        Me.PanelDVD.Controls.Add(Me.dspDVDDir)
        Me.PanelDVD.Controls.Add(Me.btnDvdMenPrinc)
        Me.PanelDVD.Controls.Add(Me.btnDvdMenuTit)
        Me.PanelDVD.Controls.Add(Me.Label15)
        Me.PanelDVD.Controls.Add(Me.Label14)
        Me.PanelDVD.Controls.Add(Me.comboDvdSubs)
        Me.PanelDVD.Controls.Add(Me.comboDvdIdiomas)
        Me.PanelDVD.Controls.Add(Me.listaDvdCapis)
        Me.PanelDVD.Controls.Add(Me.comboDvdTitulos)
        Me.PanelDVD.Controls.Add(Me.btnReproducDVD)
        Me.PanelDVD.Controls.Add(Me.Label10)
        Me.PanelDVD.Controls.Add(Me.Label12)
        Me.PanelDVD.Location = New System.Drawing.Point(25, 15)
        Me.PanelDVD.Name = "PanelDVD"
        Me.PanelDVD.Size = New System.Drawing.Size(411, 275)
        Me.PanelDVD.TabIndex = 98
        Me.PanelDVD.Visible = False
        '
        'dspDVDDir
        '
        Me.dspDVDDir.BackColor = System.Drawing.Color.Transparent
        Me.dspDVDDir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.dspDVDDir.ForeColor = System.Drawing.Color.White
        Me.dspDVDDir.Location = New System.Drawing.Point(10, 5)
        Me.dspDVDDir.Name = "dspDVDDir"
        Me.dspDVDDir.Size = New System.Drawing.Size(393, 17)
        Me.dspDVDDir.TabIndex = 43
        Me.dspDVDDir.Text = "No se esta reproduciendo un DVD"
        Me.dspDVDDir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnDvdMenPrinc
        '
        Me.btnDvdMenPrinc.BackColor = System.Drawing.Color.Transparent
        Me.btnDvdMenPrinc.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.btnDvdMenPrinc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnDvdMenPrinc.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDvdMenPrinc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.btnDvdMenPrinc.ForeColor = System.Drawing.Color.White
        Me.btnDvdMenPrinc.Location = New System.Drawing.Point(147, 85)
        Me.btnDvdMenPrinc.Name = "btnDvdMenPrinc"
        Me.btnDvdMenPrinc.Size = New System.Drawing.Size(256, 26)
        Me.btnDvdMenPrinc.TabIndex = 42
        Me.btnDvdMenPrinc.Text = "Ir A Menu Principal"
        Me.btnDvdMenPrinc.UseVisualStyleBackColor = False
        '
        'btnDvdMenuTit
        '
        Me.btnDvdMenuTit.BackColor = System.Drawing.Color.Transparent
        Me.btnDvdMenuTit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.btnDvdMenuTit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnDvdMenuTit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDvdMenuTit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.btnDvdMenuTit.ForeColor = System.Drawing.Color.White
        Me.btnDvdMenuTit.Location = New System.Drawing.Point(10, 85)
        Me.btnDvdMenuTit.Name = "btnDvdMenuTit"
        Me.btnDvdMenuTit.Size = New System.Drawing.Size(120, 26)
        Me.btnDvdMenuTit.TabIndex = 41
        Me.btnDvdMenuTit.Text = "Ir a Menu"
        Me.btnDvdMenuTit.UseVisualStyleBackColor = False
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(281, 33)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(122, 17)
        Me.Label15.TabIndex = 40
        Me.Label15.Text = "Subtitulos"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(144, 33)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(122, 17)
        Me.Label14.TabIndex = 39
        Me.Label14.Text = "Audios"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'comboDvdSubs
        '
        Me.comboDvdSubs.BackColor = System.Drawing.Color.Black
        Me.comboDvdSubs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboDvdSubs.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.comboDvdSubs.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboDvdSubs.ForeColor = System.Drawing.Color.White
        Me.comboDvdSubs.FormattingEnabled = True
        Me.comboDvdSubs.Location = New System.Drawing.Point(282, 55)
        Me.comboDvdSubs.Name = "comboDvdSubs"
        Me.comboDvdSubs.Size = New System.Drawing.Size(121, 37)
        Me.comboDvdSubs.TabIndex = 38
        '
        'comboDvdIdiomas
        '
        Me.comboDvdIdiomas.BackColor = System.Drawing.Color.Black
        Me.comboDvdIdiomas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboDvdIdiomas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.comboDvdIdiomas.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboDvdIdiomas.ForeColor = System.Drawing.Color.White
        Me.comboDvdIdiomas.FormattingEnabled = True
        Me.comboDvdIdiomas.Location = New System.Drawing.Point(146, 55)
        Me.comboDvdIdiomas.Name = "comboDvdIdiomas"
        Me.comboDvdIdiomas.Size = New System.Drawing.Size(121, 37)
        Me.comboDvdIdiomas.TabIndex = 37
        '
        'listaDvdCapis
        '
        Me.listaDvdCapis.BackColor = System.Drawing.Color.Black
        Me.listaDvdCapis.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.listaDvdCapis.ForeColor = System.Drawing.Color.White
        Me.listaDvdCapis.FormattingEnabled = True
        Me.listaDvdCapis.Location = New System.Drawing.Point(11, 132)
        Me.listaDvdCapis.Name = "listaDvdCapis"
        Me.listaDvdCapis.Size = New System.Drawing.Size(120, 108)
        Me.listaDvdCapis.TabIndex = 36
        '
        'comboDvdTitulos
        '
        Me.comboDvdTitulos.BackColor = System.Drawing.Color.Black
        Me.comboDvdTitulos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboDvdTitulos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.comboDvdTitulos.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboDvdTitulos.ForeColor = System.Drawing.Color.White
        Me.comboDvdTitulos.FormattingEnabled = True
        Me.comboDvdTitulos.Location = New System.Drawing.Point(10, 55)
        Me.comboDvdTitulos.Name = "comboDvdTitulos"
        Me.comboDvdTitulos.Size = New System.Drawing.Size(121, 37)
        Me.comboDvdTitulos.TabIndex = 35
        '
        'btnReproducDVD
        '
        Me.btnReproducDVD.BackColor = System.Drawing.Color.Transparent
        Me.btnReproducDVD.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.btnReproducDVD.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnReproducDVD.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReproducDVD.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.btnReproducDVD.ForeColor = System.Drawing.Color.White
        Me.btnReproducDVD.Location = New System.Drawing.Point(203, 165)
        Me.btnReproducDVD.Name = "btnReproducDVD"
        Me.btnReproducDVD.Size = New System.Drawing.Size(124, 34)
        Me.btnReproducDVD.TabIndex = 34
        Me.btnReproducDVD.Text = "Reproducir DVD"
        Me.btnReproducDVD.UseVisualStyleBackColor = False
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(10, 33)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(122, 19)
        Me.Label10.TabIndex = 33
        Me.Label10.Text = "Titulos"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(13, 115)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(117, 15)
        Me.Label12.TabIndex = 31
        Me.Label12.Text = "Capitulos:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PanelCDAudio
        '
        Me.PanelCDAudio.BackColor = System.Drawing.Color.Black
        Me.PanelCDAudio.Controls.Add(Me.dspAudioEst)
        Me.PanelCDAudio.Controls.Add(Me.listaAudioTracks)
        Me.PanelCDAudio.Controls.Add(Me.btnReproAudio)
        Me.PanelCDAudio.Controls.Add(Me.Label18)
        Me.PanelCDAudio.Location = New System.Drawing.Point(27, 17)
        Me.PanelCDAudio.Name = "PanelCDAudio"
        Me.PanelCDAudio.Size = New System.Drawing.Size(411, 275)
        Me.PanelCDAudio.TabIndex = 99
        Me.PanelCDAudio.Visible = False
        '
        'dspAudioEst
        '
        Me.dspAudioEst.BackColor = System.Drawing.Color.Transparent
        Me.dspAudioEst.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.dspAudioEst.ForeColor = System.Drawing.Color.White
        Me.dspAudioEst.Location = New System.Drawing.Point(10, 5)
        Me.dspAudioEst.Name = "dspAudioEst"
        Me.dspAudioEst.Size = New System.Drawing.Size(393, 17)
        Me.dspAudioEst.TabIndex = 43
        Me.dspAudioEst.Text = "No se esta reproduciendo un CD de Audio"
        Me.dspAudioEst.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'listaAudioTracks
        '
        Me.listaAudioTracks.BackColor = System.Drawing.Color.Black
        Me.listaAudioTracks.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.listaAudioTracks.ForeColor = System.Drawing.Color.White
        Me.listaAudioTracks.FormattingEnabled = True
        Me.listaAudioTracks.Location = New System.Drawing.Point(11, 50)
        Me.listaAudioTracks.Name = "listaAudioTracks"
        Me.listaAudioTracks.Size = New System.Drawing.Size(395, 108)
        Me.listaAudioTracks.TabIndex = 36
        '
        'btnReproAudio
        '
        Me.btnReproAudio.BackColor = System.Drawing.Color.Transparent
        Me.btnReproAudio.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.btnReproAudio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnReproAudio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReproAudio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.btnReproAudio.ForeColor = System.Drawing.Color.White
        Me.btnReproAudio.Location = New System.Drawing.Point(113, 186)
        Me.btnReproAudio.Name = "btnReproAudio"
        Me.btnReproAudio.Size = New System.Drawing.Size(178, 34)
        Me.btnReproAudio.TabIndex = 34
        Me.btnReproAudio.Text = "Reproducir CD de Audio"
        Me.btnReproAudio.UseVisualStyleBackColor = False
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(11, 24)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(395, 15)
        Me.Label18.TabIndex = 31
        Me.Label18.Text = "Pistas:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.ListBox1)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Location = New System.Drawing.Point(26, 16)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(411, 275)
        Me.Panel1.TabIndex = 99
        Me.Panel1.Visible = False
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(10, 5)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(393, 17)
        Me.Label11.TabIndex = 43
        Me.Label11.Text = "No se esta reproduciendo un CD de Audio"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ListBox1
        '
        Me.ListBox1.BackColor = System.Drawing.Color.Black
        Me.ListBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.ListBox1.ForeColor = System.Drawing.Color.White
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(11, 50)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(395, 108)
        Me.ListBox1.TabIndex = 36
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(113, 186)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(178, 34)
        Me.Button1.TabIndex = 34
        Me.Button1.Text = "Reproducir CD de Audio"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(11, 24)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(395, 15)
        Me.Label13.TabIndex = 31
        Me.Label13.Text = "Pistas:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PanelRadio
        '
        Me.PanelRadio.BackColor = System.Drawing.Color.Black
        Me.PanelRadio.Controls.Add(Me.btnGuardarRadio)
        Me.PanelRadio.Controls.Add(Me.btnAbrirRadio)
        Me.PanelRadio.Controls.Add(Me.dspRecout)
        Me.PanelRadio.Controls.Add(Me.btnBorrarTodosTunes)
        Me.PanelRadio.Controls.Add(Me.ListaTunes)
        Me.PanelRadio.Controls.Add(Me.btnAndirRadio)
        Me.PanelRadio.Controls.Add(Me.btnGrabarRadio)
        Me.PanelRadio.Controls.Add(Me.btnQuitarRadio)
        Me.PanelRadio.Location = New System.Drawing.Point(25, 14)
        Me.PanelRadio.Name = "PanelRadio"
        Me.PanelRadio.Size = New System.Drawing.Size(411, 275)
        Me.PanelRadio.TabIndex = 100
        Me.PanelRadio.Visible = False
        '
        'btnGuardarRadio
        '
        Me.btnGuardarRadio.BackColor = System.Drawing.Color.Transparent
        Me.btnGuardarRadio.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.btnGuardarRadio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnGuardarRadio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGuardarRadio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.btnGuardarRadio.ForeColor = System.Drawing.Color.White
        Me.btnGuardarRadio.Location = New System.Drawing.Point(255, 173)
        Me.btnGuardarRadio.Name = "btnGuardarRadio"
        Me.btnGuardarRadio.Size = New System.Drawing.Size(149, 26)
        Me.btnGuardarRadio.TabIndex = 103
        Me.btnGuardarRadio.Text = "Guardar Lista"
        Me.btnGuardarRadio.UseVisualStyleBackColor = False
        '
        'btnAbrirRadio
        '
        Me.btnAbrirRadio.BackColor = System.Drawing.Color.Transparent
        Me.btnAbrirRadio.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.btnAbrirRadio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnAbrirRadio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAbrirRadio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.btnAbrirRadio.ForeColor = System.Drawing.Color.White
        Me.btnAbrirRadio.Location = New System.Drawing.Point(18, 176)
        Me.btnAbrirRadio.Name = "btnAbrirRadio"
        Me.btnAbrirRadio.Size = New System.Drawing.Size(147, 26)
        Me.btnAbrirRadio.TabIndex = 102
        Me.btnAbrirRadio.Text = "Cargar Lista"
        Me.btnAbrirRadio.UseVisualStyleBackColor = False
        '
        'dspRecout
        '
        Me.dspRecout.BackColor = System.Drawing.Color.Transparent
        Me.dspRecout.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.dspRecout.ForeColor = System.Drawing.Color.White
        Me.dspRecout.Location = New System.Drawing.Point(16, 244)
        Me.dspRecout.Name = "dspRecout"
        Me.dspRecout.Size = New System.Drawing.Size(387, 25)
        Me.dspRecout.TabIndex = 98
        Me.dspRecout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnBorrarTodosTunes
        '
        Me.btnBorrarTodosTunes.BackColor = System.Drawing.Color.Transparent
        Me.btnBorrarTodosTunes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.btnBorrarTodosTunes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnBorrarTodosTunes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBorrarTodosTunes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.btnBorrarTodosTunes.ForeColor = System.Drawing.Color.White
        Me.btnBorrarTodosTunes.Location = New System.Drawing.Point(255, 209)
        Me.btnBorrarTodosTunes.Name = "btnBorrarTodosTunes"
        Me.btnBorrarTodosTunes.Size = New System.Drawing.Size(148, 26)
        Me.btnBorrarTodosTunes.TabIndex = 97
        Me.btnBorrarTodosTunes.Text = "Borrar Todo"
        Me.btnBorrarTodosTunes.UseVisualStyleBackColor = False
        '
        'ListaTunes
        '
        Me.ListaTunes.BackColor = System.Drawing.Color.Black
        Me.ListaTunes.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListaTunes.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader6, Me.ColumnHeader11})
        Me.ListaTunes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.ListaTunes.ForeColor = System.Drawing.Color.White
        Me.ListaTunes.FullRowSelect = True
        Me.ListaTunes.HideSelection = False
        Me.ListaTunes.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ListaTunes.Location = New System.Drawing.Point(3, 4)
        Me.ListaTunes.MultiSelect = False
        Me.ListaTunes.Name = "ListaTunes"
        Me.ListaTunes.ShowItemToolTips = True
        Me.ListaTunes.Size = New System.Drawing.Size(405, 161)
        Me.ListaTunes.TabIndex = 96
        Me.ListaTunes.UseCompatibleStateImageBehavior = False
        Me.ListaTunes.View = System.Windows.Forms.View.Details
        Me.ListaTunes.VirtualListSize = 20
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Nombre"
        Me.ColumnHeader6.Width = 157
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Direccion"
        Me.ColumnHeader11.Width = 228
        '
        'btnAndirRadio
        '
        Me.btnAndirRadio.BackColor = System.Drawing.Color.Transparent
        Me.btnAndirRadio.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.btnAndirRadio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnAndirRadio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAndirRadio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.btnAndirRadio.ForeColor = System.Drawing.Color.White
        Me.btnAndirRadio.Location = New System.Drawing.Point(192, 173)
        Me.btnAndirRadio.Name = "btnAndirRadio"
        Me.btnAndirRadio.Size = New System.Drawing.Size(31, 26)
        Me.btnAndirRadio.TabIndex = 64
        Me.btnAndirRadio.Text = "+"
        Me.btnAndirRadio.UseVisualStyleBackColor = False
        '
        'btnGrabarRadio
        '
        Me.btnGrabarRadio.BackColor = System.Drawing.Color.Transparent
        Me.btnGrabarRadio.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.btnGrabarRadio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnGrabarRadio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGrabarRadio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.btnGrabarRadio.ForeColor = System.Drawing.Color.White
        Me.btnGrabarRadio.Location = New System.Drawing.Point(18, 209)
        Me.btnGrabarRadio.Name = "btnGrabarRadio"
        Me.btnGrabarRadio.Size = New System.Drawing.Size(147, 26)
        Me.btnGrabarRadio.TabIndex = 60
        Me.btnGrabarRadio.Text = "Grabar"
        Me.btnGrabarRadio.UseVisualStyleBackColor = False
        '
        'btnQuitarRadio
        '
        Me.btnQuitarRadio.BackColor = System.Drawing.Color.Transparent
        Me.btnQuitarRadio.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.btnQuitarRadio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnQuitarRadio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnQuitarRadio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.btnQuitarRadio.ForeColor = System.Drawing.Color.White
        Me.btnQuitarRadio.Location = New System.Drawing.Point(191, 208)
        Me.btnQuitarRadio.Name = "btnQuitarRadio"
        Me.btnQuitarRadio.Size = New System.Drawing.Size(31, 26)
        Me.btnQuitarRadio.TabIndex = 59
        Me.btnQuitarRadio.Text = "-"
        Me.btnQuitarRadio.UseVisualStyleBackColor = False
        '
        'btnRadio
        '
        Me.btnRadio.BackColor = System.Drawing.Color.Transparent
        Me.btnRadio.BackgroundImage = Global.Reproductor_3._0_DVD.My.Resources.Resources.btnRadio
        Me.btnRadio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnRadio.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRadio.FlatAppearance.BorderSize = 0
        Me.btnRadio.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnRadio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnRadio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRadio.Font = New System.Drawing.Font("Impact", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRadio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(39, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.btnRadio.Location = New System.Drawing.Point(365, 294)
        Me.btnRadio.Name = "btnRadio"
        Me.btnRadio.Size = New System.Drawing.Size(30, 30)
        Me.btnRadio.TabIndex = 101
        Me.btnRadio.TabStop = False
        Me.btnRadio.UseVisualStyleBackColor = False
        '
        'botonSleep
        '
        Me.botonSleep.BackColor = System.Drawing.Color.Transparent
        Me.botonSleep.BackgroundImage = Global.Reproductor_3._0_DVD.My.Resources.Resources.btnExp
        Me.botonSleep.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.botonSleep.Cursor = System.Windows.Forms.Cursors.Hand
        Me.botonSleep.FlatAppearance.BorderSize = 0
        Me.botonSleep.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.botonSleep.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.botonSleep.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.botonSleep.Font = New System.Drawing.Font("Impact", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.botonSleep.ForeColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(39, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.botonSleep.Location = New System.Drawing.Point(76, 294)
        Me.botonSleep.Name = "botonSleep"
        Me.botonSleep.Size = New System.Drawing.Size(30, 30)
        Me.botonSleep.TabIndex = 102
        Me.botonSleep.TabStop = False
        Me.botonSleep.UseVisualStyleBackColor = False
        '
        'PanelSleep
        '
        Me.PanelSleep.BackColor = System.Drawing.Color.Black
        Me.PanelSleep.Controls.Add(Me.dspSleep)
        Me.PanelSleep.Controls.Add(Me.Label16)
        Me.PanelSleep.Controls.Add(Me.CheckSleep)
        Me.PanelSleep.Controls.Add(Me.SleepSel)
        Me.PanelSleep.Controls.Add(Me.Label17)
        Me.PanelSleep.Controls.Add(Me.Label23)
        Me.PanelSleep.Location = New System.Drawing.Point(23, 18)
        Me.PanelSleep.Name = "PanelSleep"
        Me.PanelSleep.Size = New System.Drawing.Size(411, 276)
        Me.PanelSleep.TabIndex = 103
        Me.PanelSleep.Visible = False
        '
        'dspSleep
        '
        Me.dspSleep.BackColor = System.Drawing.Color.Transparent
        Me.dspSleep.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.dspSleep.ForeColor = System.Drawing.Color.White
        Me.dspSleep.Location = New System.Drawing.Point(3, 183)
        Me.dspSleep.Name = "dspSleep"
        Me.dspSleep.Size = New System.Drawing.Size(407, 24)
        Me.dspSleep.TabIndex = 95
        Me.dspSleep.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(203, 129)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(90, 24)
        Me.Label16.TabIndex = 94
        Me.Label16.Text = "Minutos"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CheckSleep
        '
        Me.CheckSleep.AutoSize = True
        Me.CheckSleep.BackColor = System.Drawing.Color.Black
        Me.CheckSleep.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.CheckSleep.ForeColor = System.Drawing.Color.White
        Me.CheckSleep.Location = New System.Drawing.Point(110, 72)
        Me.CheckSleep.Name = "CheckSleep"
        Me.CheckSleep.Size = New System.Drawing.Size(151, 21)
        Me.CheckSleep.TabIndex = 93
        Me.CheckSleep.Text = "Activar Apagado Automatico"
        Me.CheckSleep.UseVisualStyleBackColor = False
        '
        'SleepSel
        '
        Me.SleepSel.BackColor = System.Drawing.Color.Black
        Me.SleepSel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SleepSel.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.SleepSel.ForeColor = System.Drawing.Color.White
        Me.SleepSel.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.SleepSel.Location = New System.Drawing.Point(130, 127)
        Me.SleepSel.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.SleepSel.Minimum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.SleepSel.Name = "SleepSel"
        Me.SleepSel.ReadOnly = True
        Me.SleepSel.Size = New System.Drawing.Size(71, 25)
        Me.SleepSel.TabIndex = 92
        Me.SleepSel.Value = New Decimal(New Integer() {60, 0, 0, 0})
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel)
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(7, 105)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(401, 19)
        Me.Label17.TabIndex = 89
        Me.Label17.Text = "Tiempo de Apagado"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.Label23.ForeColor = System.Drawing.Color.White
        Me.Label23.Location = New System.Drawing.Point(5, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(397, 24)
        Me.Label23.TabIndex = 86
        Me.Label23.Text = "Opciones de Apagado de PC"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SleepTimer
        '
        Me.SleepTimer.Interval = 60000
        '
        'Panel2
        '
        Me.Panel2.BackgroundImage = Global.Reproductor_3._0_DVD.My.Resources.Resources.secundary
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Panel2.Controls.Add(Me.botonSleep)
        Me.Panel2.Controls.Add(Me.btnRadio)
        Me.Panel2.Controls.Add(Me.botonCdAudio)
        Me.Panel2.Controls.Add(Me.botonDVD)
        Me.Panel2.Controls.Add(Me.botonSobre)
        Me.Panel2.Controls.Add(Me.dspLugar)
        Me.Panel2.Controls.Add(Me.botonOpciones)
        Me.Panel2.Controls.Add(Me.botonCarpeta)
        Me.Panel2.Controls.Add(Me.botonLista)
        Me.Panel2.Controls.Add(Me.PanelRadio)
        Me.Panel2.Controls.Add(Me.PanelDVD)
        Me.Panel2.Controls.Add(Me.Panel1)
        Me.Panel2.Controls.Add(Me.PanelLista)
        Me.Panel2.Controls.Add(Me.PanelCDAudio)
        Me.Panel2.Controls.Add(Me.PanelCarpeta)
        Me.Panel2.Controls.Add(Me.PanelSobre)
        Me.Panel2.Controls.Add(Me.PanelOpcion)
        Me.Panel2.Controls.Add(Me.PanelSleep)
        Me.Panel2.Location = New System.Drawing.Point(139, 182)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(460, 333)
        Me.Panel2.TabIndex = 104
        '
        'Panel3
        '
        Me.Panel3.BackgroundImage = Global.Reproductor_3._0_DVD.My.Resources.Resources.minibasetrans
        Me.Panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel3.Controls.Add(Me.botonAbrir)
        Me.Panel3.Controls.Add(Me.botonRepro)
        Me.Panel3.Location = New System.Drawing.Point(3, -1)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(162, 179)
        Me.Panel3.TabIndex = 105
        '
        'TreeDir
        '
        Me.TreeDir.BackColor = System.Drawing.Color.Black
        Me.TreeDir.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TreeDir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.TreeDir.ForeColor = System.Drawing.Color.White
        Me.TreeDir.Location = New System.Drawing.Point(3, 2)
        Me.TreeDir.Name = "TreeDir"
        Me.TreeDir.SelectedFile = ShellItem2
        Me.TreeDir.Size = New System.Drawing.Size(328, 88)
        Me.TreeDir.TabIndex = 36
        '
        'Principal
        '
        Me.AllowDrop = True
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Navy
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(603, 536)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.PanelCtrl)
        Me.Controls.Add(Me.Panel2)
        Me.DoubleBuffered = True
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Principal"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mini Media Player 3"
        Me.TransparencyKey = System.Drawing.Color.Navy
        CType(Me.dspLugar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dspModo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dspOrden, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dspEsta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelLista.ResumeLayout(False)
        Me.PanelCarpeta.ResumeLayout(False)
        Me.PanelOpcion.ResumeLayout(False)
        Me.PanelOpcion.PerformLayout()
        Me.PanelSobre.ResumeLayout(False)
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Menupop.ResumeLayout(False)
        CType(Me.dspItipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelCtrl.ResumeLayout(False)
        Me.panelDspTrac.ResumeLayout(False)
        Me.panelDspTrac.PerformLayout()
        Me.PanelDVD.ResumeLayout(False)
        Me.PanelCDAudio.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.PanelRadio.ResumeLayout(False)
        Me.PanelSleep.ResumeLayout(False)
        Me.PanelSleep.PerformLayout()
        CType(Me.SleepSel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents botonParar As System.Windows.Forms.Button
    Friend WithEvents botonRepro As System.Windows.Forms.Button
    Friend WithEvents botonAnt As System.Windows.Forms.Button
    Friend WithEvents botonSig As System.Windows.Forms.Button
    Friend WithEvents botonAbrir As System.Windows.Forms.Button
    Friend WithEvents botonCarpeta As System.Windows.Forms.Button
    Friend WithEvents botonLista As System.Windows.Forms.Button
    Friend WithEvents botonOpciones As System.Windows.Forms.Button
    Friend WithEvents botonSobre As System.Windows.Forms.Button
    Friend WithEvents dspLugar As System.Windows.Forms.PictureBox
    Friend WithEvents dspModo As System.Windows.Forms.PictureBox
    Friend WithEvents dspOrden As System.Windows.Forms.PictureBox
    Friend WithEvents dspEsta As System.Windows.Forms.PictureBox
    Friend WithEvents dspTipo As System.Windows.Forms.Label
    Friend WithEvents dspTrac As System.Windows.Forms.Label
    Friend WithEvents posicionBar As EConTech.Windows.MACUI.MACTrackBar
    Friend WithEvents volBar As EConTech.Windows.MACUI.MACTrackBar
    Friend WithEvents posicion As System.Windows.Forms.Timer
    Friend WithEvents AnimPau As System.Windows.Forms.Timer
    Friend WithEvents AnimTipo As System.Windows.Forms.Timer
    Friend WithEvents dspPos As System.Windows.Forms.Label
    Friend WithEvents PanelLista As System.Windows.Forms.Panel
    Friend WithEvents guardarLista As System.Windows.Forms.Button
    Friend WithEvents borrarTodoLista As System.Windows.Forms.Button
    Friend WithEvents abrirLista As System.Windows.Forms.Button
    Friend WithEvents borrarSellista As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents totalesLista As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents seleccionLista As System.Windows.Forms.Label
    Friend WithEvents PanelCarpeta As System.Windows.Forms.Panel
    Friend WithEvents añadeTodoCarpeta As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents totalCarpeta As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents selecCarpeta As System.Windows.Forms.Label
    Friend WithEvents PanelSobre As System.Windows.Forms.Panel
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PanelOpcion As System.Windows.Forms.Panel
    Friend WithEvents DialogoAbrir As System.Windows.Forms.OpenFileDialog
    Friend WithEvents DialogoGuardar As System.Windows.Forms.SaveFileDialog
    Friend WithEvents delRepro As System.Windows.Forms.Timer
    Friend WithEvents IconoBarra As System.Windows.Forms.NotifyIcon
    Friend WithEvents AnimTrack As System.Windows.Forms.Timer
    Friend WithEvents OpcGuard As System.Windows.Forms.CheckBox
    Friend WithEvents OpcMostrarMensIconoBarra As System.Windows.Forms.CheckBox
    Friend WithEvents OpcMinimizarIconoBarra As System.Windows.Forms.CheckBox
    Friend WithEvents OpcIconoBarra As System.Windows.Forms.CheckBox
    Friend WithEvents OpcVideo As System.Windows.Forms.CheckBox
    Friend WithEvents OpcMsnAudio As System.Windows.Forms.CheckBox
    Friend WithEvents OpcMSNVideo As System.Windows.Forms.CheckBox
    Friend WithEvents OpcMsnTx As System.Windows.Forms.TextBox
    Friend WithEvents OpcEnablMSN As System.Windows.Forms.CheckBox
    Friend WithEvents OpcButtCambioTeclas As System.Windows.Forms.Button
    Friend WithEvents OpcCambioTeclas As System.Windows.Forms.ComboBox
    Friend WithEvents OpcTeclas As System.Windows.Forms.CheckBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Menupop As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Msiguien As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Manterior As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Mpausarepro As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Mparar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Mactivartecl As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Minfo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Mcerrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AnimTitBarra As System.Windows.Forms.Timer
    Friend WithEvents BtnCerr As System.Windows.Forms.Button
    Friend WithEvents BtnMini As System.Windows.Forms.Button
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents dspTempor As System.Windows.Forms.Label
    Friend WithEvents TimerAdelan As System.Windows.Forms.Timer
    Friend WithEvents AnimPas As System.Windows.Forms.Timer
    Friend WithEvents BtnMute As System.Windows.Forms.Button
    Friend WithEvents dspItipo As System.Windows.Forms.PictureBox
    Friend WithEvents dspRem As System.Windows.Forms.Label

    Public WithEvents PanelCtrl As System.Windows.Forms.Panel
    Public WithEvents botonComp As System.Windows.Forms.Button
    Public WithEvents anadePlist As System.Windows.Forms.Button
    Public WithEvents lAnomb As System.Windows.Forms.ColumnHeader
    Public WithEvents lATitulo As System.Windows.Forms.ColumnHeader
    Public WithEvents listaNombres As System.Windows.Forms.ListView
    Public WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Public WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Public WithEvents listaArchivos As System.Windows.Forms.ListView
    Public WithEvents botonDVD As System.Windows.Forms.Button
    Public WithEvents botonCdAudio As System.Windows.Forms.Button
    Public WithEvents PanelDVD As System.Windows.Forms.Panel
    Public WithEvents btnReproducDVD As System.Windows.Forms.Button
    Public WithEvents Label10 As System.Windows.Forms.Label
    Public WithEvents Label12 As System.Windows.Forms.Label
    Public WithEvents listaDvdCapis As System.Windows.Forms.ListBox
    Public WithEvents comboDvdTitulos As System.Windows.Forms.ComboBox
    Public WithEvents Label15 As System.Windows.Forms.Label
    Public WithEvents Label14 As System.Windows.Forms.Label
    Public WithEvents comboDvdSubs As System.Windows.Forms.ComboBox
    Public WithEvents comboDvdIdiomas As System.Windows.Forms.ComboBox
    Public WithEvents btnDvdMenPrinc As System.Windows.Forms.Button
    Public WithEvents btnDvdMenuTit As System.Windows.Forms.Button
    Public WithEvents dspDVDDir As System.Windows.Forms.Label
    Public WithEvents PanelCDAudio As System.Windows.Forms.Panel
    Public WithEvents dspAudioEst As System.Windows.Forms.Label
    Public WithEvents listaAudioTracks As System.Windows.Forms.ListBox
    Public WithEvents btnReproAudio As System.Windows.Forms.Button
    Public WithEvents Label18 As System.Windows.Forms.Label
    Public WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Public WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Public WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Public WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Public WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Public WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Public WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Public WithEvents Panel1 As System.Windows.Forms.Panel
    Public WithEvents Label11 As System.Windows.Forms.Label
    Public WithEvents ListBox1 As System.Windows.Forms.ListBox
    Public WithEvents Button1 As System.Windows.Forms.Button
    Public WithEvents Label13 As System.Windows.Forms.Label
    Public WithEvents OpcTeclKit As System.Windows.Forms.ComboBox
    Public WithEvents PanelRadio As System.Windows.Forms.Panel
    Public WithEvents ListaTunes As System.Windows.Forms.ListView
    Public WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Public WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Public WithEvents btnAndirRadio As System.Windows.Forms.Button
    Public WithEvents btnGrabarRadio As System.Windows.Forms.Button
    Public WithEvents btnQuitarRadio As System.Windows.Forms.Button
    Public WithEvents btnRadio As System.Windows.Forms.Button
    Public WithEvents dspRecout As System.Windows.Forms.Label
    Public WithEvents btnBorrarTodosTunes As System.Windows.Forms.Button
    Public WithEvents panelDspTrac As System.Windows.Forms.Panel
    Public textotrack As TextoMovil
    Public WithEvents btnGuardarRadio As System.Windows.Forms.Button
    Public WithEvents btnAbrirRadio As System.Windows.Forms.Button
    Public WithEvents btnAba As System.Windows.Forms.Button
    Public WithEvents btnArr As System.Windows.Forms.Button
    Public WithEvents botonSleep As System.Windows.Forms.Button
    Public WithEvents PanelSleep As System.Windows.Forms.Panel
    Public WithEvents Label23 As System.Windows.Forms.Label
    Public WithEvents SleepSel As System.Windows.Forms.NumericUpDown
    Public WithEvents Label17 As System.Windows.Forms.Label
    Public WithEvents CheckSleep As System.Windows.Forms.CheckBox
    Public WithEvents SleepTimer As System.Windows.Forms.Timer
    Public WithEvents Label16 As System.Windows.Forms.Label
    Public WithEvents dspSleep As System.Windows.Forms.Label
    Public WithEvents infoSiguiente As System.Windows.Forms.Label
    Public WithEvents Panel2 As System.Windows.Forms.Panel
    Public WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents TreeDir As MBTreeViewExplorer.MBTreeViewExplorer
    Friend WithEvents LabelDirectory As System.Windows.Forms.Label
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents OpcTeclasD As System.Windows.Forms.CheckBox
    Friend WithEvents MactivarteclD As System.Windows.Forms.ToolStripMenuItem
End Class
