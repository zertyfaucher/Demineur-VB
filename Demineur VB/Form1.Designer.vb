<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.ButQuitter = New System.Windows.Forms.Button()
        Me.CBNom = New System.Windows.Forms.ComboBox()
        Me.ButJouer = New System.Windows.Forms.Button()
        Me.ButScore = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ButQuitter
        '
        Me.ButQuitter.Location = New System.Drawing.Point(471, 377)
        Me.ButQuitter.Name = "ButQuitter"
        Me.ButQuitter.Size = New System.Drawing.Size(75, 23)
        Me.ButQuitter.TabIndex = 0
        Me.ButQuitter.Text = "Quitter"
        Me.ButQuitter.UseVisualStyleBackColor = True
        '
        'CBNom
        '
        Me.CBNom.FormattingEnabled = True
        Me.CBNom.Location = New System.Drawing.Point(319, 158)
        Me.CBNom.Name = "CBNom"
        Me.CBNom.Size = New System.Drawing.Size(121, 21)
        Me.CBNom.TabIndex = 1
        '
        'ButJouer
        '
        Me.ButJouer.Location = New System.Drawing.Point(235, 377)
        Me.ButJouer.Name = "ButJouer"
        Me.ButJouer.Size = New System.Drawing.Size(75, 23)
        Me.ButJouer.TabIndex = 2
        Me.ButJouer.Text = "Jouer"
        Me.ButJouer.UseVisualStyleBackColor = True
        '
        'ButScore
        '
        Me.ButScore.Location = New System.Drawing.Point(333, 377)
        Me.ButScore.Name = "ButScore"
        Me.ButScore.Size = New System.Drawing.Size(116, 23)
        Me.ButScore.TabIndex = 3
        Me.ButScore.Text = "Tableau des scores"
        Me.ButScore.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.ButScore)
        Me.Controls.Add(Me.ButJouer)
        Me.Controls.Add(Me.CBNom)
        Me.Controls.Add(Me.ButQuitter)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ButQuitter As Button
    Friend WithEvents CBNom As ComboBox
    Friend WithEvents ButJouer As Button
    Friend WithEvents ButScore As Button
End Class
