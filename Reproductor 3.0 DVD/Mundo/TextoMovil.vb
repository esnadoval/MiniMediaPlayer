Public Class TextoMovil

    Private panel As Panel
    Private label As Label
    Private timer As Timer
    Public texto As String

    Public Sub New(ByVal panell As Panel, ByVal labell As Label, ByVal timerr As Timer)
        panel = panell
        label = labell
        timer = timerr
    End Sub
    Public Sub moverElTexto()
        If label.Width > panel.Width Then
            If label.Left <= (-1 * label.Width) Then
                label.Left = panel.Width
            Else
                label.Left = label.Left - 1
            End If
        Else
            center()
        End If


    End Sub
    Public Sub setTexto(ByVal tx As String)
        timer.Enabled = False
        texto = tx
        label.Text = tx
        label.Left = panel.Width
        If label.Width > panel.Width Then
            timer.Enabled = True
        Else
            center()
        End If

    End Sub
    Public Sub reset()
        label.Left = panel.Width
    End Sub
    Public Sub center()
        label.Left = (panel.Width / 2) - (label.Width / 2)
    End Sub
End Class
