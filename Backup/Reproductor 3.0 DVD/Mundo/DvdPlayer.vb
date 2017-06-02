Imports System.Drawing
Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Imports System.Text

Imports DirectShowLib
Imports DirectShowLib.Dvd




''' <summary> MainForm for DVD Player. </summary>
Public Class DvdPlayer

    Private dsp As PictureBox

    ''' <summary> menu clicked to close DVD volume. </summary>
    Public Sub cerrarDVD()
        CloseInterfaces()

    End Sub

    ''' <summary> menu clicked to start playback. </summary>
    Public Sub reproducir(ByVal screen As PictureBox)
        If playState = playState.Init Then
            FirstPlayDvd(screen)
        Else
            If (mediaCtrl Is Nothing) OrElse (playState = playState.Playing) Then
                Return
            End If

            Dim hr As Integer = mediaCtrl.Run()
            DsError.ThrowExceptionForHR(hr)

            playState = playState.Playing

            If (menuMode = menuMode.Still) AndAlso (dvdCtrl IsNot Nothing) Then
                hr = dvdCtrl.StillOff()
                DsError.ThrowExceptionForHR(hr)
            End If
        End If

    End Sub

    Public Sub continuarReproduccion()
        If (mediaCtrl Is Nothing) OrElse (playState = playState.Playing) Then
            Return
        End If

        Dim hr As Integer = mediaCtrl.Run()
        DsError.ThrowExceptionForHR(hr)

        playState = playState.Playing

        If (menuMode = menuMode.Still) AndAlso (dvdCtrl IsNot Nothing) Then
            hr = dvdCtrl.StillOff()
            DsError.ThrowExceptionForHR(hr)
        End If
    End Sub

    ''' <summary> menu clicked to pause playback. </summary>
    Public Sub parar()
        If (mediaCtrl Is Nothing) OrElse (playState <> playState.Playing) Then
            Return
        End If

        Dim hr As Integer = mediaCtrl.Pause()
        DsError.ThrowExceptionForHR(hr)

        playState = playState.Paused

    End Sub

    ''' <summary> menu clicked to stop playback. </summary>
    Public Sub pararPlayback()
        If (mediaCtrl Is Nothing) OrElse ((playState <> playState.Playing) AndAlso (playState <> playState.Paused)) Then
            Return
        End If

        Dim hr As Integer = mediaCtrl.[Stop]()
        DsError.ThrowExceptionForHR(hr)

        playState = playState.Stopped

    End Sub

    ''' <summary> menu clicked to single-step. </summary>
    Private Sub menuPbackStepFw_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim hr As Integer
        If (videoStep Is Nothing) OrElse (mediaCtrl Is Nothing) Then
            Return
        End If

        If playState <> playState.Paused Then
            hr = mediaCtrl.Pause()
            DsError.ThrowExceptionForHR(hr)
        End If
        playState = playState.Paused
        hr = videoStep.[Step](1, Nothing)
        DsError.ThrowExceptionForHR(hr)

    End Sub

    ''' <summary> menu clicked to play next chapter. </summary>
    Public Sub irSiguienteCapitulo()
        If (playState <> playState.Playing) OrElse (dvdCtrl Is Nothing) Then
            Return
        End If

        Dim hr As Integer = dvdCtrl.PlayNextChapter(DvdCmdFlags.SendEvents, cmdOption)
        DsError.ThrowExceptionForHR(hr)

        If cmdOption IsNot Nothing Then
            pendingCmd = True
        End If

    End Sub

    Public Sub adelantarNFrames(ByVal vel As Double)
        If (playState <> playState.Playing) OrElse (dvdCtrl Is Nothing) Then
            Return
        End If

        Dim hr As Integer = dvdCtrl.PlayForwards(vel, DvdCmdFlags.SendEvents, cmdOption)
        Try
            DsError.ThrowExceptionForHR(hr)
        Catch ex As Exception

        End Try

        If cmdOption IsNot Nothing Then
            pendingCmd = True
        End If

    End Sub

    Public Sub atrazarNFrames(ByVal vel As Double)
        If (playState <> playState.Playing) OrElse (dvdCtrl Is Nothing) Then
            Return
        End If

        Dim hr As Integer = dvdCtrl.PlayBackwards(vel, DvdCmdFlags.SendEvents, cmdOption)
        Try
            DsError.ThrowExceptionForHR(hr)
        Catch ex As Exception

        End Try


        If cmdOption IsNot Nothing Then
            pendingCmd = True
        End If

    End Sub

    Public Sub irACapitulo(ByVal num As Integer)
        If (playState <> playState.Playing) OrElse (dvdCtrl Is Nothing) Then
            Return
        End If

        Dim hr As Integer = dvdCtrl.PlayChapter(num, DvdCmdFlags.SendEvents, cmdOption)
        DsError.ThrowExceptionForHR(hr)

        If cmdOption IsNot Nothing Then
            pendingCmd = True
        End If

    End Sub

    Public Sub seleccionarAudio(ByVal num As Integer)
        If (playState <> playState.Playing) OrElse (dvdCtrl Is Nothing) Then
            Return
        End If

        Dim hr As Integer = dvdCtrl.SelectAudioStream(num, DvdCmdFlags.SendEvents, cmdOption)
        DsError.ThrowExceptionForHR(hr)

        If cmdOption IsNot Nothing Then
            pendingCmd = True
        End If

    End Sub

    Public Sub seleccionarSubtitulo(ByVal num As Integer)
        If (playState <> playState.Playing) OrElse (dvdCtrl Is Nothing) Then
            Return
        End If

        Dim hr As Integer = dvdCtrl.SelectSubpictureStream(num, DvdCmdFlags.SendEvents, cmdOption)
        DsError.ThrowExceptionForHR(hr)

        If cmdOption IsNot Nothing Then
            pendingCmd = True
        End If

    End Sub

    Public Sub irATitulo(ByVal num As Integer)
        If (playState <> playState.Playing) OrElse (dvdCtrl Is Nothing) Then
            Return
        End If

        Dim hr As Integer = dvdCtrl.PlayTitle(num, DvdCmdFlags.SendEvents, cmdOption)
        Try
            DsError.ThrowExceptionForHR(hr)
        Catch ex As Exception

        End Try


        If cmdOption IsNot Nothing Then
            pendingCmd = True
        End If

    End Sub
    Public Sub cambiarIdioma(ByVal num As Integer)
        If (playState <> playState.Playing) OrElse (dvdCtrl Is Nothing) Then
            Return
        End If

        Dim hr As Integer = dvdCtrl.SelectAudioStream(num, DvdCmdFlags.SendEvents, cmdOption)
        DsError.ThrowExceptionForHR(hr)

        If cmdOption IsNot Nothing Then
            pendingCmd = True
        End If

    End Sub
    Public Sub cambiarSubtitulo(ByVal num As Integer)
        If (playState <> playState.Playing) OrElse (dvdCtrl Is Nothing) Then
            Return
        End If

        Dim hr As Integer = dvdCtrl.SelectSubpictureStream(num, DvdCmdFlags.SendEvents, cmdOption)
        DsError.ThrowExceptionForHR(hr)

        If cmdOption IsNot Nothing Then
            pendingCmd = True
        End If

    End Sub

    Private Sub getTime()
        Try
            'Dim hr As Integer
            'Dim lc As New DvdPlaybackLocation2
            'hr = dvdInfo.GetCurrentLocation(lc)
            'currnTime = lc.TimeCode
            OnDvdEvent()
        Catch ex As Exception

        End Try



    End Sub
    Public Function darRorulo() As String

        Dim hr As Integer
        Dim lc As New DvdPlaybackLocation2
        hr = dvdInfo.GetCurrentLocation(lc)
        Return "DVD Titulo: " & lc.TitleNum & " Capitulo: " & lc.ChapterNum


    End Function
    Public Function darUbicacion() As String

        Dim hr As Integer
        Dim lc As New DvdPlaybackLocation2
        hr = dvdInfo.GetCurrentLocation(lc)
        Return "Titulo: " & lc.TitleNum & "     Capitulo: " & lc.ChapterNum


    End Function

    ''' <summary> menu clicked to play previous chapter. </summary>
    Public Sub irAnteriorCapitulo()
        If (playState <> playState.Playing) OrElse (dvdCtrl Is Nothing) Then
            Return
        End If

        Dim hr As Integer = dvdCtrl.PlayPrevChapter(DvdCmdFlags.SendEvents, cmdOption)
        DsError.ThrowExceptionForHR(hr)

        If cmdOption IsNot Nothing Then
            pendingCmd = True
        End If

    End Sub


    Private Sub menuPbackFullscreen_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        ToggleFullScreen()
    End Sub

    ''' <summary> menu clicked to show dvd-root-menu. </summary>
    Public Sub irAMenuTitulo()
        Dim icmd As IDvdCmd

        If (playState <> playState.Playing) OrElse (dvdCtrl Is Nothing) Then
            Return
        End If

        Dim hr As Integer = dvdCtrl.ShowMenu(DvdMenuId.Root, DvdCmdFlags.Block Or DvdCmdFlags.Flush, icmd)
        DsError.ThrowExceptionForHR(hr)
    End Sub


    ''' <summary> menu clicked to show dvd-title-menu. </summary>
    Public Sub irAMenuPrincipal()
        Dim icmd As IDvdCmd

        If (playState <> playState.Playing) OrElse (dvdCtrl Is Nothing) Then
            Return
        End If

        Dim hr As Integer = dvdCtrl.ShowMenu(DvdMenuId.Title, DvdCmdFlags.Block Or DvdCmdFlags.Flush, icmd)
        DsError.ThrowExceptionForHR(hr)
    End Sub

    Public Sub irAPosicionS(ByVal timein As Long)
        Dim icmd As IDvdCmd

        If (playState <> playState.Playing) OrElse (dvdCtrl Is Nothing) Then
            Return
        End If
        Dim tim As New DvdHMSFTimeCode
        Dim h As Long
        Dim m As Long
        Dim s As Long
        h = timein \ 3600
        m = (timein \ 60) - h * 60
        s = (timein) - h * 3600 - m * 60

        tim.bHours = h
        tim.bMinutes = m
        tim.bSeconds = s
        Dim hr As Integer = dvdCtrl.PlayAtTime(tim, DvdCmdFlags.Block, icmd)
        Try
            DsError.ThrowExceptionForHR(hr)
        Catch ex As Exception

        End Try

    End Sub



    ''' <summary> show dialog about dvd information. </summary>
    Public Sub darInformacion()
        If (playState <> playState.Playing) OrElse (dvdInfo Is Nothing) Then
            Return
        End If

        Dim att As DvdVideoAttributes
        dvdInfo.GetCurrentVideoAttributes(att)
        Dim txt As New StringBuilder(600)
        txt.AppendFormat("Resolution  : {0} / {1}" & vbCr & vbLf, att.sourceResolutionX.ToString(), att.sourceResolutionY.ToString())
        txt.AppendFormat("Aspect      : {0} : {1}" & vbCr & vbLf, att.aspectX.ToString(), att.aspectY.ToString())
        txt.AppendFormat("Frame Rate  : {0}" & vbCr & vbLf, att.frameRate.ToString())
        txt.AppendFormat("Compression : {0}" & vbCr & vbLf, att.compression.ToString())

        'msgbox(txt.ToString(), "GetCurrentVideoAttributes", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Public Function darTitulos() As Integer

        Dim att As New DvdDiscSide
        Dim tits As Integer() = {0, 0, 0}
        dvdInfo.GetDVDVolumeInfo(tits(0), tits(1), att, tits(2))

        Return tits(2)

    End Function

    Public Function darCapitulosTitulo(ByVal numt As Integer) As Integer

        Dim tits As Integer = 0
        dvdInfo.GetNumberOfChapters(numt, tits)

        Return tits

    End Function

    Public Function darAudios() As Integer

        Dim tits As Integer() = {0, 0, 0}
        dvdInfo.GetCurrentAudio(tits(0), tits(1))

        Return tits(0)

    End Function
    Public Function darSubtitulos() As Integer

        Dim tits As Integer() = {0, 0, 0}

        dvdInfo.GetCurrentSubpicture(tits(0), tits(1), tits(2))

        Return tits(0)

    End Function


    Public Function darDirectorio() As String

        Dim tits As Integer = 0
        Dim strg As New StringBuilder
        dvdInfo.GetDVDDirectory(strg, 50, tits)

        Return strg.ToString

    End Function

    Public Function darTiempoTotalMS() As Long

        Dim att As New DvdHMSFTimeCode
        Dim ult As DvdTimeCodeFlags
        dvdInfo.GetTotalTitleTime(att, ult)
        Dim h As Long = att.bHours
        Dim m As Long = att.bMinutes
        Dim s As Long = att.bSeconds

        Return ((h * 3600000) + (m * 60000) + (s * 1000))

    End Function
    Public Function darTiempoTotalS() As Long
        Dim att As New DvdHMSFTimeCode
        Dim ult As DvdTimeCodeFlags
        dvdInfo.GetTotalTitleTime(att, ult)
        Dim h As Long = att.bHours
        Dim m As Long = att.bMinutes
        Dim s As Long = att.bSeconds

        Return ((h * 3600) + (m * 60) + (s))

    End Function

    Public Function darTiempoTotalFormato() As String
        Dim att As New DvdHMSFTimeCode
        Dim ult As DvdTimeCodeFlags
        dvdInfo.GetTotalTitleTime(att, ult)
        Dim h As Long = att.bHours
        Dim m As Long = att.bMinutes
        Dim s As Long = att.bSeconds

        Return h & ":" & m & ":" & s

    End Function

    ''' <summary> handling the very first start of dvd playback. </summary>
    Private Function FirstPlayDvd(ByVal pantalla As PictureBox) As Boolean
        Dim hr As Integer

        Try
            pendingCmd = True
            dsp = pantalla
            CloseInterfaces()
            If Not GetInterfaces() Then
                Return False
            End If

            hr = dvdCtrl.SetOption(DvdOptionFlag.HMSFTimeCodeEvents, True)
            ' use new HMSF timecode format
            DsError.ThrowExceptionForHR(hr)

            hr = dvdCtrl.SetOption(DvdOptionFlag.ResetOnStop, False)
            DsError.ThrowExceptionForHR(hr)

            hr = mediaEvt.SetNotifyWindow(pantalla.Handle, WM_DVD_EVENT, IntPtr.Zero)
            DsError.ThrowExceptionForHR(hr)

            hr = videoWin.put_Owner(pantalla.Handle)
            DsError.ThrowExceptionForHR(hr)

            hr = videoWin.put_WindowStyle(WindowStyle.Child Or WindowStyle.ClipSiblings Or WindowStyle.ClipChildren)
            'hr = videoWin.put_WindowStyle(WindowStyle.Child)
            DsError.ThrowExceptionForHR(hr)

            ResizeVideoWindow()

            hr = mediaCtrl.Run()
            DsError.ThrowExceptionForHR(hr)

            hr = videoWin.put_MessageDrain(pantalla.Handle)
            DsError.ThrowExceptionForHR(hr)

            playState = playState.Playing
            pendingCmd = False

            Return True
        Catch ee As Exception
            MsgBox("No se puede iniciar el DVD" & vbCr & vbLf & ee.Message, MsgBoxStyle.Critical, "Mini Media Player")
            CloseInterfaces()
            Return False
        End Try
    End Function


    Public Sub ResizeVideoWindow()
        If videoWin Is Nothing Then
            Return
        End If

        Dim rc As Rectangle = dsp.ClientRectangle
        Dim hr As Integer = videoWin.SetWindowPosition(0, 0, rc.Right, rc.Bottom)
        DsError.ThrowExceptionForHR(hr)
    End Sub


    ''' <summary> create the used COM components and get the interfaces. </summary>
    Private Function GetInterfaces() As Boolean
        Dim hr As Integer
        Dim status As AMDvdRenderStatus
        Dim comobj As Object = Nothing

        Try
            dvdGraph = DirectCast(New DvdGraphBuilder(), IDvdGraphBuilder)

            hr = dvdGraph.RenderDvdVideoVolume(Nothing, AMDvdGraphFlags.None, status)
            DsError.ThrowExceptionForHR(hr)

            hr = dvdGraph.GetDvdInterface(GetType(IDvdInfo2).GUID, comobj)
            DsError.ThrowExceptionForHR(hr)
            dvdInfo = DirectCast(comobj, IDvdInfo2)
            comobj = Nothing

            hr = dvdGraph.GetDvdInterface(GetType(IDvdControl2).GUID, comobj)
            DsError.ThrowExceptionForHR(hr)
            dvdCtrl = DirectCast(comobj, IDvdControl2)
            comobj = Nothing

            hr = dvdGraph.GetFiltergraph(graphBuilder)
            DsError.ThrowExceptionForHR(hr)

            mediaCtrl = DirectCast(graphBuilder, IMediaControl)
            mediaEvt = DirectCast(graphBuilder, IMediaEventEx)

            hr = dvdGraph.GetDvdInterface(GetType(IVideoWindow).GUID, comobj)
            DsError.ThrowExceptionForHR(hr)

            videoWin = DirectCast(comobj, IVideoWindow)
            comobj = Nothing

            GetFrameStepInterface()
            Return True
        Catch ee As Exception
            MsgBox("Could not get interfaces" & vbCr & vbLf & ee.Message, MsgBoxStyle.Critical, "Mini Media Player")
            CloseInterfaces()
            Return False
        Finally
            If comobj IsNot Nothing Then
                Marshal.ReleaseComObject(comobj)
                comobj = Nothing
            End If
        End Try
    End Function


    ''' <summary> detect if we can single step. </summary>
    Private Function GetFrameStepInterface() As Boolean
        videoStep = TryCast(graphBuilder, IVideoFrameStep)
        If videoStep Is Nothing Then
            Return False
        End If

        ' Check if this decoder can step
        Dim hr As Integer = videoStep.CanStep(0, Nothing)
        If hr <> 0 Then
            videoStep = Nothing
            Return False
        End If
        Return True
    End Function


    ''' <summary> do cleanup and release DirectShow. </summary>
    Private Sub CloseInterfaces()
        Dim hr As Integer
        Try
            If dvdCtrl IsNot Nothing Then
                hr = dvdCtrl.SetOption(DvdOptionFlag.ResetOnStop, True)
            End If

            If mediaCtrl IsNot Nothing Then
                hr = mediaCtrl.[Stop]()
                mediaCtrl = Nothing
            End If
            playState = playState.Stopped

            If mediaEvt IsNot Nothing Then
                hr = mediaEvt.SetNotifyWindow(IntPtr.Zero, WM_DVD_EVENT, IntPtr.Zero)
                mediaEvt = Nothing
            End If

            If videoWin IsNot Nothing Then
                hr = videoWin.put_Visible(OABool.[False])
                hr = videoWin.put_MessageDrain(IntPtr.Zero)
                hr = videoWin.put_Owner(IntPtr.Zero)
                videoWin = Nothing
            End If

            videoStep = Nothing

            If cmdOption IsNot Nothing Then
                Marshal.ReleaseComObject(cmdOption)
                cmdOption = Nothing
            End If

            pendingCmd = False

            If graphBuilder IsNot Nothing Then
                Marshal.ReleaseComObject(graphBuilder)
                graphBuilder = Nothing
            End If

            dvdCtrl = Nothing
            If dvdInfo IsNot Nothing Then
                Marshal.ReleaseComObject(dvdInfo)
                dvdInfo = Nothing
            End If

            If dvdGraph IsNot Nothing Then
                Marshal.ReleaseComObject(dvdGraph)
                dvdGraph = Nothing
            End If

            playState = playState.Init
        Catch generatedExceptionName As Exception
        End Try
    End Sub


    Private Sub ToggleFullScreen()
        If videoWin Is Nothing Then
            Return
        End If

        Dim mode As OABool
        Dim hr As Integer = videoWin.get_FullScreenMode(mode)
        If mode = OABool.[False] Then
            hr = videoWin.put_FullScreenMode(OABool.[True])
            If hr >= 0 Then
                fullScreen = True
            End If
        Else
            hr = videoWin.put_FullScreenMode(OABool.[False])
            If hr >= 0 Then
                fullScreen = False
            End If


        End If
    End Sub


    ''' <summary> override message handler to get dvd events</summary>


    Public Function darTiempoMS() As Long
        getTime()
        Dim h As Long = currnTime.bHours
        Dim m As Long = currnTime.bMinutes
        Dim s As Long = currnTime.bSeconds

        Return ((h * 3600000) + (m * 60000) + (s * 1000))
    End Function
    Public Function darTiempoS() As Long
        getTime()
        Dim h As Long = currnTime.bHours
        Dim m As Long = currnTime.bMinutes
        Dim s As Long = currnTime.bSeconds

        Return ((h * 3600) + (m * 60) + (s))
    End Function

    Public Function darTiempoFormato() As String
        getTime()
        Dim h As Long = currnTime.bHours
        Dim m As Long = currnTime.bMinutes
        Dim s As Long = currnTime.bSeconds

        Return h & ":" & m & ":" & s
    End Function

    Public Sub moverCtrlDVD(ByVal x As Long, ByVal y As Long)
        Try

            Dim pt As New Point()
            pt.X = x
            pt.Y = y
            dvdCtrl.SelectAtPosition(pt)
        Catch ex As Exception

        End Try

    End Sub


    Public Sub clicCtrlDvd(ByVal x As Long, ByVal y As Long)
        Try
            Dim pt As New Point()
            pt.X = x
            pt.Y = y
            dvdCtrl.ActivateAtPosition(pt)
        Catch ex As Exception

        End Try

    End Sub
    ''' <summary> DVD event message handler</summary>
    Public Sub OnDvdEvent()
        Dim p1 As IntPtr, p2 As IntPtr
        Dim hr As Integer = 0
        Dim code As EventCode
        Do
            hr = mediaEvt.GetEvent(code, p1, p2, 0)
            If hr < 0 Then
                Exit Do
            End If

            Select Case code
                Case EventCode.DvdCurrentHmsfTime
                    If True Then
                        Dim ati As Byte() = BitConverter.GetBytes(p1.ToInt32())
                        currnTime.bHours = ati(0)
                        currnTime.bMinutes = ati(1)
                        currnTime.bSeconds = ati(2)
                        currnTime.bFrames = ati(3)

                        Exit Select
                    End If
                Case EventCode.DvdChapterStart
                    If True Then
                        currnChapter = p1.ToInt32()

                        Exit Select
                    End If
                Case EventCode.DvdTitleChange
                    If True Then
                        currnTitle = p1.ToInt32()

                        Exit Select
                    End If
                Case EventCode.DvdDomainChange
                    If True Then
                        currnDomain = DirectCast(p1.ToInt32, DvdDomain)

                        Exit Select
                    End If

                Case EventCode.DvdCmdStart
                    If True Then
                        Exit Select
                    End If
                Case EventCode.DvdCmdEnd
                    If True Then
                        OnCmdComplete(p1, p2)
                        Exit Select
                    End If

                Case EventCode.DvdStillOn
                    If True Then
                        If p1 = IntPtr.Zero Then
                            menuMode = menuMode.Buttons
                        Else
                            menuMode = menuMode.Still
                        End If
                        Exit Select
                    End If
                Case EventCode.DvdStillOff
                    If True Then
                        If menuMode = menuMode.Still Then
                            menuMode = menuMode.No
                        End If
                        Exit Select
                    End If
                Case EventCode.DvdButtonChange
                    If True Then
                        If p1.ToInt32() <= 0 Then
                            menuMode = menuMode.No
                        Else
                            menuMode = menuMode.Buttons
                        End If
                        Exit Select
                    End If

                Case EventCode.DvdNoFpPgc
                    If True Then
                        Dim icmd As IDvdCmd

                        If dvdCtrl IsNot Nothing Then
                            hr = dvdCtrl.PlayTitle(1, DvdCmdFlags.None, icmd)
                        End If
                        Exit Select
                    End If
            End Select

            hr = mediaEvt.FreeEventParams(code, p1, p2)
        Loop While hr = 0
    End Sub

    ''' <summary> asynchronous command completed </summary>
    Private Sub OnCmdComplete(ByVal p1 As IntPtr, ByVal hrg As IntPtr)
        ' Trace.WriteLine( "DVD OnCmdComplete.........." );
        If (pendingCmd = False) OrElse (dvdInfo Is Nothing) Then
            Return
        End If

        Dim cmd As IDvdCmd
        Dim hr As Integer = dvdInfo.GetCmdFromEvent(p1, cmd)
        DsError.ThrowExceptionForHR(hr)

        If cmd Is Nothing Then
            ' DVD OnCmdComplete GetCmdFromEvent failed
            Return
        End If

        If cmd IsNot cmdOption Then
            ' DVD OnCmdComplete UNKNOWN CMD
            Marshal.ReleaseComObject(cmd)
            cmd = Nothing
            Return
        End If

        Marshal.ReleaseComObject(cmd)
        cmd = Nothing
        Marshal.ReleaseComObject(cmdOption)
        cmdOption = Nothing
        pendingCmd = False
        ' Trace.WriteLine( "DVD OnCmdComplete OK." );

    End Sub



    ''' <summary> for dvd menus, forward mouse movements </summary>
    Private Sub MainForm_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If (dvdCtrl Is Nothing) OrElse (menuMode <> menuMode.Buttons) Then
            Return
        End If
        Dim pt As New Point()
        pt.X = e.X
        pt.Y = e.Y
        dvdCtrl.SelectAtPosition(pt)
    End Sub


    ''' <summary> for dvd menus, forward mouse button clicks </summary>
    Private Sub MainForm_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If (dvdCtrl Is Nothing) OrElse (menuMode <> menuMode.Buttons) Then
            Return
        End If
        Dim pt As New Point()
        pt.X = e.X
        pt.Y = e.Y
        dvdCtrl.ActivateAtPosition(pt)
    End Sub


    ''' <summary> keyboard handling for shortcuts. </summary>
    Public Sub MainForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If pendingCmd Then
            Return
        End If

        If e.KeyCode = Keys.P Then

            Return
        End If

        If playState = playState.Init Then
            Return
        End If

        Select Case e.KeyCode
            Case Keys.A
                If True Then

                    Exit Select
                End If
            Case Keys.S
                If True Then

                    Exit Select
                End If
            Case Keys.D1, Keys.Space
                If True Then

                    Exit Select
                End If

            Case Keys.N
                If True Then

                    Exit Select
                End If
            Case Keys.R
                If True Then

                    Exit Select
                End If

            Case Keys.F
                If True Then
                    menuPbackFullscreen_Click(Nothing, Nothing)
                    Exit Select
                End If

            Case Keys.Escape
                If True Then
                    If fullScreen Then
                        ToggleFullScreen()
                    End If
                    Exit Select
                End If

            Case Keys.Home
                If True Then

                    Exit Select
                End If

            Case Keys.M
                If True Then

                    Exit Select
                End If

            Case Keys.I
                If True Then
                    Exit Select
                End If

            Case Keys.Left
                If True Then
                    If (menuMode = menuMode.Buttons) AndAlso (dvdCtrl IsNot Nothing) Then
                        dvdCtrl.SelectRelativeButton(DvdRelativeButton.Left)
                    End If
                    Exit Select
                End If
            Case Keys.Right
                If True Then
                    If (menuMode = menuMode.Buttons) AndAlso (dvdCtrl IsNot Nothing) Then
                        dvdCtrl.SelectRelativeButton(DvdRelativeButton.Right)
                    End If
                    Exit Select
                End If
            Case Keys.Up
                If True Then
                    If (menuMode = menuMode.Buttons) AndAlso (dvdCtrl IsNot Nothing) Then
                        dvdCtrl.SelectRelativeButton(DvdRelativeButton.Upper)
                    End If
                    Exit Select
                End If
            Case Keys.Down
                If True Then
                    If (menuMode = menuMode.Buttons) AndAlso (dvdCtrl IsNot Nothing) Then
                        dvdCtrl.SelectRelativeButton(DvdRelativeButton.Lower)
                    End If
                    Exit Select
                End If
            Case Keys.Enter
                If True Then
                    If (menuMode = menuMode.Buttons) AndAlso (dvdCtrl IsNot Nothing) Then
                        dvdCtrl.ActivateButton()
                    ElseIf (menuMode = menuMode.Still) AndAlso (dvdCtrl IsNot Nothing) Then
                        dvdCtrl.StillOff()
                    End If
                    Exit Select
                End If
        End Select

    End Sub


#Region "Member Variables"

    ''' <summary> current state of playback (playing/paused/...) </summary>
    Private playState As PlayState

    ''' <summary> current mode of playback (movie/menu/still). </summary>
    Private menuMode As MenuMode

    ''' <summary> flag to toggle full-screen. </summary>
    Private fullScreen As Boolean

    ''' <summary> asynchronous command interface. </summary>
    Private cmdOption As IDvdCmd
    ''' <summary> asynchronous command pending. </summary>
    Private pendingCmd As Boolean

    ''' <summary> dvd graph builder interface. </summary>
    Private dvdGraph As IDvdGraphBuilder
    ''' <summary> dvd control interface. </summary>
    Private dvdCtrl As IDvdControl2
    ''' <summary> dvd information interface. </summary>
    Private dvdInfo As IDvdInfo2

    ''' <summary> dvd video playback window interface. </summary>
    Private videoWin As IVideoWindow

    Private graphBuilder As IGraphBuilder

    ''' <summary> control interface. </summary>
    Private mediaCtrl As IMediaControl

    ''' <summary> graph event interface. </summary>
    Private mediaEvt As IMediaEventEx

    ''' <summary> interface to single-step video. </summary>
    Private videoStep As IVideoFrameStep

    Private currnTime As New DvdHMSFTimeCode()
    ' copy of current playback states, see OnDvdEvent()
    Private currnTitle As Integer
    Private currnChapter As Integer
    Private currnDomain As DvdDomain

    Private Const WM_DVD_EVENT As Integer = &H8002
    ' message from dvd graph
    Private Const WS_CHILD As Integer = &H40000000
    ' attributes for video window
    Private Const WS_CLIPCHILDREN As Integer = &H2000000
    Private Const WS_CLIPSIBLINGS As Integer = &H4000000

#End Region

   


End Class


Friend Enum PlayState
    Init
    Playing
    Paused
    Stopped
End Enum

Friend Enum MenuMode
    No
    Buttons
    Still
End Enum

