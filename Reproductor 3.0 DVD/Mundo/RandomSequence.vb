Public Class RandomSequence
    Public _holder() As Integer
    Public _maxValue As Integer
    Public _lastIndex As Integer
    Private _rand As New Random

    Public Sub New(ByVal maxValue As Integer)
        If (maxValue < 0) Then
            Throw New ArgumentOutOfRangeException("maxValue")
        End If

        ReDim _holder(maxValue)
        Array.Clear(_holder, 0, maxValue)
        _maxValue = maxValue
        _lastIndex = 0
    End Sub

    Public Function NextValue() As Integer
        Dim value As Integer

        If _lastIndex = _maxValue Then
            Return -1 ' no hya mas valores
        End If

        Do
            value = _rand.Next(_maxValue)
        Loop Until _holder(value) = 0

        _holder(value) = 1
        _lastIndex += 1
        Console.WriteLine(persistString())
        Return value
    End Function

    Public Sub Reset()
        _lastIndex = 0
        Array.Clear(_holder, 0, _maxValue)
    End Sub
    Public Function persistString() As String
        Try
            Dim tmp As String = _holder(0)
            For i = 1 To _holder.Length - 1
                tmp = tmp & ";" & _holder(i)
            Next

            Return tmp & "|" & _lastIndex & "|" & _maxValue
        Catch ex As Exception
            Return "|" & _lastIndex & "|" & _maxValue
        End Try

    End Function
    Public Shared Function rndGenFromString(ByVal chn As String) As RandomSequence
        Try

            Dim max() As String = chn.Split("|")
            Dim hold() As String = max(0).Split(";")

            Dim nrand As New RandomSequence(max(2))

            nrand._lastIndex = max(1)


            For i = 0 To nrand._holder.Length - 1
                nrand._holder(i) = hold(i)
            Next

            Return nrand
        Catch ex As Exception
            Throw New Exception("Failed to create rnd generator")
        End Try

    End Function

End Class