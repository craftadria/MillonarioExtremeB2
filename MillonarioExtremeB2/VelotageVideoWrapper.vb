Imports Veloengine2
Namespace MillonarioExtremeB2
    Public Class VelotageVideoWrapper

        Public Shared Sub LoadSplashVideo(ByVal GameFile As String, ByVal LoopScene As String, ResolutionX As Integer, ResolutionY As Integer, ResolutionMode As String, EditorEnabled As Boolean)

            Select Case ResolutionMode
                Case "fullscreen"
                    Form1.Width = VeloTage.ScreenManager.GetScreenX()
                    Form1.Height = VeloTage.ScreenManager.GetScreenY()
                Case "windowed"
                    Form1.FormBorderStyle = BorderStyle.FixedSingle
                    Form1.Width = ResolutionX
                    Form1.Height = ResolutionY
                Case "windowless"
                    Form1.FormBorderStyle = BorderStyle.None
                    Form1.Width = ResolutionX
                    Form1.Height = ResolutionY
                Case Else
                    Throw New ApplicationException("Modo de pantalla desconocido. Prueba el fullscreen, windowed o windowless")
            End Select
            Dim filetoread As String = Application.StartupPath() & "/" & GameFile

            If File.Exists(filetoread) Then
                Form1.AxShockwaveFlash1.Loop = LoopScene
                Form1.Location = New System.Drawing.Point(0, 0)
                Form1.AxShockwaveFlash1.Size = New System.Drawing.Size(ResolutionX, ResolutionY)
                Form1.AxShockwaveFlash1.Movie = filetoread
            Else
                Throw New ApplicationException("Error al volcar fichero a RAM")
            End If

        End Sub
        Public Shared Sub AutoLoadScene(ByVal ConfigFileName As String, ByVal EditorEnabled As Boolean)
            Dim param1 As String = VeloengineCore.ReadConfigFile(VeloengineCore.SendEngineFolder & "/" & ConfigFileName, 3)
            Dim param2 As Boolean = False
            Dim param3 As String = VeloengineCore.ReadConfigFile(VeloengineCore.SendEngineFolder & "/" & ConfigFileName, 7)
            Dim param4 As String = VeloengineCore.ReadConfigFile(VeloengineCore.SendEngineFolder & "/" & ConfigFileName, 8)
            Dim param5 As String = VeloengineCore.ReadConfigFile(VeloengineCore.SendEngineFolder & "/" & ConfigFileName, 9)
            VeloTage.SceneManager.LoadScene(param1, param2, param3, param4, param5, EditorEnabled)
        End Sub
    End Class
End Namespace