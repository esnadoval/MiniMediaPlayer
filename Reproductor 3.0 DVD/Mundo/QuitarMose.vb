Option Explicit On
Public Class QuitarMose

    '
    ' When SetCursor is called a value of
    ' True : increments the cursor internal value by 1
    ' False : decrements the cursor internal value by 1
    ' The cursor internal value is the SetCusor return value
    '
    ' If the cursor internal value is negative then the cursor is invisible
    ' otherwise it is visible
    '
    ' This means that just calling SetCursor with True may not make the cursor visible
    ' as the cursor internal value may be -7 and calling SetCursor(True) increases
    ' the cursor internal value to -6, which is still an invisible state
    '
    Private Enum CursorEnum
        Hide = False ' Hide cursor state
        Show = True ' Show cursor state
        Toggle = 2 ' Opposite of last cursor state
    End Enum

    Private Declare Function ShowCursor Lib "user32" _
        (ByVal bShow As Long) As Long

    Dim blnMvCursorState As Boolean ' Keep track of last cursor state
    Dim lngMvInternalCounter As Long ' Internal cursor counter
    Public Sub inicializar(ByVal ini As Boolean)
        blnMvCursorState = ini
    End Sub
    Public Sub mostrar()
        Call SetCursorState(CursorEnum.Show)
    End Sub
    Public Sub desaparecer()
        Call SetCursorState(CursorEnum.Hide)
    End Sub
    Private Function SetCursorState(Optional ByVal enmVvOverRide As CursorEnum = CursorEnum.Toggle) As Boolean
        ' Force Cursor state by ensuring that internal cursor counter is set to
        ' -1 to make the cursor invisible
        ' 0 to make the cursor visible
        ' Value of internal cursor counter at which cursor is invisible
        Const lngLcCURSOR_OFF_VALUE As Long = -1
        ' Value of internal cursor counter at which cursor is visible
        Const lngLcCURSOR_ON_VALUE As Long = 0
        '
        Dim blnLvCursorState As Boolean
        Dim lngLvRequiredCursorValue As Long
        ' Set Cursor State
        If enmVvOverRide = CursorEnum.Toggle Then
            ' Reverse state of cursor
            blnMvCursorState = Not blnMvCursorState
        Else
            ' Implicit cursor state
            blnMvCursorState = enmVvOverRide
        End If
        ' Make sure that SetCursor will have the correct value sent to it
        ' and that the correct value for the cursor internal value is reached
        If blnMvCursorState Then
            blnLvCursorState = IIf(lngMvInternalCounter > lngLcCURSOR_ON_VALUE, False, True)
            lngLvRequiredCursorValue = lngLcCURSOR_ON_VALUE
        Else
            blnLvCursorState = IIf(lngMvInternalCounter > lngLcCURSOR_OFF_VALUE, False, True)
            lngLvRequiredCursorValue = lngLcCURSOR_OFF_VALUE
        End If
        ' Force internal cursor count movement in wrong direction
        ' to ensure that ShowCursor to be called at least once
        lngMvInternalCounter = ShowCursor(Not blnLvCursorState)
        ' Update internal cursor counter until correct cursor state reached
        Do While lngMvInternalCounter <> lngLvRequiredCursorValue
            lngMvInternalCounter = ShowCursor(blnLvCursorState)
        Loop
    End Function

End Class
