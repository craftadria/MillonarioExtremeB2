Imports System.IO
Imports Veloengine2
Imports MillonarioExtremeB2
Imports AxShockwaveFlashObjects
Public Class Form1
    Dim segundos As Integer = 0
    Dim ElapsedTime As Integer = 0

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim EngineFile As String = System.Windows.Forms.Application.ExecutablePath
        Dim GameFolder As String = EngineFile & "_GameData"

        If System.IO.Directory.Exists(GameFolder) Then
        Else

            Throw New ApplicationException("Velotage can't find Millonario's folder in" & Name)

        End If
        Timer1.Start()
        MillonarioExtremeB2.VelotageVideoWrapper.AutoLoadScene("GameSettings.json", Me)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        ElapsedTime = ElapsedTime + 1
        segundos = ElapsedTime / 10
        Me.Text = segundos

        If segundos = 15 Then '15
            Timer1.Stop()
            Game.Show()
        End If
    End Sub
End Class
