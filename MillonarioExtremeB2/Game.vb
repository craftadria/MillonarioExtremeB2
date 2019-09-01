Public Class Game
    Private Sub Game_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim EngineFile As String = System.Windows.Forms.Application.ExecutablePath
        Dim GameFolder As String = EngineFile & "_GameData"

        Form1.Close()
        ReadSettings("GameSettings.json", Me)
        VeloTage.AudioPlayer.GH3MusicPlayer(GameFolder & "/Sound/Music/GameBase.ief", "Loading1")

    End Sub

    Public Shared Sub SetResolution(ByVal GameFile As String, ByVal LoopScene As String, ResolutionX As Integer, ResolutionY As Integer, ResolutionMode As String, ActiveForm As Form)
        Select Case ResolutionMode
            Case "fullscreen"
                ActiveForm.FormBorderStyle = BorderStyle.None
                ActiveForm.Width = VeloTage.ScreenManager.GetScreenX()
                ActiveForm.Height = VeloTage.ScreenManager.GetScreenY()
            Case "windowed"
                ActiveForm.FormBorderStyle = BorderStyle.FixedSingle
                ActiveForm.Width = ResolutionX
                ActiveForm.Height = ResolutionY
            Case "windowless"
                ActiveForm.FormBorderStyle = BorderStyle.None
                ActiveForm.Width = ResolutionX
                ActiveForm.Height = ResolutionY
            Case Else
                Throw New ApplicationException("Modo de pantalla desconocido. Prueba el fullscreen, windowed o windowless")
        End Select
    End Sub
    Public Shared Sub ReadSettings(ByVal ConfigFileName As String, ByVal NameOfForm As Form)
        Dim param1 As String = VeloengineCore.ReadConfigFile(VeloengineCore.SendEngineFolder & "/" & ConfigFileName, 3)
        Dim param2 As Boolean = False
        Dim param3 As String = VeloengineCore.ReadConfigFile(VeloengineCore.SendEngineFolder & "/" & ConfigFileName, 7)
        Dim param4 As String = VeloengineCore.ReadConfigFile(VeloengineCore.SendEngineFolder & "/" & ConfigFileName, 8)
        Dim param5 As String = VeloengineCore.ReadConfigFile(VeloengineCore.SendEngineFolder & "/" & ConfigFileName, 9)
        Game.SetResolution(param1, param2, param3, param4, param5, NameOfForm)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.Close()
    End Sub
End Class