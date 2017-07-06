<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddMember_Resize
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.AddMemberButton = New System.Windows.Forms.Button()
        Me.label11 = New System.Windows.Forms.Label()
        Me.IDNumber = New System.Windows.Forms.RichTextBox()
        Me.FirstName_Label = New System.Windows.Forms.Label()
        Me.FirstName = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'AddMemberButton
        '
        Me.AddMemberButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AddMemberButton.Location = New System.Drawing.Point(340, 585)
        Me.AddMemberButton.Name = "AddMemberButton"
        Me.AddMemberButton.Size = New System.Drawing.Size(306, 46)
        Me.AddMemberButton.TabIndex = 1
        Me.AddMemberButton.Text = "Add Member"
        Me.AddMemberButton.UseVisualStyleBackColor = True
        '
        'label11
        '
        Me.label11.AutoSize = True
        Me.label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label11.Location = New System.Drawing.Point(13, 9)
        Me.label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label11.Name = "label11"
        Me.label11.Size = New System.Drawing.Size(26, 20)
        Me.label11.TabIndex = 117
        Me.label11.Text = "ID"
        '
        'IDNumber
        '
        Me.IDNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IDNumber.Location = New System.Drawing.Point(17, 33)
        Me.IDNumber.Margin = New System.Windows.Forms.Padding(4)
        Me.IDNumber.Multiline = False
        Me.IDNumber.Name = "IDNumber"
        Me.IDNumber.Size = New System.Drawing.Size(52, 28)
        Me.IDNumber.TabIndex = 118
        Me.IDNumber.Text = ""
        '
        'FirstName_Label
        '
        Me.FirstName_Label.AutoSize = True
        Me.FirstName_Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.FirstName_Label.Location = New System.Drawing.Point(12, 76)
        Me.FirstName_Label.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.FirstName_Label.Name = "FirstName_Label"
        Me.FirstName_Label.Size = New System.Drawing.Size(106, 25)
        Me.FirstName_Label.TabIndex = 119
        Me.FirstName_Label.Text = "First Name"
        '
        'FirstName
        '
        Me.FirstName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.FirstName.Location = New System.Drawing.Point(17, 105)
        Me.FirstName.Margin = New System.Windows.Forms.Padding(4)
        Me.FirstName.Multiline = False
        Me.FirstName.Name = "FirstName"
        Me.FirstName.Size = New System.Drawing.Size(571, 34)
        Me.FirstName.TabIndex = 120
        Me.FirstName.Text = ""
        '
        'AddMember_Resize
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1062, 673)
        Me.Controls.Add(Me.FirstName)
        Me.Controls.Add(Me.FirstName_Label)
        Me.Controls.Add(Me.IDNumber)
        Me.Controls.Add(Me.label11)
        Me.Controls.Add(Me.AddMemberButton)
        Me.Name = "AddMember_Resize"
        Me.Text = "AddMember_Resize"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents AddMemberButton As Button
    Friend WithEvents label11 As Label
    Friend WithEvents IDNumber As RichTextBox
    Friend WithEvents FirstName_Label As Label
    Friend WithEvents FirstName As RichTextBox
End Class
