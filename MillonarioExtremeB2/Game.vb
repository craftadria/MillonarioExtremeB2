Public Class Game
    Dim GameCounter As Integer = 0
    Dim Level As Integer = 0
    'Maquina de estados
    Dim Llamando As Boolean = False
    Dim Publico As Boolean = False
    Dim Solucion As Boolean = False
    Dim Idle As Boolean = False
    Dim Misterio As Boolean = False
    Dim GameState As String = 0


    Private Sub Game_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Form1.Close()
        ReadSettings("GameSettings.json", Me)


    End Sub
    Private Function LLamarPublico()
        VeloTage.AudioPlayer.GH3MusicPlayer("/GameData/Sound/Music/GameBase.hld", "Publico")
    End Function

    Private Function Correcto()
        VeloTage.AudioPlayer.GH3MusicPlayer("/GameData/Sound/Music/GameBase.hld", "Correcto")
    End Function


    Public Sub MaquinaDeEstados()
        If Misterio = True Then
            VeloTage.AudioPlayer.GH3MusicPlayer("/GameData/Sound/Music/GameBase.hld", "Wait")
            Timer1.Start()
        End If

        If Solucion = True Then
            Correcto()
            Timer1.Start()
        End If

        If Idle = True Then
            VeloTage.AudioPlayer.GH3MusicPlayer("/GameData/Sound/Music/GameBase.hld", "Preg100-1000")
        End If


        'MaquinaDeEstados("Gameplay")
        'Return State
    End Sub

    Public Shared Sub SetResolution(ResolutionX As Integer, ResolutionY As Integer, ResolutionMode As String, ActiveForm As Form)
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
        Dim param3 As String = VeloengineCore.ReadConfigFile(VeloengineCore.SendEngineFolder & "/" & ConfigFileName, 7)
        Dim param4 As String = VeloengineCore.ReadConfigFile(VeloengineCore.SendEngineFolder & "/" & ConfigFileName, 8)
        Dim param5 As String = VeloengineCore.ReadConfigFile(VeloengineCore.SendEngineFolder & "/" & ConfigFileName, 9)
        Game.SetResolution(param3, param4, param5, NameOfForm)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Idle = False
        Solucion = False
        Misterio = True
        MaquinaDeEstados()
    End Sub



    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Misterio = True Then
            If GameCounter >= 100 Then
                Timer1.Stop()

                GameCounter = 0
                Misterio = False
                Solucion = True
                MaquinaDeEstados()
            Else
                GameCounter += 1
            End If
        End If

        If Solucion = True Then
            If GameCounter >= 20 Then
                Timer1.Stop()
                GameCounter = 0
                Solucion = False
                Idle = True
                MaquinaDeEstados()
            Else
                GameCounter += 1
            End If
        End If


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Label1.Text = Llamando
        Label2.Text = Publico
        Label3.Text = Solucion
        Label4.Text = Idle
        Label5.Text = Misterio
        Label6.Text = GameState
    End Sub

End Class