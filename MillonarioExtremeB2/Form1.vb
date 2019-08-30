Imports System.IO
Imports Veloengine2
Imports MillonarioExtremeB2
Imports AxShockwaveFlashObjects
Public Class Form1
    Dim segundos As Integer = 0
    Dim ElapsedTime As Integer = 0
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
        MillonarioExtremeB2.VelotageVideoWrapper.LoadSplashVideo("GameData/Videos/SplashScreen.vtv", False, 800, 600, "windowed", False)
        Dim param1 As String = VeloengineCore.ReadConfigFile(VeloengineCore.SendEngineFolder & "/" & ConfigFileName, 3)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        ElapsedTime = ElapsedTime + 1
        segundos = ElapsedTime / 10
        Me.Text = segundos

        If segundos = 15 Then
            Timer1.Stop()
            Game.Show()
        End If
    End Sub
End Class
