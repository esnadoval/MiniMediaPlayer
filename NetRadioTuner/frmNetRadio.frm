VERSION 5.00
Object = "{248DD890-BB45-11CF-9ABC-0080C7E7B78D}#1.0#0"; "MSWINSCK.OCX"
Begin VB.Form RadioTunerfrm 
   BorderStyle     =   0  'None
   Caption         =   "Radio Tuner"
   ClientHeight    =   4215
   ClientLeft      =   0
   ClientTop       =   -45
   ClientWidth     =   4215
   Icon            =   "frmNetRadio.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   4215
   ScaleWidth      =   4215
   ShowInTaskbar   =   0   'False
   StartUpPosition =   2  'CenterScreen
   Visible         =   0   'False
   Begin VB.Timer tmrNetRadio 
      Interval        =   50
      Left            =   3120
      Top             =   1320
   End
   Begin VB.Frame frameProxy 
      Caption         =   " Proxy server "
      Height          =   975
      Left            =   120
      TabIndex        =   18
      Top             =   3120
      Width           =   3975
      Begin MSWinsockLib.Winsock Winsock1 
         Left            =   3120
         Top             =   0
         _ExtentX        =   741
         _ExtentY        =   741
         _Version        =   393216
      End
      Begin VB.CheckBox chkDirectConnect 
         Caption         =   "Direct connection"
         Height          =   255
         Left            =   240
         TabIndex        =   20
         Top             =   600
         Width           =   1575
      End
      Begin VB.TextBox txtProxy 
         Height          =   285
         Left            =   120
         MaxLength       =   100
         TabIndex        =   19
         Top             =   240
         Width           =   3735
      End
      Begin VB.Label lblUserPass 
         AutoSize        =   -1  'True
         Caption         =   "[user:pass@]server:port"
         Height          =   195
         Left            =   2160
         TabIndex        =   21
         Top             =   600
         Width           =   1680
      End
   End
   Begin VB.Frame framePresents 
      Caption         =   " Presents "
      Height          =   1455
      Left            =   120
      TabIndex        =   11
      Top             =   0
      Width           =   3975
      Begin VB.CommandButton Command1 
         Caption         =   "Command1"
         Height          =   255
         Left            =   1800
         TabIndex        =   22
         Top             =   1200
         Width           =   615
      End
      Begin VB.CheckBox chkSave 
         Caption         =   "Save local copy"
         Height          =   255
         Left            =   120
         TabIndex        =   10
         Top             =   1080
         Width           =   3735
      End
      Begin VB.CommandButton btnPresents 
         Caption         =   "5"
         Height          =   350
         Index           =   9
         Left            =   3360
         TabIndex        =   9
         Top             =   630
         Width           =   450
      End
      Begin VB.CommandButton btnPresents 
         Caption         =   "4"
         Height          =   350
         Index           =   8
         Left            =   2790
         TabIndex        =   7
         Top             =   630
         Width           =   450
      End
      Begin VB.CommandButton btnPresents 
         Caption         =   "3"
         Height          =   350
         Index           =   7
         Left            =   2220
         TabIndex        =   5
         Top             =   630
         Width           =   450
      End
      Begin VB.CommandButton btnPresents 
         Caption         =   "2"
         Height          =   350
         Index           =   6
         Left            =   1650
         TabIndex        =   3
         Top             =   630
         Width           =   450
      End
      Begin VB.CommandButton btnPresents 
         Caption         =   "1"
         Height          =   350
         Index           =   5
         Left            =   1080
         TabIndex        =   1
         Top             =   630
         Width           =   450
      End
      Begin VB.CommandButton btnPresents 
         Caption         =   "5"
         Height          =   350
         Index           =   4
         Left            =   3360
         TabIndex        =   8
         Top             =   240
         Width           =   450
      End
      Begin VB.CommandButton btnPresents 
         Caption         =   "4"
         Height          =   350
         Index           =   3
         Left            =   2790
         TabIndex        =   6
         Top             =   240
         Width           =   450
      End
      Begin VB.CommandButton btnPresents 
         Caption         =   "3"
         Height          =   350
         Index           =   2
         Left            =   2220
         TabIndex        =   4
         Top             =   240
         Width           =   450
      End
      Begin VB.CommandButton btnPresents 
         Caption         =   "2"
         Height          =   350
         Index           =   1
         Left            =   1650
         TabIndex        =   2
         Top             =   240
         Width           =   450
      End
      Begin VB.CommandButton btnPresents 
         Caption         =   "1"
         Height          =   350
         Index           =   0
         Left            =   1080
         TabIndex        =   0
         Top             =   240
         Width           =   450
      End
      Begin VB.Label lblModem 
         AutoSize        =   -1  'True
         Caption         =   "Modem"
         Height          =   195
         Left            =   120
         TabIndex        =   14
         Top             =   720
         Width           =   525
      End
      Begin VB.Label lblBroadband 
         AutoSize        =   -1  'True
         Caption         =   "Broadband"
         Height          =   195
         Left            =   120
         TabIndex        =   13
         Top             =   240
         Width           =   780
      End
   End
   Begin VB.Frame framePlaying 
      Caption         =   " Currently playing "
      Height          =   1455
      Left            =   120
      TabIndex        =   12
      Top             =   1560
      Width           =   3975
      Begin VB.CommandButton Command2 
         Caption         =   "Command2"
         Height          =   195
         Left            =   2520
         TabIndex        =   23
         Top             =   240
         Width           =   1335
      End
      Begin VB.Label lblBPS 
         Alignment       =   2  'Center
         Height          =   195
         Left            =   90
         TabIndex        =   17
         Top             =   1200
         Width           =   3795
         WordWrap        =   -1  'True
      End
      Begin VB.Label lblName 
         Alignment       =   2  'Center
         Caption         =   "not playing"
         Height          =   375
         Left            =   105
         TabIndex        =   16
         Top             =   720
         Width           =   3765
         WordWrap        =   -1  'True
      End
      Begin VB.Label lblSong 
         Alignment       =   2  'Center
         Height          =   435
         Left            =   105
         TabIndex        =   15
         Top             =   240
         Width           =   3765
         WordWrap        =   -1  'True
      End
   End
End
Attribute VB_Name = "RadioTunerfrm"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'/////////////////////////////////////////////////////////////////////////////////
' RadioTunerfrm.frm - Copyright (c) 2002-2007 (: JOBnik! :) [Arthur Aminov, ISRAEL]
'                                                         [http://www.jobnik.org]
'                                                         [  jobnik@jobnik.org  ]
'
' * Save local copy is added by: Peter Hebels @ http://www.phsoft.nl
'                                             e-mail: info@phsoft.nl
'
' Other sources: modNetRadio.bas & clsFileIo.cls
'
' BASS Internet radio example
' Originally translated from - netradio.c - Example of Ian Luck
'/////////////////////////////////////////////////////////////////////////////////

Option Explicit

Private Declare Function GetModuleFileName Lib "kernel32" Alias "GetModuleFileNameA" (ByVal hModule As Long, ByVal lpFileName As String, ByVal nSize As Long) As Long
Private Declare Sub CopyMemory Lib "kernel32" Alias "RtlMoveMemory" (Destination As Any, Source As Any, ByVal length As Long)

Private Sub chkDirectConnect_Click()
    If (chkDirectConnect.value) Then
        Call BASS_SetConfigPtr(BASS_CONFIG_NET_PROXY, vbNullString)  ' disable proxy
    Else
        Call BASS_SetConfigPtr(BASS_CONFIG_NET_PROXY, VarPtr(proxy(0))) ' enable proxy
    End If
End Sub

' this function will check if you're running in IDE or EXE modes
' VB will crash if you're closing the app while (cthread<>0) in IDE,
' but won't crash if in EXE mode
Public Function isIDEmode() As Boolean
    Dim sFileName As String, lCount As Long

    sFileName = String(255, 0)
    lCount = GetModuleFileName(App.hInstance, sFileName, 255)
    sFileName = UCase(GetFileName(Mid(sFileName, 1, lCount)))

    isIDEmode = (sFileName = "VB6.EXE")
End Function

Private Sub Command1_Click()
unTune
End Sub

Public Sub setVol(vol As String)
Call BASS_SetConfig(BASS_CONFIG_GVOL_STREAM, vol)
End Sub


Private Sub Command2_Click()
Buscar_Carpeta "tit", App.Path
End Sub

Private Sub Form_Load()
If App.PrevInstance Then End
Winsock1.LocalPort = "7000"
'Nos ponemos a escuchar
Winsock1.Listen
End Sub

Private Sub Form_Unload(Cancel As Integer)
    If (isIDEmode And cthread) Then
        ' IDE Version
        Cancel = True   ' disable closing app to avoid crash
    Else
        ' Compiled Version or (cthread = 0) close app is available
        Call BASS_Free
    End If
End Sub
Public Sub tune(urls As String)
unTune
' change and set the current path, to prevent from VB not finding BASS.DLL
    ChDrive App.Path
    ChDir App.Path

    ' check the correct BASS was loaded
    If (HiWord(BASS_GetVersion) <> BASSVERSION) Then
        Call MsgBox("An incorrect version of BASS.DLL was loaded", vbCritical)
        End
    End If

    ' setup output device
    If (BASS_Init(-1, 44100, 0, Me.hwnd, 0) = 0) Then
        Call Error_("Can't initialize device")
        End
    End If

    Call BASS_SetConfig(BASS_CONFIG_NET_PLAYLIST, 1) ' enable playlist processing
    Call BASS_SetConfig(BASS_CONFIG_NET_PREBUF, 0) ' minimize automatic pre-buffering, so we can do it (and display it) instead
    Call BASS_SetConfigPtr(BASS_CONFIG_NET_PROXY, VarPtr(proxy(0)))  ' setup proxy server location

    ' preset stream URLs
    url = Array(urls)
    Set WriteFile = New clsFileIo
    cthread = 0
    
        If (cthread) Then   ' already connecting
        Call Beep
    Else
        Call CopyMemory(proxy(0), ByVal txtProxy.Text, Len(txtProxy.Text))   ' get proxy server

        ' open URL in a new thread (so that main thread is free)
        Dim threadid As Long
        cthread = CreateThread(ByVal 0&, 0, AddressOf OpenURL, 0, 0, threadid)   ' threadid param required on win9x
    End If
End Sub
Public Sub unTune()
Call BASS_Free
End Sub

Private Sub btnPresents_Click(index As Integer)
tune ("http://yp.shoutcast.com/sbin/tunein-station.pls?id=110834")
End Sub

Private Sub chkSave_Click()
    If chkSave.value = vbChecked Then
        
       sveFile (True)
    Else
        sveFile (False)
    End If
End Sub
Public Sub sveFile(onof As Boolean)
  If onof = True Then
   Dim dir As String
        dir = Buscar_Carpeta("Seleccione el lugar donde se guardaran los archivos")
        modNetRadio.recdir = dir
        
        Dim sel As Integer
        sel = MsgBox("Desea separar las canciones transmitidas en archivos diferentes?", vbYesNo, "Modo de Grabar")
        If sel = vbYes Then
        modNetRadio.wholefil = False
         modNetRadio.DlOutput = dir & "\" & RadioTunerfrm.lblSong.Caption & ".mp3"
        Else
        modNetRadio.wholefil = True
            Dim fn As String
            fn = InputBox("Escriba el nombre del archivo que contendra la grabacion:", "Archivo de Grabacion", "Radio_Record")
            modNetRadio.DlOutput = dir & "\" & fn & ".mp3"
            modNetRadio.recdir = dir & "\" & fn & ".mp3"
        End If
        
       
        DoDownload = True
     
    Else
       
        DoDownload = False
        
    End If
End Sub

Private Sub tmrNetRadio_Timer()
    Dim progress As Long
    progress = BASS_StreamGetFilePosition(chan, BASS_FILEPOS_BUFFER) * 100 / BASS_StreamGetFilePosition(chan, BASS_FILEPOS_END)    ' percentage of buffer filled
    If (progress > 75 Or BASS_StreamGetFilePosition(chan, BASS_FILEPOS_CONNECTED) = 0) Then ' over 75% full (or end of download)
        tmrNetRadio.Enabled = False ' finished prebuffering, stop monitoring
        ' get the broadcast name and bitrate
        Dim icyPtr As Long
        icyPtr = BASS_ChannelGetTags(chan, BASS_TAG_ICY)
        If (icyPtr = 0) Then icyPtr = BASS_ChannelGetTags(chan, BASS_TAG_HTTP) ' no ICY tags, try HTTP
        If (icyPtr) Then
            Dim icyStr As String
            Do
                icyStr = VBStrFromAnsiPtr(icyPtr)
                icyPtr = icyPtr + Len(icyStr) + 1
                lblName.Caption = IIf(Mid(icyStr, 1, 9) = "icy-name:", Mid(icyStr, 10), lblName.Caption)
                lblBPS.Caption = IIf(Mid(icyStr, 1, 7) = "icy-br:", "bitrate: " & Mid(icyStr, 8), lblBPS.Caption)

                ' NOTE: you can get more ICY info like: icy-genre:, icy-url:... :)
            Loop While (icyStr <> "")
        End If

        ' get the stream title and set sync for subsequent titles
        Call DoMeta
        Call BASS_ChannelSetSync(chan, BASS_SYNC_META, 0, AddressOf MetaSync, 0)
        ' set sync for end of stream
        Call BASS_ChannelSetSync(chan, BASS_SYNC_END, 0, AddressOf EndSync, 0)
        ' play it!
        Call BASS_ChannelPlay(chan, BASSFALSE)
    Else
        lblName.Caption = "buffering... " & progress & "%"
    End If
End Sub

'--------------------
' useful function :)
'--------------------

' get file name from file path
Public Function GetFileName(ByVal fp As String) As String
    GetFileName = Mid(fp, InStrRev(fp, "\") + 1)
End Function
Private Sub Winsock1_ConnectionRequest(ByVal requestID As Long)
'Si el winsock está abierto lo cerramos.
If Winsock1.State <> sckClosed Then Winsock1.close
Winsock1.Accept requestID 'Aceptamos la conexión
End Sub

Private Sub Winsock1_Error(ByVal Number As Integer, Description As String, ByVal Scode As Long, ByVal Source As String, ByVal HelpFile As String, ByVal HelpContext As Long, CancelDisplay As Boolean)
'Si ocurre un error, cerramos y volvemos a escuchar.
Winsock1.close
Winsock1.Listen
End Sub

Private Sub Winsock1_Close()
'Si se cierra la conexión, volvemos a escuchar.
Winsock1.close
Winsock1.Listen
End Sub


Private Sub Winsock1_DataArrival(ByVal bytesTotal As Long)
'Variable para la ruta del archivo en la oopcion ejecutar archivo
Dim Ruta As String
'Declaramos la variable que recibirá los datos
Dim Data1 As String
'Tomamos los datos que nos envían
Winsock1.GetData Data1

'separamos el String y determinamos que accion nos está mandando el Cliente
Select Case Mid(Data1, 1, 6)
'Opcion ejecutar un archivo
Case "#TUNE#"
    
  Ruta = Mid(Data1, 7)
  tune Ruta
  Winsock1.SendData (Ruta & "tuned succsesfuly")
'Genera las pulsacione de tecla
Case "#STOP#"
  unTune
  Winsock1.SendData ("succesfull shutdown")
  End

Case "#INFO#"
  Winsock1.SendData (lblSong.Caption & ";;" & lblName.Caption & ";;" & lblBPS.Caption)

  Case "#REON#"
  sveFile True
  Winsock1.SendData ("init record")

    Case "#REOF#"
  sveFile False
  Winsock1.SendData ("stop record")
      Case "#VOLU#"
  setVol Mid(Data1, 7)
  Winsock1.SendData ("volch")

End Select
End Sub



' Funcción que abre el cuadro de dialogo y retorna la ruta
'******************************************************************
Public Function Buscar_Carpeta(Optional Titulo As String, _
                        Optional Path_Inicial As Variant) As String

On Local Error GoTo errFunction
    
    Dim objShell As Object
    Dim objFolder As Object
    Dim o_Carpeta As Object
    
    ' Nuevo objeto Shell.Application
    Set objShell = CreateObject("Shell.Application")
    
    On Error Resume Next
    'Abre el cuadro de diálogo para seleccionar
    Set objFolder = objShell.BrowseForFolder( _
                            0, _
                            Titulo, _
                            0, _
                            Path_Inicial)
    ' Devuelve solo el nombre de carpeta
    Set o_Carpeta = objFolder.Self
    
    ' Devuelve la ruta completa seleccionada en el diálogo
    Buscar_Carpeta = o_Carpeta.Path

Exit Function
'Error
errFunction:
    MsgBox Err.Description, vbCritical
    Buscar_Carpeta = vbNullString


    
End Function



