Option Explicit On
Option Strict Off
Public Class Plugins
    'finder
    Public ints As Principal
    Public buff As New CommandBuffer(Me)

    'Private Declare Function WaitForSingleObject Lib "kernel32" _
    '         (ByVal hHandle As Long, _
    '         ByVal dwMilliseconds As Long) As Long


    'Private Declare Function PostMessage Lib "user32" _
    '   Alias "PostMessageA" _
    '   (ByVal hWnd As Long, _
    '   ByVal wMsg As Long, _
    '   ByVal wParam As Long, _
    '   ByVal lParam As Long) As Long

    'Private Declare Function IsWindow Lib "user32" _
    '   (ByVal hWnd As Long) As Long

    'Private Declare Function OpenProcess Lib "kernel32" _
    '   (ByVal dwDesiredAccess As Long, _
    '   ByVal bInheritHandle As Long, _
    '   ByVal dwProcessId As Long) As Long

    'Private Declare Function GetWindowThreadProcessId Lib "user32" _
    '   (ByVal hWnd As Long, _
    '   ByVal lpdwProcessId As Long) As Long

    ''Constants that are used by the API
    'Const WM_CLOSE = &H10
    'Const INFINITE = &HFFFFFFFF
    'Const SYNCHRONIZE = &H100000


    Dim ptit As String
    Dim ptx As String
    Dim lastx As Long
    Dim lasty As Long

    'MSN
    Private Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hWnd As Long, ByVal wMsg As Long, ByVal wParam As Long, ByVal lParam As Long) As Long
    Private Declare Function FindWindow Lib "user32" Alias "FindWindowA" (ByVal lpClassName As String, ByVal lpWindowName As String) As Long
    Private Declare Function FindWindowEx Lib "user32" Alias "FindWindowExA" (ByVal hWnd1 As Long, ByVal hWnd2 As Long, ByVal lpsz1 As String, ByVal lpsz2 As String) As Long
    Private Declare Function SetForegroundWindow Lib "user32" (ByVal hWnd As Long) As Long
    Private Structure COPYDATASTRUCT
        Dim dwData As Long
        Dim cbData As Long
        Dim lpData As Long
    End Structure
    Private data As COPYDATASTRUCT
    Private Const WM_COPYDATA = &H4A
      'dar tecla presionada
    'Private Declare Function GetAsyncKeyState Lib "user32" (ByVal vKey As Long) As Integer
    Public Const REPRO_PAUSA As Integer = 0
    Public Const A_SIGUIENTE As Integer = 1
    Public Const A_ATRAS As Integer = 2
    Public Const A_PARAR As Integer = 3
    Public Const ADELANTAR As Integer = 4
    Public Const ATRAZAR As Integer = 5
    Public Const SUBIR_VOL As Integer = 6
    Public Const BAJAR_VOL As Integer = 7
    Public Const CALLAR_VOL As Integer = 8

    Public keysout As Integer() = {179, 176, 177, 178, 119, 118, 116, 117, 115}
    Public keysout2 As Integer() = {122, 123, 121, 120, 119, 118, 116, 117, 115}
    Public flagChangeKey As Boolean = False
    Public flagTeclaPress As Boolean = False
    Public timepresss As Integer = 0
    'Dim reproducir As Integer = 122
    'Dim siguiente As Integer = 123
    'Dim atras As Integer = 121
    'Dim parar As Integer = 120
    'Dim reboadelan As Integer = 119
    'Dim reboatras As Integer = 118
    'Dim volarriba As Integer = 116
    'Dim volabajo As Integer = 117
    'Dim sinvol As Integer = 115

    Private WithEvents globalHooks As New GlobalHook.GlobalHook

    Public Sub New(ByVal src As Principal)
        ints = src
    End Sub


    Public Sub setlastxy(ByVal X As Long, ByVal Y As Long)
        lastx = X
        lasty = Y
    End Sub
    Public Sub SetMusicInfo(ByRef mostrar As Boolean, ByRef mensaje As String, Optional ByRef tipo As String = "Music")

        Dim udtData As COPYDATASTRUCT
        Dim sBuffer As String
        Dim hMSGRUI As Long
        Dim ast As Integer
        If mostrar Then
            ast = 1
        Else
            ast = 0
        End If

        sBuffer = "\0" & tipo & "\0" & ast & "\0{0} - {1}\0\0" & mensaje & "\0\0\0" & vbNullChar

        udtData.dwData = &H547
        udtData.lpData = VarPtr(sBuffer)
        udtData.cbData = sBuffer.Length * 2
        Try
            Do
                hMSGRUI = FindWindowEx(0&, hMSGRUI, "MsnMsgrUIManager", vbNullString)

                If (hMSGRUI > 0) Then
                    Call SendMessage(hMSGRUI, WM_COPYDATA, 0, VarPtr(udtData))
                End If

            Loop Until (hMSGRUI = 0)
        Catch ex As Exception


            Dim MSN As New MSNPlug.ChangeText
            Call MSN.Send(mensaje, mensaje, "", tipo, mostrar)
        End Try

    End Sub

    Public Function VarPtr(ByVal e As Object) As Integer
        Dim GC As Runtime.InteropServices.GCHandle = Runtime.InteropServices.GCHandle.Alloc(e, Runtime.InteropServices.GCHandleType.Pinned)
        Dim GC2 As Integer = GC.AddrOfPinnedObject.ToInt32
        GC.Free()
        Return GC2
    End Function

    'Public Sub instanc(ByVal prog As String)
    '    Dim hWindow As Long
    '    Dim hThread As Long
    '    Dim hProcess As Long
    '    Dim lProcessId As Long
    '    Dim lngResult As Long
    '    Dim lngReturnValue As Long

    '    hWindow = FindWindow(vbNullString, prog)
    '    hThread = GetWindowThreadProcessId(hWindow, lProcessId)
    '    hProcess = OpenProcess(SYNCHRONIZE, 0&, lProcessId)
    '    lngReturnValue = PostMessage(hWindow, WM_CLOSE, 0&, 0&)
    '    lngResult = WaitForSingleObject(hProcess, INFINITE)

    '    'Does the handle still exist?
    '    Application.DoEvents()
    '    'hWindow = FindWindow(vbNullString, prog)

    'End Sub


    'Public Function dartecla() As Integer
    '    Dim i As Integer
    '    Dim tmp As Integer
    '    tmp = -22
    '    For i = 0 To 255
    '        If GetAsyncKeyState(i) And &H8000 Then
    '            tmp = i
    '            Exit For
    '        End If
    '    Next
    '    dartecla = tmp
    'End Function

#Region "KeyHookinit"
    Public Sub setHotKey(ByVal func As Integer, ByVal code As Integer, ByVal kit As Integer)
        Select Case kit
            Case 0
                keysout(func) = code
            Case 1
                keysout2(func) = code

        End Select


    End Sub

    Public Sub setHotKeysfromFile(ByVal func As Integer, ByVal format As String)

        keysout(func) = format.Split(";")(0)

        keysout2(func) = format.Split(";")(1)

    End Sub

    Public Function getHotKey(ByVal func As Integer, ByVal kit As Integer) As Integer
        Select Case kit
            Case 0
                Return keysout(func)
            Case 1
                Return keysout2(func)
        End Select
        Return -1
    End Function

    Public Function getHotKeysFromFile(ByVal func As Integer) As String
        Return keysout(func) & ";" & keysout2(func)
    End Function
    Public Sub InstallmouseHooks()
        globalHooks.installmousehooks()
    End Sub

    Public Sub RemovemouseHooks()
        globalHooks.removemousehooks()
    End Sub
    Public Sub InstallHooks()
        globalHooks.InstallHooks()
    End Sub

    Public Sub RemoveHooks()
        globalHooks.RemoveHooks()
    End Sub

    Private Sub globalHooks_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles globalHooks.KeyDown
        'If buff.dinbuff.Count = 0 Then resetBuff()
        'buff.addcharr(e.KeyValue)
        downKey(e.KeyCode)


    End Sub
    Public Sub downKey(ByVal key As Integer)


        If flagChangeKey Then
            'flagChangeKey = False


        Else
            flagTeclaPress = True
            If timepresss < 10 Then
                timepresss = timepresss + 1


            End If
            doDownFunct(key)
        End If
    End Sub

    Private Sub globalHooks_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles globalHooks.MouseDown
        'lb.Items.Insert(0, String.Format("down-{0} {1} {2} ({3}, {4})", e.Button.ToString, e.Clicks, e.Delta, e.X, e.Y))
        If ints.reproducciones.sourceActivo = Reproductor.VIDEO Or ints.reproducciones.sourceActivo = Reproductor.DVD Then


            If ints.vetaVideo.flagActivo = True And e.X < (ints.vetaVideo.Size.Width + ints.vetaVideo.Left) - 10 And e.X > (ints.vetaVideo.Left) + 10 And e.Y < (ints.vetaVideo.Size.Height + ints.vetaVideo.Top) - 10 And e.Y > (ints.vetaVideo.Top) + 38 Then
                ints.vetaVideo.moveron(e)
                ints.vetaVideo.fullsc()


            End If
        End If
    End Sub

    Private Sub globalHooks_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles globalHooks.MouseMove
        'lb.Items.Insert(0, String.Format("move-{0} {1} {2} ({3}, {4})", e.Button.ToString, e.Clicks, e.Delta, e.X, e.Y))
        If ints.reproducciones.sourceActivo = Reproductor.VIDEO Or ints.reproducciones.sourceActivo = Reproductor.DVD Then
            ints.vetaVideo.moviendo(e)
            If ints.AnimPau.Enabled And ints.vetaVideo.mover Then
                'ints.proseguir()
            End If
        End If
    End Sub

    Private Sub globalHooks_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles globalHooks.MouseUp
        'lb.Items.Insert(0, String.Format("up-{0} {1} {2} ({3}, {4})", e.Button.ToString, e.Clicks, e.Delta, e.X, e.Y))
        If ints.reproducciones.sourceActivo = Reproductor.VIDEO Or ints.reproducciones.sourceActivo = Reproductor.DVD Then
            If e.X < (ints.vetaVideo.Size.Width + ints.vetaVideo.Left) - 10 And e.X > (ints.vetaVideo.Left) + 10 And e.Y < (ints.vetaVideo.Size.Height + ints.vetaVideo.Top) - 10 And e.Y > (ints.vetaVideo.Top) + 38 Then
                ints.vetaVideo.moveroff(e)
            End If
        End If
    End Sub

    Public Sub cambioTecla(ByVal e As Integer)
        Select Case ints.OpcTeclKit.SelectedIndex
            Case 0
                ints.OpcButtCambioTeclas.Text = "Cambiar Tecla"
                setHotKey(ints.OpcCambioTeclas.SelectedIndex, e, 0)
                MsgBox("La tecla " & ints.OpcCambioTeclas.Text & " fue cambiada en el kit 1", vbInformation, "Cambio tecla")

            Case 1
                ints.OpcButtCambioTeclas.Text = "Cambiar Tecla"
                setHotKey(ints.OpcCambioTeclas.SelectedIndex, e, 1)
                MsgBox("La tecla " & ints.OpcCambioTeclas.Text & " fue cambiada en el kit 2", vbInformation, "Cambio tecla")

        End Select

    End Sub
    Private Sub globalHooks_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles globalHooks.KeyPress

    End Sub

    Public Sub pressKey(ByVal key As Integer)
        If flagChangeKey Then

            flagChangeKey = False
            flagTeclaPress = False
            timepresss = 0
            cambioTecla(key)
            Exit Sub
        Else
            doUpFunct(key)
        End If
        flagTeclaPress = False
        timepresss = 0
        'buff = New CommandBuffer(Me)
        'RemoveHooks()
        'InstallHooks()
    End Sub
    Private Sub globalHooks_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles globalHooks.KeyUp
        ' buff.removecharr(e.KeyValue)
        pressKey(e.KeyCode)


    End Sub
    Public Sub resetBuff()
        buff = New CommandBuffer(Me)
    End Sub

    Public Sub doDownFunct(ByVal key As Integer)

        Select Case HKFuncion(key)
            Case Plugins.REPRO_PAUSA

                If ints.reproducciones.reproductorMPEG.isMoviePlaying Then
                    If ints.AnimPau.Enabled Then
                        ints.proseguir()
                    Else
                        ints.pausa()
                    End If
                Else
                    ints.desicionReproduccion()
                End If

            Case Plugins.A_ATRAS
                ints.dnatrIntelig()
            Case Plugins.A_PARAR
                ints.parar()
            Case Plugins.A_SIGUIENTE
                ints.dnSigIntelig()
            Case Plugins.ADELANTAR
                ints.progresAdelan()
            Case Plugins.ATRAZAR
                ints.progresAtras()
            Case Plugins.BAJAR_VOL
                ints.bajarvol()
            Case Plugins.CALLAR_VOL
                ints.muteact()
            Case Plugins.SUBIR_VOL
                ints.subirvol()


        End Select
    End Sub

    Public Sub doUpFunct(ByVal key As Integer)

        Select Case HKFuncion(key)

            Case Plugins.A_ATRAS
                ints.upatrasIntelig()
            Case Plugins.A_SIGUIENTE
                ints.upsiguienteIntelig()

                'Case Plugins.ADELANTAR
                '    ints.pararadelantaciondef()
                'Case Plugins.ATRAZAR
                '    ints.pararadelantaciondef()

        End Select
    End Sub
    Private Function HKFuncion(ByVal key As Integer) As Integer
        For i = 0 To keysout.Length - 1

            If (ints.OpcTeclas.Checked And keysout(i) = key) Or (ints.OpcTeclasD.Checked And keysout2(i) = key) Then
                Return i
                Exit Function
            End If
        Next

        Return -1
    End Function
    
#End Region


End Class
