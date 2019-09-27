Imports System.IO
Imports System.Media
Imports Veloengine2
Imports MillonarioExtremeB2
Imports AxShockwaveFlashObjects
Imports Un4seen.BassMOD
Public Class Form1
    Dim segundos As Integer = 0
    Dim ElapsedTime As Integer = 0

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim RootAppDir As String = Application.StartupPath() + "/GameSettings.xml"
        Dim EngineFile As String = VeloengineCore.ReadConfigFile(RootAppDir, 1)
        Dim receivedText As String = Command()

        If System.IO.Directory.Exists(EngineFile & "/GameData") Then
            VeloTage.AudioPlayer.GH3MusicPlayer(EngineFile & "/GameData/Sound/Music/GameBase.hld", "Loading2")
            Timer1.Start()
            MillonarioExtremeB2.VelotageVideoWrapper.AutoLoadScene("GameSettings.xml", "Videos/SplashScreen.vtv", Me)

        Else
            'Dim MediaPlayer As SoundPlayer = New SoundPlayer()
            'MediaPlayer.PlayLooping()
            ErrorForm.Show()
            BassMOD.BASSMOD_Init(0, 44100, BASSInit.BASS_DEVICE_DEFAULT)
            BassMOD.BASS_MusicLoad(Application.StartupPath() + "/musiklinjen.mod", 0, 0, BASSMusic.BASS_MUSIC_LOOP)
            BassMOD.BASSMOD_MusicPlay()

        End If
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        ElapsedTime = ElapsedTime + 1
        segundos = ElapsedTime / 10

        If segundos = 7 Then
            Dim EngineFile As String = VeloengineCore.ReadConfigFile(Application.StartupPath() + "/GameSettings.xml", 1)
            VeloTage.AudioPlayer.GH3MusicPlayer(EngineFile & "/GameData/Sound/Music/GameBase.hld", "Clic")
            Me.Text = "MillonarioExtremeB2"
            Me.FormBorderStyle = BorderStyle.None
            MillonarioExtremeB2.VelotageVideoWrapper.AutoLoadScene("GameSettings.xml", "Videos/LoadingObject.vtv", Me)
        End If

        If segundos = 22 Then '17
            Timer1.Stop()
            Game.Show()
        End If

    End Sub
End Class
