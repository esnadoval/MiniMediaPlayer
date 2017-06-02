Public Class FormVideo

    Public princ As Principal
    Dim mxs As Long
    Dim mys As Long
    Private x As Integer
    Private y As Integer
    Public mover As Boolean
    Public flagMouse As Boolean = False
    Private Const WM_DVD_EVENT As Integer = &H8002
    Public cliccount As Integer = 0
    Public flagActivo As Boolean = True


    Public Sub guardares(ByVal X As Long, ByVal Y As Long)
        Try
            princ.reproducciones.reproductorMPEG.sizeLocateMovie(0, 0, X, Y)
        Catch e As Exception
        End Try
    End Sub

    Private Sub FormVideo_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed

    End Sub
    Public Sub moveron(ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ' habilitar el flag
            mover = True
            ' guardar las coordenadas
            x = e.X - Me.Location.X
            y = e.Y - Me.Location.Y
            ' cambiar el cursor del mouse
            Me.Cursor = Cursors.NoMove2D

        End If
    End Sub
    Public Sub moviendo(ByVal e As System.Windows.Forms.MouseEventArgs)

        If mover And Me.FormBorderStyle <> Windows.Forms.FormBorderStyle.None Then
            ' establecer la nueva posición
            Me.Location = New Point(e.X - x, e.Y - y)

        End If
    End Sub
    Public Sub moveroff(ByVal e As System.Windows.Forms.MouseEventArgs)
        ' reestablecer
        mover = False
        Me.Cursor = Cursors.Default

    End Sub
    Private Sub FormVideo_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        resise()
    End Sub
    Public Sub resise()
        If Me.Height < 320 Then
            Me.Height = 320

        End If
        If Me.Width < 450 Then
            Me.Width = 450

        End If

        If Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable Then

            Me.DibujoVideo.Height = Me.Height - 16
        Else
            Me.DibujoVideo.Height = Me.Height
        End If

        If Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable Then
            Me.DibujoVideo.Width = Me.Width - 16
        Else
            Me.DibujoVideo.Width = Me.Width
        End If

        If Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable Then
            BarraVideo.Width = Me.Width - 16
        Else
            BarraVideo.Width = Me.Width
        End If

        BtnFord.Left = BarraVideo.Width - 37
        PosBar.Width = Math.Abs(PosBar.Left - BtnFord.Left)
        guardares(Me.DibujoVideo.Width, Me.DibujoVideo.Height)
        Try
            princ.reproducciones.dvdplayer.ResizeVideoWindow()
        Catch ex As Exception

        End Try




    End Sub


    Private Sub FormVideo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        abrirvideo()

    End Sub
    Public Sub abrirvideo()
        Dim sumw As Integer
        Dim sumh As Integer

        For i As Integer = 0 To Screen.AllScreens.Length - 1
            sumw = sumw + Screen.AllScreens(i).Bounds.Width
            If Screen.AllScreens(i).Bounds.Height > sumh Then
                sumh = Screen.AllScreens(i).Bounds.Height
            End If
        Next


        If Me.Location.X >= sumw - 450 Or Me.Location.Y >= sumh - 320 Then
            Me.Location = New Point(0, 0)

        End If

        If Me.WindowState = FormWindowState.Maximized Then

        End If


        If Me.TopMost Then
            BtnTop.Text = "_v_"
        End If

        resise()
        txtpista.reset()
        txtpista.setTexto(princ.reproducciones.darNombrePista(True))
        mostrarBarra()
        Mousecapt.Enabled = True

    End Sub
    Public Sub actualizarPistaDVD()
        txtpista.reset()
        txtpista.setTexto(princ.reproducciones.dvdplayer.darRorulo)
    End Sub

    Public Sub actualizarRotuloMenuDVD()
        txtpista.reset()
        txtpista.setTexto("Menu DVD")
    End Sub
    Public Sub cerrarvideo()
        desaparecerBarra()
        Mousecapt.Enabled = False

    End Sub

    Public Sub mostrarBarra()
        Try

            BarraVideo.Visible = True
            actualizarSlider()
            txtTiempo.Text = princ.dspPos.Text
            actualPos.Enabled = True
            delApearBar.Enabled = True
            textMovil.Enabled = True

        Catch e As Exception
        End Try
    End Sub
    Public Sub actualizarSlider()

        If princ.flagSlider = False Then
            If princ.reproducciones.sourceActivo = Reproductor.DVD Then

                PosBar.Maximum = princ.reproducciones.dvdplayer.darTiempoTotalS
                PosBar.Value = princ.reproducciones.dvdplayer.darTiempoS

            Else
                PosBar.Maximum = princ.reproducciones.reproductorMPEG.getLengthInMS / 1000
                PosBar.Value = princ.reproducciones.reproductorMPEG.getPositionInMS / 1000
            End If
        End If
    End Sub
    Public Sub fullsc()
        If cliccount = 0 Then
            cliccount = 1
            clickdel.Enabled = True
            'If princ.AnimPau.Enabled Then
            '    princ.proseguir()
            'Else
            '    princ.pausa()
            'End If
            Exit Sub
        ElseIf cliccount = 1 Then
            cliccount = 0
            clickdel.Enabled = False
            'princ.proseguir()

        End If
        mover = False
        If Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable Then

            princ.reproducciones.videosets(0) = Me.Location.X
            princ.reproducciones.videosets(1) = Me.Location.Y
            princ.reproducciones.videosets(2) = Me.Width
            princ.reproducciones.videosets(3) = Me.Height
            Me.WindowState = FormWindowState.Maximized
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Else


            Me.WindowState = FormWindowState.Normal
            Dim sumw As Integer
            Dim sumh As Integer

            For i As Integer = 0 To Screen.AllScreens.Length - 1
                sumw = sumw + Screen.AllScreens(i).Bounds.Width
                If Screen.AllScreens(i).Bounds.Height > sumh Then
                    sumh = Screen.AllScreens(i).Bounds.Height
                End If
            Next


            If Me.Location.X >= sumw - 450 Or Me.Location.Y >= sumh - 320 Then
                Me.Location = New Point(0, 0)

            End If

            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable

        End If
        resise()
    End Sub
    Public Sub desaparecerBarra()
        Try
            If Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None And Cursor.Position.X >= Me.Left And Cursor.Position.X <= Me.Left + Me.Width And Cursor.Position.Y >= Me.Top And Cursor.Position.Y <= Me.Top + Me.Height Then
                If princ.reproducciones.dartipo = Reproductor.VIDEO Then

                    flagMouse = True
                    Cursor.Position = New Point(Me.Width + 1, Me.Height + 1)
                End If
            End If
            BarraVideo.Visible = False
            actualPos.Enabled = False
            delApearBar.Enabled = False
            textMovil.Enabled = False
        Catch e As Exception
        End Try
    End Sub

    Private Sub Mousecapt_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Mousecapt.Tick
        Dim xx As Long
        Dim yy As Long

        xx = Cursor.Position.X
        yy = Cursor.Position.Y


        If ((mxs <> xx Or mys <> yy) And (xx > Me.Left And xx < Me.Left + Me.Width) And (yy > Me.Top And yy * 15 < Me.Top + Me.Height)) Or ((mxs <> xx Or mys <> yy) And (xx > Me.Left And xx < Me.Left + Me.Width) And (yy > Me.Top And yy < Me.Top + Me.Height)) Then

            If BarraVideo.Visible = True Then
                delApearBar.Stop()
                delApearBar.Start()
            Else
                If flagMouse = True Then
                    flagMouse = False
                Else
                    mostrarBarra()
                End If

            End If

        End If
        mxs = xx
        mys = yy
    End Sub

    Private Sub actualPos_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actualPos.Tick
        txtTiempo.Text = princ.dspPos.Text
        If princ.flagSlider = False Then
            If princ.reproducciones.sourceActivo = Reproductor.DVD Then
                PosBar.Value = princ.reproducciones.dvdplayer.darTiempoS
            Else
                PosBar.Value = princ.reproducciones.reproductorMPEG.getPositionInMS / 1000
            End If
        End If

    End Sub

    Private Sub delApearBar_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles delApearBar.Tick
        If princ.reproducciones.fordwval = 0 And princ.AnimPau.Enabled = False Then
            desaparecerBarra()
            delApearBar.Enabled = False
        Else
            delApearBar.Stop()
            delApearBar.Start()
        End If
    End Sub

    Private Sub FormVideo_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        If Me.Visible = True Then abrirvideo() Else cerrarvideo()

    End Sub


    Private Sub txtTiempo_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtTiempo.MouseDown

    End Sub

    Private Sub txtTiempo_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtTiempo.MouseMove

    End Sub

    Private Sub txtTiempo_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtTiempo.MouseUp

    End Sub

    Private Sub TxtEsta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtEsta.Click
    End Sub

    Private Sub TxtEsta_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TxtEsta.MouseDown

    End Sub

    Private Sub TxtEsta_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TxtEsta.MouseMove

    End Sub

    Private Sub TxtEsta_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TxtEsta.MouseUp

    End Sub

    Private Sub BarraVideo_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles BarraVideo.MouseDown

    End Sub

    Private Sub BarraVideo_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles BarraVideo.MouseMove

    End Sub

    Private Sub BarraVideo_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles BarraVideo.MouseUp

    End Sub


    Private Sub BarraVideo_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles BarraVideo.Paint

    End Sub

    Private Sub textMovil_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles textMovil.Tick
        If princ.reproducciones.fordwval = 0 And princ.AnimPau.Enabled = False Then
            txtpista.moverElTexto()
        End If
    End Sub

    Private Sub PosBar_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PosBar.MouseDown
        princ.flagSlider = True
        princ.adelantar(False, 0)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            princ.reproducciones.cambiarClipini(PosBar.Value * 1000)

        End If
    End Sub

    Private Sub PosBar_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PosBar.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Left Then
            If princ.reproducciones.sourceActivo = Reproductor.DVD Then
                princ.reproducciones.dvdplayer.irAPosicionS(PosBar.Value)

            Else
                princ.reproducciones.reproductorMPEG.setPositionTo(PosBar.Value * 1000)
            End If
        ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
            princ.reproducciones.cambiarClipfin(PosBar.Value * 1000)
        End If
        princ.flagSlider = False
    End Sub



    Private Sub PosBar_ValueChanged(ByVal sender As System.Object, ByVal value As System.Decimal) Handles PosBar.ValueChanged
        If princ.flagSlider = True Then
            textMovil.Enabled = False
            txtpista.center()
            TxtEsta.Text = princ.reproducciones.reproductorMPEG.getThisTime(PosBar.Value * 1000)
        ElseIf princ.TimerAdelan.Enabled = False Then

            TxtEsta.Text = princ.dspTrac.Text
            textMovil.Enabled = True
        End If

    End Sub
    Public Sub adelantimgs()

        txtpista.setTexto(princ.dspTempor.Text)


    End Sub

    Private Sub BtnMax_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        fullsc()
    End Sub

    Private Sub BtnTop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTop.Click
        If BtnTop.Text = "_/\_" Then
            BtnTop.Text = "_\/_"
            Me.TopMost = True
        Else
            BtnTop.Text = "_/\_"
            Me.TopMost = False
        End If
    End Sub

    Private Sub BtnFord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFord.Click
        princ.progresAdelan()

    End Sub

    Private Sub BtnBackw_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBackw.Click
        princ.progresAtras()
    End Sub

    Private Sub clpIndic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clpIndic.Click

    End Sub

    Private Sub clpIndic_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles clpIndic.MouseDown

    End Sub

    Private Sub clpIndic_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles clpIndic.MouseMove

    End Sub

    Private Sub clpIndic_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles clpIndic.MouseUp

    End Sub

    Private Sub DibujoVideo_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DibujoVideo.MouseDown
        Try
            princ.reproducciones.dvdplayer.clicCtrlDvd(e.X, e.Y)
        Catch ex As Exception

        End Try


    End Sub



    Private Sub DibujoVideo_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DibujoVideo.MouseMove

        Try
            princ.reproducciones.dvdplayer.moverCtrlDVD(e.X, e.Y)
        Catch ex As Exception

        End Try

    End Sub

  
    Private Sub clickdel_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clickdel.Tick
        cliccount = 0
        clickdel.Enabled = False
    End Sub

    Private Sub FormVideo_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        flagActivo = True
    End Sub

    Private Sub FormVideo_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        flagActivo = False
    End Sub
End Class