Public Class Scores
    Private Sub Scores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For i = 0 To Module1.getJoueurs.length - 1
            ListBox1.Items.Add(Module1.getJoueurs(i).getNom)
            ListBox2.Items.Add(Module1.getJoueurs(i).getNbCase)
            ListBox3.Items.Add(Module1.getJoueurs(i).getTempsTotal)
            ComboBox1.Items.Add(Module1.getJoueurs(i).getNom)
        Next
    End Sub

    Private Sub Scores_Closed(sender As Object, e As EventArgs) Handles MyBase.Closed
        Form1.Show()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged, ListBox2.SelectedIndexChanged, ListBox3.SelectedIndexChanged
        ListBox1.SelectedIndex = sender.SelectedIndex
        ListBox2.SelectedIndex = sender.SelectedIndex
        ListBox3.SelectedIndex = sender.SelectedIndex
        ComboBox1.Text = ListBox1.SelectedItem
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ListBox1.SelectedItem <> "" Then
            Dim s As String
            Dim jActu As Personne
            jActu = getJoueur(ListBox1.SelectedItem)
            s = "Nom : " & jActu.getNom & Chr(13) & "Meilleur nombre de cases révélées : " & jActu.getNbCase & Chr(13) & "Temps associé : " & jActu.getTemps
            s += Chr(13) & "Temps cumulé : " & jActu.getTempsTotal & Chr(13) & "Nombre de parties : " & jActu.getNbPartie
            MsgBox(s, MsgBoxStyle.OkOnly, "Démineur")
        End If
    End Sub
End Class