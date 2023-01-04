<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Options
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
        Me.LabLigne = New System.Windows.Forms.Label()
        Me.LabCol = New System.Windows.Forms.Label()
        Me.ButQuit = New System.Windows.Forms.Button()
        Me.LabMines = New System.Windows.Forms.Label()
        Me.LabChrono = New System.Windows.Forms.Label()
        Me.LabTmpChrono = New System.Windows.Forms.Label()
        Me.RBOui = New System.Windows.Forms.RadioButton()
        Me.RBNon = New System.Windows.Forms.RadioButton()
        Me.LabDiff = New System.Windows.Forms.Label()
        Me.CBDiff = New System.Windows.Forms.ComboBox()
        Me.CNChrono = New Demineur_VB.ChoixNombre()
        Me.CNMine = New Demineur_VB.ChoixNombre()
        Me.CNCol = New Demineur_VB.ChoixNombre()
        Me.CNLigne = New Demineur_VB.ChoixNombre()
        Me.SuspendLayout()
        '
        'LabLigne
        '
        Me.LabLigne.AutoSize = True
        Me.LabLigne.Location = New System.Drawing.Point(9, 65)
        Me.LabLigne.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabLigne.Name = "LabLigne"
        Me.LabLigne.Size = New System.Drawing.Size(95, 13)
        Me.LabLigne.TabIndex = 0
        Me.LabLigne.Text = "Nombre de lignes :"
        '
        'LabCol
        '
        Me.LabCol.AutoSize = True
        Me.LabCol.Location = New System.Drawing.Point(9, 105)
        Me.LabCol.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabCol.Name = "LabCol"
        Me.LabCol.Size = New System.Drawing.Size(111, 13)
        Me.LabCol.TabIndex = 1
        Me.LabCol.Text = "Nombre de colonnes :"
        '
        'ButQuit
        '
        Me.ButQuit.Location = New System.Drawing.Point(212, 332)
        Me.ButQuit.Margin = New System.Windows.Forms.Padding(2)
        Me.ButQuit.Name = "ButQuit"
        Me.ButQuit.Size = New System.Drawing.Size(56, 24)
        Me.ButQuit.TabIndex = 4
        Me.ButQuit.Text = "Quitter"
        Me.ButQuit.UseVisualStyleBackColor = True
        '
        'LabMines
        '
        Me.LabMines.AutoSize = True
        Me.LabMines.Location = New System.Drawing.Point(9, 145)
        Me.LabMines.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabMines.Name = "LabMines"
        Me.LabMines.Size = New System.Drawing.Size(95, 13)
        Me.LabMines.TabIndex = 4
        Me.LabMines.Text = "Nombre de mines :"
        '
        'LabChrono
        '
        Me.LabChrono.AutoSize = True
        Me.LabChrono.Location = New System.Drawing.Point(9, 192)
        Me.LabChrono.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabChrono.Name = "LabChrono"
        Me.LabChrono.Size = New System.Drawing.Size(47, 13)
        Me.LabChrono.TabIndex = 7
        Me.LabChrono.Text = "Chrono :"
        '
        'LabTmpChrono
        '
        Me.LabTmpChrono.AutoSize = True
        Me.LabTmpChrono.Location = New System.Drawing.Point(9, 230)
        Me.LabTmpChrono.Name = "LabTmpChrono"
        Me.LabTmpChrono.Size = New System.Drawing.Size(79, 13)
        Me.LabTmpChrono.TabIndex = 8
        Me.LabTmpChrono.Text = "TempsChrono :"
        '
        'RBOui
        '
        Me.RBOui.AutoSize = True
        Me.RBOui.Location = New System.Drawing.Point(143, 190)
        Me.RBOui.Name = "RBOui"
        Me.RBOui.Size = New System.Drawing.Size(41, 17)
        Me.RBOui.TabIndex = 9
        Me.RBOui.Text = "Oui"
        Me.RBOui.UseVisualStyleBackColor = True
        '
        'RBNon
        '
        Me.RBNon.AutoSize = True
        Me.RBNon.Location = New System.Drawing.Point(223, 190)
        Me.RBNon.Name = "RBNon"
        Me.RBNon.Size = New System.Drawing.Size(45, 17)
        Me.RBNon.TabIndex = 10
        Me.RBNon.Text = "Non"
        Me.RBNon.UseVisualStyleBackColor = True
        '
        'LabDiff
        '
        Me.LabDiff.AutoSize = True
        Me.LabDiff.Location = New System.Drawing.Point(9, 30)
        Me.LabDiff.Name = "LabDiff"
        Me.LabDiff.Size = New System.Drawing.Size(54, 13)
        Me.LabDiff.TabIndex = 11
        Me.LabDiff.Text = "Difficulté :"
        '
        'CBDiff
        '
        Me.CBDiff.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBDiff.FormattingEnabled = True
        Me.CBDiff.Location = New System.Drawing.Point(143, 27)
        Me.CBDiff.Name = "CBDiff"
        Me.CBDiff.Size = New System.Drawing.Size(125, 21)
        Me.CBDiff.TabIndex = 12
        '
        'CNChrono
        '
        Me.CNChrono.Location = New System.Drawing.Point(143, 230)
        Me.CNChrono.Margin = New System.Windows.Forms.Padding(2)
        Me.CNChrono.Name = "CNChrono"
        Me.CNChrono.Size = New System.Drawing.Size(125, 22)
        Me.CNChrono.TabIndex = 6
        '
        'CNMine
        '
        Me.CNMine.Location = New System.Drawing.Point(143, 145)
        Me.CNMine.Margin = New System.Windows.Forms.Padding(2)
        Me.CNMine.Name = "CNMine"
        Me.CNMine.Size = New System.Drawing.Size(125, 22)
        Me.CNMine.TabIndex = 5
        '
        'CNCol
        '
        Me.CNCol.Location = New System.Drawing.Point(143, 105)
        Me.CNCol.Margin = New System.Windows.Forms.Padding(2)
        Me.CNCol.Name = "CNCol"
        Me.CNCol.Size = New System.Drawing.Size(125, 22)
        Me.CNCol.TabIndex = 3
        '
        'CNLigne
        '
        Me.CNLigne.Location = New System.Drawing.Point(143, 65)
        Me.CNLigne.Margin = New System.Windows.Forms.Padding(2)
        Me.CNLigne.Name = "CNLigne"
        Me.CNLigne.Size = New System.Drawing.Size(125, 23)
        Me.CNLigne.TabIndex = 2
        '
        'Options
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 366)
        Me.Controls.Add(Me.CBDiff)
        Me.Controls.Add(Me.LabDiff)
        Me.Controls.Add(Me.RBNon)
        Me.Controls.Add(Me.RBOui)
        Me.Controls.Add(Me.LabTmpChrono)
        Me.Controls.Add(Me.LabChrono)
        Me.Controls.Add(Me.CNChrono)
        Me.Controls.Add(Me.CNMine)
        Me.Controls.Add(Me.LabMines)
        Me.Controls.Add(Me.ButQuit)
        Me.Controls.Add(Me.CNCol)
        Me.Controls.Add(Me.CNLigne)
        Me.Controls.Add(Me.LabCol)
        Me.Controls.Add(Me.LabLigne)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "Options"
        Me.Text = "Options"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabLigne As Label
    Friend WithEvents LabCol As Label
    Friend WithEvents CNLigne As ChoixNombre
    Friend WithEvents CNCol As ChoixNombre
    Friend WithEvents ButQuit As Button
    Friend WithEvents CNMine As ChoixNombre
    Friend WithEvents LabMines As Label
    Friend WithEvents CNChrono As ChoixNombre
    Friend WithEvents LabChrono As Label
    Friend WithEvents LabTmpChrono As Label
    Friend WithEvents RBOui As RadioButton
    Friend WithEvents RBNon As RadioButton
    Friend WithEvents LabDiff As Label
    Friend WithEvents CBDiff As ComboBox
End Class
