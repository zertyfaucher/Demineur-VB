Public Class Form1
    Dim Joueur As String
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Form1_Show(sender As Object, e As EventArgs) Handles MyBase.Shown

    End Sub

    Private Sub ButQuitter_Click(sender As Object, e As EventArgs) Handles ButQuitter.Click
        Dim Quitter As Object
        Quitter = MsgBox("Quitter ?", MsgBoxStyle.YesNo, "Démineur")
        If Quitter = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub ButJouer_Click(sender As Object, e As EventArgs) Handles ButJouer.Click
        If CBNom.Text.Length >= 3 Then
            Jeu.Show()
            If Not CBNom.Items.Contains(CBNom.Text) Then
                CBNom.Items.Add(CBNom.Text)
            End If
            Joueur = CBNom.Text
            CBNom.Text = Nothing
            Me.Hide()
        Else
            MsgBox("Le nom doit au moins contenir 3 caractères", MsgBoxStyle.OkOnly, "Démineur")
        End If
    End Sub

    Private Sub ButScore_Click(sender As Object, e As EventArgs) Handles ButScore.Click
        Scores.Show()
        Me.Hide()
    End Sub

    Private Sub CBNom_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBNom.SelectedIndexChanged

    End Sub
End Class
