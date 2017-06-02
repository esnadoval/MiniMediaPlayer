<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormVideo
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
        Me.components = New System.ComponentModel.Container
        Me.BarraVideo = New System.Windows.Forms.Panel
        Me.panelTxtEsta = New System.Windows.Forms.Panel
        Me.TxtEsta = New System.Windows.Forms.Label
        Me.clpIndic = New System.Windows.Forms.Label
        Me.txtTiempo = New System.Windows.Forms.Label
        Me.BtnBackw = New System.Windows.Forms.Button
        Me.BtnFord = New System.Windows.Forms.Button
        Me.BtnTop = New System.Windows.Forms.Button
        Me.PosBar = New EConTech.Windows.MACUI.MACTrackBar
        Me.actualPos = New System.Windows.Forms.Timer(Me.components)
        Me.delApearBar = New System.Windows.Forms.Timer(Me.components)
        Me.Mousecapt = New System.Windows.Forms.Timer(Me.components)
        Me.textMovil = New System.Windows.Forms.Timer(Me.components)
        Me.DibujoVideo = New System.Windows.Forms.PictureBox
        Me.clickdel = New System.Windows.Forms.Timer(Me.components)
        Me.BarraVideo.SuspendLayout()
        Me.panelTxtEsta.SuspendLayout()
        CType(Me.DibujoVideo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BarraVideo
        '
        Me.BarraVideo.BackColor = System.Drawing.Color.Black
        Me.BarraVideo.Controls.Add(Me.panelTxtEsta)
        Me.BarraVideo.Controls.Add(Me.clpIndic)
        Me.BarraVideo.Controls.Add(Me.txtTiempo)
        Me.BarraVideo.Controls.Add(Me.BtnBackw)
        Me.BarraVideo.Controls.Add(Me.BtnFord)
        Me.BarraVideo.Controls.Add(Me.BtnTop)
        Me.BarraVideo.Controls.Add(Me.PosBar)
        Me.BarraVideo.Location = New System.Drawing.Point(0, 0)
        Me.BarraVideo.Name = "BarraVideo"
        Me.BarraVideo.Size = New System.Drawing.Size(579, 34)
        Me.BarraVideo.TabIndex = 1
        Me.BarraVideo.Visible = False
        '
        'panelTxtEsta
        '
        Me.panelTxtEsta.Controls.Add(Me.TxtEsta)
        Me.panelTxtEsta.Location = New System.Drawing.Point(139, 6)
        Me.panelTxtEsta.Name = "panelTxtEsta"
        Me.panelTxtEsta.Size = New System.Drawing.Size(108, 22)
        Me.panelTxtEsta.TabIndex = 2
        '
        'TxtEsta
        '
        Me.TxtEsta.AutoSize = True
        Me.TxtEsta.BackColor = System.Drawing.Color.Transparent
        Me.TxtEsta.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEsta.ForeColor = System.Drawing.Color.White
        Me.TxtEsta.Location = New System.Drawing.Point(3, 2)
        Me.TxtEsta.Name = "TxtEsta"
        Me.TxtEsta.Size = New System.Drawing.Size(71, 20)
        Me.TxtEsta.TabIndex = 90
        Me.TxtEsta.Text = "00:00:00"
        Me.TxtEsta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'clpIndic
        '
        Me.clpIndic.BackColor = System.Drawing.Color.Transparent
        Me.clpIndic.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.clpIndic.ForeColor = System.Drawing.Color.White
        Me.clpIndic.Location = New System.Drawing.Point(253, 8)
        Me.clpIndic.Name = "clpIndic"
        Me.clpIndic.Size = New System.Drawing.Size(31, 19)
        Me.clpIndic.TabIndex = 91
        Me.clpIndic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtTiempo
        '
        Me.txtTiempo.BackColor = System.Drawing.Color.Transparent
        Me.txtTiempo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTiempo.ForeColor = System.Drawing.Color.White
        Me.txtTiempo.Location = New System.Drawing.Point(55, 7)
        Me.txtTiempo.Name = "txtTiempo"
        Me.txtTiempo.Size = New System.Drawing.Size(78, 22)
        Me.txtTiempo.TabIndex = 89
        Me.txtTiempo.Text = "00:00:00"
        Me.txtTiempo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnBackw
        '
        Me.BtnBackw.BackColor = System.Drawing.Color.Transparent
        Me.BtnBackw.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.BtnBackw.FlatAppearance.CheckedBackColor = System.Drawing.Color.White
        Me.BtnBackw.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.BtnBackw.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BtnBackw.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnBackw.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBackw.ForeColor = System.Drawing.Color.White
        Me.BtnBackw.Location = New System.Drawing.Point(290, 3)
        Me.BtnBackw.Name = "BtnBackw"
        Me.BtnBackw.Size = New System.Drawing.Size(34, 26)
        Me.BtnBackw.TabIndex = 15
        Me.BtnBackw.Text = "<<"
        Me.BtnBackw.UseVisualStyleBackColor = False
        '
        'BtnFord
        '
        Me.BtnFord.BackColor = System.Drawing.Color.Transparent
        Me.BtnFord.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.BtnFord.FlatAppearance.CheckedBackColor = System.Drawing.Color.White
        Me.BtnFord.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.BtnFord.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BtnFord.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFord.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFord.ForeColor = System.Drawing.Color.White
        Me.BtnFord.Location = New System.Drawing.Point(542, 4)
        Me.BtnFord.Name = "BtnFord"
        Me.BtnFord.Size = New System.Drawing.Size(34, 26)
        Me.BtnFord.TabIndex = 14
        Me.BtnFord.Text = ">>"
        Me.BtnFord.UseVisualStyleBackColor = False
        '
        'BtnTop
        '
        Me.BtnTop.BackColor = System.Drawing.Color.Transparent
        Me.BtnTop.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.BtnTop.FlatAppearance.CheckedBackColor = System.Drawing.Color.White
        Me.BtnTop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.BtnTop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BtnTop.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnTop.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTop.ForeColor = System.Drawing.Color.White
        Me.BtnTop.Location = New System.Drawing.Point(5, 4)
        Me.BtnTop.Name = "BtnTop"
        Me.BtnTop.Size = New System.Drawing.Size(44, 26)
        Me.BtnTop.TabIndex = 12
        Me.BtnTop.Text = "_/\_"
        Me.BtnTop.UseVisualStyleBackColor = False
        '
        'PosBar
        '
        Me.PosBar.BackColor = System.Drawing.Color.Transparent
        Me.PosBar.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Me.PosBar.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PosBar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(123, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(123, Byte), Integer))
        Me.PosBar.IndentHeight = 6
        Me.PosBar.Location = New System.Drawing.Point(330, 2)
        Me.PosBar.Maximum = 10
        Me.PosBar.Minimum = 0
        Me.PosBar.Name = "PosBar"
        Me.PosBar.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.PosBar.Size = New System.Drawing.Size(208, 28)
        Me.PosBar.TabIndex = 0
        Me.PosBar.TextTickStyle = System.Windows.Forms.TickStyle.None
        Me.PosBar.TickColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.PosBar.TickHeight = 4
        Me.PosBar.TickStyle = System.Windows.Forms.TickStyle.None
        Me.PosBar.TrackerColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.PosBar.TrackerSize = New System.Drawing.Size(16, 16)
        Me.PosBar.TrackLineColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.PosBar.TrackLineHeight = 3
        Me.PosBar.Value = 0
        '
        'actualPos
        '
        Me.actualPos.Interval = 250
        '
        'delApearBar
        '
        Me.delApearBar.Interval = 5000
        '
        'Mousecapt
        '
        Me.Mousecapt.Enabled = True
        Me.Mousecapt.Interval = 500
        '
        'textMovil
        '
        Me.textMovil.Interval = 30
        '
        'DibujoVideo
        '
        Me.DibujoVideo.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.DibujoVideo.Location = New System.Drawing.Point(0, 0)
        Me.DibujoVideo.Name = "DibujoVideo"
        Me.DibujoVideo.Size = New System.Drawing.Size(579, 354)
        Me.DibujoVideo.TabIndex = 0
        Me.DibujoVideo.TabStop = False
        '
        'clickdel
        '
        Me.clickdel.Interval = 300
        '
        'FormVideo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(579, 354)
        Me.ControlBox = False
        Me.Controls.Add(Me.BarraVideo)
        Me.Controls.Add(Me.DibujoVideo)
        Me.KeyPreview = True
        Me.Name = "FormVideo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.TransparencyKey = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BarraVideo.ResumeLayout(False)
        Me.panelTxtEsta.ResumeLayout(False)
        Me.panelTxtEsta.PerformLayout()
        CType(Me.DibujoVideo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        txtpista = New TextoMovil(panelTxtEsta, TxtEsta, textMovil)
    End Sub
    Friend WithEvents DibujoVideo As System.Windows.Forms.PictureBox
    Friend WithEvents BarraVideo As System.Windows.Forms.Panel
    Friend WithEvents PosBar As EConTech.Windows.MACUI.MACTrackBar
    Friend WithEvents BtnBackw As System.Windows.Forms.Button
    Friend WithEvents BtnFord As System.Windows.Forms.Button
    Friend WithEvents BtnTop As System.Windows.Forms.Button
    Friend WithEvents txtTiempo As System.Windows.Forms.Label
    Friend WithEvents TxtEsta As System.Windows.Forms.Label
    Friend WithEvents actualPos As System.Windows.Forms.Timer
    Friend WithEvents delApearBar As System.Windows.Forms.Timer
    Friend WithEvents Mousecapt As System.Windows.Forms.Timer
    Friend WithEvents textMovil As System.Windows.Forms.Timer
    Friend WithEvents clpIndic As System.Windows.Forms.Label
    Friend WithEvents panelTxtEsta As System.Windows.Forms.Panel
    Public txtpista As TextoMovil
    Friend WithEvents clickdel As System.Windows.Forms.Timer
End Class
