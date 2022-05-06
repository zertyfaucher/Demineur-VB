Public Class Scores
    Private Sub Scores_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Scores_Hide(sender As Object, e As EventArgs) Handles MyBase.Closed
        Form1.Show()
    End Sub
End Class