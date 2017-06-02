Public Class Reproductor
    Private lugar As Integer = 0
    Private tipo As Integer = 0
    Private modo As Integer = 0
    Private orden As Integer = 0
    Public pistaid3 As String = ""
    Public pista As String = ""
    Public reproductorMPEG As New Reproduccion
    Public reproductorRadio As New NetRadioInterface()
    Private clipini As Long = 0
    Private clipfin As Long = 0
    Private clipon As Boolean = False
    Public Const VIDEO As Integer = 0
    Public Const AUDIO As Integer = 1
    Public form As Principal
    Public rndPl As New Collection
    Public fordwval As Integer = 0
    Public backwrd As Boolean = False
    Public videosets As Integer() = {0, 0, 0, 0, 4, 0, 0}
    Public dvdplayer As New DvdPlayer
    Public sourceActivo As Integer = 0

    Public Const MPEG As Integer = 0
    Public Const DVD As Integer = 1
    Public Const CDAUDIO As Integer = 2
    Public Const RADIO As Integer = 3

    Public Const CARPETA As Integer = 0
    Public Const LISTA As Integer = 1

    Public Const NORMAL As Integer = 0
    Public Const REPETIR As Integer = 1
    Public Const REPETODO As Integer = 2

    Public Const ORDEN_NORMAL As Integer = 0
    Public Const ORDEN_ALEATORIO As Integer = 1

    Public Const X2 As Integer = 2000
    Public Const X4 As Integer = 4000
    Public Const X8 As Integer = 8000
    Public Const X16 As Integer = 16000
    Public Const X20 As Integer = 20000
    Public Sub cambiarClipini(ByVal ini As Long)
        clipini = ini
    End Sub
    Public Function isClipeado() As Boolean
        Return clipon
    End Function

    Public Sub actualizarRotuloDVD()
        pista = dvdplayer.darRorulo
    End Sub
    Public Sub cambiarClipfin(ByVal fin As Long)
        clipfin = fin
        If (clipfin - clipini < 3000) Then
            clipini = 0
            clipfin = 0
            clipon = False
        Else
            clipon = True
        End If
    End Sub
    Public Function darclipini() As Long
        Return clipini
    End Function
    Public Function darclipfin() As Long
        Return clipfin
    End Function

    Public Function cambiarlugar(ByVal lug As Integer) As Integer
        lugar = lug
        Return 0
    End Function
    Public Function darlugar() As Integer
        Return lugar
    End Function
    Public Function cambiarmodo(ByVal mods As Integer) As Integer
        modo = mods
        Return 0
    End Function
    Public Function darmodo() As Integer
        Return modo
    End Function
    Public Function cambiarorden(ByVal ord As Integer) As Integer
        orden = ord
        Return 0
    End Function
    Public Function darorden() As Integer
        Return orden
    End Function
    Public Function dartipo() As Integer
        Return tipo
    End Function
    Public Function darNombrePista(Optional ByVal sinext As Boolean = False) As String
        If sinext Then
            For i As Integer = Len(pista) To 1 Step -1
                If Mid(pista, i, 1) = "." Then
                    Return Mid(pista, 1, i - 1)
                    Exit For
                End If
            Next
        End If
        Return pista
    End Function
    Public Function reproducir(ByVal file As String, Optional ByVal sourcedir As String = "", Optional ByVal totaltrkinfo As String = "DEF") As Boolean
        Try
            cerrarVentanaVideo()
            form.plugins.RemovemouseHooks()
            reproductorMPEG.closeMovie()
            dvdplayer.cerrarDVD()
            sourceActivo = MPEG
            Dim sTodo As String
            Dim sPath As String
            Dim vNombre As String
            Dim vExt As String
            Dim bNombre As Boolean
            sTodo = file
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


            pista = vNombre
            reproductorMPEG.Filename = file
            vExt = vExt.ToLower
            If file = "RADIO" Then

                sourceActivo = RADIO

                pista = sourcedir
                pistaid3 = pista
                tipo = AUDIO
                reproductorRadio.tune(sourcedir)
                'pistaid3 = reproductorRadio.radio._Artist & " - " & reproductorRadio.radio._Title
                If reproductorMPEG.mute Then
                    reproductorRadio.setvolum(0)
                Else
                    reproductorRadio.setvolum(form.volBar.Value * 10)
                End If
            ElseIf file = "DVD" Then
                form.plugins.InstallmouseHooks()
                sourceActivo = DVD
                abrirVentanaVideo()
                Try

                    dvdplayer.reproducir(form.vetaVideo.DibujoVideo)
                    pista = dvdplayer.darRorulo
                    pistaid3 = pista
                    form.vetaVideo.resise()
                Catch ex As Exception
                    Return False
                End Try


                tipo = VIDEO

            ElseIf file = "CDAUDIO" Then

                sourceActivo = CDAUDIO
                reproductorMPEG.openAudioCD()
                pista = "CD De Audio"
                pistaid3 = pista
                reproduciract()
                tipo = AUDIO

            ElseIf vExt = "mp3" Or vExt = "wma" Or vExt = "wav" Or vExt = "wma" Or vExt = "ogg" Or vExt = "aac" Or vExt = "m4a" Or vExt = "flac" Then
                If vExt = "mp3" Or vExt = "wma" Or vExt = "m4a" Then
                    Dim reads As New Id3Reader
                    Dim tgs As New Id3Reader.MP3(sPath, vNombre)
                    Try
                        reads.readMP3Tag(tgs)
                        pistaid3 = labelTagPoc(tgs)
                    Catch ex As Exception
                        pistaid3 = darNombrePista(True)
                    End Try
                Else
                    pistaid3 = darNombrePista(True)



                End If
                sourceActivo = MPEG
                reproductorMPEG.openMovie()
                tipo = AUDIO


            ElseIf vExt = "avi" Or vExt = "mpg" Or vExt = "divx" Or vExt = "rm" Or vExt = "ogm" Or vExt = "avc" Or vExt = "flv" Or vExt = "mkv" Or vExt = "mp4" Or vExt = "m2ts" Then
                form.plugins.InstallmouseHooks()
                sourceActivo = MPEG
                pistaid3 = darNombrePista(True)
                abrirVentanaVideo()
                reproductorMPEG.openMovieWindow(form.vetaVideo.DibujoVideo.Handle, "Child")
                form.vetaVideo.resise()
                tipo = VIDEO
            Else

                Return False

            End If


            If clipon And clipini < reproductorMPEG.getLengthInMS Then reproductorMPEG.setPositionTo(clipini)
            reproduciract()
            Return True
        Catch es As Exception
            Console.WriteLine(es.Message)
            Return False
        End Try
    End Function
    Public Function labelTagPoc(ByVal tgs As Id3Reader.MP3) As String

        If removEmpty(tgs.id3Artist) = String.Empty And removEmpty(tgs.id3Title) = String.Empty And removEmpty(tgs.id3Album) = String.Empty Then
            Return removEmpty(darNombrePista(True))
        ElseIf removEmpty(tgs.id3Artist) = String.Empty And removEmpty(tgs.id3Title) = String.Empty Then
            Return removEmpty(darNombrePista(True)) & " - " & removEmpty(tgs.id3Album)
        ElseIf removEmpty(tgs.id3Artist) = String.Empty And removEmpty(tgs.id3Album) = String.Empty Then
            Return removEmpty(tgs.id3Title)
        ElseIf removEmpty(tgs.id3Title) = String.Empty And removEmpty(tgs.id3Album) = String.Empty Then
            Return removEmpty(tgs.id3Artist) & " - " & removEmpty(darNombrePista(True))

        ElseIf removEmpty(tgs.id3Artist) = String.Empty Then

            Return removEmpty(tgs.id3Title) & " - " & removEmpty(tgs.id3Album) & " - " & darNombrePista(True)

        ElseIf removEmpty(tgs.id3Title) = String.Empty Then
            Return removEmpty(tgs.id3Artist) & " - " & removEmpty(darNombrePista(True)) & " - " & removEmpty(tgs.id3Album)
        ElseIf removEmpty(tgs.id3Album) = String.Empty Then
            Return removEmpty(tgs.id3Artist) & " - " & removEmpty(tgs.id3Title)
        Else

            Return removEmpty(tgs.id3Artist) & " - " & removEmpty(tgs.id3Title) & " - " & removEmpty(tgs.id3Album)

        End If


    End Function
    Public Function removEmpty(ByVal str As String) As String
        Dim sb As New System.Text.StringBuilder(str.Length)

        For Each i As Char In str
            If i <> Chr(0) And i <> Chr(255) Then
                sb.Append(i)
            End If
        Next


        Return sb.ToString()

    End Function
    Private Sub abrirVentanaVideo()

        form.vetaVideo = New FormVideo()
        form.vetaVideo.FormBorderStyle = videosets(4)
        form.vetaVideo.WindowState = videosets(5)
        form.vetaVideo.Left = videosets(0)
        form.vetaVideo.Top = videosets(1)
        form.vetaVideo.Width = videosets(2)
        form.vetaVideo.Height = videosets(3)
        form.vetaVideo.TopMost = videosets(6)

        form.vetaVideo.princ = form


        form.vetaVideo.Show(form)
    End Sub

    Private Sub cerrarVentanaVideo()
        If form.vetaVideo.WindowState <> FormWindowState.Maximized Then
            videosets(0) = form.vetaVideo.Location.X
            videosets(1) = form.vetaVideo.Location.Y
            videosets(2) = form.vetaVideo.Size.Width
            videosets(3) = form.vetaVideo.Size.Height

        End If
        videosets(4) = form.vetaVideo.FormBorderStyle
        videosets(5) = form.vetaVideo.WindowState
        videosets(6) = form.vetaVideo.TopMost
        form.vetaVideo.Dispose()
    End Sub
    Public Sub reproduciract()
        reproductorMPEG.playMovie()
    End Sub
    Public Sub pausa()
        If sourceActivo = RADIO Then
            reproductorRadio.untune()
        ElseIf sourceActivo = DVD Then
            dvdplayer.pararPlayback()
        Else
            reproductorMPEG.pauseMovie()
        End If

    End Sub
    Public Sub parar()
        reproductorMPEG.closeMovie()
        dvdplayer.cerrarDVD()
        cerrarVentanaVideo()
    End Sub
    Public Sub proseg()
        If sourceActivo = RADIO Then
            reproductorRadio.resumetune()
            If reproductorMPEG.mute Then
                reproductorRadio.setvolum(0)
            Else
                reproductorRadio.setvolum(form.volBar.Value * 10)
            End If

        ElseIf sourceActivo = DVD Then
            dvdplayer.continuarReproduccion()
        Else
            reproductorMPEG.resumeMovie()
        End If

    End Sub
    Public Sub adelantaratrazar(ByVal atras As Boolean, ByVal ms As Integer)

        backwrd = atras
        fordwval = ms


    End Sub
    Public Sub adelantaccion()

        If backwrd Then
            If sourceActivo = DVD Then
                If fordwval = 0 Then
                    dvdplayer.atrazarNFrames(1)
                Else
                    dvdplayer.atrazarNFrames(fordwval / 1000)
                End If

            Else
                reproductorMPEG.forwardByMS(fordwval * -1)
            End If

        Else
            If sourceActivo = DVD Then
                If fordwval = 0 Then
                    dvdplayer.adelantarNFrames(1)
                Else
                    dvdplayer.adelantarNFrames(fordwval / 1000)
                End If

            Else
                reproductorMPEG.forwardByMS(fordwval)
            End If

        End If
    End Sub
End Class
