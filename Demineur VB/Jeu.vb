Public Class Jeu

    Public BoutonsMax = 64
    Dim Boutons(BoutonsMax) As CLC
    Dim WithEvents b As CLC
    Dim NbrMines As Integer = 10
    Public nbrLignes As Integer = 8
    Public nbrColonnes As Integer = 8
    Private Selection As Boolean = False

    Private Sub Jeu_Closed(sender As Object, e As EventArgs) Handles MyBase.Closed
        Form1.Show()
    End Sub

    Private Sub Jeu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        Dim X As Integer
        Dim Y As Integer
        Dim Ecart = 27
        For i = 0 To BoutonsMax - 1
            b = New CLC()
            b.setNum(i)
            Me.Controls.Add(b)
            X += Ecart
            If i Mod 8 = 0 Then
                Y += Ecart
                X = 10
            End If
            b.Left = X
            b.Top = Y
            Boutons(i) = b
        Next
        For i = 0 To NbrMines - 1
            Dim tmp = MineAlea(0, BoutonsMax)
            Boutons(tmp).getLabel.Text = "M"
        Next
        AttribueValeurCases()
    End Sub

    Private Sub Jeu_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If UCase(e.KeyChar) = "M" Then
            If Selection = False Then
                Selection = True
                Label4.Text = "Mines"
            Else
                Selection = False
                Label4.Text = "Normal"
            End If
        End If
    End Sub

    Sub AttribueValeurCases()
        Dim count As Integer
        For i = 0 To BoutonsMax - 1
            count = 0
            If Boutons(i).getLabel.Text <> "M" Then
                If i Mod 8 = 0 Then
                    If i - nbrColonnes < 0 Then
                        If Boutons(i + nbrColonnes).getLabel.Text = "M" Then
                            count += 1
                        End If
                        If Boutons(i + nbrColonnes + 1).getLabel.Text = "M" Then
                            count += 1
                        End If
                    ElseIf i + nbrColonnes > BoutonsMax - 1 Then
                        If Boutons(i - nbrColonnes).getLabel.Text = "M" Then
                            count += 1
                        End If
                        If Boutons(i - nbrColonnes + 1).getLabel.Text = "M" Then
                            count += 1
                        End If
                    Else
                        For j = i + nbrColonnes To i + nbrColonnes + 1
                            If Boutons(j).getLabel.Text = "M" Then
                                count += 1
                            End If
                        Next
                        For j = i - nbrColonnes To i - nbrColonnes + 1
                            If Boutons(j).getLabel.Text = "M" Then
                                count += 1
                            End If
                        Next
                    End If
                    If Boutons(i + 1).getLabel.Text = "M" Then
                        count += 1
                    End If
                ElseIf i Mod 8 = 7 Then
                    If i - nbrColonnes < 0 Then
                        If Boutons(i + nbrColonnes).getLabel.Text = "M" Then
                            count += 1
                        End If
                        If Boutons(i + nbrColonnes - 1).getLabel.Text = "M" Then
                            count += 1
                        End If
                    ElseIf i + nbrColonnes > BoutonsMax - 1 Then
                        If Boutons(i - nbrColonnes).getLabel.Text = "M" Then
                            count += 1
                        End If
                        If Boutons(i - nbrColonnes - 1).getLabel.Text = "M" Then
                            count += 1
                        End If
                    Else
                        For j = i + nbrColonnes - 1 To i + nbrColonnes
                            If Boutons(j).getLabel.Text = "M" Then
                                count += 1
                            End If
                        Next
                        For j = i - nbrColonnes - 1 To i - nbrColonnes
                            If Boutons(j).getLabel.Text = "M" Then
                                count += 1
                            End If
                        Next
                    End If
                    If Boutons(i - 1).getLabel.Text = "M" Then
                        count += 1
                    End If
                Else
                    If i - nbrColonnes < 0 Then
                        For j = i + nbrColonnes - 1 To i + nbrColonnes + 1
                            If Boutons(j).getLabel.Text = "M" Then
                                count += 1
                            End If
                        Next
                    ElseIf i + nbrColonnes > BoutonsMax - 1 Then
                        For j = i - nbrColonnes - 1 To i - nbrColonnes + 1
                            If Boutons(j).getLabel.Text = "M" Then
                                count += 1
                            End If
                        Next
                    Else
                        For j = i + nbrColonnes - 1 To i + nbrColonnes + 1
                            If Boutons(j).getLabel.Text = "M" Then
                                count += 1
                            End If
                        Next
                        For j = i - nbrColonnes - 1 To i - nbrColonnes + 1
                            If Boutons(j).getLabel.Text = "M" Then
                                count += 1
                            End If
                        Next
                    End If
                    If Boutons(i - 1).getLabel.Text = "M" Then
                        count += 1
                    End If
                    If Boutons(i + 1).getLabel.Text = "M" Then
                        count += 1
                    End If
                End If
                Boutons(i).getLabel.Text = "" & count
            End If
        Next
    End Sub

    Function MineAlea(Min As Integer, Max As Integer)
        Randomize()
        Dim r As Integer
        r = CInt(Math.Floor((Max - 1 - Min + 1) * Rnd())) + Min
        While Verification(r) = False
            r = CInt(Math.Floor((Max - 1 - Min + 1) * Rnd())) + Min
        End While
        Return r
    End Function

    Function Verification(I As Integer)
        Dim b As CLC = Boutons(I)
        If b.getLabel.Text = "M" Then
            Return False
        Else
            Return True
        End If
    End Function

    Function GetBouton()
        Return Boutons
    End Function

    Function GetBoutonAff(i As Integer)
        Return Boutons(i)
    End Function

    Function getSelection()
        Return Selection
    End Function
End Class

Class CLC : Inherits Panel
    Private Num As Integer
    Private WithEvents Bouton As Button
    Private WithEvents Label As Label
    Private selectione As Boolean = False
    Private trouvé As Boolean = False

    Private casPartZero(0) As Integer

    Sub New()

        Bouton = New Button()
        Bouton.Size = New Size(25, 25)
        Bouton.Text = Nothing
        Bouton.BackColor = Color.LightGray

        Label = New Label()
        Label.Text = "1"
        Label.Size = New Size(25, 25)
        Label.Left = 7
        Label.Top = 7

        Size = New Size(25, 25)
        Controls.Add(Bouton)
        Controls.Add(Label)

    End Sub

    Function getLabel()
        Return Label
    End Function

    Function getTrouvé()
        Return trouvé
    End Function

    Function getBouton()
        Return Bouton
    End Function

    Function getSelectione()
        Return selectione
    End Function

    Sub Bouton_Click(sender As Object, e As EventArgs) Handles Bouton.Click
        Dim perdu As Boolean = False
        If Jeu.getSelection = False Then
            Bouton.Visible = False
            Label.Focus()
            Dim dejaVu(Jeu.BoutonsMax) As Boolean
            If Label.Text = "0" Then
                propag(Jeu.GetBouton, dejaVu, Num)
            End If
            If casPartZero IsNot Nothing Then
                For index = 0 To casPartZero.Length - 1 ' pour les cas a part
                    If dejaVu(casPartZero(index)) = False Then
                        propag(Jeu.GetBouton, dejaVu, casPartZero(index))
                    End If
                Next
                Array.Clear(casPartZero, 0, casPartZero.Length - 1)
                ReDim casPartZero(0)
            End If

            If Label.Text = "M" Then
                MsgBox("Mine découverte, partie perdue", MsgBoxStyle.OkOnly, "Démineur")
                perdu = True
            End If
        Else
            If selectione = False Then
                If Label.Text = "M" Then
                    trouvé = True
                End If
                Bouton.BackColor = Color.Red
                selectione = True
                Label.Focus()
            Else
                trouvé = False
                Bouton.BackColor = Color.LightGray
                selectione = False
                Label.Hide()
            End If
        End If
        If verifGagner() Then
            MsgBox("Bravo ! Vous avez gagner !", MsgBoxStyle.OkOnly, "Démineur")
            Form1.Show()
            Jeu.Close()
        ElseIf perdu = True Then
            Form1.Show()
            Jeu.Close()
        End If
    End Sub

    Function verifGagner() 'fonction pas finie
        Dim count As Integer
        For i = 0 To Jeu.BoutonsMax - 1
            If Jeu.GetBoutonAff(i).getSelectione = True Then
                If Jeu.GetBoutonAff(i).getLabel.Text = "M" Then
                    count += 1
                Else
                    count -= 1
                End If
            End If
        Next
        If count = 10 Then
            Return True
        Else
            Return False
        End If
    End Function

    Sub setNum(i As Integer)
        Num = i
    End Sub

    Dim countTabZeroSpe As Integer = 0 ' prob pas de remise a zero
    Function propag(tab() As CLC, dejaVu() As Boolean, r As Integer)
        If r < 0 Or r >= Jeu.BoutonsMax Then
            Return Nothing
        End If
        If dejaVu(r) Then
            Return Nothing
        End If
        dejaVu(r) = True


        'bc de truc a voir (cote mauvais ect)
        If tab(r).Label.Text = "0" Then
            If r + Jeu.nbrColonnes < Jeu.BoutonsMax Then ' verif dans tab ( sud )
                If tab(r + Jeu.nbrColonnes).Label.Text <> "0" Then  ' sud
                    If r + Jeu.nbrColonnes + 1 < Jeu.BoutonsMax AndAlso (r + 1) Mod 8 <> 0 Then ' verif dans tab
                        If tab(r + 1).Label.Text <> "0" Then  ' est
                            If tab(r + Jeu.nbrColonnes + 1).Label.Text = "0" AndAlso dejaVu(r + Jeu.nbrColonnes + 1) = False Then 'sud-est si zero et diff zero sud & est
                                If casPartZero Is Nothing Then
                                    casPartZero(countTabZeroSpe) = r + Jeu.nbrColonnes + 1
                                Else
                                    countTabZeroSpe += 1
                                    ReDim casPartZero(countTabZeroSpe)
                                    casPartZero(countTabZeroSpe) = r + Jeu.nbrColonnes + 1
                                End If
                            End If
                        End If
                    End If
                    If (r - 1) Mod 8 <> 7 AndAlso r - 1 > -1 Then ' verif dans tab
                        If tab(r - 1).Label.Text <> "0" Then  ' ouest
                            If tab(r + Jeu.nbrColonnes - 1).Label.Text = "0" AndAlso dejaVu(r + Jeu.nbrColonnes - 1) = False Then 'sud-ouest si zero et diff zero sud & ouest
                                If casPartZero Is Nothing Then
                                    casPartZero(countTabZeroSpe) = r + Jeu.nbrColonnes - 1
                                Else
                                    countTabZeroSpe += 1
                                    ReDim casPartZero(countTabZeroSpe)
                                    casPartZero(countTabZeroSpe) = r + Jeu.nbrColonnes - 1
                                End If
                            End If
                        End If
                    End If
                End If
            End If

            If r - Jeu.nbrColonnes > -1 Then ' verif dans tab ( nord ) si cest bien superieur a -1
                If tab(r - Jeu.nbrColonnes).Label.Text <> "0" Then  ' nord
                    If r + 1 < Jeu.BoutonsMax Then
                        If tab(r + 1).Label.Text <> "0" Then  ' est
                            If r + 1 Mod 8 <> 0 Then ' verif dans tab
                                If tab(r - Jeu.nbrColonnes + 1).Label.Text = "0" Then
                                    If dejaVu(r - Jeu.nbrColonnes + 1) = False Then 'nord-est si zero et diff zero sud & est
                                        If casPartZero Is Nothing Then
                                            casPartZero(countTabZeroSpe) = r - Jeu.nbrColonnes + 1
                                        Else
                                            countTabZeroSpe += 1
                                            ReDim casPartZero(countTabZeroSpe)
                                            casPartZero(countTabZeroSpe) = r - Jeu.nbrColonnes + 1
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                    If r - Jeu.nbrColonnes - 1 > -1 AndAlso r - 1 Mod 8 <> 7 Then ' verif dans tab
                        If tab(r - 1).Label.Text <> "0" Then  ' ouest
                            If tab(r - Jeu.nbrColonnes - 1).Label.Text = "0" AndAlso dejaVu(r - Jeu.nbrColonnes - 1) = False Then 'nord-ouest si zero et diff zero sud & ouest
                                If casPartZero Is Nothing Then
                                    casPartZero(countTabZeroSpe) = r - Jeu.nbrColonnes - 1
                                Else
                                    countTabZeroSpe += 1
                                    ReDim casPartZero(countTabZeroSpe)
                                    casPartZero(countTabZeroSpe) = r - Jeu.nbrColonnes - 1
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If



        If r Mod 8 = 0 Then
            If tab(r).Label.Text = "0" Then
                afficher9cases(r)
                Jeu.GetBoutonAff(r).getBouton.visible = False
                propag(tab, dejaVu, r + 1)
            End If
        End If
        If r Mod 8 = 7 Then
            If tab(r).Label.Text = "0" Then
                afficher9cases(r)
                Jeu.GetBoutonAff(r).getBouton.visible = False
                propag(tab, dejaVu, r - 1)
            End If
        End If
        If tab(r).Label.Text <> "0" Then
            Return Nothing 'ajouter montrer val cas
        End If
        If tab(r).Label.Text = "0" Then
            afficher9cases(r)
            Jeu.GetBoutonAff(r).getBouton.visible = False
            If r Mod 8 <> 7 Then
                propag(tab, dejaVu, r + 1)
            End If
            If r Mod 8 <> 0 Then
                propag(tab, dejaVu, r - 1)
            End If
            propag(tab, dejaVu, r + Jeu.nbrColonnes)
            propag(tab, dejaVu, r - Jeu.nbrColonnes)
        End If
        Return Nothing
    End Function

    Sub afficher9cases(actu As Integer)
        Dim valY As Integer
        For casesY = -1 To 1
            If casesY = -1 Then
                valY = -8
            ElseIf casesY = 0 Then
                valY = 0
            Else
                valY = 8
            End If
            If valY + actu > -1 AndAlso valY + actu < Jeu.BoutonsMax Then
                For casesX = -1 To 1
                    If casesX + actu + valY > -1 AndAlso casesX + actu + valY < Jeu.BoutonsMax Then
                        If actu Mod 8 = 0 Then
                            If (actu + casesX + valY) Mod 8 <> 7 Then
                                Jeu.GetBoutonAff(actu + casesX + valY).getBouton.Visible = False
                            End If

                        ElseIf actu Mod 8 = 7 Then
                            If (actu + casesX + valY) Mod 8 <> 0 Then
                                Jeu.GetBoutonAff(actu + casesX + valY).getBouton.Visible = False
                            End If
                        ElseIf actu Mod 8 <> 7 OrElse actu Mod 8 <> 0 Then
                            Jeu.GetBoutonAff(actu + casesX + valY).getBouton.Visible = False
                        End If
                    End If
                Next
            End If
        Next
    End Sub


End Class


' ajout : 0 focus
' fin avec toutes case trouvers sauf mines
' changement de nom pour le mode mine et normal
' voir si le mettre en click gauche
' timer
' enregistrement dans feuille txt
' score
