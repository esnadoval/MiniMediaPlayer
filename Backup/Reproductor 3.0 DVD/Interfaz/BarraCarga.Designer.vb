Imports System.ComponentModel

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BarraCarga
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
        Me.ProgressBar = New System.Windows.Forms.ProgressBar
        Me.InfoProg = New System.Windows.Forms.Label
        Me.LblTit = New System.Windows.Forms.Label
        Me.Bw = New System.ComponentModel.BackgroundWorker
        Me.Label1 = New System.Windows.Forms.Label
        Me.Bw2 = New System.ComponentModel.BackgroundWorker
        Me.Bw3 = New System.ComponentModel.BackgroundWorker
        Me.SuspendLayout()
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(12, 78)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(245, 23)
        Me.ProgressBar.TabIndex = 1
        '
        'InfoProg
        '
        Me.InfoProg.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InfoProg.ForeColor = System.Drawing.Color.White
        Me.InfoProg.Location = New System.Drawing.Point(12, 30)
        Me.InfoProg.Name = "InfoProg"
        Me.InfoProg.Size = New System.Drawing.Size(245, 23)
        Me.InfoProg.TabIndex = 2
        Me.InfoProg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblTit
        '
        Me.LblTit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTit.ForeColor = System.Drawing.Color.White
        Me.LblTit.Location = New System.Drawing.Point(12, 8)
        Me.LblTit.Name = "LblTit"
        Me.LblTit.Size = New System.Drawing.Size(245, 23)
        Me.LblTit.TabIndex = 3
        Me.LblTit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Bw
        '
        Me.Bw.WorkerReportsProgress = True
        Me.Bw.WorkerSupportsCancellation = True
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(13, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(245, 23)
        Me.Label1.TabIndex = 4
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Bw2
        '
        Me.Bw2.WorkerReportsProgress = True
        Me.Bw2.WorkerSupportsCancellation = True
        '
        'BarraCarga
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(270, 104)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LblTit)
        Me.Controls.Add(Me.InfoProg)
        Me.Controls.Add(Me.ProgressBar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "BarraCarga"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub




    
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents InfoProg As System.Windows.Forms.Label
    Friend WithEvents LblTit As System.Windows.Forms.Label
    Friend WithEvents Bw As System.ComponentModel.BackgroundWorker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Bw2 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Bw3 As System.ComponentModel.BackgroundWorker

End Class
