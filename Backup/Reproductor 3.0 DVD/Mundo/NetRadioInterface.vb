Imports System.Runtime.InteropServices
Imports Radio

Public Class NetRadioInterface
    Implements IRadioListener
    Public opened As Boolean = False
    Public lasturl As String = ""
    Public radio As NetRadio
    Dim trd As Threading.Thread
    Public parent As Principal

    Public title As String
    Public artist As String
    Public station As String
    Public status As String
    Private lastvol As String
    Public Sub initializeRadio()

        openInstance()
    End Sub
    Private Sub openInstance()
        radio = New NetRadio(parent, Me)
        radio.NetRadio_Load()
    End Sub
    Public Sub tune(ByVal url As String)
        lasturl = url

        opened = True
        Try
            trd.Abort()
        Catch ex As Exception

        End Try


        trd = New Threading.Thread(AddressOf tuneAsync)
        trd.IsBackground = True
        trd.Start()

    End Sub
    Private Sub tuneAsync()

        radio.playRadio(lasturl)
        radio.setVolum(lastvol)
    End Sub


    Public Sub cls()
        opened = False
        radio.stopRadio()
    End Sub
    Public Sub resumetune()
        opened = True
        tune(lasturl)

    End Sub
    Public Sub untune(Optional ByVal noread As Boolean = False)
        opened = False
        radio.stopRadio()
    End Sub
    Public Function record() As Boolean
        Dim reply As DialogResult = MessageBox.Show("Desea grabar cada pista separadamente?", "Grabar radio", _
                      MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)

        If reply = DialogResult.Yes Then
            Dim FolderBrowserDialog1 As New FolderBrowserDialog

            ' Then use the following code to create the Dialog window
            ' Change the .SelectedPath property to the default location
            With FolderBrowserDialog1
                ' Desktop is the root folder in the dialog.
                '.RootFolder = System.AppDomain.CurrentDomain.BaseDirectory()

                .SelectedPath = System.AppDomain.CurrentDomain.BaseDirectory()

                .Description = "Seleccione el Directorio Donde se guardaran las pistas."
                If .ShowDialog = DialogResult.OK Then
                    radio.recordTracking(.SelectedPath)
                    Return True
                End If
            End With
        Else
            Dim CommonDialog1 As SaveFileDialog
            CommonDialog1 = New SaveFileDialog()
            CommonDialog1.InitialDirectory = System.AppDomain.CurrentDomain.BaseDirectory()
            CommonDialog1.Filter = "Mp3 Files (*.mp3)|*.mp3"
            ' Specify default filter.
            CommonDialog1.FilterIndex = 0

            ' Display the Open dialog box.
            CommonDialog1.ShowDialog()

            If Not (CommonDialog1.FileName.Equals("")) Then
                radio.recordContinuous(CommonDialog1.FileName)
                Return True
            End If
        End If
        Return False
    End Function
    Public Sub stoprecord()
        radio.stopRecord()
    End Sub
    Public Function getInfo() As String()
     
    End Function
    Public Sub setvolum(ByVal level As String)


        lastvol = level
        radio.setVolum(level)


    End Sub

    Public Sub updateTag() Implements IRadioListener.tagUpdate
        title = radio._Title
        artist = radio._Artist
        station = radio._radioName
        parent.radioTagUpdate()
    End Sub
    Public Sub updateMessage() Implements IRadioListener.messagesUpdate
        'title = radio._Title
        'artist = radio._Artist
        'station = radio._radioName
        'parent.radioStatusUpdate()
    End Sub
    Public Sub updateStatus() Implements IRadioListener.statusUpdate

        status = radio._buffering
        parent.radioStatusUpdate()
    End Sub
End Class