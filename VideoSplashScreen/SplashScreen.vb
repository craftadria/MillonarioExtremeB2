Public Class SplashScreen
    Private Sub SplashScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        VeloTage.SceneManager.LoadScene("GameData/Videos/SplashScreen.vtv", False, 800, 600, "windowed", False)
    End Sub
End Class