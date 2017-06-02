Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Public Class GlobalHook
    Implements IDisposable

#Region "Public Events"

    Public Event MouseDown As MouseEventHandler
    Public Event MouseMove As MouseEventHandler
    Public Event MouseUp As MouseEventHandler
    Public Event MouseWheel As MouseEventHandler

    Public Event KeyDown As KeyEventHandler
    Public Event KeyPress As KeyPressEventHandler
    Public Event KeyUp As KeyEventHandler

#End Region

#Region "ctor/dtor"

    Private disposed As Boolean = False        ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposed Then
            If disposing Then

            End If
            Me.RemoveHooks()
        End If
        Me.disposed = True
    End Sub

    Protected Overrides Sub Finalize()
        Dispose(False)
        MyBase.Finalize()
    End Sub

    Public Sub Dispose() Implements System.IDisposable.Dispose
        Me.Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

#End Region

#Region "Event Triggers"

    Protected Overridable Sub OnMouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        If Not MouseDownEvent Is Nothing Then
            RaiseEvent MouseDown(sender, e)
        End If
    End Sub

    Protected Overridable Sub OnMouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
        If Not MouseMoveEvent Is Nothing Then
            RaiseEvent MouseMove(sender, e)
        End If
    End Sub

    Protected Overridable Sub OnMouseUp(ByVal sender As Object, ByVal e As MouseEventArgs)
        If Not MouseUpEvent Is Nothing Then
            RaiseEvent MouseUp(sender, e)
        End If
    End Sub

    Protected Overridable Sub OnMouseWheel(ByVal sender As Object, ByVal e As MouseEventArgs)
        If Not MouseWheelEvent Is Nothing Then
            RaiseEvent MouseWheel(sender, e)
        End If
    End Sub

    Protected Overridable Sub OnKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        If Not KeyDownEvent Is Nothing Then
            For Each handler As KeyEventHandler In KeyDownEvent.GetInvocationList
                handler.Invoke(Me, e)
                If e.Handled Then
                    Exit For
                End If
            Next
        End If
    End Sub

    Protected Overridable Sub OnKeyUp(ByVal sender As Object, ByVal e As KeyEventArgs)
        If Not KeyUpEvent Is Nothing Then
            For Each handler As KeyEventHandler In KeyUpEvent.GetInvocationList
                handler.Invoke(Me, e)
                If e.Handled Then
                    Exit For
                End If
            Next
        End If
    End Sub

    Protected Overridable Sub OnKeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        If Not KeyPressEvent Is Nothing Then
            For Each handler As KeyPressEventHandler In KeyPressEvent.GetInvocationList
                handler.Invoke(Me, e)
                If e.Handled Then
                    Exit For
                End If
            Next
        End If
    End Sub

#End Region

#Region "Fields"

    Private Shared hMouseHook As Integer = 0
    Private Shared hKeyboardHook As Integer = 0

    Private MouseHookProcedure As Win32.HookProc
    Private KeyboardHookProcedure As Win32.HookProc

#End Region

#Region "Public Methods"
    Public Sub installmousehooks()
        If hMouseHook = 0 Then
            MouseHookProcedure = New Win32.HookProc(AddressOf MouseHookProc)

            hMouseHook = Win32.SetWindowsHookEx( _
                Win32.WH.WH_MOUSE_LL, _
                MouseHookProcedure, _
                Marshal.GetHINSTANCE(Reflection.Assembly.GetExecutingAssembly().GetModules()(0)), _
                0)

            If hMouseHook = 0 Then 'SetWindowsHookEx failed
                RemoveHooks()
                'Throw New Exception("SetWindowsHookEx failed.")
            End If
        End If
    End Sub
    Public Sub InstallHooks()
        

        If hKeyboardHook = 0 Then ' install Keyboard hook 
            KeyboardHookProcedure = New Win32.HookProc(AddressOf KeyboardHookProc)
            hKeyboardHook = Win32.SetWindowsHookEx( _
                Win32.WH.WH_KEYBOARD_LL, _
                KeyboardHookProcedure, _
                Marshal.GetHINSTANCE(Reflection.Assembly.GetExecutingAssembly().GetModules()(0)), _
                0)

            If (hKeyboardHook = 0) Then 'SetWindowsHookEx failed
                RemoveHooks()
                'Throw New Exception("SetWindowsHookEx failed.")
            End If
        End If
    End Sub
    Public Sub removemousehooks()
        Dim mouseResult As Boolean = True
        Dim keyboardResult As Boolean = True

        If hMouseHook <> 0 Then
            mouseResult = Win32.UnhookWindowsHookEx(hMouseHook)
            hMouseHook = 0
        End If
        If Not (mouseResult AndAlso keyboardResult) Then 'UnhookWindowsHookEx failed
            'Throw New Exception("UnhookWindowsHookEx failed.")
        End If
    End Sub

    Public Sub RemoveHooks()

        Dim keyboardResult As Boolean = True


        If hKeyboardHook <> 0 Then
            keyboardResult = Win32.UnhookWindowsHookEx(hKeyboardHook)
            hKeyboardHook = 0
        End If

     
    End Sub

#End Region

#Region "Mouse Methods"

    Private Shared Function GetMouseButtonFlag( _
        ByVal wParam As Integer, ByVal hiWord As Integer) As MouseButtons

        Select Case (wParam)
            Case _
                Win32.WM.WM_LBUTTONDOWN, _
                Win32.WM.WM_LBUTTONUP, _
                Win32.WM.WM_LBUTTONDBLCLK
                Return MouseButtons.Left

            Case Win32.WM.WM_MBUTTONDOWN, _
                Win32.WM.WM_MBUTTONUP, _
                Win32.WM.WM_MBUTTONDBLCLK
                Return MouseButtons.Middle

            Case Win32.WM.WM_RBUTTONDOWN, _
                Win32.WM.WM_RBUTTONUP, _
                Win32.WM.WM_RBUTTONDBLCLK
                Return MouseButtons.Right

            Case _
                Win32.WM.WM_XBUTTONDOWN, _
                Win32.WM.WM_XBUTTONUP, _
                Win32.WM.WM_XBUTTONDBLCLK, _
                Win32.WM.WM_NCXBUTTONDOWN, _
                Win32.WM.WM_NCXBUTTONUP, _
                Win32.WM.WM_NCXBUTTONDBLCLK

                If hiWord = 1 Then
                    Return MouseButtons.XButton1
                ElseIf hiWord = 2 Then
                    Return MouseButtons.XButton2
                End If
        End Select
        Return MouseButtons.None

    End Function

    Private Shared Function GetDelta(ByVal wParam As Integer, ByVal hiWord As Integer) As Integer
        If wParam = Win32.WM.WM_MOUSEWHEEL Then
            Return hiWord
        Else
            Return 0
        End If
    End Function

    Private Shared Function GetClickCount(ByVal wParam As Integer, ByVal buttons As MouseButtons) As Integer

        If buttons <> MouseButtons.None Then
            Select Case wParam
                Case _
                    Win32.WM.WM_LBUTTONDBLCLK, _
                    Win32.WM.WM_MBUTTONDBLCLK, _
                    Win32.WM.WM_RBUTTONDBLCLK, _
                    Win32.WM.WM_XBUTTONDBLCLK
                    Return 2
                Case Else
                    Return 1
            End Select
        End If
        Return 0

    End Function

    Private Shared Function CreateMouseEventArgs(ByVal wParam As Integer, ByVal lParam As IntPtr) As MouseEventArgs

        Dim clickCount As Integer
        Dim buttons As MouseButtons
        Dim mhs As New Win32.MSLLHOOKSTRUCT
        Dim hiWord As Integer
        Dim delta As Integer

        Marshal.PtrToStructure(lParam, mhs)
        hiWord = Win32.HIWORD(mhs.mouseData)
        buttons = GetMouseButtonFlag(wParam, hiWord)
        delta = GetDelta(wParam, hiWord)
        clickCount = GetClickCount(wParam, buttons)

        Return New MouseEventArgs(buttons, clickCount, mhs.pt.X, mhs.pt.Y, delta)

    End Function

    Private Function MouseHookProc(ByVal nCode As Integer, ByVal wParam As Integer, ByVal lParam As IntPtr) As Integer
        If nCode >= 0 Then
            Select Case wParam
                Case _
                    Win32.WM.WM_LBUTTONDOWN, _
                    Win32.WM.WM_LBUTTONDBLCLK, _
                    Win32.WM.WM_MBUTTONDOWN, _
                    Win32.WM.WM_MBUTTONDBLCLK, _
                    Win32.WM.WM_RBUTTONDOWN, _
                    Win32.WM.WM_RBUTTONDBLCLK, _
                    Win32.WM.WM_XBUTTONDOWN, _
                    Win32.WM.WM_XBUTTONDBLCLK

                    ' avoid overhead of creating event args if event not handled
                    If Not MouseDownEvent Is Nothing Then
                        Dim e As MouseEventArgs = CreateMouseEventArgs(wParam, lParam)
                        OnMouseDown(Me, e)
                    End If

                Case _
                    Win32.WM.WM_LBUTTONUP, _
                    Win32.WM.WM_MBUTTONUP, _
                    Win32.WM.WM_RBUTTONUP, _
                    Win32.WM.WM_XBUTTONUP

                    ' avoid overhead of creating event args if event not handled
                    If Not MouseUpEvent Is Nothing Then
                        Dim e As MouseEventArgs = CreateMouseEventArgs(wParam, lParam)
                        OnMouseUp(Me, e)
                    End If

                Case Win32.WM.WM_MOUSEWHEEL

                    ' avoid overhead of creating event args if event not handled
                    If Not MouseWheelEvent Is Nothing Then
                        Dim e As MouseEventArgs = CreateMouseEventArgs(wParam, lParam)
                        OnMouseWheel(Me, e)
                    End If

                Case Win32.WM.WM_MOUSEMOVE

                    ' avoid overhead of creating event args if event not handled
                    If Not MouseMoveEvent Is Nothing Then
                        Dim e As MouseEventArgs = CreateMouseEventArgs(wParam, lParam)
                        OnMouseMove(Me, e)
                    End If

            End Select
        End If

        Return Win32.CallNextHookEx(hMouseHook, nCode, wParam, lParam)
    End Function

#End Region

    Private Function CreateKeyEventArgs(ByVal khs As Win32.KeyboardHookStruct) As KeyEventArgs
        Dim ctrl As Keys
        If Win32.IsKeyDown(Keys.ControlKey) Then
            ctrl = Keys.Control
        End If
        Dim alt As Keys
        If Win32.IsKeyDown(Keys.Menu) Then
            alt = Keys.Alt
        End If
        Dim shift As Keys
        If Win32.IsKeyDown(Keys.ShiftKey) Then
            shift = Keys.Shift
        End If

        Dim keyCode As Keys = CType(khs.vkCode, Keys)
        Dim e As New KeyEventArgs(keyCode Or ctrl Or alt Or shift)
        Return e
    End Function

    Private Function FireKeyPress(ByVal wParam As Integer, ByVal khs As Win32.KeyboardHookStruct, ByVal e As KeyEventArgs) As Boolean
        If wParam = Win32.WM.WM_SYSKEYDOWN Then
            Return False
        Else
            Dim inBuffer(2) As Byte
            Dim keyState(256) As Byte
            Win32.GetKeyboardState(keyState)

            If Win32.ToAscii(khs.vkCode, khs.scanCode, keyState, inBuffer, khs.flags) > 0 Then
                Dim args As New KeyPressEventArgs(BitConverter.ToChar(inBuffer, 0))
                OnKeyPress(Me, args)
                Return e.Handled
            End If
        End If
        Return False
    End Function

    Private Sub CheckForKeyDown(ByVal wParam As Integer, ByVal lParam As IntPtr, ByRef handled As Boolean, ByRef khs As Win32.KeyboardHookStruct)
        If Not KeyDownEvent Is Nothing Then
            khs = New Win32.KeyboardHookStruct
            Marshal.PtrToStructure(lParam, khs)

            Dim e As KeyEventArgs = CreateKeyEventArgs(khs)
            Me.OnKeyDown(Me, e)

            handled = e.Handled

            If Not handled Then
                handled = FireKeyPress(wParam, khs, e)
            End If
        End If
    End Sub

    Private Sub CheckForKeyUp(ByVal wParam As Integer, ByVal lParam As IntPtr, ByRef handled As Boolean, ByVal khs As Win32.KeyboardHookStruct)
        If Not KeyUpEvent Is Nothing Then
            If khs Is Nothing Then
                khs = New Win32.KeyboardHookStruct
                Marshal.PtrToStructure(lParam, khs)
            End If

            Dim keyData As Keys = CType(khs.vkCode, Keys)
            Dim e As New KeyEventArgs(keyData)
            OnKeyUp(Me, e)
            handled = e.Handled
        End If
    End Sub

    Private Function KeyboardHookProc( _
                        ByVal nCode As Integer, ByVal wParam As Integer, _
                        ByVal lParam As IntPtr) As Integer

        Dim handled As Boolean = False

        If nCode >= 0 Then
            Dim khs As Win32.KeyboardHookStruct

            If wParam = Win32.WM.WM_KEYDOWN OrElse wParam = Win32.WM.WM_SYSKEYDOWN Then
                CheckForKeyDown(wParam, lParam, handled, khs)
            ElseIf wParam = Win32.WM.WM_KEYUP OrElse wParam = Win32.WM.WM_SYSKEYUP Then
                CheckForKeyUp(wParam, lParam, handled, khs)
            End If
        End If

        If handled Then
            Return -1
        Else
            Return Win32.CallNextHookEx(hKeyboardHook, nCode, wParam, lParam)
        End If
    End Function

End Class
