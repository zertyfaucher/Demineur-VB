Module Module1
    Dim nbrLignes As Integer = 8
    Dim nbrColonnes As Integer = 8
    Dim BoutonsMax = nbrColonnes * nbrLignes
    Dim Boutons(BoutonsMax) As Cases
    Dim WithEvents b As Cases
    Dim NbrMines As Integer = 10
    Dim TempsMax As Integer = 60
    Dim Chrono As Integer = 0
    Dim nbrDecouvert As Integer = 0
    Dim temps As Integer = 0
    Dim Joueurs(0) As Personne
    Dim nbrJoueurs = 0

    Sub LectureFichier()
        Dim Fichier As Integer = FreeFile()
        FileOpen(Fichier, "Joueurs.txt", OpenMode.Input)
        Dim ligne As Integer = 0
        Dim nextLine As String
        Dim p As Personne
        p = New Personne
        Do Until EOF(Fichier)
            For i = 0 To 4
                nextLine = LineInput(Fichier)
                If ligne Mod 5 = 0 Then
                    p.setNom(nextLine)
                ElseIf ligne Mod 5 = 1 Then
                    p.setNbCase(Val(nextLine))
                ElseIf ligne Mod 5 = 2 Then
                    p.setTemps(Val(nextLine))
                ElseIf ligne Mod 5 = 3 Then
                    p.setTempsTotal(Val(nextLine))
                Else
                    p.setNbPartie(Val(nextLine))
                End If
                ligne += 1
            Next
            EnregistrerPersFichier(p.getNom, p.getNbCase, p.getTemps, p.getNbPartie, p.getTempsTotal)
        Loop
        FileClose()
    End Sub

    Sub AjouterJoueurFichier()
        Dim Fichier As Integer = FreeFile()
        FileOpen(Fichier, "Joueurs.txt", OpenMode.Output)
        For i = 0 To Joueurs.Length - 1
            Dim p As Personne
            p = Joueurs(i)
            WriteLine(Fichier, p.getNom)
            WriteLine(Fichier, p.getNbCase)
            WriteLine(Fichier, p.getTemps)
            WriteLine(Fichier, p.getNbPartie)
            WriteLine(Fichier, p.getTempsTotal)
        Next
        FileClose()
    End Sub


    Sub EnregistrerPremierjoueur()
        Joueurs(0) = New Personne
        Joueurs(0).setNom("X")
        Joueurs(0).setNbCase(0)
        Joueurs(0).setTemps(0)
    End Sub

    Function getJoueur(n As String)
        For i = 0 To Joueurs.Length - 1
            If Joueurs(i).getNom = n Then
                Return Joueurs(i)
            End If
        Next
        Return 0
    End Function

    Sub AttribueValeur()
        BoutonsMax = nbrColonnes * nbrLignes
        ReDim Boutons(BoutonsMax)
    End Sub

    Sub CreerCases()
        Dim X As Integer
        Dim Y As Integer
        Dim Ecart = 27
        For i = 0 To BoutonsMax - 1
            b = New Cases()
            b.setNum(i)
            Jeu.Controls.Add(b)
            X += Ecart
            If i Mod nbrColonnes = 0 Then
                Y += Ecart
                X = 220
            End If
            b.Left = X
            b.Top = Y
            Boutons(i) = b
        Next
    End Sub

    Sub AttribueMines()
        For i = 0 To NbrMines - 1
            Dim tmp = MineAlea(0, BoutonsMax)
            Boutons(tmp).getLabel.Text = "M"
        Next
    End Sub

    Sub AttribueValeurCases()
        Dim count As Integer
        For i = 0 To BoutonsMax - 1
            count = 0
            If Boutons(i).getLabel.Text <> "M" Then
                If i Mod nbrColonnes = 0 Then
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
                ElseIf i Mod nbrColonnes = nbrColonnes - 1 Then
                    If i - nbrLignes < 0 Then
                        If Boutons(i + nbrColonnes).getLabel.Text = "M" Then
                            count += 1
                        End If
                        If Boutons(i + nbrColonnes - 1).getLabel.Text = "M" Then
                            count += 1
                        End If
                    ElseIf i + nbrLignes > BoutonsMax - 1 Then
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
        Dim b As Cases = Boutons(I)
        If b.getLabel.Text = "M" Then
            Return False
        Else
            Return True
        End If
    End Function

    Sub resetValeurs()
        setTemps(0)
        setNbrDecouvert(0)
    End Sub

    Function GetBouton()
        Return Boutons
    End Function

    Function GetBoutonAff(i As Integer)
        Return Boutons(i)
    End Function

    Function getTemps()
        Return temps
    End Function

    Function getTempsMax()
        Return TempsMax
    End Function

    Function getNbrDecouvert()
        Return nbrDecouvert
    End Function

    Function getChrono()
        Return Chrono
    End Function

    Sub setTemps(i As Integer)
        temps = i
    End Sub

    Sub ajoutDecouvert()
        nbrDecouvert += 1
    End Sub

    Sub setNbrDecouvert(i As Integer)
        nbrDecouvert = i
    End Sub

    Sub setChrono(i)
        Chrono = i
    End Sub

    Function getNbrColonnes()
        Return nbrColonnes
    End Function

    Function getNbrLignes()
        Return nbrLignes
    End Function

    Sub setNbrColonnes(i)
        nbrColonnes = i
    End Sub

    Sub setNbrLignes(i)
        nbrLignes = i
    End Sub

    Sub setNbrMines(i)
        NbrMines = i
    End Sub

    Function getBoutonsMax()
        Return BoutonsMax
    End Function

    Function getNbrMines()
        Return NbrMines
    End Function

    Sub setTempsMax(i)
        TempsMax = i
    End Sub

    Function getJoueurs()
        Return Joueurs
    End Function

    Function getJoueurs(i As Integer)
        Return Joueurs(i)
    End Function

    Class Cases : Inherits Panel
        Private Num As Integer
        Private WithEvents Bouton As Button
        Private WithEvents Label As Label
        Private selectione As Boolean = False
        Private trouvé As Boolean = False
        Private casPartZero(0) As Integer
        Dim countTabZeroSpe As Integer = 0
        Dim CasPartB As Boolean = False

        Sub New()

            Bouton = New Button()
            Bouton.Size = New Size(25, 25)
            Bouton.Text = Nothing
            Bouton.BackColor = Color.LightGray

            Label = New Label()
            Label.Text = "."
            Label.Size = New Size(25, 25)
            Label.Left = 7
            Label.Top = 7

            Size = New Size(25, 25)
            Controls.Add(Bouton)
            Controls.Add(Label)

        End Sub

        Function getSelectione()
            Return selectione
        End Function

        Sub Bouton_Click(sender As Object, e As EventArgs) Handles Bouton.Click
            Dim perdu As Boolean = False
            If Jeu.getSelection = False Then
                Bouton.Visible = False
                Label.Focus()
                Dim dejaVu(getBoutonsMax) As Boolean
                If Label.Text = "M" Then
                    Dim res As Boolean = False
                    finPartie(res)
                    Exit Sub
                Else
                    Dim tmp = getTempsMax() - getChrono()
                    setTemps(tmp)
                End If
                If Label.Text = "0" Then
                    propag(Module1.GetBouton, dejaVu, Num)
                Else
                    trouvé = True
                    ajoutDecouvert()
                End If
            Else
                If selectione = False Then
                    Bouton.BackColor = Color.Red
                    selectione = True
                    Label.Focus()
                Else
                    Bouton.BackColor = Color.LightGray
                    selectione = False
                    Label.Hide()
                End If
            End If
            If verifGagner() Then
                finPartie(verifGagner)
            End If
        End Sub

        Sub finPartie(res As Boolean)
            Jeu.Timer1.Stop()
            Dim textRes As String
            If Jeu.getChronometre = True Then
                textRes = "Vous avez découvert " & getNbrDecouvert() & " cases en " & getTemps() & " secondes"
            Else
                textRes = "Vous avez découvert " & getNbrDecouvert() & " cases"
            End If

            If res = True Then
                MsgBox(textRes, MsgBoxStyle.OkOnly, "Partie gagnée")
            Else
                MsgBox(textRes, MsgBoxStyle.OkOnly, "Partie perdue")
            End If
            EnregistrerPers(Form1.getJoueur, getNbrDecouvert, getTemps)
            Form1.Show()
            Jeu.Close()
        End Sub

        Function verifGagner()
            Dim count As Integer
            For i = 0 To getBoutonsMax() - 1
                If GetBoutonAff(i).getTrouvé = True Then
                    count += 1
                End If
            Next
            Jeu.Test.Text = "" & count
            setNbrDecouvert(count)
            If count = getBoutonsMax() - getNbrMines() Then
                Return True
            Else
                Return False
            End If
        End Function

        Sub setNum(i As Integer)
            Num = i
        End Sub

        Function propag(tab() As Cases, dejaVu() As Boolean, r As Integer)
            If r < 0 Or r >= getBoutonsMax() Then
                Return Nothing
            End If
            If dejaVu(r) Then
                Return Nothing
            End If
            dejaVu(r) = True
            If tab(r).Label.Text = "0" Then
                If r + nbrColonnes < BoutonsMax Then ' verif dans tab ( sud )
                    If tab(r + nbrColonnes).Label.Text <> "0" Then  ' sud
                        If r + nbrColonnes + 1 < BoutonsMax AndAlso (r + 1) Mod 8 <> 0 Then ' verif dans tab
                            If tab(r + 1).Label.Text <> "0" Then  ' est
                                If tab(r + nbrColonnes + 1).Label.Text = "0" AndAlso dejaVu(r + nbrColonnes + 1) = False Then 'sud-est si zero et diff zero sud & est
                                    If CasPartB = False Then
                                        casPartZero(countTabZeroSpe) = r + nbrColonnes + 1
                                        CasPartB = True
                                    Else
                                        countTabZeroSpe += 1
                                        ReDim Preserve casPartZero(countTabZeroSpe)
                                        casPartZero(countTabZeroSpe) = r + nbrColonnes + 1
                                        CasPartB = True
                                    End If
                                End If
                            End If
                        End If
                        If (r - 1) Mod nbrColonnes <> nbrColonnes - 1 AndAlso r - 1 > -1 Then ' verif dans tab
                            If tab(r - 1).Label.Text <> "0" Then  ' ouest
                                If tab(r + nbrColonnes - 1).Label.Text = "0" AndAlso dejaVu(r + nbrColonnes - 1) = False Then 'sud-ouest si zero et diff zero sud & ouest
                                    If CasPartB = False Then
                                        casPartZero(countTabZeroSpe) = r + nbrColonnes - 1
                                        CasPartB = True
                                    Else
                                        countTabZeroSpe += 1
                                        ReDim Preserve casPartZero(countTabZeroSpe)
                                        casPartZero(countTabZeroSpe) = r + nbrColonnes - 1
                                        CasPartB = True
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If

                If r - nbrColonnes > -1 Then ' verif dans tab ( nord ) si cest bien superieur a -1
                    If tab(r - nbrColonnes).Label.Text <> "0" Then  ' nord
                        If r + 1 < BoutonsMax Then
                            If tab(r + 1).Label.Text <> "0" Then  ' est
                                If r + 1 Mod 8 <> 0 Then ' verif dans tab
                                    If tab(r - nbrColonnes + 1).Label.Text = "0" Then
                                        If dejaVu(r - nbrColonnes + 1) = False Then 'nord-est si zero et diff zero sud & est
                                            If CasPartB = False Then
                                                casPartZero(countTabZeroSpe) = r - nbrColonnes + 1
                                                CasPartB = True
                                            Else
                                                countTabZeroSpe += 1
                                                ReDim Preserve casPartZero(countTabZeroSpe)
                                                casPartZero(countTabZeroSpe) = r - nbrColonnes + 1
                                                CasPartB = True
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                        If r - nbrColonnes - 1 > -1 AndAlso r - 1 Mod 8 <> 7 Then ' verif dans tab
                            If tab(r - 1).Label.Text <> "0" Then  ' ouest
                                If tab(r - nbrColonnes - 1).Label.Text = "0" AndAlso dejaVu(r - nbrColonnes - 1) = False Then 'nord-ouest si zero et diff zero sud & ouest
                                    If CasPartB = False Then
                                        casPartZero(countTabZeroSpe) = r - nbrColonnes - 1
                                        CasPartB = True
                                    Else
                                        countTabZeroSpe += 1
                                        ReDim Preserve casPartZero(countTabZeroSpe)
                                        casPartZero(countTabZeroSpe) = r - nbrColonnes - 1
                                        CasPartB = True
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
            If r Mod getNbrColonnes() = 0 Then
                If tab(r).Label.Text = "0" Then
                    afficher9cases(r)
                    GetBoutonAff(r).getBouton.visible = False
                    GetBoutonAff(r).setTrouvé(True)
                    propag(tab, dejaVu, r + 1)
                End If
            End If
            If r Mod getNbrColonnes() = getNbrColonnes() - 1 Then
                If tab(r).Label.Text = "0" Then
                    afficher9cases(r)
                    GetBoutonAff(r).getBouton.visible = False
                    GetBoutonAff(r).setTrouvé(True)
                    propag(tab, dejaVu, r - 1)
                End If
            End If
            If tab(r).Label.Text <> "0" Then
                Return Nothing 'ajouter montrer val cas
            End If
            If tab(r).Label.Text = "0" Then
                afficher9cases(r)
                GetBoutonAff(r).getBouton.visible = False
                GetBoutonAff(r).setTrouvé(True)
                If r Mod getNbrColonnes() <> getNbrColonnes() - 1 Then
                    propag(tab, dejaVu, r + 1)
                End If
                If r Mod getNbrColonnes() <> 0 Then
                    propag(tab, dejaVu, r - 1)
                End If
                propag(tab, dejaVu, r + getNbrColonnes())
                propag(tab, dejaVu, r - getNbrColonnes())
            End If
            ajoutDecouvert()
            Return Nothing
        End Function

        Sub afficher9cases(actu As Integer)
            Dim valY As Integer
            For casesY = -1 To 1
                If casesY = -1 Then
                    valY = -getNbrLignes()
                ElseIf casesY = 0 Then
                    valY = 0
                Else
                    valY = getNbrLignes()
                End If
                If valY + actu > -1 AndAlso valY + actu < getBoutonsMax() Then
                    For casesX = -1 To 1
                        If casesX + actu + valY > -1 AndAlso casesX + actu + valY < getBoutonsMax() Then
                            If actu Mod getNbrColonnes() = 0 Then
                                If (actu + casesX + valY) Mod getNbrColonnes() <> getNbrColonnes() - 1 Then
                                    GetBoutonAff(actu + casesX + valY).getBouton.Visible = False
                                    GetBoutonAff(actu + casesX + valY).setTrouvé(True)
                                End If

                            ElseIf actu Mod getNbrColonnes() = getNbrColonnes() - 1 Then
                                If (actu + casesX + valY) Mod getNbrColonnes() <> 0 Then
                                    GetBoutonAff(actu + casesX + valY).getBouton.Visible = False
                                    GetBoutonAff(actu + casesX + valY).setTrouvé(True)
                                End If
                            ElseIf actu Mod getNbrColonnes() <> getNbrColonnes() - 1 OrElse actu Mod getNbrColonnes() <> 0 Then
                                GetBoutonAff(actu + casesX + valY).getBouton.Visible = False
                                GetBoutonAff(actu + casesX + valY).setTrouvé(True)
                            End If
                        End If
                    Next
                End If
            Next
        End Sub

        Function getLabel()
            Return Label
        End Function

        Function getBouton()
            Return Bouton
        End Function

        Function gettrouvé()
            Return trouvé
        End Function

        Sub setTrouvé(b As Boolean)
            trouvé = b
        End Sub

    End Class

    Class Personne

        Private nom As String
        Private nbCase As Integer
        Private temps As Integer
        Private nbPartie As Integer
        Private tempsTotal As Integer
        'Private RefJ As Integer = 0

        Function getNom()
            Return nom
        End Function

        Function getNbCase()
            Return nbCase
        End Function

        Function getTemps()
            Return temps
        End Function

        Function getNbPartie()
            Return nbPartie
        End Function

        Function getTempsTotal()
            Return tempsTotal
        End Function

        Sub setNom(n As String)
            nom = n
        End Sub

        Sub setNbCase(i As Integer)
            nbCase = i
        End Sub

        Sub setTemps(i As Integer)
            temps = i
        End Sub

        Sub setNbPartie(i As Integer)
            nbPartie = i
        End Sub

        Sub setTempsTotal(i As Integer)
            tempsTotal = i
        End Sub
    End Class


    Sub EnregistrerPers(n As String, nbC As Integer, tmp As Integer)

        Dim nouveau As Boolean = True

        For index = 0 To Joueurs.Length - 1
            If Joueurs(index).getNom = n Then
                nouveau = False
                If nbC >= Joueurs(index).getNbCase Then
                    If tmp < Joueurs(index).getTemps Then
                        Joueurs(index).setNom(n)
                        Joueurs(index).setNbPartie(Joueurs(index).getNbPartie + 1)
                        Joueurs(index).setNbCase(nbC)
                        Joueurs(index).setTempsTotal(Joueurs(index).getTempsTotal + tmp)
                        Joueurs(index).setTemps(tmp)
                        Exit Sub
                    End If
                End If
            End If
        Next

        If nouveau = True Then
            Dim p As Personne
            p = New Personne
            p.setNom(n)
            p.setNbCase(nbC)
            p.setNbPartie(1)
            p.setTemps(tmp)
            p.setTempsTotal(tmp)
            If nbrJoueurs <> 0 Then
                ReDim Preserve Joueurs(nbrJoueurs)
            End If
            Joueurs(nbrJoueurs) = p
            nbrJoueurs += 1
            AjouterJoueurFichier()
        End If
    End Sub

    Sub EnregistrerPersFichier(n As String, nbC As Integer, tmp As Integer, tmpTot As Integer, nbPart As Integer)

        Dim p As Personne
        p = New Personne
        p.setNom(n)
        p.setNbCase(nbC)
        p.setNbPartie(nbPart)
        p.setTemps(tmp)
        p.setTempsTotal(tmpTot)
        If nbrJoueurs <> 0 Then
            ReDim Preserve Joueurs(nbrJoueurs)
        End If
        Joueurs(nbrJoueurs) = p
        nbrJoueurs += 1
    End Sub
End Module
