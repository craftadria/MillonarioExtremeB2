Imports System.IO
Module Module1
    Sub Main()
        Dim RootAppDir As String = System.Windows.Forms.Application.StartupPath()
        Dim ConfigFile As String = RootAppDir & "/Debug/GameSettings.xml"

        If File.Exists(ConfigFile) Then
            Shell(RootAppDir & "/Debug/MillonarioExtremeB2.exe")
        Else
            Console.WriteLine("Configurando...")
            Dim arr(26) As String
            arr(0) = "<VelotageConfig>"
            arr(0) = "<GameDir>"
            arr(1) = RootAppDir
            arr(2) = "</GameDir>"
            arr(3) = "<GameGraphics>"
            arr(4) = "<Resolution>"
            arr(5) = "<ResX>"
            arr(6) = "800"
            arr(7) = "</ResX>"
            arr(8) = "<ResY>"
            arr(9) = "600"
            arr(10) = "</ResY>"
            arr(11) = "</Resolution>"
            arr(12) = "<ScreenMode>"
            arr(13) = "windowed"
            arr(14) = "</ScreenMode>"
            arr(15) = "</GameGraphics>"
            arr(16) = "<EnableAudio>"
            arr(17) = "true"
            arr(18) = "</EnableAudio>"
            arr(19) = "<Mods>"
            arr(20) = "<Active>"
            arr(21) = "true"
            arr(22) = "</Active>"
            arr(23) = "<ModsDir>"
            arr(24) = ""
            arr(25) = "/<ModsDir>"
            arr(26) = "</VelotageConfig>"
            File.WriteAllLines(ConfigFile, arr)
        End If
    End Sub

End Module
