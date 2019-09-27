Public Class ErrorForm

    Private Sub ErrorForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim RootAppDir As String = Application.StartupPath() + "/GameSettings.xml"
        Dim EngineFile As String = VeloengineCore.ReadConfigFile(RootAppDir, 1)

        TextBox1.Text = "There should be " & EngineFile & "/GameData" & " folder next to the executable"

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        BassMOD.BASSMOD_MusicStop()
        BassMOD.BASSMOD_Free()
    End Sub
End Class