Public Module ModuloPrincipal
    Dim formularioprinc As Principal
    Dim formulariovid As FormVideo


    Sub Main(ByVal args() As String)


        If PrevInstance() Then
            MsgBox("La Aplicacion ya se ha abierto", MsgBoxStyle.Exclamation, "Instancia abierta")
            End
        End If
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        formularioprinc = New Principal()
        formulariovid = New FormVideo()

        formularioprinc.vetaVideo = formulariovid
        formularioprinc.reproducciones.form = formularioprinc
        formularioprinc.reproducciones.reproductorRadio.parent = formularioprinc
        formularioprinc.reproducciones.reproductorRadio.initializeRadio() '(formularioprinc.reproducciones.reproductorRadio)
        formularioprinc.Show()
        abrir(args)
        Application.Run(formularioprinc)



    End Sub
    Public Sub cerrar()
        Dim oSW As New IO.StreamWriter(Application.StartupPath & "\Mini Media Player 3.ini")

        Try

            If formularioprinc.reproducciones.reproductorMPEG.isMoviePaused Then
                formularioprinc.reproducciones.reproduciract()
            End If
            formularioprinc.plugins.RemoveHooks()
            formularioprinc.plugins.SetMusicInfo(False, "")

            oSW.WriteLine("-Mini Media Player 3 Initialization-")
            Dim tmp As String = ""
            With formularioprinc

                If .OpcEnablMSN.Checked Then tmp = tmp & "si|" Else tmp = tmp & "no|"
                If .OpcGuard.Checked Then tmp = tmp & "si|" Else tmp = tmp & "no|"
                If .OpcIconoBarra.Checked Then tmp = tmp & "si|" Else tmp = tmp & "no|"
                If .OpcMinimizarIconoBarra.Checked Then tmp = tmp & "si|" Else tmp = tmp & "no|"
                If .OpcMostrarMensIconoBarra.Checked Then tmp = tmp & "si|" Else tmp = tmp & "no|"
                If .OpcMsnAudio.Checked Then tmp = tmp & "si|" Else tmp = tmp & "no|"
                If .OpcMSNVideo.Checked Then tmp = tmp & "si|" Else tmp = tmp & "no|"
                If .OpcTeclas.Checked Then tmp = tmp & "si|" Else tmp = tmp & "no|"
                If .OpcTeclasD.Checked Then tmp = tmp & "si|" Else tmp = tmp & "no|"
                If .OpcVideo.Checked Then tmp = tmp & "si" Else tmp = tmp & "no"
                oSW.WriteLine(tmp)
                tmp = .flagmax & "|" & .plugins.getHotKeysFromFile(Plugins.A_ATRAS) & "|" & .plugins.getHotKeysFromFile(Plugins.A_PARAR) & "|" & .plugins.getHotKeysFromFile(Plugins.ADELANTAR) & "|" & .plugins.getHotKeysFromFile(Plugins.ATRAZAR) & "|" & .plugins.getHotKeysFromFile(Plugins.REPRO_PAUSA) & "|" & .plugins.getHotKeysFromFile(Plugins.A_SIGUIENTE) & "|" & .plugins.getHotKeysFromFile(Plugins.CALLAR_VOL) & "|" & .plugins.getHotKeysFromFile(Plugins.BAJAR_VOL) & "|" & .plugins.getHotKeysFromFile(Plugins.SUBIR_VOL) & "|" & .mensajemsn & "|" & .volBar.Value
                If .reproducciones.reproductorMPEG.mute Then tmp = tmp & "|1" Else tmp = tmp & "|0"
                Try
                    Dim ss As Integer = 0
                    If .vetaVideo.TopMost Then ss = 1
                    If .vetaVideo.WindowState <> FormWindowState.Maximized Then
                        tmp = tmp & "|" & .vetaVideo.Location.X & "|" & .vetaVideo.Location.Y & "|" & .vetaVideo.Width & "|" & .vetaVideo.Height & "|" & .vetaVideo.FormBorderStyle & "|" & .vetaVideo.WindowState & "|" & ss
                    Else
                        tmp = tmp & "|" & .reproducciones.videosets(0) & "|" & .reproducciones.videosets(1) & "|" & .reproducciones.videosets(2) & "|" & .reproducciones.videosets(3) & "|" & .vetaVideo.FormBorderStyle & "|" & .vetaVideo.WindowState & "|" & ss
                    End If
                Catch ex As Exception
                    tmp = tmp & "|" & .reproducciones.videosets(0) & "|" & .reproducciones.videosets(1) & "|" & .reproducciones.videosets(2) & "|" & .reproducciones.videosets(3) & "|" & .reproducciones.videosets(4) & "|" & .reproducciones.videosets(5) & "|" & .reproducciones.videosets(6)
                End Try

                oSW.WriteLine(tmp)

                If .ListaTunes.Items.Count > 0 Then
                    .GuardarM3U(Application.StartupPath & "\Last Radio.m3u", .ListaTunes.Items, 1, 0)
                End If




                If .OpcGuard.Checked Then
                    oSW.WriteLine(.path)
                    If .listaArchivos.Items.Count = 0 Then  Else 
                    oSW.WriteLine("" & .getSelectedIndex(.listaArchivos) & ":" & .getSelectedIndex(.listaNombres) & ":" & .getSelectedIndex(.ListaTunes)) 'Modificar
                    oSW.WriteLine("" & .listaNombres.Items.Count)
                    If .listaNombres.Items.Count > 0 Then
                        .GuardarM3U(Application.StartupPath & "\Last Playlist.m3u", .listaNombres.Items, 5, 0)
                    Else
                        If System.IO.File.Exists(Application.StartupPath & "\Last Playlist.m3u") = True Then

                            System.IO.File.Delete(Application.StartupPath & "\Last Playlist.m3u")


                        End If
                    End If

                    oSW.WriteLine(.randomGenerator.persistString)
                    'If .rndLst.Items.Count > 0 Then
                    '    For i As Integer = 0 To .rndLst.Items.Count - 1
                    '        .rndLst.SelectedIndex = i
                    '        oSW.WriteLine(.rndLst.Text)
                    '    Next
                    '    oSW.WriteLine("FinLista")
                    'Else
                    '    oSW.WriteLine("NoArch")
                    'End If

                    oSW.WriteLine(.reproducciones.darlugar & "|" & .reproducciones.darmodo & "|" & .reproducciones.darorden)
                    If .reproducciones.reproductorMPEG.Filename = "RADIO" Then
                        oSW.WriteLine(.reproducciones.reproductorMPEG.Filename & "|" & .reproducciones.reproductorRadio.lasturl)

                    Else
                        oSW.WriteLine(.reproducciones.reproductorMPEG.Filename & "|" & .reproducciones.reproductorMPEG.getPositionInMS)


                    End If

                End If
                .reproducciones.reproductorMPEG.closeMovie()
            End With
            oSW.Flush()
            oSW.Close()
            formularioprinc.reproducciones.reproductorRadio.radio.NetRadio_Close()
            formularioprinc.Dispose()
            If formulariovid.Visible = True Then formulariovid.Dispose()
        Catch es As Exception

            MsgBox("Error al guardar, " & es.Message, MsgBoxStyle.Critical, "Guardando")
            oSW.Close()
        End Try


    End Sub

    Public Sub abrir(ByVal args() As String)
        Dim objReader As System.IO.StreamReader
        Try

            Try

                objReader = IO.File.OpenText(Application.StartupPath & "\Mini Media Player 3.ini")
                objReader.ReadLine()
            Catch ex As Exception
                formularioprinc.aumentarRedprincipal(False)

                MsgBox("Esta es la primera vez que ejecuta el reproductor, para cambiar las opciones Cliquee en el boton 'Mostrar Opciones' ", MsgBoxStyle.Information, "Mini Media Player 3")
                Exit Sub
            End Try
            formularioprinc.plugins.InstallHooks()
            Dim aa As String = objReader.ReadLine
            Dim tmp() As String = aa.Split(ChrW(124))
            With formularioprinc
                If tmp(0) = "si" Then .OpcEnablMSN.Checked = True Else .OpcEnablMSN.Checked = False
                If tmp(1) = "si" Then .OpcGuard.Checked = True Else .OpcGuard.Checked = False
                If tmp(2) = "si" Then .OpcIconoBarra.Checked = True Else .OpcIconoBarra.Checked = False
                If tmp(3) = "si" Then .OpcMinimizarIconoBarra.Checked = True Else .OpcMinimizarIconoBarra.Checked = False
                If tmp(4) = "si" Then .OpcMostrarMensIconoBarra.Checked = True Else .OpcMostrarMensIconoBarra.Checked = False
                If tmp(5) = "si" Then .OpcMsnAudio.Checked = True Else .OpcMsnAudio.Checked = False
                If tmp(6) = "si" Then .OpcMSNVideo.Checked = True Else .OpcMSNVideo.Checked = False
                If tmp(7) = "si" Then .OpcTeclas.Checked = True Else .OpcTeclas.Checked = False
                If tmp(8) = "si" Then .OpcTeclasD.Checked = True Else .OpcTeclasD.Checked = False
                If tmp(9) = "si" Then .OpcVideo.Checked = True Else .OpcVideo.Checked = False
                aa = objReader.ReadLine
                tmp = aa.Split(ChrW(124))
                .flagmax = tmp(0)
                .aumentarRedprincipal(.flagmax)
                .plugins.setHotKeysfromFile(Plugins.A_ATRAS, tmp(1))
                .plugins.setHotKeysfromFile(Plugins.A_PARAR, tmp(2))
                .plugins.setHotKeysfromFile(Plugins.ADELANTAR, tmp(3))
                .plugins.setHotKeysfromFile(Plugins.ATRAZAR, tmp(4))
                .plugins.setHotKeysfromFile(Plugins.REPRO_PAUSA, tmp(5))
                .plugins.setHotKeysfromFile(Plugins.A_SIGUIENTE, tmp(6))
                .plugins.setHotKeysfromFile(Plugins.CALLAR_VOL, tmp(7))
                .plugins.setHotKeysfromFile(Plugins.BAJAR_VOL, tmp(8))
                .plugins.setHotKeysfromFile(Plugins.SUBIR_VOL, tmp(9))
                .OpcMsnTx.Text = tmp(10)
                .reproducciones.reproductorMPEG.volume = tmp(11)
                .volBar.Value = tmp(11)
                If tmp(12) = "0" Then

                    .reproducciones.reproductorMPEG.setAudioOn()
                    .reproducciones.reproductorMPEG.mute = False
                    .BtnMute.BackgroundImage = My.Resources.btnSpk
                Else

                    .reproducciones.reproductorMPEG.setAudioOff()
                    .reproducciones.reproductorMPEG.mute = True
                    .BtnMute.BackgroundImage = My.Resources.btnSpkMut
                End If

                If .OpcVideo.Checked = False Then
                    formulariovid.Left = tmp(13)
                    formulariovid.Top = tmp(14)
                    formulariovid.Width = tmp(15)
                    formulariovid.Height = tmp(16)
                    formulariovid.FormBorderStyle = tmp(17)
                    formulariovid.WindowState = tmp(18)
                    formulariovid.TopMost = tmp(19)

                    .reproducciones.videosets(0) = tmp(13)
                    .reproducciones.videosets(1) = tmp(14)
                    .reproducciones.videosets(2) = tmp(15)
                    .reproducciones.videosets(3) = tmp(16)
                    .reproducciones.videosets(4) = tmp(17)
                    .reproducciones.videosets(5) = tmp(18)
                    .reproducciones.videosets(6) = tmp(19)


                End If

                Try

                    Dim dirs() As String
                    Dim names() As String

                    If .CargarM3U(Application.StartupPath & "\Last Radio.m3u", dirs, names) Then
                        .ListaTunes.Items.Clear()
                        For i = 0 To dirs.Length - 1
                            .anadirEstRadio(dirs(i), names(i).Split(":")(1).Split(";")(0))
                        Next
                    Else


                    End If


                Catch ex As Exception

                End Try


                If args.Length > 0 Then

                    formularioprinc.abrirsolo(args(0))
                    objReader.Close()
                    Exit Sub
                End If
                '.TreeDir.expandDir(Application.StartupPath)
                If .OpcGuard.Checked Then

                    Dim smp As String
                    smp = objReader.ReadLine

                    .cargarAchivosListaArch(smp)


                    smp = objReader.ReadLine
                    Dim asd() As String = smp.Split(":")
                    smp = objReader.ReadLine

                    Dim plct As Integer = smp
                    Dim dirs() As String
                    Dim names() As String
                    If .CargarM3U(Application.StartupPath & "\Last Playlist.m3u", dirs, names) Then


                        .listaNombres.Items.Clear()
                        .eventoDeListaActualizar()
                        .abrirMultiples(dirs, True)


                    Else

                    End If

                    smp = objReader.ReadLine
                    Try
                        .randomGenerator = RandomSequence.rndGenFromString(smp)
                    Catch ex As Exception
                        .randomGenerator = New RandomSequence(2)
                    End Try

                    smp = objReader.ReadLine
                    Dim arr As String() = smp.Split(ChrW(124))
                    .obligarLugar(arr(0), False)
                    .obligarModo(arr(1))
                    .obligarOrden(arr(2), False)
                    smp = objReader.ReadLine
                    arr = smp.Split(ChrW(124))

                    If arr(0) <> "RADIO" And arr(1) > "1000" Then
                        .reproducciones.reproducir(arr(0))
                        If arr(0) = "CDAUDIO" Then .cargarInfoCDAudio()
                        .imgsRepro(True)
                        .posicionBar.Value = arr(1) / 1000
                        .reproducciones.reproductorMPEG.setPositionTo(arr(1))
                        .reproducciones.reproductorMPEG.pauseMovie()
                        .imgsPausa(True)



                    ElseIf arr(0) = "RADIO" Then
                        .PanelRadio.Visible = True
                        .reproducciones.reproducir("RADIO", arr(1))
                        .configuracionDeTipoMulti(Reproductor.RADIO)
                        .imgsRepro(True)


                    End If

                    .setSelectedIndex(.listaArchivos, asd(0))
                    .setSelectedIndex(.listaNombres, asd(1))
                    .setSelectedIndex(.ListaTunes, asd(2))

                    .estadoBarra = .infoSiguiente.Text

                End If
            End With
            objReader.Close()

        Catch es As Exception

            MsgBox("No se pudo cargar el estado anterior correctamente., " & es.Message, MsgBoxStyle.Exclamation, "Carga Del Reproductor")
            objReader.Close()
        End Try
    End Sub

    Public Function sacardatosDir(ByVal dir As String) As String()
        Dim sTodo As String
        Dim sPath As String
        Dim vNombre As String
        Dim vExt As String
        Dim bNombre As Boolean
        sTodo = dir
        Dim i As Integer

        bNombre = True
        vNombre = sTodo


        vExt = ""
        i = InStrRev(sTodo, ".")
        If i Then
            vExt = Mid$(sTodo, i + 1)
        End If


        sPath = ""
        'Asignar el path
        For i = Len(sTodo) To 1 Step -1
            If Mid$(sTodo, i, 1) = "\" Then
                sPath = Left$(sTodo, i - 1)
                'Si hay que devolver el nombre
                If bNombre Then
                    vNombre = Mid$(sTodo, i + 1)
                End If
                Exit For
            End If
        Next
        Dim ee As String() = {vNombre, vExt}

        Return ee
    End Function
    Function PrevInstance() As Boolean
        If UBound(Diagnostics.Process.GetProcessesByName(Diagnostics.Process.GetCurrentProcess.ProcessName)) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Module
