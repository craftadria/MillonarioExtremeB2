Imports System.IO
Imports System.Media
Imports Veloengine2
Imports MillonarioExtremeB2
Imports AxShockwaveFlashObjects
Public Class Form1
    Dim segundos As Integer = 0
    Dim ElapsedTime As Integer = 0

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim RootAppDir As String = Application.StartupPath() + "/GameSettings.xml"
        Dim EngineFile As String = VeloengineCore.ReadConfigFile(RootAppDir, 1)
        VeloTage.AudioPlayer.GH3MusicPlayer(EngineFile & "/GameData/Sound/Music/GameBase.hld", "Loading2")

        If System.IO.Directory.Exists(EngineFile & "/GameData") Then
            Timer1.Start()
            MillonarioExtremeB2.VelotageVideoWrapper.AutoLoadScene("GameSettings.xml", "Videos/SplashScreen.vtv", Me)
        Else
            Dim MediaPlayer As SoundPlayer = New SoundPlayer(My.Resources.audioinexe)
            MediaPlayer.PlayLooping()
            ErrorForm.Show()
        End If
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        ElapsedTime = ElapsedTime + 1
        segundos = ElapsedTime / 10
        Me.Text = segundos

        If segundos = 7 Then
            Dim EngineFile As String = VeloengineCore.ReadConfigFile(Application.StartupPath() + "/GameSettings.xml", 1)
            VeloTage.AudioPlayer.GH3MusicPlayer(EngineFile & "/GameData/Sound/Music/GameBase.hld", "Clic")
            MillonarioExtremeB2.VelotageVideoWrapper.AutoLoadScene("GameSettings.xml", "Videos/LoadingObject.vtv", Me)
        End If

        If segundos = 15 Then
                Timer1.Stop()
                Game.Show()
            End If

    End Sub
End Class
