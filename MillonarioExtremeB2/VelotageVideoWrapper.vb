Imports Veloengine2
Namespace MillonarioExtremeB2
    Public Class VelotageVideoWrapper

        Public Shared Sub LoadSplashVideo(ByVal GameFile As String, ByVal LoopScene As String, ResolutionX As Integer, ResolutionY As Integer, ResolutionMode As String, ActiveForm As Form)
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


        Public Shared Sub AutoLoadScene(ByVal ConfigFileName As String, ByVal NameOfForm As Form)
            Dim param1 As String = VeloengineCore.ReadConfigFile(VeloengineCore.SendEngineFolder & "/" & ConfigFileName, 3)
            Dim param2 As Boolean = False
            Dim param3 As String = VeloengineCore.ReadConfigFile(VeloengineCore.SendEngineFolder & "/" & ConfigFileName, 7)
            Dim param4 As String = VeloengineCore.ReadConfigFile(VeloengineCore.SendEngineFolder & "/" & ConfigFileName, 8)
            Dim param5 As String = VeloengineCore.ReadConfigFile(VeloengineCore.SendEngineFolder & "/" & ConfigFileName, 9)
            MillonarioExtremeB2.VelotageVideoWrapper.LoadSplashVideo(param1, param2, param3, param4, param5, NameOfForm)
        End Sub
    End Class
End Namespace