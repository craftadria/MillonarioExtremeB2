Public Class ErrorForm

    Private Sub ErrorForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim EngineFile As String = Application.StartupPath & "/GameData"
        TextBox1.Text = "There should be " & EngineFile & " folder next to the executable"

    End Sub
End Class