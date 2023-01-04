Public Class Options

    Dim Diff() As String = {"Facile", "Moyen", "Difficile", "Personalisé"}

    Private Sub Options_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AttribueMin()
        AttribueValeur(Module1.getNbrLignes, Module1.getNbrColonnes, Module1.getNbrMines, Module1.getTempsMax)
        For i = 0 To Diff.Length - 1
            CBDiff.Items.Add(Diff(i))
        Next
        LabChrono.Select()
        RBOui.Checked = True
        CBDiff.SelectedItem = "Moyen"
    End Sub

    Private Sub Options_Closed(sender As Object, e As EventArgs) Handles MyBase.Closed
        Form1.Show()
    End Sub

    Private Sub ButQuit_Click(sender As Object, e As EventArgs) Handles ButQuit.Click

        If verification() = True Then
            sauvegarder()
            Form1.Show()
            Me.Hide()
        Else
            MsgBox("Une ou plusieurs données sont incorectes", MsgBoxStyle.OkOnly, "Options")
        End If

    End Sub

    Private Function verification()

        Dim verif As Boolean = True

        If Not verifNombres(CNLigne, 3, 10) Then
            verif = False
        End If
        LabTmpChrono.Text = CNLigne.getTexte.text
        If Not verifNombres(CNCol, 3, 10) Then
            verif = False
        End If
        If Not verifNombres(CNMine, 1, 99) Then
            verif = False
        End If
        If Not verifNombres(CNChrono, 10, 300) Then
            verif = False
        End If
        If Not Val(CNMine.getTexte.text) < Val(CNLigne.getTexte.Text) * Val(CNCol.getTexte.Text) - 1 Then
            verif = False
            CNMine.getTexte.BackColor = Color.Red
        End If


        If verif = True Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Sub controlBlanc()
        For i = 0 To Me.Controls.Count - 1
            Me.Controls.Item(i).BackColor = Color.White
        Next
    End Sub

    Private Sub sauvegarder()
        Module1.setNbrLignes(CNLigne.getTexte.text)
        Module1.setNbrColonnes(CNCol.getTexte.text)
        Module1.setNbrMines(CNMine.getTexte.Text)
        Module1.setTempsMax(CNChrono.getTexte.Text)
    End Sub

    Private Function verifNombres(c As ChoixNombre, min As Integer, max As Integer)
        If IsNumeric(c.getTexte.text) = False Then
            c.getTexte.BackColor = Color.Red
            Return False
        ElseIf Val(c.getTexte.text) < min Or Val(c.getTexte.text) > max Then
            c.getTexte.BackColor = Color.Red
            Return False
        Else
            c.getTexte.BackColor = Color.White
        End If
        Return True
    End Function

    Sub AttribueMin()
        CNLigne.setMin(3)
        CNCol.setMin(3)
        CNMine.setMin(1)
        CNChrono.setMin(10)
    End Sub

    Sub AttribueValeur(L As Integer, C As Integer, M As Integer, T As Integer)
        CNLigne.setTexte("" & L)
        CNCol.setTexte("" & C)
        CNMine.setTexte("" & M)
        CNChrono.setTexte("" & T)
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RBOui.CheckedChanged
        Jeu.setChronometre(True)
        LabTmpChrono.Visible = True
        CNChrono.Visible = True
        CBDiff.SelectedItem = "Personalisé"
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RBNon.CheckedChanged
        Jeu.setChronometre(False)
        LabTmpChrono.Visible = False
        CNChrono.Visible = False
        CBDiff.SelectedItem = "Personalisé"
    End Sub

    Private Sub CBDiff_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles CBDiff.SelectionChangeCommitted
        If CBDiff.SelectedItem = "Facile" Then
            AttribueValeur(5, 5, 4, 60)
            RBNon.Checked = True
        ElseIf CBDiff.SelectedItem = "Moyen" Then
            AttribueValeur(8, 8, 10, 60)
            RBOui.Checked = True
        ElseIf CBDiff.SelectedItem = "Difficile" Then
            AttribueValeur(10, 10, 20, 100)
            RBOui.Checked = True
        End If
    End Sub

    Function getCBDiff()
        Return CBDiff
    End Function
End Class

Class ChoixNombre : Inherits Panel

    Private WithEvents texte As TextBox
    Private WithEvents plus As Button
    Private WithEvents moins As Button
    Private min As Integer

    Sub New()

        texte = New TextBox()
        texte.Size = New Size(75, 30)
        texte.Text = Nothing
        texte.Top = 1

        plus = New Button()
        plus.Text = "+"
        plus.Size = New Size(25, 23)
        plus.Left = 75

        moins = New Button()
        moins.Text = "-"
        moins.Size = New Size(25, 23)
        moins.Left = 100

        Size = New Size(125, 25)
        Controls.Add(texte)
        Controls.Add(plus)
        Controls.Add(moins)

    End Sub

    Sub plus_Click(sender As Object, e As EventArgs) Handles plus.Click
        If IsNumeric(texte.Text) Then
            Dim tmp As Integer
            tmp = Convert.ToInt32(texte.Text)
            tmp += 1
            texte.Text = "" & tmp
        End If
    End Sub

    Sub text_changed(sender As Object, e As EventArgs) Handles texte.TextChanged
        Options.CBDiff.SelectedItem = "Personalisé"
    End Sub

    Sub moins_Click(sender As Object, e As EventArgs) Handles moins.Click
        If IsNumeric(texte.Text) Then
            If texte.Text > min Then
                Dim tmp As Integer
                tmp = Convert.ToInt32(texte.Text)
                tmp -= 1
                texte.Text = "" & tmp
            End If
        End If
    End Sub

    Function getTexte()
        Return texte
    End Function

    Sub setMin(i)
        min = i
    End Sub

    Sub setTexte(s As String)
        texte.Text = s
    End Sub

End Class