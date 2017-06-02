
Option Explicit On
Option Strict Off
Public Class CommandBuffer

    Public dinbuff As New ArrayList
    Public main As Plugins
    Dim lastcmd As Integer = 0
    Dim delay As Integer = 0
    Dim flagover As Boolean = False
    Dim maxkeys As Integer = 7
    Dim initkey As Integer = 0


    Public Sub New(ByVal forms As Plugins)
        main = forms
    End Sub


    Public Sub addcharr(ByVal chr As Integer)
        If dinbuff.Count = 0 Then initkey = chr
        If buscarChar(chr) = -1 And delay < maxkeys Then
            flagover = False

            dinbuff.Add(chr)

        Else
            If delay >= maxkeys Then
                If Not flagover Then
                    keyCommandDown()
                    lastcmd = createCmdID()
                End If

                delay = maxkeys
            End If

        End If
        delay = delay + 1
    End Sub
    Public Function createCmdID() As Integer
        Dim ids As Integer
        For Each num As Integer In dinbuff
            ids = ids + num
        Next

        


   
    End Function
    Public Function buscarChar(ByVal chr As Integer) As Integer
        Dim i As Integer
        For i = 0 To dinbuff.Count - 1
            If CInt(dinbuff.Item(i)) = chr Then Return i
        Next
        Return -1
    End Function

    Public Sub removecharr(ByVal chr As Integer)
        Dim asd As Integer = buscarChar(chr)
        If asd <> -1 Then
            flagover = True
            If delay < maxkeys Then
                lastcmd = lastcmd + chr
            End If

            dinbuff.RemoveAt(asd)

        End If

        If dinbuff.Count = 0 And lastcmd <> 0 Then
            If lastcmd <= 255 Then lastcmd = initkey
            If delay < maxkeys Then
                keyCommandDownNoDel()
            End If
            keyCommandPressed()

            delay = 0
        End If

    End Sub

    Public Sub keyCommandDownNoDel()
        main.downKey(lastcmd)
    End Sub
    Public Sub keyCommandPressed()
        main.pressKey(lastcmd)
        lastcmd = 0

    End Sub
    Public Sub keyCommandDown()
        main.downKey(createCmdID)
    End Sub
End Class


