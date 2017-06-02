Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.IO
Imports System.Windows.Forms

Public Class Id3Reader
    Public Sub readMP3Tag(ByRef paramMP3 As MP3)
        ' Read the 128 byte ID3 tag into a byte array
        Dim oFileStream As FileStream
        oFileStream = New FileStream(paramMP3.fileComplete, FileMode.Open, FileAccess.Read)
        Dim bBuffer As Byte() = New Byte(127) {}
        oFileStream.Seek(-128, SeekOrigin.[End])
        oFileStream.Read(bBuffer, 0, 128)
        oFileStream.Close()

        ' Convert the Byte Array to a String
        Dim instEncoding As Encoding = New ASCIIEncoding()
        ' NB: Encoding is an Abstract class
        Dim id3Tag As String = instEncoding.GetString(bBuffer)


        ' If there is an attched ID3 v1.x TAG then read it 
        If id3Tag.Substring(0, 3) = "TAG" Then
            paramMP3.fileType = paramMP3.fileFileName.Substring(paramMP3.fileFileName.Length - 4, 4).Trim()
            paramMP3.id3Title = id3Tag.Substring(3, 30).Trim()
            paramMP3.id3Artist = id3Tag.Substring(33, 30).Trim()
            paramMP3.id3Album = id3Tag.Substring(63, 30).Trim()
            paramMP3.id3Year = id3Tag.Substring(93, 4).Trim()
            paramMP3.id3Comment = id3Tag.Substring(97, 28).Trim()

            ' Get the track number if TAG conforms to ID3 v1.1
            If id3Tag(125) = ChrW("0") Then
                paramMP3.id3TrackNumber = bBuffer(126)
            Else
                paramMP3.id3TrackNumber = 0
            End If
            paramMP3.id3Genre = bBuffer(127)
            ' ********* IF USED IN ANGER: ENSURE to test for non-numeric year
            paramMP3.hasID3Tag = True
        Else
            ' ID3 Tag not found so create an empty TAG in case the user saces later
            paramMP3.id3Title = ""
            paramMP3.id3Artist = ""
            paramMP3.id3Album = ""
            paramMP3.id3Year = ""
            paramMP3.id3Comment = ""
            paramMP3.id3TrackNumber = 0
            paramMP3.id3Genre = 0
            paramMP3.hasID3Tag = False
        End If
    End Sub

    Public Shared Sub updateMP3Tag(ByRef paramMP3 As MP3)
        ' Trim any whitespace
        paramMP3.id3Title = paramMP3.id3Title.Trim()
        paramMP3.id3Artist = paramMP3.id3Artist.Trim()
        paramMP3.id3Album = paramMP3.id3Album.Trim()
        paramMP3.id3Year = paramMP3.id3Year.Trim()
        paramMP3.id3Comment = paramMP3.id3Comment.Trim()

        ' Ensure all properties are correct size
        If paramMP3.id3Title.Length > 30 Then
            paramMP3.id3Title = paramMP3.id3Title.Substring(0, 30)
        End If
        If paramMP3.id3Artist.Length > 30 Then
            paramMP3.id3Artist = paramMP3.id3Artist.Substring(0, 30)
        End If
        If paramMP3.id3Album.Length > 30 Then
            paramMP3.id3Album = paramMP3.id3Album.Substring(0, 30)
        End If
        If paramMP3.id3Year.Length > 4 Then
            paramMP3.id3Year = paramMP3.id3Year.Substring(0, 4)
        End If
        If paramMP3.id3Comment.Length > 28 Then
            paramMP3.id3Comment = paramMP3.id3Comment.Substring(0, 28)
        End If

        ' Build a new ID3 Tag (128 Bytes)
        Dim tagByteArray As Byte() = New Byte(127) {}
        For i As Integer = 0 To tagByteArray.Length - 1
            tagByteArray(i) = 0
        Next
        ' Initialise array to nulls
        ' Convert the Byte Array to a String
        Dim instEncoding As Encoding = New ASCIIEncoding()
        ' NB: Encoding is an Abstract class // ************ To DO: Make a shared instance of ASCIIEncoding so we don't keep creating/destroying it
        ' Copy "TAG" to Array
        Dim workingByteArray As Byte() = instEncoding.GetBytes("TAG")
        Array.Copy(workingByteArray, 0, tagByteArray, 0, workingByteArray.Length)
        ' Copy Title to Array
        workingByteArray = instEncoding.GetBytes(paramMP3.id3Title)
        Array.Copy(workingByteArray, 0, tagByteArray, 3, workingByteArray.Length)
        ' Copy Artist to Array
        workingByteArray = instEncoding.GetBytes(paramMP3.id3Artist)
        Array.Copy(workingByteArray, 0, tagByteArray, 33, workingByteArray.Length)
        ' Copy Album to Array
        workingByteArray = instEncoding.GetBytes(paramMP3.id3Album)
        Array.Copy(workingByteArray, 0, tagByteArray, 63, workingByteArray.Length)
        ' Copy Year to Array
        workingByteArray = instEncoding.GetBytes(paramMP3.id3Year)
        Array.Copy(workingByteArray, 0, tagByteArray, 93, workingByteArray.Length)
        ' Copy Comment to Array
        workingByteArray = instEncoding.GetBytes(paramMP3.id3Comment)
        Array.Copy(workingByteArray, 0, tagByteArray, 97, workingByteArray.Length)
        ' Copy Track and Genre to Array
        tagByteArray(126) = paramMP3.id3TrackNumber
        tagByteArray(127) = paramMP3.id3Genre

        ' SAVE TO DISK: Replace the final 128 Bytes with our new ID3 tag
        Dim oFileStream As New FileStream(paramMP3.fileComplete, FileMode.Open)
        If paramMP3.hasID3Tag Then
            oFileStream.Seek(-128, SeekOrigin.[End])
        Else
            oFileStream.Seek(0, SeekOrigin.[End])
        End If
        oFileStream.Write(tagByteArray, 0, 128)
        oFileStream.Close()
        paramMP3.hasID3Tag = True
    End Sub
    Public Structure MP3
        Public filePath As String
        Public fileFileName As String
        Public fileComplete As String
        Public hasID3Tag As Boolean
        Public id3Title As String
        Public id3Artist As String
        Public id3Album As String
        Public id3Year As String
        Public id3Comment As String
        Public id3TrackNumber As Byte
        Public id3Genre As Byte
        Public fileType As String

        ' Required struct constructor
        Public Sub New(ByVal path As String, ByVal name As String)
            Me.filePath = path
            Me.fileFileName = name
            Me.fileComplete = path & "\" & name
            Me.hasID3Tag = False
            Me.id3Title = Nothing
            Me.id3Artist = Nothing
            Me.id3Album = Nothing
            Me.id3Year = Nothing
            Me.id3Comment = Nothing
            Me.id3TrackNumber = 0
            Me.id3Genre = 0
            Me.fileType = Nothing
        End Sub
    End Structure
End Class



