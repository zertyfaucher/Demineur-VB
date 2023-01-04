Public Class Form1
    Dim Joueur As String
    Dim PremierePartie As Boolean = False
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Module1.EnregistrerPremierjoueur()
        Module1.LectureFichier()
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
            If Not CBNom.Items.Contains(CBNom.Text) Then
                CBNom.Items.Add(CBNom.Text)
            End If
            PremierePartie = True
            Joueur = CBNom.Text
            CBNom.Text = Nothing
            Jeu.Show()
            Me.Hide()
        Else
            MsgBox("Le nom doit au moins contenir 3 caractères", MsgBoxStyle.OkOnly, "Démineur")
        End If
    End Sub

    Private Sub ButScore_Click(sender As Object, e As EventArgs) Handles ButScore.Click
        Scores.Show()
        Me.Hide()
    End Sub

    Private Sub CBNom_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBNom.KeyUp
        If CBNom.Text.Length < 3 Then
            CBNom.ForeColor = Color.Red
        Else
            CBNom.ForeColor = Color.Green
        End If
    End Sub

    Private Sub ButOpt_Click(sender As Object, e As EventArgs) Handles ButOpt.Click
        Options.Show()
        Me.Hide()
    End Sub

    Function getJoueur()
        Return Joueur
    End Function

    Function getPremierePartie()
        Return PremierePartie
    End Function
End Class
