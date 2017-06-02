Option Explicit On
Imports Microsoft.WindowsAPICodePack.Shell
Imports Microsoft.WindowsAPICodePack.Taskbar
Imports System.IO
Imports System.Windows.Forms.ListView
Imports System.Threading
Imports Reproductor_3._0_DVD.BarraCarga

Public Class Principal
    'Location panel ctr completo 20, 378---- 21, 378
    ' panel ctr reucido 20, 41-----21, 40
    Public flagmax As Boolean = True

    Public plugins As New Plugins(Me)
    Public flagSlider As Boolean = False
    Public posSw As Integer = 0
    Public animPlayalt As Integer = 1

    Public estadoBarra As String = "Mini Media Player 3"
    Public alterBarra As Boolean = False
    Public vetaVideo As FormVideo
    Private x As Integer
    Private y As Integer
    Private mover As Boolean
    Public flagAdelanta As Boolean = False
    Public mensajepopup As String() = {"", ""}
    Public mensajemsn As String = ""
    Private botonThAnterior As ThumbnailToolbarButton
    Private botonThSiguiente As ThumbnailToolbarButton
    Private botonThReproPa As ThumbnailToolbarButton
    Private botonThParar As ThumbnailToolbarButton
    Public sleepCounter As Long = 15
    Public randomGenerator As New RandomSequence(1)
    Private muestraPaneles As Boolean() = {False, False, False, False, False, False, False, False}
    Dim ttlugar As New ToolTip
    Public path As String
    Private m_SortingColumn As ColumnHeader
    Public flagadelan As Boolean = False
    Private interVar As String
    Public dllg As New BarraCarga
    Public reproducciones As New Reproductor







    Public Function listaArchivosFilename() As String
        Try
            Return listaArchivos.Items(getSelectedIndex(listaArchivos)).SubItems(0).Text
        Catch ex As Exception

        End Try
        Return ""
    End Function


    Public Delegate Sub ListaArchivosAddItem(ByVal item As ListViewItem)
    Public Delegate Sub ListaArchivosEndUPD()
    Public Delegate Sub ListaArchivosBeginUPD()
    




    Public Sub updTotalTracks()
        totalCarpeta.Text = listaArchivos.Items.Count
    End Sub
    Public Sub cargarAchivosListaArch(ByVal dir As String, Optional ByVal noUpda As Boolean = False)

        Try
            path = dir
            dllg = New BarraCarga
            dllg.Left = Me.Left + 253
            dllg.Top = Me.Top + 35
            dllg.Show()
            If Not noUpda Then TreeDir.expandDir(dir)
            LabelDirectory.Text = dir
            listaArchivos.BeginUpdate()
            listaArchivos.Items.Clear()


            'dllg.Text = "Espere, Cargando Directorio"
            Dim d As New DirectoryInfo(path)


            dllg.inicializar(d.GetFiles.Length, "Buscando Archivos", "Preparando")
            Application.DoEvents()
            Dim isa As Integer = 0
            Dim reads As New Id3Reader

            For Each f As FileInfo In d.GetFiles

                Dim item As New ListViewItem(f.Name)
                Dim exts As String = f.Extension.ToLower

                If (exts = ".mp3" Or exts = ".wma" Or exts = ".m4a") Then
                    Try

                        Dim tgs As New Id3Reader.MP3(f.DirectoryName, f.Name)
                        reads.readMP3Tag(tgs)
                        item.SubItems.Add(tgs.id3Artist)
                        item.SubItems.Add(tgs.id3Title)
                        item.SubItems.Add(tgs.id3Album)
                        item.SubItems.Add(Val(tgs.id3Genre) & " - " & tgs.id3Year)


                    Catch ex As Exception

                    End Try

                    listaArchivos.Items.Add(item)

                ElseIf exts = ".wav" Or exts = ".ogg" Or exts = ".aac" Or exts = ".ac3" Or exts = ".flac" Then
                    'item.SubItems.Add(f.Length \ 1024 & " KB")
                    listaArchivos.Items.Add(item)


                ElseIf exts = ".avi" Or exts = ".mpg" Or exts = ".divx" Or exts = ".rm" Or exts = ".ogm" Or exts = ".avc" Or exts = ".flv" Or exts = ".mkv" Or exts = ".mp4" Or exts = ".m2ts" Then
                    'item.SubItems.Add(f.Length \ 1024 & " KB")
                    listaArchivos.Items.Add(item)
                End If
                If listaArchivos.Items.Count > 0 Then setSelectedIndex(listaArchivos, 0)



                dllg.cambiarValor(item.Text, isa)
                Application.DoEvents()
                isa = isa + 1



            Next
            listaArchivos.EndUpdate()
            updTotalTracks()
            dllg.diposeCmd()

        Catch ex As Exception
            dllg.diposeCmd()
            listaArchivos.EndUpdate()

        End Try

    End Sub


    Public Sub barraCargaLoad()
        dllg = New BarraCarga()
        dllg.Text = "Espere, Cargando Directorio"
        dllg.LblTit.Visible = False
        dllg.InfoProg.Visible = False
        dllg.Left = Me.Left + 253
        dllg.Top = Me.Top + 35
        dllg.ShowDialog()
    End Sub

    Public Function getSelectedIndex(ByVal listView As ListView) As Integer
        Try
            Return listView.SelectedItems(0).Index
        Catch ex As Exception
            Return -1
        End Try


    End Function
    Public Sub setSelectedIndex(ByVal listView As ListView, ByVal idx As Integer)
        Try
            listView.Items(idx).Selected = True
            listView.Items(idx).Focused = True
            listView.Refresh()
            listView.FocusedItem.EnsureVisible()

        Catch ex As Exception

        End Try
    End Sub


    Public Sub aumentarRedprincipal(ByVal aumentar As Boolean)

        If aumentar Then
            botonSobre.Visible = True
            botonCarpeta.Visible = True
            botonLista.Visible = True
            botonOpciones.Visible = True
            PanelCarpeta.Visible = muestraPaneles(0)
            PanelOpcion.Visible = muestraPaneles(1)
            PanelLista.Visible = muestraPaneles(2)
            PanelSobre.Visible = muestraPaneles(3)
            PanelDVD.Visible = muestraPaneles(4)
            PanelCDAudio.Visible = muestraPaneles(5)
            PanelRadio.Visible = muestraPaneles(6)
            PanelSleep.Visible = muestraPaneles(7)
            dspLugar.Visible = True

            'Me.Size = New Size(605, 508)
            resiseForm(605, 508)
            botonComp.BackgroundImage = My.Resources.btnComp
            flagmax = True
        Else
            muestraPaneles(0) = PanelCarpeta.Visible
            muestraPaneles(1) = PanelOpcion.Visible
            muestraPaneles(2) = PanelLista.Visible
            muestraPaneles(3) = PanelSobre.Visible
            muestraPaneles(4) = PanelDVD.Visible
            muestraPaneles(5) = PanelCDAudio.Visible
            muestraPaneles(6) = PanelRadio.Visible
            muestraPaneles(7) = PanelSleep.Visible

            botonSobre.Visible = False
            botonCarpeta.Visible = False
            botonLista.Visible = False
            botonOpciones.Visible = False
            PanelCarpeta.Visible = False
            PanelOpcion.Visible = False
            PanelLista.Visible = False
            PanelSobre.Visible = False
            dspLugar.Visible = False
            PanelDVD.Visible = False
            PanelCDAudio.Visible = False
            PanelRadio.Visible = False
            'Me.Size = New Size(605, 181)
            resiseForm(605, 181)
            botonComp.BackgroundImage = My.Resources.btnExp
            flagmax = False
        End If

    End Sub



    Private Sub botonParar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles botonParar.Click
        parar()
    End Sub

    Private Sub botonParar_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles botonParar.MouseEnter
        botonParar.BackgroundImage = My.Resources.btnPararMov
    End Sub

    Private Sub botonParar_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles botonParar.MouseLeave
        botonParar.BackgroundImage = My.Resources.btnParar
    End Sub

    Private Sub botonPausa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If reproducciones.reproductorMPEG.isMoviePlaying Then
            pausa()
        End If

    End Sub


    Private Sub botonRepro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles botonRepro.Click
        If reproducciones.reproductorMPEG.isMoviePlaying Then
            If AnimPau.Enabled Then
                proseguir()
                botonRepro.BackgroundImage = My.Resources.btnPauMov
            Else
                pausa()
                botonRepro.BackgroundImage = My.Resources.btnReproMov
            End If
        Else
            desicionReproduccion()
            botonRepro.BackgroundImage = My.Resources.btnPauMov
        End If

    End Sub

    Private Sub botonRepro_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles botonRepro.MouseEnter

        If reproducciones.reproductorMPEG.isMoviePlaying Then
            If AnimPau.Enabled Then

                botonRepro.BackgroundImage = My.Resources.btnReproMov

            Else

                botonRepro.BackgroundImage = My.Resources.btnPauMov
            End If

        Else

            botonRepro.BackgroundImage = My.Resources.btnReproMov
        End If


    End Sub

    Private Sub botonRepro_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles botonRepro.MouseLeave
        If reproducciones.reproductorMPEG.isMoviePlaying Then
            If AnimPau.Enabled Then

                botonRepro.BackgroundImage = My.Resources.btnRepro

            Else
                botonRepro.BackgroundImage = My.Resources.btnPau

            End If

        Else

            botonRepro.BackgroundImage = My.Resources.btnRepro
        End If
    End Sub

    Private Sub botonAnt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles botonAnt.Click
        irAnterior()
    End Sub

    Private Sub botonAnt_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles botonAnt.MouseEnter
        botonAnt.BackgroundImage = My.Resources.btnAntMov
    End Sub

    Private Sub botonAnt_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles botonAnt.MouseLeave
        botonAnt.BackgroundImage = My.Resources.btnAnt
    End Sub

    Private Sub botonSig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles botonSig.Click
        irSiguiente()
    End Sub

    Private Sub botonSig_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles botonSig.MouseEnter
        botonSig.BackgroundImage = My.Resources.btnSigMov
    End Sub

    Private Sub botonSig_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles botonSig.MouseLeave
        botonSig.BackgroundImage = My.Resources.btnSig
    End Sub

    Private Sub botonAbrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles botonAbrir.Click
        abrirar()
    End Sub

    Private Sub botonAbrir_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles botonAbrir.MouseEnter
        ttlugar.SetToolTip(botonAbrir, "Abrir Archivo")
        botonAbrir.BackgroundImage = My.Resources.btnAbrirMov
    End Sub

    Private Sub botonAbrir_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles botonAbrir.MouseLeave
        botonAbrir.BackgroundImage = My.Resources.btnAbrir
    End Sub

    Public Sub obligarLugar(ByVal lug As Integer, Optional ByVal borraal As Boolean = True)
        If lug = Reproductor.LISTA Then
            dspLugar.BackgroundImage = My.Resources.btnLugLis
            reproducciones.cambiarlugar(Reproductor.LISTA)
            ttlugar.SetToolTip(dspLugar, "Reproduciendo desde La Lista")
        Else
            dspLugar.BackgroundImage = My.Resources.btnLugCarp
            reproducciones.cambiarlugar(Reproductor.CARPETA)
            ttlugar.SetToolTip(dspLugar, "Reproduciendo desde La Carpeta")
        End If
        If borraal Then limpiarAleatorio()
    End Sub


    Private Sub botenModo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If reproducciones.darmodo = Reproductor.NORMAL Then
            dspModo.BackgroundImage = My.Resources.btnRepOnMov
            reproducciones.cambiarmodo(Reproductor.REPETIR)
            ttlugar.SetToolTip(dspModo, "Se Repetirá El Archivo En Reproducción")
        ElseIf reproducciones.darmodo = Reproductor.REPETIR Then
            dspModo.BackgroundImage = My.Resources.btnModoRepMov
            reproducciones.cambiarmodo(Reproductor.REPETODO)
            If reproducciones.darlugar = Reproductor.LISTA Then
                ttlugar.SetToolTip(dspModo, "Se Repetirá La Reproducción De Todos Los Archivos De La Lista")
            Else
                ttlugar.SetToolTip(dspModo, "Se Repetirá La Reproducción De Todos Los Archivos De La Carpeta")
            End If
        Else
            dspModo.BackgroundImage = My.Resources.btnRepOnMov
            reproducciones.cambiarmodo(Reproductor.NORMAL)
            ttlugar.SetToolTip(dspModo, "Reproducción Normal")
        End If
    End Sub
    Public Sub obligarModo(ByVal mods As Integer)
        If mods = Reproductor.REPETIR Then
            dspModo.BackgroundImage = My.Resources.btnModoRepUn
            reproducciones.cambiarmodo(Reproductor.REPETIR)
            ttlugar.SetToolTip(dspModo, "Se Repetirá El Archivo En Reproducción")
        ElseIf mods = Reproductor.REPETODO Then
            dspModo.BackgroundImage = My.Resources.btnModoRep
            reproducciones.cambiarmodo(Reproductor.REPETODO)
            If reproducciones.darlugar = Reproductor.LISTA Then
                ttlugar.SetToolTip(dspModo, "Se Repetirá La Reproducción De Todos Los Archivos De La Lista")
            Else
                ttlugar.SetToolTip(dspModo, "Se Repetirá La Reproducción De Todos Los Archivos De La Carpeta")
            End If
        Else
            dspModo.BackgroundImage = My.Resources.btnModoRepMov
            reproducciones.cambiarmodo(Reproductor.NORMAL)
            ttlugar.SetToolTip(dspModo, "Reproducción Normal")
        End If
    End Sub




    Private Sub botonOrden_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Public Sub obligarOrden(ByVal ord As Integer, Optional ByVal borraleat As Boolean = True)
        If ord = Reproductor.ORDEN_ALEATORIO Then
            dspOrden.BackgroundImage = My.Resources.btnOrden
            reproducciones.cambiarorden(Reproductor.ORDEN_ALEATORIO)
            ttlugar.SetToolTip(dspOrden, "Reproducción En Orden Aleatorio")
        Else
            dspOrden.BackgroundImage = My.Resources.btnOrdenMov
            reproducciones.cambiarorden(Reproductor.ORDEN_NORMAL)
            ttlugar.SetToolTip(dspOrden, "Reproducción En Orden Continuo")
        End If
        If borraleat Then limpiarAleatorio()
    End Sub




    Public Sub imgsPausa(Optional ByVal carga As Boolean = False)
        textotrack = New TextoMovil(panelDspTrac, dspTrac, AnimTrack)
        dspEsta.Visible = True
        AnimTipo.Enabled = True
        posicionBar.Enabled = False
        posicion.Enabled = False
        dspTipo.Visible = True
        AnimPau.Enabled = True
        dspTipo.Text = "Pausado"
        actualizarBotonesThumbTareas(False)

        'If reproducciones.sourceActivo = Reproductor.DVD Then
        '    dspTrac.Text = "DVD Video"
        'ElseIf reproducciones.sourceActivo = Reproductor.CDAUDIO Then
        '    dspTrac.Text = "CD De Audio"
        'Else

        '    dspTrac.Text = reproducciones.darNombrePista(True)
        'End If


        dspPos.Text = reproducciones.reproductorMPEG.getFormatPosition
        dspRem.Text = reproducciones.reproductorMPEG.getFormatRemeaning

        botonRepro.BackgroundImage = My.Resources.btnRepro
        dspEsta.Visible = True
        dspEsta.BackgroundImage = My.Resources.dspPause
        alterBarra = False
        AnimTitBarra.Enabled = False
        Me.Icon = My.Resources.icoInactivo
        Me.Text = "Pausado"

        iconoBarraAction("Accion", "Pausado", False)
        Try
            vetaVideo.PosBar.Enabled = False
        Catch ex As Exception

        End Try

        If carga = False Then

            plugins.SetMusicInfo(False, "")
        End If
    End Sub
    Public Sub imgsRepro(Optional ByVal carga As Boolean = False)
        textotrack = New TextoMovil(panelDspTrac, dspTrac, AnimTrack)
        dspTipo.Visible = True
        dspEsta.Visible = True
        AnimPau.Enabled = False
        posicionBar.Enabled = True
        AnimTipo.Enabled = False
        posicionBar.Enabled = True
        actualizarBotonesThumbTareas(True)
        dspPos.Visible = True
        dspRem.Visible = True
        posicionBar.Visible = True
        If reproducciones.sourceActivo = Reproductor.RADIO Then

            posicionBar.Enabled = False
            dspPos.Visible = False
            dspRem.Visible = False
            posicionBar.Visible = False
            infoSiguiente.Width = 226
            infoSiguiente.Height = 64
            dspTrac.Text = "Radio"
        ElseIf reproducciones.sourceActivo = Reproductor.DVD Then
            posicionBar.Maximum = reproducciones.dvdplayer.darTiempoTotalS
            posicionBar.Value = reproducciones.dvdplayer.darTiempoS
        Else
            posicionBar.Maximum = reproducciones.reproductorMPEG.getLengthInMS / 1000
            posicionBar.Value = reproducciones.reproductorMPEG.getPositionInMS / 1000
        End If

        posicion.Enabled = True
        If reproducciones.dartipo = Reproductor.VIDEO Then
            dspItipo.BackgroundImage = My.Resources.icoVideo
        Else
            dspItipo.BackgroundImage = My.Resources.icoAudio
        End If
        dspTipo.Text = ""


        If reproducciones.sourceActivo = Reproductor.DVD Then
            textotrack.setTexto("DVD Video")
        ElseIf reproducciones.sourceActivo = Reproductor.CDAUDIO Then
            textotrack.setTexto("CD De Audio")
        Else
            textotrack.setTexto(reproducciones.pistaid3)

        End If



        dspEsta.Visible = True

        botonRepro.BackgroundImage = My.Resources.btnPau
        'thumbImgTareas()
        dspEsta.BackgroundImage = My.Resources.dspPlay
        alterBarra = False
        AnimTitBarra.Enabled = True
        Me.Icon = My.Resources.icoActivo
        If estadoBarra = "" Then
            estadoBarra = infoSiguiente.Text
            Me.Text = estadoBarra
        Else
            Me.Text = estadoBarra
        End If

        Try
            vetaVideo.PosBar.Enabled = True
            vetaVideo.mostrarBarra()
        Catch ex As Exception

        End Try
        If reproducciones.sourceActivo = Reproductor.RADIO Then
            iconoBarraAction("Cargando Radio", reproducciones.darNombrePista(False), True)
        ElseIf reproducciones.sourceActivo = Reproductor.DVD Then
            iconoBarraAction("Reproduciendo DVD Video", reproducciones.darNombrePista(True), True)
        ElseIf reproducciones.sourceActivo = Reproductor.CDAUDIO Then
            iconoBarraAction("Reproduciendo CD De Audio", "Pista " & reproducciones.reproductorMPEG.getCDCurrentTrack & " De " & reproducciones.reproductorMPEG.GetNumTracks, True)
        Else
            If reproducciones.darlugar = Reproductor.CARPETA Then
                iconoBarraAction(estadoBarra & " desde la Carpeta", reproducciones.pistaid3, True)
            Else
                iconoBarraAction(estadoBarra & " desde la Lista", reproducciones.pistaid3, True)
            End If
        End If

        If carga = False Then

            mensajeMsnMostrar()
        End If

    End Sub
    Public Sub imgsParar(ByVal todo As Boolean)
        infoSiguiente.Width = 226
        infoSiguiente.Height = 17
        textotrack = New TextoMovil(panelDspTrac, dspTrac, AnimTrack)
        actualizarBotonesThumbTareas(False)
        dspTipo.Visible = True
        dspEsta.Visible = True

        posicionBar.Enabled = False
        posicionBar.Value = 0
        AnimPau.Enabled = False
        posicion.Enabled = False
        AnimTrack.Enabled = False
        dspPos.Text = ""
        dspRem.Text = ""
        dspItipo.BackgroundImage = Nothing
        Me.Icon = My.Resources.icoInactivo
        alterBarra = False
        AnimTitBarra.Enabled = False

        botonRepro.BackgroundImage = My.Resources.btnRepro
        If Not todo Then
            dspTipo.Text = "Parado"
            AnimTipo.Enabled = True
            Me.Text = "Parado"
            iconoBarraAction("Accion", "Parado", False)
        Else
            AnimTipo.Enabled = False
            dspTipo.Text = "Completo"
            Me.Text = "Todo Reproducido"
            iconoBarraAction("Accion", "Todo Reproducido", False)

        End If
        dspTrac.Text = ""
        dspEsta.Visible = True
        dspEsta.BackgroundImage = My.Resources.dspStop
        mensajeMsnMostrar()
    End Sub
    Public Sub imgsSiguiente()
        infoSiguiente.Width = 226
        infoSiguiente.Height = 17
        dspEsta.Visible = True
        dspTipo.Visible = True
        AnimPau.Enabled = False
        AnimTipo.Enabled = True
        posicionBar.Enabled = False
        AnimTrack.Enabled = False
        posicionBar.Value = 0
        posicion.Enabled = False
        dspPos.Text = ""
        dspRem.Text = ""
        dspTipo.Text = "Siguiente"
        AnimPas.Enabled = True
        dspTrac.Text = ""
        dspEsta.Visible = True
        dspEsta.BackgroundImage = My.Resources.dspNext
        alterBarra = False
        AnimTitBarra.Enabled = False
        Me.Icon = My.Resources.icoInactivo
        Me.Text = "Siguiente"
        iconoBarraAction("Accion", "Siguiente", False)
        'mensajeMsnMostrar()
    End Sub
    Public Sub imgsAnterior()
        infoSiguiente.Width = 226
        infoSiguiente.Height = 17
        dspTipo.Visible = True
        dspEsta.Visible = True
        posicionBar.Enabled = False
        posicionBar.Value = 0
        AnimTipo.Enabled = True
        AnimPau.Enabled = False
        AnimTrack.Enabled = False
        posicion.Enabled = False
        dspPos.Text = ""
        dspRem.Text = ""
        dspTipo.Text = "Anterior"
        AnimPas.Enabled = True
        dspTrac.Text = ""
        dspEsta.Visible = True
        dspEsta.BackgroundImage = My.Resources.dspPrev
        Me.Icon = My.Resources.icoInactivo
        alterBarra = False
        AnimTitBarra.Enabled = False
        Me.Text = "Anterior"
        iconoBarraAction("Accion", "Anterior", False)
        'mensajeMsnMostrar()
    End Sub
    Public Sub imgsCargando()
        infoSiguiente.Width = 226
        infoSiguiente.Height = 17
        dspTipo.Visible = True
        dspEsta.Visible = True
        posicionBar.Enabled = False
        dspItipo.BackgroundImage = Nothing
        posicionBar.Value = 0
        AnimTipo.Enabled = True
        AnimPau.Enabled = False
        posicion.Enabled = False
        AnimTrack.Enabled = False
        dspTipo.Text = "Cargando"
        dspPos.Text = ""
        dspRem.Text = ""
        dspTrac.Text = ""
        dspEsta.Visible = False
        dspEsta.BackgroundImage = My.Resources.dspNext
        alterBarra = False
        AnimTitBarra.Enabled = False
        Me.Icon = My.Resources.icoInactivo
        Me.Text = "Cargando"
        iconoBarraAction("Accion", "Cargando", False)
        'mensajeMsnMostrar()
    End Sub




    Public Sub desicionReproduccion()
        imgsCargando()
        delRepro.Enabled = True
    End Sub
    Public Sub desicionReproduccion2(Optional ByVal source As Integer = Reproductor.MPEG)
        adelantar(False, 0)
        parar()


        If source = Reproductor.RADIO Then
            Dim b As Boolean = reproducciones.reproducir("RADIO", ListaTunes.SelectedItems(0).SubItems(ListaTunes.Columns.Count - 1).Text)
            ' estadoBarra = "Reproduciendo Radio"
            'infoSiguiente.Text = estadoBarra
            'Name = ""
            'reproducciones.reproductorRadio.emisor = ""
            'reproducciones.reproductorRadio.bitrate = ""
            configuracionDeTipoMulti(Reproductor.RADIO)
            imgsRepro()

        ElseIf source = Reproductor.DVD Then

            Dim b As Boolean = reproducciones.reproducir("DVD")
            Try
                cargarInfoDVD()
                estadoBarra = "Reproduciendo DVD"

                infoSiguiente.Text = estadoBarra

                imgsRepro()
            Catch ex As Exception
                MsgBox("Error al intentar reproducir el DVD", MsgBoxStyle.Critical, "Error")
                imgsParar(False)
                Return
            End Try

            If b = False Then

                MsgBox("Error al intentar reproducir el DVD", MsgBoxStyle.Critical, "Error")
                imgsParar(False)
                Return
            End If

        ElseIf source = Reproductor.CDAUDIO Then

            Dim b As Boolean = reproducciones.reproducir("CDAUDIO")
            Try
                estadoBarra = "Reproduciendo CD De Audio"
                cargarInfoCDAudio()
                infoSiguiente.Text = estadoBarra
                imgsRepro()
            Catch ex As Exception
                MsgBox("Error al intentar reproducir el CD", MsgBoxStyle.Critical, "Error")
                imgsParar(False)
                Return
            End Try

            If b = False Then

                MsgBox("Error al intentar reproducir el CD", MsgBoxStyle.Critical, "Error")
                imgsParar(False)
                Return
            End If

        ElseIf reproducciones.darlugar = Reproductor.CARPETA Then


            Dim b As Boolean = reproducciones.reproducir(path & "\" & listaArchivosFilename())
            If b Then

                If reproducciones.darorden = Reproductor.NORMAL Then
                    estadoBarra = "Archivo " & getSelectedIndex(listaArchivos) + 1 & " de " & listaArchivos.Items.Count
                Else
                    estadoBarra = "Reproducidos " & randomGenerator._lastIndex & " de " & listaArchivos.Items.Count
                End If
                infoSiguiente.Text = estadoBarra
                imgsRepro()

            Else
                MsgBox("Error al intentar reproducir el archivo", MsgBoxStyle.Critical, "Error")
                imgsParar(False)
            End If
        Else
            Dim b As Boolean = False
            Try
                b = reproducciones.reproducir(listaNombres.SelectedItems(0).SubItems(listaNombres.Columns.Count - 1).Text)

            Catch ex As Exception
                MsgBox("Error al intentar reproducir el archivo", MsgBoxStyle.Critical, "Error")
                Return
            End Try
            If b Then

                If reproducciones.darorden = Reproductor.NORMAL Then
                    estadoBarra = "Archivo " & getSelectedIndex(listaNombres) + 1 & " de " & listaNombres.Items.Count
                Else
                    estadoBarra = "Reproducidos " & randomGenerator._lastIndex & " de " & listaNombres.Items.Count
                End If
                infoSiguiente.Text = estadoBarra
                imgsRepro()

            Else
                MsgBox("Error al intentar reproducir el archivo", MsgBoxStyle.Critical, "Error")
                imgsParar(False)
            End If

        End If
    End Sub
    Public Sub parar()
        reproducciones.parar()
        reproducciones.reproductorRadio.untune()
        borrarInfoDVD()
        borrarInfoCDAudio()
        configuracionDeTipoMulti(Reproductor.MPEG)
        reproducciones.sourceActivo = Reproductor.MPEG
        adelantar(False, 0)
        imgsParar(False)
    End Sub
    Public Sub pausa()
        If TimerAdelan.Enabled Then
            adelantar(False, 0)
        Else
            reproducciones.pausa()
            imgsPausa()
        End If


    End Sub
    Public Sub proseguir()

        reproducciones.proseg()
        adelantar(False, 0)
        imgsRepro()

    End Sub


    Private Sub posicion_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles posicion.Tick
        If Me.WindowState = FormWindowState.Normal Or Me.WindowState = FormWindowState.Maximized Then
            If reproducciones.sourceActivo = Reproductor.DVD Then
                dspPos.Text = reproducciones.dvdplayer.darTiempoFormato
                dspRem.Text = reproducciones.dvdplayer.darTiempoTotalFormato
                actualizarTitulosGraficosDVD()
                If flagSlider = False Then
                    posicionBar.Maximum = reproducciones.dvdplayer.darTiempoTotalS
                    posicionBar.Value = reproducciones.dvdplayer.darTiempoS
                    Try
                        vetaVideo.actualizarSlider()
                    Catch ex As Exception

                    End Try
                End If

            ElseIf reproducciones.sourceActivo = Reproductor.CDAUDIO Then
                If posSw = 0 Then
                    dspPos.Text = reproducciones.reproductorMPEG.getFormatPosition
                    dspRem.Text = reproducciones.reproductorMPEG.getFormatRemeaning
                ElseIf posSw = 1 Then
                    dspPos.Text = reproducciones.reproductorMPEG.getFormatPosition
                    dspRem.Text = reproducciones.reproductorMPEG.getFormatLength
                Else
                    dspPos.Text = reproducciones.reproductorMPEG.getFormatLength
                    dspRem.Text = reproducciones.reproductorMPEG.getFormatRemeaning
                End If

                If flagSlider = False Then
                    posicionBar.Value = reproducciones.reproductorMPEG.getPositionInMS / 1000
                End If
                infoSiguiente.Text = "Pista " & reproducciones.reproductorMPEG.getCDCurrentTrack & " De " & reproducciones.reproductorMPEG.GetNumTracks
                estadoBarra = infoSiguiente.Text
            ElseIf reproducciones.sourceActivo = Reproductor.MPEG Then

                If posSw = 0 Then
                    dspPos.Text = reproducciones.reproductorMPEG.getFormatPosition
                    dspRem.Text = reproducciones.reproductorMPEG.getFormatRemeaning
                ElseIf posSw = 1 Then
                    dspPos.Text = reproducciones.reproductorMPEG.getFormatPosition
                    dspRem.Text = reproducciones.reproductorMPEG.getFormatLength
                Else
                    dspPos.Text = reproducciones.reproductorMPEG.getFormatLength
                    dspRem.Text = reproducciones.reproductorMPEG.getFormatRemeaning
                End If

                If flagSlider = False Then
                    posicionBar.Value = reproducciones.reproductorMPEG.getPositionInMS / 1000
                End If
            End If
        End If
    End Sub

    Public Sub actualizarTitulosGraficosDVD()
        If reproducciones.dvdplayer.darTiempoTotalS < 5 And infoSiguiente.Text <> "Menu DVD" Then
            reproducciones.actualizarRotuloDVD()
            infoSiguiente.Text = "Menu DVD"
            dspTrac.Text = "DVD Video"
            vetaVideo.actualizarRotuloMenuDVD()

        ElseIf reproducciones.dvdplayer.darRorulo <> reproducciones.darNombrePista Then
            reproducciones.actualizarRotuloDVD()
            infoSiguiente.Text = reproducciones.dvdplayer.darUbicacion
            dspTrac.Text = "DVD Video"
            vetaVideo.actualizarPistaDVD()


        End If



    End Sub


    Private Sub volBar_ValueChanged(ByVal sender As System.Object, ByVal value As System.Decimal) Handles volBar.ValueChanged
        If reproducciones.sourceActivo = Reproductor.RADIO Then
            reproducciones.reproductorRadio.setvolum(volBar.Value * 10)
        End If
        reproducciones.reproductorMPEG.SetVolume(volBar.Value)


    End Sub
    Public Sub adelantardef()
        If reproducciones.reproductorMPEG.isMoviePlaying And AnimPau.Enabled = False And flagadelan = False Then

            adelantar(False, Reproductor.X4)
            imgAdelan()
            flagadelan = True
        End If
    End Sub

    Public Sub upsiguienteIntelig()
        If plugins.timepresss < 2 Then
            irSiguiente()
            Exit Sub
        End If
        pararadelantaciondef()
    End Sub
    Public Sub dnatrIntelig()
        If plugins.timepresss >= 2 Then
            atrazardef()
        End If
    End Sub
    Public Sub progresAdelan()
        If reproducciones.backwrd = True And reproducciones.fordwval <> 0 Then
            adelantar(False, 0)
        Else
            adelantarsw(False)
        End If
    End Sub
    Public Sub progresAtras()
        If reproducciones.backwrd = False And reproducciones.fordwval <> 0 Then
            adelantar(False, 0)
        Else
            adelantarsw(True)
        End If
    End Sub
    Public Sub upatrasIntelig()
        If plugins.timepresss < 2 Then
            irAnterior()
            Exit Sub
        End If
        pararadelantaciondef()
    End Sub
    Public Sub dnSigIntelig()
        If plugins.timepresss >= 2 Then
            adelantardef()
        End If
    End Sub

    Public Sub pararadelantaciondef()
        adelantar(False, 0)
        imgAdelan()
        flagadelan = False
    End Sub
    Public Sub atrazardef()
        If reproducciones.reproductorMPEG.isMoviePlaying And AnimPau.Enabled = False And flagadelan = False Then
            adelantar(True, Reproductor.X4)
            imgAdelan()
            flagadelan = True
        End If
    End Sub
    Private Sub posicionBar_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles posicionBar.MouseDown
        flagSlider = True
        adelantar(False, 0)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            reproducciones.cambiarClipini(posicionBar.Value * 1000)
        End If
    End Sub



    Private Sub posicionBar_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles posicionBar.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Left Then
            If reproducciones.sourceActivo = Reproductor.DVD Then
                reproducciones.dvdplayer.irAPosicionS(posicionBar.Value)

            Else
                reproducciones.reproductorMPEG.setPositionTo(posicionBar.Value * 1000)
            End If

        ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
            reproducciones.cambiarClipfin(posicionBar.Value * 1000)
        End If
        flagSlider = False
        If posicionBar.Enabled = True Then procesadorAutonomia(reproducciones.reproductorMPEG.getPositionInMS)
    End Sub


    Private Sub posicionBar_ValueChanged(ByVal sender As System.Object, ByVal value As System.Decimal) Handles posicionBar.ValueChanged

        If flagSlider = True Then
            dspTempor.Text = reproducciones.reproductorMPEG.getThisTime(posicionBar.Value * 1000)
        ElseIf reproducciones.isClipeado Then
            dspTempor.Text = "Cut"
            Try
                vetaVideo.clpIndic.Text = "Cut"
            Catch ex As Exception

            End Try
        ElseIf reproducciones.fordwval = 0 Then
            dspTempor.Text = ""
            Try
                vetaVideo.clpIndic.Text = ""
            Catch ex As Exception

            End Try
        End If

        If flagSlider = False And posicionBar.Enabled = True Then
            procesadorAutonomia(reproducciones.reproductorMPEG.getPositionInMS)

        End If



    End Sub


    Public Sub irSiguiente()

        On Error GoTo 1
        If reproducciones.sourceActivo = Reproductor.RADIO Then
            If getSelectedIndex(ListaTunes) + 1 = ListaTunes.Items.Count Then
                setSelectedIndex(ListaTunes, 0)
            Else
                setSelectedIndex(ListaTunes, getSelectedIndex(ListaTunes) + 1)
            End If
            desicionReproduccion2(Reproductor.RADIO)
            Return
        ElseIf reproducciones.sourceActivo = Reproductor.DVD Then
            reproducciones.dvdplayer.irSiguienteCapitulo()
        ElseIf reproducciones.sourceActivo = Reproductor.CDAUDIO Then
            reproducciones.reproductorMPEG.SeekCDtoX(reproducciones.reproductorMPEG.getCDCurrentTrack + 1)
        Else
            If reproducciones.darlugar = Reproductor.CARPETA Then
                If (reproducciones.darNombrePista = listaArchivosFilename() And reproducciones.reproductorMPEG.isMoviePlaying) Or (reproducciones.reproductorMPEG.isMoviePlaying = False) Then
                    If reproducciones.darorden = Reproductor.ORDEN_NORMAL Then
                        If getSelectedIndex(listaArchivos) < listaArchivos.Items.Count - 1 Then
                            setSelectedIndex(listaArchivos, getSelectedIndex(listaArchivos) + 1)
                        Else
                            setSelectedIndex(listaArchivos, 0)
                        End If
                    Else

                        randomProcesing()

                        'Aleatply(listaArchivos.Items.Count, path & "\" & listaArchivosFilename())
                    End If
                ElseIf reproducciones.darorden = Reproductor.ORDEN_ALEATORIO Then


                    randomProcesing()
                    'Aleatply(listaArchivos.Items.Count, path & "\" & listaArchivosFilename())

                End If
            Else
                If (reproducciones.darNombrePista = listaNombres.SelectedItems(0).Text And reproducciones.reproductorMPEG.isMoviePlaying) Or (reproducciones.reproductorMPEG.isMoviePlaying = False) Then
                    If reproducciones.darorden = Reproductor.ORDEN_NORMAL Then
                        If getSelectedIndex(listaNombres) < listaNombres.Items.Count - 1 Then

                            setSelectedIndex(listaNombres, getSelectedIndex(listaNombres) + 1)
                        Else
                            setSelectedIndex(listaNombres, 0)
                        End If
                    Else


                        randomProcesing()
                        'Aleatply(listaNombres.Items.Count, listaNombres.SelectedItems(0).SubItems(listaNombres.Columns.Count - 1).Text)
                    End If
                ElseIf reproducciones.darorden = Reproductor.ORDEN_ALEATORIO Then

                    randomProcesing()
                    'Aleatply(listaNombres.Items.Count, listaNombres.SelectedItems(0).SubItems(listaNombres.Columns.Count - 1).Text)
                End If
            End If


            If reproducciones.reproductorMPEG.isMoviePlaying = True Then
                desicionReproduccion()
                Exit Sub
            Else
                imgsSiguiente()
            End If
            'img faltante
            Exit Sub
        End If
1:
    End Sub
    Public Function randomProcesing() As Integer

        Dim fgh As Integer = randomGenerator.NextValue
        If fgh = -1 Then
            limpiarAleatorio()
            Return -1
        Else
            If reproducciones.darlugar = Reproductor.CARPETA Then
                setSelectedIndex(listaArchivos, fgh)
            Else
                setSelectedIndex(listaNombres, fgh)
            End If
            Return 0
        End If

    End Function
    Public Sub irAnterior()
        On Error GoTo 1
        If reproducciones.sourceActivo = Reproductor.RADIO Then
            If getSelectedIndex(ListaTunes) = 0 Then
                setSelectedIndex(ListaTunes, ListaTunes.Items.Count - 1)
            Else
                setSelectedIndex(ListaTunes, getSelectedIndex(ListaTunes) - 1)
            End If
            desicionReproduccion2(Reproductor.RADIO)
            Return
        ElseIf reproducciones.sourceActivo = Reproductor.DVD Then

            reproducciones.dvdplayer.irAnteriorCapitulo()
        ElseIf reproducciones.sourceActivo = Reproductor.CDAUDIO Then
            reproducciones.reproductorMPEG.SeekCDtoX(reproducciones.reproductorMPEG.getCDCurrentTrack - 1)
        Else
            If reproducciones.darlugar = Reproductor.CARPETA Then
                If (reproducciones.darNombrePista = listaArchivosFilename() And reproducciones.reproductorMPEG.isMoviePlaying) Or (reproducciones.reproductorMPEG.isMoviePlaying = False) Then
                    If getSelectedIndex(listaArchivos) > 0 Then
                        setSelectedIndex(listaArchivos, getSelectedIndex(listaArchivos) - 1)
                    Else
                        setSelectedIndex(listaArchivos, listaArchivos.Items.Count - 1)
                    End If
                End If
            Else
                If (reproducciones.darNombrePista = listaNombres.SelectedItems(0).Text And reproducciones.reproductorMPEG.isMoviePlaying) Or (reproducciones.reproductorMPEG.isMoviePlaying = False) Then
                    If getSelectedIndex(listaNombres) > 0 Then

                        setSelectedIndex(listaNombres, getSelectedIndex(listaNombres) - 1)
                    Else

                        setSelectedIndex(listaNombres, getSelectedIndex(listaNombres) - 1)
                    End If
                End If
            End If

            If reproducciones.reproductorMPEG.isMoviePlaying = True Then
                desicionReproduccion()
                Exit Sub
            Else
                imgsAnterior()
            End If
            Exit Sub
        End If
1:
    End Sub
    Public Sub volEnable(ByVal enable As Boolean)
        volBar.Enabled = enable
    End Sub
    Public Sub mutEnable(ByVal enable As Boolean)
        If enable Then
            BtnMute.Enabled = True
        Else
            'muteobl(False)
            BtnMute.Enabled = False
        End If
    End Sub
    Public Sub modEnable(ByVal enable As Boolean)
        'obligarModo(Reproductor.NORMAL)
        dspModo.Enabled = enable
    End Sub
    Public Sub ordenarEnable(ByVal enable As Boolean)
        dspOrden.Enabled = enable

        'If enable = False Then
        '    obligarOrden(Reproductor.ORDEN_NORMAL)
        '    limpiarAleatorio()
        'End If

    End Sub

    Public Sub configuracionDeTipoMulti(ByVal tipo As Integer)
        If reproducciones.sourceActivo = Reproductor.RADIO Then
            modEnable(False)
            mutEnable(True)
            volEnable(True)
            ordenarEnable(False)
        ElseIf tipo = Reproductor.DVD Then
            modEnable(False)
            mutEnable(False)
            volEnable(False)
            ordenarEnable(False)
        ElseIf tipo = Reproductor.CDAUDIO Then
            modEnable(True)
            mutEnable(True)
            volEnable(False)
            ordenarEnable(False)
        Else
            modEnable(True)
            mutEnable(True)
            volEnable(True)
            ordenarEnable(True)
        End If
    End Sub
    Public Sub procesadorAutonomia(ByVal posms As Long)
        If reproducciones.sourceActivo = Reproductor.DVD Then
        ElseIf reproducciones.sourceActivo = Reproductor.CDAUDIO And posms >= reproducciones.reproductorMPEG.getLengthInMS - 1000 Then
            If reproducciones.darmodo = Reproductor.REPETIR Or reproducciones.darmodo = Reproductor.REPETODO Then
                reproducciones.reproductorMPEG.SeekCDtoX(1)
                imgsRepro()
            Else
                parar()
                imgsParar(True)

            End If
        Else

            Try

                If posms >= reproducciones.reproductorMPEG.getLengthInMS - 1000 Or (posms >= reproducciones.darclipfin - 1000 And reproducciones.isClipeado) Then

                    If reproducciones.darmodo = Reproductor.REPETIR Then
                        reproducciones.reproductorMPEG.restartMovie()
                        imgsRepro()
                    ElseIf reproducciones.darmodo = Reproductor.NORMAL Then

                        If reproducciones.darorden = Reproductor.ORDEN_ALEATORIO Then
                            If randomGenerator._lastIndex < randomGenerator._maxValue Then
                                irSiguiente()
                            Else
                                parar()
                                imgsParar(True)
                                limpiarAleatorio()
                            End If

                        Else

                            If reproducciones.darlugar = Reproductor.CARPETA Then
                                If getSelectedIndex(listaArchivos) >= listaArchivos.Items.Count - 1 And path & "\" & listaArchivosFilename() = reproducciones.reproductorMPEG.Filename And reproducciones.darorden = Reproductor.ORDEN_NORMAL Then
                                    parar()
                                    imgsParar(True)
                                Else
                                    irSiguiente()
                                End If
                            ElseIf reproducciones.darlugar = Reproductor.LISTA Then
                                If getSelectedIndex(listaNombres) >= listaNombres.Items.Count - 1 And listaNombres.SelectedItems(0).SubItems(listaNombres.Columns.Count - 1).Text = reproducciones.reproductorMPEG.Filename And reproducciones.darorden = Reproductor.ORDEN_NORMAL Then
                                    parar()
                                    imgsParar(True)
                                Else
                                    irSiguiente()
                                End If
                            End If
                        End If
                    ElseIf reproducciones.darmodo = Reproductor.REPETODO Then
                        irSiguiente()
                    End If
                End If

            Catch ex As Exception
                MsgBox("Error en el procesador de los archivos", MsgBoxStyle.Critical, "Error Fatal")
            End Try
        End If


    End Sub

    Private Sub AnimPau_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnimPau.Tick
        If Me.WindowState = FormWindowState.Normal Or Me.WindowState = FormWindowState.Maximized Then
            If dspEsta.Visible = True Then
                dspEsta.Visible = False
                Try
                    vetaVideo.textMovil.Enabled = False
                    vetaVideo.txtpista.center()
                    vetaVideo.TxtEsta.Text = ""
                Catch ex As Exception

                End Try
            Else
                dspEsta.Visible = True
                Try
                    vetaVideo.textMovil.Enabled = False
                    vetaVideo.txtpista.center()
                    vetaVideo.TxtEsta.Text = "I I"
                Catch ex As Exception

                End Try

            End If
        End If
    End Sub

    Private Sub AnimTipo_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnimTipo.Tick

        dspTipo.Visible = False
        AnimTipo.Enabled = False
    End Sub

    Private Sub botonCarpeta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles botonCarpeta.Click

        If PanelCarpeta.Visible Then
            PanelCarpeta.Visible = False
        Else
            PanelCarpeta.Visible = True
            PanelOpcion.Visible = False
            PanelLista.Visible = False
            PanelSobre.Visible = False
            PanelDVD.Visible = False
            PanelCDAudio.Visible = False
            PanelRadio.Visible = False
            PanelSleep.Visible = False
        End If
    End Sub

    Private Sub botonLista_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles botonLista.Click

        If PanelLista.Visible Then
            PanelLista.Visible = False
        Else
            PanelLista.Visible = True
            PanelCarpeta.Visible = False
            PanelOpcion.Visible = False
            PanelSobre.Visible = False
            PanelDVD.Visible = False
            PanelCDAudio.Visible = False
            PanelRadio.Visible = False
            PanelSleep.Visible = False
        End If
    End Sub

    Private Sub botonOpciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles botonOpciones.Click

        If PanelOpcion.Visible Then

            PanelOpcion.Visible = False
        Else
            PanelLista.Visible = False
            PanelCarpeta.Visible = False
            PanelOpcion.Visible = True
            PanelSobre.Visible = False
            PanelDVD.Visible = False
            PanelCDAudio.Visible = False
            PanelRadio.Visible = False
            PanelSleep.Visible = False
        End If
    End Sub

    Private Sub botonSobre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles botonSobre.Click

        If PanelSobre.Visible Then
            PanelSobre.Visible = False
        Else
            PanelLista.Visible = False
            PanelCarpeta.Visible = False
            PanelOpcion.Visible = False
            PanelSobre.Visible = True
            PanelDVD.Visible = False
            PanelCDAudio.Visible = False
            PanelRadio.Visible = False
            PanelSleep.Visible = False
        End If
    End Sub

    Private Sub Principal_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        PanelCarpeta.Visible = False
        PanelLista.Visible = False
    End Sub



    Private Sub Principal_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim MyFiles() As String

            MyFiles = e.Data.GetData(DataFormats.FileDrop)
            If MyFiles.Length = 1 Then
                abrirsolo(MyFiles(0))
            ElseIf MyFiles.Length > 1 Then
                abrirMultiples(MyFiles)

            End If

        End If
    End Sub

    Public Sub abrirMultiples(ByVal archs As String(), Optional ByVal soloagregar As Boolean = False)
        Dim listavacia As Boolean = False
        If listaNombres.Items.Count <= 0 Then listavacia = True
        dllg = New BarraCarga()
        dllg.Text = "Espere, Cargando Lista"
        dllg.Left = Me.Left + 253
        dllg.Top = Me.Top + 35
        dllg.inicializar(archs.Length, "Creando Lista", "Preparando")
        dllg.Show()
        Application.DoEvents()
        For i As Integer = 0 To archs.Length - 1
            agregaralista(archs(i), sacardatosDir(archs(i))(0))
            dllg.cambiarValor(archs(i), i + 1)
            eventoDeListaActualizar()

            Application.DoEvents()
        Next
        dllg.Dispose()
        If listavacia Then


            setSelectedIndex(listaNombres, 0)

            If soloagregar = False Then
                obligarLugar(Reproductor.LISTA)
                desicionReproduccion()
            End If

            PanelLista.Visible = True
            PanelCarpeta.Visible = False
            PanelOpcion.Visible = False
            PanelSobre.Visible = False
        End If
    End Sub


    Private Sub Principal_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Move
        End If
    End Sub

    Private Sub Principal_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        cerrar()
    End Sub

    Private Sub Principal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

    End Sub



    Public Sub thumbImgTareas()
        If TaskbarManager.IsPlatformSupported Then

            TaskbarManager.Instance.TabbedThumbnail.SetThumbnailClip(Me.Handle, New Rectangle(New Point(251, 29), New Size(276, 117)))

        End If
    End Sub
    Public Sub initBotonesThumbTareas()

        If TaskbarManager.IsPlatformSupported Then
            botonThAnterior = New ThumbnailToolbarButton(My.Resources.thAnt, "Anterior")
            botonThAnterior.Enabled = True
            AddHandler botonThAnterior.Click, AddressOf botonThAnterior_Click

            botonThReproPa = New ThumbnailToolbarButton(My.Resources.thRepro, "Reproducir/Pausa")
            botonThReproPa.Enabled = True
            AddHandler botonThReproPa.Click, AddressOf botonThReproPa_Click

            botonThSiguiente = New ThumbnailToolbarButton(My.Resources.thSig, "Siguiente")
            botonThSiguiente.Enabled = True
            AddHandler botonThSiguiente.Click, AddressOf botonThSiguiente_Click

            botonThParar = New ThumbnailToolbarButton(My.Resources.thParar, "Parar")
            botonThParar.Enabled = True
            AddHandler botonThParar.Click, AddressOf botonThParar_Click


            TaskbarManager.Instance.ThumbnailToolbars.AddButtons(Me.Handle, botonThAnterior, botonThParar, botonThReproPa, botonThSiguiente)
        End If
    End Sub
    Private Sub botonThAnterior_Click()
        irAnterior()
    End Sub
    Private Sub botonThReproPa_Click()
        If reproducciones.reproductorMPEG.isMoviePlaying Then
            If AnimPau.Enabled Then

                proseguir()
            Else
                pausa()
            End If

        Else
            desicionReproduccion()
        End If
    End Sub
    Private Sub botonThSiguiente_Click()
        irSiguiente()
    End Sub
    Private Sub botonThParar_Click()
        parar()
    End Sub

    Public Sub actualizarBotonesThumbTareas(ByVal pausa As Boolean)
        If TaskbarManager.IsPlatformSupported Then
            Try
                If pausa Then
                    botonThReproPa.Icon = My.Resources.thPau
                    botonThReproPa.Tooltip = "Pausar"
                Else
                    botonThReproPa.Icon = My.Resources.thRepro
                    botonThReproPa.Tooltip = "Reproducir"

                End If

            Catch ss As Exception
            End Try
        End If
    End Sub

    Private Sub comboUnidades_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub


    Private Sub comboUnidades_SelectedIndexChanged_2(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo 6
        'comboLista.Path = comboUnidades.Drive
        Exit Sub
6:
        'MsgBox("No Hay dispositivo en " & comboUnidades.Drive, vbExclamation, "Error de dispositivo")
    End Sub

    Private Sub comboLista_Change(ByVal sender As Object, ByVal e As System.EventArgs)
        'cargarAchivosListaArch(comboLista.Path)
    End Sub

    Private Sub listaArchivos_MouseClick1(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        'ttlugar.SetToolTip(listaArchivos, listaArchivosFilename())
    End Sub


    'Public Sub Aleatply(ByVal tott As Integer, ByVal fname As String)


    '    '        Dim at As Integer
    '    '        Dim e As Boolean
    '    '        e = False

    '    '        For i As Integer = 0 To (rndLst.Items.Count - 1) Step 1
    '    '            'MsgBox("pos " & i & "coun " & reproducciones.rndPl.Count - 1)
    '    '            rndLst.SelectedIndex = i
    '    '            If rndLst.Text = reproducciones.repr.Filename Then
    '    '                e = True
    '    '                Exit For
    '    '            End If
    '    '        Next

    '    '        If e = False Then rndLst.Items.Add(reproducciones.repr.Filename)



    '    '        If rndLst.Items.Count = tott Or tott = 0 Then
    '    '            parar()
    '    '            imgsParar(True)
    '    '            limpiarAleatorio()
    '    '            Exit Sub
    '    '        End If


    '    '        at = Int(Rnd() * tott)

    '    '        If reproducciones.darlugar = Reproductor.CARPETA Then
    '    '            setSelectedIndex(listaArchivos, at)

    '    '        Else

    '    '            setSelectedIndex(listaNombres, at)

    '    '        End If





    '    '2:
    '    '        e = False
    '    '        For j As Integer = 0 To (rndLst.Items.Count - 1) Step 1
    '    '            rndLst.SelectedIndex = j
    '    '            If rndLst.Text = fname Then
    '    '                e = True
    '    '                Exit For
    '    '            End If
    '    '        Next

    '    '        If e Then
    '    '            If reproducciones.darlugar = Reproductor.CARPETA Then
    '    '                If getSelectedIndex(listaArchivos) < listaArchivos.Items.Count - 1 Then
    '    '                    setSelectedIndex(listaArchivos, getSelectedIndex(listaArchivos) + 1)
    '    '                Else
    '    '                    setSelectedIndex(listaArchivos, 0)
    '    '                End If
    '    '                fname = path & "\" & listaArchivosFilename()
    '    '            Else
    '    '                If getSelectedIndex(listaNombres) < listaNombres.Items.Count - 1 Then

    '    '                    setSelectedIndex(listaNombres, getSelectedIndex(listaNombres) + 1)
    '    '                Else

    '    '                    setSelectedIndex(listaNombres, 0)
    '    '                End If
    '    '                fname = listaNombres.SelectedItems(0).SubItems(listaNombres.Columns.Count - 1).Text
    '    '            End If
    '    '            GoTo 2
    '    '        End If

    'End Sub
    Public Sub limpiarAleatorio()
        activarRnd()
    End Sub

    Public Function CargarM3U(ByVal strFileName As String, ByRef strFilePathss() As String, ByRef strNamess() As String) As Boolean


        Try
            'Declare variables
            Dim lngFileNo As Long
            Dim strTemp As String
            Dim i As Long
            Dim strLines() As String
            Dim lngLines As Long
            Dim strM3ULoc As String
            Dim err As Boolean = False



            'Check if file exists
            If Dir(strFileName) <> "" Then

                Try
                    strM3ULoc = System.IO.Path.GetDirectoryName(strFileName)

                Catch ex As Exception

                End Try
               


                'Get new file number
                lngFileNo = FreeFile()

                'Open the file
                Dim objReader As System.IO.StreamReader

                objReader = IO.File.OpenText(strFileName)


                strTemp = objReader.ReadToEnd


                objReader.Close()


                'Split the file into it's lines
                strLines = Split(strTemp, vbCrLf)

                'Check that this file has enough lines
                If UBound(strLines) > 2 Then

                    'Check that it's an M3U file
                    If strLines(0) = "#EXTM3U" Then

                        'Get number of lines
                        lngLines = UBound(strLines)

                        'Attention! If you have any errors over the next 2 lines then you need to make sure
                        'that you have declared the array variables without specifying their size,
                        'because here we're changing their sizes to match.  - Thanks
                        Dim strFilePaths As New List(Of String)
                        Dim strNames As New List(Of String)

                        'Loop through each line
                        For i = 1 To lngLines

                            'Check what kind of data we've got
                            If Strings.Left(strLines(i), 7) = "#EXTINF" Then

                                'File name & length (but we don't return that). Get file name
                                strNames.Add(Strings.Right(strLines(i), Len(strLines(i)) - InStr(1, strLines(i), ",")))

                            ElseIf strLines(i) <> "" Then
                                'File path. Verify the path
                                If strLines(i).Substring(0, 4).ToLower = "http" Then
                                    strFilePaths.Add(strLines(i).Trim)
                                ElseIf Dir(strLines(i)) <> "" Then
                                    'Pure path, including drive letter
                                    strFilePaths.Add(strLines(i))
                                ElseIf Dir(strM3ULoc & strLines(i)) <> "" Then
                                    'Adding onto the M3U's path (most common)
                                    strFilePaths.Add(strM3ULoc & strLines(i))
                                ElseIf Dir(Strings.Left(strM3ULoc, 3) & strLines(i)) <> "" Then
                                    'Adding onto the M3U's drive only
                                    strFilePaths.Add(Strings.Left(strM3ULoc, 3) & strLines(i))

                                Else
                                    'Display error message
                                    err = True
                                End If
                            End If
                                ' MsgBox(strFilePaths((i / 2) - 1))
                        Next i

                        'Set return value to true

                        strFilePathss = strFilePaths.ToArray
                        strNamess = strNames.ToArray
                        If err Then
                            Call MsgBox("La lista no se cargó correctamente (archivos perdidos).", vbExclamation, "Error while loading a file!")

                        End If
                        Return True

                    End If

                Else
                    'Return error
                    Return False
                End If

            Else
                'Return error
                Return False
            End If

            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try




    End Function


    Public Sub guardaLista()

        If listaNombres.Items.Count = 0 Then
            MsgBox("No hay archivos en la Lista.", MsgBoxStyle.Information, "Mini Media Player")
            Exit Sub
        End If



        DialogoGuardar.InitialDirectory = Application.StartupPath
        DialogoGuardar.Filter = "Lista De Reproduccion (*.m3u)|*.m3u"
        DialogoGuardar.ShowDialog()


        If DialogoGuardar.FileName <> Nothing And listaNombres.Items.Count > 0 Then
            GuardarM3U(DialogoGuardar.FileName, listaNombres.Items, 5, 0)
        End If






    End Sub

    Public Function GuardarM3U(ByVal filename As String, ByVal items As ListViewItemCollection, ByVal idxdir As Integer, ByVal idxname As Integer) As Boolean
        Dim oSW As New IO.StreamWriter(filename)
        oSW.WriteLine("#EXTM3U")
        For i = 0 To items.Count - 1
            oSW.WriteLine("#EXTINF:" & items.Item(i).SubItems.Item(idxname).Text)
            If (items.Item(i).SubItems.Item(idxdir).Text).Substring(0, 4).ToLower = "http" Then
                oSW.WriteLine(items.Item(i).SubItems.Item(idxdir).Text)
            Else
                Try
                    oSW.WriteLine(MakeRelativePath(System.IO.Path.GetDirectoryName(filename), items.Item(i).SubItems.Item(idxdir).Text))
                Catch ex As Exception
                    oSW.WriteLine(items.Item(i).SubItems.Item(idxdir).Text)
                End Try
            End If

           

        Next
        oSW.Flush()
        oSW.Close()
    End Function
    Private Function MakeRelativePath(ByVal fromPath As [String], ByVal toPath As [String]) As [String]
        If [String].IsNullOrEmpty(fromPath) Then
            Throw New ArgumentNullException("fromPath")
        End If
        If [String].IsNullOrEmpty(toPath) Then
            Throw New ArgumentNullException("toPath")
        End If

        Dim fromUri As New Uri(fromPath)
        Dim toUri As New Uri(toPath)

        Dim relativeUri As Uri = fromUri.MakeRelativeUri(toUri)
        Dim relativePath As [String] = Uri.UnescapeDataString(relativeUri.ToString())

        Return relativePath.Replace("/"c, System.IO.Path.DirectorySeparatorChar)
    End Function



    Public Sub openpl()
        DialogoAbrir.InitialDirectory = Application.StartupPath
        DialogoAbrir.Filter = "Lista de Reproduccion (*.m3u)|*.m3u"
        DialogoAbrir.Multiselect = False

        If DialogoAbrir.ShowDialog = Windows.Forms.DialogResult.OK Then





            Dim dirs() As String
            Dim names() As String

            If CargarM3U(DialogoAbrir.FileName, dirs, names) Then

                Dim anad As Integer = MsgBox("Desea añadir esta lista a la lista de reproduccion actual?", MsgBoxStyle.YesNo, "Mini Media Player")
                If anad = vbYes Then
                    abrirMultiples(dirs, True)
                    eventoDeListaActualizar()
                Else
                    listaNombres.Items.Clear()
                    eventoDeListaActualizar()
                    abrirMultiples(dirs)
                End If
            Else
                MsgBox("Error al abrir Lista", MsgBoxStyle.Exclamation, "Mini Media Player")

            End If

        End If
    End Sub

    Private Sub abrirLista_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles abrirLista.Click
        openpl()
    End Sub

    Private Sub guardarLista_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles guardarLista.Click
        guardaLista()
    End Sub

    Private Sub borrarSellista_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles borrarSellista.Click
        Try
            Dim tmp As Integer = 0
            tmp = getSelectedIndex(listaNombres)
            listaNombres.Items.RemoveAt(getSelectedIndex(listaNombres))
            setSelectedIndex(listaNombres, tmp - 1)
        Catch ex As Exception
            setSelectedIndex(listaNombres, 0)
        End Try
        eventoDeListaActualizar()
    End Sub

    Private Sub borrarTodoLista_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles borrarTodoLista.Click

        Dim anad As Integer = MsgBox("Desea Borrar todos los elementos de la lista?", MsgBoxStyle.YesNo, "Mini Media Player")
        If anad = vbYes Then
            listaNombres.BeginUpdate()
            listaNombres.Items.Clear()
            listaNombres.EndUpdate()
            eventoDeListaActualizar()
        End If

    End Sub





    Public Sub eventoDeListaActualizar()
        If reproducciones.darlugar = Reproductor.LISTA Then limpiarAleatorio()
        totalesLista.Text = listaNombres.Items.Count
    End Sub
    Public Sub anadirTodoALista()
        Dim idxanta As Integer = getSelectedIndex(listaArchivos)
        Dim idxantb As Integer = getSelectedIndex(listaNombres)
        Dim itms As ListViewItemCollection = listaArchivos.Items
        dllg = New BarraCarga
        dllg.Text = "Espere, Copiendo Directorio a Lista"
        dllg.Left = Me.Left + 253
        dllg.Top = Me.Top + 35
        dllg.inicializar(itms.Count, "Agregando Archivos", "Preparando")
        dllg.Show()
        Application.DoEvents()
        For i As Integer = 0 To itms.Count - 1
            agregaralista(path & "\" & itms(i).SubItems(0).Text, itms(i).SubItems(0).Text)
            dllg.cambiarValor(itms(i).SubItems(0).Text, i + 1)
            eventoDeListaActualizar()
            Application.DoEvents()
        Next
        dllg.diposeCmd()
        setSelectedIndex(listaArchivos, idxanta)
        setSelectedIndex(listaNombres, idxantb)
        MsgBox("La carpeta actual fue agregada a la lista", MsgBoxStyle.Information, "Lista")


    End Sub

    Private Sub añadeTodoCarpeta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles añadeTodoCarpeta.Click
        anadirTodoALista()
    End Sub
    Private Sub anadelista()

        DialogoAbrir.InitialDirectory = path
        DialogoAbrir.Filter = "MPEG audio layer 3 (.mp3)|*.mp3|Windows media audio (.wma)|*.wma|Wave audio (.wav)|*.wav|Vorbis Audio (.ogg)|*.ogg|AAC Audio (.aac)|*.aac|AC3 audio (.ac3)|*.ac3|Video for windows (.avi)|*.avi|MPEG Video (.mpg)|*.mpg|Divx Video (.divx)|*.divx|Real media (.rm)|*.rm|Vorbis media container (.ogm)|*.ogm|MPEG 4 Video (.avc)|*.avc|Flash video (.flv)|*.flv|Matroska container (.mkv)|*.mkv|Mpeg 4 (.mp4)|*.mp4"
        DialogoAbrir.Multiselect = True
        Try
            If DialogoAbrir.ShowDialog = Windows.Forms.DialogResult.OK Then

                Dim tmp As String()
                tmp = DialogoAbrir.FileNames
                abrirMultiples(tmp, True)
            End If


        Catch e As Exception
            MsgBox(e.Message)
            Exit Sub
        End Try
    End Sub
    Private Sub abrirar()
        DialogoAbrir.InitialDirectory = path
        DialogoAbrir.Filter = "MPEG audio layer 3 (.mp3)|*.mp3|Windows media audio (.wma)|*.wma|Wave audio (.wav)|*.wav|Vorbis Audio (.ogg)|*.ogg|AAC Audio (.aac)|*.aac|AC3 audio (.ac3)|*.ac3|Video for windows (.avi)|*.avi|MPEG Video (.mpg)|*.mpg|Divx Video (.divx)|*.divx|Real media (.rm)|*.rm|Vorbis media container (.ogm)|*.ogm|MPEG 4 Video (.avc)|*.avc|Flash video (.flv)|*.flv|Matroska container (.mkv)|*.mkv|Mpeg 4 (.mp4)|*.mp4"
        DialogoAbrir.Multiselect = True
        Try
            If DialogoAbrir.ShowDialog = Windows.Forms.DialogResult.OK Then

                Dim tmp As String()
                tmp = DialogoAbrir.FileNames

                If tmp.Length = 1 Then
                    abrirsolo(tmp(0))
                ElseIf tmp.Length > 1 Then
                    abrirMultiples(tmp)

                End If
            End If


        Catch e As Exception
            MsgBox(e.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub delRepro_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles delRepro.Tick
        delRepro.Enabled = False
        desicionReproduccion2()
    End Sub
    Public Function agregaralista(ByVal dirn As String, ByVal nom As String) As Boolean
        Dim lidx As Integer = getSelectedIndex(listaNombres)
        Dim items As ListViewItemCollection = listaNombres.Items()
        For i As Integer = 0 To items.Count - 1
            Try

                If items(i).SubItems(listaNombres.Columns.Count - 1).Text = dirn Then
                    setSelectedIndex(listaNombres, lidx)
                    MsgBox("El Archivo " & nom & " ya esta en la lista", MsgBoxStyle.Exclamation, "Lista")
                    Return False
                End If
            Catch ex As Exception

            End Try

        Next
        Dim item As ListViewItem
        Dim reads As New Id3Reader
        Try
            Dim f As New FileInfo(dirn)
            item = New ListViewItem(f.Name)

            If (f.Extension = ".mp3" Or f.Extension = ".wma" Or f.Extension = ".MP3" Or f.Extension = ".WMA" Or f.Extension = ".M4a" Or f.Extension = ".m4a") Then
                Try

                    'If f.Length < 20971520 Then
                    Dim tgs As New Id3Reader.MP3(f.DirectoryName, f.Name)
                    reads.readMP3Tag(tgs)

                    item.SubItems.Add(tgs.id3Artist)
                    item.SubItems.Add(tgs.id3Title)
                    item.SubItems.Add(tgs.id3Album)
                    item.SubItems.Add(tgs.id3Genre & " - " & tgs.id3Year)
                    item.SubItems.Add(f.FullName)

                Catch ex As Exception

                End Try
                item.SubItems.Add("")
                item.SubItems.Add("")
                item.SubItems.Add("")
                item.SubItems.Add("")
                item.SubItems.Add(f.FullName)
                listaNombres.Items.Add(item)

            ElseIf f.Extension = ".wav" Or f.Extension = ".ogg" Or f.Extension = ".aac" Or f.Extension = ".ac3" Or f.Extension = ".WAV" Or f.Extension = ".WMA" Or f.Extension = ".OGG" Or f.Extension = ".AAC" Or f.Extension = ".AC3" Then
                item.SubItems.Add("")
                item.SubItems.Add("")
                item.SubItems.Add("")
                item.SubItems.Add("")
                item.SubItems.Add(f.FullName)
                listaNombres.Items.Add(item)
            ElseIf f.Extension = ".avi" Or f.Extension = ".mpg" Or f.Extension = ".divx" Or f.Extension = ".rm" Or f.Extension = ".ogm" Or f.Extension = ".avc" Or f.Extension = ".flv" Or f.Extension = ".mkv" Or f.Extension = ".mp4" Or f.Extension = ".AVI" Or f.Extension = ".MPG" Or f.Extension = ".DIVX" Or f.Extension = ".RM" Or f.Extension = ".OGM" Or f.Extension = ".AVC" Or f.Extension = ".FLV" Or f.Extension = ".MKV" Or f.Extension = ".MP4" Then
                item.SubItems.Add("")
                item.SubItems.Add("")
                item.SubItems.Add("")
                item.SubItems.Add("")
                item.SubItems.Add(f.FullName)
                listaNombres.Items.Add(item)
            End If

        Catch ex As Exception
            item = New ListViewItem(nom)
            item.SubItems.Add("")
            item.SubItems.Add("")
            item.SubItems.Add("")
            item.SubItems.Add("")
            item.SubItems.Add(dirn)
            listaNombres.Items.Add(item)
        End Try


        totalesLista.Text = listaNombres.Items.Count
        listaNombres.EndUpdate()


        'iconoBarraAction("Agregado archivo a la Lista:", nom, reproducciones.repr.isMoviePlaying)

        setSelectedIndex(listaNombres, lidx)

        Return True
    End Function



    Private Sub AnimTrack_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnimTrack.Tick
        If Me.WindowState = FormWindowState.Normal Or Me.WindowState = FormWindowState.Maximized Then
            textotrack.moverElTexto()

        End If
    End Sub

    'Private Sub waiterTeclas_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles waiterTeclas.Tick
    '    Dim a As Integer = plugins.dartecla
    '    If a <> -22 Then
    '        Select Case OpcCambioTeclas.SelectedIndex
    '            Case 0
    '                plugins.setreproducir(a)
    '            Case 1
    '                plugins.setsiguiente(a)
    '            Case 2
    '                plugins.setatras(a)
    '            Case 3
    '                plugins.setparar(a)
    '            Case 4
    '                plugins.setreboadelan(a)
    '            Case 5
    '                plugins.setreboatras(a)
    '            Case 6
    '                plugins.setvolarriba(a)
    '            Case 7
    '                plugins.setvolabajo(a)
    '            Case 8
    '                plugins.setsinvol(a)
    '        End Select

    '        waiterTeclas.Enabled = False
    '        OpcButtCambioTeclas.Text = "Cambiar Tecla"
    '        MsgBox("La tecla " & OpcCambioTeclas.Text & " fue cambiada", vbInformation, "Cambio tecla")
    '    End If
    'End Sub

    Private Sub OpcButtCambioTeclas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpcButtCambioTeclas.Click
        If OpcCambioTeclas.SelectedIndex >= 0 And OpcTeclKit.SelectedIndex >= 0 Then
            Dim sd As String = InputBox("Escriba el codigo ASCII que quiere asignar, si no conoce el codigo, deje en blanco y presione la tecla. Escriba -1 si quiere dejar sin asignar.", "Cambio de tecla")
            If sd = Nothing Or sd = "" Then
                plugins.flagChangeKey = True
                'OpcButtCambioTeclas.Text = "presionar"
                Exit Sub
            End If
            Try
                plugins.cambioTecla(sd)
            Catch ex As Exception
                MsgBox("Tecla invalida", MsgBoxStyle.Critical, "Cambio teclas")
            End Try
        End If
    End Sub

    Private Sub IconoBarra_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles IconoBarra.MouseClick
    End Sub

    Private Sub IconoBarra_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles IconoBarra.MouseDoubleClick
        If Me.Visible = True Then
            If OpcMinimizarIconoBarra.Checked = True Then
                Me.Hide()

            Else
                Me.WindowState = FormWindowState.Minimized
            End If
        Else
            If OpcMinimizarIconoBarra.Checked = True Then
                Me.Show()

            Else
                Me.WindowState = FormWindowState.Normal
            End If
            Me.TopMost = True
            Me.TopMost = False
        End If
    End Sub

    Private Sub AnimTitBarra_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnimTitBarra.Tick
        If Me.Text = estadoBarra Then
            Me.Text = reproducciones.darNombrePista
        Else
            Me.Text = estadoBarra
        End If
    End Sub
    Public Sub imgAdelan()
        infoSiguiente.Width = 226
        infoSiguiente.Height = 17
        Select Case reproducciones.fordwval
            Case Reproductor.X2
                If reproducciones.backwrd Then
                    dspTempor.Text = "<< x2"
                Else
                    dspTempor.Text = "x2 >>"
                End If
                Try
                    vetaVideo.adelantimgs()
                Catch ex As Exception

                End Try


            Case Reproductor.X4
                If reproducciones.backwrd Then
                    dspTempor.Text = "<< x4"
                Else
                    dspTempor.Text = "x4 >>"
                End If
                Try
                    vetaVideo.adelantimgs()
                Catch ex As Exception

                End Try
            Case Reproductor.X8
                If reproducciones.backwrd Then
                    dspTempor.Text = "<< x8"
                Else
                    dspTempor.Text = "x8 >>"
                End If
                Try
                    vetaVideo.adelantimgs()
                Catch ex As Exception

                End Try
            Case Reproductor.X16
                If reproducciones.backwrd Then
                    dspTempor.Text = "<< x16"
                Else
                    dspTempor.Text = "x16 >>"
                End If
                Try
                    vetaVideo.adelantimgs()
                Catch ex As Exception

                End Try
            Case Reproductor.X20
                If reproducciones.backwrd Then
                    dspTempor.Text = "<< x20"
                Else
                    dspTempor.Text = "x20 >>"
                End If
                Try
                    vetaVideo.adelantimgs()
                Catch ex As Exception

                End Try
            Case Else
                dspTempor.Text = ""
                Try
                    vetaVideo.adelantimgs()
                Catch ex As Exception

                End Try
        End Select


    End Sub
    Public Sub adelantarsw(ByVal atras As Boolean)
        If reproducciones.reproductorMPEG.isMoviePlaying And AnimPau.Enabled = False Then
            Select Case reproducciones.fordwval
                Case Reproductor.X2
                    adelantar(atras, Reproductor.X4)
                    TimerAdelan.Enabled = True
                Case Reproductor.X4
                    adelantar(atras, Reproductor.X8)
                    TimerAdelan.Enabled = True
                Case Reproductor.X8
                    adelantar(atras, Reproductor.X16)
                    TimerAdelan.Enabled = True
                Case Reproductor.X16
                    adelantar(atras, Reproductor.X20)
                    TimerAdelan.Enabled = True
                Case Reproductor.X20
                    adelantar(atras, 0)
                    If reproducciones.sourceActivo = Reproductor.DVD Then reproducciones.adelantaccion()
                    TimerAdelan.Enabled = False
                Case Else
                    adelantar(atras, Reproductor.X2)
                    TimerAdelan.Enabled = True
            End Select
        Else
            adelantar(atras, 0)
            TimerAdelan.Enabled = False
        End If
    End Sub
    Public Sub adelantar(ByVal atras As Boolean, ByVal vall As Integer)

        If reproducciones.reproductorMPEG.isMoviePlaying And AnimPau.Enabled = False Then
            Try
                vetaVideo.mostrarBarra()
            Catch ex As Exception
            End Try
            Select Case vall
                Case Reproductor.X2
                    reproducciones.adelantaratrazar(atras, Reproductor.X2)
                    TimerAdelan.Enabled = True
                Case Reproductor.X4
                    reproducciones.adelantaratrazar(atras, Reproductor.X4)
                    TimerAdelan.Enabled = True
                Case Reproductor.X8
                    reproducciones.adelantaratrazar(atras, Reproductor.X8)
                    TimerAdelan.Enabled = True
                Case Reproductor.X16
                    reproducciones.adelantaratrazar(atras, Reproductor.X16)
                    TimerAdelan.Enabled = True
                Case Reproductor.X20
                    reproducciones.adelantaratrazar(atras, Reproductor.X20)
                    TimerAdelan.Enabled = True
                Case Else
                    reproducciones.adelantaratrazar(atras, 0)
                    If reproducciones.sourceActivo = Reproductor.DVD Then reproducciones.adelantaccion()
                    TimerAdelan.Enabled = False
            End Select
        Else

            reproducciones.adelantaratrazar(atras, 0)

            TimerAdelan.Enabled = False
        End If
    End Sub
    Public Sub iconoBarraAction(ByVal titulo As String, ByVal mensaje As String, ByVal active As Boolean)
        mensajepopup(0) = titulo
        mensajepopup(1) = mensaje
        If active Then IconoBarra.Icon = My.Resources.icoActivo Else IconoBarra.Icon = My.Resources.icoInactivo
        If OpcIconoBarra.Checked Then
            If OpcMostrarMensIconoBarra.Checked Then
                IconoBarra.BalloonTipTitle = titulo
                IconoBarra.BalloonTipText = mensaje
                Try
                    IconoBarra.ShowBalloonTip(5000)
                Catch ex As Exception

                End Try
            End If

        End If
    End Sub

    Private Sub BtnCerr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerr.Click
        cerrar()
    End Sub

    Private Sub OpcMostrarMensIconoBarra_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpcMostrarMensIconoBarra.CheckedChanged
        If OpcMostrarMensIconoBarra.Checked Then
            OpcIconoBarra.Checked = True
        End If

    End Sub

    Private Sub OpcMinimizarIconoBarra_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpcMinimizarIconoBarra.CheckedChanged
        If OpcMinimizarIconoBarra.Checked Then
            OpcIconoBarra.Checked = True
        End If
    End Sub

    Private Sub OpcIconoBarra_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpcIconoBarra.CheckedChanged
        If OpcIconoBarra.Checked = False Then
            OpcMinimizarIconoBarra.Checked = False
            OpcMostrarMensIconoBarra.Checked = False
            IconoBarra.Visible = False
        Else
            IconoBarra.Visible = True
        End If
    End Sub

    Private Sub BtnMini_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMini.Click
        If OpcMinimizarIconoBarra.Checked = True Then
            Me.Hide()
        Else
            Me.WindowState = FormWindowState.Minimized
        End If
    End Sub
    Public Sub playPauseLoad()
        If reproducciones.reproductorMPEG.isMoviePlaying Then
            If AnimPau.Enabled Then
                proseguir()
            Else
                pausa()
            End If
        Else
            desicionReproduccion()
        End If
    End Sub


    Private Sub OpcTeclas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpcTeclas.CheckedChanged
        If OpcTeclas.Checked Then
            'plugins.InstallHooks()
            Mactivartecl.Text = "Desactivar Kit 1"
            Mactivartecl.Image = My.Resources.popKeyen
            plugins.RemoveHooks()
            plugins.InstallHooks()
        Else
            'plugins.RemoveHooks()
            Mactivartecl.Text = "Activar Kit 1"
            Mactivartecl.Image = My.Resources.popKey
            plugins.RemoveHooks()
            plugins.InstallHooks()
        End If
    End Sub

    Private Sub Principal_MouseDown( _
       ByVal sender As Object, _
       ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown

        If e.Button = Windows.Forms.MouseButtons.Left Then
            ' habilitar el flag
            mover = True
            ' guardar las coordenadas
            x = e.X
            y = e.Y
            ' cambiar el cursor del mouse
            Me.Cursor = Cursors.NoMove2D
        End If
    End Sub

    Private Sub Principal_MouseMove( _
        ByVal sender As Object, _
        ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove

        If mover Then
            ' establecer la nueva posición
            Me.Location = New Point((Me.Left + e.X - x), (Me.Top + e.Y - y))
            Try
                dllg.Left = Me.Left + 253
                dllg.Top = Me.Top + 35
            Catch ex As Exception

            End Try
        
        End If

    End Sub

    Private Sub Principal_MouseUp( _
        ByVal sender As Object, _
        ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        ' reestablecer
        mover = False
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub BtnCerr_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCerr.MouseEnter
        ttlugar.SetToolTip(BtnCerr, "Cerrar")
        BtnCerr.BackgroundImage = My.Resources.btnCloseMov
    End Sub

    Private Sub BtnCerr_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCerr.MouseLeave
        BtnCerr.BackgroundImage = My.Resources.btnClose
    End Sub

    Private Sub BtnMini_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnMini.MouseEnter
        ttlugar.SetToolTip(BtnMini, "Minimizar")
        BtnMini.BackgroundImage = My.Resources.btnMinMov
    End Sub

    Private Sub BtnMini_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnMini.MouseLeave
        BtnMini.BackgroundImage = My.Resources.btnMin
    End Sub


    Public Sub mensajeMsnMostrar()
        If OpcEnablMSN.Checked Then
            Dim tmp As String = reproducciones.pistaid3
            If reproducciones.reproductorMPEG.isMoviePlaying Then

                If reproducciones.sourceActivo = Reproductor.RADIO Then

                    tmp = reproducciones.pista
                    plugins.SetMusicInfo(True, tmp)
                Else


                    If reproducciones.dartipo = Reproductor.VIDEO And OpcMSNVideo.Checked Then
                        tmp = "Reproduciendo: " & reproducciones.pistaid3 & " , Mensaje: " & OpcMsnTx.Text
                    ElseIf reproducciones.dartipo = Reproductor.AUDIO And OpcMsnAudio.Checked Then
                        tmp = "Reproduciendo: " & reproducciones.pistaid3 & " , Mensaje: " & OpcMsnTx.Text
                    End If
                End If
            End If
            plugins.SetMusicInfo(True, tmp)
        Else
            plugins.SetMusicInfo(False, "")
        End If

    End Sub

    Private Sub OpcEnablMSN_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpcEnablMSN.CheckedChanged
        mensajeMsnMostrar()
    End Sub

    Private Sub OpcMSNVideo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpcMSNVideo.CheckedChanged
        mensajeMsnMostrar()
    End Sub

    Private Sub OpcMsnAudio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpcMsnAudio.CheckedChanged
        mensajeMsnMostrar()
    End Sub

    Private Sub Principal_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseWheel

    End Sub

    Private Sub TimerAdelan_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerAdelan.Tick
        imgAdelan()
        reproducciones.adelantaccion()
    End Sub

    Private Sub Msiguien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Msiguien.Click
        irSiguiente()
    End Sub

    Private Sub Manterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Manterior.Click
        irAnterior()
    End Sub

    Private Sub Mpausarepro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Mpausarepro.Click
        If reproducciones.reproductorMPEG.isMoviePlaying Then
            If AnimPau.Enabled Then
                proseguir()
            Else
                pausa()
            End If
        Else
            desicionReproduccion()
        End If
    End Sub

    Private Sub Mparar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Mparar.Click
        parar()
    End Sub

    Private Sub Mactivartecl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Mactivartecl.Click
        If OpcTeclas.Checked Then
            OpcTeclas.Checked = False
            Mactivartecl.Text = "Activar Kit 1"
            Mactivartecl.Image = My.Resources.popKey
        Else
            OpcTeclas.Checked = True
            Mactivartecl.Text = "Desactivar Kit 1"
            Mactivartecl.Image = My.Resources.popKeyen
        End If


    End Sub

    Private Sub Mcerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Mcerrar.Click
        cerrar()
        Me.Dispose()
    End Sub

    Private Sub Minfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Minfo.Click
        If reproducciones.reproductorMPEG.isMoviePlaying Then
            iconoBarraAction(mensajepopup(0), mensajepopup(1), True)
        Else
            iconoBarraAction(mensajepopup(0), mensajepopup(1), False)
        End If

    End Sub
    Public Sub subirvol()
        If volBar.Value + 100 <= volBar.Maximum Then volBar.Value = volBar.Value + 100 Else volBar.Value = volBar.Maximum

    End Sub
    Public Sub bajarvol()
        If volBar.Value - 100 >= 0 Then volBar.Value = volBar.Value - 100 Else volBar.Value = 0
    End Sub
    Public Sub abrirsolo(ByVal arch As String)
        Try
            Dim hj As New FileInfo(arch)

            'comboUnidades.Drive = hj.DirectoryName

            'comboLista.Path = hj.DirectoryName



            cargarAchivosListaArch(hj.DirectoryName)

            Dim sd As ListViewItemCollection = listaArchivos.Items

            For i As Integer = 0 To sd.Count - 1

                If path & "\" & sd(i).SubItems(0).Text = arch Then
                    obligarLugar(Reproductor.CARPETA)
                    setSelectedIndex(listaArchivos, i)
                    desicionReproduccion()
                    Exit For
                End If
            Next
            Exit Sub
        Catch e As Exception
            MsgBox(e.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub AnimPas_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnimPas.Tick
        dspEsta.Visible = False
        AnimPas.Enabled = False
    End Sub

    Private Sub OpcMsnTx_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpcMsnTx.TextChanged
        mensajemsn = OpcMsnTx.Text
    End Sub

    Private Sub BtnMute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMute.Click
        If reproducciones.reproductorMPEG.mute Then
            reproducciones.reproductorMPEG.setAudioOn()
            reproducciones.reproductorMPEG.mute = False
            BtnMute.BackgroundImage = My.Resources.btnSpkMov
            If reproducciones.sourceActivo = Reproductor.RADIO Then
                reproducciones.reproductorRadio.setvolum(reproducciones.reproductorMPEG.volume * 10)
            End If
        Else
            reproducciones.reproductorMPEG.setAudioOff()
            reproducciones.reproductorMPEG.mute = True
            BtnMute.BackgroundImage = My.Resources.btnSpkMutMov
            If reproducciones.sourceActivo = Reproductor.RADIO Then
                reproducciones.reproductorRadio.setvolum(0)
            End If
        End If
    End Sub
    Public Sub muteact()
        If reproducciones.reproductorMPEG.mute Then
            reproducciones.reproductorMPEG.setAudioOn()
            reproducciones.reproductorMPEG.mute = False
            BtnMute.BackgroundImage = My.Resources.btnSpk
            If reproducciones.sourceActivo = Reproductor.RADIO Then
                reproducciones.reproductorRadio.setvolum(reproducciones.reproductorMPEG.volume * 10)
            End If
        Else
            reproducciones.reproductorMPEG.setAudioOff()
            reproducciones.reproductorMPEG.mute = True
            BtnMute.BackgroundImage = My.Resources.btnSpkMut
            If reproducciones.sourceActivo = Reproductor.RADIO Then
                reproducciones.reproductorRadio.setvolum(0)
            End If
        End If
    End Sub
    Public Sub muteobl(ByVal ons As Boolean)
        If ons = False Then
            reproducciones.reproductorMPEG.setAudioOn()
            reproducciones.reproductorMPEG.mute = False
            BtnMute.BackgroundImage = My.Resources.btnSpk
            If reproducciones.sourceActivo = Reproductor.RADIO Then
                reproducciones.reproductorRadio.setvolum(reproducciones.reproductorMPEG.volume * 10)
            End If
        Else
            reproducciones.reproductorMPEG.setAudioOff()
            reproducciones.reproductorMPEG.mute = True
            BtnMute.BackgroundImage = My.Resources.btnSpkMut
            If reproducciones.sourceActivo = Reproductor.RADIO Then
                reproducciones.reproductorRadio.setvolum(0)
            End If
        End If
    End Sub

    Private Sub BtnMute_MarginChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnMute.MarginChanged

    End Sub

    Private Sub BtnMute_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnMute.MouseEnter
        If reproducciones.reproductorMPEG.mute Then
            BtnMute.BackgroundImage = My.Resources.btnSpkMutMov
        Else
            BtnMute.BackgroundImage = My.Resources.btnSpkMov
        End If
    End Sub

    Private Sub BtnMute_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnMute.MouseLeave
        If reproducciones.reproductorMPEG.mute Then
            ttlugar.SetToolTip(BtnMute, "Sin Silencio")
            BtnMute.BackgroundImage = My.Resources.btnSpkMut
        Else
            ttlugar.SetToolTip(BtnMute, "Silenciar")
            BtnMute.BackgroundImage = My.Resources.btnSpk
        End If
    End Sub


    Private Sub Principal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        initBotonesThumbTareas()
        thumbImgTareas()
        PanelCarpeta.Visible = True
        PanelLista.Visible = True
        PanelCarpeta.Visible = False
        PanelLista.Visible = False


        If AnimPau.Enabled = False Then
            actualizarBotonesThumbTareas(True)

        End If
    End Sub
    Public Sub resiseForm(ByVal w As Integer, ByVal h As Integer)
        Me.Width = w
        Me.Height = h
    End Sub
    Public Sub borrarInfoDVD()
        comboDvdTitulos.Items.Clear()
        comboDvdIdiomas.Items.Clear()
        comboDvdSubs.Items.Clear()
        listaDvdCapis.Items.Clear()
        dspDVDDir.Text = "No se esta reproduciendo un DVD"
    End Sub

    Public Sub borrarInfoCDAudio()
        listaAudioTracks.Items.Clear()
        dspAudioEst.Text = "No se esta reproduciendo un CD De Audio"
    End Sub

    Public Sub cargarInfoDVD()
        Dim tiutulos As Integer = reproducciones.dvdplayer.darTitulos
        Dim capitulos As Integer = reproducciones.dvdplayer.darCapitulosTitulo(1)
        Dim audios As Integer = reproducciones.dvdplayer.darAudios
        Dim subs As Integer = reproducciones.dvdplayer.darSubtitulos


        dspDVDDir.Text = "Directorio: " & reproducciones.dvdplayer.darDirectorio
        comboDvdTitulos.Items.Clear()
        For i = 1 To tiutulos
            comboDvdTitulos.Items.Add("Titulo " & i)
        Next
        Try
            comboDvdTitulos.SelectedIndex = 0
        Catch ex As Exception

        End Try

        comboDvdIdiomas.Items.Clear()
        For i = 1 To audios
            comboDvdIdiomas.Items.Add("Audio " & i)
        Next

        Try
            comboDvdIdiomas.SelectedIndex = 0
        Catch ex As Exception

        End Try

        comboDvdSubs.Items.Clear()
        For i = 1 To subs
            comboDvdSubs.Items.Add("Subtitulo " & i)
        Next

        Try
            comboDvdSubs.SelectedIndex = 0
        Catch ex As Exception

        End Try


        listaDvdCapis.Items.Clear()
        For i = 1 To capitulos
            listaDvdCapis.Items.Add("Capitulo " & i)
        Next


        Try
            listaDvdCapis.SelectedIndex = 0
        Catch ex As Exception

        End Try
    End Sub

    Public Sub cargarInfoCDAudio()

        Dim tracks As Integer = reproducciones.reproductorMPEG.GetNumTracks


        dspAudioEst.Text = "Reproduciendo CD De Audio"

        listaAudioTracks.Items.Clear()


        For i = 1 To tracks
            listaAudioTracks.Items.Add("Pista " & i)
        Next
        Try
            listaAudioTracks.SelectedIndex = 0
        Catch ex As Exception

        End Try


    End Sub

    Private Sub infoSiguiente_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles infoSiguiente.MouseEnter
        ttlugar.SetToolTip(infoSiguiente, infoSiguiente.Text)
    End Sub

    Private Sub botonSobre_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles botonSobre.MouseEnter
        ttlugar.SetToolTip(botonSobre, "Mostrar Sobre")
        botonSobre.BackgroundImage = My.Resources.btnSobreMov
    End Sub

    Private Sub botonCarpeta_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles botonCarpeta.MouseEnter
        ttlugar.SetToolTip(botonCarpeta, "Mostrar Explorador De Carpetas")
        botonCarpeta.BackgroundImage = My.Resources.btnCarpMov
    End Sub

    Private Sub botonLista_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles botonLista.MouseEnter
        ttlugar.SetToolTip(botonLista, "Mostrar Lista De Reproducción")
        botonLista.BackgroundImage = My.Resources.btnLisMov
    End Sub

    Private Sub botonOpciones_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles botonOpciones.MouseEnter
        ttlugar.SetToolTip(botonOpciones, "Mostrar Opciones")
        botonOpciones.BackgroundImage = My.Resources.btnOpcMov
    End Sub

    Private Sub botonSobre_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles botonSobre.MouseLeave
        botonSobre.BackgroundImage = My.Resources.btnSobre
    End Sub

    Private Sub botonCarpeta_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles botonCarpeta.MouseLeave
        botonCarpeta.BackgroundImage = My.Resources.btnCarp
    End Sub

    Private Sub botonLista_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles botonLista.MouseLeave
        botonLista.BackgroundImage = My.Resources.btnLis
    End Sub

    Private Sub botonOpciones_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles botonOpciones.MouseLeave
        botonOpciones.BackgroundImage = My.Resources.btnOpc
    End Sub

    Private Sub dspRem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dspRem.Click
        If posSw = 2 Then
            posSw = 0
        Else
            posSw = posSw + 1
        End If
    End Sub


    Private Sub Principal_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Me.Activate()
    End Sub

    Private Sub botonComp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles botonComp.Click
        If flagmax Then
            aumentarRedprincipal(False)
            botonComp.BackgroundImage = My.Resources.btnCompMov

        Else
            aumentarRedprincipal(True)
            botonComp.BackgroundImage = My.Resources.btnExpMov

        End If
    End Sub

    Private Sub botonComp_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles botonComp.MouseEnter

        If flagmax Then
            botonComp.BackgroundImage = My.Resources.btnCompMov
            ttlugar.SetToolTip(botonComp, "Compactar")
        Else
            botonComp.BackgroundImage = My.Resources.btnExpMov
            ttlugar.SetToolTip(botonComp, "Expander")
        End If
    End Sub

    Private Sub botonComp_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles botonComp.MouseLeave
        If flagmax Then
            botonComp.BackgroundImage = My.Resources.btnComp
        Else
            botonComp.BackgroundImage = My.Resources.btnExp
        End If
    End Sub

    Private Sub dspModo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dspModo.Click
        If reproducciones.darmodo = Reproductor.NORMAL Then
            dspModo.BackgroundImage = My.Resources.btnModoRepUn
            reproducciones.cambiarmodo(Reproductor.REPETIR)
            ttlugar.SetToolTip(dspModo, "Se Repetirá El Archivo En Reproducción")
        ElseIf reproducciones.darmodo = Reproductor.REPETIR Then
            dspModo.BackgroundImage = My.Resources.btnModoRep
            reproducciones.cambiarmodo(Reproductor.REPETODO)
            If reproducciones.darlugar = Reproductor.LISTA Then
                ttlugar.SetToolTip(dspModo, "Se Repetirá La Reproducción De Todos Los Archivos De La Lista")
            Else
                ttlugar.SetToolTip(dspModo, "Se Repetirá La Reproducción De Todos Los Archivos De La Carpeta")
            End If
        Else
            dspModo.BackgroundImage = My.Resources.btnRepOnMov
            reproducciones.cambiarmodo(Reproductor.NORMAL)
            ttlugar.SetToolTip(dspModo, "Reproducción Normal")
        End If
    End Sub



    Private Sub dspOrden_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dspOrden.Click
        If reproducciones.darorden = Reproductor.ORDEN_NORMAL Then
            dspOrden.BackgroundImage = My.Resources.btnOrden
            reproducciones.cambiarorden(Reproductor.ORDEN_ALEATORIO)
            activarRnd()
            ttlugar.SetToolTip(dspOrden, "Reproducción En Orden Aleatorio")
        Else
            dspOrden.BackgroundImage = My.Resources.btnOrdenMov
            reproducciones.cambiarorden(Reproductor.ORDEN_NORMAL)
            ttlugar.SetToolTip(dspOrden, "Reproducción En Orden Continuo")
        End If
    End Sub
    Private Sub activarRnd()

        If reproducciones.darlugar = Reproductor.CARPETA Then
            randomGenerator = New RandomSequence(listaArchivos.Items.Count)
        Else
            randomGenerator = New RandomSequence(listaNombres.Items.Count)
        End If


    End Sub




    Private Sub dspLugar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dspLugar.Click
        If reproducciones.darlugar = Reproductor.CARPETA Then
            dspLugar.BackgroundImage = My.Resources.btnLugLisMov
            reproducciones.cambiarlugar(Reproductor.LISTA)
            ttlugar.SetToolTip(dspLugar, "Reproduciendo desde La Lista")
        Else
            dspLugar.BackgroundImage = My.Resources.btnLugCarpMov
            reproducciones.cambiarlugar(Reproductor.CARPETA)
            ttlugar.SetToolTip(dspLugar, "Reproduciendo desde La Carpeta")

        End If
        limpiarAleatorio()

    End Sub

    Private Sub dspLugar_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles dspLugar.MouseEnter
        If reproducciones.darlugar = Reproductor.CARPETA Then
            dspLugar.BackgroundImage = My.Resources.btnLugCarpMov
        Else
            dspLugar.BackgroundImage = My.Resources.btnLugLisMov

        End If
    End Sub

    Private Sub dspLugar_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles dspLugar.MouseLeave
        If reproducciones.darlugar = Reproductor.CARPETA Then
            dspLugar.BackgroundImage = My.Resources.btnLugCarp
        Else
            dspLugar.BackgroundImage = My.Resources.btnLugLis

        End If
    End Sub

    Private Sub PanelCtrl_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PanelCtrl.MouseDown
        Principal_MouseDown(sender, e)
    End Sub

    Private Sub PanelCtrl_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PanelCtrl.MouseMove
        Principal_MouseMove(sender, e)
    End Sub

    Private Sub PanelCtrl_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PanelCtrl.MouseUp
        Principal_MouseUp(sender, e)
    End Sub




    Private Sub anadePlist_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles anadePlist.Click
        anadelista()
    End Sub

    Private Sub PanelCarpeta_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PanelCarpeta.Paint

    End Sub

    Private Sub listaArchivos_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles listaArchivos.ColumnClick
        listviewsort(listaArchivos, e)

    End Sub


    Private Sub listaArchivos_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles listaArchivos.MouseDoubleClick
        If reproducciones.darlugar = Reproductor.CARPETA Then
            desicionReproduccion()

        Else
            agregaralista(path & "\" & listaArchivosFilename(), listaArchivosFilename())
        End If
        eventoDeListaActualizar()
    End Sub

    Private Sub listaArchivos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles listaArchivos.SelectedIndexChanged

        selecCarpeta.Text = getSelectedIndex(listaArchivos) + 1

        If reproducciones.darlugar = Reproductor.CARPETA Then
            If reproducciones.reproductorMPEG.Filename = path & "\" & listaArchivosFilename() Then
                If reproducciones.darorden = Reproductor.NORMAL Then
                    infoSiguiente.Text = "Archivo " & getSelectedIndex(listaArchivos) + 1 & " de " & listaArchivos.Items.Count
                Else
                    infoSiguiente.Text = "Reproducidos " & randomGenerator._lastIndex & " de " & listaArchivos.Items.Count
                End If
            Else
                infoSiguiente.Text = "->: " & listaArchivosFilename()
            End If

        End If

    End Sub
    Public Sub listviewsort(ByVal lv As ListView, ByVal e As System.Windows.Forms.ColumnClickEventArgs)
        ' Get the new sorting column.
        Dim new_sorting_column As ColumnHeader = _
            lv.Columns(e.Column)

        ' Figure out the new sorting order.
        Dim sort_order As System.Windows.Forms.SortOrder
        If m_SortingColumn Is Nothing Then
            ' New column. Sort ascending.
            sort_order = SortOrder.Ascending
        Else
            ' See if this is the same column.
            If new_sorting_column.Equals(m_SortingColumn) Then
                ' Same column. Switch the sort order.
                If m_SortingColumn.Text.StartsWith("\/ ") Then
                    sort_order = SortOrder.Descending
                Else
                    sort_order = SortOrder.Ascending
                End If
            Else
                ' New column. Sort ascending.
                sort_order = SortOrder.Ascending
            End If

            ' Remove the old sort indicator.
            m_SortingColumn.Text = m_SortingColumn.Text.Substring(2)
        End If

        ' Display the new sort order.
        m_SortingColumn = new_sorting_column
        If sort_order = SortOrder.Ascending Then
            m_SortingColumn.Text = "\/ " & m_SortingColumn.Text
        Else
            m_SortingColumn.Text = "/\ " & m_SortingColumn.Text
        End If

        ' Create a comparer.
        lv.ListViewItemSorter = New ListViewComparer(e.Column, sort_order)

        ' Sort.
        lv.Sort()
    End Sub
    Private Sub listaNombres_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles listaNombres.ColumnClick
        listviewsort(listaNombres, e)
    End Sub


    Public Sub lNombrechangeevent()
        Try
            seleccionLista.Text = getSelectedIndex(listaNombres) + 1
            If reproducciones.darlugar = Reproductor.LISTA Then
                If reproducciones.reproductorMPEG.Filename = listaNombres.SelectedItems(0).SubItems(listaNombres.Columns.Count - 1).Text Then
                    If reproducciones.darorden = Reproductor.NORMAL Then
                        infoSiguiente.Text = "Archivo " & getSelectedIndex(listaNombres) + 1 & " de " & listaNombres.Items.Count
                    Else
                        infoSiguiente.Text = "Reproducidos " & randomGenerator._lastIndex & " de " & listaNombres.Items.Count
                    End If
                Else
                    infoSiguiente.Text = "->: " & listaNombres.SelectedItems(0).Text
                End If

            End If
        Catch ex As Exception

        End Try

    End Sub



    Private Sub listaNombres_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles listaNombres.MouseDoubleClick
        If reproducciones.darlugar = Reproductor.LISTA Then
            desicionReproduccion()
        End If
    End Sub




    Private Sub listaNombres_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles listaNombres.SelectedIndexChanged
        lNombrechangeevent()
    End Sub






    Private Sub botonDVD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles botonDVD.Click
        If PanelDVD.Visible Then
            PanelDVD.Visible = False
        Else
            PanelCarpeta.Visible = False
            PanelOpcion.Visible = False
            PanelLista.Visible = False
            PanelSobre.Visible = False
            PanelDVD.Visible = True
            PanelCDAudio.Visible = False
            PanelRadio.Visible = False
            PanelSleep.Visible = False
        End If
    End Sub

    Private Sub btnReproducDVD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReproducDVD.Click
        parar()
        desicionReproduccion2(Reproductor.DVD)
        configuracionDeTipoMulti(Reproductor.DVD)
    End Sub


    Private Sub btnDvdMenPrinc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDvdMenPrinc.Click
        Try
            reproducciones.dvdplayer.irAMenuPrincipal()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnDvdMenuTit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDvdMenuTit.Click
        Try
            reproducciones.dvdplayer.irAMenuTitulo()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub comboDvdTitulos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comboDvdTitulos.SelectedIndexChanged
        Try
            Dim capitulos As Integer = reproducciones.dvdplayer.darCapitulosTitulo(comboDvdTitulos.SelectedIndex + 1)
            listaDvdCapis.Items.Clear()
            For i = 1 To capitulos
                listaDvdCapis.Items.Add("Capitulo " & i)
            Next



            listaDvdCapis.SelectedIndex = 0
        Catch ex As Exception

        End Try
    End Sub

    Private Sub listaDvdCapis_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles listaDvdCapis.MouseDoubleClick
        Try
            reproducciones.dvdplayer.irATitulo(comboDvdTitulos.SelectedIndex + 1)
            reproducciones.dvdplayer.irACapitulo(listaDvdCapis.SelectedIndex + 1)
        Catch ex As Exception

        End Try

    End Sub


    Private Sub botonDVD_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles botonDVD.MouseEnter
        ttlugar.SetToolTip(botonDVD, "Mostrar Controles DVD")
        botonDVD.BackgroundImage = My.Resources.btnDVDMov
    End Sub

    Private Sub botonCdAudio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles botonCdAudio.Click
        If PanelCDAudio.Visible Then
            PanelCDAudio.Visible = False

        Else
            PanelLista.Visible = False
            PanelCarpeta.Visible = False
            PanelOpcion.Visible = True
            PanelSobre.Visible = False
            PanelDVD.Visible = False
            PanelOpcion.Visible = False
            PanelCDAudio.Visible = True
            PanelRadio.Visible = False
            PanelSleep.Visible = False
        End If
    End Sub

    Private Sub botonCdAudio_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles botonCdAudio.MouseEnter
        ttlugar.SetToolTip(botonCdAudio, "Mostrar Controles CD De Audio")
        botonCdAudio.BackgroundImage = My.Resources.btnAudioMov
    End Sub

    Private Sub botonDVD_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles botonDVD.MouseLeave
        botonDVD.BackgroundImage = My.Resources.btnDVD
    End Sub

    Private Sub botonCdAudio_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles botonCdAudio.MouseLeave
        botonCdAudio.BackgroundImage = My.Resources.btnAudio
    End Sub

    Private Sub btnReproAudio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReproAudio.Click, Button1.Click
        parar()
        desicionReproduccion2(Reproductor.CDAUDIO)
        configuracionDeTipoMulti(Reproductor.CDAUDIO)
    End Sub

    Private Sub listaAudioTracks_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles listaAudioTracks.DoubleClick, ListBox1.DoubleClick
        reproducciones.reproductorMPEG.SeekCDtoX(listaAudioTracks.SelectedIndex + 1)

    End Sub



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        vetaVideo.resise()
    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        reproducciones.reproductorRadio.untune()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        reproducciones.reproductorRadio.setvolum(10000)
    End Sub

    Private Sub btnGrabarRadio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabarRadio.Click
        If reproducciones.reproductorRadio.opened = True Then
            If btnGrabarRadio.Text = "Parar" Then
                detenerGrabacion()
                btnGrabarRadio.Text = "Grabar"
            Else
                If grabarRadio() Then btnGrabarRadio.Text = "Parar"
            End If
        End If
    End Sub
    Public Function grabarRadio() As Boolean
        If reproducciones.reproductorRadio.record() Then
            btnGrabarRadio.Text = "Parar"
            dspRecout.Text = "GRABANDO "
            Return True
        End If
        Return False
    End Function
    Public Sub detenerGrabacion()
        reproducciones.reproductorRadio.stoprecord()
        'desicionReproduccion2(Reproductor.RADIO)
        btnGrabarRadio.Text = "Grabar"
        dspRecout.Text = "GRABACION FINALIZADA"
    End Sub

    Private Sub btnAndirRadio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAndirRadio.Click
        Dim str As String = InputBox("Inserte la url de la nueva Estacion:", "Radio")
        Dim str2 As String = InputBox("Inserte El Nombre de La Nueva Estacion", "Radio", "Canal " & ListaTunes.Items.Count)

        anadirEstRadio(str, str2)
    End Sub
    Public Sub anadirEstRadio(ByVal url As String, ByVal name As String)
        If url = "" Or name = "" Then Return
        Dim Items As ListViewItemCollection = ListaTunes.Items
        For i As Integer = 0 To Items.Count - 1
            Try

                If Items(i).SubItems(ListaTunes.Columns.Count - 1).Text = url Then
                    MsgBox("La Estacion " & url & " ya esta en la lista", MsgBoxStyle.Exclamation, "Lista")
                    Return
                End If
            Catch ex As Exception

            End Try

        Next

        Dim item As New ListViewItem(name)
        item.SubItems.Add(url)
        ListaTunes.Items.Add(item)
    End Sub
    Public Sub removerEstRadio()

    End Sub

    Private Sub btnRadio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRadio.Click
        If PanelRadio.Visible Then
            PanelRadio.Visible = False

        Else
            PanelLista.Visible = False
            PanelCarpeta.Visible = False
            PanelOpcion.Visible = True
            PanelSobre.Visible = False
            PanelDVD.Visible = False
            PanelOpcion.Visible = False
            PanelCDAudio.Visible = False
            PanelRadio.Visible = True
            PanelSleep.Visible = False
        End If
    End Sub

    Private Sub ListaTunes_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListaTunes.MouseDoubleClick

        reproducciones.sourceActivo = Reproductor.RADIO
        desicionReproduccion2(Reproductor.RADIO)

    End Sub





    Private Sub btnQuitarRadio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuitarRadio.Click
        Try
            Dim tmp As Integer = 0
            tmp = getSelectedIndex(ListaTunes)
            ListaTunes.Items.RemoveAt(getSelectedIndex(ListaTunes))
            setSelectedIndex(ListaTunes, tmp - 1)
        Catch ex As Exception
            setSelectedIndex(listaNombres, 0)
        End Try
    End Sub
    Public Delegate Sub restetTextoTrackDele()
    Public Sub restetTextoTrack()
        If reproducciones.darNombrePista(False).Length >= 30 Then
            textotrack.setTexto(reproducciones.darNombrePista(False))
            textotrack.reset()

        Else
            dspTrac.Text = reproducciones.darNombrePista(False)

        End If

    End Sub
    Public Delegate Sub actualizarInfoSiguienteDele(ByVal info As String)
    Public Sub actualizarInfoSiguiente(ByVal info As String)
        infoSiguiente.Text = info
    End Sub

    Public Sub radioTagUpdate()
        Try


            If reproducciones.reproductorRadio.artist.Equals("") Then
                reproducciones.pista = reproducciones.reproductorRadio.station
                reproducciones.pistaid3 = reproducciones.pista
                Invoke(New actualizarInfoSiguienteDele(AddressOf actualizarInfoSiguiente), reproducciones.reproductorRadio.radio._Genre)
                'actualizarInfoSiguiente("")
                estadoBarra = "Reproduciendo Radio"
            Else
                reproducciones.pista = reproducciones.reproductorRadio.artist & " - " & reproducciones.reproductorRadio.title
                reproducciones.pistaid3 = reproducciones.pista
                Invoke(New actualizarInfoSiguienteDele(AddressOf actualizarInfoSiguiente), reproducciones.reproductorRadio.station)
                estadoBarra = reproducciones.reproductorRadio.radio._radioName
            End If

            Invoke(New restetTextoTrackDele(AddressOf restetTextoTrack))
            iconoBarraAction("Reproduciendo Radio", reproducciones.darNombrePista(False), True)
            mensajeMsnMostrar()

        Catch ex As Exception

        End Try


    End Sub
    Public Sub radioStatusUpdate()
        Try
            'iconoBarraAction("Cargando Radio", reproducciones.darNombrePista(False), True)

            Invoke(New actualizarInfoSiguienteDele(AddressOf actualizarInfoSiguiente), reproducciones.reproductorRadio.status)
            estadoBarra = "Cargando Radio"


        Catch ex As Exception

        End Try


    End Sub

    Private Sub btnBorrarTodosTunes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrarTodosTunes.Click
        Dim anad As Integer = MsgBox("Desea Borrar todos los elementos de la lista?", MsgBoxStyle.YesNo, "Mini Media Player")
        If anad = vbYes Then
            ListaTunes.Items.Clear()
        End If

    End Sub

    Private Sub btnRadio_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRadio.MouseEnter
        ttlugar.SetToolTip(btnRadio, "Mostrar Lista De Estaciones de Radio")
        btnRadio.BackgroundImage = My.Resources.btnRadioMov
    End Sub

    Private Sub btnRadio_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRadio.MouseLeave
        btnRadio.BackgroundImage = My.Resources.btnRadio
    End Sub



    Private Sub ListaTunes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListaTunes.SelectedIndexChanged

    End Sub


    Private Sub btnAbrirRadio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbrirRadio.Click
        openradio()
    End Sub
    Public Sub openradio()
        DialogoAbrir.InitialDirectory = Application.StartupPath
        DialogoAbrir.Filter = "Lista de Reproduccion (*.m3u)|*.m3u"
        DialogoAbrir.Multiselect = False

        If DialogoAbrir.ShowDialog = Windows.Forms.DialogResult.OK Then





            Dim dirs() As String
            Dim names() As String

            If CargarM3U(DialogoAbrir.FileName, dirs, names) Then

                Dim anad As Integer = MsgBox("Desea añadir esta lista a la lista de reproduccion actual?", MsgBoxStyle.YesNo, "Mini Media Player")
                If anad = vbYes Then
                    For i = 0 To dirs.Length - 1
                        anadirEstRadio(dirs(i).Trim, names(i).Split(":")(1).Split(";")(0))
                    Next
                Else
                    ListaTunes.Items.Clear()
                    For i = 0 To dirs.Length - 1
                        anadirEstRadio(dirs(i).Trim, names(i).Split(":")(1).Split(";")(0))
                    Next
                End If
            Else
                MsgBox("Error al abrir Lista", MsgBoxStyle.Exclamation, "Mini Media Player")

            End If

        End If
    End Sub

    Private Sub btnGuardarRadio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarRadio.Click
        guardaradio()
    End Sub
    Public Sub guardaradio()

        If ListaTunes.Items.Count = 0 Then
            MsgBox("No hay archivos en la Lista.", MsgBoxStyle.Information, "Mini Media Player")
            Exit Sub
        End If



        DialogoGuardar.InitialDirectory = Application.StartupPath
        DialogoGuardar.Filter = "Lista De Reproduccion (*.m3u)|*.m3u"
        DialogoGuardar.ShowDialog()


        If DialogoGuardar.FileName <> Nothing And ListaTunes.Items.Count > 0 Then
            GuardarM3U(DialogoGuardar.FileName, ListaTunes.Items, 1, 0)
        End If






    End Sub



    Public Sub moverPLItemArriba()
        Try
            If getSelectedIndex(listaNombres) > 0 And listaNombres.Items.Count <> 0 Then
                listaArchivos.BeginUpdate()
                Dim idx As Integer = getSelectedIndex(listaNombres)
                Dim tmp As ListViewItem = listaNombres.Items(idx)
                Dim tmp2 As ListViewItem = listaNombres.Items(idx - 1)
                listaNombres.Items.RemoveAt(idx)
                listaNombres.Items.RemoveAt(idx - 1)
                listaNombres.Items.Insert(idx - 1, tmp)
                listaNombres.Items.Insert(idx, tmp2)

                listaArchivos.EndUpdate()
                listaArchivos.Items(getSelectedIndex(listaNombres)).EnsureVisible()
            End If
        Catch ex As Exception

        End Try


    End Sub
    Public Sub moverPLItemAbajo()
        Try
            If getSelectedIndex(listaNombres) < listaNombres.Items.Count - 1 And listaNombres.Items.Count <> 0 Then
                listaArchivos.BeginUpdate()
                Dim idx As Integer = getSelectedIndex(listaNombres)
                Dim tmp As ListViewItem = listaNombres.Items(idx)
                Dim tmp2 As ListViewItem = listaNombres.Items(idx + 1)
                listaNombres.Items.RemoveAt(idx + 1)
                listaNombres.Items.RemoveAt(idx)
                listaNombres.Items.Insert(idx, tmp2)
                listaNombres.Items.Insert(idx + 1, tmp)

                listaArchivos.EndUpdate()
                listaArchivos.Items(getSelectedIndex(listaNombres)).EnsureVisible()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnArr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArr.Click


    End Sub

    Private Sub btnAba_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAba.Click

    End Sub

    Private Sub btnAba_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnAba.MouseDown
        moverPLItemAbajo()
    End Sub

    Private Sub btnArr_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnArr.MouseDown
        moverPLItemArriba()
    End Sub

    Private Sub PanelCtrl_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PanelCtrl.Paint

    End Sub

    Private Sub botonSleep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles botonSleep.Click
        If PanelSleep.Visible Then
            PanelSleep.Visible = False
        Else
            PanelSleep.Visible = True
            PanelLista.Visible = False
            PanelCarpeta.Visible = False
            PanelOpcion.Visible = False
            PanelSobre.Visible = False
            PanelDVD.Visible = False
            PanelCDAudio.Visible = False
            PanelRadio.Visible = False
        End If
    End Sub

    Private Sub botonSleep_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles botonSleep.MouseDown

    End Sub

    Private Sub botonSleep_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles botonSleep.MouseEnter
        ttlugar.SetToolTip(botonSleep, "Mostrar Opciones de Apagado")
        botonSleep.BackgroundImage = My.Resources.btnExpMov
    End Sub

    Private Sub botonSleep_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles botonSleep.MouseLeave
        botonSleep.BackgroundImage = My.Resources.btnExp
    End Sub

    Private Sub CheckSleep_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckSleep.CheckedChanged
        If CheckSleep.Checked Then
            sleepCounter = SleepSel.Value
            SleepSel.Enabled = False
            SleepTimer.Enabled = True
            iconoBarraAction("Apagado Automatico Activado", "Quedan " & sleepCounter & " minutos.", False)
            dspSleep.Text = "Quedan " & sleepCounter & " minutos."
        Else
            SleepTimer.Enabled = False
            sleepCounter = 15
            SleepSel.Enabled = True
            iconoBarraAction("Apagado Automatico ", "Desactivado.", False)
            dspSleep.Text = ""
        End If
    End Sub

    Private Sub SleepTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SleepTimer.Tick
        sleepCounter = sleepCounter - 1
        dspSleep.Text = "Quedan " & sleepCounter & " minutos."
        If sleepCounter <= 0 Then
            SleepTimer.Enabled = False
            CheckSleep.Checked = False
            System.Diagnostics.Process.Start("shutdown", "-s -t 00")
        ElseIf (sleepCounter Mod 10) = 0 Then
            iconoBarraAction("Apagado Automatico", "Quedan " & sleepCounter & " minutos.", False)
        ElseIf sleepCounter < 3 Then
            iconoBarraAction("Apagado Automatico", "Quedan " & sleepCounter & " minutos.", False)
        End If
    End Sub

    Private Sub panelDspTrac_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles panelDspTrac.MouseDoubleClick
        Clipboard.Clear()
        Clipboard.SetText(dspTrac.Text)

    End Sub


    Private Sub panelDspTrac_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles panelDspTrac.MouseEnter
        ttlugar.SetToolTip(panelDspTrac, "Doble Click para copiar Informacion")
    End Sub



    Private Sub dspTrac_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dspTrac.MouseDoubleClick
        Clipboard.Clear()
        Clipboard.SetText(dspTrac.Text)
    End Sub

    Private Sub dspTrac_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles dspTrac.MouseEnter
        ttlugar.SetToolTip(dspTrac, "Doble Click para copiar Informacion")
    End Sub

    Private Sub comboLista_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub




    

    Public Sub LoadDirTree(ByVal DirPath As String, ByVal Node As Windows.Forms.TreeNode)
        On Error Resume Next
        Dim Dir As String
        Dim Index As Integer
        If Node.Nodes.Count = 0 Then
            For Each Dir In My.Computer.FileSystem.GetDirectories(DirPath)
                Index = Dir.LastIndexOf("\")
                Node.Nodes.Add(Dir.Substring(Index + 1, Dir.Length - Index - 1))
                Node.LastNode.Tag = Dir
                Node.LastNode.ImageIndex = 0
            Next
        End If
    End Sub


    Private Sub TreeDir_OpenDir(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TreeDir.OpenDir

        cargarAchivosListaArch(TreeDir.SelectedFile.Path, True)

        LabelDirectory.Text = TreeDir.SelectedFile.Path
    End Sub

    Private Sub TreeDir_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs)

    End Sub

    Private Sub TreeDir_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TreeDir_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)

    End Sub

    
    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        TreeDir.LoadNodes()
        cargarAchivosListaArch(LabelDirectory.Text)
    End Sub

    Private Sub Principal_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        thumbImgTareas()
    End Sub

    Private Sub OpcTeclasD_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpcTeclasD.CheckedChanged
        If OpcTeclasD.Checked Then
            'plugins.InstallHooks()
            MactivarteclD.Text = "Desactivar Kit 2"
            MactivarteclD.Image = My.Resources.popKeyen
            plugins.RemoveHooks()
            plugins.InstallHooks()
        Else
            'plugins.RemoveHooks()
            MactivarteclD.Text = "Activar Kit 2"
            MactivarteclD.Image = My.Resources.popKey
            plugins.RemoveHooks()
            plugins.InstallHooks()
        End If
    End Sub

    Private Sub MactivarteclD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MactivarteclD.Click
        If OpcTeclasD.Checked Then
            OpcTeclasD.Checked = False
            MactivarteclD.Text = "Activar Kit 2"
            MactivarteclD.Image = My.Resources.popKey
        Else
            OpcTeclasD.Checked = True
            MactivarteclD.Text = "Desactivar Kit 2"
            MactivarteclD.Image = My.Resources.popKeyen
        End If
    End Sub

    Private Sub OpcCambioTeclas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpcCambioTeclas.SelectedIndexChanged

    End Sub

    Protected Overrides Sub Finalize()
        'MyBase.Finalize()
    End Sub
End Class