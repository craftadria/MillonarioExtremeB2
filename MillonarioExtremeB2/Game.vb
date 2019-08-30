Public Class Game
    Private Sub Game_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Form1.Close()
        VeloTage.AudioPlayer.GH3MusicPlayer("GameData/Sound/Music/VelotageGeneric.ief", "DLCNotFound")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.Close()
    End Sub
End Class