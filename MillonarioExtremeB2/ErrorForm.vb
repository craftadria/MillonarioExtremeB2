Public Class ErrorForm

    Private Sub ErrorForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim RootAppDir As String = Application.StartupPath() + "/GameSettings.xml"
        Dim EngineFile As String = VeloengineCore.ReadConfigFile(RootAppDir, 1)

        TextBox1.Text = "There should be " & EngineFile & "/GameData" & " folder next to the executable"

    End Sub
End Class