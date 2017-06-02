Option Explicit On
Public Class Reproduccion

    Private Declare Function mciGetErrorString Lib "winmm.dll" Alias "mciGetErrorStringA" (ByVal dwError As Long, ByVal lpstrBuffer As String, ByVal uLength As Long) As Long 'Get the error message of the mcidevice if any
    Private Declare Function mciSendString Lib "winmm.dll" Alias "mciSendStringA" (ByVal lpstrCommand As String, ByVal lpstrReturnString As String, ByVal uReturnLength As Long, ByVal hwndCallback As Long) As Long 'Send command strings to the mci device
    Public Declare Function mciSendCommand Lib "winmm.dll" Alias "mciSendCommandA" (ByVal wDeviceID As Integer, ByVal uMessage As String, ByVal dwParam1 As Integer, ByVal dwParam2 As Object) As Integer


    Dim Data As String = Space(128) ' Used to store our return data
    Public errors As Long = 0 ' Used to store our error message
    Public Filename As String ' Used to store our file
    Public playing As Boolean
    Public volume As Integer = 1000
    Public paused As Boolean = False
    Public mute As Boolean = False


    Public Function stepFrames(ByVal Value As Long) As Integer
        'Step ahead a specified amount of frames
        'Ex. If the movie was on frame 20. And if you stepped
        '10 frames the movie would skip ahead 10 frames and
        'would be on frame 30.
        errors = mciSendString("step movie by " & Value, 0, 0, 0)
        Return 0
    End Function
    Public Function restoreSizeDefault() As Integer
        'This function will restore the movie to its original
        'size. Not if you use a child window
        errors = mciSendString("put movie window", 0, 0, 0)
        Return 0
    End Function
    Public Function openMovie() As Boolean
        'Open a movie in the default window style(Popup)
        'Dim a As Long
        'Filename = Chr$(34) & Filename & Chr$(34)
        paused = False
        errors = mciSendString("close movie", 0, 0, 0)
        'Decide which way you want the mci device to work below
        'Specify the mpegvideo driver to play the movies
        errors = mciSendString("open " & ChrW(34) & Filename & ChrW(34) & " type mpegvideo alias movie", 0, 0, 0)
        SetFormat_milliseconds()


        SetVolume(volume)
        If mute Then setAudioOff() Else setAudioOn()
        'Let the mci device decide which driver to use
        'Error = mciSendString("open " & Filename & " alias movie", 0, 0, 0)
        Return True
    End Function
    Public Function openAudioCD() As Boolean
        'Open a movie in the default window style(Popup)
        'Dim a As Long
        'Filename = Chr$(34) & Filename & Chr$(34)
        paused = False
        errors = mciSendString("close movie", 0, 0, 0)
        'Decide which way you want the mci device to work below
        'Specify the mpegvideo driver to play the movies
        errors = mciSendString("open cdaudio alias movie wait shareable", 0, 0, 0)

        SetFormat_hms()


        SetVolume(volume)
        If mute Then setAudioOff() Else setAudioOn()
        'Let the mci device decide which driver to use
        'Error = mciSendString("open " & Filename & " alias movie", 0, 0, 0)
        Return True
    End Function
    Public Function openMovieWindow(ByVal hWnd As Long, ByVal WindowStyle As String) As Integer
        'Style types = popup , child or overlapped
        'Child window would be a .hwnd window of your choice.
        'Ex. A picturebox control or a frame control would be
        'a child window
        paused = False
        errors = mciSendString("close movie", 0, 0, 0)
        'Decide which way you want the mci device to work below

        'use the command below to play divx movies. Must have the Divx codec installed
        errors = mciSendString("open " & ChrW(34) & Filename & ChrW(34) & " type mpegvideo alias movie parent " & hWnd & " style " & WindowStyle & " ", 0, 0, 0)
        SetVolume(volume)

        If mute Then setAudioOff() Else setAudioOn()
        'Let the mci device decide which driver to use
        'Error = mciSendString("open " & Filename & " alias movie parent " & hWnd & " style " & WindowStyle & " ", 0, 0, 0)
        Return True
    End Function
    Public Function minimizeMovie() As Integer
        'Minimize the movie window
        errors = mciSendString("window movie state minimized", 0, 0, 0)
        Return 0
    End Function


    Public Sub seektrack(ByVal curr As Integer)
        SetFormat_hms()
        errors = mciSendString("seek movie to " & curr, 0, 0, 0)
    End Sub
    Public Function playMovie() As Integer
        'Play the movie after you open it
        errors = mciSendString("play movie", 0, 0, 0)
        playing = True
        paused = False
        Return 0
    End Function
    Public Function hideMovie() As Integer
        'Hides the movie window
        errors = mciSendString("window movie state hide", 0, 0, 0)
        Return 0
    End Function
    Public Function showMovie() As Integer
        'Will show the window if it was hidden with the
        'hideMovie function
        errors = mciSendString("window movie state show", 0, 0, 0)
        Return 0
    End Function
    Public Function restoreMovie() As Integer
        'Will restore the window to its original state
        errors = mciSendString("window movie state restore", 0, 0, 0)
        Return 0
    End Function
    Public Function stopMovie() As Integer
        'Stops the playing of the movie
        errors = mciSendString("stop movie", 0, 0, 0)
        Return 0
        playing = False
        paused = False
    End Function
    Public Function getFormatRemeaning() As String

        Dim h As Long
        Dim m As Long
        Dim s As Long
        h = (getLengthInMS() - getPositionInMS()) \ 3600000
        m = (getLengthInMS() - getPositionInMS()) \ 60000 - h * 60
        s = (getLengthInMS() - getPositionInMS()) \ 1000 - h * 3600 - m * 60
        'h2 =  \ 3600000
        'm2 = repro.getLengthInMS \ 60000 - h2 * 60
        's2 = repro.getLengthInMS \ 1000 - h2 * 3600 - m2 * 60



        'If m2 = m Then
        getFormatRemeaning = "-" & Math.Abs(h) & ":" & Math.Abs(m) & ":" & Math.Abs(s)
        'Else
        'darSobrante = "-" & Abs(h2 - h) & ":" & Abs(m2 - m) & ":" & Abs(59 - s)
        'End If
    End Function

    Public Function getBitsPerPixel() As Integer
        Data = Space(128)
        'Will get the movie bitsperpixel
        'Works with avi movies only
        errors = mciSendString("status movie bitsperpel", Data, 128, 0)
        getBitsPerPixel = Integer.Parse(strformat(Data))
        Return 0
    End Function
    Public Function getMovieInput() As String
        'Returns the current input source
        errors = mciSendString("status movie monitor input", Data, 128, 0)
        getMovieInput = Data
    End Function
    Public Function getMovieOutput() As String
        'Returns the current output source
        errors = mciSendString("status movie monitor output", Data, 128, 0)
        getMovieOutput = Data
    End Function
    Public Function getAudioStatus() As String
        'Check to see if the audio is on or off
        errors = mciSendString("status movie audio", Data, 128, 0)
        getAudioStatus = Data
    End Function
    Public Function sizeLocateMovie(ByVal left As Long, ByVal top As Long, ByVal Width As Long, ByVal Height As Long) As Integer
        'Change the size of the movie and the location of
        'the movie in Pixels
        errors = mciSendString("put movie window at " & left & " " & top & " " & Width & " " & Height, 0, 0, 0)
    End Function
    Public Function isMoviePlaying() As Boolean
        Return playing
    End Function
    Public Function isMoviePaused() As Boolean
        Return paused
    End Function
    Public Function checkError() As String
        'A very useful function for getting any errors
        'associated with the mci device
        checkError = Space$(255)
        mciGetErrorString(errors, checkError, Len(checkError))
    End Function
    Public Function getDeviceName() As String
        'Returns the current device name in use
        errors = mciSendString("info movie product", Data, 128, 0)
        getDeviceName = Data
    End Function
    Public Function getDeviceVersion() As String
        'Returns the current version of the mci device in use
        errors = mciSendString("info movie version", Data, 128, 0)
        getDeviceVersion = Data
    End Function
    Public Function getNominalFrameRate() As Long
        Data = Space(128)
        'Returns the nominal frame rate of the movie file
        errors = mciSendString("status movie nominal frame rate wait", Data, 128, 0)
        getNominalFrameRate = Long.Parse(strformat(Data))
    End Function
    Public Function getFramePerSecRate() As Long
        Data = Space(128)
        'Returns the Frames Per Second of the movie file
        'avi and mpeg movies
        errors = mciSendString("status movie frame rate", Data, 128, 0)
        getFramePerSecRate = Long.Parse(strformat(Data)) \ 1000
    End Function
    Public Function getCurrentSize() As String
        'Returns the current width, height of the movie
        errors = mciSendString("where movie destination max", Data, 128, 0)
        getCurrentSize = Data
    End Function
    Public Function getDefaultSize() As String
        'Returns the default width, height the movie
        errors = mciSendString("where movie source", Data, 128, 0)
        getDefaultSize = Data
    End Function
    Public Function getLengthInFrames() As Long
        Data = Space(128)
        'Get the length of the movie in frames
        errors = mciSendString("set movie time format frames", 0, 0, 0)
        errors = mciSendString("status movie length", Data, 128, 0)
        getLengthInFrames = Long.Parse(strformat(Data))
    End Function
    Public Function getLengthInMS() As Long
        On Error GoTo 1
        Data = Space(128)
        'Get the length of the movie in milliseconds
        errors = mciSendString("set movie time format ms", 0, 0, 0)
        errors = mciSendString("status movie length", Data, 128, 0)
        getLengthInMS = Long.Parse(strformat(Data))
        Exit Function
1:
        Return 0
    End Function
    Public Function playFullScreen() As Integer
        'Play the movie in full screen mode
        errors = mciSendString("Play movie fullscreen", 0, 0, 0)
        playing = True
        paused = False
        Return 0
    End Function
    Public Function getLengthInSec() As Long
        'Get the length of the movie in seconds
        getLengthInSec = getLengthInMS() \ 1000
    End Function
    Public Function setVideoOff() As Integer
        'Set the video device off
        errors = mciSendString("set all video off", 0, 0, 0)
        Return 0
    End Function
    Public Function setVideoOn() As Integer
        'Set the video device on
        errors = mciSendString("set all video on", 0, 0, 0)
        Return 0
    End Function
    Public Function pauseMovie() As Integer
        'Pause the movie
        errors = mciSendString("pause movie", 0, 0, 0)
        paused = True
        Return 0
    End Function
    Public Function resumeMovie() As Integer
        'Resumes the movie
        errors = mciSendString("resume movie", 0, 0, 0)
        paused = False
        Return 0
    End Function
    Public Function getPositionInMS() As Int32
        On Error GoTo 1
        Data = Space(128)
        'Get the position of the movie in milliseconds
        errors = mciSendString("set movie time format ms", 0, 0, 0)
        errors = mciSendString("status movie position wait", Data, 128, 0)
        Return Int32.Parse(strformat(Data))
        Exit Function
1:      Return 0
    End Function
    Public Function getRate() As Long
        'Get the current speed of the movie
        Data = Space(128)
        errors = mciSendString("status movie speed", Data, 128, 0)
        getRate = Long.Parse(strformat(Data))
    End Function
    Public Function getPositionInFrames() As Long
        Data = Space(128)
        'Get the position of the movie in frames
        errors = mciSendString("set movie time format frames wait", 0, 0, 0)
        errors = mciSendString("status movie position", Data, 128, 0)
        getPositionInFrames = Long.Parse(strformat(Data))
    End Function
    Public Function getStatus() As String
        'Get the current mode of the movie
        'Playing, Stopped, Paused, Not Ready
        errors = mciSendString("status movie mode", Data, 128, 0)
        getStatus = StrConv(Data, vbProperCase)
    End Function
    Public Function closeMovie() As Integer
        'Close the mci device
        errors = mciSendString("close all", 0, 0, 0)
        playing = False
        paused = False
        Return 0
    End Function
    Public Function getFormatPosition() As String
        'Get the position in a userfriendly time format
        getFormatPosition = getThisTime(getPositionInMS)
    End Function
    Public Function getFormatLength() As String
        'Get the length in a userfriendly time format
        getFormatLength = getThisTime(getLengthInMS)
    End Function

    Public Function getThisTime(ByVal timein As Long) As String
        Dim h As Long
        Dim m As Long
        Dim s As Long
        h = timein \ 3600000
        m = (timein \ 60000) - h * 60
        s = (timein \ 1000) - h * 3600 - m * 60

        Return h & ":" & m & ":" & s
    End Function
    Public Function getVolume() As Long
        Data = Space(128)
        'Get the current volume level
        errors = mciSendString("status movie volume", Data, 128, 0)
        getVolume = Long.Parse(strformat(Data))
    End Function
    Public Function getVolumel() As String
        Data = Space(128)
        'Get the current volume level
        errors = mciSendString("status movie output", Data, 128, 0)
        getVolumel = Data
    End Function
    Public Function getVideoStatus() As String
        'Get the status of the video. Returns on or off
        errors = mciSendString("status movie video", Data, 128, 0)
        getVideoStatus = Data
    End Function
    Public Function getTimeFormat() As String
        'Returns the current time format. Frames or Millisecond
        errors = mciSendString("status movie time format", Data, 128, 0)
        getTimeFormat = Data
    End Function
    Public Function getLeftVolume() As Long
        Data = Space(128)
        'Returns the volume value of the left channel
        errors = mciSendString("status movie left volume", Data, 128, 0)
        getLeftVolume = Long.Parse(strformat(Data))
    End Function
    Public Function getPositionInSec() As Long
        'Get the position of the movie in seconds
        getPositionInSec = getPositionInMS() \ 1000
    End Function
    Public Function getRightVolume() As Long
        'Get the volume value of the right channel
        errors = mciSendString("status movie right volume", Data, 128, 0)
        getRightVolume = Data
    End Function
    Public Function setAudioOff() As Integer
        'Turns of the audio device
        mute = True
        errors = mciSendString("set movie audio all off", 0, 0, 0)
        Return 0
    End Function
    Public Function setAudioOn() As Integer
        'turns on the audio device
        mute = False
        errors = mciSendString("set movie audio all on", 0, 0, 0)
        Return 0
    End Function
    Public Function setLeftOff() As Integer
        'Turns of the left channel
        errors = mciSendString("set movie audio left off", 0, 0, 0)
        Return 0
    End Function
    Public Function setRightOff() As Integer
        'Turns of the right channel
        errors = mciSendString("set movie audio right off", 0, 0, 0)
        Return 0
    End Function
    Public Function setLeftOn() As Integer
        'Turns on the left channel
        errors = mciSendString("set movie audio left on", 0, 0, 0)
    End Function
    Public Function setRightOn() As Integer
        'Truns on the right channel
        errors = mciSendString("set movie audio right on", 0, 0, 0)
        Return 0
    End Function
    Public Function setDoorOpen() As Integer
        'Open the cdrom door
        errors = mciSendString("set cdaudio door open", 0, 0, 0)
        Return 0
    End Function
    Public Function setDoorClosed() As Integer
        'Close the cdrom door
        errors = mciSendString("set cdaudio door closed", 0, 0, 0)
        Return 0
    End Function
    Public Function SetVolume(ByVal Value As Long) As Integer
        'Raise or lower the volume for both channels
        '1000 max - 0 min
        volume = Value
        errors = mciSendString("setaudio movie volume to " & Value, 0, 0, 0)
        Return 0
    End Function
    Public Function setPositionTo(ByVal ms As Long) As Integer
        'Sets the position of the movie to play at
        SetFormat_milliseconds()
        If ms > getLengthInMS() Then ms = getLengthInMS() - 1000
        If ms < 0 Then ms = 0 + 1000
        If isMoviePlaying() = True Then
            mciSendString("play movie from " & ms, 0, 0, 0)
        ElseIf isMoviePlaying() = False Then
            mciSendString("seek movie to " & ms, 0, 0, 0)
        End If
        Return 0
    End Function
    Public Function restartMovie() As Integer
        'Sets the movie to the beginning and call the playMovie
        'function to start playing from the beginning
        errors = mciSendString("seek movie to start", 0, 0, 0)
        paused = False
        playMovie()
        Return 0
    End Function
    Public Function rewindByMS(ByVal numMS As Long) As Integer
        'Rewind the movie a specified number of milliseconds
        errors = mciSendString("set movie time format ms", 0, 0, 0)
        errors = mciSendString("play movie from " & getPositionInMS() - numMS, 0, 0, 0)
        Return 0
    End Function
    Public Function rewindByFrames(ByVal numFrames As Long) As Integer
        'Rewind the movie by a specified number of frames
        errors = mciSendString("set movie time format frames", 0, 0, 0)
        errors = mciSendString("play movie from " & getPositionInFrames() - numFrames, 0, 0, 0)
        Return 0
    End Function
    Public Function rewindBySeconds(ByVal numSec As Long) As Integer
        'Rewind the movie by a specified number of seconds
        errors = mciSendString("set movie time format ms", 0, 0, 0)
        errors = mciSendString("play movie from " & getPositionInMS() - 1000 * numSec, 0, 0, 0)
        Return 0
    End Function
    Public Function forwardByFrames(ByVal numFrames As Long) As Integer
        'Forward the movie a specified number of frames
        errors = mciSendString("set movie time format frames", 0, 0, 0)
        errors = mciSendString("play movie from " & getPositionInFrames() + numFrames, 0, 0, 0)
        Return 0
    End Function
    Public Function forwardByMS(ByVal numMS As Long) As Integer
        'Forward the movie a specified number of milliseconds
        errors = mciSendString("set movie time format ms", 0, 0, 0)
        errors = mciSendString("play movie from " & getPositionInMS() + numMS, 0, 0, 0)
        Return 0
    End Function
    Public Function forwardBySeconds(ByVal numSec As Long) As Integer
        'Forward the movie a specified number of seconds
        errors = mciSendString("set movie time format ms", 0, 0, 0)
        errors = mciSendString("play movie from " & getPositionInMS() + 1000 * numSec, 0, 0, 0)
        Return 0
    End Function
    Public Function checkDeviceReady() As String
        'Returns true or false depending if the mci device
        'is ready or not
        errors = mciSendString("status movie ready", Data, 128, 0)
        checkDeviceReady = Data
    End Function
    Public Function setSpeed(ByVal Value As Long) As Integer
        'Set the current playing spped of the movie
        '0 = as fast as possible without losing frames
        'Values 1 - 2000 - 2000 being fastest
        errors = mciSendString("set movie speed " & Value, 0, 0, 0)
        Return 0
    End Function
    Public Function setLeftVolume(ByVal Value As Long) As Integer
        'Set the value of the left volume
        errors = mciSendString("setaudio movie left volume to " & Value, 0, 0, 0)
        Return 0
    End Function
    Public Function setRightVolume(ByVal Value As Long) As Integer
        'Set the value of the right volume
        errors = mciSendString("setaudio movie right volume to " & Value, 0, 0, 0)
        Return 0
    End Function
    Public Function strformat(ByVal str128 As String) As String
        For i As Integer = 1 To Len(str128) - 1
            If Mid(str128, i, 1) = " " Then
                Return Mid(str128, 1, i - 1)
            End If
        Next
        Return str128
    End Function



    Public Sub StartPlay()
        mciSendString("play movie", 0, 0, 0)
    End Sub

    Private Sub SetTrack(ByVal Track%)
        SetFormat_hms()
        mciSendString("seek movie to " & Str(Track), 0, 0, 0)
    End Sub

    Public Sub StopPlay()
        mciSendString("stop movie wait", 0, 0, 0)
    End Sub

    Public Sub PausePlay()
        mciSendString("pause movie", 0, 0, 0)
    End Sub

    Private Sub SetFormat_milliseconds()
        mciSendString("set movie time format milliseconds", 0, 0, 0)
    End Sub
    Private Sub SetFormat_hms()
        mciSendString("set movie time format tmsf", 0, 0, 0)
    End Sub

    Function CheckCD$()
        Dim s As String = Space(30)
        mciSendString("status movie media present", s, Len(s), 0)
        CheckCD = s
    End Function
    Public Function getCDCurrentTrack() As Integer
        Dim retstr As String = Space(63)
        SetFormat_hms()
        errors = mciSendString("status movie Current track", retstr, 63, 0)
        Return Val(retstr)

    End Function

    Function GetNumTracks%()
        Dim s As String = Space(30)
        mciSendString("status movie number of tracks wait", s, Len(s), 0)
        GetNumTracks = CInt(Mid$(s, 1, 2))
    End Function

    Function GetCDLength$()
        Dim s As String = Space(30)
        mciSendString("status movie length wait", s, Len(s), 0)
        GetCDLength = s
    End Function

    Function GetTrackLength$(ByVal TrackNum%)
        Dim s As String = Space(30)
        mciSendString("status movie length track " & TrackNum, s, Len(s), 0)
        GetTrackLength = s
    End Function

    Function GetCDPosition$()
        Dim s As String = Space(30)
        mciSendString("status movie position", s, Len(s), 0)
        GetCDPosition = s
    End Function

    Public Sub SeekCDtoX(ByVal Track%)
        If paused = False Then
            StopPlay()
            SetTrack(Track)

            StartPlay()
        End If
    End Sub



End Class
