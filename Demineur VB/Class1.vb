Public Class Class1 : Inherits GroupBox

    Private Bouton As Button
        Private Label As Label

    Sub New()

        Bouton = New Button()
        Bouton.Text = ""

        Label = New Label()
        Label.Text = "Label"
        Label.Visible = False

        Size = New Size(25, 25)
        Me.Padding = New Padding(3, 3, 3, 3)
        Controls.Add(Bouton)
        Controls.Add(Label)

    End Sub
End Class
