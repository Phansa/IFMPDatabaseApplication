<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChildView
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
        Me.Children_Grid = New System.Windows.Forms.DataGridView()
        Me.ChildName = New System.Windows.Forms.RichTextBox()
        Me.ChildAge = New System.Windows.Forms.RichTextBox()
        Me.ChildSchool = New System.Windows.Forms.RichTextBox()
        Me.AdultName = New System.Windows.Forms.RichTextBox()
        Me.Adults_Grid = New System.Windows.Forms.DataGridView()
        Me.Adults_Label = New System.Windows.Forms.Label()
        Me.Children_Label = New System.Windows.Forms.Label()
        Me.ChildId = New System.Windows.Forms.RichTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddChildToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddAdultToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GoToToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MainViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ManualToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateMember = New System.Windows.Forms.Button()
        Me.ViewDatabase = New System.Windows.Forms.Button()
        Me.Child_Name_Label = New System.Windows.Forms.Label()
        Me.Child_Age_Label = New System.Windows.Forms.Label()
        Me.Child_School_Label = New System.Windows.Forms.Label()
        Me.MemberID = New System.Windows.Forms.RichTextBox()
        Me.Member_Id_Label = New System.Windows.Forms.Label()
        Me.Adult_Name_Label = New System.Windows.Forms.Label()
        Me.AdultId = New System.Windows.Forms.RichTextBox()
        Me.Adult_Id_Label = New System.Windows.Forms.Label()
        Me.DBUpdateHand = New System.Windows.Forms.Button()
        Me.Remove = New System.Windows.Forms.Button()
        Me.Remove_Adult = New System.Windows.Forms.Button()
        Me.Add_Adult = New System.Windows.Forms.Button()
        Me.Update_Adult = New System.Windows.Forms.Button()
        Me.View_Adult = New System.Windows.Forms.Button()
        Me.AdultAge = New System.Windows.Forms.RichTextBox()
        Me.Adult_Age_Label = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.RelationshipBox = New System.Windows.Forms.RichTextBox()
        Me.Delete_All = New System.Windows.Forms.Button()
        CType(Me.Children_Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Adults_Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Children_Grid
        '
        Me.Children_Grid.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Children_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Children_Grid.Location = New System.Drawing.Point(421, 35)
        Me.Children_Grid.Name = "Children_Grid"
        Me.Children_Grid.RowTemplate.Height = 24
        Me.Children_Grid.Size = New System.Drawing.Size(1096, 349)
        Me.Children_Grid.TabIndex = 0
        '
        'ChildName
        '
        Me.ChildName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.ChildName.Location = New System.Drawing.Point(4, 217)
        Me.ChildName.Margin = New System.Windows.Forms.Padding(4)
        Me.ChildName.Multiline = False
        Me.ChildName.Name = "ChildName"
        Me.ChildName.Size = New System.Drawing.Size(214, 34)
        Me.ChildName.TabIndex = 1
        Me.ChildName.Text = ""
        '
        'ChildAge
        '
        Me.ChildAge.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.ChildAge.Location = New System.Drawing.Point(4, 282)
        Me.ChildAge.Margin = New System.Windows.Forms.Padding(4)
        Me.ChildAge.Multiline = False
        Me.ChildAge.Name = "ChildAge"
        Me.ChildAge.Size = New System.Drawing.Size(214, 34)
        Me.ChildAge.TabIndex = 2
        Me.ChildAge.Text = ""
        '
        'ChildSchool
        '
        Me.ChildSchool.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.ChildSchool.Location = New System.Drawing.Point(4, 350)
        Me.ChildSchool.Margin = New System.Windows.Forms.Padding(4)
        Me.ChildSchool.Multiline = False
        Me.ChildSchool.Name = "ChildSchool"
        Me.ChildSchool.Size = New System.Drawing.Size(214, 34)
        Me.ChildSchool.TabIndex = 3
        Me.ChildSchool.Text = ""
        '
        'AdultName
        '
        Me.AdultName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.AdultName.Location = New System.Drawing.Point(0, 557)
        Me.AdultName.Margin = New System.Windows.Forms.Padding(4)
        Me.AdultName.Multiline = False
        Me.AdultName.Name = "AdultName"
        Me.AdultName.Size = New System.Drawing.Size(214, 34)
        Me.AdultName.TabIndex = 6
        Me.AdultName.TabStop = False
        Me.AdultName.Text = ""
        '
        'Adults_Grid
        '
        Me.Adults_Grid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Adults_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Adults_Grid.Location = New System.Drawing.Point(417, 436)
        Me.Adults_Grid.Name = "Adults_Grid"
        Me.Adults_Grid.RowTemplate.Height = 24
        Me.Adults_Grid.Size = New System.Drawing.Size(1096, 335)
        Me.Adults_Grid.TabIndex = 114
        '
        'Adults_Label
        '
        Me.Adults_Label.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Adults_Label.AutoSize = True
        Me.Adults_Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!)
        Me.Adults_Label.Location = New System.Drawing.Point(836, 390)
        Me.Adults_Label.Name = "Adults_Label"
        Me.Adults_Label.Size = New System.Drawing.Size(90, 31)
        Me.Adults_Label.TabIndex = 115
        Me.Adults_Label.Text = "Adults"
        '
        'Children_Label
        '
        Me.Children_Label.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Children_Label.AutoSize = True
        Me.Children_Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!)
        Me.Children_Label.Location = New System.Drawing.Point(836, 1)
        Me.Children_Label.Name = "Children_Label"
        Me.Children_Label.Size = New System.Drawing.Size(161, 31)
        Me.Children_Label.TabIndex = 116
        Me.Children_Label.Text = "Dependents"
        '
        'ChildId
        '
        Me.ChildId.BackColor = System.Drawing.SystemColors.Window
        Me.ChildId.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.ChildId.Location = New System.Drawing.Point(4, 152)
        Me.ChildId.Margin = New System.Windows.Forms.Padding(4)
        Me.ChildId.Multiline = False
        Me.ChildId.Name = "ChildId"
        Me.ChildId.Size = New System.Drawing.Size(214, 34)
        Me.ChildId.TabIndex = 5
        Me.ChildId.Text = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Label1.Location = New System.Drawing.Point(-1, 123)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(129, 25)
        Me.Label1.TabIndex = 118
        Me.Label1.Text = "Dependent Id"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1530, 28)
        Me.MenuStrip1.TabIndex = 119
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MenuToolStripMenuItem
        '
        Me.MenuToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddChildToolStripMenuItem, Me.AddAdultToolStripMenuItem, Me.GoToToolStripMenuItem, Me.ViewAllToolStripMenuItem})
        Me.MenuToolStripMenuItem.Name = "MenuToolStripMenuItem"
        Me.MenuToolStripMenuItem.Size = New System.Drawing.Size(58, 24)
        Me.MenuToolStripMenuItem.Text = "Menu"
        '
        'AddChildToolStripMenuItem
        '
        Me.AddChildToolStripMenuItem.Name = "AddChildToolStripMenuItem"
        Me.AddChildToolStripMenuItem.Size = New System.Drawing.Size(197, 26)
        Me.AddChildToolStripMenuItem.Text = "Add Child"
        '
        'AddAdultToolStripMenuItem
        '
        Me.AddAdultToolStripMenuItem.Name = "AddAdultToolStripMenuItem"
        Me.AddAdultToolStripMenuItem.Size = New System.Drawing.Size(197, 26)
        Me.AddAdultToolStripMenuItem.Text = "Add Adult"
        '
        'GoToToolStripMenuItem
        '
        Me.GoToToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MainViewToolStripMenuItem, Me.ManualToolStripMenuItem})
        Me.GoToToolStripMenuItem.Name = "GoToToolStripMenuItem"
        Me.GoToToolStripMenuItem.Size = New System.Drawing.Size(197, 26)
        Me.GoToToolStripMenuItem.Text = "Go To"
        '
        'MainViewToolStripMenuItem
        '
        Me.MainViewToolStripMenuItem.Name = "MainViewToolStripMenuItem"
        Me.MainViewToolStripMenuItem.Size = New System.Drawing.Size(181, 26)
        Me.MainViewToolStripMenuItem.Text = "Main View"
        '
        'ManualToolStripMenuItem
        '
        Me.ManualToolStripMenuItem.Name = "ManualToolStripMenuItem"
        Me.ManualToolStripMenuItem.Size = New System.Drawing.Size(181, 26)
        Me.ManualToolStripMenuItem.Text = "Manual"
        '
        'ViewAllToolStripMenuItem
        '
        Me.ViewAllToolStripMenuItem.Name = "ViewAllToolStripMenuItem"
        Me.ViewAllToolStripMenuItem.Size = New System.Drawing.Size(197, 26)
        Me.ViewAllToolStripMenuItem.Text = "View All Children"
        '
        'UpdateMember
        '
        Me.UpdateMember.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.UpdateMember.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.UpdateMember.Location = New System.Drawing.Point(69, 0)
        Me.UpdateMember.Margin = New System.Windows.Forms.Padding(4)
        Me.UpdateMember.Name = "UpdateMember"
        Me.UpdateMember.Size = New System.Drawing.Size(65, 47)
        Me.UpdateMember.TabIndex = 120
        Me.UpdateMember.TabStop = False
        Me.UpdateMember.Text = "Update Child"
        Me.UpdateMember.UseVisualStyleBackColor = True
        '
        'ViewDatabase
        '
        Me.ViewDatabase.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ViewDatabase.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.ViewDatabase.Location = New System.Drawing.Point(144, 0)
        Me.ViewDatabase.Margin = New System.Windows.Forms.Padding(4)
        Me.ViewDatabase.Name = "ViewDatabase"
        Me.ViewDatabase.Size = New System.Drawing.Size(49, 47)
        Me.ViewDatabase.TabIndex = 121
        Me.ViewDatabase.TabStop = False
        Me.ViewDatabase.Text = "View Child"
        Me.ViewDatabase.UseVisualStyleBackColor = True
        '
        'Child_Name_Label
        '
        Me.Child_Name_Label.AutoSize = True
        Me.Child_Name_Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Child_Name_Label.Location = New System.Drawing.Point(-1, 188)
        Me.Child_Name_Label.Name = "Child_Name_Label"
        Me.Child_Name_Label.Size = New System.Drawing.Size(64, 25)
        Me.Child_Name_Label.TabIndex = 122
        Me.Child_Name_Label.Text = "Name"
        '
        'Child_Age_Label
        '
        Me.Child_Age_Label.AutoSize = True
        Me.Child_Age_Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Child_Age_Label.Location = New System.Drawing.Point(-1, 253)
        Me.Child_Age_Label.Name = "Child_Age_Label"
        Me.Child_Age_Label.Size = New System.Drawing.Size(48, 25)
        Me.Child_Age_Label.TabIndex = 123
        Me.Child_Age_Label.Text = "Age"
        '
        'Child_School_Label
        '
        Me.Child_School_Label.AutoSize = True
        Me.Child_School_Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Child_School_Label.Location = New System.Drawing.Point(-1, 321)
        Me.Child_School_Label.Name = "Child_School_Label"
        Me.Child_School_Label.Size = New System.Drawing.Size(73, 25)
        Me.Child_School_Label.TabIndex = 124
        Me.Child_School_Label.Text = "School"
        '
        'MemberID
        '
        Me.MemberID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.MemberID.Location = New System.Drawing.Point(4, 85)
        Me.MemberID.Margin = New System.Windows.Forms.Padding(4)
        Me.MemberID.Multiline = False
        Me.MemberID.Name = "MemberID"
        Me.MemberID.ReadOnly = True
        Me.MemberID.Size = New System.Drawing.Size(214, 34)
        Me.MemberID.TabIndex = 125
        Me.MemberID.TabStop = False
        Me.MemberID.Text = ""
        '
        'Member_Id_Label
        '
        Me.Member_Id_Label.AutoSize = True
        Me.Member_Id_Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Member_Id_Label.Location = New System.Drawing.Point(-1, 56)
        Me.Member_Id_Label.Name = "Member_Id_Label"
        Me.Member_Id_Label.Size = New System.Drawing.Size(105, 25)
        Me.Member_Id_Label.TabIndex = 126
        Me.Member_Id_Label.Text = "Member Id"
        '
        'Adult_Name_Label
        '
        Me.Adult_Name_Label.AutoSize = True
        Me.Adult_Name_Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Adult_Name_Label.Location = New System.Drawing.Point(-1, 528)
        Me.Adult_Name_Label.Name = "Adult_Name_Label"
        Me.Adult_Name_Label.Size = New System.Drawing.Size(64, 25)
        Me.Adult_Name_Label.TabIndex = 127
        Me.Adult_Name_Label.Text = "Name"
        '
        'AdultId
        '
        Me.AdultId.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.AdultId.Location = New System.Drawing.Point(0, 490)
        Me.AdultId.Margin = New System.Windows.Forms.Padding(4)
        Me.AdultId.Multiline = False
        Me.AdultId.Name = "AdultId"
        Me.AdultId.Size = New System.Drawing.Size(214, 34)
        Me.AdultId.TabIndex = 128
        Me.AdultId.TabStop = False
        Me.AdultId.Text = ""
        '
        'Adult_Id_Label
        '
        Me.Adult_Id_Label.AutoSize = True
        Me.Adult_Id_Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Adult_Id_Label.Location = New System.Drawing.Point(-1, 461)
        Me.Adult_Id_Label.Name = "Adult_Id_Label"
        Me.Adult_Id_Label.Size = New System.Drawing.Size(78, 25)
        Me.Adult_Id_Label.TabIndex = 129
        Me.Adult_Id_Label.Text = "Adult Id"
        '
        'DBUpdateHand
        '
        Me.DBUpdateHand.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.DBUpdateHand.Location = New System.Drawing.Point(201, 1)
        Me.DBUpdateHand.Margin = New System.Windows.Forms.Padding(4)
        Me.DBUpdateHand.Name = "DBUpdateHand"
        Me.DBUpdateHand.Size = New System.Drawing.Size(49, 46)
        Me.DBUpdateHand.TabIndex = 4
        Me.DBUpdateHand.Text = "Add Child"
        Me.DBUpdateHand.UseVisualStyleBackColor = True
        '
        'Remove
        '
        Me.Remove.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Remove.Location = New System.Drawing.Point(258, 0)
        Me.Remove.Margin = New System.Windows.Forms.Padding(4)
        Me.Remove.Name = "Remove"
        Me.Remove.Size = New System.Drawing.Size(74, 47)
        Me.Remove.TabIndex = 131
        Me.Remove.TabStop = False
        Me.Remove.Text = "Remove Child"
        Me.Remove.UseVisualStyleBackColor = True
        '
        'Remove_Adult
        '
        Me.Remove_Adult.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Remove_Adult.Location = New System.Drawing.Point(258, 408)
        Me.Remove_Adult.Margin = New System.Windows.Forms.Padding(4)
        Me.Remove_Adult.Name = "Remove_Adult"
        Me.Remove_Adult.Size = New System.Drawing.Size(77, 46)
        Me.Remove_Adult.TabIndex = 132
        Me.Remove_Adult.Text = "Remove Adult"
        Me.Remove_Adult.UseVisualStyleBackColor = True
        '
        'Add_Adult
        '
        Me.Add_Adult.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Add_Adult.Location = New System.Drawing.Point(201, 407)
        Me.Add_Adult.Margin = New System.Windows.Forms.Padding(4)
        Me.Add_Adult.Name = "Add_Adult"
        Me.Add_Adult.Size = New System.Drawing.Size(49, 46)
        Me.Add_Adult.TabIndex = 133
        Me.Add_Adult.Text = "Add Adult"
        Me.Add_Adult.UseVisualStyleBackColor = True
        '
        'Update_Adult
        '
        Me.Update_Adult.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Update_Adult.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Update_Adult.Location = New System.Drawing.Point(69, 407)
        Me.Update_Adult.Margin = New System.Windows.Forms.Padding(4)
        Me.Update_Adult.Name = "Update_Adult"
        Me.Update_Adult.Size = New System.Drawing.Size(65, 47)
        Me.Update_Adult.TabIndex = 134
        Me.Update_Adult.TabStop = False
        Me.Update_Adult.Text = "Update Adult"
        Me.Update_Adult.UseVisualStyleBackColor = True
        '
        'View_Adult
        '
        Me.View_Adult.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.View_Adult.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.View_Adult.Location = New System.Drawing.Point(144, 407)
        Me.View_Adult.Margin = New System.Windows.Forms.Padding(4)
        Me.View_Adult.Name = "View_Adult"
        Me.View_Adult.Size = New System.Drawing.Size(49, 47)
        Me.View_Adult.TabIndex = 135
        Me.View_Adult.TabStop = False
        Me.View_Adult.Text = "View Adult"
        Me.View_Adult.UseVisualStyleBackColor = True
        '
        'AdultAge
        '
        Me.AdultAge.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.AdultAge.Location = New System.Drawing.Point(0, 624)
        Me.AdultAge.Margin = New System.Windows.Forms.Padding(4)
        Me.AdultAge.Multiline = False
        Me.AdultAge.Name = "AdultAge"
        Me.AdultAge.Size = New System.Drawing.Size(214, 34)
        Me.AdultAge.TabIndex = 136
        Me.AdultAge.TabStop = False
        Me.AdultAge.Text = ""
        '
        'Adult_Age_Label
        '
        Me.Adult_Age_Label.AutoSize = True
        Me.Adult_Age_Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Adult_Age_Label.Location = New System.Drawing.Point(-5, 595)
        Me.Adult_Age_Label.Name = "Adult_Age_Label"
        Me.Adult_Age_Label.Size = New System.Drawing.Size(48, 25)
        Me.Adult_Age_Label.TabIndex = 137
        Me.Adult_Age_Label.Text = "Age"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Label2.Location = New System.Drawing.Point(231, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(118, 25)
        Me.Label2.TabIndex = 138
        Me.Label2.Text = "Relationship"
        '
        'RelationshipBox
        '
        Me.RelationshipBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.RelationshipBox.Location = New System.Drawing.Point(236, 85)
        Me.RelationshipBox.Margin = New System.Windows.Forms.Padding(4)
        Me.RelationshipBox.Multiline = False
        Me.RelationshipBox.Name = "RelationshipBox"
        Me.RelationshipBox.Size = New System.Drawing.Size(157, 34)
        Me.RelationshipBox.TabIndex = 139
        Me.RelationshipBox.TabStop = False
        Me.RelationshipBox.Text = ""
        '
        'Delete_All
        '
        Me.Delete_All.Location = New System.Drawing.Point(297, 162)
        Me.Delete_All.Name = "Delete_All"
        Me.Delete_All.Size = New System.Drawing.Size(75, 65)
        Me.Delete_All.TabIndex = 140
        Me.Delete_All.Text = "Delete All Children"
        Me.Delete_All.UseVisualStyleBackColor = True
        '
        'ChildView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1530, 778)
        Me.Controls.Add(Me.Delete_All)
        Me.Controls.Add(Me.RelationshipBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Adult_Age_Label)
        Me.Controls.Add(Me.AdultAge)
        Me.Controls.Add(Me.View_Adult)
        Me.Controls.Add(Me.Update_Adult)
        Me.Controls.Add(Me.Add_Adult)
        Me.Controls.Add(Me.Remove_Adult)
        Me.Controls.Add(Me.Remove)
        Me.Controls.Add(Me.DBUpdateHand)
        Me.Controls.Add(Me.Adult_Id_Label)
        Me.Controls.Add(Me.AdultId)
        Me.Controls.Add(Me.Adult_Name_Label)
        Me.Controls.Add(Me.Member_Id_Label)
        Me.Controls.Add(Me.MemberID)
        Me.Controls.Add(Me.Child_School_Label)
        Me.Controls.Add(Me.Child_Age_Label)
        Me.Controls.Add(Me.Child_Name_Label)
        Me.Controls.Add(Me.ViewDatabase)
        Me.Controls.Add(Me.UpdateMember)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ChildId)
        Me.Controls.Add(Me.Children_Label)
        Me.Controls.Add(Me.Adults_Label)
        Me.Controls.Add(Me.Adults_Grid)
        Me.Controls.Add(Me.AdultName)
        Me.Controls.Add(Me.ChildSchool)
        Me.Controls.Add(Me.ChildAge)
        Me.Controls.Add(Me.ChildName)
        Me.Controls.Add(Me.Children_Grid)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ChildView"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ChildView"
        CType(Me.Children_Grid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Adults_Grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Children_Grid As DataGridView
    Friend WithEvents ChildName As RichTextBox
    Friend WithEvents ChildAge As RichTextBox
    Friend WithEvents ChildSchool As RichTextBox
    Friend WithEvents AdultName As RichTextBox
    Friend WithEvents Adults_Grid As DataGridView
    Friend WithEvents Adults_Label As Label
    Friend WithEvents Children_Label As Label
    Friend WithEvents ChildId As RichTextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents MenuToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddChildToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddAdultToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UpdateMember As Button
    Friend WithEvents ViewDatabase As Button
    Friend WithEvents Child_Name_Label As Label
    Friend WithEvents Child_Age_Label As Label
    Friend WithEvents Child_School_Label As Label
    Friend WithEvents MemberID As RichTextBox
    Friend WithEvents Member_Id_Label As Label
    Friend WithEvents Adult_Name_Label As Label
    Friend WithEvents AdultId As RichTextBox
    Friend WithEvents Adult_Id_Label As Label
    Friend WithEvents DBUpdateHand As Button
    Friend WithEvents Remove As Button
    Friend WithEvents Remove_Adult As Button
    Friend WithEvents Add_Adult As Button
    Friend WithEvents Update_Adult As Button
    Friend WithEvents View_Adult As Button
    Friend WithEvents AdultAge As RichTextBox
    Friend WithEvents Adult_Age_Label As Label
    Friend WithEvents GoToToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label2 As Label
    Friend WithEvents RelationshipBox As RichTextBox
    Friend WithEvents Delete_All As Button
    Friend WithEvents ViewAllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ManualToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MainViewToolStripMenuItem As ToolStripMenuItem
End Class
