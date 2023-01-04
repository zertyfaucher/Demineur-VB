Public Class Jeu

    Dim Selection As Boolean = False
    Dim Chronometre As Boolean = True
    Dim premiere As Boolean = True

    Private Sub Jeu_Closed(sender As Object, e As EventArgs) Handles MyBase.Closed
        Form1.Show()
        Timer1.Stop()
    End Sub

    Private Sub Jeu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        Module1.resetValeurs()
        Module1.AttribueValeur()
        Module1.CreerCases()
        Module1.AttribueMines()
        Module1.AttribueValeurCases()
        Label1.Select()
        LabNomJoueur.Text = "Joueur : " & Form1.getJoueur
        premiere = False
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

    Private Sub initTimer() Handles MyBase.Load
        If Chronometre = True Then
            Module1.setChrono(Module1.getTempsMax())
            Timer1.Interval = 1000
            Timer1.Start()
        End If
    End Sub

    Private Sub Timer1_Tick() Handles Timer1.Tick
        If Module1.getChrono = 0 Then
            Timer1.Stop()
            MsgBox("Temps écoulé, vous avez perdu.", MsgBoxStyle.OkOnly, "Démineur")
            Form1.Show()
            Me.Close()
        Else
            Me.Text = Module1.getChrono()
            Module1.setChrono(getChrono() - 1)
        End If
    End Sub

    Function getSelection()
        Return Selection
    End Function

    Sub setChronometre(b As Boolean)
        Chronometre = b
    End Sub

    Function getChronometre()
        Return Chronometre
    End Function

    Function getPremiere()
        Return premiere
    End Function
End Class


