<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Manual
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.TopicToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmailToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DependToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangelogToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QuitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Manual_Text = New System.Windows.Forms.RichTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Page_Number = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TopicToolStripMenuItem, Me.QuitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1062, 28)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'TopicToolStripMenuItem
        '
        Me.TopicToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem2, Me.EmailToolStripMenuItem, Me.SettingsToolStripMenuItem, Me.DependToolStripMenuItem, Me.ChangelogToolStripMenuItem})
        Me.TopicToolStripMenuItem.Name = "TopicToolStripMenuItem"
        Me.TopicToolStripMenuItem.Size = New System.Drawing.Size(57, 24)
        Me.TopicToolStripMenuItem.Text = "Topic"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(197, 26)
        Me.ToolStripMenuItem1.Text = "Welcome"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(197, 26)
        Me.ToolStripMenuItem2.Text = "Interface"
        '
        'EmailToolStripMenuItem
        '
        Me.EmailToolStripMenuItem.Name = "EmailToolStripMenuItem"
        Me.EmailToolStripMenuItem.Size = New System.Drawing.Size(197, 26)
        Me.EmailToolStripMenuItem.Text = "Email"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(197, 26)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        '
        'DependToolStripMenuItem
        '
        Me.DependToolStripMenuItem.Name = "DependToolStripMenuItem"
        Me.DependToolStripMenuItem.Size = New System.Drawing.Size(197, 26)
        Me.DependToolStripMenuItem.Text = "Dependant Table"
        '
        'ChangelogToolStripMenuItem
        '
        Me.ChangelogToolStripMenuItem.Name = "ChangelogToolStripMenuItem"
        Me.ChangelogToolStripMenuItem.Size = New System.Drawing.Size(197, 26)
        Me.ChangelogToolStripMenuItem.Text = "Changelog"
        '
        'QuitToolStripMenuItem
        '
        Me.QuitToolStripMenuItem.Name = "QuitToolStripMenuItem"
        Me.QuitToolStripMenuItem.Size = New System.Drawing.Size(49, 24)
        Me.QuitToolStripMenuItem.Text = "Quit"
        '
        'Manual_Text
        '
        Me.Manual_Text.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Manual_Text.Location = New System.Drawing.Point(12, 43)
        Me.Manual_Text.Name = "Manual_Text"
        Me.Manual_Text.ReadOnly = True
        Me.Manual_Text.Size = New System.Drawing.Size(1038, 508)
        Me.Manual_Text.TabIndex = 1
        Me.Manual_Text.TabStop = False
        Me.Manual_Text.Text = ""
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 627)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 26)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Page"
        '
        'Page_Number
        '
        Me.Page_Number.Location = New System.Drawing.Point(73, 631)
        Me.Page_Number.Name = "Page_Number"
        Me.Page_Number.Size = New System.Drawing.Size(36, 22)
        Me.Page_Number.TabIndex = 6
        Me.Page_Number.TabStop = False
        '
        'Button2
        '
        Me.Button2.Image = Global.WindowsApplication1.My.Resources.Resources.left_arro2
        Me.Button2.Location = New System.Drawing.Point(512, 568)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(201, 98)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Image = Global.WindowsApplication1.My.Resources.Resources.right_arrow
        Me.Button1.Location = New System.Drawing.Point(738, 568)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(201, 98)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Manual
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1062, 673)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Page_Number)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Manual_Text)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Manual"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Manual"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents HelpProvider1 As HelpProvider
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents TopicToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents QuitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Manual_Text As RichTextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Page_Number As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents EmailToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DependToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ChangelogToolStripMenuItem As ToolStripMenuItem
End Class
