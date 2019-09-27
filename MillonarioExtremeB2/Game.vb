Public Class Game
    Dim RootAppDir As String = Application.StartupPath() + "/GameSettings.xml"
    Dim EngineFile As String = VeloengineCore.ReadConfigFile(RootAppDir, 1)

    Dim GameCounter As Integer = 0
    Dim Level As Integer = 0
    'Maquina de estados
    Dim Llamando As Boolean = False
    Dim Publico As Boolean = False
    Dim Solucion As Boolean = False
    Dim Idle As Boolean = False
    Dim Misterio As Boolean = False
    '  Dim GameState As String = 0
    Dim NextQuestion As Boolean = False

    Dim cn As New System.Data.Odbc.OdbcConnection("Driver=Microsoft Access Driver (*.mdb);DBQ=Preguntas.MDB")
    Dim Respuesta As Integer

    Private Sub Game_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Form1.Close()

        Select Case VeloengineCore.ReadConfigFile(RootAppDir, 13)
            Case "fullscreen"
                Me.FormBorderStyle = BorderStyle.None
                Me.Width = VeloTage.ScreenManager.GetScreenX()
                Me.Height = VeloTage.ScreenManager.GetScreenY()
            Case "windowed"
                Me.FormBorderStyle = BorderStyle.FixedSingle
                Me.Width = VeloengineCore.ReadConfigFile(RootAppDir, 6)
                Me.Height = VeloengineCore.ReadConfigFile(RootAppDir, 9)
            Case "windowless"
                Me.FormBorderStyle = BorderStyle.None
                Me.Width = VeloengineCore.ReadConfigFile(RootAppDir, 6)
                Me.Height = VeloengineCore.ReadConfigFile(RootAppDir, 9)
            Case Else
                Throw New ApplicationException("Modo de pantalla desconocido. Prueba el fullscreen, windowed o windowless")
        End Select

        VeloTage.AudioPlayer.GH3MusicPlayer(EngineFile & "/GameData/Sound/Music/GameBase.hld", "Preg100-1000")
        Me.BackgroundImage = Image.FromFile(EngineFile & "/GameData/Backgrounds/Game.png")


        cn.Open()
    End Sub

    Sub LeerPreguntas()
        Dim TotalPreguntas As Integer
        Dim cm As New Odbc.OdbcCommand("Select Numero from Preguntas order by Numero desc;")
        cm.Connection = cn

        Dim dr As Odbc.OdbcDataReader = cm.ExecuteReader()
        If dr.Read() Then
            TotalPreguntas = dr.GetInt32(0)
        Else
            TotalPreguntas = 0
        End If
        dr.Close()
        cm.Dispose()
        Dim a As Integer
        Randomize(Now.Millisecond)
        a = Int(1 + Rnd() * TotalPreguntas)
        cm = New Odbc.OdbcCommand("Select * from Preguntas where Numero=" + a.ToString() + ";")
        cm.Connection = cn
        dr = cm.ExecuteReader()
        If dr.Read() Then
            Label1.Text = "PREGUNTA " + dr.GetValue(0).ToString()
            Label2.Text = dr.GetValue(1)
            Button1.Text = dr.GetValue(2)
            Button2.Text = dr.GetValue(3)
            Button3.Text = dr.GetValue(4)
            Button4.Text = dr.GetValue(5)
            Solucion = dr.GetInt32(6)
        End If
        dr.Close()
        cm.Dispose()
    End Sub
    Private Sub Contestacion(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click, Button2.Click, Button4.Click, Button3.Click
        Idle = False
        Solucion = False
        Misterio = True
        MaquinaDeEstados()

        If CInt(CType(sender, Button).Tag) = Solucion Then
            'Timer1.Start()
            VeloTage.AudioPlayer.GH3MusicPlayer(EngineFile & "/GameData/Sound/Music/GameBase.hld", "Correcto")

            LeerPreguntas()
        Else
            Dim Sol As String = Choose(Solucion, Button1.Text, Button2.Text, Button3.Text, Button4.Text)
            MsgBox("¡GAME OVER! - La respuesta correcta es: " & Sol)
            cn.Close()
            Close()
        End If
    End Sub

    Private Function LLamarPublico()
        VeloTage.AudioPlayer.GH3MusicPlayer(EngineFile & "/GameData/Sound/Music/GameBase.hld", "Publico")
    End Function


    Public Sub MaquinaDeEstados()
        If Misterio = True Then
            VeloTage.AudioPlayer.GH3MusicPlayer(EngineFile & "/GameData/Sound/Music/GameBase.hld", "Wait")
            Timer1.Start()
        End If

        If Solucion = True Then
            Timer1.Start()
        End If

        If Idle = True Then

            If Level = -1 Then
                VeloTage.AudioPlayer.GH3MusicPlayer(EngineFile & "/GameData/Sound/Music/GameBase.hld", "FastFinger")
            End If

            If Level >= 0 Then
                VeloTage.AudioPlayer.GH3MusicPlayer(EngineFile & "/GameData/Sound/Music/GameBase.hld", "Pregunta0to5")
            End If

            If Level >= 5 Then
                VeloTage.AudioPlayer.GH3MusicPlayer(EngineFile & "/GameData/Sound/Music/GameBase.hld", "Gameplay")
            End If

            If Level >= 11 Then
                VeloTage.AudioPlayer.GH3MusicPlayer(EngineFile & "/GameData/Sound/Music/GameBase.hld", "Pregunta11to14")
            End If
            If Level >= 100 Then
                VeloTage.AudioPlayer.GH3MusicPlayer(EngineFile & "/GameData/Sound/Music/GameBase.hld", "Preg100-1000")
            End If
        End If

        If NextQuestion = True Then
            If Level = -1 Then
                VeloTage.AudioPlayer.GH3MusicPlayer(EngineFile & "/GameData/Sound/Music/GameBase.hld", "TV_Map")
            End If

            If Level >= 0 Then
                VeloTage.AudioPlayer.GH3MusicPlayer(EngineFile & "/GameData/Sound/Music/GameBase.hld", "PNext")
            End If

            If Level >= 5 Then
                VeloTage.AudioPlayer.GH3MusicPlayer(EngineFile & "/GameData/Sound/Music/GameBase.hld", "PNextB")
            End If

            If Level >= 11 Then
                VeloTage.AudioPlayer.GH3MusicPlayer(EngineFile & "/GameData/Sound/Music/GameBase.hld", "8000_next")
            End If

            If Level >= 100 Then
                VeloTage.AudioPlayer.GH3MusicPlayer(EngineFile & "/GameData/Sound/Music/GameBase.hld", "1000000_next")
            End If
            Timer1.Start()


        End If

    End Sub
    Public Shared Sub SaveGame(ActualLevel As Integer, Modality As Integer)
        Console.WriteLine("Saving...")
        Dim GameSaveContent(5) As String
        GameSaveContent(0) = Environment.MachineName
        GameSaveContent(1) = Environment.Is64BitOperatingSystem
        GameSaveContent(2) = Environment.UserName
        GameSaveContent(3) = Environment.UserInteractive
        GameSaveContent(4) = Environment.UserDomainName
        GameSaveContent(5) = Environment.WorkingSet

        Dim SaveFolder As String = VeloengineCore.ReadConfigFile(Application.StartupPath() + "/GameSettings.xml", 1)
        File.WriteAllLines(SaveFolder & "/GameData/Savegames/" & Environment.UserName, GameSaveContent)

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
            If GameCounter >= 70 Then
                Timer1.Stop()
                GameCounter = 0
                Solucion = False
                Idle = False
                NextQuestion = True
                MaquinaDeEstados()
            Else
                GameCounter += 1
            End If
        End If


        If NextQuestion = True Then
            If GameCounter >= 70 Then
                Timer1.Stop()
                GameCounter = 0
                NextQuestion = False
                Idle = True
                MaquinaDeEstados()
            Else
                GameCounter += 1
            End If
        End If

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Level = TextBox1.Text
        Label1.Text = Llamando
        Label2.Text = Publico
        Label3.Text = Solucion
        Label4.Text = Idle
        Label5.Text = Misterio
        Label6.Text = NextQuestion
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        SaveGame("15", "5")
    End Sub
End Class