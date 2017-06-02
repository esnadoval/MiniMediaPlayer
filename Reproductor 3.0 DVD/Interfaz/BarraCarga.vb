Imports System.Windows.Forms
Imports System.Windows.Forms.ListView

Public Class BarraCarga
    Public princ As Principal
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub BarraCarga_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    Public Delegate Sub disposer()
    Public Sub diposeCmd()

        Hide()

    End Sub

    Public Delegate Sub delupdateBarraCarga(ByVal info As String, ByVal val As Integer)
    Public Sub cambiarValor(ByVal info As String, ByVal val As Integer)
        ProgressBar.Value = val
        InfoProg.Text = info
        Label1.Text = ("(" & ProgressBar.Value & "/" & ProgressBar.Maximum & ")")

    End Sub
    Public Delegate Sub delInicializar(ByVal maxibar As Integer, ByVal titulo As String, ByVal valini As String)
    Public Sub inicializar(ByVal maxibar As Integer, ByVal titulo As String, ByVal valini As String)
        ProgressBar.Maximum = maxibar
        ProgressBar.Minimum = 0
        ProgressBar.Value = 0
        LblTit.Text = titulo
        InfoProg.Text = valini
        Me.Refresh()

    End Sub

    Public outvar As String
    Private Sub Bw_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Bw.DoWork
        Dim objReader As System.IO.StreamReader = e.Argument
        Dim smp As String
       
        Dim dirs() As String
        Dim names() As String

        If princ.CargarM3U(Application.StartupPath & "\Last Playlist.m3u", dirs, names) Then


            princ.listaNombres.Items.Clear()
            princ.eventoDeListaActualizar()
            For i = 0 To dirs.Length - 1
                princ.agregaralista(dirs(i), sacardatosDir(dirs(i))(0))
                Bw.ReportProgress(i + 1, "Añadiendo " & sacardatosDir(dirs(i))(0))
            Next

        Else

        End If


        smp = objReader.ReadLine
        outvar = smp

    End Sub

    Private Sub Bw_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles Bw.ProgressChanged
        cambiarValor(e.UserState, e.ProgressPercentage)
    End Sub

    Private Sub Bw_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Bw.RunWorkerCompleted
        Me.Visible = False
    End Sub

End Class
